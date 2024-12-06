// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var count = args.Count();
void RunNotepad()
{
    var proc = new Process();
    proc.StartInfo.FileName = "notepad.exe";
    proc.Start();

    Thread.Sleep(1000);

    proc.Kill();
}
void RunCalc()
{
    var proc = new Process();
    proc.StartInfo.FileName = @"C:\Users\serhi\.repos\sabatex-itstep\P22\SystemProg\ProcessDemoCalc\bin\Debug\net9.0\ProcessDemoCalc.exe";
    proc.StartInfo.Arguments = "10 20 30";
    proc.StartInfo.WorkingDirectory = @"C:\Users\serhi\.repos\sabatex-itstep\P22\SystemProg\ProcessDemoCalc\bin\Debug\net9.0\";
    proc.StartInfo.CreateNoWindow = true;
    proc.StartInfo.RedirectStandardOutput = true;
    proc.StartInfo.RedirectStandardError = true;
    proc.OutputDataReceived += (a, b) => Console.WriteLine(b.Data);
    proc.ErrorDataReceived += (a, b) => Console.WriteLine(b.Data);
    proc.Start();
    proc.BeginOutputReadLine();
    proc.BeginErrorReadLine();
    proc.WaitForExit();
    Console.WriteLine(proc.ExitCode);
    Thread.Sleep(3000);
}

bool ArchiveFolder(string folder,string resultFile)
{
    string script = $"tar -cvjf {resultFile} {folder}";
    var proc = new Process();
    proc.StartInfo.FileName = "cmd.exe";
    proc.StartInfo.Arguments = $"/C {script}";
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.RedirectStandardOutput = true;
    proc.StartInfo.RedirectStandardError = true;
    proc.OutputDataReceived += (a, b) => Console.WriteLine(b.Data);
    proc.ErrorDataReceived += (a, b) => Console.WriteLine(b.Data);
    proc.StartInfo.CreateNoWindow = true;
    proc.Start();
    proc.BeginOutputReadLine();
    proc.BeginErrorReadLine();
    proc.WaitForExit();
    return proc.ExitCode == 0 || proc.ExitCode == 1000;
}


ArchiveFolder(@"C:\temp\ProcessDemo", "processDemo.tar.bz2");