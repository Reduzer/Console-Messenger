using System.Net.Sockets;

namespace Program.Server;

public class TCPServer
{
    private static TcpListener server;

    private static bool isRunning = false;

    private static int port = 5000;
    public TCPServer()
    {
        
    }
}