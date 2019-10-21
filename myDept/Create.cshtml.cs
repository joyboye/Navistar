using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Navi2.Data;

namespace Navi2.Pages.myDept
{
    public class CreateModel : PageModel
    {
        private readonly Navi2.Data.ApplicationDbContext _context;

        public CreateModel(Navi2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dept Dept { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dept.Add(Dept);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}