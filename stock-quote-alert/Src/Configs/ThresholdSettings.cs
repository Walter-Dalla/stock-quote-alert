using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_alert.Configs
{
    public class ThresholdSettings
    {
        public decimal MinThreshold { get; set; } = 0m;
        public decimal MaxThreshold { get; set; } = 0m;
        public string StockQuote { get; set; } = "";
    }
}
