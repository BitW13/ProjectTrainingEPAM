using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FileSharing.Entities.Models
{
    public class UploadFileViewModel
    {
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
