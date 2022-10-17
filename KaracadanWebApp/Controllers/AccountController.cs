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
                    //if (await userManager.IsLockedOutAsync(user))
                    //{
                    //    ModelState.AddModelError("", "Hesabınız bir süreliğine kilitlenmiştir. Lütfen daha sonra tekrar deneyiniz.");

                    //    return View(userLoginModel);
                    //}

                    //if (userManager.IsEmailConfirmedAsync(user).Result == false)
                    //{
                    //    ModelState.AddModelError("", "Email adresiniz onaylanmamıştır. Lütfen  epostanızı kontrol ediniz.");
                    //    return View(userLoginModel);
                    //}

                    //await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, userLoginModel.Password, userLoginModel.RememberMe, false);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bu email adresine kayıtlı kullanıcı bulunamamıştır.");
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
        public async Task<IActionResult> SignUp(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (userManager.Users.Any(u => u.Email == userViewModel.Email))
                {
                    ModelState.AddModelError("", "Bu email adresi kayıtlıdır.");
                    return View(userViewModel);
                }

                if (userManager.Users.Any(u => u.PhoneNumber == userViewModel.PhoneNumber))
                {
                    ModelState.AddModelError("", "Bu telefon numarası kayıtlıdır.");
                    return View(userViewModel);
                }

                ApplicationUser user = new ApplicationUser();
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
                user.FirstName = userViewModel.FirstName;
                user.LastName = userViewModel.LastName;

                IdentityResult result = await userManager.CreateAsync(user, userViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddModelError(result);
                }
            }

            return View(userViewModel);
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
