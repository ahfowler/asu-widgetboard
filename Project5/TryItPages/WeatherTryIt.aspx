<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WeatherTryIt.aspx.cs" Inherits="Project5.WeatherTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div>
            <h2>Weather Service Try It Page</h2>
        </div>
    <p>This serivce uses the api at <a href="https://openweathermap.org/api">Open Weather Map</a>. It returns a JSON file with a 16 day forecast with varying levels of information that can be filtered the developer. The service is currently set up to find the weather forecast for Tempe, Arizona based on the city's latitude and longitude coordinates.</p>
        </div>
    <div>
        <h3>API Specification Information:</h3>
        <b>Parameters:</b>
        <ul>
            <li><b>lat: </b>33.427204</li>
            <li><b>lon: </b>-111.939869</li>
            <li><b>units: </b>imperial</li>
            <li><b>exclude: </b>hourly, minutely, current, alerts</li>
            
        </ul>
        <h3>Weather Report</h3>
        <hr />
        <hr />
        <asp:Label ID="weatherResults" runat="server"></asp:Label>
    </div>

</asp:Content>
