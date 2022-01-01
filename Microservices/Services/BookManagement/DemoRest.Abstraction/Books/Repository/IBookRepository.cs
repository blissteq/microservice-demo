
using DemoRest.Abstraction.Books.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRest.Abstraction.Books.Repository
{
  public  interface IBookRepository:IRepository<BookEntity,int>
    {
    }
}
