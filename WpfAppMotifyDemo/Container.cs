using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMotifyDemo
{
    public class Container
    {
        public string  ObjectType { get; set; } 
        public string SerializedText { get; set; }

        public void Serialize<TItem>(TItem item) where TItem : class
        {
            ObjectType = typeof(TItem).Name;
            SerializedText = System.Text.Json.JsonSerializer.Serialize(item);
        }



    }

    public class Container<T> where T : class
    {
        public string ObjectType { get; set; }
        public T SerializedText { get; set; }

        public void Serialize<TItem>(TItem item) where TItem : class
        {
            ObjectType = typeof(TItem).Name;
            SerializedText = System.Text.Json.JsonSerializer.Serialize(item);
        }



    }
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public dynamic Cost { get; set; } = new { Max = "Maximum" }; // sinclair ZX-spectrum (16k Rom 16kRam) (16kB,48Kb) Z80,I8080 (адресували 64kB) 256x192

        void Test()
        {
            int a = Cost.Max;
        }
    }

    class School
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
