// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Net;
using System.Text;

//var ipAddres = IPAddress.Parse("127.0.0.1");


IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 10000);

var socketListener = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


try
{
    socketListener.Bind(iPEndPoint);
    socketListener.Listen(10);
    while (true)
    {
        Console.WriteLine($"Waiting for connection in {iPEndPoint} ...");
        Socket connectedSocket = socketListener.Accept();
        Console.WriteLine($"Connected from {connectedSocket.RemoteEndPoint}");
        var buffer = new byte[1024];
        var data = new StringBuilder();
        int bytes = 0;
        do
        {
            bytes = connectedSocket.Receive(buffer, buffer.Length, 0);
            data.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
        } while (!data.ToString().EndsWith("EOF\r\n"));
        Console.WriteLine($"Data from client: {data}");
        string responce = "By\r\n";
        var responceData = Encoding.UTF8.GetBytes(responce);
        connectedSocket.Send(responceData);
        connectedSocket.Close();
    }

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    socketListener.Close();
}


