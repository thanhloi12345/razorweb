using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorPages.Data;
using razorPages.Models;

namespace razorPages.Pages_Blog
{
    public class DetailsModel : PageModel
    {
        private readonly razorPages.Data.MyBlogContext _context;

        public DetailsModel(razorPages.Data.MyBlogContext context)
        {
            _context = context;
        }

      public Article Article { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.articles == null)
            {
                return NotFound();
            }

            var article = await _context.articles.FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            else 
            {
                Article = article;
            }
            return Page();
        }
    }
}
