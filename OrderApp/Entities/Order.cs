using OrderApp.Entities.Enums;
using System.Text;
using System.Globalization;

namespace OrderApp.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client? Client { get; set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client? client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double total = 0;
            foreach (OrderItem item in Items)
            {
                total += item.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine($"Order moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
            sb.AppendLine($"Order status: {Status.ToString()}");
            sb.AppendLine($"Client: {Client?.Name} ({Client?.BirthDate.ToString("dd/MM/yyyy")}) - {Client?.Email}");
            sb.AppendLine("Order items:");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine($"{item.Product.Name}, Quantity: {item.Quantity}, Subtotal: ${item.SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            }
            sb.AppendLine($"Total price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
            
            return sb.ToString();
        }
    }
}
