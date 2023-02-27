using Microsoft.AspNetCore.Mvc;
using StockPortfolio.Common;
using StockPortfolio.Inferfaces;
using StockPortfolio.Model;

namespace StockPortfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private IPortfolio _IPortfolio;
        public MainController(IPortfolio iportfolio)
        {
            _IPortfolio = iportfolio;
        }

        [HttpGet("/api/portfolio")] //portfolio rebalance
        //public IActionResult RebalancePortfolio(List<Stock> stocks)
        public IActionResult RebalancePortfolio()
        {
            try
            {
                //get sample data
                var portfolio = Helper.SeedData();
                var rebalanced = _IPortfolio.GetRebalancePortfolio(portfolio);

                if (rebalanced != null && rebalanced.Count() > 0)
                {
                    return Ok(rebalanced);
                }
                else
                {
                    return BadRequest("Invalid portfolio");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }
    }
}
