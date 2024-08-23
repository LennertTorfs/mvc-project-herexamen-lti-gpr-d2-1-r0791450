using System.ComponentModel.DataAnnotations;

namespace MVC_Project_Herexamen.Models
{
    public class Product
    {
        #region publics
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "De naam van het product is verplicht")]
        [StringLength(100, ErrorMessage = "De naam mag niet langer zijn dan 100 karakters")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "De prijs van het product is verplicht")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }  
        public string Quantity { get; set; } = default!;
        [Required]
        public int PurchaseId { get; set; }

        public Purchase Purchase { get; set; } = default!; 
        #endregion
    }
}
