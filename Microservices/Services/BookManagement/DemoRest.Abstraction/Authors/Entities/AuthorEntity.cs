using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRest.Abstraction.Authors.Entities
{
  public  class AuthorEntity:IEntity
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public int BookId { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}
