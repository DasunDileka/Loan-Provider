using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Product
    {//check id colume
        public Guid Id {get; set;}
        public string Image { get; set; }
       
        public string Name { get; set; }
    
        public string Description { get; set; }

        public float Price { get; set; }

    }
}
