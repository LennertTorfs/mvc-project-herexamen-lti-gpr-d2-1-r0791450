using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MVC_Project_Herexamen.Models;
using System.ComponentModel.DataAnnotations;

public class RegisterModel : PageModel
{
    private readonly UserManager<CustomUser> _userManager;
    private readonly SignInManager<CustomUser> _signInManager;

    public RegisterModel(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public async Task<IActionResult> OnGetAsync()
    {
        // Check if any user with the 'Beheerder' role exists
        var beheerderExists = _userManager.Users.Any(u => _userManager.IsInRoleAsync(u, "Beheerder").Result);

        if (beheerderExists)
        {
            return RedirectToPage("/Account/Login"); // Redirect to login if a 'Beheerder' already exists
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var user = new CustomUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, Name = Input.Name };
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Beheerder");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/Account/Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return Page();
    }
}
