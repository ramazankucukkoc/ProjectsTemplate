using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ProductBranch ProductBranch { get; set; }
        public int ProductBranchId { get; set; }
        public virtual Stock Stock { get; set; }
        public string? ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal RegularPrice { get; set; }// Normal fiyat
        public decimal? SalePrice { get; set; }//Satış Fiyatı
        public string SKU { get; set; }//Stok Kodu
        public int Rating { get; set; }//Değerlendirme
        public int DiscountRate { get; set; }//Indirim oranı
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<UserComment> UserComments { get; set; }
        public virtual ICollection<ProductComment> ProductComments { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }

    }
}
