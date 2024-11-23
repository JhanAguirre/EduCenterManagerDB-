using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerDB.Data;
using EduCenterManagerDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace EduCenterManagerDB.Pages.Profesores
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Profesor> Profesores { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Profesores = await _context.Profesores.ToListAsync();
        }
    }
}