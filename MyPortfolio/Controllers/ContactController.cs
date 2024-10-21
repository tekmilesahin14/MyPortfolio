using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class ContactController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult Index()
		{
			var values = context.Contacts.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateToContact()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateToContact(Contact contact)
		{
			context.Contacts.Add(contact);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult DeleteToContact(int id)
		{
			var value = context.Contacts.Find(id);
			context.Contacts.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateToContact(int id)
		{
			var value = context.Contacts.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateToContact(Contact contact)
		{
			context.Contacts.Update(contact);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
