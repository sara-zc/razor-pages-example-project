using CIE206_ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIE206_ExampleProject.Pages.Admin
{
    public class AllEmployeesModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public DB db { get; set; }
        public DataTable dt { get; set; }
        public Employee selected_emp { get; set; }

        public AllEmployeesModel(DB db) {
            this.db = db;
        }
        public IActionResult? OnGet()
        {
            // do not allow any non-admin users to access
            if (HttpContext.Session.GetString("username") != "a-sara")
            {
                //return Unauthorized();    // returns 401 without message
                return StatusCode((int)System.Net.HttpStatusCode.Unauthorized, "You are not allowed to access the admin dashboard!");
            }
            else {
                dt = db.ReadTable("Employee");
                return null;
            }
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Error");
        }
        public IActionResult OnPostDelete(string ssn)
        {
            Console.WriteLine("Inside onpostdelete.");
            return RedirectToPage("/Admin/DeleteEmployee", new { ssn = ssn });
        }
        public IActionResult OnPostUpdate(string ssn)
        {
            return RedirectToPage("/Admin/UpdateEmployee", new { ssn = ssn });
        }
    }
}
