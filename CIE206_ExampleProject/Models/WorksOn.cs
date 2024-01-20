using System.ComponentModel.DataAnnotations;

namespace CIE206_ExampleProject.Models
{
	public class WorksOn
	{
		[Required]
		public int Essn { get; set; }
		public int Pno { get; set; }
		public int Hours { get; set; }
	}
}
