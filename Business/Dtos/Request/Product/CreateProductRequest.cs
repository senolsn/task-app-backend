using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Request.ProductColor;

namespace Business.Dtos.Request.Product
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsActive { get; set; }
        public List<CreateProductColorRequest> ProductColors { get; set; } = new();

    }
}
