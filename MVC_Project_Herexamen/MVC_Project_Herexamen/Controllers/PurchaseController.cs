using Microsoft.AspNetCore.Mvc;
using MVC_Project_Herexamen.Data;
using Microsoft.AspNetCore.Identity;
using MVC_Project_Herexamen.Models;
using MVC_Project_Herexamen.Viewmodel;

namespace MVC_Project_Herexamen.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<CustomUser> _userManager;

        public PurchaseController(IUnitOfWork unitOfWork, UserManager<CustomUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new PurchaseViewModel
            {
                CustomUserId = user.Id,
                Date = DateTime.Now,  
                Subjects = (await _unitOfWork.Subjects.GetAllAsync()).ToList(),
                Products = new List<ProductViewModel>()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var purchase = new Purchase
                {
                    Date = DateTime.Now, // Automatisch de huidige datum instellen
                    Reason = model.Reason,
                    CustomUserId = model.CustomUserId,
                    SubjectId = model.SubjectId,
                    Products = model.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = p.Quantity
                    }).ToList()
                };

                _unitOfWork.Purchases.Add(purchase);
                await _unitOfWork.SaveAsync();

                // TempData om een succesbericht door te geven aan de view
                TempData["SuccessMessage"] = "De aankoopaanvraag is succesvol ingediend.";

                // Na succesvolle invoer, herlaad de pagina en leeg het formulier
                return RedirectToAction("Create");
            }

            model.Subjects = (await _unitOfWork.Subjects.GetAllAsync()).ToList();
            return View(model);
        }


    }
}
