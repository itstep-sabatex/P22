// See https://aka.ms/new-console-template for more information
if (args.Length > 0)
{
    Console.WriteLine($"Mutex demo {args[0]}");
}else
{ 
    Console.WriteLine("Mutex demo no args");
}
var m = new Mutex(false);
Mutex mutex = new Mutex(false, "54A8B9A3-9C9A-4183-9800-A3B90015F94C", out bool isNew);
for (int i = 0; i < 100; i++)
{
    if (mutex.WaitOne(TimeSpan.FromSeconds(10)))
    {
        Console.WriteLine($"Counter {i} time {DateTime.Now}");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        mutex.ReleaseMutex();
    }
    else {
        Console.WriteLine("Error enter mutex");
    
    }
}

// одночасно 3 програми з таймером 1сек
//  arg[0] - current time
// запис у спільний файл c:/temp/mutex.log