using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class ToDoListController : Controller
    {
        readonly MyPortfolioContext _context;

        public ToDoListController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ToDoList> values = _context.ToDoLists.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateToDoList()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateToDoList(ToDoList toDoList)
        {
            toDoList.Status = false;
            _context.ToDoLists.Add(toDoList);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTodoList(int id)
        {
            ToDoList value = _context.ToDoLists.Find(id);
            _context.ToDoLists.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateToDoList(int id)
        {
            ToDoList value = _context.ToDoLists.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Update(toDoList);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeTodoListStatusToTrue(int id)
        {
            ToDoList value = _context.ToDoLists.Find(id);
            value.Status = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeTodoListStatusToFalse(int id)
        {
            ToDoList value = _context.ToDoLists.Find(id);
            value.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
