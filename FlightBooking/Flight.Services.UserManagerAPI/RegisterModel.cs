﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.UserManagerAPI
{
    public class RegisterModel
    {
        //[Required (ErrorMessage ="User Name is Required")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
