﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.EntityLayer.Concrete
{
    public class CargoOperation
    {
        public int CargoOperationId { get; set; }
        public string Barcode { get; set; }
        public DateTime OperationDate { get; set; }
        public string Description { get; set; }
    }
}
