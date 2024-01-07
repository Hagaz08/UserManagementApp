using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Models.Entities;
using UserManagementApp.Models.ViewModels;
using UserManagementApp.Services.Interfaces;

namespace UserManagementApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IEmailService _emailservice;
		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailservice)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_emailservice = emailservice;
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(UserToRegisterViewModel model)
		{
			if(ModelState.IsValid)
			{
				var user = new AppUser
				{
					FirstName = model.Firstname,
					LastName = model.Lastname,
					Email = model.Email,
					PhoneNumber = model.PhoneNumber,
					UserName = model.Email
				};
				var createUserResult= await _userManager.CreateAsync(user,model.Password);
				if (createUserResult.Succeeded)
				{
					var addRoleResult = await _userManager.AddToRoleAsync(user, "regular");
					if (addRoleResult.Succeeded)
					{
						var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
						var link = Url.Action("ConfirmEmail", "Account", new { user.Email, token },Request.Scheme);
						var body = @$"Hi {user.FirstName},                  
Please click the link <a href='{link}'> here </a> to confirm your account's email";

						await _emailservice.SendEmailAsync(user.Email, body, "Confirm Email");
						return RedirectToAction("RegisterCongrats","Account", new {name=model.Firstname});  
					}
					foreach (var err in addRoleResult.Errors)
					{
						ModelState.AddModelError(err.Code, err.Description);
					}
				}
				foreach(var err in createUserResult.Errors)
				{
					ModelState.AddModelError(err.Code, err.Description);
				}
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult RegisterCongrats(string name)
		{
			ViewBag.Name = name;
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> ConfirmEmail(string Email, string token)
		{
			var user = await _userManager.FindByEmailAsync(Email);

			if (user != null) 
			{
				var confirmEmailResult = await _userManager.ConfirmEmailAsync(user, token);
				if (confirmEmailResult.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}
				foreach( var err in confirmEmailResult.Errors)
				{
					ModelState.AddModelError(err.Code, err.Description);
				}
				return View(ModelState);
			}
			ModelState.AddModelError("", "Email Confirmation failed");
			return View(ModelState);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
	}
}
