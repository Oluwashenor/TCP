using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    
    static void Main(string[] args)
    {
        var clientId = "clientA";
        Console.WriteLine("Starting Up Client A");
        var myIp = "192.168.42.146";
        TcpClient client = new TcpClient(myIp, 12345);
        NetworkStream stream = client.GetStream();
        Console.WriteLine("Connected to Server");

        while (true)
        {
            Console.WriteLine("You:");
            string message = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            if(message.ToLower() == "exit")
            {
                break;
            }
        }
        client.Close();
    }
}