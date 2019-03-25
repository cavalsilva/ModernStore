using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User user = new User("cavalsilva", "ric456");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            var customer = new Customer("","Silva","ricardocavalcantesilva@gmail.com", user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            var customer = new Customer("Ricardo", "", "ricardocavalcantesilva@gmail.com", user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailNameShouldReturnANotification()
        {
            var customer = new Customer("Ricardo", "Silva", "a", user);
            Assert.IsFalse(customer.IsValid());
        }

    }
}
