using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MVC_Project_Herexamen.Models;
using MVC_Project_Herexamen.Viewmodel;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Beheerder")]
public class UserController : Controller
{
    private readonly UserManager<CustomUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var roles = _roleManager.Roles.ToList();

        var model = new UserManagementViewModel
        {
            Users = users,
            Roles = roles
        };

        return View(model);
    }



    public IActionResult Create()
    {
        var roles = _roleManager.Roles.Where(r => r.Name != "Beheerder").ToList();
        var model = new CreateUserViewModel
        {
            Roles = roles.Select(r => r.Name).ToList()
        };
        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new CustomUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.LastName,
                FirstName = model.FirstName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Voeg de gebruiker toe aan de geselecteerde rol
                await _userManager.AddToRoleAsync(user, model.Role);
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // Haal de rollen opnieuw op als het formulier opnieuw wordt weergegeven
        model.Roles = _roleManager.Roles.Where(r => r.Name != "Beheerder").Select(r => r.Name).ToList();
        return View(model);
    }



    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var roles = _roleManager.Roles.Where(r => r.Name != "Beheerder").ToList();
        var userRole = await _userManager.GetRolesAsync(user);

        var model = new EditUserViewModel
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.Name,
            Role = userRole.FirstOrDefault(),
            Roles = roles.Select(r => r.Name).ToList()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.Name = model.LastName;

            var userRole = await _userManager.GetRolesAsync(user);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.Role) && !userRole.Contains(model.Role))
                {
                    await _userManager.RemoveFromRolesAsync(user, userRole);
                    await _userManager.AddToRoleAsync(user, model.Role);
                }

                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        model.Roles = _roleManager.Roles.Where(r => r.Name != "Beheerder").Select(r => r.Name).ToList();
        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction("Index");
    }
}
