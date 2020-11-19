<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Project5.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Configure Settings</h2>
    <p>This page is only accessible by administrators.</p>

    <div style="display: flex; justify-content: space-between;">
        <div style="min-width: 30%; margin-right: 10px;">
            <h3>Add New Admin</h3>
              <div style="width:100%;">
            <div style="max-width:100%;border: solid 1px #cccccc;border-radius:5px;padding:10px;text-align:left;">
                <hr />
                <div style="padding-bottom: 10px;">
                    <table>
                        <tr>
                            <td><b>Username: </b></td>
                            <td><asp:TextBox ID="registerUsername" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Password: </b></td>
                            <td><asp:TextBox ID="registerPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Confirm Password: </b></td>
                            <td><asp:TextBox ID="registerConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <br />
                <div style="text-align:center;">
                <a class="btn btn-default">Register</a>
                </div>

            </div>
        </div>
        </div>

        <div style="min-width: 70%; margin-left: 10px;">
            <h3 style="text-align:center;">Configure Dashboard Settings</h3>
           <div style="width:100%;">
            <div style="max-width:100%;border: solid 1px #cccccc;border-radius:5px;padding:10px;text-align:left;">
                <hr />
                </div>
               </div>
        </div>
    </div>
</asp:Content>
