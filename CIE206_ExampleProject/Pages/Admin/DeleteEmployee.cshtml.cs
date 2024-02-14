using CIE206_ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE206_ExampleProject.Pages.Admin
{
    public class DeleteEmployeeModel : PageModel
    {
        public DB db { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ssn { get; set; }

        [BindProperty(SupportsGet = true)]
        public string msg { get; set; }
        public DeleteEmployeeModel(DB db)
        {
            this.db = db;
        }
        public void OnGet(string ssn)
        {
            this.ssn = ssn;
        }
        public IActionResult? OnPost()
        {
            msg = db.DeleteEmployee(ssn);
            if (msg == "1")
            {
                return RedirectToPage("/Admin/Index");
            }
            return null;
        }
    }
}
