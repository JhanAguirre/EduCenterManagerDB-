using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Horarios
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
            ViewData["Cursos"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
            return Page();
        }

        [BindProperty]
        public Horario Horario { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Cursos"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
                return Page();
            }

            _context.Horarios.Add(Horario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}