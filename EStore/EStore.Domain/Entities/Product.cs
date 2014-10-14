//Name: Product.cs
//Author: Joshua Omundson
//Date: 10.13.2014
//Abstract: This is a POCO for a Product.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string  Name { get; set; }
        public string  Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
