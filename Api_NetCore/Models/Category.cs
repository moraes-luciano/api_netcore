using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Api_NetCore.Models
{
    public class Category : IValidatableObject
    {
        public int Id { get; set; }
        
        [Required] [StringLength(80)]
        public string Name { get; set; }
        
        [Required] [StringLength(300)]
        public string ImgUrl { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new Collection<Product>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var firstChar = Name[0].ToString();
                if (firstChar != firstChar.ToUpper())
                {
                    yield return new ValidationResult(
                        "The first character must be in uppercase",
                        new[] {nameof(Name)});
                }
            }
            
        }
    }
}