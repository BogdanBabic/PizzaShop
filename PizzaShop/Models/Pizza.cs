﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Models
{
    public class Pizza
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl {  get; set; }
        public bool? IsPizzaOfTheWeek { get; set; }
        public Category Category { get; set; }

    }
}
