﻿using GREEDY.Models;
using System.Linq;

namespace GREEDY.DataManagers
{
    public class ShopDistributor
    {
        // TODO: need connection to DB or dictionary of all shops available
        public string ReceiptDistributor(Receipt receipt)
        {
            var shopTile = "";
            for (int i = 0; i < 4; i++)
            {
                shopTile += receipt.LinesOfText.ElementAt(i);
            }

            if (shopTile.ToUpper().Contains("MAXIMA"))
            {
                return "MAXIMA";
            }
            else if (shopTile.ToUpper().Contains("RIMI"))
            {
                return "RIMI";
            }
            else if (shopTile.ToUpper().Contains("PALINK"))
            {
                return "IKI";
            }
            else
            {
                return null;
            }
        }
    }
}
