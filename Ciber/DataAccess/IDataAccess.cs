using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Ciber.DataAccess
{
    public interface IDataAccess
    {
        // Task<IEnumerable<dynamic>> QueryAsync(IDbConnection connection, string query,
        //IDictionary<string, object> parameters, TimeSpan? timeout);
        public Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string sql);


    }
}
