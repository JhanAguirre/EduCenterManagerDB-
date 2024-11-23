using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace EduCenterManagerDB.Pages.Calificaciones
{
    
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Calificacion> Calificaciones { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Calificaciones = await _context.Calificaciones
                .Include(c => c.Estudiante)
                .Include(c => c.Curso)
                .ToListAsync();
        }
    }
}