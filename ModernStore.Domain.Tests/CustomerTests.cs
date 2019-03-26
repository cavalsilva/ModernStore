using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User user = new User("cavalsilva", "ric456");
        private readonly Document document = new Document("12345678911");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            var name = new Name("", "Silva");
            var email = new Email("ricardocavalcantesilva@gmail.com");

            var customer = new Customer(name, email, document, user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            var name = new Name("Ricardo", "");
            var email = new Email("ricardocavalcantesilva@gmail.com");

            var customer = new Customer(name, email, document, user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailNameShouldReturnANotification()
        {
            var name = new Name("Ricardo", "Silva");
            var email = new Email("a");

            var customer = new Customer(name, email, document, user);
            Assert.IsFalse(customer.IsValid());
        }

    }
}
