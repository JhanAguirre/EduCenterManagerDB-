using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace EduCenterManagerDB.Pages.Cursos
{
    [Authorize]
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