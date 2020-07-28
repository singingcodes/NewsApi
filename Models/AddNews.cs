namespace NewsApi.Models {
    public class AddNews {
        public string HeadLine { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public Category Category { get; set; }
    }
}