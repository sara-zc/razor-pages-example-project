using CIE206_ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE206_ExampleProject.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        public User user { get; set; }
        public DashboardModel() {
            user = new User();
        }
        public IActionResult? OnGet()
        {
            Console.WriteLine(HttpContext.Session.GetString("username"));
            var username = HttpContext.Session.GetString("username");
            if (username != null)
            {
                user.username = username;
                return null;
            }
            else
            {
                return RedirectToPage("/SignIn");
            }
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("password", "");

            return RedirectToPage("/SignIn");
        }
    }
}
