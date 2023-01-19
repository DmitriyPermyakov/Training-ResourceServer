namespace ResourceServer.DTO.Responses
{
    public class SupplierResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SupplierAddress Address { get; set; }
    }

    public class SupplierAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
    }
}
