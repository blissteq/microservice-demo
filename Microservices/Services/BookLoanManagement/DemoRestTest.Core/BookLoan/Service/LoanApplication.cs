using DemoRestTest.Abstraction.BookLoan.Entities;
using DemoRestTest.Abstraction.BookLoan.Model;
using DemoRestTest.Abstraction.BookLoan.Repository;
using DemoRestTest.Abstraction.BookLoan.Service;
using DemoRestTest.Core.BookLoan.Aggregate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestTest.Core.BookLoan.Service
{
    public class LoanApplication : ILoanApplication
    {
        private readonly ILogger<LoanApplication> _logger;
        private readonly ILoanRepository _repository;

        public LoanApplication(ILogger<LoanApplication> logger, ILoanRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<List<string>> AddLoan(Loan loan)
        {
            _logger.LogInformation("Initialising.....");
            var aggregate = new LoanAggregate(new LoanEntity());
            var result = new List<string>();
            aggregate.ValidateLoan(loan);
            if (aggregate.ResultMessages.Count < 1)
            {
                _logger.LogInformation("save .....");
                aggregate.SaveLoan(loan);
                await _repository.Save(aggregate.Entity);
            }
            else
            {
                result = aggregate.ResultMessages;

            }
            return result;
        }

        public async Task<bool>DeleteLoan(int id)
        {
            //load  record
            _logger.LogInformation("Loading  detials......");
            var entity = await _repository.GetOne(id);
            var result = new List<string>();

            if (entity == null)
            {
                result.Add("Loan not found");
                
            }

            var aggregate = new LoanAggregate(entity);
            if (aggregate.ResultMessages.Count < 1)
            {
                //save person 
                _logger.LogInformation("Saving  details.....");
                aggregate.DeleteLoan();
                await _repository.Save(aggregate.Entity);
            }
            else
            {
                result = aggregate.ResultMessages;
            }
            return entity.IsDeleted;
        }

    

        public async Task<Loan> GetLoan(int id)
        {
            var entity = await _repository.GetOne(id);
            var loan = new Loan(entity);
            return loan;

        }

        public async Task<IEnumerable<Loan>> GetLoans()
    {
        var entities = await _repository.GetAll();
        var loans = new List<Loan>();
        foreach (var entity in entities)
        {
            var loan = new Loan(entity);
            loans.Add(loan);
        }
        return loans;
    }


    public async Task<List<string>> UpdateLoan(Loan loan)
    {
        _logger.LogInformation("Loading person detials......");
        var entity = await _repository.GetOne(loan.Id);
        var result = new List<string>();

        if (entity == null)
        {
            result.Add("Loan not found");
            return result;
        }

        var aggregate = new LoanAggregate(entity);
        aggregate.ValidateLoan(loan);
        if (aggregate.ResultMessages.Count < 1)
        {
            //save person 
            _logger.LogInformation("Saving person details.....");
            aggregate.SaveLoan(loan);
            await _repository.Save(aggregate.Entity);
        }
        else
        {
            result = aggregate.ResultMessages;
        }
        return result;
    }

}
    }


