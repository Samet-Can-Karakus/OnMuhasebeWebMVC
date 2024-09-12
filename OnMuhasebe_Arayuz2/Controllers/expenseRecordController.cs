using Microsoft.AspNetCore.Mvc;
using OnMuhasebe_Arayuz2.Models;
using OnMuhasebe_Arayuz2.services;

namespace OnMuhasebe_Arayuz2.Controllers
{
    public class ExpenseRecordController : Controller
    {
        private readonly ExpenseRecordService _ExpenseRecordService;

        public ExpenseRecordController(ExpenseRecordService ExpenseRecordService)
        {
            _ExpenseRecordService = ExpenseRecordService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _ExpenseRecordService.GetExpenseRecordsAsync();
            return View(records);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(ExpenseRecord record)
        {
            if (ModelState.IsValid)
            {
                await _ExpenseRecordService.SaveExpenseRecordAsync(record);
                return RedirectToAction("Index");
            }
            return View(record);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var record = await _ExpenseRecordService.GetExpenseRecordByIdAsync(id);
            return View(record);
        }

        /*public async Task<IActionResult> Edit(int id)
        {
          var record = await _incomeRecordService.UpdateIncomeRecordAsync(id);
          return View(record);
        }*/

        [HttpPost]
        public async Task<IActionResult> Edit(ExpenseRecord record)
        {
            if (ModelState.IsValid)
            {
                await _ExpenseRecordService.UpdateExpenseRecordAsync(record);
                return RedirectToAction("Index");
            }
            return View(record);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _ExpenseRecordService.DeleteExpenseRecordAsync(id);
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ExpenseRecordService.DeleteExpenseRecordAsync(id);
            return RedirectToAction("Index");
        }
    }
}
