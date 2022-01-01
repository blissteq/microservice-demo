
using DemoRest.Abstraction.Books.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRest.Abstraction.Books.Services
{
   public interface IBookService
    {
        Task<List<string>> AddBook(Book book);

        Task<List<string>> UpdateBook(Book book);

       

        Task<List<string>> DeleteBook(int id);
        Task<Book> GetBook(int id);
        Task<IEnumerable<Book>> GetBook();

    }
}
