using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	List<String> GetNewsList();
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class Articles
{
	[DataMember]
	public object source { get; set; }
	[DataMember]
	public string author { get; set; }
	[DataMember]
	public string title { get; set; }
	[DataMember]
	public string description { get; set; }
	[DataMember]
	public string url { get; set; }
	[DataMember]
	public string urlToImage { get; set; }
	[DataMember]
	public string publishedAt { get; set; }
	[DataMember]
	public string content { get; set; }
}

[DataContract]
public class NewsResults
{
	[DataMember]
	public string status { get; set; }
	[DataMember]
	public int totalResults { get; set; }
	[DataMember]
	public List<Articles> articles { get; set; }
}
