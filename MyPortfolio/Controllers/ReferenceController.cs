using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using System.Security.Cryptography.Xml;

namespace MyPortfolio.Controllers
{
	public class ReferenceController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult Index()
		{
			var values = context.References.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateToReferanca()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateToReference(MyPortfolio.DAL.Entities.Reference reference)
		{
			context.References.Add(reference);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult DeleteToRefeence(int id)
		{
			var value = context.References.Find(id);
			context.References.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateToReference(int id)
		{
			var value = context.References.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateToReference(MyPortfolio.DAL.Entities.Reference reference)
		{
			context.References.Update(reference);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
