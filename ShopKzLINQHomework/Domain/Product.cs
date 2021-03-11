using System;

namespace ShopKzLINQHomework.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicityDate { get; set; } = DateTime.Now;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
