using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace IdentityProject.Model
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string? ItemPerUnit { get; set; }
        public bool ItemTaxable { get; set; }
        public Int64 ItemQnty { get; set; }
        public DateTime Createdat { get; set; }
        public string? Createdby { get; set; }
        public DateTime Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public double Total { get { return (double)(ItemPrice * ItemQnty); } }

        [ForeignKey("Customer")]    
		public int CustomerID { get; set; }
		public virtual Customer? Customer { get; set; }
	}
}
