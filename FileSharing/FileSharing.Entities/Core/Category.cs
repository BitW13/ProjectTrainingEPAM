using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
