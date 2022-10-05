using Application.Interfaces.Services;
using Domain.Dtos;
using Domain.Entites;
using Domain.Enum;
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

        public async Task<IActionResult> Index()
        {
            var res = await _invoiceService.GetInvoice();
            InvoiceDto invoiceDto = res.Data;
            if (invoiceDto is not null)
            {
                ViewBag.Total = invoiceDto.ItemDtos.Sum(a => a.Price * a.Qty);
                return View(res.Data);
            }
            return View(new InvoiceDto
            {

                InvoiceDate = DateTime.Now,
                ItemDtos = new List<ItemDto>(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceDto invoiceDto)
        {
            var x = invoiceDto.ItemDtos.Sum(a => a.Price * a.Qty);
            if (x > 10000 && invoiceDto.PaymentMethod == PaymentMethods.Credit.ToString())
                return View("privacy", "total exceed 10,000 EGP");
            var res = await _invoiceService.AddNewInovice(invoiceDto);

            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult NewInvoice(int invoiceId)
        {
            var invoice = new InvoiceDto
            {
                Id = invoiceId + 1,
                InvoiceDate = DateTime.Now,
                ItemDtos = new List<ItemDto>(),
            };
            return View("Index", invoice);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteInvoice(int invoiceId)
        {
            var res = await _invoiceService.DeleteInvoice(invoiceId);

            return RedirectToAction("index");
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