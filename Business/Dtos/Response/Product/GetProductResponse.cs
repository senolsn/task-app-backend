using System;
using System.Collections.Generic;

namespace Business.Dtos.Response.Product
{
    public class GetProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsActive { get; set; }

        public List<GetProductColorResponse> ProductColors { get; set; } = new();
    }

    public class GetProductColorResponse
    {
        public Guid Id { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }
}
