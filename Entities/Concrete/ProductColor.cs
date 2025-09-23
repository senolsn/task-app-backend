using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class ProductColor : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }

        public Product Product { get; set; }
    }
}
