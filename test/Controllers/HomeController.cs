using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpendSmartDbContext _context;

        public HomeController(ILogger<HomeController> logger,SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            return View(allExpenses);
        }

        public IActionResult CreateEditView(int id)
        {
            var expenseInDB = _context.Expenses.SingleOrDefault(expense => expense.ID == id);   
            return View();
        }

        public IActionResult DeleteView(int id)
        {
            var expenseInDB = _context.Expenses.SingleOrDefault(expense => expense.ID == id);
            _context.Expenses.Remove(expenseInDB);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult CreateEditViewForm(Expense models)
        {
            //add model
            _context.Expenses.Add(models);
            // changes
            _context.SaveChanges();

            return RedirectToAction("Expenses");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
