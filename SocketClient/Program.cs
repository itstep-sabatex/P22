// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Net;
using System.Text;

var ipaddress = IPAddress.Parse("192.168.1.102");
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

