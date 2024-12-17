using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Console_Messenger
{
    internal class SocketBasedServer
    {
        private IPAddress? m_ip = IPAddress.Any;
        private const int m_nPort = 5000;

        private IPEndPoint m_oIpEndPoint;
        private Socket? handler;

        private byte[] buffer = new byte[1_024];
        private const string eom = "<|EOM|>"; 
        private const string ackMessage = "<|ACK|>";

        public SocketBasedServer()
        {
            m_oIpEndPoint = new IPEndPoint(m_ip, m_nPort);
        }

        public async void RecieveWithServer()
        {
            using Socket listener = new(
                m_oIpEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            listener.Bind(m_oIpEndPoint);
            listener.Listen(100);


            while (true)
            {
                handler = await listener.AcceptAsync();
                
                int received = await handler.ReceiveAsync(buffer, SocketFlags.None);
                string response = Encoding.UTF8.GetString(buffer, 0, received);

                if (response.IndexOf(eom) > -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Socket server received message: \"{response.Replace(eom, "")}\"");

                    byte[] echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                    await handler.SendAsync(echoBytes, 0);
                }
                else 
                {
                    break;
                }
            }
        }
    }
}
