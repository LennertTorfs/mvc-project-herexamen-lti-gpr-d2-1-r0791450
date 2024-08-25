using System.ComponentModel.DataAnnotations;

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

    public List<string> Roles { get; set; } = new List<string>();
}
