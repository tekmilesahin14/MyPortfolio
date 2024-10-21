using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class AboutController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult AboutList()
		{
			var values = context.Abouts.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateToAbout()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateToAbout(About about)
		{
			context.Abouts.Add(about);
			context.SaveChanges();
			return RedirectToAction("AboutList");
		}
		public IActionResult DeleteToAbout(int id)
		{
			var value = context.Abouts.Find(id);
			context.Abouts.Remove(value);
			context.SaveChanges();
			return RedirectToAction("AboutList");
		}
		[HttpGet]
		public IActionResult UpdateToAbout(int id)
		{
			var value = context.Abouts.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateToAbout(About about)
		{
			context.Abouts.Update(about);
			context.SaveChanges();
			return RedirectToAction("AboutList");
		}
	}
}
