using System.Collections;

namespace system_prog
{
    internal class Program
    {
        


        static int CalcAdd(int a,int b)
        {
            int c = 10;
            Demo demo = new Demo();
            DemoClass dc = new DemoClass();
            return a + b;
        }
        static void Main(string[] args)
        {
            // SP = 1000
            // 1- push a  SP=992   pointer a = 992
            // 2- push b  SP=984   pointer b = 984
            // SP = SP - 8; Demo SP= 976   pointer demo = 976
            // SP = SP - 8; SP=968  Pointer to HEAP DemoClass// SP = SP - 8; 
            // 2- call CalcAdd (push address Console.WriteLine($"Summ {summ}");) // I8080  8-bit , I80286 - 16bit,  I80386,I80486, Pentium, - 32bit, x86
            // 64 bit (24bytes)  SP=960  0005
            var summ = CalcAdd(1, 2); //0000
            // SP = SP +16 (24)       //0005 
            Console.WriteLine($"Summ {summ}");
        }
    }

    struct Demo
    {
        public int a;
        public int b;
    }

    class DemoClass
    {
        public int a;
        public int b;
    }

}
