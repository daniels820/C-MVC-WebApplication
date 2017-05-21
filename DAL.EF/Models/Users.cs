using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public partial class Users
    {
        public string ContactId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string HashPassword { get; set; }
    }
}
