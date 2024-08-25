using Microsoft.AspNetCore.Identity;
using MVC_Project_Herexamen.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project_Herexamen.Viewmodel
{
    public class UserManagementViewModel
    {
        public List<CustomUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }

    public class CreateUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public List<string> Roles { get; set; }
    }

    public class EditUserViewModel
    {
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }

        public List<string> Roles { get; set; }
    }
}
