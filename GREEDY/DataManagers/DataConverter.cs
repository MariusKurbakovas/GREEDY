﻿using System.Collections.Generic;
using GREEDY.Models;
using System;
using System.Text.RegularExpressions;

namespace GREEDY.DataManagers
{
    public class DataConverter : IDataConverter
    {
        private static ShopDistributor ShopDistributor => new ShopDistributor();
        private static ItemCategorization ItemCategorization => new ItemCategorization();

        public List<Item> ReceiptToItemList(Receipt receipt)
        {
            var shop = ShopDistributor.ReceiptDistributor(receipt);
            var receiptLinesToString = String.Join(Environment.NewLine, receipt.LinesOfText);
            List<Item> itemList = new List<Item>();

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            //TODO: change strings to dictionary
            //TODO: create extension method to pass only shop name and get itemList
            if (shop == "MAXIMA")
            {
                string pattern = @"\b(([A-Z]|#)(\d){8})(.+)\n(PVM\b)";
                receiptLinesToString = Regex.Replace(receiptLinesToString, @"\r", "");

                Match match = Regex.Match(receiptLinesToString, pattern, RegexOptions.Singleline);
                if (match.Success)
                {
                    var productList = match.Groups[4].Value;
                    productList = Regex.Replace(productList, @"\n", " ");
                    productList = Regex.Replace(productList, @"(\d+(,)\d\d).[A|E|B|F|N]{1}\b", "$1" + Environment.NewLine);

                    pattern = @"([A-Za-z]{2}[A-Za-z]+.+)(\d+(,)\d\d)\r\n";
                    MatchCollection matches = Regex.Matches(productList, pattern, RegexOptions.Multiline);
                    foreach (Match m in matches)
                    {
                        itemList.Add(new Item
                        {
                            Name = m.Groups[1].Value.Replace("\n", string.Empty),
                            Price = decimal.Parse(m.Groups[2].Value),
                            Category = ItemCategorization.CategorizeSingleItem(m.Groups[1].Value)
                        });
                    }
                    return itemList;
                }
                return itemList;
            }
            else if (shop == "IKI")
            {
                string pattern = @"\b(([A-Z]{2})(\d){9})(.+)(Prekiautojo\b|ID\b)";
                receiptLinesToString = Regex.Replace(receiptLinesToString, @"\r", "");

                Match match = Regex.Match(receiptLinesToString, pattern, RegexOptions.Singleline);
                if (match.Success)
                {
                    var productList = match.Groups[4].Value;
                    productList = Regex.Replace(productList, @"\n", " ");
                    productList = Regex.Replace(productList, @"›", ",");
                    productList = Regex.Replace(productList, @"(\d+(,)\d\d).[A|E|B|F|N]{1}\b", "$1" + Environment.NewLine);

                    pattern = @"([A-Za-z]{2}[A-Za-z]+.+)(\d+(,)\d\d)\r\n";
                    MatchCollection matches = Regex.Matches(productList, pattern, RegexOptions.Multiline);
                    foreach (Match m in matches)
                    {
                        itemList.Add(new Item
                        {
                            Name = m.Groups[1].Value.Replace("\n", string.Empty),
                            Price = decimal.Parse(m.Groups[2].Value),
                            Category = ItemCategorization.CategorizeSingleItem(m.Groups[1].Value)
                        });
                    }
                    return itemList;
                }
                return itemList;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}