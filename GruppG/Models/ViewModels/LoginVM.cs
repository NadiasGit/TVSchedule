using GruppG.Models.db;
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

        //[Required(ErrorMessage = "Du måste ange ett användarnamn")]
        [Required]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Du måste ange ett lösenord")]
        //För att lösenordet inte ska synas
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Eric använder inte dessa (31 min)
        public Nullable<int> Role { get; set; }
        public string LoginErrorMessage { get; set; }
        public Person Person { get; set; }
    }
}