using Microsoft.EntityFrameworkCore;
using System.Net;
using Utilities;
using Endpoints;
using Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Database connection 
var connectionString = "Host=localhost;Database=LocalDev;Username=postgres;Password=ivancho181";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

WebApplication app = builder.Build();

DefaultEndPoint defaultEndpoint = new DefaultEndPoint(app);

UserEndpoint userEndpoint = new UserEndpoint(app);



app.Run();
