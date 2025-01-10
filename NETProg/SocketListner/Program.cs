// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;


var listener = Task.Run(() =>
{
    var ipAddres = IPAddress.Parse("127.0.0.1");
    IPEndPoint iPEndPoint = new IPEndPoint(ipAddres, 10000);

    var socketListener = new Socket(ipAddres.AddressFamily,SocketType.Stream,ProtocolType.Tcp);
    

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

});


var client = Task.Run(() =>
{
    var ipaddress = IPAddress.Parse("127.0.0.1");
    IPEndPoint iPEndPoint = new IPEndPoint(ipaddress, 10000);
    var socket = new Socket(ipaddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    socket.Connect(iPEndPoint);
    if (socket.Connected)
    {
        string message = "Hello from client\r\nEOF\r\n";
        var data = Encoding.UTF8.GetBytes(message);
        socket.Send(data, SocketFlags.None);
        var buffer = new byte[1024];
        var responce = new StringBuilder();
        int bytes = 0;
        do
        {
            bytes = socket.Receive(buffer, buffer.Length, 0);
            responce.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
        } while (!responce.ToString().EndsWith("By\r\n"));
        Console.WriteLine($"Responce from server: {responce}");
    }

    socket.Close();
});

Console.ReadLine();