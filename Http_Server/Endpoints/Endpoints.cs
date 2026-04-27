using Microsoft.EntityFrameworkCore;
using Utilities;
using Data;
using System.Reflection.Metadata;

namespace Endpoint
{
    // Endpoint base class
    // I think this is a good use since 
    // all the endpoint will use smiliar code 
    // to create the endpoints and this way we can avoid code duplication
    // (a.k.a less code to maintain)
    public class Endpoint
    {
        public Endpoint(WebApplication app)
        {
            endpointApp = app;
        }

        protected WebApplication endpointApp { get; set; }
    }

    // Default endpoint
    public class DefaultEndPoint : Endpoint
    {
        public DefaultEndPoint(WebApplication app) : base(app)
        {
            endpointApp.MapGet("/", () => "Hello People! Welcome to my Http Server! \n" + 
            "This is the default endpoint, you can change it if you want :) \n" +
            "USER ENDPOINTS: \n" +
            "GET /users - Get all users from the database \n" +
            "POST /users/signup - Create a new user and add it to the database \n" +
            "POST /users/login - Login endpoint (definitely should not be like this FIX LATER) \n" +
            "GET /users/count - Get the count of users in the database");
        }
    }

    // User endpoint
    public class UserEndpoints : Endpoint
    {
        public UserEndpoints(WebApplication app, MyJsonUserCurrent userCurrent) : base(app)
        {
            // Get all users from the database and show them in the endpoint
            endpointApp.MapGet("/users", async (AppDbContext db) =>
            {
                // Get all users from the database
                return await db.Users.ToListAsync();
            });

            // Create a new user and add it to the database
            endpointApp.MapPost("/users/signup", async (MyJsonUser newUser, AppDbContext db) =>
            {
                // Check if the email is valid
                try
                {
                    await EmailChecker.IsValidEmail(newUser.Email, db);                    
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }

                // Check if the password is valid
                try
                {
                    PasswordChecker.IsValidPassword(newUser.Password);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
                
                userCurrent.Id = newUser.Id;
                userCurrent.Name = newUser.Name;
                userCurrent.Email = newUser.Email;

                // Add the new user to the database
                db.Users.Add(newUser);
                await db.SaveChangesAsync();

                return Results.Ok("User created successfully!");
            });

            // Login endpoint PS it definitely should not be like this FIX LATER
            // (a.k.a add a check for the password and add a token or something like that) 
            endpointApp.MapPost("/users/login", async (MyJsonUserLogIn loginUser, AppDbContext db) =>
            {
                // Check if the user exists in the database
                var user = await db.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email);

                if (user == null)
                {
                    return Results.NotFound("User not found.");
                }
                
                userCurrent.Id = user.Id;
                userCurrent.Name = user.Name;
                userCurrent.Email = user.Email;

                return Results.Ok("Login successful! Welcome " + user.Name);
            });

            endpointApp.MapGet("/user", async (AppDbContext db) =>
            {
                var user = await db.Users.FindAsync(userCurrent.Id);
                // Get all users from the database
                return user;
            });

            // Get the count of users in the database
            endpointApp.MapGet("/users/count", async (AppDbContext db) =>
            {
                // Get the count of users from the database
                return Results.Ok("Total users in the database: " + await db.Users.CountAsync());
            });
        }
    }
}