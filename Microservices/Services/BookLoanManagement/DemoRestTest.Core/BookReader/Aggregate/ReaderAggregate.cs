using DemoRestTest.Abstraction.BookReader.Entities;
using DemoRestTest.Abstraction.BookReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRestTest.Core.BookReader.Aggregate
{
    public class ReaderAggregate : BaseAggregate<ReaderEntity>
    {
        public ReaderAggregate(ReaderEntity entity) : base(entity)
        {

        }

        public void SaveReader(Reader reader)
        {
            SetEntity(reader);
        }

        public void DeleteReader()
        {
            Entity.IsDeleted = true;
        }

        public void ValidateReader(Reader reader)
        {

        }

        private void SetEntity(Reader reader)
        {
            Entity.Id = reader.ReaderId;
            Entity.LoanId = reader.LoanId; ;
            Entity.ReaderName = reader.ReaderName;
            Entity.ReaderAddress = reader.ReaderAddress;
           
        }
    }
}
