using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Quic;
using Microsoft.EntityFrameworkCore;
using razorPages.Data;
using razorPages.Models;

namespace razorPages.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly razorPages.Data.MyBlogContext _context;

        public IndexModel(razorPages.Data.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;
        public const int ITEMS_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }
        public async Task OnGetAsync([FromQuery] string SearchString)
        {
            if (_context.articles != null)
            {
                // Article = await _context.articles.ToListAsync();
                //  int totalArtical = await _context.articles.CountAsync();
                // countPages = (int)Math.Ceiling((double)totalArtical / ITEMS_PER_PAGE);

                // if (currentPage < 1)
                //     currentPage = 1;
                // if (currentPage > countPages)
                //     currentPage = countPages;
                var qr = (from a in _context.articles
                          orderby a.Created descending
                          select a).AsQueryable();
                if (!string.IsNullOrEmpty(SearchString))
                {
                    qr = qr.Where(a => a.Title!.Contains(SearchString)).AsQueryable();
                    int totalArtical = await qr.CountAsync();
                    countPages = (int)Math.Ceiling((double)totalArtical / ITEMS_PER_PAGE);
                }
                else
                {
                    int totalArtical = await _context.articles.CountAsync();
                    countPages = (int)Math.Ceiling((double)totalArtical / ITEMS_PER_PAGE);
                }

                if (currentPage < 1)
                    currentPage = 1;
                if (currentPage > countPages)
                    currentPage = countPages;
                Article = await qr.Skip((currentPage - 1) * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE).ToListAsync();
            }

        }
    }
}
