using CIE206_ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE206_ExampleProject.Pages.Admin
{
    [BindProperties(SupportsGet = true)]
    public class UpdateEmployeeModel : PageModel
    {
        public DB db { get; set; }
        public string ssn { get; set; }
        public string msg { get; set; }
        public Employee emp { get; set; }
        public bool showForm { get; set; } = true;

        public UpdateEmployeeModel(DB db)
        {
            this.db = db;
        }
        public void OnGet(string ssn)
        {
            this.ssn = ssn;

            emp = db.getEmployee(ssn);
            if (emp is null)
            {
                msg = "Employee with this SSN was not found!";
                showForm = false;
            }
        }
        public IActionResult? OnPost()
        {
            msg = db.UpdateEmployee(emp);
            if (msg == "1")
            {
                return RedirectToPage("/Index");
            }
            else
                return Page();

        }
    }
}
