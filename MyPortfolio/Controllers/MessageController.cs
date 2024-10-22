using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class MessageController : Controller
	{
		readonly MyPortfolioContext _context;

		public MessageController(MyPortfolioContext context)
		{
			_context = context;
		}

		public IActionResult Inbox()
		{
			List<Message> values=_context.Messages.ToList();
			return View(values);
		}

		public IActionResult ChangeIsReadToTrue(int id)
		{
			Message value = _context.Messages.Find(id); 
			value.IsRead = true;
			_context.SaveChanges();
			return RedirectToAction("Inbox");
		}

        public IActionResult ChangeIsReadToFalse(int id)
        {
            Message value = _context.Messages.Find(id);
            value.IsRead = false;
            _context.SaveChanges();
            return RedirectToAction("Inbox");
        }

		public IActionResult DeleteMessage(int id)
		{
			Message value = _context.Messages.Find(id);
			_context.Messages.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("Inbox");
		}

		public IActionResult MessageDateil(int id)
		{
			Message value = _context.Messages.Find(id);
			return View(value);
		}
    }
}
