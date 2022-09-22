using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApplication.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProId { get; set; }
        public string ProName { get; set; }
        public int ProStock { get; set; }
        public double ProPrice { get; set; }
        public string? CatName { get; set; }
    }
}
