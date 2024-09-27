namespace MTCG_MHL.Models.HTTP;

public class Response
{
    public string HttpVersion { get; set; } = "HTTP/1.1";
    public int StatusCode { get; set; } = 200;
    public string ReasonPhrase { get; set; } = "OK";
    public Dictionary<string, string> Headers { get; set; } = new();
    public string Body { get; set; } = "";
}