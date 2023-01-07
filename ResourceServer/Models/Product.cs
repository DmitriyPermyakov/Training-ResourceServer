namespace ResourceServer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
