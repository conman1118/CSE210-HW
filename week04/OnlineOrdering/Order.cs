using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer, List<Product> products)
        {
            _customer = customer;
            _products = products;
        }

        /// <summary>
        /// Sum of each product’s total cost plus one‐time shipping.
        /// </summary>
        public decimal CalculateTotalCost()
        {
            decimal subtotal = _products.Sum(p => p.GetTotalCost());
            decimal shipping = _customer.IsInUSA() ? 5.00m : 35.00m;
            return subtotal + shipping;
        }

        /// <summary>
        /// Lines of "ProductName – ProductID"
        /// </summary>
        public string GetPackingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (var p in _products)
            {
                sb.AppendLine($"{p.Name} - {p.ProductId}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Customer name and full address
        /// </summary>
        public string GetShippingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Shipping Label:");
            sb.AppendLine(_customer.Name);
            sb.AppendLine(_customer.Address.ToString());
            return sb.ToString();
        }
    }
}
