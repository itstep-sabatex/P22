// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using System.Text;

var server = Task.Run(() =>
{
    var ipAddres = IPAddress.Parse("127.0.0.1");
    var tcpListener = new TcpListener(ipAddres, 10000);
    tcpListener.Start();
    while (true)
    {
        Console.WriteLine("Waiting for connection...");
        var tcpClient = tcpListener.AcceptTcpClient();
        Task.Run(() => 
        {
            Console.WriteLine("Connected");
            var stream = tcpClient.GetStream();
             var buffer = new byte[1024];
            var data = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(buffer, 0, buffer.Length);
                data.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
            }
            while (!data.ToString().EndsWith("EOF\r\n"));
            Console.WriteLine($"Data from client: {data}");
            string responce = "By\r\n";
            var responceData = Encoding.UTF8.GetBytes(responce);
            stream.Write(responceData, 0, responceData.Length);
            tcpClient.Close(); 

        });


 
    }
});

var client = Task.Run(() =>
{
    var tcpClient = new TcpClient("127.0.0.1",10000);
    var message = "Hello from client\r\nEOF\r\n";
    byte[] data = Encoding.UTF8.GetBytes(message);
    NetworkStream stream = tcpClient.GetStream();
    stream.Write(data, 0, data.Length); ;
    Console.WriteLine($"Data sent : {message}");
    data = new byte[1024];
    var bytes = stream.Read(data, 0, data.Length);
    var responce = Encoding.UTF8.GetString(data, 0, bytes);
    Console.WriteLine($"Responce from server: {responce}");
    stream.Close();
    tcpClient.Close();


});

Console.ReadLine();