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
            "It's a simple site I made you can register or log in \n" + 
            "This site was made purely for educational purpose \n" +
            "But it coulde be transformed into a cv website for me.");
        }
    }
}