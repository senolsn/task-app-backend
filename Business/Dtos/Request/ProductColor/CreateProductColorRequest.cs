using System;

namespace Business.Dtos.Request.ProductColor
{
    public class CreateProductColorRequest
    {
        public Guid ProductId { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }
}
