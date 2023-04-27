using Ciber.Context;
using Ciber.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Repository
{
    public class CRepository : IRepository
    {
        private readonly IDapperContext _context;
        public CRepository(IDapperContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Lấy danh mục
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var query = "SELECT * FROM category";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Category>(query);
                return companies.ToList();
            }
        }

        /// <summary>
        /// Lấy sản phẩm
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProduct()
        {
            var query = "SELECT * FROM product";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Product>(query);
                return companies.ToList();
            }
        }
        /// <summary>
        /// Thông tin khách hàng
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            var query = "SELECT * FROM customer";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Customer>(query);
                return companies.ToList();
            }
        }
        /// <summary>
        /// Lấy tất cả order
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<OrderDTO>> GetOrder()
        {
            var query = "SELECT o.OrderId,t.ProductName,ct.CategoryName,c.CustomerName,o.CreatedDate, o.Amount FROM `order` o " +
                "INNER JOIN customer c ON c.CustomerId = o.CustomerId " +
                "INNER JOIN product t ON t.ProductId = o.ProductId " +
                "INNER JOIN category ct ON ct.CategoryId = t.CategoryId";
            using (var connection = _context.CreateConnection())
            {
                var companies = await this.GetQueryAsync(connection,query);
                return companies;
            }
        }
        public virtual async Task<List<OrderDTO>> GetQueryAsync(IDbConnection conn, string query)
        {
            return (await conn.QueryAsync<OrderDTO>(query)).ToList();
        }
        /// <summary>
        /// Đặt hàng
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ServiceResult> OrderProduct(Order param)
        {
            ServiceResult result = new ServiceResult();
            if (await this.ValidateProduct(param))
            {
                var query = "INSERT INTO `order`(ProductId,CustomerId,Amount,CreatedDate ) VALUES (@ProductId,@CustomerId,@Amount,@CreatedDate)";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", param.ProductId, DbType.Int32);
                parameters.Add("CustomerId", param.CustomerId, DbType.Int32);
                parameters.Add("Amount", param.Amount, DbType.Int32);
                parameters.Add("CreatedDate", param.CreatedDate, DbType.DateTime);
                using (var connection = _context.CreateConnection())
                {
                    var resultRow = await connection.ExecuteAsync(query, parameters);
                    //Nếu số bản ghi được thực hiện lớn hơn 0 thì trả về true
                    if (resultRow > 0)
                    {
                        result = new ServiceResult()
                        {
                            Code = "1",
                            ErrorCode = 0,
                            Data = resultRow
                        };
                    }
                }
            }
            else
            {
                result = new ServiceResult()
                {
                    Code = "1",
                    ErrorCode = -1,
                    Message = "Amount could not exceed quantity remaining of product"
                };

                }
            return result;
        }
        /// <summary>
        /// Validate đơn đặt
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<bool> ValidateProduct(Order param)
        {
            var result = false;
            var query = "SELECT * FROM product p WHERE p.ProductId = @ProductId;";
            
            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QueryFirstAsync<Product>(query, new {param.ProductId});
                result = (param.Amount ?? 0) <= (product?.Quantity ?? 0);
            }
            return result;
        }
    }
}
