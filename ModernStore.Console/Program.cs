using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using System;

namespace ModernStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = new Name("Ricardo", "Silva");
            var email = new Email("ricardocavalcantesilva@gmail.com");
            var document = new Document("12345678911");
            var user = new User("cavalsilva", "cavalsilva");
            var customer = new Customer(name, email, document, user);
            var mouse = new Product("Mouse", 299, "mouse.png", 25);
            var mousePad = new Product("Mouse", 99, "mousepad.png", 25);
            var teclado = new Product("Mouse", 599, "teclado.png", 25);

            Console.WriteLine($"Mouses: {mouse.QuantityOnHand}");
            Console.WriteLine($"Mouse Pads: {mouse.QuantityOnHand}");
            Console.WriteLine($"teclados: {mouse.QuantityOnHand}");

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));
            order.AddItem(new OrderItem(mousePad, 2));
            order.AddItem(new OrderItem(teclado, 2));

            Console.WriteLine($"Número do Pedido: {order.Number }");
            Console.WriteLine($"Data: {order.CreateDate :dd/MM/yyyy}");
            Console.WriteLine($"Desconto: {order.Discount} ");
            Console.WriteLine($"Taxa de Entrega: {order.DeliveryFree}");
            Console.WriteLine($"Sub Total: {order.SubTotal()}");
            Console.WriteLine($"Total: {order.Total()}");
            Console.WriteLine($"Cliente: {order.Customer.ToString()}");

            Console.WriteLine($"Mouses: {mouse.QuantityOnHand}");
            Console.WriteLine($"Mouse Pads: {mouse.QuantityOnHand}");
            Console.WriteLine($"teclados: {mouse.QuantityOnHand}");

            Console.ReadKey();
        }
    }
}
