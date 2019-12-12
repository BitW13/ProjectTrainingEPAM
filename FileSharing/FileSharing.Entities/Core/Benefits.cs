using System.ComponentModel.DataAnnotations;

namespace FileSharing.Entities.Core
{
    public class Benefits
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название льготы")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Размер")]
        public double Size { get; set; }
    }
}
