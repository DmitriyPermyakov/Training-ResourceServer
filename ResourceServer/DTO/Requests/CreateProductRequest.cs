using System.ComponentModel.DataAnnotations;

namespace ResourceServer.DTO.Requests
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }

    public class UpdateProductRequest : CreateProductRequest
    {
        public int Id { get; set; }
    }
}
