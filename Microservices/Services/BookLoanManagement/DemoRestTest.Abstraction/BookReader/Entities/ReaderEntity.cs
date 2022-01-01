using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRestTest.Abstraction.BookReader.Entities
{
   public  class ReaderEntity : IEntity
    {
        public bool IsDeleted { get; set ; }
        public int Id { get; set ; }
       public int ReaderId { get; set; }

        public string ReaderName { get; set; }

      public   string ReaderAddress { get; set; }

         public int LoanId { get; set; }
    }
}
