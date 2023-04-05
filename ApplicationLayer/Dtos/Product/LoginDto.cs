using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dtos.Product
{
    public class LoginDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
