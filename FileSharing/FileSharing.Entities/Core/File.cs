using System;
using System.ComponentModel.DataAnnotations;

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

        public int FileAccessId { get; set; }

        public int FileUrlId { get; set; }

        public int UserId { get; set; }
    }
}
