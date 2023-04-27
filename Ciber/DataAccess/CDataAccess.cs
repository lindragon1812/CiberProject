using Ciber.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Ciber.DataAccess
{
    public class CDataAccess : IDataAccess
    {
        public async Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string sql)
        {
            return await connection.QueryAsync<T>(sql);
        }
    }
}
