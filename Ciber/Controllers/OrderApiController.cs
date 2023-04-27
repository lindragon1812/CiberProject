using Ciber.Models;
using Ciber.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ciber.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        
       
        private readonly IRepository _companyRepo;
        private readonly ILogger _logger;

        public OrderApiController(IRepository companyRepo, ILogger<OrderApiController> logger)
        {
            _logger = logger;
            _companyRepo = companyRepo;
        }
        /// <summary>
        /// Lấy danh sách danh mục
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var companies = await _companyRepo.GetCategories();
                
                return Ok(companies);

            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError(ex, "GetCategories");
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                var companies = await _companyRepo.GetProduct();
                return Ok(companies);
            }
            catch (Exception ex)
            {

                //log error
                _logger.LogError(ex, "GetProduct");
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                var companies = await _companyRepo.GetCustomer();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError(ex, "GetCustomer");
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Lấy tất cả order
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                var companies = await _companyRepo.GetOrder();


                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError(ex, "GetAllOrder");
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Thực hiện order
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("OrderProduct")]
        public async Task<IActionResult> OrderProduct([FromBody] Order param)
        {
            try
            {
                var companies = await _companyRepo.OrderProduct(param);
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError(ex, "OrderProduct");
                return StatusCode(500, ex.Message);
            }
        }




    }
}
