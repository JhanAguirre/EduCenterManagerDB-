using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Cursos
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Profesores"] = new SelectList(_context.Profesores, "IdProfesor", "Nombre");
            return Page();
        }

        [BindProperty]
        public Curso Curso { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Profesores"] = new SelectList(_context.Profesores, "IdProfesor", "Nombre");
                return Page();
            }

            _context.Cursos.Add(Curso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}