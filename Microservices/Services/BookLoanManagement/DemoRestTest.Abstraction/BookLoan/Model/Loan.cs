using DemoRestTest.Abstraction.BookLoan.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRestTest.Abstraction.BookLoan.Model
{
   public class Loan
    {
        public Loan()
        {

        }

        public Loan(LoanEntity entity)
        {
            this.Id = Id;
            this.BookId = BookId;
            this.IssueDate = IssueDate;
            this.ReaderId = ReaderId;
            this.ReturnDate = ReturnDate;
        }
      
        public int Id { get; set; }

        public int ReaderId { get; set; }

        public int BookId { get; set; }
        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
