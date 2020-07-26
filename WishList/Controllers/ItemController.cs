using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers {

public class ItemController : Controller {
  private readonly ApplicationDbContext _context;

  public ItemController(ApplicationDbContext context) {
    _context = context;
  }
  // PS complaining again >_>
  // this._context = context;
  
  public IActionResult Index() {
    return View("Index", _context.Items.ToList());
  }

  [HttpGet]
  public IActionResult Create() {
    return View("Create");
  }

  [HttpPost]
  public IActionResult Create(Item item) {
    _context.Items.Add(item);
    _context.SaveChanges();
    return RedirectToAction("Index");
  }

  public IActionResult Delete(int id) {
    var item = _context.Items.FirstOrDefault(e => e.Id == id);
    _context.Items.Remove(item);
    _context.SaveChanges();
    return RedirectToAction("Index");
  }

  // PluralSight doesn't like this even though it's right.
  // public IActionResult Delete(int id) {
  //   var item = _context.Items.First(x => x.Id == id);
  //   if(item != null) {
  //     _context.Items.Remove(item);
  //     _context.SaveChanges();
  //   }
  //   return RedirectToAction("Index");
  // }

}

}
