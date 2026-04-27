namespace Endpoint{
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

}