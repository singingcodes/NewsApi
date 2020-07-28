using System;
namespace NewsApi.Models {
    public class News {

        public int ID { get; set; }
        public string HeadLine{ get; set; }
        public string Author { get; set; }

        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
      
        public Category Category{ get; set; }

    }
}