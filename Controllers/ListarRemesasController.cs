using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExamenParcial.Data;
using ExamenParcial.Models;
using ExamenParcial.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamenParcial.Controllers
{

    public class ListarRemesasController : Controller
    {
        private readonly ILogger<ListarRemesasController> _logger;
        private readonly ApplicationDbContext _context;

        public ListarRemesasController(ILogger<ListarRemesasController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var remesas = _context.DataRemesa.ToList();
            var viewModel = new RemesasViewModel
            {
                ListarRemesas = remesas 
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}