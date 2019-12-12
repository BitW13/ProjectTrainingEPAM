using System.ComponentModel.DataAnnotations;

namespace FileSharing.Entities.Core
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public int UserRoleId { get; set; }

        public int ClaimId { get; set; }
    }
}
