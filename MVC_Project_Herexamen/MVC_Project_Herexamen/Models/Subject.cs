using System.ComponentModel.DataAnnotations;

namespace MVC_Project_Herexamen.Models
{
    public class Subject
    {
        #region publics

        [Key]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "De naam van het vak is verplicht")]
        [StringLength(100, ErrorMessage = "De naam mag niet langer zijn dan 100 karakters")]
        public string Name { get; set; } = default!;

        public bool Deleted { get; set; }

        public ICollection<Purchase>? Purchases { get; set; } = default!;

        #endregion
    }
}