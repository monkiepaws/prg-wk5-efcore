using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoanApi.Models
{
    public partial class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int? YearPublished { get; set; }
        public int AuthorId { get; set; }

        [JsonIgnore]
        public virtual Author Author { get; set; }
        [JsonIgnore]
        public virtual Loan Loan { get; set; }
    }
}
