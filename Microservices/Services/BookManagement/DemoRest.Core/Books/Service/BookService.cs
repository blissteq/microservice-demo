using DemoRest.Abstraction.Books.Entities;
using DemoRest.Abstraction.Books.Models;
using DemoRest.Abstraction.Books.Repository;
using DemoRest.Abstraction.Books.Services;
using DemoRest.Core.Books.Aggregate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRest.Core.Books.Service
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly IBookRepository _repository;

        public BookService(ILogger<BookService>logger,IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<List<string>> AddBook(Book book)
        {
            _logger.LogInformation("Initialising.....");
            var aggregate = new BookAggregate(new BookEntity());
            var result = new List<string>();
            aggregate.ValidateBook(book);
            if(aggregate.ResultMessages.Count < 1)
            {
                _logger.LogInformation("save book .....");
                aggregate.SaveBook(book);
                await _repository.Save(aggregate.Entity);
            }
            else
            {
                result = aggregate.ResultMessages;

            }
            return result;
        }

        public async Task<List<string>> DeleteBook(int id)
        {
            //load  record
            _logger.LogInformation("Loading person detials......");
            var entity = await _repository.GetOne(id);
            var result = new List<string>();

            if (entity == null)
            {
                result.Add("Person not found");
                return result;
            }

            var aggregate = new BookAggregate(entity);
            if (aggregate.ResultMessages.Count < 1)
            {
                //save person 
                _logger.LogInformation("Saving person details.....");
                aggregate.DeleteBook();
                await _repository.Save(aggregate.Entity);
            }
            else
            {
                result = aggregate.ResultMessages;
            }
            return result;
        }

        public async Task<Book> GetBook(int id)
        {
            var entity = await _repository.GetOne(id);
            var book = new Book(entity);
            return book;

        }

        public async Task<IEnumerable<Book>> GetBook()
        {
            var entities = await _repository.GetAll();
            var books = new List<Book>();
            foreach (var entity in entities)
            {
                var book = new Book(entity);
                books.Add(book);
            }
            return books;
        }


        public async Task<List<string>> UpdateBook(Book book)
        {
            _logger.LogInformation("Loading person detials......");
            var entity = await _repository.GetOne(book.Id);
            var result = new List<string>();

            if (entity == null)
            {
                result.Add("Person not found");
                return result;
            }

            var aggregate = new BookAggregate(entity);
            aggregate.ValidateBook(book);
            if (aggregate.ResultMessages.Count < 1)
            {
                //save person 
                _logger.LogInformation("Saving person details.....");
                aggregate.SaveBook(book);
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
