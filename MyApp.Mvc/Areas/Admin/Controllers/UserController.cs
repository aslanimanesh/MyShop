﻿using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Domain.Models;
using MyApp.Domain.ViewModels.Users;

namespace MyApp.Mvc.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Public Method

        #region List
        // GET: UserController
        public async Task<ActionResult> Index(FilterUserViewModel filter)
        {
            var result = await _userService.FilterAsync(filter);
            return View(result);
        }
        #endregion

        #region Details
        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDetail = new UserViewModel
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                IsActive = user.IsActive,
            };

            return View(userDetail);
        }
        #endregion

        #region Create
        // GET: UserController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }


            if (await _userService.IsExistUserName(viewModel.UserName.Trim(), null))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده قبلا ثبت نام کرده است");
                return View(viewModel);
            }

            if (await _userService.IsExistEmail(viewModel.Email.Trim().ToLower(), null))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
                return View(viewModel);
            }

            var user = new User
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                IsActive = true,
            };

            await _userService.AddAsync(user);

            return RedirectToAction("Index");
        }

        #endregion

        #region Edit
        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new EditUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                IsActive = user.IsActive,

            };

            return View(viewModel);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (await _userService.IsExistUserName(viewModel.UserName.Trim(), viewModel.Id))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده قبلا ثبت نام کرده است");
                return View(viewModel);
            }

            if (await _userService.IsExistEmail((viewModel.Email).Trim().ToLower(), viewModel.Id))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
                return View(viewModel);
            }

            var user = new User
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                IsActive = viewModel.IsActive,

            };

            await _userService.UpdateAsync(user);
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
    #endregion

        #endregion

}
