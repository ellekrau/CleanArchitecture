using CleanArchitecture.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(1)]
        [MaxLength(200)]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(1, 9999)]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Display(Name = "Image")]
        [MaxLength(255)]
        public string? Image { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
    }
}
