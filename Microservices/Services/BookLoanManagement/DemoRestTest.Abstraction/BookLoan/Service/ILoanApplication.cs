using DemoRestTest.Abstraction.BookLoan.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestTest.Abstraction.BookLoan.Service
{
  public   interface ILoanApplication
    {
        Task<List<string>> AddLoan(Loan loan);

        Task<List<string>> UpdateLoan(Loan loan);
        Task <bool>  DeleteLoan(int id);
        Task<Loan> GetLoan(int id);
        Task<IEnumerable<Loan>> GetLoans();
    }
}
