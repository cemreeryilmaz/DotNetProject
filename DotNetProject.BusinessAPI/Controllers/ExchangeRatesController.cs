using DotNetProject.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DotNetProject.BusinessAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRatesController : Controller
    {
        private dotnetprojectdbContext dotnetprojectdbContext;
        public ExchangeRatesController()
        {
            dotnetprojectdbContext = new dotnetprojectdbContext();
        }
        [HttpGet]
        public dynamic Get(string code)
        {
            var exchangerates = dotnetprojectdbContext.Exchangerates.Where(x => x.Kod == code).Select(x => new{ Date = x.Tarih,Value = x.BanknoteBuying }).ToList();

            return exchangerates;
        }
    }
}
