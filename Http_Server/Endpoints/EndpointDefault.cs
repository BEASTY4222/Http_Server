using Microsoft.EntityFrameworkCore;
using Utilities;
using Data;
using System.Reflection.Metadata;

namespace Endpoint
{
    // Default endpoint
    public class DefaultEndPoint : Endpoint
    {
        public DefaultEndPoint(WebApplication app) : base(app)
        {
            endpointApp.MapGet("/", () => 
            "Hello People! Welcome to my Http Server! \n" + 
            "This is the default endpoint, you can change it if you want :) \n" +
            "USER ENDPOINTS: \n" +
            "GET /users - Get all users from the database \n" +
            "GET /user - Get the current user from the database!!!MUST BE LOGGED IN OR JUST SIGNED IN!!! \n" +
            "POST /users/signup - Create a new user and add it to the database \n" +
            "POST /users/login - Login endpoint (definitely should not be like this FIX LATER) \n" +
            "GET /users/count - Get the count of users in the database \n" +
            "DEV ENDPOINTS: \n" +
            "GET /dev - see the developer behind the server \n" +
            "GET /dev/photo - SEE the developer behind the server");
        }
    }
}