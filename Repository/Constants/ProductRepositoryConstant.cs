namespace InventoryService.Repository.Constants
{
    public static class ProductRepositoryConstant
    {
        public const string GetAll = @"select * from ""Product"";";
        public const string Update = @"UPDATE public.""Product"" SET ""AvailableQuantity""=(""AvailableQuantity""-@OrderdQuantity) WHERE ""ProductId""=@ProductId;";

    }
}
