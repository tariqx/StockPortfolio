using StockPortfolio.Common;
using StockPortfolio.Inferfaces;
using StockPortfolio.Model;

namespace StockPortfolio.Services
{
    public class PortfolioService : IPortfolio
    {
        private readonly IHttpClientFactory _clientFactory;
        public PortfolioService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IEnumerable<Stock> GetRebalancePortfolio(List<Stock> portfolio)
        {
            try
            {
                var totalValue = portfolio.Sum(stock => stock.Price * stock.Shares);
                var stocks = new List<Stock>();
                foreach (var stock in portfolio)
                {
                    var targetPercentage = Helper.TargetPercentages[stock.Symbol];
                    var targetValue = totalValue * targetPercentage;
                    var currentValue = targetValue - (stock.Price * stock.Shares);
                    
                    if (currentValue > 0)
                    {
                        // Buy stock
                        int numSharesToBuy = (int)Math.Floor(currentValue / stock.Price);
                        stock.Shares += numSharesToBuy;

                        var newPercentage = Helper.CalculateNewAllocatedPercentage(currentValue, targetValue);
                        stock.NewAllocatedPercentage = decimal.Round(Math.Abs(newPercentage), 2, MidpointRounding.AwayFromZero);
                        stock.TrxType = Helper.TranactionType.Buy.ToString();
                        stocks.Add(stock);

                    }
                    else if (currentValue < 0)
                    {
                        // Sell stock
                        int numSharesToSell = (int)Math.Floor(Math.Abs(currentValue) / stock.Price);
                        stock.Shares -= numSharesToSell;

                        var newPercentage = Helper.CalculateNewAllocatedPercentage(Math.Abs(currentValue), targetValue);
                        stock.NewAllocatedPercentage = decimal.Round(Math.Abs(newPercentage), 2, MidpointRounding.AwayFromZero); 
                        stock.TrxType = Helper.TranactionType.Sell.ToString();
                        stocks.Add(stock);
                    }
                }
                return stocks;

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
