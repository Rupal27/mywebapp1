﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Library.DTO
{
    public class LoginUserDTO
    {
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
