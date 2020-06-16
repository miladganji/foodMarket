using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Values.Price
{
 public   class Price
    {
       
        
        public decimal val { get;private set; }
        public Price SetPrice(decimal value)
        {
            return new Price() {
                val=value
            };
        }
    }
}
