using System.Text.Json.Serialization;
using static StockPortfolio.Common.Helper;

namespace StockPortfolio.Model
{
    public class Stock
    {
        public string Symbol { get; set; }
        public int Shares { get; set; }
        public decimal Price { get; set; }
        public string? TrxType { get; set; } 
        public decimal? NewAllocatedPercentage { get; set; }
    }
}
