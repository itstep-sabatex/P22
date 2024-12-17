// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

await  Task.Run(() => Console.WriteLine("RunTask"));
var task2 = new Task(() => Console.WriteLine("RunTask 2"));
task2.Start();
//ask1.Wait();
task2.Wait();



void CallBackFunction(object state)
{
    Console.WriteLine("CallBackFunction  executed");

}

void ImitationAsync(Action<object> callback)
{
    Thread.Sleep(1000);
    callback("Imitation end");
}

await Task.Run(()=>ImitationAsync(CallBackFunction)); //read disk

var a= Console.ReadLine();
Console.WriteLine(a);


//Thread.Sleep(1000);

//  -> Відправляємо контролеру запит на сектор (Трек,номер сектора)
//  <- підтвердження від контролера про розуміння операції
//  ********
// loop (pause(),   check controller state) // nop

//  -> Відправляємо контролеру запит на сектор (Трек,номер сектора,номер прериваня (call back))
//  <- підтвердження від контролера про розуміння операції
//  процесор продовжує виконувати програму
//  .......
// преривання (виконуэться зчитування з контролера даних)
// 


var ma = MatrixLib.Matrix.CreateMatrix(1000);
var mc = MatrixLib.Matrix.CreateMatrix(1000);
var tasks = new Task<double>[1000,1000];

for (int i = 0; i < 1000; i++)
{
    for (int j = 0; j < 1000; j++)
    {
        var pi = i;
        var pj = j;
        tasks[i, j] = Task.Run(()=>MatrixLib.Matrix.MultiplreOneElement(1000, pi, pj, ma, mc));
        tasks[i, j] = MatrixLib.Matrix.MultiplreOneElementTask(1000, pi, pj, ma, mc);
    }
}
var result = new double[1000, 1000];

for (int i = 0; i < 1000; i++)
{
    for (int j = 0; j < 1000; j++)
    {
        tasks[i,j].Wait();
        result[i, j] = tasks[i, j].Result;
    }
}
static void ReadCallback(IAsyncResult asyncResult)
{ 
    dynamic state = asyncResult.AsyncState;
    FileStream fileStream = state.FileStream;
    byte[] buffer = state.Buffer;
    int bytesRead = fileStream.EndRead(asyncResult);
    string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    Console.WriteLine("File content:");
    Console.WriteLine(content); fileStream.Close();
}

string filePath = "example.txt";
FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
byte[] buffer = new byte[fileStream.Length];
AsyncCallback callback = new AsyncCallback(ReadCallback);
fileStream.BeginRead(buffer, 0, buffer.Length, callback, new { FileStream = fileStream, Buffer = buffer });
Console.ReadLine();
