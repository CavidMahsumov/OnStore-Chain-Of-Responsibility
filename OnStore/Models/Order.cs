using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnStore.Models
{
  public  class Order
    {
        public string Name { get; set; }
        public decimal Price { get; set; }


        public string ImagePath { get; set; }

        public decimal Sum { get; set; }
    }
}
