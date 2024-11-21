using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;

namespace EduCenterManagerDB.Pages.Horarios
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Horario> Horarios { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Horarios = await _context.Horarios
                .Include(h => h.Curso)
                .ToListAsync();
        }
    }
}