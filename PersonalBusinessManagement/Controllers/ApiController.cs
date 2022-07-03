using Microsoft.AspNetCore.Mvc;
using PersonalBusinessManagement.Data.ExchangeRates;
using PersonalBusinessManagement.Data.GithubRepos;

namespace PersonalBusinessManagement.Controllers;

public class ApiController : Controller
{
    public async Task<IActionResult> Index()
    {
        var exchangeRates = await CurrencyFileHandler.GetExchangeRates();
        var githubRepo = await GithubRepoHandler.GetRepos();
        return View((exchangeRates, githubRepo));
    }

    public async Task<IActionResult> UpdateExchangeRate()
    {
        await CurrencyFileHandler.UpdateExchangeRates();
        return RedirectToAction(nameof(Index));
    }
}

