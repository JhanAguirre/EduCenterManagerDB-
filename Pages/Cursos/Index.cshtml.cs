using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Curso> Cursos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Cursos = await _context.Cursos
                .Include(c => c.Profesor)
                .ToListAsync();
        }
    }
}