using DemoRest.Abstraction.Authors.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRest.Abstraction.Authors.Services
{
  public  interface IAuthorService
    {
        Task<List<string>> AddAuthor(Author author);
          Task<List<string>> UpdateAuthor(Author author);

        Task<List<string>> DeleteAuthor(int id);
        Task<Author> GetAuthor(int id);
        Task<IEnumerable<Author>> GetAuthor();


    }
}
