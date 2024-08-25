using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC_Project_Herexamen.Models;

namespace MVC_Project_Herexamen.Viewmodel
{
    public class PurchaseViewModel
    {
        public string CustomUserId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public int? SubjectId { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }

    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Quantity { get; set; }
    }
}
