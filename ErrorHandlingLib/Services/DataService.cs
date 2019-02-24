using ErrorHandlingLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandlingLib.Services
{
    public class DataService : IDataService
    {
        public Task<DataItem[]> GetDataAsync()
        {
            var data1 = new DataItem
            {
                Id = 1,
                SomeData = "data 1"
            };

            var data2 = new DataItem
            {
                Id = 2,
                SomeData = "data 2"
            };

            return Task.FromResult(new[] { data1, data2 });
        }
    }
}
