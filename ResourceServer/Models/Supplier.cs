﻿namespace ResourceServer.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public Address? Address { get; set; }
        public List<Product>? Products { get; set; }
    }
}
