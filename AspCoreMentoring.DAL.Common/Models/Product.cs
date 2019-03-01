﻿using System;

namespace AspCoreMentoring.DAL.Common.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Category Category { get; set; }

        public Supplier Supplier { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public Int16 UnitsInStock { get; set; }

        public Int16 UnitsOnOrder { get; set; }

        public Int16 ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

    }
}