using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project_Herexamen.Models
{
    public class CustomUser : IdentityUser
    {
        #region publics
        [PersonalData]
        [StringLength(50, ErrorMessage = "Achternaam mag niet langer zijn dan 50 karakters")]
        public string Name { get; set; } = default!;

        [PersonalData]
        [StringLength(50, ErrorMessage = "Voornaam mag niet langer zijn dan 50 karakters")]
        public string FirstName { get; set; } = default!;

        public string Initials
        {
            get { return $"{FirstName[0]}.{Name[0]}.".ToUpper(); }
        }

        public bool Deleted { get; set; }

        public ICollection<Purchase>? Purchases { get; set; } = new List<Purchase>();

        #endregion
    }
}
