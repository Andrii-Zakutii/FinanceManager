using FinanceManager.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinanceManager.WebApp.Controllers
{
    [Authorize]
    public class MoneyAccountController : Controller
    {

        public IActionResult Index()
        {
            return View(new List<MoneyAccount>());
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
