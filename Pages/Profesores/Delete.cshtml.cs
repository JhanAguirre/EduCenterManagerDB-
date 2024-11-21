using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Profesores
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profesor Profesor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores.FirstOrDefaultAsync(m => m.IdProfesor == id);

            if (profesor == null)
            {
                return NotFound();
            }

            Profesor = profesor;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor != null)
            {
                Profesor = profesor;
                _context.Profesores.Remove(Profesor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}