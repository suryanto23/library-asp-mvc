using LibraryMVC.Database;
using LibraryMVC.Models;
using LibraryMVC.Models.PostModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Controllers
{
    public class TransactionController : Controller
    {
        private IndexContext _context;
        public TransactionController(IndexContext source)
        {
            _context = source;
        }

        public IActionResult Index()
        {
            int totalRecord = _context.Transactions.Count();
            int totalOngoing = _context.Transactions.Where(item => item.returnDate == DateTime.MinValue).Count();
            int totalFinish = _context.Transactions.Where(item => item.returnDate != DateTime.MinValue).Count();

            ViewBag.totalRecord = totalRecord;
            ViewBag.totalOngoing = totalOngoing;
            ViewBag.totalFinish = totalFinish;

            return View(_context.Transactions
                .Include(item => item.book)
                .ToList());
        }

        [HttpPost]
        public IActionResult AddTransaction(PostTransaction model)
        {
            TransactionModel transaction = new TransactionModel();
            transaction.bookId = model.bookId;
            transaction.name = model.name;
            transaction.onRent = true;
            transaction.startRent = DateTime.Today.Date;
            transaction.endRent = model.endRent;            
            // transaction.isReturn = false;
            _context.Transactions.Add(transaction);

            BookModel book = _context.Books.Where(item => item.id == model.bookId).FirstOrDefault();
            book.stock = book.stock - 1;
            _context.Books.Update(book);

            _context.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        public IActionResult Finish(Guid id)
        {
            TransactionModel transaction = _context.Transactions.Where(item => item.id == id).FirstOrDefault();

            if (transaction != null)
            {
                transaction.returnDate = DateTime.Today.Date;
                _context.Transactions.Update(transaction);

                BookModel book = _context.Books.Where(item => item.id == transaction.bookId).FirstOrDefault();
                book.stock = book.stock + 1;

                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
