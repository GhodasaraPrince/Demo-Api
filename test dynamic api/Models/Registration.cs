using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_dynamic_api.Models
{
    public class Registration
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }

        [Required]
        [MinLength(6)]
        public string userName { get; set; } = String.Empty;

        [Required]
        public string firstName { get; set; } = String.Empty;

        [Required]
        [MinLength(8)]
        public string password { get; set; } = String.Empty;

        [Required]
        public string lastName { get; set; } = String.Empty;

        [Required]
        public string email { get; set; } = String.Empty;

        [Required]
        public string number { get; set; }
    }

    public class ApiResponse
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
    }
}
