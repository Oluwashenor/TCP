using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static TcpListener server;
    static void Main(string[] args)
    {
        Console.WriteLine("Setting up your TCP Server");
        var myIp = "192.168.42.146";
        server = new TcpListener(IPAddress.Parse(myIp), 12345);
        server.Start();

        Console.WriteLine($"Server is listening on TCP Server with IP {myIp}");

        while(true)
        {
            TcpClient client = server.AcceptTcpClient();
            Thread clientThread = new Thread(() => HandleClient(client));
            clientThread.Start();
        }
    }

    static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        while (true)
        {
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);    
            Console.WriteLine(message);
            if(message.ToLower() == "exit")
            {
                break;
            }
        }
        client.Close();
    }
}