using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Entities.Models
{
    public class AccountIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Логин")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string UserRoleName { get; set; }
    }
}
