using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async_await_demo
{
    public abstract class DataAdapterBase
    {
        public abstract Task<string> GetName();

    }
}
