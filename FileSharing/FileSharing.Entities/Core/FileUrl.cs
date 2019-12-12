using System.ComponentModel.DataAnnotations;

namespace FileSharing.Entities.Core
{
    public class FileUrl
    {
        public int Id { get; set; }

        [Display(Name = "Ссылка на скачивание")]
        public string Url { get; set; }
    }
}
