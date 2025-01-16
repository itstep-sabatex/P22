// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Net;
using System.Net.Sockets;
using System.Text;

var udpServer = Task.Run(() =>
{
    UdpClient udpClient = new UdpClient();
    var endPoint = new IPEndPoint(IPAddress.Any, 10000);
    udpClient.Client.Bind(endPoint);
    while (true)
    {
        Console.WriteLine("Waiting for connection...");
        var data = udpClient.Receive(ref endPoint);
        var message = Encoding.UTF8.GetString(data);
        Console.WriteLine($"Data from client: {message}");
        
 //       var responce = Encoding.UTF8.GetBytes("By");
 //       udpClient.Send(responce, responce.Length, endPoint);
    }
});

var udpClient = Task.Run(() =>
{


    UdpClient udpClient = new UdpClient();
    var message = Encoding.UTF8.GetBytes("Hello from client");
    for (int i = 0; i < 10; i++)
    {
        udpClient.Send(message, message.Length, "localhost", 10000);
        var message2 = Encoding.UTF8.GetBytes("Hello from client (Brodcast)");
        udpClient.Send(message2, message2.Length, "255.255.255.255", 10000); //broadcast
        Thread.Sleep(1000);
    }
});


Console.ReadLine();