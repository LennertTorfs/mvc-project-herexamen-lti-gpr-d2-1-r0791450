﻿using System.ComponentModel.DataAnnotations;

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

    public List<string> Roles { get; set; } = new List<string>();
}
