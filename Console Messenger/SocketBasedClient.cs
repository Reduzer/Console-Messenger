using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Console_Messenger
{
    internal class SocketBasedClient
    {
        private const int m_nPort = 5000;
        private bool bIsConnected;
        private IPAddress m_ip;

        private IPEndPoint m_oIpEndPoint;

        public SocketBasedClient()
        {
            m_ip = IPAddress.Loopback;

            m_oIpEndPoint = new IPEndPoint(m_ip, m_nPort);
        }

        public bool Send(string? sJSONString)
        {
            if (sJSONString == ":q")
            {
                return false;
            }

            if (sJSONString == String.Empty)
            {
                return true;
            }

            SendWithClient(sJSONString);
            return true;
        }

        public string IP
        {
            set { m_ip = IPAddress.Parse(value); }
        }

        private async void SendWithClient(string? message)
        {
            using Socket client = new(
                m_oIpEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            await client.ConnectAsync(m_oIpEndPoint);
            bIsConnected = true;

            while (bIsConnected)
            {
                message += "<|EOM|>";
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                _ = await client.SendAsync(messageBytes, SocketFlags.None);
                Console.WriteLine($"Socket client sent message: \"{message}\"");

                // Receive ack.
                var buffer = new byte[1_024];
                var received = await client.ReceiveAsync(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(
                        $"Socket client received acknowledgment: \"{response}\"");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    bIsConnected = false;
                }
            }
        }
    }
}
