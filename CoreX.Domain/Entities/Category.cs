﻿namespace CoreX.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; private set; }
        public ICollection<Product>? Products { get; private set; }

    }
}
