using DotNetProject.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace DotNetProject.DataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        private dotnetprojectdbContext dotnetprojectdbContext;
        public CurrencyController()
        {
            dotnetprojectdbContext = new dotnetprojectdbContext();
        }
        [HttpGet]
        public IActionResult Get()
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            XmlElement root = doc1.DocumentElement;

            Tarih_Date tarih_Date = new();

            XmlSerializer serializer = new XmlSerializer(typeof(Tarih_Date));

            using (XmlReader reader = new XmlNodeReader(doc1))
            {
                tarih_Date = (Tarih_Date)serializer.Deserialize(reader);
            }

            if (Convert.ToDateTime(tarih_Date.Tarih)<DateTime.Now.AddMonths(-2))
            {               
                return Unauthorized();
            }

            List<Exchangerate> exchangerates = new();

            foreach (var c in tarih_Date.Currency)
            {
                Exchangerate exchangerate = new Exchangerate
                {
                    BanknoteBuying = c.BanknoteBuying,
                    BanknoteSelling = c.BanknoteSelling,
                    CrossOrder = c.CrossOrder,
                    CrossRateOther = c.CrossRateOther,
                    CrossRateUsd = c.CrossRateUSD,
                    CurrencyCode = c.CurrencyCode,
                    CurrencyName = c.CurrencyName,
                    ForexBuying = c.ForexBuying,
                    ForexSelling = c.ForexSelling,
                    Isim = c.Isim,
                    Kod = c.Kod,
                    Tarih = Convert.ToDateTime(tarih_Date.Tarih),
                    Unit = c.Unit
                };

                exchangerates.Add(exchangerate);
            }

            dotnetprojectdbContext.AddRange(exchangerates);
            dotnetprojectdbContext.SaveChanges();

            return Ok();
        }


    }
}
