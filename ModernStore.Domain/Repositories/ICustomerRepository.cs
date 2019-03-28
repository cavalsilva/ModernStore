using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        void Save(Customer customer);
        void Update(Customer customer);
        bool DocumentExists(string document);
    }
}
