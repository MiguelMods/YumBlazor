using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YumBlazor.Data.Entities
{
    [Table("Products")]
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.1, 1000)]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? SpecialTag { get; set; }
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
