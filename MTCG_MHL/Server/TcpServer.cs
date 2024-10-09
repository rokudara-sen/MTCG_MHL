using System;
using System.Net;
using System.Net.Sockets;
using MTCG_MHL.Business.Logic.Http;
using MTCG_MHL.DataAccess.Repositories;

namespace MTCG_MHL.Server
{
    public class TcpServer
    {
        private readonly TcpListener _httpServer;
        private readonly HttpProcessor _httpProcessor;

        public TcpServer(IPAddress ipAddress, int port)
        {
            _httpServer = new TcpListener(ipAddress, port);
            _httpProcessor = new HttpProcessor();
        }

        public void Start()
        {
            Console.WriteLine("Our first simple HTTP-Server: http://localhost:10001/");

            // ===== I. Start the HTTP-Server =====
            _httpServer.Start();

            while (true)
            {
                // ----- 0. Accept the TCP-Client -----
                var clientSocket = _httpServer.AcceptTcpClient();
                _httpProcessor.ProcessRequest(clientSocket);
            }
        }
    }
}