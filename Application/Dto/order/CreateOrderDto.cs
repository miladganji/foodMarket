using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.order
{
  public  class CreateOrderDto
    {
        public Domain.Food.Food Food { get;  set; }
        public int Qty { get;  set; }

    }
}
