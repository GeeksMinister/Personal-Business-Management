using Microsoft.AspNetCore.Mvc;
using PersonalBusinessManagement.Data.ExchangeRates;

namespace PersonalBusinessManagement.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View(CurrencyFileHandler.GetExchangeRates());
        }

        public async Task<IActionResult> UpdateExchangeRate()
        {
            await CurrencyFileHandler.UpdateExchangeRates();
            return RedirectToAction(nameof(Index));
        }
    }
}
