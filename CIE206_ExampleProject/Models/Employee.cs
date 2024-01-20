using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CIE206_ExampleProject.Models
{
	[BindProperties(SupportsGet = true)]
	public class Employee
	{
		[Required]
		public string SSN { get; set; }
		[Required]
		[StringLength(10, MinimumLength = 3)]
		public string Fname { get; set; }
		public char? Minit { get; set; }
		public string? Lname { get; set; }
		public DateTime? BirthDate { get; set; }
	}
}
