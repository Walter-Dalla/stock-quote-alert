﻿namespace stock_quote_alert.Configs
{
    public class SmtpSettings
    {
        public string Server { get; set; } = "";
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
