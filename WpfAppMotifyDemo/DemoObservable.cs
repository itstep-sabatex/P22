using Sabatex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMotifyDemo
{
    public class DemoObservable: ObservableObject
    {
        string _name;
        public string Name { get=>_name; set=>SetProperty(ref _name,value); }

    }
}
