using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async_await_demo
{
    internal class DataAdapter : DataAdapterBase,IDataAdapter
    {
        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerator<string> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


        //public async Task<string> GetBaseNameAsync()
        //{
        //    await Task.Yield();
        //    return "Hello";
        //}
        public Task<string> GetBaseNameAsync()
        {

            return  Task.FromResult("Hello");
        }



        public override Task<string> GetName()
        {
            throw new NotImplementedException();
        }

 
    }
}
