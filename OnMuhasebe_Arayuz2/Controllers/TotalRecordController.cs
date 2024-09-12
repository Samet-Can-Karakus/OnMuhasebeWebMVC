using Microsoft.AspNetCore.Mvc;
using OnMuhasebe_Arayuz2.Models;
using OnMuhasebe_Arayuz2.services;

namespace OnMuhasebe_Arayuz2.Controllers
{
	public class TotalRecordController : Controller
	{
		private readonly TotalRecordService _TotalRecordService;

		public TotalRecordController(TotalRecordService TotalRecordService)
		{
			_TotalRecordService = TotalRecordService;
		}
		public async Task<IActionResult> Index()
		{
			var records = await _TotalRecordService.GetTotalRecordsAsync();
			return View(records);
		}
		public IActionResult create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> create(DateTime StartDate, DateTime EndDate)
		{
			var netKazanc = await _TotalRecordService.SaveTotalRecordAsync(StartDate, EndDate);
			ViewBag.TotalRecord = netKazanc;
			return RedirectToAction("Index");
		}
	}
}
