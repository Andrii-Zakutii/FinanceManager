using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinanceManager.WebApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMoneyAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(
            ITransactionRepository transactionRepository,
            IMoneyAccountRepository accountRepository,
            UserManager<User> userManager)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var transactions = _transactionRepository.GetAll(user);
            return View(transactions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var newAccount = new MoneyAccount { UserId = user.Id };
            return View(newAccount);
        }

        [HttpPost]
        public IActionResult Create(MoneyAccount account)
        {
            if (ModelState.IsValid == false)
                return View();

            CheckUser(account);
            _accountRepository.Add(account);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(long id) => View(_accountRepository.Get(id));

        [HttpPost]
        public IActionResult Update(MoneyAccount account)
        {
            if (ModelState.IsValid == false)
                return View();

            CheckUser(account);
            _accountRepository.Update(account);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(long id) => View(_accountRepository.Get(id));

        [HttpPost]
        public IActionResult Delete(MoneyAccount account)
        {
            CheckUser(account);
            _accountRepository.Delete(account);
            return RedirectToAction(nameof(Index));
        }

        private void CheckUser(MoneyAccount account)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (account.BelongsTo(user) == false)
                throw new Exception("Account doesn't belong to current user");
        }
    }
}
