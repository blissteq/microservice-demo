using DemoRest.Abstraction;
using DemoRest.Abstraction.Books.Entities;
using DemoRest.Abstraction.Books.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRest.Infrastructure.Mongo
{
   public class BookRepository: IBookRepository
    {
        private readonly MongoContext _context;
        public BookRepository(IOptions<AppSettings>config)
        {
            _context = new MongoContext(config);
        }

        public async Task<IEnumerable<BookEntity>> GetAll()
        {
            FilterDefinition<BookEntity> filter = Builders<BookEntity>.Filter.Ne(s => s.IsDeleted, true);
            List<BookEntity> book = await _context.Book.Find(filter).ToListAsync();
            return book;
        }

        public async Task<BookEntity> GetOne(int id)
        {
            var filter = Builders<BookEntity>.Filter.Eq("_id", id);
            var book = (await _context.Book.FindAsync(filter)).FirstOrDefault();
            return book;
        }

        public async Task<int> Save(BookEntity entity)
        {
            FilterDefinition<BookEntity> filter = Builders<BookEntity>.Filter.Eq("_id", entity.Id);
            var result = await _context.Book.FindAsync(filter);

            if (result.Any())
            {
                await _context.Book.ReplaceOneAsync(filter, entity);
            }
            else
            {
                await _context.Book.InsertOneAsync(entity);
            }

            return entity.Id;
        }
    }
    
}
