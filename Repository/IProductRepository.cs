namespace InventoryService.Repository
{
    using Model;
    using Order.Model;

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<int> UpdateQuantityAsync(OrderData orderData);
    }
}
