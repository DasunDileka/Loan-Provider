﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dtos.Product
{
    public class UpdateProductDto
    {
        public string Image { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }
    }
}
