using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExamenParcial.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamenParcial.Controllers
{
    public class ConversionesController : Controller
    {
        private readonly ILogger<ConversionesController> _logger;
        private readonly CoinMarketCapService _coinMarketCapService;


        public ConversionesController(ILogger<ConversionesController> logger, CoinMarketCapService coinMarketCapService)
        {
            _logger = logger;
            _coinMarketCapService = coinMarketCapService; 
        }


        public IActionResult Index(decimal? result = null)
        {
            ViewBag.Result = result;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Convert(string currency, decimal amount)
        {
            decimal result;

            if (currency == "USD")
            {
                result = await _coinMarketCapService.ConvertUsdToBtcAsync(amount);
            }
            else
            {
                result = await _coinMarketCapService.ConvertBtcToUsdAsync(amount);
            }

            return RedirectToAction("Index", new { result });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}