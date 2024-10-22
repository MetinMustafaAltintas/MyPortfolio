using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
        readonly MyPortfolioContext _context;

		public _LayoutNavbarComponentPartial(MyPortfolioContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.toDolistCount = _context.ToDoLists.Where(x => x.Status == false).Count();
			List<ToDoList> values = _context.ToDoLists.Where(x => x.Status == false).ToList();
			return View(values);
		}
	}
}
