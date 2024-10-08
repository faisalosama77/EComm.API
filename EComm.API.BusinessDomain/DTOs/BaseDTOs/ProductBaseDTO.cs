﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs.BaseDTOs
{
    public abstract class ProductBaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public bool IsDeleted { get; set; }
        public string Status { get; set; }
    }
}
