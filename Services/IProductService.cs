using CsvStoreApi.Models;
namespace CsvStoreApi.Services
//<summary>This service is for mocking tests and allowing swapping the CSV file for a database later product related operations</summary>   
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAllAsync();
    }
}
