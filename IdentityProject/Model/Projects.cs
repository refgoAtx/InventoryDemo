using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityProject.Model
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Createdat { get; set; }
        public string? Createdby { get; set; }
        public DateTime Updatedat { get; set; }
        public string? Updatedby { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryID { get; set; }
        public virtual Inventory? Inventory { get; set; }
    }
}
