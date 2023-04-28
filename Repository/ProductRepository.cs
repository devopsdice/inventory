namespace InventoryService.Repository
{
    using Dapper;
    using InventoryService.Repository.Base;
    using InventoryService.Repository.Constants;
    using Model;
    using Order.Model;

    public class ProductRepository : IProductRepository
    {
        private readonly IDapperContext _context;

        public ProductRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            IEnumerable<Product> result;
            
            using (var connection = _context.CreateConnection())
            {
                result = await connection.QueryAsync<Product>(ProductRepositoryConstant.GetAll);
            }

            return result;
        }

        public async Task<int> UpdateQuantityAsync(OrderData orderData)
        {

            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", orderData.ProductID);
            parameters.Add("@OrderdQuantity", orderData.Quantity);

            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteScalarAsync<int>(ProductRepositoryConstant.Update, parameters);
            }

            return result;
        }

    }
}
