namespace LibraryMVC.Models
{
    public class BookModel
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public int year { get; set; }
        public int stock { get; set; }
    }
}
