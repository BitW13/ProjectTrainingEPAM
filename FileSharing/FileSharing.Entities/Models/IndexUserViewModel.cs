using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Entities.Models
{
    public class IndexUserViewModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string UserRoleName { get; set; }
    }
}
