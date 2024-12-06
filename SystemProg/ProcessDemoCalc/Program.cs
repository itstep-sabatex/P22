Console.WriteLine("Demo calculator programm");
int result  = 0;
foreach (var arg  in args)
{
    result = result + int.Parse(arg.ToString());
    Console.WriteLine($" Add value {arg} ");
}
Console.WriteLine($" Result = {result} ");
File.WriteAllText("result.txt", result.ToString());
Thread.Sleep(3000);

return result;