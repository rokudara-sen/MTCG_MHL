using MTCG_MHL.Interface;
using MTCG_MHL.Models.HTTP;

namespace MTCG_MHL.Business.Endpoints;

public class PackageEndpoint : IEndpoint
{
    public void HandleRequest(Request request, Response response)
    {
        if (request.Method == "POST")
        {
            CreatePackage(request, response);
        }
        else
        {
            response.StatusCode = 404;
            response.ReasonPhrase = "Not Found";
            response.Body = "The requested resource was not found.";
        }
    }

    private void CreatePackage(Request request, Response response)
    {
        response.StatusCode = 201;
        response.ReasonPhrase = "Created";
        response.Body = "Package created successfully.";
    }
}