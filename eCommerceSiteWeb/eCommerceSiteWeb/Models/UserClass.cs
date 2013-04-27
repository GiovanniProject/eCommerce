using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSiteWeb.Models
{
    public class UserClass
    {
        [Required]
        public string ID { get; set; }

        [Required(ErrorMessage = "A First Name is required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage="A Last Name is required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A Mail is required")]
        [DataType(DataType.EmailAddress )]
        public string Mail { get; set; }

        [Required(ErrorMessage = "A Password is required")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        public string ConfirmPassword {get;set;}
    }
}