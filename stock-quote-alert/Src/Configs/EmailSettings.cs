using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_alert.Src.Configs
{
    public class EmailSettings
    {
        public string EmailAddressSender { get; set; }
        public string EmailAddressRecipient { get; set; }
        public string Password { get; set; }
    }
}
