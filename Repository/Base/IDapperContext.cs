using System.Data;

namespace InventoryService.Repository.Base
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
