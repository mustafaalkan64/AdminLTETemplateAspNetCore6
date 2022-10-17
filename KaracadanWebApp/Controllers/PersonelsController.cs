using KaracadanWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KaracadanWebApp.Controllers
{
    [Authorize]
    public class PersonelsController : BaseController
    {
        public PersonelsController(UserManager<ApplicationUser> userManager, ApplicationDbContext _context, RoleManager<IdentityRole> roleManager) : base(userManager, null, _context, roleManager)
        {
        }

        public async Task<IActionResult> Index()
        {
            var allPersonels = await _context.Personels.ToListAsync();
            return View(allPersonels);
        }


        public IActionResult Create()
        {
            var person = new Personels();
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Personels personel)
        {
            await _context.Personels.AddAsync(personel);
            await _context.SaveChangesAsync();
            return View("Index");
        }
    }
}
