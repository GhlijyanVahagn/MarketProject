﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class Warehouse
    {
        public int Id { get; set; }
        public decimal TotalRemind { get; set; }
        public decimal RetailPrice { get; set; }
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }
 
 

    }
}