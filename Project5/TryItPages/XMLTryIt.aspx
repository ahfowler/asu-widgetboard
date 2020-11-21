<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XMLTryIt.aspx.cs" Inherits="Project5.XMLTryIt" %>
<%@ Import Namespace="System.Xml.XPath" %>
<%@ Import Namespace="System.Xml" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div>
            <h2>XML Manipulation Try It Page</h2>
        </div>
        <div>
            <p>This functionality allows users to search for members of xml file by username or add a new member to XML file. Please note that in the test file here the passwords are not hashed for the sake of confirming correct password documentation.</p>
            <div class="col-md-6">
                <h3>Seach XML file</h3>
                <p>Type username to see if it exists within MemberTest.XML</p>
                 <table style="width:75%;">
                        <tr>
                            <td><b>Search Username: </b></td>
                            <td><asp:TextBox ID="searchUsername" runat="server" Width="75%" TextMode="SingleLine"></asp:TextBox></td>
                            <td><asp:Button ID="submitSearch" OnCLick="searchUser" CssClass="btn btn-default" runat="server" Text="Search" /></td>
                        </tr>
                 </table>
                <br />
                <div style="text-align:center;">
                <asp:Label ID="searchError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="col-md-6">
                <h3>Add Member to XML file</h3>
                <p>Create new member to add to MemberTest.XML</p>
                <table style="width:75%;">
                        <tr>
                            <td><b>Username: </b></td>
                            <td><asp:TextBox ID="addUsername" runat="server" Width="75%" TextMode="SingleLine"></asp:TextBox></td>
                        </tr>
                     <tr>
                            <td><b>Password: </b></td>
                            <td><asp:TextBox ID="addPassword" runat="server" Width="75%" TextMode="Password"></asp:TextBox></td>
                        </tr>
                     <tr>
                            <td><b>Confirm Password: </b></td>
                            <td><asp:TextBox ID="confirmPassword" runat="server" Width="75%" TextMode="Password"></asp:TextBox></td>
                        </tr>
                 </table>
                <br />
                <div style="text-align:center;">
                <asp:Button CssClass="btn btn-default" OnClick="fieldsValidation" ID="registerButton" runat="server" Text="Add User" /><br />
                <asp:Label ID="addError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div style="margin: auto;width: 50%;padding: 10px;">
       <h3 style="margin: auto;width: 50%;padding: 10px;">MemberTest.xml</h3>
        <hr/>
    <asp:Button class="btn btn-default" OnClick="ViewMembersXml" runat="server" Text="View MemberTest.XML"></asp:Button>
       
    </div>
</asp:Content>
