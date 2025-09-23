using System;
using Business.Dtos.Request.ProductColor;
using System.Collections.Generic;

namespace Business.Dtos.Request.Product
{
    public class UpdateProductRequest 
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsActive { get; set; }
        public List<UpdateProductColorRequest> ProductColors { get; set; } = new List<UpdateProductColorRequest>();

    }
}
