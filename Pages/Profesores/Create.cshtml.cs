using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Profesores
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profesor Profesor { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Profesores.Add(Profesor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}