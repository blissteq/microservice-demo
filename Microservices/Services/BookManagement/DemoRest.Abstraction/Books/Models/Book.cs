


using DemoRest.Abstraction.Books.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DemoRest.Abstraction.Books.Models
{
    [DataContract]
    public class Book
    {
        public Book()
        {

        }
        public Book(BookEntity entity)
        {
            this.Title = entity.Title;
            this.Descrition = entity.Descrition;
            this.ISNB = entity.ISNB;
            this.AuthorId = entity.AuthorId;
            this.Id = entity.Id;
        }
        [DataMember]
        public  string Title { get; set; }
        [DataMember]
        public string Descrition { get; set; }
        [DataMember]
        public string ISNB { get; set; }
        [DataMember]
        public Guid AuthorId { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int  LoanId { get; set; }
        [DataMember]
        public DateTime IssueDate { get; set; }


    }
}
