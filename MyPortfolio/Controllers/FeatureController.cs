using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class FeatureController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult Index()
		{
			var values = context.Features.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateFeature()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateFeature(Feature feature)
		{
			context.Features.Add(feature);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult DeleteToFeature(int id)
		{
			var value = context.Features.Find(id);
			context.Features.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateToFeature(int id)
		{
			var value = context.Features.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateToFeature(Feature feature)
		{
			context.Features.Update(feature);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
