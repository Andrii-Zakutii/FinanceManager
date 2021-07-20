using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.WebApp.Controllers
{
    [Authorize]
    public class MoneyAccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMoneyAccountRepository _accountRepository;

        public MoneyAccountController(
            IMoneyAccountRepository accountRepository,
            UserManager<User> userManager)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var accounts = _accountRepository.GetAll(user);
            return View(accounts);
        }

        public IActionResult Create()
        {
            var user = _userManager.GetUserAsync(User).Result;
            return View(new MoneyAccount { UserId = user.Id });
        }

        [HttpPost]
        public IActionResult Create(MoneyAccount account)
        {
            if (ModelState.IsValid == false)
                return View();

            // TODO: Check user
            _accountRepository.Add(account);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(long id) => 
            View(_accountRepository.Get(id));

        [HttpPost]
        public IActionResult Update(MoneyAccount account)
        {
            if (ModelState.IsValid == false)
                return View();

            // TODO: Check user
            _accountRepository.Update(account);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long id)
        {
            return View(_accountRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(MoneyAccount account)
        {
            // TODO: Check user
            _accountRepository.Delete(account);
            return RedirectToAction(nameof(Index));
        }
    }
}
