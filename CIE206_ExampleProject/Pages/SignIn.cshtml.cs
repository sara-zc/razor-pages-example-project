using CIE206_ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE206_ExampleProject.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string username { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public string password { get; set; } = "";
        public string msg { get; set; } = "";
        public DB db { get; set; }
        
        public SignInModel(DB db) { 
            this.db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (db.ValidateUser(username, password))
            {
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("password", password);

                if(username.StartsWith("a-")) {
                    return RedirectToPage("/Admin/Index");
                }
                return RedirectToPage("/Index");

            }
            msg = "username or password incorrect ..";
            return Page();
        }
    }
}
