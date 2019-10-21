using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Navi2.Data;

namespace Navi2.Pages.myDept
{
    public class IndexModel : PageModel
    {
        private readonly Navi2.Data.ApplicationDbContext _context;

        public IndexModel(Navi2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dept> Dept { get;set; }

        public async Task OnGetAsync()
        {
            Dept = await _context.Dept.ToListAsync();
        }
    }
}
