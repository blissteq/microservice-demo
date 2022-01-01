using DemoRest.Abstraction.Authors.Entities;
using DemoRest.Abstraction.Authors.Models;
using DemoRest.Abstraction.Authors.Repository;
using DemoRest.Abstraction.Authors.Services;
using DemoRest.Core.Authors.Aggregste;
using DemoRest.Core.Books.Aggregate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRest.Core.Authors.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> _logger;
        private readonly IAuthorRepository _repository;

        public AuthorService(ILogger<AuthorService> logger, IAuthorRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<List<string>> AddAuthor(Author author)
        {
            _logger.LogInformation("Initialising.....");
            var aggregate = new AuthorAggregate(new AuthorEntity());
            var result = new List<string>();
            aggregate.ValidateAuthor(author);
            if (aggregate.ResultMessages.Count < 1)
            {
                _logger.LogInformation("save book .....");
                aggregate.SaveAuthor(author);
                await _repository.Save(aggregate.Entity);
            }
            else
            {
                result = aggregate.ResultMessages;

            }
            return result;
        }

        public async Task<List<string>> DeleteAuthor(int id)
        {
            _logger.LogInformation("Loading person detials......");
            var entity = await _repository.GetOne(id);
            var result = new List<string>();

            if (entity == null)
            {
                result.Add("Author not found");
                return result;
            }

            var aggregate = new AuthorAggregate(entity);
            if (aggregate.ResultMessages.Count < 1)
            {
                //save person 
                _logger.LogInformation("Saving author details.....");
                aggregate.DeleteAuthor();
                await _repository.Save(aggregate.Entity);
            }
            else
            {
                result = aggregate.ResultMessages;
            }
            return result;
        }

        public async Task<Author> GetAuthor(int id)
        {
            var entity = await _repository.GetOne(id);
            var author = new Author(entity);
            return author;
        }

        public async Task<IEnumerable<Author>> GetAuthor()
        {
            var entities = await _repository.GetAll();
            var authors = new List<Author>();
            foreach (var entity in entities)
            {
                var book = new Author(entity);
                authors.Add(book);
            }
            return authors; ;
        }

        public async Task<List<string>> UpdateAuthor(Author author)
        {
            _logger.LogInformation("Loading author detials......");
            var entity = await _repository.GetOne(author.Id);
            var result = new List<string>();

            if (entity == null)
            {
                result.Add("author not found");
                return result;
            }

            var aggregate = new AuthorAggregate(entity);
            aggregate.ValidateAuthor(author);
            if (aggregate.ResultMessages.Count < 1)
            {
                //save person 
                _logger.LogInformation("Saving person details.....");
                aggregate.SaveAuthor(author);
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
