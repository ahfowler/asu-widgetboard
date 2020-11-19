using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	List<string> GetForecast();
	[OperationContract]
	WeatherReport GetWeatherReport();
	[OperationContract]
	string TodayForecast(List<DailyForecast> todayReport);

	// TODO: Add your service operations here
}

[DataContract]
public class WeatherReport
{
	[DataMember]
	public double lat { get; set; }

	[DataMember]
	public double lon { get; set; }
	[DataMember]
	public string timezone { get; set; }
	[DataMember]
	public string timezone_offset { get; set; }
	
	[DataMember]
	public List<DailyForecast> daily { get; set; }
	
	
}

[DataContract]
public class DailyForecast
{
	[DataMember]
	public string dt { get; set; }
	[DataMember]
	public string sunrise { get; set; }
	[DataMember]
	public string sunset { get; set; }
	[DataMember]
	public TempInfo temp { get; set; }
	[DataMember]
	public FeelsLike feels { get; set; }
	[DataMember]
	public double pressure { get; set; }
	[DataMember]
	public double humidity { get; set; }
	[DataMember]
	public double dew_point { get; set; }
	[DataMember]
	public double speed { get; set; }
	[DataMember]
	public double deg { get; set; }
	[DataMember]
	public List<Weather> weather { get; set; }
	
	[DataMember]
	public double clouds { get; set; }
	[DataMember]
	public double pop { get; set; }
	[DataMember]
	public double uvi { get; set; }
}

[DataContract]
public class TempInfo
{
	[DataMember]
	public double day { get; set; }
	[DataMember]
	public double min { get; set; }
	[DataMember]
	public double max { get; set; }
	[DataMember]
	public double night { get; set; }
	[DataMember]
	public double eve { get; set; }
	[DataMember]
	public double morn { get; set; }
}

[DataContract]
public class FeelsLike
{
	[DataMember]
	public double day { get; set; }
	[DataMember]
	public double night { get; set; }
	[DataMember]
	public double even { get; set; }
	[DataMember]
	public double morn { get; set; }
}

[DataContract]
public class Weather
{
	[DataMember]
	public string id { get; set; }
	[DataMember]
	public string main { get; set; }
	[DataMember]
	public string description { get; set; }
	[DataMember]
	public string icon { get; set; }
}