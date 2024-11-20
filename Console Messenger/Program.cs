using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TCPClient;
using TCPServer;

namespace Program
{
    public class Program
    {
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


        private static void getIPandPort()
        {
            Console.WriteLine("Please write down the IPAdress you want to connect to: ");
            sIPAdress = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Please write down the Port you want to connect on: ");
            sPort = Convert.ToString(Console.ReadLine());
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