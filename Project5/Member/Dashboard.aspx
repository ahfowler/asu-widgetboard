<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Project5.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ASU WidgetBoard</h2>
    <p>This is the self-subscribed member page that contains the ASU WidgetBoard.</p>

    <div style="display: flex; justify-content: space-between;">
        <div ID="StocksSection" style="min-width: 30%; margin-right: 10px;">
            <h3>Stock Quotes</h3>
            <div style="max-height: 480px; overflow-y: scroll; margin-bottom: 20px; margin-top: 20px;">
                <asp:Table ID="Stocks" runat="server"
                    CellPadding="5" HorizontalAlign="Left" CellSpacing="5" Width="100%" GridLines="None">
                </asp:Table>
            </div>
        </div>

        <div ID="WeatherSection" style="min-width: 70%; margin-left: 10px;">
            <h3>Weather Forecast</h3>
            <!-- https://rapidapi.com/stefan.skliarov/api/AccuWeather?endpoint=apiendpoint_200c1560-f967-11e7-847f-a7b04b853fafgetDailyForecastByLocationKey
            <div style="display: flex; justify-content: space-around; margin-bottom: 20px; margin-top: 20px;">
                <div style="text-align: center;">
                    <img  ID="TodayImage" src="https://www.flaticon.com/svg/static/icons/svg/1163/1163661.svg" style="max-height: 150px;" />
                    <h5 id="TodayWeather">Partly Cloudy</h5>
                </div>
                <div style="text-align: center;">
                    <h4><b>MONDAY</b> | NOVEMBER 16TH, 2020</h4>
                    <p>Tempe, Arizona</p>
                    <hr />
                    <h3>45&#176</h3>
                    <h5>54&#176 / 89&#176</h5>
                </div>-->
            <asp:Label ID="todaysWeather" runat="server"></asp:Label>
            <div style="display: flex; justify-content: space-between; padding: 15px;">
                <asp:Label style="background-color: #f8f8f8; text-align: center; padding: 10px; border-radius: 5px;" ID="Weather1" runat="server"></asp:Label>
                <asp:Label style="background-color: #f8f8f8; text-align: center; padding: 10px; border-radius: 5px;" ID="Weather2" runat="server"></asp:Label>
                <asp:Label style="background-color: #f8f8f8; text-align: center; padding: 10px; border-radius: 5px;" ID="Weather3" runat="server"></asp:Label>
                <asp:Label style="background-color: #f8f8f8; text-align: center; padding: 10px; border-radius: 5px;" ID="Weather4" runat="server"></asp:Label>
                <asp:Label style="background-color: #f8f8f8; text-align: center; padding: 10px; border-radius: 5px;" ID="Weather5" runat="server"></asp:Label>
            </div>
        </div>
    </div>

    <div style="display: flex;justify-content: space-between;">
        <div ID="NewsSection" style="background-color: #f8f8f8; text-align: center; padding: 10px; border-radius: 5px;max-width:30%;">
            <h3>ASU News</h3>
            <div style="max-height: 375px; overflow-y: scroll; margin-bottom: 20px; margin-top: 20px;">
                <asp:Table ID="News" runat="server"
                    CellPadding="5" HorizontalAlign="Left" CellSpacing="5" Width="100%" GridLines="None">
                </asp:Table>
            </div>
        </div>
        <div style="background-color: #f8f8f8; text-align: center; padding: 10px; border-radius: 5px;min-width:35%;">
            <h3>Phoenix Suns' Schedule</h3>
            <div style="max-height: 375px; overflow-y: scroll; margin-bottom: 20px; margin-top: 20px;">
                <asp:Table ID="SunsSchedule" runat="server"
                    CellPadding="5" HorizontalAlign="Left" CellSpacing="5" Width="100%" GridLines="None">
                </asp:Table>
            </div>
            </div>

        <div ID="ScopeSection" style="background-color: #f8f8f8; text-align: center; padding: 10px; border-radius: 5px;max-width:30%;">
            <h3>Daily Horoscope</h3>
            <div style="text-align: center;min-height: 375px;">
                <asp:Image style="max-height: 100px;" ID="horoscopeImage" runat="server" ImageUrl="https://www.flaticon.com/svg/static/icons/svg/2647/2647369.svg" />
                <h5><asp:Label ID="horoscopeSign" runat="server" Text=""></asp:Label></h5>
                <hr />
                <asp:DropDownList ID="horoscopeDropDown" runat="server">
                    <asp:ListItem Value="Aries"></asp:ListItem>
                    <asp:ListItem Value="Taurus"></asp:ListItem>
                    <asp:ListItem Value="Gemini"></asp:ListItem>
                    <asp:ListItem Value="Cancer"></asp:ListItem>
                    <asp:ListItem Value="Leo"></asp:ListItem>
                    <asp:ListItem Value="Virgo"></asp:ListItem>
                    <asp:ListItem Value="Libra"></asp:ListItem>
                    <asp:ListItem Value="Scorpio"></asp:ListItem>
                    <asp:ListItem Value="Sagittarius"></asp:ListItem>
                    <asp:ListItem Value="Capricorn"></asp:ListItem>
                    <asp:ListItem Value="Aquarius"></asp:ListItem>
                    <asp:ListItem Value="Pisces"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button class="btn btn-default" ID="submitHoroscope" runat="server" Text="Submit" OnClick="submitHoroscope_Click" />
                <hr />
                <p>
                    <asp:Label ID="horoscopeReading" runat="server"></asp:Label>
                </p>
            </div>
        </div>
    </div>

</asp:Content>
