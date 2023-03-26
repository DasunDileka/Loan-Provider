using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dtos.Product
{
    public class ProductDto
    {
        public string Image { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }
    }
}
