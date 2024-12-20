using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EduCenterManagerDB.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace EduCenterManagerDB.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

           
            if (User.Email == "admin@admin.com" && User.Password == "Admin123!")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, User.Email),
                    new Claim(ClaimTypes.Email, User.Email)
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            ModelState.AddModelError("", "Credenciales inválidas");
            return Page();
        }
    }
}