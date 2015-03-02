using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EStore.Domain.Abstract;
using EStore.Domain.Entities;
using EStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EStore.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_Contains_All_Products()
        {
            //Arrange - Create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            });

            //Arrange - Create a controller
            AdminController target = new AdminController(mock.Object);

            //Action
            Product[] result = ((IEnumerable<Product>)target.Index().ViewData.Model).ToArray();

            //Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("P1", result[0].Name);
            Assert.AreEqual("P2", result[1].Name);
            Assert.AreEqual("P3", result[2].Name);
        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            //Arrange - Create mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            });

            //Arrange - Create the controller
            AdminController target = new AdminController(mock.Object);

            //Act
            Product p1 = target.Edit(1).ViewData.Model as Product;
            Product p2 = target.Edit(2).ViewData.Model as Product;
            Product p3 = target.Edit(3).ViewData.Model as Product;

            //Assert
            Assert.AreEqual(1, p1.ProductID);
            Assert.AreEqual(2, p2.ProductID);
            Assert.AreEqual(3, p3.ProductID);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Product()
        {
            //Arrange - Create mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            });

            //Arrange - Create the controller
            AdminController target = new AdminController(mock.Object);

            //Act 
            Product result = target.Edit(4).ViewData.Model as Product;

            //Assert
            Assert.IsNull(result);
        }
    }
}
