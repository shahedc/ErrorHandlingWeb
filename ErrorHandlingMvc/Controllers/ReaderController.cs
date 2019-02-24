using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErrorHandlingMvc.Models;
using ErrorHandlingLib.Services;
using ErrorHandlingLib.Models;

namespace ErrorHandlingMvc.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IDataService _dataService;

        public ReaderController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IActionResult> Index()
        {
            var dataItems = await _dataService.GetDataAsync();
            var model = new DataItemModel()
            {
                DataItems = dataItems
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
