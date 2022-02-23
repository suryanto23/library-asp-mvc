namespace LibraryMVC.Models.PostModels
{
    public class PostTransaction
    {
        public Guid bookId { get; set; }
        public string name { get; set; }
        public bool onRent { get; set; }
        public DateTime startRent { get; set; }
        public DateTime endRent { get; set; }
    }
}
