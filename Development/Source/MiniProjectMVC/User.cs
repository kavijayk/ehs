//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniProjectMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Security;

    public partial class User
    {
        [Required(ErrorMessage = "Username is compulsory field")]
        [DisplayName("Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is compulsory field")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [MembershipPassword(
           MinRequiredNonAlphanumericCharacters = 1,
           MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
           ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc)."
        )]
        [DataType(DataType.Password)]
        public string Pasword { get; set; }


        [Required(ErrorMessage = "Please select User type")]
        [DisplayName("User type")]
        public string UserType { get; set; }
    }
}
