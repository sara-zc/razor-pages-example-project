using CIE206_ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIE206_ExampleProject.Pages.Admin
{
    [BindProperties(SupportsGet = true)]

    public class AddEmployeeModel : PageModel
    {
        public DB db { get; set; }
        public string? msg { get; set; }
        public Employee emp { get; set; }
        public string? validation_errors { get; set; }
        public AddEmployeeModel(DB db)
        {
            this.db = db;
            validation_errors = "";
            msg = "";
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                string res = db.AddEmployee(emp);
                if (res == "1")
                    msg = "successfully added new employee!";
                else
                    msg = res;
            }
            else
            {
                validation_errors = ModelState.SelectMany(state => state.Value.Errors).Aggregate("", (current, error) => current + error.ErrorMessage + ". ");
            }
        }
    }
}
