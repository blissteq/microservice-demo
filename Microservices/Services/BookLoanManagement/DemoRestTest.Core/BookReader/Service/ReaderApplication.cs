using DemoRestTest.Abstraction.BookReader.Entities;
using DemoRestTest.Abstraction.BookReader.Model;
using DemoRestTest.Abstraction.BookReader.Repository;
using DemoRestTest.Abstraction.BookReader.Service;
using DemoRestTest.Core.BookReader.Aggregate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestTest.Core.BookReader.Service
{
    public class ReaderApplication : IReaderApplication
    {
        private readonly ILogger<ReaderApplication> _logger;
        private readonly IReaderRepository _repository;

        public ReaderApplication(ILogger<ReaderApplication> logger, IReaderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<List<string>> AddReader(Reader reader)
        {
            _logger.LogInformation("Initialising.....");
            var aggregate = new ReaderAggregate(new ReaderEntity());
            var result = new List<string>();
            aggregate.ValidateReader(reader);
            if (aggregate.ResultMessages.Count < 1)
            {
                _logger.LogInformation("save .....");
                aggregate.SaveReader(reader);
                await _repository.Save(aggregate.Entity);
            }
            else
            {
                result = aggregate.ResultMessages;

            }
            return result;
        }

        public async Task<List<string>> DeleteReader(int id)
        {
            //load  record
            _logger.LogInformation("Loading  detials......");
            var entity = await _repository.GetOne(id);
            var result = new List<string>();

            if (entity == null)
            {
                result.Add("Reader not found");
                return result;
            }

            var aggregate = new ReaderAggregate(entity);
            if (aggregate.ResultMessages.Count < 1)
            {
                //save person 
                _logger.LogInformation("Saving person details.....");
                aggregate.DeleteReader();
                await _repository.Save(aggregate.Entity);
            }
            else
            {
                result = aggregate.ResultMessages;
            }
            return result;
        }

        public async Task<Reader> GetReader(int id)
        {
            var entity = await _repository.GetOne(id);
            var reader = new Reader(entity);
            return reader;

        }

        public async Task<IEnumerable<Reader>> GetReaders()
        {
            var entities = await _repository.GetAll();
            var readers = new List<Reader>();
            foreach (var entity in entities)
            {
                var reader= new Reader(entity);
                readers.Add(reader);
            }
            return readers;
        }


        public async Task<List<string>> UpdateReader(Reader reader)
        {
            _logger.LogInformation("Loading person detials......");
            var entity = await _repository.GetOne(reader.ReaderId);
            var result = new List<string>();

            if (entity == null)
            {
                result.Add("Person not found");
                return result;
            }

            var aggregate = new ReaderAggregate(entity);
            aggregate.ValidateReader(reader);
            if (aggregate.ResultMessages.Count < 1)
            {
                //save person 
                _logger.LogInformation("Saving person details.....");
                aggregate.SaveReader(reader);
                await _repository.Save(aggregate.Entity);
            }
            else
            {
                result = aggregate.ResultMessages;
            }
            return result;
        }
    }
}
