using LoanApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApi.ViewModels
{
    public class LoanVm
    {
        public LoanVm(Loan l)
        {
            this.StudentId = l.StudentId;
            this.Student = l.Student;
            this.Isbn = l.Isbn;
            this.Book = l.IsbnNavigation;
        }

        public string StudentId { get; set; }
        public string Isbn { get; set; }

        public Book Book { get; set; }
        public Student Student { get; set; }
    }
}
