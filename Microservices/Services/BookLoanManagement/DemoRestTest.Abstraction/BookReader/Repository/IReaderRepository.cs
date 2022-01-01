using DemoRestTest.Abstraction.BookLoan.Entities;
using DemoRestTest.Abstraction.BookReader.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRestTest.Abstraction.BookReader.Repository
{
public    interface IReaderRepository:  IRepository<ReaderEntity, int>
    {
    }
}
