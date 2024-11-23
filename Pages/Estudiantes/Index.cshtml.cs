using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Models;
using EduCenterManagerDB.Data;
using Microsoft.AspNetCore.Authorization;

namespace EduCenterManagerDB.Pages.Estudiantes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Estudiante> Estudiantes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Estudiantes = await _context.Estudiantes
                .Include(e => e.Curso)
                .ToListAsync();
        }
    }
}