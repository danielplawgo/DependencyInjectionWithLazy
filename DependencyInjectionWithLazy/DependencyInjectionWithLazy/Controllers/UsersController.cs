using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DependencyInjectionWithLazy.Logics;
using DependencyInjectionWithLazy.Models;
using DependencyInjectionWithLazy.ViewModels;

namespace DependencyInjectionWithLazy.Controllers
{
    public class UsersController : Controller
    {
        private Lazy<IUserLogic> _userLogic;
        protected IUserLogic UserLogic
        {
            get { return _userLogic.Value; }
        }

        public UsersController(Lazy<IUserLogic> userLogic)
        {
            _userLogic = userLogic;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(viewModel);
            }

            var user = new User()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };

            var result = UserLogic.Add(user);

            if (result.Success)
            {
                return Content("Added");
            }

            result.AddErrorToModelState(ModelState);

            return View(viewModel);
        }
    }
}