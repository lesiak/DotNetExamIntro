using System;
using EssentialTools.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialTools.Tests {
    [TestClass]
    public class UnitTest1 {

        private IDiscountHelper dicountHelper = new MinimumDiscountHelper();        

        [TestMethod]
        public void Discount_Above_100() {
            decimal total = 200;

            var discountedTotal = dicountHelper.ApplyDiscount(total);

            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100() {
            //arrange             

            // act
            decimal TenDollarDiscount = dicountHelper.ApplyDiscount(10);
            decimal HundredDollarDiscount = dicountHelper.ApplyDiscount(100);
            decimal FiftyDollarDiscount = dicountHelper.ApplyDiscount(50);

            // assert
            Assert.AreEqual(5, TenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, FiftyDollarDiscount, "$50 discount is wrong");
        }

        [TestMethod]
        public void Discount_Less_Than_10() {
            //arrange             
            // act
            decimal discount5 = dicountHelper.ApplyDiscount(5);
            decimal discount0 = dicountHelper.ApplyDiscount(0);

            // assert
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total() {
            //arrange             

            // act
            dicountHelper.ApplyDiscount(-1);
        }
    }
}
