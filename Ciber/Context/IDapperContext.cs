using System.Data;

namespace Ciber.Context
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
         
    }
}
