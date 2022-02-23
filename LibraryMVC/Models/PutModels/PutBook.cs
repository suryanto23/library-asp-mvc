namespace LibraryMVC.Models.PutModels
{
    public class PutBook
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public int year { get; set; }
    }
}
