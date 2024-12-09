

void ThreadDemo()
{
    Console.WriteLine("Thread start");
    Thread.Sleep(5000);
}


void ThreadDemo1(object a)
{
    Console.WriteLine($"Thread start - {a}");
    Thread.Sleep(5000);
}

var thread = new Thread(ThreadDemo1);
//thread.IsBackground = true;
thread.Start("1");
thread = new Thread(ThreadDemo1);
//thread.IsBackground = true;
thread.Start("2");
thread = new Thread(ThreadDemo1);
//thread.IsBackground = true;
thread.Start("3");
//thread.IsBackground = true;
//thread.Suspend();
for (int i = 0; i < 10; i++)
{
    var v = i;


}

//thread.Join();
//thread.Resume();
Console.WriteLine("Hello, World!");


