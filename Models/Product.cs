using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyTask.Models
{
    [Table("All_Product_Name")]
    public class Product
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ProductId { get; set; } 

        [Required(ErrorMessage = "Product Name is required")] 
        [MaxLength(100, ErrorMessage = "Product Name cannot exceed 100 characters")] 
        public string ProductName { get; set; }

        [Required] 
        public int CategoryID { get; set; }

        [Required] 
        public string CategoryName { get; set; }
    }
}
