// See https://aka.ms/new-console-template for more information
using System.Threading;

Console.WriteLine("Hello, World!");
Semaphore semaphore = new Semaphore(2, 2, "9F633EE0-BD71-4F4C-A9DB-FFD865FC2D64", out bool isNew);

try
{
    for (int i = 0; i < 100; i++)
    {
        if (semaphore.WaitOne(TimeSpan.FromSeconds(10)))
        {
            Console.WriteLine($"Counter {i}");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            semaphore.Release();

        }
        else
        {
            Console.WriteLine("Error, not enter thread {i}");
        }
    }
}
finally
{
    semaphore.Close();
}