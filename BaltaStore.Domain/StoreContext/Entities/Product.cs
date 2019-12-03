using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities {
  public class Product : Entity {
    public Product (string title, string description, string image,decimal price, decimal quantityOnHand) {
      this.Title = title;
      this.Description = description;
      this.Image = image;
      this.QualityOnHand = quantityOnHand;
      this.Price = price;
    }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Image { get; private set; }
    public decimal QualityOnHand { get; private set; }
    public decimal Price { get; private set; }

    public void DecreaseQuantity(decimal quantity) {
      QualityOnHand -= quantity;
    }
  }
}