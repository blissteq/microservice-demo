using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRestTest.Abstraction.BookLoan.Entities
{
  public  class LoanEntity:IEntity
    {
        public bool IsDeleted { get ; set ; }
        public int Id { get; set; }

      public  int ReaderId { get; set; }

         public int BookId { get; set; }
         public DateTime IssueDate { get; set; }

         public DateTime ReturnDate { get; set; }
    }
}
