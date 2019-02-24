using ErrorHandlingLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandlingLib.Services
{
    public interface IDataService
    {
        Task<DataItem[]> GetDataAsync();
    }
}
