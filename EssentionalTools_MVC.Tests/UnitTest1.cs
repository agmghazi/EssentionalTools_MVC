﻿using System;
using EssentionalTools_MVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentionalTools_MVC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            //Arrange
            IDiscountHelper target = getTestObject();
            decimal total = 100;

            //Act
            var discountedTotal = target.ApplyDiscount(total);

            //Assert
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()

        {
            //Arrange
            IDiscountHelper target = getTestObject();

            //Act
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyDollarDiscount = target.ApplyDiscount(50);

            //Asert
            Assert.AreEqual(5,TenDollarDiscount,"$10 discount is wrong");

            Assert.AreEqual(95, TenDollarDiscount, "$100 discount is wrong");

            Assert.AreEqual(45, TenDollarDiscount, "$50 discount is wrong");

        }

        [TestMethod]
        [ExpectedException(typeof( ArgumentOutOfRangeException))]  // this mean this method is exception (-1) Nagative
        public void Discount_Nagative_Toata()
        {
            //Arrang
            IDiscountHelper target = getTestObject();

            //Act
             target.ApplyDiscount(-1);

            //Asert
            
        }
    }
}
