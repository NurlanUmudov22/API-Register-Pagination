﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Account
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }
    }
}
