﻿namespace PizzaShop.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Pie> Pies {get; set;}

    }
}
