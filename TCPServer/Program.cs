using System;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;

namespace TCPServer
{
    public class TCPServer
    {
        private static Server server;

        public static void Main()
        {
            
        }
    }

    public class Server
    {
        private static TcpListener server;

        private bool bIsRunning = false;

        private int port;
        StreamWriter writer;
        StreamReader reader;

        public Server()
        {
            port = 5000;
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
}