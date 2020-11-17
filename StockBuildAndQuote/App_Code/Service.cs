using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

public class StockProfile
{
    public string currency { get; set; }
    public string description { get; set; }
    public string displaySymbol { get; set; }
    public string symbol { get; set; }
    public string type { get; set; }
}

public class StockQuote
{
    public double c { get; set; }
    public double h { get; set; }
    public double l { get; set; }
    public double o { get; set; }
    public double pc { get; set; }
    public int t { get; set; }
}

public class Service : IService
{
    public string stockBuild()
    {
        string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/StockPricePairs.txt");
        if (!File.Exists(destPath))
        {

            string html = string.Empty;
            string getStockProfilesURL = @"https://finnhub.io/api/v1/stock/symbol?exchange=US&token=bu4sdhv48v6sjdfq354g";

            List<StockProfile> stockProfiles;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getStockProfilesURL);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                List<StockProfile> myDeserializedClass = JsonConvert.DeserializeObject<List<StockProfile>>(reader.ReadToEnd());
                stockProfiles = myDeserializedClass.OrderBy(x => Guid.NewGuid()).ToList();
            }

            string data = string.Empty;

            foreach (StockProfile stockProfile in stockProfiles.GetRange(0, 50))
            {
                string getQuoteURL = @"https://finnhub.io/api/v1/quote?symbol=" + stockProfile.symbol + "&token=bu4sdhv48v6sjdfq354g";
                StockQuote stockQuote = null;

                request = (HttpWebRequest)WebRequest.Create(getQuoteURL);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    stockQuote = JsonConvert.DeserializeObject<StockQuote>(reader.ReadToEnd());
                }

                data += stockProfile.symbol + "," + stockQuote.o + "\n";
            }
            File.WriteAllText(destPath, data);
        }

        return destPath;
    }

    public string stockQuote(string stockSymbol, string stockQuotePairsFilePath)
    {
        if (File.Exists(stockQuotePairsFilePath))
        {
            // Reads file line by line 
            StreamReader Textfile = new StreamReader(stockQuotePairsFilePath);

            string line = Textfile.ReadLine();

            while (line != null)
            {
                string[] stockPair = line.Split(',');
                if (stockPair[0] == stockSymbol)
                {
                    Textfile.Close();
                    return stockPair[1];
                }
                else
                {
                    line = Textfile.ReadLine();
                }
            }

            Textfile.Close();

            return "The given stock symbol was not found.";
        }
        else
        {
            return "The stock symbol pair file was not found. Please generate a file.";
        }
    }
}
