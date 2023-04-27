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
using Ciber.DataAccess;
using NSubstitute.ExceptionExtensions;
using System;


namespace CiberTest
{
    public class CRepositoryTest
    {
        
        protected IDapperContext context;
        protected IDataAccess dataAccess;
        protected IDbConnection connection;
        [SetUp]
        public void Setup()
        {
            context = Substitute.For<IDapperContext>();
            dataAccess = Substitute.For<IDataAccess>();
            connection = Substitute.For<IDbConnection>();
        }

        [Test]
        [TestCaseSource(typeof(CRepositoryTestHelper), nameof(CRepositoryTestHelper.Test))]
        public void CRepository_GetOrder_QueryEmpty(string testCase, List<OrderDTO> returnResult, string query)
        {
            //Arrange
            context.CreateConnection().Returns(connection);
            dataAccess.QueryAsync<OrderDTO>(connection, query).Returns(returnResult);
            var repository = Substitute.ForPartsOf<CRepository>(context, dataAccess);

            //Action
            var result = repository.GetOrder().GetAwaiter().GetResult();
            //Assert
            Assert.IsTrue(returnResult.Count() == 0);

        }
        [Test]
        [TestCaseSource(typeof(CRepositoryTestHelper), nameof(CRepositoryTestHelper.TestHaveData))]
        public void CRepository_GetOrder_QueryHaveData(string testCase, List<OrderDTO> returnResult, string query)
        {
            //Arrange
            context.CreateConnection().Returns(connection);
            dataAccess.QueryAsync<OrderDTO>(connection, query).Returns(returnResult);
            var repository = Substitute.ForPartsOf<CRepository>(context, dataAccess);

            //Action
            var result = repository.GetOrder().GetAwaiter().GetResult();
            //Assert
            Assert.IsInstanceOf(typeof(List<OrderDTO>),result);

        }

    }
}