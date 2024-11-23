using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Calificaciones
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Calificacion Calificacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificaciones
                .Include(c => c.Estudiante)
                .Include(c => c.Curso)
                .FirstOrDefaultAsync(m => m.IdCalificacion == id);

            if (calificacion == null)
            {
                return NotFound();
            }
            Calificacion = calificacion;

            ViewData["Estudiantes"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Nombre");
            ViewData["Cursos"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Calificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionExists(Calificacion.IdCalificacion))
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

        private bool CalificacionExists(int id)
        {
            return _context.Calificaciones.Any(e => e.IdCalificacion == id);
        }
    }
}