﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLecture.Entities.Dtos.User
{
    public class UserInputDto
    {
        [MinLength(4)]
        public required string UserName { get; set; } = "";
        [MinLength(6)]
        public required string Password { get; set; } = "";
    }
}
