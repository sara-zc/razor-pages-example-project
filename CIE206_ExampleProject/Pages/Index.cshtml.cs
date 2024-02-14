using CIE206_ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE206_ExampleProject.Pages
{
	public class IndexModel : PageModel
	{
        private readonly ILogger<IndexModel> _logger;
        public DB db { get; set; }
        public User user { get; set; }
        public IndexModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;

            user = new User();
        }

        public IActionResult? OnGet()
        {
            Console.WriteLine(HttpContext.Session.GetString("username"));
            var username = HttpContext.Session.GetString("username");
            if (username != null) {
                user.username = username;
                return null;
            }
            else
            {
                return RedirectToPage("/SignIn");
            }
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Error");
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("password", "");

            return RedirectToPage("/SignIn");
        }
    }
}