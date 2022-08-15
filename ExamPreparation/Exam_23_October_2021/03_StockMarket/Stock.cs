using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
        }

        public decimal MarketCapitalization => this.PricePerShare * this.TotalNumberOfShares;

        public int TotalNumberOfShares { get; set; }

        public decimal PricePerShare { get; set; }

        public string Director { get; set; }

        public string CompanyName { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Company: {this.CompanyName}");
            sb.AppendLine($"Director: {this.Director}");
            sb.AppendLine($"Price per share: ${this.PricePerShare}");
            sb.AppendLine($"Market capitalization: ${this.MarketCapitalization}");

            return sb.ToString().TrimEnd();
        }
    }
}
