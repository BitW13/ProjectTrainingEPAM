using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Entities.Models
{
    public class EditFileViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Имя файла")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Описание файла")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Сделать его открытым для скачивания")]
        public bool IsPublic { get; set; }
    }
}
