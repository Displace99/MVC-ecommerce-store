//Name: NinjectDependencyResolver.cs
//Author: Joshua Omundson
//Date: 10.12.2014
//Abstract: This is our customer dependency resolver.  It was taken from the book Pro ASP.NET MVC 5 from Apress (with permission)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using EStore.Domain.Abstract;
using EStore.Domain.Entities;
using EStore.Domain.Concrete;

namespace EStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //Creates a mock object of the Product Repository to test until we get the database set up
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product {Name = "Football", Price = 25},
            //    new Product {Name = "Surfboard", Price = 179},
            //    new Product {Name = "Running shoes", Price = 95}
            //});

            //This binds and returns the mocked object whenever a request for an implementation of the IProductRepository is made.
            //kernel.Bind<IProductsRepository>().ToConstant(mock.Object);

            //This binds the IProductRepository to the EFProductRepository
            kernel.Bind<IProductsRepository>().To<EFProductRepository>();
        }
        
    }
}