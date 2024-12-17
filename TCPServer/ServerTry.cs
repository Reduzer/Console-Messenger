using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    public class ServerTry
    {
        private string m_sIPAdress;
        private string m_sPortNumber;
        public bool m_bIsRunning;

        public ServerTry(string sIPAdress, string sPortNumber)
        {
            this.m_sPortNumber = sPortNumber;
            this.m_sIPAdress = sIPAdress;
        }

        public void test() 
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(m_sIPAdress);
                int nPort = int.Parse(m_sPortNumber);

                Console.WriteLine("Starting TCP listener...");

                TcpListener listener = new TcpListener(ipAddress, nPort);

                listener.Start();

                while (m_bIsRunning)
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
            catch(SocketException e)
            {
                Console.WriteLine("Exception on socket! \n Message: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
                Console.ReadLine();
            }

        }
    }   
}
