using DemoRestTest.Abstraction;
using DemoRestTest.Abstraction.BookReader.Entities;
using DemoRestTest.Abstraction.BookReader.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestTest.Infrastructure.Mongo
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly MongoContext _context;
        public ReaderRepository(IOptions<AppSettings> config)
        {
            _context = new MongoContext(config);
        }

        public async Task<IEnumerable<ReaderEntity>> GetAll()
        {
            FilterDefinition<ReaderEntity> filter = Builders<ReaderEntity>.Filter.Ne(s => s.IsDeleted, true);
            List<ReaderEntity> reader = await _context.Readers.Find(filter).ToListAsync();
            return reader;
        }

        public async Task<ReaderEntity> GetOne(int id)
        {
            var filter = Builders<ReaderEntity>.Filter.Eq("_id", id);
            var reader = (await _context.Readers.FindAsync(filter)).FirstOrDefault();
            return reader;
        }

        public async Task<int> Save(ReaderEntity entity)
        {
            FilterDefinition<ReaderEntity> filter = Builders<ReaderEntity>.Filter.Eq("_id", entity.Id);
            var result = await _context.Readers.FindAsync(filter);

            if (result.Any())
            {
                await _context.Readers.ReplaceOneAsync(filter, entity);
            }
            else
            {
                await _context.Readers.InsertOneAsync(entity);
            }

            return entity.Id;
        }
    }
}
