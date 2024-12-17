<<<<<<< HEAD
﻿using Console_Messenger;
using System;
=======
﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
>>>>>>> origin/Master
using TCPClient;
using TCPServer;

namespace Program
{
    public class Program
    {
<<<<<<< HEAD
        static bool ContinueRunning = true;
        static string? inp;

        static SocketBasedServer server = new SocketBasedServer();
        static SocketBasedClient client = new SocketBasedClient();

        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Program is Starting");

            Console.ForegroundColor = ConsoleColor.Gray;
=======
        private static TCPServer.ServerTry Server;

        private static string sUserName = String.Empty;
        private static string sIPAdress = String.Empty;
        private static string sPort = String.Empty;

        public static void Main()
        {
            Console.WriteLine("Program is starting!");
            init();

            Server = new TCPServer.ServerTry(sIPAdress, sPort);

            Server.m_bIsRunning = true;
            Server.test();
            Input();

            Console.WriteLine("Program stopped!");
            Console.ReadKey();
        }

        private static void Input()
        {
            try
            {
                while (true)
                {
                    string sInput = Convert.ToString(Console.ReadLine());
                    if (sInput == String.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        if (sInput == ":q")
                        {
                            Server.m_bIsRunning = false;
                            return;
                        }
                        else
                        {
                            //Send to other user
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.ToString());
            }
            catch (OverflowException e)
            {
                Debug.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
>>>>>>> origin/Master

            Console.WriteLine("Please write the ip you want to connect to:");
            inp = Console.ReadLine();
            client.IP = inp;

<<<<<<< HEAD
            Console.Clear();
=======
        private static void getIPandPort()
        {
            Console.WriteLine("Please write down the IPAdress you want to connect to: ");
            sIPAdress = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Please write down the Port you want to connect on: ");
            sPort = Convert.ToString(Console.ReadLine());
        }
>>>>>>> origin/Master

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