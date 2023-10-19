using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using LibSlide;

namespace Slide;

public class Slide
{
    public static void Main(string[] args)
    {
        var client = new TcpClient();
        client.BeginConnect("127.0.0.1", Constants.MainPort
    }
}
