using DemoRestTest.Abstraction;
using DemoRestTest.Abstraction.BookLoan.Entities;
using DemoRestTest.Abstraction.BookLoan.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestTest.Infrastructure.Mongo
{
    public class LoanRepository : ILoanRepository
    {
        private readonly MongoContext _context;
        public LoanRepository(IOptions<AppSettings> config)
        {
            _context = new MongoContext(config);
        }

        public async Task<IEnumerable<LoanEntity>> GetAll()
        {
            FilterDefinition<LoanEntity> filter = Builders<LoanEntity>.Filter.Ne(s => s.IsDeleted, true);
            List<LoanEntity> loan = await _context.Loans.Find(filter).ToListAsync();
            return loan;
        }

        public async Task<LoanEntity> GetOne(int id)
        {
            var filter = Builders<LoanEntity>.Filter.Eq("_id", id);
            var loan = (await _context.Loans.FindAsync(filter)).FirstOrDefault();
            return loan;
        }

        public async Task<int> Save(LoanEntity entity)
        {
            FilterDefinition<LoanEntity> filter = Builders<LoanEntity>.Filter.Eq("_id", entity.Id);
            var result = await _context.Loans.FindAsync(filter);

            if (result.Any())
            {
                await _context.Loans.ReplaceOneAsync(filter, entity);
            }
            else
            {
                await _context.Loans.InsertOneAsync(entity);
            }

            return entity.Id;
        }
    }
}
