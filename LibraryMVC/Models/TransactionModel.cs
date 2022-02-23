namespace LibraryMVC.Models
{
    public class TransactionModel
    {
        public Guid id { get; set; }
        public Guid bookId { get; set; }
        public BookModel book { get; set; }
        public string name { get; set; }
        public bool onRent { get; set; }
        public DateTime startRent { get; set; }
        public DateTime endRent { get; set; }
        public DateTime returnDate { get; set; }

    }
}
