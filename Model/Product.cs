﻿namespace ProductandCategoryManagementAPI.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public Category Category { get; set; }
    }
}
