// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");



// 127.0.0.1  - DNS localhost
// 127.0.0.1..254 - using adrresses
// 127.0.0.0 - reserved
// 127.0.0.255 - reserved for broadcast
// mask 255.255.255.0 192.168.1.0  local network (192.168.1.1 - 192.168.1.255)   192.168.0.1 -> next network -> next network 12.34.56.67
// 255.255.255.255 - broadcast FF.FF.FF.FF
IPAddress iPAddress = IPAddress.Parse("192.168.1.1");
iPAddress = new IPAddress(new byte[] { 192, 168, 1, 1 }); // 32 bit

var google = Dns.GetHostEntry("www.google.com");

IPAddress googleIP = google.AddressList[0];

IPEndPoint iPEndPoint = new IPEndPoint(googleIP, 80); // ip + port

var socket = new Socket(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
socket.Connect(iPEndPoint);
var page= new StringBuilder();
if (socket.Connected)
{
    string getRequest = "GET / HTTP/1.1\r\nHost: www.google.com\r\nConnection: close\r\n\r\n";
    var data = Encoding.UTF8.GetBytes(getRequest);
    var buffer = new byte[1024];
    socket.Send(data, SocketFlags.None);
    int bytes = 0;
    do
    {
        bytes = socket.Receive(buffer, buffer.Length,0);
        page.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
    } while (bytes > 0);
    
    Console.WriteLine(page);
}

// <div> порахувати кількість слів </div> на www.google.com та www.microsoft.com