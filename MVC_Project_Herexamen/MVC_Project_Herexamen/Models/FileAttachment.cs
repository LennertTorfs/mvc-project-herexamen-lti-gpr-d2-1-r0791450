using System.ComponentModel.DataAnnotations;

namespace MVC_Project_Herexamen.Models
{
    public class FileAttachment
    {
        #region publics

        [Key]
        public int FileAttachmentId { get; set; }

        [Required(ErrorMessage = "De bestandsnaam is verplicht")]
        [StringLength(255, ErrorMessage = "De bestandsnaam mag niet langer zijn dan 255 karakters")]
        public string Name { get; set; } = default!;

        [Required]
        public int PurchaseId { get; set; }  

        public Purchase Purchase { get; set; } = default!; 

        #endregion
    }
}