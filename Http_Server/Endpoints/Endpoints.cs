using Microsoft.EntityFrameworkCore;
using Utilities;
using Data;
using System.Reflection.Metadata;

namespace Endpoints
{
    // Endpoint base class
    // I think this is a good use since 
    // all the endpoint will use smiliar code 
    // to create the endpoints and this way we can avoid code duplication
    // (a.k.a less code to maintain)
    public class Endpoints
    {
        public Endpoints(WebApplication app)
        {
            endpointApp = app;
        }

        protected WebApplication endpointApp { get; set; }
    }

    // Default endpoint
    public class DefaultEndPoint : Endpoints
    {
        public DefaultEndPoint(WebApplication app) : base(app)
        {
            endpointApp.MapGet("/", () => "Hello People! Welcome to my Http Server! \n" + 
            "This is the default endpoint, you can change it if you want :) \n" +
            "(/users)");
        }
    }

    // User endpoint
    public class UserEndpoints : Endpoints
    {
        public UserEndpoints(WebApplication app) : base(app)
        {
            // Get all users from the database and show them in the endpoint
            endpointApp.MapGet("/users", async (AppDbContext db) =>
            {
                // Get all users from the database
                return await db.Users.ToListAsync();
            });

            // Create a new user and add it to the database
            endpointApp.MapPost("/users", async (MyJsonUser newUser, AppDbContext db) =>
            {
                try
                {
                    PasswordChecker.IsValidPassword(newUser.Password);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
                


                // Add the new user to the database
                db.Users.Add(newUser);
                await db.SaveChangesAsync();

                return Results.Ok("User created successfully!");
            });

            // Get the count of users in the database
            endpointApp.MapGet("/users/count", async (AppDbContext db) =>
            {
                // Get the count of users from the database
                return await db.Users.CountAsync();
            });
        }
    }
}