using Microsoft.AspNetCore.Mvc;
using MVC_Project_Herexamen.Data;
using MVC_Project_Herexamen.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Beheerder")]
public class PurchaseManagementController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PurchaseManagementController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var purchases = await _unitOfWork.Purchases.GetAllAsync();
        return View("Purchase/Index", purchases); // Specify the path here
    }
    public async Task<IActionResult> Details(int id)
    {
        var purchase = await _unitOfWork.Purchases.GetByIdAsync(id);
        if (purchase == null)
        {
            return NotFound();
        }

        return View(purchase);
    }

    public async Task<IActionResult> Approve(int id)
    {
        var purchase = await _unitOfWork.Purchases.GetByIdAsync(id);
        if (purchase == null)
        {
            return NotFound();
        }

        purchase.Approved = true;
        await _unitOfWork.SaveAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Reject(int id)
    {
        var purchase = await _unitOfWork.Purchases.GetByIdAsync(id);
        if (purchase == null)
        {
            return NotFound();
        }

        purchase.Approved = false;
        await _unitOfWork.SaveAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Archive(int id)
    {
        var purchase = await _unitOfWork.Purchases.GetByIdAsync(id);
        if (purchase == null)
        {
            return NotFound();
        }

        purchase.Deleted = true;
        await _unitOfWork.SaveAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Reopen(int id)
    {
        var purchase = await _unitOfWork.Purchases.GetByIdAsync(id);
        if (purchase == null)
        {
            return NotFound();
        }

        purchase.Deleted = false;
        await _unitOfWork.SaveAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var purchase = await _unitOfWork.Purchases.GetByIdAsync(id);
        if (purchase == null)
        {
            return NotFound();
        }

        _unitOfWork.Purchases.Remove(purchase);
        await _unitOfWork.SaveAsync();

        return RedirectToAction("Index");
    }
}
