using ModernStore.Domain.Entities;
using System;

namespace ModernStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("cavalsilva", "cavalsilva");
            var customer = new Customer(
                "Ricardo",
                "Silva", 
                "ricardocavalcantesilva@gmail.com",
                user);

            if (!customer.IsValid())
            {
                foreach (var notification in customer.Notifications)
                {
                    Console.WriteLine(notification.Message);
                }
            }

            Console.WriteLine(customer.ToString());
            Console.ReadKey();
        }
    }
}
