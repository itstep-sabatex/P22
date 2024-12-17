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


        
            var en =Monitor.TryEnter(locker,6000);

        #region Wait
            Monitor.Wait(locker, 5000); // sleep thread 5000
            Monitor.Pulse(locker);      // wake up
            Monitor.PulseAll(locker);   // wake upp all
        #endregion
            counter = counter + a;
            IncrementCounter(value);
            while (true) { }

            Monitor.Exit(locker);
  

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