using System.Net.Sockets;
using System.Text;

namespace Program.Server;

public class TCPServer
{
    private static TcpListener server;

    private static bool bIsRunning = false;

    private static int port = 5000;
    StreamWriter writer;
    StreamReader reader;

    public TCPServer()
    {
        
    }

    public void start()
    {
        Thread t = new Thread(handleCommunication);
        t.Start();
    }

    private void handleCommunication()
    {
        server = new TcpListener(port);
        server.Start();

        while (bIsRunning)
        {
            TcpClient client = server.AcceptTcpClient();
            Thread clientThread = new Thread(new ParameterizedThreadStart(handleClient));
            clientThread.Start(client);
        }

    }

    private void handleClient(object obj)
    {
        string name;

        TcpClient client = (TcpClient)obj;

        writer = new StreamWriter(client.GetStream(), Encoding.ASCII);
        reader = new StreamReader(client.GetStream(), Encoding.ASCII);

        bool isClientConnected = true;

        string sData = String.Empty;

        name = reader.ReadLine();

        while (isClientConnected)
        {
            sData = reader.ReadLine();

            if (sData != String.Empty)
            {
                Console.WriteLine(name + ": " + sData);
            }
        }
    }
}