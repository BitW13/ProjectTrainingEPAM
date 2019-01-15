using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Entities.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Это поле должно быть от {2} до {1} символов", MinimumLength = 3)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Неправильный формат")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
