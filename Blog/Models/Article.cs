using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Article
    {
        
        public int Id { get; set; }
        public string path { get; set; }
        public string Title { get; set; }
  
        public string Discription { get; set; }
        public int? CategoryId { get; set; }
        public Category CN { get; set; }
        public string getcat()
        {
            return this.CN.CategoryName;
        }
    }
}