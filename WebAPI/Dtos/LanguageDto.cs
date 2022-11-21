using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class LanguageDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Name is mandatory")]
        [StringLength(50)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Numerics are not allowed")]
        public string Name { get; set; }
        //[Required]
        public string Origin { get; set; }
    }
}