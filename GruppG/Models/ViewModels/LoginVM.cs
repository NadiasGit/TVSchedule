using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GruppG.Models.ViewModels
{
    public class LoginVM
    {
        //Log in function

        [Required(ErrorMessage = "Du måste ange ett användarnamn")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Du måste ange ett användarnamn")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Nullable<int> Role { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}