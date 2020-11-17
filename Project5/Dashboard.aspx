<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Project5.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ASU WidgetBoard</h2>
    <p>This is the self-subscribed member page that contains the ASU WidgetBoard.</p>

    <div style="display: flex; justify-content: space-between;">
        <div style="min-width: 30%; margin-right: 10px;">
            <h3>Stock Quotes</h3>
            <div style="max-height: 375px; overflow-y: scroll; margin-bottom: 20px; margin-top: 20px;">
                <asp:Table ID="Stocks" runat="server"
                    CellPadding="5" HorizontalAlign="Left" CellSpacing="5" Width="100%" GridLines="None">
                </asp:Table>
            </div>
        </div>

        <div style="min-width: 70%; margin-left: 10px;">
            <h3>Weather Forecast</h3>
            <!-- https://rapidapi.com/stefan.skliarov/api/AccuWeather?endpoint=apiendpoint_200c1560-f967-11e7-847f-a7b04b853fafgetDailyForecastByLocationKey -->
            <div style="display: flex; justify-content: space-around; margin-bottom: 20px; margin-top: 20px;">
                <!-- Current Weather Image -->
                <div style="text-align: center;">
                    <img src="https://www.flaticon.com/svg/static/icons/svg/1163/1163661.svg" style="max-height: 150px;" />
                    <h5>Partly Cloudy</h5>
                </div>
                <!-- Current Temperature Details -->
                <div style="text-align: center;">
                    <h4><b>MONDAY</b> | NOVEMBER 16TH, 2020</h4>
                    <p>Tempe, Arizona</p>
                    <hr />
                    <h3>45&#176</h3>
                    <h5>54&#176 / 89&#176</h5>
                </div>
            </div>
            <div style="display: flex; justify-content: space-between; padding: 15px;">
                <div style="background-color: #cccccc; text-align: center; padding: 10px; border-radius: 5px;">
                    <h5><b>MONDAY</b></h5>
                    <hr />
                    <h3>45&#176</h3>
                    <h5>54&#176 / 89&#176</h5>
                </div>
                <div style="background-color: #cccccc; text-align: center; padding: 10px; border-radius: 5px;">
                    <h5><b>TUESDAY</b></h5>
                    <hr />
                    <h3>45&#176</h3>
                    <h5>54&#176 / 89&#176</h5>
                </div>
                <div style="background-color: #cccccc; text-align: center; padding: 10px; border-radius: 5px;">
                    <h5><b>WEDNESDAY</b></h5>
                    <hr />
                    <h3>45&#176</h3>
                    <h5>54&#176 / 89&#176</h5>
                </div>
                <div style="background-color: #cccccc; text-align: center; padding: 10px; border-radius: 5px;">
                    <h5><b>THURSDAY</b></h5>
                    <hr />
                    <h3>45&#176</h3>
                    <h5>54&#176 / 89&#176</h5>
                </div>
                <div style="background-color: #cccccc; text-align: center; padding: 10px; border-radius: 5px;">
                    <h5><b>FRIDAY</b></h5>
                    <hr />
                    <h3>45&#176</h3>
                    <h5>54&#176 / 89&#176</h5>
                </div>
                <div style="background-color: #cccccc; text-align: center; padding: 10px; border-radius: 5px;">
                    <h5><b>SATURDAY</b></h5>
                    <hr />
                    <h3>45&#176</h3>
                    <h5>54&#176 / 89&#176</h5>
                </div>
                <div style="background-color: #cccccc; text-align: center; padding: 10px; border-radius: 5px;">
                    <h5><b>SUNDAY</b></h5>
                    <hr />
                    <h3>45&#176</h3>
                    <h5>54&#176 / 89&#176</h5>
                </div>
            </div>
        </div>
    </div>

    <div style="display: flex;justify-content: space-between;">
        <div style="background-color: lightgray; text-align: center; padding: 10px; border-radius: 5px;max-width:30%;">
            <h3>ASU News</h3>
            <!-- https://rapidapi.com/webit/api/webit-news-search -->
            <div style="max-height: 375px; overflow-y: scroll; margin-bottom: 20px; margin-top: 20px;">
                <asp:Table ID="News" runat="server"
                    CellPadding="5" HorizontalAlign="Left" CellSpacing="5" Width="100%" GridLines="None">
                </asp:Table>
            </div>
        </div>
        <div style="background-color: lightgray; text-align: center; padding: 10px; border-radius: 5px;min-width:35%;">
            <h3>Phoenix Suns' Schedule</h3>
            <div style="max-height: 375px; overflow-y: scroll; margin-bottom: 20px; margin-top: 20px;">
                <asp:Table ID="SunsSchedule" runat="server"
                    CellPadding="5" HorizontalAlign="Left" CellSpacing="5" Width="100%" GridLines="None">
                </asp:Table>
            </div>
            </div>

        <div style="background-color: lightgray; text-align: center; padding: 10px; border-radius: 5px;max-width:30%;">
            <h3>Daily Horoscope</h3>
            <div style="text-align: center;">
                <img src="https://www.flaticon.com/svg/static/icons/svg/2647/2647369.svg" style="max-height: 100px;" />
                <h5>Capricorn</h5>
                <hr />
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="Aries"></asp:ListItem>
                    <asp:ListItem Value="Taurus"></asp:ListItem>
                </asp:DropDownList>
                <hr />
                <p>
                    A little romantic time with your special someone may be in order today, Capricorn. With the day-to-day chaos of working and living, it can be tough to get some quality time alone. If you don't make specific plans, it can be months before this happens. Take the situation in hand and make those plans. If you're single, consider making arrangements for a date or spending time with a friend, if possible.
                </p>
            </div>
        </div>
    </div>

</asp:Content>
