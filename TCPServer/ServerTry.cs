using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    internal class ServerTry
    {
        public void test() 
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse("10.30.126.138");

                Console.WriteLine("Starting TCP listener...");

                TcpListener listener = new TcpListener(ipAddress, 500);

                listener.Start();

                while (true)
                {
                    Console.WriteLine("Server is listening on " + listener.LocalEndpoint);

                    Console.WriteLine("Waiting for a connection...");

                    Socket client = listener.AcceptSocket();

                    Console.WriteLine("Connection accepted.");

                    Console.WriteLine("Reading data...");

                    byte[] data = new byte[100];
                    int size = client.Receive(data);
                    Console.WriteLine("Recieved data: ");
                    for (int i = 0; i < size; i++)
                        Console.Write(Convert.ToChar(data[i]));

                    Console.WriteLine();

                    client.Close();
                }

                listener.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
                Console.ReadLine();
            }

        }
    }   
}
