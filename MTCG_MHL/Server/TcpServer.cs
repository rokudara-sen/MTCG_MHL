using System.Net;
using System.Net.Sockets;
using MTCG_MHL.Business.Logic.Http;

namespace MTCG_MHL.Server;

public class TcpServer
{
    private readonly TcpListener _listener;
    private readonly HttpProcessor _httpProcessor;
    public TcpServer(string ip, int port)
    {
        _listener = new TcpListener(IPAddress.Parse(ip), port);
        _httpProcessor = new HttpProcessor();
    }

    public void Start()
    {
        Console.WriteLine("Starting the server...");
        _listener.Start();

        while (true)
        {
            var clientSocket = _listener.AcceptTcpClient();
            _httpProcessor.ProcessRequest(clientSocket);
        }
    }
}