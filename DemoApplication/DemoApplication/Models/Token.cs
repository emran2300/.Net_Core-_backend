using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApplication.Models
{
    public class Token
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AutoToken { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
    }
}
