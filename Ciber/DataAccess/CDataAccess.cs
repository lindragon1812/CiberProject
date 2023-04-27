using Ciber.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Ciber.DataAccess
{
    public class CDataAccess : IDataAccess
    {
        public Task<IEnumerable<dynamic>> QueryAsync(IDbConnection cnn, string sql)
        {
            return null;
        }
    }
}
