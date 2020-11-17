using System.ServiceModel;

[ServiceContract]
public interface IService
{

	[OperationContract]
	string stockBuild();

	[OperationContract]
	string stockQuote(string stockSymbol, string stockQuotePairsFilePat);
}
