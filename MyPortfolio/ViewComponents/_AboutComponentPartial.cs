using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        readonly MyPortfolioContext _context;

        public _AboutComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle=_context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubDescription=_context.Abouts.Select(x => x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetail=_context.Abouts.Select(x => x.Detail).FirstOrDefault();
            return View();
        }
    }
}
