// See https://aka.ms/new-console-template for more information

namespace MonitorDemo;
static class Programm
{
    volatile static int counter = 1;
    static object locker = new object();
    static void IncrementCounter(int value)
    {
        var a = value + 12;
        var s = "gggg";   
        lock (locker)
        {
            counter++;                // inc, add reg,reg,   mov,add,mov
            counter = counter + a;
            IncrementCounterB(value);
            // get from method b
        }
        
        // взяти з озу counter
        // взяти з озу value

        // додати до counter value
        // зберигти в ОЗУ counter

    }
    static void IncrementCounterB(int value)
    {
        var a = value + 12;
        var s = "gggg";

        Monitor.Enter(locker);

        var en =Monitor.TryEnter(locker,6000);
        if (en)
        {
            #region Wait
            Monitor.Wait(locker, 5000); // sleep thread 5000


            Monitor.Pulse(locker);      // wake up
            Monitor.PulseAll(locker);   // wake upp all
            #endregion
            counter = counter + a;
            IncrementCounter(value);
            while (true) { }Monitor.Exit(locker);
        }
        else
        {
            throw new Exception("Error execute critical section");
        }

        Mutex mutex = new Mutex(false, "54A8B9A3-9C9A-4183-9800-A3B90015F94C    mutex", out bool isNew);

        mutex.WaitOne();

        mutex.ReleaseMutex();


        // взяти з озу counter
        // взяти з озу value

        // додати до counter value
        // зберигти в ОЗУ counter

    }


    public static void Main(string[] args)
    {
        Task.Run(() => {
            IncrementCounter(5);
        });
        Task.Run(() => {
            IncrementCounter(5);
        });

        IncrementCounter(5);

        Console.WriteLine("Hello, World!");

    }

    




 
}