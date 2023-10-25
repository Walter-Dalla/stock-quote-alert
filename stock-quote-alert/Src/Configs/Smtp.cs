using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_alert.Src.Configs
{
    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
