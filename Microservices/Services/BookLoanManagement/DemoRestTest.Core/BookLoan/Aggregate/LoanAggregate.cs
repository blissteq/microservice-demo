using DemoRestTest.Abstraction.BookLoan.Entities;
using DemoRestTest.Abstraction.BookLoan.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRestTest.Core.BookLoan.Aggregate
{
    public class LoanAggregate : BaseAggregate<LoanEntity>
    {
        public LoanAggregate(LoanEntity entity) : base(entity)
        {

        }

        public void SaveLoan(Loan loan)
        {
            SetEntity(loan);
        }

        public void DeleteLoan()
        {
            Entity.IsDeleted = true;
        }

        public void ValidateLoan(Loan loan)
        {

        }

        private void SetEntity(Loan loan)
        {
            Entity.Id = loan.Id;
            Entity.BookId = loan.BookId;
            Entity.IssueDate= loan.IssueDate;
            Entity.ReaderId = loan.ReaderId;
            Entity.ReturnDate= loan.ReturnDate;
        }
    }
}
