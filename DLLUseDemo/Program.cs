// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)] //1.0,1.1,1.2
static extern void MessageBox(IntPtr hWhd, string tesxt, string caption, uint uType = 0x02);
IntPtr ptr = Process.GetCurrentProcess().MainWindowHandle;

MessageBox(ptr, "Hello world", "Test");

Console.WriteLine("Hello, World!");