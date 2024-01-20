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
        public void OnGet()
        {
            dt = db.ReadTable("Employee");

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
