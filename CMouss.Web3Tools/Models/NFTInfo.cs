using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Web3Tools
{
    public class NFTInfo
    {
        public string URL { get; set; }
        public string MarketPlace { get; set; }
        public string ChainName { get; set; }
        public string ContractAddress { get; set; }
        public string TokenId { get; set; }


        public NFTInfo(string nftUrl)
        {
            URL = nftUrl;
            //OpenSea
            if (nftUrl.ToLower().Contains("opensea.io") && nftUrl.ToLower().Contains("assets"))
            {
                this.MarketPlace = "OpenSea";

                string[] temps = nftUrl.Substring(nftUrl.IndexOf("assets") + 7).Split(@"/");
                this.ChainName = temps[0];
                this.ContractAddress = temps[1];
                this.TokenId = temps[2];
            }
            else
            {
                throw new Exception("Not identified");
            }
        }

    }
}
