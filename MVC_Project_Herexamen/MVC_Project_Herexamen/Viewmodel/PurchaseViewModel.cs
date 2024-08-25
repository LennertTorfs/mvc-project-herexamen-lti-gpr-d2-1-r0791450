using MVC_Project_Herexamen.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project_Herexamen.Viewmodel
{
    public class PurchaseViewModel
    {
        public string CustomUserId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public int? SubjectId { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public List<CustomUser> Users { get; set; } = new List<CustomUser>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
