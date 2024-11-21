using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Horarios
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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

            var horario = await _context.Horarios
                .Include(h => h.Curso)
                .FirstOrDefaultAsync(m => m.IdHorario == id);

            if (horario == null)
            {
                return NotFound();
            }

            Horario = horario;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FindAsync(id);
            if (horario != null)
            {
                Horario = horario;
                _context.Horarios.Remove(Horario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}