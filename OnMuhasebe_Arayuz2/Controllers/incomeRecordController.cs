using Azure;
using Microsoft.AspNetCore.Mvc;
using OnMuhasebe_Arayuz2.Models;
using OnMuhasebe_Arayuz2.services;
using System.Net.Http;
namespace OnMuhasebe_Arayuz2.Controllers;
public class IncomeRecordController : Controller
{
    private readonly IncomeRecordService _incomeRecordService;

    public IncomeRecordController(IncomeRecordService incomeRecordService)
    {
        _incomeRecordService = incomeRecordService;
    }

    public async Task<IActionResult> Index()
    {
        var records = await _incomeRecordService.GetIncomeRecordsAsync();
        return View(records);
    }

    public IActionResult create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> create(IncomeRecord record)
    {
        if (ModelState.IsValid)
        {
            await _incomeRecordService.SaveIncomeRecordAsync(record);
            return RedirectToAction("Index");
        }
        return View(record);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var record = await _incomeRecordService.GetIncomeRecordByIdAsync(id);
        return View(record);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(IncomeRecord record)
    {
        if (ModelState.IsValid)
        {
            await _incomeRecordService.UpdateIncomeRecordAsync(record);
            return RedirectToAction("Index");
        }
        return View(record);
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _incomeRecordService.DeleteIncomeRecordAsync(id);
        return RedirectToAction("Index");
    }

    /*[HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _incomeRecordService.DeleteIncomeRecordAsync(id);
        return RedirectToAction("Index");
    }*/

}
