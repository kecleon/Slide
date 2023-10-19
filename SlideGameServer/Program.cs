using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using LibSlide;

namespace SlideGameServer;

public class SlideServer
{
    public static void Main(string[] args)
    {
        var port = int.Parse(args[0]);
        
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");

        TcpListener server = new TcpListener(localAddr, port);

        server.Start();
        Console.WriteLine($"Server started on {localAddr}:{port}");

        while (true)
        {
            Console.WriteLine("Waiting for a connection...");
            TcpClient client = server.AcceptTcpClient();

            Console.WriteLine("Connected!");

            NetworkStream stream = client.GetStream();

            StreamReader reader = new StreamReader(stream, Encoding.ASCII);
            string requestLine = reader.ReadLine();

            if (requestLine != null && requestLine.StartsWith("GET /account/servers"))
            {
                // Craft your custom response for this specific endpoint
                string responseBody = "{\"servers\":[\"Your fake server data here\"]}";
                string responseHeaders = "HTTP/1.1 200 OK\r\n" +
                                         "Content-Type: application/json\r\n" +
                                         $"Content-Length: {responseBody.Length}\r\n" +
                                         "\r\n";
                string fullResponse = responseHeaders + responseBody;

                byte[] responseBytes = Encoding.ASCII.GetBytes(fullResponse);
                stream.Write(responseBytes, 0, responseBytes.Length);
                Console.WriteLine("Sent custom response.");
            }
            else
            {
                // Generic response for all other requests
                string responseString = "HTTP/1.1 200 OK\r\nContent-Length: 0\r\n\r\n";
                byte[] responseBytes = Encoding.ASCII.GetBytes(responseString);
                stream.Write(responseBytes, 0, responseBytes.Length);
                Console.WriteLine("Sent default response.");
            }

            client.Close();
        }
    }
}
