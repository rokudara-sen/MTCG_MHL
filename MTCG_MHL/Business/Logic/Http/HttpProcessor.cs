using System.IO;
using System.Net.Sockets;
using System.Text;

namespace MTCG_MHL.Business.Logic.Http;

public class HttpProcessor
{
    private readonly RequestHandler _requestHandler;

    public HttpProcessor()
    {
        _requestHandler = new RequestHandler();
    }

    public void ProcessRequest(TcpClient clientSocket)
    {
        using var writer = new StreamWriter(clientSocket.GetStream()) { AutoFlush = true };
        using var reader = new StreamReader(clientSocket.GetStream());

        // Read request
        var requestLine = reader.ReadLine();
        if (requestLine == null) 
            return;

        // Split the request line (e.g., "POST /users HTTP/1.1")
        var tokens = requestLine.Split(' ');
        var method = tokens[0];
        var path = tokens[1];

        // Read the HTTP headers (you can skip this part or parse it if needed)
        string? line;
        int contentLength = 0;
        while ((line = reader.ReadLine()) != null && line != "")
        {
            if (line.StartsWith("Content-Length"))
            {
                contentLength = int.Parse(line.Split(':')[1].Trim());
            }
        }

        // Read the request body (if present)
        string requestBody = null;
        if (contentLength > 0)
        {
            char[] bodyChars = new char[contentLength];
            reader.Read(bodyChars, 0, contentLength);
            requestBody = new string(bodyChars);
        }

        // Handle request and get response
        var response = _requestHandler.HandleRequest(method, path, requestBody);

        // Write response
        WriteHttpResponse(writer, response);
    }

    private void WriteHttpResponse(StreamWriter writer, string response)
    {
        writer.WriteLine("HTTP/1.0 200 OK");
        writer.WriteLine("Content-Type: application/json; charset=utf-8");
        writer.WriteLine();
        writer.WriteLine(response);
    }
}