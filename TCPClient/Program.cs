using System;
using System.Text;
using System.Net.Sockets;

namespace TCPClient
{
    public class TCPClient
    {
        private static Client client;

        public static string ipaddress
        {
            private get;
            set;
        }

        public static string username
        {
            private get;
            set;
        }

        public static void Main()
        {

            if (ipaddress != String.Empty && username != String.Empty)
            {
                client = new Client(ipaddress, username);
                client.Start();

            }
        }
    }

    public class Client
    {
        private TcpClient m_client;
        private StreamWriter m_writer;
        private StreamReader m_reader;

        private bool bIsConnected;

        private string? sUserName;

        public Client(string ipaddress, string username)
        {
            m_client = new TcpClient();
            m_client.Connect(ipaddress, 5000);

            this.sUserName = username;

            HandleCommunication();
        }

        public void Start()
        {
            HandleCommunication();
        }


        private void HandleCommunication()
        {
            m_reader = new StreamReader(m_client.GetStream(), Encoding.ASCII);
            m_writer = new StreamWriter(m_client.GetStream(), Encoding.ASCII);

            m_writer.WriteLine(sUserName);
            m_writer.Flush();

            bIsConnected = true;

            String sData = String.Empty;

            while (bIsConnected)
            {
                Console.Write("Eingabe: ");

                sData = Console.ReadLine();

                m_writer.WriteLine(sData);
                m_writer.Flush();
            }
        }
    }
}