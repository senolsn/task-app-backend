
using System;
namespace Business.Dtos.Response.Product
{
    public class GetAllProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsActive { get; set; }
    }
}
