using DemoRest.Abstraction.Authors.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DemoRest.Abstraction.Authors.Models
{
    [DataContract]
    public class Author
    {
        public Author()
        {

        }
        public Author(AuthorEntity entity)
        {
            this.Id = entity.Id;
            this.AuthorName = entity.AuthorName;
            this.BookId = entity.BookId;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]

        public int BookId { get; set; }
    }
}
