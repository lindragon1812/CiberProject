using Ciber.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CiberTest
{
    internal static class CRepositoryTestHelper
    {
        internal static object[] Test = {

            new object[]
            {
                "1",
                new List<OrderDTO>(){ 
                        
                },
                ""
            }
        
        
        };
        internal static object[] TestHaveData = {

            new object[]
            {
                "1",
                new List<OrderDTO>(){
                    new OrderDTO()
                    {
                        Amount = 1,
                        CategoryName = "TestCategory",
                        CustomerName = "TestCustomer",  
                        OrderId = 1,    
                        ProductName = "TestProduct",   
                    }
                },
                "SELECT * FROM order"
            }


        };



    }
}
