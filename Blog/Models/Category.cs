using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Article> Articles { get; set; }

        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }
        public Category()
        {
            Articles = new List<Article>();
        }
    }
}