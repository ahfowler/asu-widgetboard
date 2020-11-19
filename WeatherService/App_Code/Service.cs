using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public List<string> GetForecast()
	{
		//NewsResults newsResults = new NewsResults();
		//List<Articles> newsArticles = new List<Articles>();
		string html = string.Empty;
		string getForecastURL = @"https://api.openweathermap.org/data/2.5/onecall?lat=33.427204&lon=-111.939869&units=imperial&exclude=hourly,current,minutely,alerts&appid=eb8028e9f70631d282168afca14700af";

		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getForecastURL);
		request.AutomaticDecompression = DecompressionMethods.GZip;

		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
		using (Stream stream = response.GetResponseStream())
		using (StreamReader reader = new StreamReader(stream))
		{
			html = reader.ReadToEnd();
		}

		//WeatherReport tempReport = new WeatherReport();
		var tempReport = JsonConvert.DeserializeObject<WeatherReport>(html);
		//var tempReport = JsonConvert.DeserializeObject <  >> (html);
		
		//dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp);
		//return dtDateTime;
		List<DailyForecast> daysResults = new List<DailyForecast>();
		List<string> weatherReport = new List<string>();
		foreach (DailyForecast day in tempReport.daily)
		{
			//string dt = DateTime.Parse(day.dt).ToString("yyyy-MM-dd");
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(Convert.ToDouble(day.dt));

			string dayReport =
				@"<div> <h5><b>" + dtDateTime.DayOfWeek +"</b></h5>"+
                    "<hr/>" +
					"<img src='http://openweathermap.org/img/wn/"+ day.weather[0].icon+ "@2x.png'/>"+
					"<p>"+day.weather[0].description+"<p>"+
                    "<h3>" + Convert.ToInt32(day.temp.day) +"&#176</h3>"+
                    "<h5>"+ Convert.ToInt32(day.temp.min) +"&#176 / "+ Convert.ToInt32(day.temp.max) + "&#176</h5>"+
                "</div>";

			weatherReport.Add(dayReport);

		}

		//tempReport = daysResults;
		WeatherReport finalReport = new WeatherReport();
		//finalReport.city_name = tempData.city_name;
		//finalReport.country = tempData.country;
		finalReport.daily = daysResults;
		return weatherReport;
		//return html;
	}

	public WeatherReport GetWeatherReport()
	{
		//NewsResults newsResults = new NewsResults();
		//List<Articles> newsArticles = new List<Articles>();
		string html = string.Empty;
		string getForecastURL = @"https://api.openweathermap.org/data/2.5/onecall?lat=33.427204&lon=-111.939869&units=imperial&exclude=hourly,current,minutely,alerts&appid=eb8028e9f70631d282168afca14700af";

		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getForecastURL);
		request.AutomaticDecompression = DecompressionMethods.GZip;

		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
		using (Stream stream = response.GetResponseStream())
		using (StreamReader reader = new StreamReader(stream))
		{
			html = reader.ReadToEnd();
		}

		//WeatherReport tempReport = new WeatherReport();
		var tempReport = JsonConvert.DeserializeObject<WeatherReport>(html);
		return tempReport;
		//return html;
	}
	public string TodayForecast(List<DailyForecast> todayReport)
	{
		DailyForecast todaysReport = new DailyForecast();
		todaysReport = todayReport[0];
		System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
		dtDateTime = dtDateTime.AddSeconds(Convert.ToDouble(todaysReport.dt));

		string dayReport =
				@"<div style='display: flex; justify-content: space-around; margin-bottom: 20px; margin-top: 20px; '>"+
				"<div style='text-align: center;'>"+
				"<img src='http://openweathermap.org/img/wn/"+ todaysReport.weather[0].icon+"@2x.png' style='max-height: 250px;'/>"+
				"<h5>"+ todaysReport.weather[0].description+" </h5>"+
				"</div>"+
				"<div style='text-align: center;'>"+
				"<h4><b> "+ dtDateTime.DayOfWeek +"</b> | "+DateTime.Now.ToString("MMMM").ToUpper() +" " + dtDateTime.Day +" </h4>"+
				"<p> Tempe, Arizona </p>"+
				"<hr/>"+
				"<h3>"+ Convert.ToInt32(todaysReport.temp.day) +" &#176</h3>"+
                "<h5>"+ Convert.ToInt32(todaysReport.temp.min) + " &#176 / "+ Convert.ToInt32(todaysReport.temp.max) + "&#176</h5>"+
                "</div>"+
				"</div>";

			//weatherReport.Add(dayReport);

		return dayReport;
		//return html;
	}

}
