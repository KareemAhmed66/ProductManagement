﻿namespace CRUD.DTOS
{
    public class ProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public int CategoryId { get; set; } // Foreign Key

    }
}
