using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoanApi.Models
{
    public partial class Student
    {
        public Student()
        {
            Loan = new HashSet<Loan>();
        }

        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public virtual ICollection<Loan> Loan { get; set; }
    }
}
