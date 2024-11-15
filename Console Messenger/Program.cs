using System;
using Program.Client;
using Program.Server;

namespace Program
{
    public class Program
    {
        private static TCPClient m_client;
        private static TCPServer m_server;
        
        private static string sIPAdress = String.Empty;
        private static int nPort;

        private static string sUserName = String.Empty;
        
        /// <summary>
        /// Start of the Program
        /// </summary>
        public static void Main()
        {
            init();

            m_client = new TCPClient(sIPAdress,nPort, sUserName);
            m_server = new TCPServer(nPort);

            Console.Clear();

            m_server.start(); 
            m_client.Start();
        }


        private static void getIPandPort()
        {
            Console.WriteLine("Please write down the IPAdress you want to connect to: ");
            sIPAdress = Convert.ToString(Console.ReadLine());

            nPort = 5000;
        }

        private static void getUserName()
        {
            Console.WriteLine("Please write your Username");
            sUserName = Convert.ToString(Console.ReadLine());
        }

        private static void init()
        {
            getIPandPort();
            getUserName();
        }
    }
}