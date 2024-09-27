using MTCG_MHL.Business.Logic.Http;
using MTCG_MHL.Models.HTTP;

namespace MTCG_MHL.Business.Endpoints
{
    public class UserEndpoint
    {
        public void HandleRequest(Request request, Response response)
        {
            if (request.Method == "POST" && request.Path == "/users")
            {
                RegisterUser(request, response);
            }
            else if (request.Method == "POST" && request.Path == "/sessions")
            {
                LoginUser(request, response);
            }
            else
            {
                response.StatusCode = 404;
                response.ReasonPhrase = "Not Found";
                response.Body = "The requested resource was not found.";
            }
        }

        private void RegisterUser(Request request, Response response)
        {
            // Extract user data from request.Body
            // Perform registration logic
            // Set response.StatusCode, response.Body, etc.
            response.StatusCode = 201;
            response.ReasonPhrase = "Created";
            response.Body = "User registered successfully.";
        }

        private void LoginUser(Request request, Response response)
        {
            // Extract credentials from request.Body
            // Perform authentication logic
            // Set response.StatusCode, response.Body, etc.
            response.StatusCode = 200;
            response.ReasonPhrase = "OK";
            response.Body = "User logged in successfully.";
        }
    }
}