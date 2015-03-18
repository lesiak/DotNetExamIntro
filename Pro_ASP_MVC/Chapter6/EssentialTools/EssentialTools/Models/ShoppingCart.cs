using System.Collections.Generic;

namespace EssentialTools.Models {
    public class ShoppingCart {
        private IValueCalculator calc;
        public IEnumerable<Product> Products { get; set; }

        public ShoppingCart(IValueCalculator calc) {
            this.calc = calc;
        }

        public decimal CalculateProductTotal() {
            return calc.ValueProducts(Products);
        }
    }
}