using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BANXEDAP.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="username cannot be blank.")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "username cannot be blank.")]
        public string Pass { get; set; }
        [Required(ErrorMessage = "password cannot be blank.")]
        [Compare("Pass", ErrorMessage = "password and confirm")]

        public string ConfirmPass { get; set; }
    }
}