using DemoRest.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRest.Core.Books.Aggregate
{
    public class BaseAggregate<T> where T : IEntity
    {
        public T Entity;

        public List<string> ResultMessages { get; }

        public BaseAggregate(T entity)
        {
            this.Entity = entity;
            ResultMessages = new List<string>();
        }

        public void AddMessages(string msg)
        {
            this.ResultMessages.Add(msg);
        }
    }
}
