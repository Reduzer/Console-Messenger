using System.Net.Sockets;
using System.Text;

namespace Program.Client;


public class TCPClient
{
    private TcpClient m_client;
    private StreamWriter m_writer;
    private StreamReader m_reader;

    private bool bIsConnected;

    private string? sUserName;
    
    public TCPClient(string ipaddress, int port, string username)
    {
        m_client = new TcpClient();
        m_client.Connect(ipaddress, port);

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