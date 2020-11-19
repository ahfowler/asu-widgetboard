using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.

	public class Service : IService
	{
		public List<string> GetNewsList()
		{
		string keywords = "\"ASU\"OR\"Arizona State University\"";
			NewsResults newsResults = new NewsResults();
		List<Articles> newsArticles = new List<Articles>();
			string html = string.Empty;
			string newsSearchURL = @"http://newsapi.org/v2/everything?q=" + keywords + "&language=en&apiKey=7beee265245e4e4db8b4b401534a8d11";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newsSearchURL);
			request.AutomaticDecompression = DecompressionMethods.GZip;

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				using (Stream stream = response.GetResponseStream())
				using (StreamReader reader = new StreamReader(stream))
            {
				html = reader.ReadToEnd();
            }
		NewsResults tempResults = new NewsResults();
		tempResults = JsonConvert.DeserializeObject<NewsResults>(html);
		List<string> newsReel = new List<string>();
			foreach(Articles article in tempResults.articles)
        {
			string newsReport;
			DateTime dt = Convert.ToDateTime(article.publishedAt);
			newsReport = @"<div><b>" + dt.DayOfWeek +" | "+dt.ToString("MMMM") +" " +dt.Day+", "+dt.Year + "</b><br/><h4>" + article.title + " </h4><img src='"+article.urlToImage+"'style='max-height:75px; max-width:100px;'><br/><p>" + article.description + "<a href='" + article.url + "'> Read More </a>" + "</p><hr/></div>";
			newsReel.Add(newsReport);
		}
			return newsReel;
		}

	}
