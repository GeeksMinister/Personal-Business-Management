using Microsoft.AspNetCore.Mvc;
using PersonalBusinessManagement.Data.ExchangeRates;
using PersonalBusinessManagement.Data.GithubRepos;

namespace PersonalBusinessManagement.Controllers
{
    public class ApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View((await CurrencyFileHandler.GetExchangeRates(),
                         await GithubRepoHandler.GetRepos()));
        }

        public async Task<IActionResult> UpdateExchangeRate()
        {
            await CurrencyFileHandler.UpdateExchangeRates();
            return RedirectToAction(nameof(Index));
        }
    }
}
