using FinanceManager.Core.Entities;
using FinanceManager.Core.Entities.Base;
using FinanceManager.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinanceManager.WebApp.Controllers.Base
{
    [Authorize]
    public abstract class StandardController<T> : Controller where T : PersonalEntity, new()
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository<T> _repository;

        public StandardController(IRepository<T> repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult List() => View(_repository.GetAll(GetUser()));

        public IActionResult Create() => View(new T { UserId = GetUser().Id });

        [HttpPost]
        public IActionResult Create(T entity) => Modify(entity, _repository.Add, nameof(Create));

        public IActionResult Edit(long id) => Show(id, nameof(Edit));

        [HttpPost]
        public IActionResult Edit(T entity) => Modify(entity, _repository.Update, nameof(Edit));

        public IActionResult Delete(long id) => Show(id, nameof(Delete));

        [HttpPost]
        public IActionResult Delete(T entity) => Modify(entity, _repository.Delete, nameof(Delete));

        public IActionResult Details(long id) => Show(id, nameof(Details));

        private IActionResult Show(long id, string viewName)
        {
            T entity = _repository.Get(id);

            if (ValidateEntity(entity) == false)
                throw new Exception("Validation failed");

            return View(viewName, entity);
        }

        private IActionResult Modify(T entity, Action<T> action, string viewName)
        {
            if (action != _repository.Delete && ModelState.IsValid == false)
                return View(viewName, entity);

            if (ValidateEntity(entity) == false)
                throw new Exception("Validation failed");

            action(entity);
            return RedirectToAction(nameof(List));
        }

        protected abstract bool ValidateEntity(T entity);

        protected User GetUser() => _userManager.GetUserAsync(User).Result;
    }
}
