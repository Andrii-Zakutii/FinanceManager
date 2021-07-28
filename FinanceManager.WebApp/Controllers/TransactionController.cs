using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.Core.Services;
using FinanceManager.WebApp.Extensions;
using FinanceManager.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinanceManager.WebApp.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private const string commonKey = "1";
        private const string expenseKey = "2";
        private const string incomeKey = "3";

        private readonly UserManager<User> _userManager;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMoneyAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(
            ITransactionRepository transactionRepository,
            ICategoryRepository categoryRepository,
            IMoneyAccountRepository accountRepository,
            UserManager<User> userManager)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _userManager = userManager;
            _categoryRepository = categoryRepository;
        }

        public IActionResult ListAll() => List(type: null);

        public IActionResult ListIncomes() => List(TransactionTypes.Income);

        public IActionResult ListExpenses() => List(TransactionTypes.Expense);

        [HttpPost]
        public IActionResult List(TransactionsFilter filter)
        {
            SetFilter(filter);
            return List(filter.Type);
        }

        public IActionResult Create(TransactionTypes type)
        {
            PrepareData(type);
            Transaction transaction = new Transaction { Type = type };
            return View(transaction);
        }

        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid == false)
            {
                PrepareData(transaction.Type ?? default);
                return View(transaction);
            }

            CheckUser(transaction);
            _transactionRepository.Add(transaction);
            return RedirectToAction(transaction.Type == TransactionTypes.Expense ?
                nameof(ListExpenses) : nameof(ListIncomes));
        }

        public IActionResult Edit(long id)
        {
            Transaction transaction = _transactionRepository.Get(id);
            PrepareData(transaction?.Type ?? default);
            return View(transaction);
        }

        [HttpPost]
        public IActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid == false)
            {
                PrepareData(transaction.Type ?? default);
                return View(transaction);
            }

            CheckUser(transaction);
            _transactionRepository.Update(transaction);
            return RedirectToAction(transaction.Type == TransactionTypes.Expense ?
                nameof(ListExpenses) : nameof(ListIncomes));
        }

        public IActionResult Delete(long id)
        {
            var transaction = _transactionRepository.Get(id);
            CheckUser(transaction);
            return View(transaction);
        }

        [HttpPost]
        public IActionResult Delete(Transaction transaction)
        {
            CheckUser(transaction);
            _transactionRepository.Delete(transaction);
            return RedirectToAction(transaction.Type == TransactionTypes.Expense ?
                nameof(ListExpenses) : nameof(ListIncomes));
        }

        public IActionResult Details(long id)
        {
            var transaction = _transactionRepository.Get(id);
            CheckUser(transaction);
            return View(transaction);
        }

        private IActionResult List(TransactionTypes? type)
        {
            var filter = GetFilter(type);
            ViewBag.Filter = filter;
            PrepareData(filter.Type ?? default);
            var transactions = GetTransactions(type);
            var statistics = new TransactionsStatistics(transactions);
            ViewBag.Statistics = statistics;
            return View("List", transactions);
        }

        private void PrepareData(TransactionTypes type)
        {
            ViewBag.Categories = _categoryRepository.GetAll(GetUser(), type);
            ViewBag.Accounts = _accountRepository.GetAll(GetUser());
        }

        private void CheckUser(Transaction transaction)
        {
            return;
        }

        private User GetUser() => _userManager.GetUserAsync(User).Result;

        private IEnumerable<Transaction> GetTransactions(TransactionTypes? type) => GetQuery(type).ToArray();

        private IQueryable<Transaction> GetQuery(TransactionTypes? type) => _transactionRepository
            .GetAll(GetUser())
            .Include(t => t.Category)
            .Include(t => t.MoneyAccount)
            .Apply(GetFilter(type));

        private TransactionsFilter GetFilter(TransactionTypes? type) =>
            HttpContext.Session.GetJson<TransactionsFilter>(GetKey(type)) ?? new() { Type = type };

        private void SetFilter(TransactionsFilter filter) =>
            HttpContext.Session.SetJson(GetKey(filter.Type), filter);

        private string GetKey(TransactionTypes? type)
        {
            string key;

            if (type == null)
                key = commonKey;
            else if (type == TransactionTypes.Expense)
                key = expenseKey;
            else
                key = incomeKey;

            return key;
        }

    }
}
