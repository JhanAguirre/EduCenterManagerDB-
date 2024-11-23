using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace EduCenterManagerDB.Pages.Calificaciones
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
            ViewData["Estudiantes"] = new SelectList(_context.Estudiantes
                .Select(e => new { e.IdEstudiante, NombreCompleto = e.Nombre + " " + e.Apellido }),
                "IdEstudiante", "NombreCompleto");
            ViewData["Cursos"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
            return Page();
        }

        [BindProperty]
        public Calificacion Calificacion { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Estudiantes"] = new SelectList(_context.Estudiantes
                    .Select(e => new { e.IdEstudiante, NombreCompleto = e.Nombre + " " + e.Apellido }),
                    "IdEstudiante", "NombreCompleto");
                ViewData["Cursos"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
                return Page();
            }

            _context.Calificaciones.Add(Calificacion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}