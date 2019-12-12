using System.ComponentModel.DataAnnotations;

namespace FileSharing.Entities.Core
{
    public class FileAccess
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Доступ")]
        public string Name { get; set; }
    }
}
