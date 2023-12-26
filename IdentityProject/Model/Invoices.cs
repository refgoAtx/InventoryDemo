using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Model
{
	public class Invoices
	{
		[Key]
		public int Id { get; set; }
		public string? firstname { get; set; }
	}
}
