using KaracadanWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KaracadanWebApp.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext _context, RoleManager<IdentityRole> roleManager ) : base(userManager, signInManager, _context, roleManager)
        {
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(userLoginModel.Email);

                if (user != null)
                {

                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, userLoginModel.Password, userLoginModel.RememberMe, false);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Şifreniz Hatalı");
                        ViewBag.Message = "Şifreniz Hatalı";
                        return View(userLoginModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bu email adresine kayıtlı kullanıcı bulunamamıştır.");
                    ViewBag.Message = "Bu email adresine kayıtlı kullanıcı bulunamamıştır.";
                }
            }

            return View(userLoginModel);
        }


        public IActionResult SignUp()
        {
            return View();
        }


        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterModel userRegisterModel)
        {
            if (ModelState.IsValid)
            {
                if (userManager.Users.Any(u => u.Email == userRegisterModel.Email))
                {
                    ModelState.AddModelError("", "Bu email adresi kayıtlıdır.");
                    ViewBag.Message = "Bu email adresi kayıtlıdır.";
                    return View(userRegisterModel);
                }

                if (userManager.Users.Any(u => u.PhoneNumber == userRegisterModel.PhoneNumber))
                {
                    ModelState.AddModelError("", "Bu telefon numarası kayıtlıdır.");
                    ViewBag.Message = "Bu telefon numarası kayıtlıdır.";
                    return View(userRegisterModel);
                }

                ApplicationUser user = new ApplicationUser();
                user.UserName = userRegisterModel.UserName;
                user.Email = userRegisterModel.Email;
                user.PhoneNumber = userRegisterModel.PhoneNumber;
                user.FirstName = userRegisterModel.FirstName;
                user.LastName = userRegisterModel.LastName;

                IdentityResult result = await userManager.CreateAsync(user, userRegisterModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Kayıt Sırasında Hata ile Karşılaşıldı";
                    AddModelError(result);
                }
            }

            return View(userRegisterModel);
        }


        public ActionResult ForgetPassword()
        {
            ViewBag.Success = false;
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(UserLoginModel userLoginModel)
        {
            //Add reset password logic here
            throw new NotImplementedException();
        }
    }
}
