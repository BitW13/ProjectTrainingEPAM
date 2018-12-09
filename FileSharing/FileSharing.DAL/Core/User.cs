﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Core
{
    public class User
    {
        public Guid Id { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }
    }
}
