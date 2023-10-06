﻿namespace EBuy.API.DTO.Product
{
    public class UpdateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public int CategoryId { get; set; }
        public int BusinessId { get; set; }
    }
}
