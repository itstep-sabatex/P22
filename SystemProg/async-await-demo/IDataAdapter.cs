using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async_await_demo
{
    public interface IDataAdapter:IAsyncDisposable,IAsyncEnumerable<string>
    {
        Task<string> GetBaseNameAsync();
    }
}
