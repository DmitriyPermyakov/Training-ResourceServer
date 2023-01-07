namespace ResourceServer.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Building { get; set; }
        public int SupplierId { get; set; }

    }
}
