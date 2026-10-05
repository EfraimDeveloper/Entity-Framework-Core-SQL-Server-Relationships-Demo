using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_relationship_between_the_table.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }= string.Empty;
        public string Surname {  get; set; }= string.Empty;

        public ICollection<Book> Books { get; set; }
    }
}
