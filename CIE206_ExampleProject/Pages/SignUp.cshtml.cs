using CIE206_ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE206_ExampleProject.Pages
{    
    public class SignUpModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string username { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public string password { get; set; } = "";
        public string msg { get; set; }
        public DB db { get; set; }
        public SignUpModel(DB db) {
            this.db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                msg = db.AddUser(username, password);
                if (msg == "1")
                {
                    return RedirectToPage("/SignIn");
                }
            }
            return Page();
        }
    }
}
