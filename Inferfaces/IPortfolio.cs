using StockPortfolio.Model;

namespace StockPortfolio.Inferfaces
{
    public interface IPortfolio
    {
        public IEnumerable<Stock> GetRebalancePortfolio(List<Stock> portfolio);

    }
}
