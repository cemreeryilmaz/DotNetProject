using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetProject.Data
{
    public partial class Exchangerate
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public string Isim { get; set; }
        public string CurrencyName { get; set; }
        public string ForexBuying { get; set; }
        public string ForexSelling { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }
        public string CrossRateUsd { get; set; }
        public string CrossRateOther { get; set; }
        public string CrossOrder { get; set; }
        public string Kod { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime? Tarih { get; set; }
    }
}
