using Application.Interfaces.Services;
using Domain.Dtos;
using InvoiceUi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvoiceUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInvoiceService _invoiceService;

        public HomeController(ILogger<HomeController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        public IActionResult Index()
        {
            InvoiceDto invoiceDto = new()
            {
                ItemDtos = new List<ItemDto>()
            };
            return View(invoiceDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceDto invoiceDto)
        {
            var res = await _invoiceService.AddNewInovice(invoiceDto);

            return View(res);
        }
        #region Unused


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}