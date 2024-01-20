using System.ComponentModel.DataAnnotations;

namespace CIE206_ExampleProject.Models
{
	public class Project
	{
		public string Pname { get; set; }
		[Required]
		public int Pnumber { get; set; }
		[Required]
		public string Plocation { get; set; }
		public int Dnum { get; set; }
	}
}
