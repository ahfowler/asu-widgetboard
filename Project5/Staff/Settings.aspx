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
                <asp:Button CssClass="btn btn-default" OnClick="fieldValidation" ID="registerButton" runat="server" Text="Register" /><br />
                <asp:Label ID="registerErrorMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
        </div>
        <div style="min-width: 70%; margin-left: 10px;">
            <h2 style="text-align:center;">Dashboard Info</h2>
           <div style="width:100%;">
            <div style="max-width:100%;border: solid 1px #cccccc;border-radius:5px;padding:5px;text-align:left;">
                <hr />
                <div style="max-width:50%; padding:10px; ">
                    <h3 style="text-align:center">View Members</h3>
                    <div style="display:flex; justify-content:center">
                    <div style="padding:10px;">
                        <h4>Students</h4>
                        <asp:TextBox  ID="studentsView" runat="server" ReadOnly="True" AutoPostBack="False" TextMode="MultiLine" style="height:100px; max-height:100px; resize:none; padding:10px; box-shadow: 5px 5px 20px #ccc; border:none; "></asp:TextBox>
                     </div>
                    <div style="padding:10px;">
                        <h4>Administrators</h4>
                        <asp:TextBox ID="adminView" runat="server" ReadOnly="True" AutoPostBack="False" TextMode="MultiLine" style="height:100px; max-height:100px; resize:none; padding:10px; box-shadow: 5px 5px 20px #ccc; border:none;"></asp:TextBox>
                    </div>
                </div>
                 </div>
                
                </div>
               </div>
        </div>
    </div>
    <style>
        .scrollbar{
            width:10px;
            color: red;

        }
    </style>
</asp:Content>


