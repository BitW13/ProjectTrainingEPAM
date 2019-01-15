using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Entities.Core
{
    public class File
    {
        public int Id { get; set; }

        [Display(Name = "Имя файла")]
        public string Name { get; set; }

        [Display(Name = "Размер файла")]
        public double Size { get; set; }

        [Display(Name = "Описание файла")]
        public string Description { get; set; }

        [Display(Name = "Дата загрузки")]
        public DateTime DownloadDate { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Общедоступный")]
        public bool Public { get; set; }

        [Display(Name = "Ссылка на скачивание")]
        public string Url { get; set; }

        public int UserId { get; set; }
    }
}
