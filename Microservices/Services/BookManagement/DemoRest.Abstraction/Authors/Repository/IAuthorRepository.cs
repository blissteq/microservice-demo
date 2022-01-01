using DemoRest.Abstraction.Authors.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRest.Abstraction.Authors.Repository
{
  public  interface IAuthorRepository:IRepository<AuthorEntity,int>
    {
    }
}
