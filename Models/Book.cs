using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_relationship_between_the_table.Models
{
    public  class Book
    {
        public int BookId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public int year_of_release { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
