using System.ComponentModel.DataAnnotations;

namespace MVC_Project_Herexamen.Models
{
    public class Purchase
    {
        #region publics
        [Key]
        public int PurchaseId { get; set; }

        [Required(ErrorMessage = "De datum van de aanvraag is verplicht")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "De reden van de aankoop is verplicht")]
        public string Reason { get; set; } = default!;

        public bool? Approved { get; set; }

        public bool Deleted { get; set; }

        [Required]
        public string CustomUserId { get; set; }

        public CustomUser CustomUser { get; set; } = default!;


        public int? SubjectId { get; set; } 

        public Subject? Subject { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = default!;

        public ICollection<FileAttachment>? FileAttachments { get; set; } = default!;

        #endregion
    }
}