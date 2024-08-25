using Microsoft.AspNetCore.Mvc;
using MVC_Project_Herexamen.Models;
using MVC_Project_Herexamen.Data;

public class SubjectController : Controller
{
    private readonly MVCProjectContext _context;

    public SubjectController(MVCProjectContext context)
    {
        _context = context;
    }

    public IActionResult Index(bool showInactive = false)
    {
        var subjects = _context.Subjects
            .Where(s => showInactive || !s.Deleted)
            .ToList();

        ViewBag.ShowInactive = showInactive;
        return View(subjects);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Subject subject)
    {
        if (ModelState.IsValid)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(subject);
    }

    public IActionResult Edit(int id)
    {
        var subject = _context.Subjects.Find(id);
        if (subject == null)
        {
            return NotFound();
        }
        return View(subject);
    }

    [HttpPost]
    public IActionResult Edit(Subject subject)
    {
        if (ModelState.IsValid)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(subject);
    }

    [HttpPost]
    public IActionResult ToggleActive(int id)
    {
        var subject = _context.Subjects.Find(id);
        if (subject != null)
        {
            subject.Deleted = !subject.Deleted;
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
