﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoponWebApp.Models
{
    public class CartVM
    {
        public int PId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get;  set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double TotalAmount { get; set; }

    }
}
