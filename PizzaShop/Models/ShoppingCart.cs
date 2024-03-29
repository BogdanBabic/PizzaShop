﻿using Microsoft.EntityFrameworkCore;

namespace PizzaShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        public readonly ApplicationDbContext _context;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set;} = default!;

        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            //Dovlaci sesiju korisnika, svaki korisnik ima svoju sesiju
            //Sesija = 'storage' koji se se koristi dok god je sesija aktivna
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>() ?? throw new Exception("Error Initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pizza pizza)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Pizza.ID == pizza.ID && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId!,
                    Pizza = pizza,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }

        public int RemoveFromCart(Pizza pizza)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Pizza.ID == pizza.ID && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges(true);

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Pizza).ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Pizza.Price * c.Amount).Sum();

            return total;
        }

        public void ClearCart()
        {
            var cartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }
    }
}
