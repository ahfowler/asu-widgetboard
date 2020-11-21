<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HashTryit.aspx.cs" Inherits="Project5.HashTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div>
            <h2>Hashing Try It Page</h2>
            <p>This service uses student built Security Library and <samp>HashAlg(string password, string salt)</samp> to take inputted text, typically a password, and hash the text to provide a layer of security when storing passwords and user information. The hash algorithm utilizes a salt key to add an extra layer of security when hashing input.</p>
        </div>
    <h3>Input text to be hashed.</h3>
                 <table">
                        <tr>
                            <td><b>Input: </b></td>
                            <td><asp:TextBox ID="hashInput" runat="server" TextMode="SingleLine"></asp:TextBox></td>
                            <td><asp:Button ID="performHash" OnCLick="hashText" CssClass="btn btn-default" runat="server" Text="Hash Input" /></td>
                        </tr>
                 </table>
                <br />
                <div style="text-align:center;">
                <asp:Label ID="errorMsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    <hr />
                    <table">
                        <tr>
                            <td><b>User Input: </b></td>
                            <td><asp:Label ID="userInput" runat="server"></asp:Label></td>
                        </tr>
                        <br />
                        <tr>
                            <td><b>Hashed User Input: </b></td>
                            <td><asp:Label ID="hashOutput" runat="server"></asp:Label></td>
                        </tr>
                 </table>
                </div>
    </div>

</asp:Content>
