using Microsoft.EntityFrameworkCore;
using System.Net;
using Utilities;
using Endpoint;
using Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Database connection 
var connectionString = "Host=localhost;Database=LocalDev;Username=postgres;Password=ivancho181";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

WebApplication app = builder.Build();

MyJsonUserCurrent userCurrent = new MyJsonUserCurrent();

DefaultEndPoint defaultEndpoint = new DefaultEndPoint(app);

UserEndpoints userEndpoint = new UserEndpoints(app, userCurrent);




app.Run();
