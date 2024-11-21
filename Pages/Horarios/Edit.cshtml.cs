using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Horarios
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Horario Horario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FirstOrDefaultAsync(m => m.IdHorario == id);
            if (horario == null)
            {
                return NotFound();
            }

            Horario = horario;
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

            _context.Attach(Horario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(Horario.IdHorario))
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

        private bool HorarioExists(int id)
        {
            return _context.Horarios.Any(e => e.IdHorario == id);
        }
    }
}