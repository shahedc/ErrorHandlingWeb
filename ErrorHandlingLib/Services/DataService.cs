using ErrorHandlingLib.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandlingLib.Services
{
    public class DataService : IDataService
    {
        private IHostingEnvironment _env;

        public DataService(IHostingEnvironment env)
        {
            _env = env;
        }
        public Task<DataItem[]> GetDataAsync()
        {
            // hard-code some data
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

            // get data from file if possible
            try
            {   // Open the text file using a stream reader.
                var webRoot = _env.WebRootPath;
                var file = System.IO.Path.Combine(webRoot, @"data\datafile.txt");

                using (StreamReader sr = new StreamReader(file))
                {
                    // Read the stream to a string, overwrite some data
                    data2.SomeData = sr.ReadToEnd();
                }
            }
            catch (IOException ioException)
            {
                data2.SomeData = $"IO Error: {ioException.Message}";
            }
            catch (Exception exception)
            {
                data2.SomeData = $"Generic Error: {exception.Message}";
            }


            return Task.FromResult(new[] { data1, data2 });
        }
    }
}
