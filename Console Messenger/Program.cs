using Console_Messenger;
using System;
using TCPClient;
using TCPServer;

namespace Program
{
    public class Program
    {
        static bool ContinueRunning = true;
        static string? inp;

        static SocketBasedServer server = new SocketBasedServer();
        static SocketBasedClient client = new SocketBasedClient();

        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Program is Starting");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Please write the ip you want to connect to:");
            inp = Console.ReadLine();
            client.IP = inp;

            Console.Clear();

            Thread tServer;

            tServer = new Thread(server.RecieveWithServer);
            tServer.Start();

            try
            {
                while (ContinueRunning)
                {
                    inp = Convert.ToString(Console.ReadLine());

                    ContinueRunning = client.Send(inp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught!\n{0}", ex.Message);
            }

            Console.ReadKey();
            
        }
    }
}