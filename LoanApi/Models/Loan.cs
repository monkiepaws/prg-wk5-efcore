using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoanApi.Models
{
    public partial class Loan
    {
        public string StudentId { get; set; }
        public string Isbn { get; set; }

        [JsonIgnore]
        public Book IsbnNavigation { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
    }
}
