using StockPortfolio.Model;

namespace StockPortfolio.Common
{
    public static class Helper
    {
        public enum TranactionType
        {
            None,
            Buy,
            Sell,
        }

        //target weight
        public static Dictionary<string, decimal> TargetPercentages = new Dictionary<string, decimal>
        {
            { "AAPL", 0.22M },
            { "THD", 0.38M },
            { "CYBR", 0.25M },
            { "ABB", 0.15M }
        };
        public static decimal CalculatePercentage(Stock stock, decimal totalValue)
        {
            return (stock.Price * stock.Shares) / totalValue;
        }

        public static decimal CalculateNewAllocatedPercentage(decimal currentValue, decimal targetValue)
        {
            if(currentValue < targetValue)
            {
                return (currentValue / targetValue) * 100;
            }
            else
            {
                return (targetValue / currentValue) * 100;
            }
        }

        public static List<Stock> SeedData()
        {

            var portfolio = new List<Stock>
            {
                new Stock { Symbol = "AAPL", Shares = 50, Price = 147.11M },
                new Stock { Symbol = "THD", Shares = 200, Price = 72.25M },
                new Stock { Symbol = "CYBR", Shares = 150, Price = 145.99M },
                new Stock { Symbol = "ABB", Shares = 900, Price = 33.13M }
            };

            return portfolio;

        }


    }
}
