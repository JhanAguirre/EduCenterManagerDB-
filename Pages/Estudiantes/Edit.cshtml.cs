using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Estudiantes
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            Estudiante = estudiante;
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

            _context.Attach(Estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(Estudiante.IdEstudiante))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.IdEstudiante == id);
        }
    }
}