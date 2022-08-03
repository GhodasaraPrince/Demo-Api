using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_dynamic_api.Models
{
    public class CreateModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string DateTime { get; set; } = string.Empty;
        [Required]
        public string TableName { get; set; } = string.Empty;

        [Required]
        public List<Fields> Fields { get; set; }
    }

    public class Fields
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public int TableIdRef { get; set; }
        [Required]
        public string FieldName { get; set; } = string.Empty;
        [Required]
        public string FieldType { get; set; } = string.Empty;
        [Required]
        public string IsPrimaryKey { get; set; } = string.Empty;
    }

}
