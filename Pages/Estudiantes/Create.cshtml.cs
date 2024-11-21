using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Estudiantes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["Cursos"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Cursos"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
                return Page();
            }

            _context.Estudiantes.Add(Estudiante);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}