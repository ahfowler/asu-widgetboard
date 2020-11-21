<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsTryIt.aspx.cs" Inherits="Project5.NewsTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div>
            <h2>News Service Try It Page</h2>
            <p>This serivce uses the api at <a href="https://newsapi.org/">NewsApi.Org</a>. It returns a list of news articles based on search results for articles with key words: 'ASU' and 'Arizona State University'.</p>
        </div>
    <div>
        <h3>API Specification Information:</h3>
        <b>Parameters:</b>
        <ul>
            <li><b>q: </b> 'ASU'OR'Arizona State University'</li>
            <li><b>lan: </b> en (English)</li>
            <li>api Key (required)</li>
            
        </ul>
        <h3>News Results</h3>
        <hr />
        <hr />
        <asp:Label ID="newsResults" runat="server"></asp:Label>
    </div>


    </div>

</asp:Content>
