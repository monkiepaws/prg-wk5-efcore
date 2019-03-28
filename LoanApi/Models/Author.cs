using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoanApi.Models
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorTfn { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Book { get; set; }
    }
}
