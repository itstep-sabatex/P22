using async_await_demo;
using System.Collections.Generic;

async Task<string> GetNameAsync()
{
    await Task.Yield();
    return "Hella";
}
string GetName()
{
    return "Hella";
}

async Task DoExecuteAsync()
{

}

void DoExecute()
{

}


string[] GetTextFromFile(string fileName)
{
    var result = new List<string>();
    result.AddRange(File.ReadAllLines(fileName));
    result.Add("Copyright (c) Roga i Kopita");
    return result.ToArray();
}

//Task<string[]> GetTextFromFileAsync(string fileName)
//{
//    var result = new List<string>();
//    var r =  File.ReadAllLinesAsync(fileName);
//    result.AddRange(r.Result);
//    result.Add("Copyright (c) Roga i Kopita");
//    return Task.FromResult(result.ToArray());
//}
async Task<string[]> GetTextFromFileAsync(string fileName)
{
    var result = new List<string>();
    result.AddRange(await File.ReadAllLinesAsync(fileName));
    result.Add("Copyright (c) Roga i Kopita");
    return result.ToArray();
}
await using (var context = new DataAdapter())
{
    var result = context.GetName();
    result.Wait();
    var r = result.Result;


    var bn = await context.GetBaseNameAsync();

    var ra = await context.GetName();
}

await foreach (var item in new DataAdapter())
{

}
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



