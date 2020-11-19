<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASU WidgetBoard</h1>
        <p class="lead">The ASU WidgetBoard simplifies and enhances the student experience by displaying a customizable and interactive collection of widgets on a dashboard. All of the widgets are related to Arizona State University news, events, facilities, academics, clubs, and other information useful for students. Each widget utilizes a web service.</p>
    </div>

    <div>
        <h2>Applications and Components</h2>
        <p>The following table includes a list of our components.</p>
        <table>
            <thead>
                <tr>
                    <th colspan="4" style="text-align: center;background-color:#f8f8f8"><h3>Application and Components Summary Table</h3></th>
                </tr>
                <tr>
                    <th colspan="4">The application is deployed at: <a href="http://webstrar29.fulton.asu/Default.aspx">http://webstrar29.fulton.asu/Default.aspx</a></th>
                </tr>
                <tr>
                    <th colspan="4">Percentage of Contribution: Azaria Fowler: 50% + Kaitlyn Allen: 50%</th>
                </tr>
                <tr>
                    <th>Provider Name</th>
                    <th>Page and component types (e.g. aspx, DLL, SVC, etc.)</th>
                    <th class="description">Component description: What does the component do? What are input/parameter and output/return value?</th>
                    <th>Actual resources and methods used to implement the component and where this component is used?</th>
                </tr>
            </thead>
            <tbody>
                <!-- Presentation Layer (GUI) -->
                <tr>
                    <td>Azaria Fowler</td>
                    <td>Default.aspx page</td>
                    <td>This is the public default page that contains the application and components summary table with links to all other pages.</td>
                    <td><u>Resources</u>: GUI design code and C# code behind GUI.
                        <br />
                        <u>Usage</u>: Default page for application.
                    </td>
                </tr>
                <tr>
                    <td>Azaria Fowler</td>
                    <td>Dashboard.aspx page</td>
                    <td>This is the self-subscribed member page that contains the ASU WidgetBoard.</td>
                    <td><u>Resources</u>: GUI design code, C# code behind GUI, and web services.<br />
                        <u>Usage</u>: Member page for application.
                    </td>
                </tr>
                <tr>
                    <td>Kaitlyn Allen</td>
                    <td>Settings.aspx page</td>
                    <td>This is the authorization-required administrator staff page that contains the configuration settings for the ASU WidgetBoard. For example, users with access to this page can configure the Horoscope.xml file for the Horoscope services called in Dashboard.aspx.</td>
                    <td><u>Resources</u>: GUI design code, C# code behind GUI, and file writing services.<br />
                        <u>Usage</u>: Staff page for application.
                    </td>
                </tr>
                <tr>
                    <td>-</td>
                    <td>Login.aspx page</td>
                    <td>This is the log in and register page that utilizes forms-based security for the user control.</td>
                    <td><u>Resources</u>: GUI design code, C# code behind GUI, and the decryption/encryption function from Decryption.dll file.<br />
                        <u>Usage</u>: Staff page for application.
                    </td>
                </tr>
                <!-- Local Component -->
                <tr>
                    <td>-</td>
                    <td>Global.asax file</td>
                    <td>This file contains a global event handler that displays a welcome message and initializes the navigation bar according to whether a user is signed in.</td>
                    <td><u>Resources</u>:  GUI design code and conditional C# code behind GUI.<br />
                        <u>Usage</u>: This is used in Default.aspx if a user is already signed in.
                    </td>
                </tr>
                <tr>
                    <td>Kaitlyn Allen</td>
                    <td>Encryption.dll file</td>
                    <td>
                        This file contains the functions for encoding and decoding usernames and passwords.
                        <br />
                        <b>encryptCredential()</b><br />
                        <u>Parameters</u>: <samp>string credential</samp><br />
                        <u>Return Type</u>:  <samp>string</samp> representing the encrypted credential
                        <br />
                        <b>decryptCredential()</b><br />
                        <u>Parameters</u>: <samp>string encryptedCredential</samp><br />
                        <u>Return Type</u>:  <samp>string</samp> representing the decrypted credential
                    </td>
                    <td><u>Resources</u>: C# class and methods for encryptCredential() and decryptCredential()<br />
                        <u>Usage</u>: This is used in the Login.aspx page for verifying user-inputted credentials.
                    </td>
                </tr>
                <!-- Data Management -->
                <tr>
                    <td>Kaitlyn Allen</td>
                    <td>User profile cookie</td>
                    <td>This cookie contains the currently logged in user's information (username and password).</td>
                    <td><u>Resources</u>: -<br />
                        <u>Usage</u>: -
                    </td>
                </tr>
                <tr>
                    <td>-</td>
                    <td>Zodiac sign session state</td>
                    <td>This is a temprary state that contains the previously selected zodiac sign within a session.</td>
                    <td><u>Resources</u>: -<br />
                        <u>Usage</u>: -
                    </td>
                </tr>
                <tr>
                    <td>Kaitlyn Allen</td>
                    <td>Students.xml file</td>
                    <td>This file contains all of the usernames and passwords of self-registered students that can use the ASU WidgetBoard.</td>
                    <td><u>Resources</u>: A plain text file written in XML language. <br />
                        <u>Usage</u>: This is linked to the Login.aspx page and the encrpytion/decryption function.
                    </td>
                </tr>
                <tr>
                    <td>Kaitlyn Allen</td>
                    <td>Admins.xml file</td>
                    <td>This file contains all of the usernames and passwords of pre-approved admins that can edit the contents of the ASU WidgetBoard.</td>
                    <td><u>Resources</u>: A plain text file written in XML language. <br />
                        <u>Usage</u>: This is linked to the Login.aspx page and the encrpytion/decryption function.
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div>
        <h2>Services</h2>
        <p>The following table includes a list of our services as well as links to their respective TryIt pages.</p>
        <table>
            <thead>
                <tr>
                    <th colspan="5" style="text-align: center;background-color:#f8f8f8"><h3>Service Directory</h3></th>
                </tr>
                <tr>
                    <th colspan="5">Percentage of Contribution: Azaria Fowler: 50% + Kaitlyn Allen: 50%</th>
                </tr>
                <tr>
                    <th>Provider Name</th>
                    <th>Operation Name</th>
                    <th>Parameters and Return Type</th>
                    <th class="description">Function Description</th>
                    <th>TryIt Page</th>
                </tr>
            </thead>
            <tbody>
                <!-- Web Services -->
                <tr>
                    <td>Azaria Fowler</td>
                    <td>Stock Build</td>
                    <td><u>Parameters</u>: N/A<br />
                        <u>Return Type</u>: the file path to the file with the symbol price pairs
                    </td>
                    <td>This service utilizes stock data from Finnhub and finds the open price of each stock symbol from the US stock market. It then creates and saves a file with 50 random symbol price pairs (symbol, open price) in a file. This service returns the file path to the saved file of symbol price pairs.</td>
                    <td><a class="btn btn-default" href="http://webstrar29.fulton.asu/Default.aspx">TryIt</a></td>
                </tr>
                <tr>
                    <td>Azaria Fowler</td>
                    <td>Stock Quote</td>
                    <td><u>Parameters</u>: <samp>string symbol</samp><br />
                        <u>Return Type</u>:  <samp>string</samp> representing the stock price of the symbol
                    </td>
                    <td>This service reads a file of symbol price pairs and returns the stock price of the given stock symbol. The user can manually type a stock symbol or a select one from a list of valid stock symbols.</td>
                    <td><a class="btn btn-default" href="http://webstrar29.fulton.asu/Default.aspx">TryIt</a></td>
                </tr>
                <tr>
                    <td>Azaria Fowler</td>
                    <td>Daily Horoscope Reading</td>
                    <td><u>Parameters</u>: <samp>string sign</samp><br />
                        <u>Return Type</u>:  <samp>string</samp> representing the current horoscope reading of the sign
                    </td>
                    <td>This service takes a sign (i.e. capricorn, leo, etc.) and returns their current horoscope readings.</td>
                    <td><a class="btn btn-default" href="http://webstrar29.fulton.asu/Default.aspx">TryIt</a></td>
                </tr>
                <tr>
                    <td>Azaria Fowler</td>
                    <td>Phoenix Suns' Schedule</td>
                    <td><u>Parameters</u>: N/A<br />
                        <u>Return Type</u>: <samp>List < string ></samp> representing a list of games involving the Phoenix Suns'
                    </td>
                    <td>This service returns a list of 25 most recent Phoenix Suns' games from 1960-2000.</td>
                    <td><a class="btn btn-default" href="http://webstrar29.fulton.asu/Default.aspx">TryIt</a></td>
                </tr>
                <tr>
                    <td>Kaitlyn Allen</td>
                    <td>News Focus</td>
                    <td><u>Parameters</u>: N/A<br />
                        <u>Return Type</u>: <samp> List < string ></samp> of news articles
                    </td>
                    <td>This service returns the latest news articles relating to Arizona State University with dates and links to the articles.</td>
                    <td><a class="btn btn-default" href="http://webstrar29.fulton.asu/Default.aspx">TryIt</a></td>
                </tr>
                <tr>
                    <td>Kaitlyn Allen</td>
                    <td>Weather Service</td>
                    <td><u>Parameters</u>: <samp> Integer zip code</samp><br />
                        <u>Return Type</u>: <samp>XML </samp> holding five day weather forecast
                    </td>
                    <td>This service returns the 5-day weather forecast for the area of the given zipcode.</td>
                    <td><a class="btn btn-default" href="http://webstrar29.fulton.asu/Default.aspx">TryIt</a></td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="row">
        <div class="col-md-6">
            <h2>ASU WidgetBoard</h2>
            <p>
                This is the self-subscribed member page that contains the ASU WidgetBoard.
            </p>
            <p>
                <a class="btn btn-default" href="Dashboard.aspx">Visit &raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>Configure Widgets</h2>
            <p>
                This is the authorization-required administrator staff page that contains the configuration settings for the ASU WidgetBoard.
            </p>
            <p>
                <a class="btn btn-default" href="Settings.aspx">Visit &raquo;</a>
            </p>
        </div>
    </div>

    <style>
        td { 
            border-bottom: 1px dotted #cccccc;
            padding: 10px;
        }

        th {
            padding: 10px;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .description {
            width: 35%;
        }
    </style>

</asp:Content>
