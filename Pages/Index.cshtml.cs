using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorPages.Data;

namespace razorPages.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext _myBlogContext;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext myBlogContext)
    {
        _logger = logger;
        _myBlogContext = myBlogContext;
    }

    public async Task OnGet()
    {
        var posts = await (from a in _myBlogContext.articles
                           orderby a.Created descending
                           select a).ToListAsync();
        ViewData["posts"] = posts;
    }
}
