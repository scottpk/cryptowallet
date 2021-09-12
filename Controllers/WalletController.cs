using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace cryptowallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly ILogger<WalletController> _logger;
        private Dictionary<string, IWallet> wallets = new Dictionary<string, IWallet>();

        public WalletController(ILogger<WalletController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<IWallet> GetWallets()
        {
            return wallets.Select(_ => _.Value);
        }

        [HttpPut]
        public void AddOrUpdateWallet(IWallet wallet)
        {
            var id = Convert.ToBase64String(wallet.IdHash);
            wallets[id] = wallet;
        }
    }
}
