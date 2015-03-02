//Name: IProductRepository.cs
//Author: Joshua Omundson
//Date: 10.13.2014
//Abstract: This is the repository for the Product object.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Domain.Entities;

namespace EStore.Domain.Abstract
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);
    }
}
