﻿namespace FayShop.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {

        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }

        public string CategoryId { get; set; }

    }
}
