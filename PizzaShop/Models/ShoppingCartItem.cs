﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Models
{
    public class ShoppingCartItem
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId {  get; set; }
        public Pizza Pizza { get; set; }
    }
}

