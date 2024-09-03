using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        readonly MyPortfolioContext _context;

        public _FeatureComponentPartial(MyPortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<Feature> values = _context.Features.ToList();
            return View(values);
        }
    }
}
