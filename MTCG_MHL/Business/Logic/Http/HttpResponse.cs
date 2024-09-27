using System;
using System.IO;
using MTCG_MHL.Models.HTTP;

namespace MTCG_MHL.Business.Logic.Http
{
    public class HttpResponse
    {
        public void SendResponse(StreamWriter writer, Response response)
        {
            var writerAlsoToConsole = new StreamTracer(writer);  // Helper class to write to both client and console

            // First line: HTTP-Version Status-Code Reason-Phrase
            writerAlsoToConsole.WriteLine($"{response.HttpVersion} {response.StatusCode} {response.ReasonPhrase}");

            // Ensure Content-Length header is set
            if (!response.Headers.ContainsKey("Content-Length"))
            {
                response.Headers["Content-Length"] = response.Body.Length.ToString();
            }

            // Write headers
            foreach (var header in response.Headers)
            {
                writerAlsoToConsole.WriteLine($"{header.Key}: {header.Value}");
            }

            // Empty line to indicate end of headers
            writerAlsoToConsole.WriteLine();

            // Write the body
            if (!string.IsNullOrEmpty(response.Body))
            {
                writerAlsoToConsole.WriteLine(response.Body);
            }

            Console.WriteLine("========================================");
        }
    }
}