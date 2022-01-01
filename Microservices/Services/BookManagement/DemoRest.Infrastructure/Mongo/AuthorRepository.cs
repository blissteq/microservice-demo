using DemoRest.Abstraction;
using DemoRest.Abstraction.Authors.Entities;
using DemoRest.Abstraction.Authors.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRest.Infrastructure.Mongo
{
  public  class AuthorRepository:IAuthorRepository
    {
        private readonly MongoContext _context;
        public AuthorRepository(IOptions<AppSettings> config)
        {
            _context = new MongoContext(config);
        }

        public async Task<IEnumerable<AuthorEntity>> GetAll()
        {
            FilterDefinition<AuthorEntity> filter = Builders<AuthorEntity>.Filter.Ne(s => s.IsDeleted, true);
            List<AuthorEntity> author= await _context.Author.Find(filter).ToListAsync();
            return author;
        }

        public async Task<AuthorEntity> GetOne(int id)
        {
            var filter = Builders<AuthorEntity>.Filter.Eq("_id", id);
            var book = (await _context.Author.FindAsync(filter)).FirstOrDefault();
            return book;
        }

        public async Task<int> Save(AuthorEntity entity)
        {
            FilterDefinition<AuthorEntity> filter = Builders<AuthorEntity>.Filter.Eq("_id", entity.Id);
            var result = await _context.Author.FindAsync(filter);

            if (result.Any())
            {
                await _context.Author.ReplaceOneAsync(filter, entity);
            }
            else
            {
                await _context.Author.InsertOneAsync(entity);
            }

            return entity.Id;
        }
    }
}

