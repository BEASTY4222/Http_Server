using Data;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace Endpoint
{
    public class EndpointDev : Endpoint
    {
        public EndpointDev(WebApplication app) : base(app)
        {
            endpointApp.MapGet("/dev",async (AppDbContext db) =>
            {
                var users = await db.Users.FindAsync(1);

                MyJsonDev dev = new MyJsonDev(users.Name, users.Email, users.Age);

                return dev;
            });

            endpointApp.MapGet("/dev/photo",() =>
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Photos", "PhotoDev.png");
                return Results.File(path, "image/png");
            });
        }
    }
}