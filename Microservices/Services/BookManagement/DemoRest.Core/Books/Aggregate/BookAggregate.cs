using DemoRest.Abstraction.Books.Entities;
using DemoRest.Abstraction.Books.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRest.Core.Books.Aggregate
{
    public class BookAggregate: BaseAggregate<BookEntity>
    {
        public BookAggregate(BookEntity entity):base(entity)
        {

        }

        public void SaveBook(Book book)
        {
            SetEntity(book);
        }

        public void DeleteBook()
        {
            Entity.IsDeleted = true;
        }

        public void ValidateBook(Book book)
        {

        }

        private void SetEntity(Book book)
        {
            Entity.Id = book.Id;
            Entity.Title = book.Title;
            Entity.Descrition = book.Descrition;
            Entity.AuthorId = book.AuthorId;
            Entity.ISNB = book.ISNB;
        }
    }
}
