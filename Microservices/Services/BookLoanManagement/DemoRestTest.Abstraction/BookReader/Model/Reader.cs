using DemoRestTest.Abstraction.BookReader.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRestTest.Abstraction.BookReader.Model
{
 public   class Reader
    {
        public Reader()
        {

        }
        public Reader(ReaderEntity entity)
        {
            this.ReaderId = ReaderId;
            this.ReaderName = ReaderName;
            this.ReaderAddress = ReaderAddress;
            this.LoanId = LoanId;
        }
        public int ReaderId { get; set; }

        public string ReaderName { get; set; }

        public string ReaderAddress { get; set; }

        public int LoanId { get; set; }
    }
}
