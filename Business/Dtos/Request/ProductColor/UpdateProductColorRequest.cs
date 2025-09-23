using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Request.ProductColor
{
    public class UpdateProductColorRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }
}
