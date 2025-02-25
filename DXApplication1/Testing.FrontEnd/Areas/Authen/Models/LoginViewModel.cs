﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.FrontEnd.Areas.Authen.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
       
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "'Password' and 'Confirm Password' do not match.")]
        public string ConfirmPassword { get; set; }

        public bool CheckPassword => this.Password == this.ConfirmPassword;
    }
}
