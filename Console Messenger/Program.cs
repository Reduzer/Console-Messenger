using System;
using TCPClient;
using TCPServer;

namespace Program
{
    public class Program
    {
        private static string sUserName = String.Empty;
        private static string sIPAdress = String.Empty;


        public static void Main()
        {
            init();

            TCPServer.TCPServer.Main();
            TCPClient.TCPClient.ipaddress = sIPAdress;
            TCPClient.TCPClient.ipaddress = sUserName;
            TCPClient.TCPClient.Main();
        }


        private static void getIPandPort()
        {
            Console.WriteLine("Please write down the IPAdress you want to connect to: ");
            sIPAdress = Convert.ToString(Console.ReadLine());
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