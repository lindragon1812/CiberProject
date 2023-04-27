using Ciber.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Ciber.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<IEnumerable<Product>> GetProduct();
        public Task<IEnumerable<Customer>> GetCustomer();

        public Task<IEnumerable<OrderDTO>> GetOrder();
        public Task<ServiceResult> OrderProduct(Order param);

        public Task<List<OrderDTO>> GetQueryAsync(IDbConnection conn, string query);
    }
}
