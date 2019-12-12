using System;
using System.ComponentModel.DataAnnotations;

namespace FileSharing.Entities.Core
{
    public class UserClaims
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfRegistration { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
