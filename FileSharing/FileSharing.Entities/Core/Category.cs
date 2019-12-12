using System.ComponentModel.DataAnnotations;

namespace FileSharing.Entities.Core
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Это поле должно быть от {2} до {1} символов", MinimumLength = 3)]
        [Display(Name = "Имя категории")]
        public string Name { get; set; }
    }
}
