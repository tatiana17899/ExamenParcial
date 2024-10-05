using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExamenParcial.Data;
using ExamenParcial.Models;
using ExamenParcial.Services;
using ExamenParcial.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamenParcial.Controllers
{
    public class ConversionesController : Controller
    {
        private readonly ILogger<ConversionesController> _logger;
        private readonly CoinMarketCapService _coinMarketCapService;
        private readonly ApplicationDbContext _context;

        public ConversionesController(ILogger<ConversionesController> logger, CoinMarketCapService coinMarketCapService, ApplicationDbContext context)
        {
            _logger = logger;
            _coinMarketCapService = coinMarketCapService; 
            _context = context;
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
            var conversion = new Conversiones
            {
                MonedaOrigen = currency,
                MonedaDestino = currency == "USD" ? "BTC" : "USD",
                TasaCambio = result,
                Fecha = DateTime.UtcNow
            };
            _context.DataConversion.Add(conversion);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { result });
        }
        public IActionResult ListConversions()
        {
            var conversions = _context.DataConversion.ToList();
            if (conversions == null)
            {
                conversions = new List<Conversiones>();
            }
            var viewModel = new ConversionesViewModel { ListarRemesas = conversions };
            return View(viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}