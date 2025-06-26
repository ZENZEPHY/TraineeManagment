using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TraineeManagmentApplication.Models;

namespace TraineeManagmentApplication.Controllers;

public class HomeController : Controller
{
   
    tochContext context = new tochContext();
    public IActionResult Index()
    {
        return View(context.Contacts.ToList());
    }


    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Create(Contact con)
    {
        if (ModelState.IsValid)
        {
            context.Contacts.Add(con);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        return RedirectToAction("index");
    }


    public IActionResult Details(int id)
    {
        var man = context.Contacts.Find(id);
        return View(man);
    }

    public IActionResult Delete(int id)
    {
        var man = context.Contacts.Find(id);
        return View(man);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(Contact contact)
    { 
        if (contact != null)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
        }
        return RedirectToAction("index");
    }

    public IActionResult Edit(int id)
    {
        return View(context.Contacts.Find(id));
    }

    [HttpPost]
    public IActionResult Edit(Contact contact)
    {
 
            context.Contacts.Update(contact);
            context.SaveChanges();
            return RedirectToAction("index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
