using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Context;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Customer Get(Guid id)
        {
            return _context
                .Customers
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public GetCustomerCommandResult Get(string username)
        {
            //return _context
            //    .Customers
            //    .Include(x => x.User)
            //    .AsNoTracking()
            //    .Select(x => new GetCustomerCommandResult
            //    {
            //        Name = x.Name.FirstName,
            //        Document = x.Document.Number,
            //        Active = x.User.Active,
            //        Email = x.Email.Address,
            //        Username = x.User.Username,
            //        Password = x.User.Password
            //    }).FirstOrDefault(x => x.Username == username);

            // Utilizando Dapper
            var query = "SELECT * FROM [GetCustomerLoginInfoView] WHERE [Active] = 1 AND [Username]=@username";
            using (var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ModernStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                return conn
                    .Query<GetCustomerCommandResult>(query, 
                    new { username = username })
                    .FirstOrDefault();
            }
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public bool DocumentExists(string document)
        {
            return _context
                .Customers
                .Any(x => x.Document.Number == document);
        }
    }
}
