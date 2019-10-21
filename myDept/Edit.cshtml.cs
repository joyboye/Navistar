using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Navi2.Data;

namespace Navi2.Pages.myDept
{
    public class EditModel : PageModel
    {
        private readonly Navi2.Data.ApplicationDbContext _context;

        public EditModel(Navi2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dept Dept { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dept = await _context.Dept.FirstOrDefaultAsync(m => m.DID == id);

            if (Dept == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dept).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptExists(Dept.DID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeptExists(int id)
        {
            return _context.Dept.Any(e => e.DID == id);
        }
    }
}
