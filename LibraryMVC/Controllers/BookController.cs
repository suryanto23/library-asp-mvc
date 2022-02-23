using LibraryMVC.Database;
using LibraryMVC.Models;
using LibraryMVC.Models.PostModels;
using LibraryMVC.Models.PutModels;
using LibraryMVC.Models.DeleteModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    public class BookController : Controller
    {
        private IndexContext _context;
        public BookController(IndexContext source)
        {
            _context = source;
        }

        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }
        
        public IActionResult BookDetails(Guid id)
        {
            BookModel book = _context.Books.Where(item => item.id == id).FirstOrDefault();
            if(book != null)
            {
                int countRent = _context.Transactions.Where(x => id.ToString().Contains(x.bookId.ToString())).Count();
                ViewBag.countRent = countRent;
                return View(book);
            } else
            {
                ViewBag.Invalid = "Book not found :(";
                return View();
            }
        }

        public IActionResult CreateBook(Guid id)
        {
            return View();            
        }

        [HttpPost]
        public IActionResult CreateBook(PostBook model)
        {
            if(model.stock < 1)
            {
                ViewData["stockInvalid"] = "Stock cant be less than 1";
                return View();
            }
            BookModel book = new BookModel();
            book.title = model.title;
            book.author = model.author;
            book.publisher = model.publisher;
            book.year = model.year;
            book.stock = model.stock;

            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditBook(Guid id)
        {
            BookModel book = _context.Books.Where(item => item.id == id).FirstOrDefault();   
            return View(book);
        }

        [HttpPost]
        public IActionResult EditBook(PutBook model)
        {
            BookModel book = _context.Books.Where(item => item.id == model.id).FirstOrDefault();
            if(book != null)
            {
                book.title = model.title;
                book.author = model.author;
                book.publisher = model.publisher;
                book.year = model.year;

                _context.Books.Update(book);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteBook(DeleteBook model)
        {
            BookModel book = _context.Books.Where(item => item.id == model.id).FirstOrDefault();
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();                
            }
            return RedirectToAction("index");
        }

        public IActionResult TransactionForm(Guid id)
        {
            BookModel book = _context.Books.Where(item => item.id == id).FirstOrDefault();
            if (book != null){
                int onRent = _context.Transactions.Where(item => id.ToString()
                    .Contains(item.bookId.ToString()) && item.returnDate == DateTime.MinValue)
                    .Count();
                ViewBag.onRent = onRent;
                return View(book);
            }
            return RedirectToAction("Index");
        }
    }
}
