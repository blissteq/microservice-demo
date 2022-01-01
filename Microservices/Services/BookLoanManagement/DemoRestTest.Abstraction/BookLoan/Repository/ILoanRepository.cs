using DemoRestTest.Abstraction.BookLoan.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRestTest.Abstraction.BookLoan.Repository
{
   public interface ILoanRepository : IRepository<LoanEntity, int>
    {
    }
}
