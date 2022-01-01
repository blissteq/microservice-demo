using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRest.Abstraction.Books.Entities
{
  public  class BookEntity:IEntity
    {
        public string Title { get; set; }
        public string Descrition { get; set; }

        public string ISNB { get; set; }
        public Guid AuthorId { get; set; }
        public bool IsDeleted { get; set ; }
        public int Id { get; set ; }
    }
}
