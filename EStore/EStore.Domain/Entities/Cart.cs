using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Domain.Entities
{
    public class Cart
    {
        //Represents a collection of all line items in the cart
        private List<CartLine> lineCollection = new List<CartLine>();

        //Returns all of the line items (the complete shopping cart)
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        //Adds a item or quanity to the shopping cart for a specific product
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //Removes the entire line item for the specific product
        public void RemoveLine (Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        //Returns the total value of the entire shopping cart
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        //Clears the entire shopping cart
        public void Clear()
        {
            lineCollection.Clear();
        }

    }

    //Represents a single product line item in the shopping cart.
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
