using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class EnteredProduct
    {
        public EnteredProduct() { }
        public EnteredProduct(string productName, string unit, string quantity, 
            string priceNet, string invoiceId)
        {
            ProductName = productName;
            Unit = unit;
            Quantity = quantity;
            PriceNet = priceNet;
            InvoiceId = invoiceId;
        }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string PriceNet { get; set; }
        public string InvoiceId { get; set; }
    }
}
