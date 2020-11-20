<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockBuildQuoteTryIt.aspx.cs" Inherits="Project5.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-6">
            <h2>Stock Build</h2>
            <p>
                This service utilizes stock data from Finnhub and finds the open price of each stock symbol from the US stock market. It then creates and saves a file with 50 random symbol price pairs (symbol, open price) in a file. This service returns the file path to the saved file of symbol price pairs.</p>
            <p>
                <strong>Service URL</strong>:  <a>http://webstrar29.fulton.asu.edu/Page2/ASUWidgetBoard/Service.svc</a></p>
            <p>
                <strong>Input</strong>: None
            </p>
            <p>
                <strong>Output</strong>: a <samp>string</samp> representing the file name of the file with the symbol price pairs</p>
            <p>
                &nbsp;</p>
            <h3>
                Simulation</h3>
            <p>
        &nbsp;<asp:Button  class="btn btn-default" ID="Button1" runat="server" Text="Build Stock Price Pairs" />
            </p>
            <div>
                The symbol price pairs file is located at:
                <samp><asp:Label ID="Label1" runat="server" Text=""></asp:Label></samp>
            </div>
        </div>
        <div class="col-md-6">
            <h2>Stock Quote</h2>
            <p>
                This service reads a file of symbol price pairs and returns the stock price of the given stock symbol. The user can manually type a stock symbol or a select one from a list of valid stock symbols.</p>
            <p>
                <strong>Service URL</strong>:  <a>http://webstrar29.fulton.asu.edu/Page2/ASUWidgetBoard/Service.sv</a>c</p>
            <p>
                <strong>Input</strong>: 
                </p>
                <ul>
                <li><samp>string symbol</samp></li> 
                <li><samp>string stockQuotePairsFilePath</samp></li>
                    </ul>
            <p>
                <strong>Output</strong>: a <samp>string</samp> representing the open stock price of the symbol</p>
            <p>
                &nbsp;</p>
            <h3>
                Simulation</h3>
            <div class="col-sm-4">
                <p>
                    Enter a Stock Symbol:<asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
            </p>
            </div>
            <div class="col-sm-6">
                <p>
                    Select a Stock Symbol:<asp:DropDownList ID="DropDownList1" runat="server" Width="100%" size="6">
            </asp:DropDownList>
            </p>
            </div>

            <asp:Button class="btn btn-default" ID="Button2" runat="server"  Text="Find Stock Price" />
            <asp:Label class="text-success" ID="Label2" runat="server" Text=""></asp:Label>
    
        </div>
    </div>
</asp:Content>
