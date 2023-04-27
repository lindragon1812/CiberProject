using NUnit.Framework;
using NSubstitute;
using Ciber.Repository;
using Ciber.Context;
using System.Data;
using Dapper;
using Ciber.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace CiberTest
{
    public class CRepositoryTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CRepository_GetOrder_ReturnAll()
        {
            //Arrange
            string query = "";
            List<OrderDTO> returnResult = new List<OrderDTO>();
            IDapperContext context = Substitute.For<IDapperContext>();
            IDbConnection connection = Substitute.For<IDbConnection>();

            context.CreateConnection().Returns(connection);
            //connection.QueryAsync<OderDTO>(query).Returns(returnResult);
            var repository = Substitute.ForPartsOf<CRepository>(context);
            repository.GetQueryAsync(connection, query).Returns(returnResult);

            var result = repository.GetOrder().GetAwaiter().GetResult();

            Assert.IsTrue(result.Count() == 0);






        }
    }
}