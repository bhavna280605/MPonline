// ============================================================
// Assignment 05: Shopping Application with Different Discount Types
//   - Prime loyalty discount
//   - Festival / seasonal discount
//   - Coupon code discount
//   - Demonstrates Strategy pattern + polymorphism
// ============================================================
using System;
using System.Collections.Generic;

namespace ShoppingDiscounts
{
    public abstract class Discount
    {
        public string Name { get; }
        protected Discount(string name) { Name = name; }
        public abstract decimal Apply(decimal amount);
    }

    // Prime loyalty: 10% off
    public class PrimeLoyaltyDiscount : Discount
    {
        public PrimeLoyaltyDiscount() : base("Prime Loyalty (10%)") { }
        public override decimal Apply(decimal amount) => amount * 0.90m;
    }

    // Festival seasonal: flat % off
    public class FestivalDiscount : Discount
    {
        private readonly decimal _percent;
        public FestivalDiscount(decimal percent) : base($"Festival ({percent}%)")
        { _percent = percent; }
        public override decimal Apply(decimal amount) =>
            amount * (1m - _percent / 100m);
    }

    // Coupon code: fixed amount off (e.g. Rs. 250 off)
    public class CouponDiscount : Discount
    {
        private readonly decimal _flatOff;
        public CouponDiscount(string code, decimal flatOff)
            : base($"Coupon '{code}' ({flatOff:C} off)")
        { _flatOff = flatOff; }
        public override decimal Apply(decimal amount) =>
            Math.Max(0, amount - _flatOff);
    }

    // No discount
    public class NoDiscount : Discount
    {
        public NoDiscount() : base("No Discount") { }
        public override decimal Apply(decimal amount) => amount;
    }

    public class ShoppingCart
    {
        private readonly List<(string item, decimal price)> _items = new();
        public decimal SubTotal { get; private set; }

        public void Add(string item, decimal price)
        {
            _items.Add((item, price));
            SubTotal += price;
        }

        public void Checkout(Discount discount)
        {
            Console.WriteLine("-------- BILL --------");
            foreach (var (item, price) in _items)
                Console.WriteLine($"  {item,-15} {price,10:C}");
            Console.WriteLine($"  {"Subtotal",-15} {SubTotal,10:C}");
            Console.WriteLine($"  Applied: {discount.Name}");
            decimal final = discount.Apply(SubTotal);
            Console.WriteLine($"  {"Final Payable",-15} {final,10:C}");
            Console.WriteLine($"  You saved: {SubTotal - final:C}\n");
        }
    }

    class Program
    {
        static void Main()
        {
            var cart = new ShoppingCart();
            cart.Add("Laptop",   55000m);
            cart.Add("Mouse",      500m);
            cart.Add("Keyboard",  1500m);
            cart.Add("Headset",   2000m);

            // Try different discounts
            cart.Checkout(new NoDiscount());
            cart.Checkout(new PrimeLoyaltyDiscount());
            cart.Checkout(new FestivalDiscount(15m));
            cart.Checkout(new CouponDiscount("SAVE250", 250m));

            // Composed: Prime + Festival combined (apply sequentially)
            Console.WriteLine("----- Composed discount (Prime + Festival 5%) -----");
            Discount composed = new ComposedDiscount(
                new PrimeLoyaltyDiscount(),
                new FestivalDiscount(5m));
            cart.Checkout(composed);
        }
    }

    // Helper: chain two discounts
    public class ComposedDiscount : Discount
    {
        private readonly Discount _first, _second;
        public ComposedDiscount(Discount first, Discount second)
            : base($"{first.Name} + {second.Name}")
        { _first = first; _second = second; }
        public override decimal Apply(decimal amount) =>
            _second.Apply(_first.Apply(amount));
    }
}
