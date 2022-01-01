using DemoRestTest.Abstraction.BookReader.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestTest.Abstraction.BookReader.Service
{
  public  interface IReaderApplication
    {
        Task<List<string>> AddReader(Reader reader);

        Task<List<string>> UpdateReader(Reader reader);
        Task<List<string>> DeleteReader(int id);
        Task<Reader> GetReader(int id);
        Task<IEnumerable<Reader>> GetReaders();
    }
}
