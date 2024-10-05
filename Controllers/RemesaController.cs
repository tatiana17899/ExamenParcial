using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExamenParcial.Data;
using ExamenParcial.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExamenParcial.Models;
namespace ExamenParcial.Controllers
{
    public class RemesaController : Controller
    {
        private readonly ILogger<RemesaController> _logger;
        private readonly ApplicationDbContext _context;

        public RemesaController(ILogger<RemesaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var remesas= from o in _context.DataRemesa select o;
            var viewModel = new RemesasViewModel
            {
                FormRemesa= new Remesa(),
                ListarRemesas = remesas.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Registrar(RemesasViewModel viewModel)
        {
            viewModel.FormRemesa.FechaTransaccion = viewModel.FormRemesa.FechaTransaccion.ToUniversalTime();
            if (viewModel.FormRemesa.Id == 0)
            {
                _context.Add(viewModel.FormRemesa);
                TempData["Message"] = "Registro exitoso de una nueva Remesa";
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}