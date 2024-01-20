using System.ComponentModel.DataAnnotations;

namespace CIE206_ExampleProject.Models
{
	public class DeptLocations
	{
		[Required]
		public int Dnumber { get; set; }
		[Required]
		public string Dlocation { get; set; }
	}
}
