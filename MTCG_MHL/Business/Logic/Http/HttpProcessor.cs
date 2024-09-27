using System;
using System.IO;
using System.Net.Sockets;
using MTCG_MHL.Business.Endpoints;
using MTCG_MHL.Models.HTTP;

namespace MTCG_MHL.Business.Logic.Http
{
    public class HttpProcessor
    {
        private readonly HttpRequest _requestHandler;
        private readonly HttpResponse _responseHandler;

        public HttpProcessor()
        {
            _requestHandler = new HttpRequest();
            _responseHandler = new HttpResponse();
        }

        public void ProcessRequest(TcpClient clientSocket)
        {
            using var networkStream = clientSocket.GetStream();
            using var reader = new StreamReader(networkStream);
            using var writer = new StreamWriter(networkStream) { AutoFlush = true };

            // ----- 1. Read the HTTP Request -----
            var request = _requestHandler.ReadRequest(reader);
            var response = new Response();
            if (request.Path == "/users" || request.Path == "/sessions")
            {
                var userEndpoint = new UserEndpoint();
                userEndpoint.HandleRequest(request, response);
            }
            else if (request.Path == "/packages")
            {
                var packageEndpoint = new PackageEndpoint();
                packageEndpoint.HandleRequest(request, response);
            }
            else
            {
                response.StatusCode = 404;
                response.ReasonPhrase = "Not Found";
                response.Body = "The requested resource was not found.";
            }
            

            // ----- 3. Send the HTTP Response -----
            _responseHandler.SendResponse(writer, response);
        }
    }
}