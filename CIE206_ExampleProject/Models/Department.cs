using System.ComponentModel.DataAnnotations;

namespace CIE206_ExampleProject.Models
{
	public class Department
	{
		public string Dname { get; set; }
		[Required]
		public int Dnumber { get; set; }
		public string Mgr_ssn { get; set; }
		public string Mgr_start_date { get; set; }
	}
}
