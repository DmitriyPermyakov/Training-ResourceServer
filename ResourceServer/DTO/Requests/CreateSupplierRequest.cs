using System.ComponentModel.DataAnnotations;

namespace ResourceServer.DTO.Requests
{
    public class CreateSupplierRequest
    {
        [Required]
        public string SupplierName { get; set;}
        [Required]
        public string City { get; set;}
        [Required]
        public string Street { get; set;}
        [Required]
        public string Building { get; set;}
    }

    public class UpdateSupplierRequest : CreateSupplierRequest
    {
        public int Id { get; set;}
    }
}
