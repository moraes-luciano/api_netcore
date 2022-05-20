using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api_NetCore.Validations;

namespace Api_NetCore.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required] [StringLength(80)][FirstUp]
        public string Name { get; set; }
        
        [Required] [StringLength(300)]
        public string Description { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        [Required] [StringLength(300)]
        public string ImgUrl { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Storage { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}