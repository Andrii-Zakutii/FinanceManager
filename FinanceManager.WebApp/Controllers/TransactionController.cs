using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinanceManager.WebApp.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
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

        public IActionResult ListAll() => List(null);

        public IActionResult ListIncomes() => List(TransactionTypes.Income);

        public IActionResult ListExpenses() => List(TransactionTypes.Expense);

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

        private void PrepareData(TransactionTypes type)
        {
            ViewBag.Categories = _categoryRepository.GetAll(GetUser(), type);
            ViewBag.Accounts = _accountRepository.GetAll(GetUser());
        }

        private void CheckUser(Transaction transaction)
        {
            return;
        }

        private IActionResult List(TransactionTypes? type)
        {
            ViewBag.TransactionType = type;
            return View("List", type == null ? GetTransactions() : GetTransactions(type));
        }

        private User GetUser() => _userManager.GetUserAsync(User).Result;

        private IQueryable<Transaction> GetTransactions() => _transactionRepository
            .GetAll(GetUser())
            .Include(t => t.Category)
            .Include(t => t.MoneyAccount);

        private IQueryable<Transaction> GetTransactions(TransactionTypes? type) => GetTransactions()
            .Where(t => t == null ? true : t.Type == type);
    }
}
