<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project5.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <% if (global_asax.signedIn)
        { %>
    <asp:Panel ID="unauthorizedPanel" runat="server">
        <div style="margin:25% 30% auto 30%;border: solid 1px #cccccc;border-radius:5px;padding:15px;text-align:center;">
                <h2>Unauthorized Access</h2>
                <hr />
                <h4>You do not have administration privilleges with this account. Please sign out and log in with an administrator account.</h4>
            </div>
     </asp:Panel>
    <% } else { %>
    <div style="display: flex; align-items: center;">
        <div style="width:50%;">
            <div style="margin:25% 10% auto 10%;border: solid 1px #cccccc;border-radius:5px;padding:10px;text-align:left;">
                <h2>Login</h2>
                <hr />
                <div style="padding-bottom: 10px;">
                    <table style="width:100%;">
                        <tr>
                            <td><b>Username: </b></td>
                            <td>
                                <asp:TextBox ID="loginUsername" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Password: </b></td>
                            <td>
                                <asp:TextBox ID="loginPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <br />
                <div style="text-align: center;">
                    <asp:Button CssClass="btn btn-default" OnClick="logInFunction" ID="logIn" runat="server" Text="Login" /><br />
                    <asp:CheckBox ID="rememberMeCheckBox" runat="server" Height="20px" Text=" Remember me?" /><br /><br />
                    <asp:Label ID="logInErrorMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
        <div style="width:50%;">
            <div style="margin:25% 10% auto 10%;border: solid 1px #cccccc;border-radius:5px;padding:10px;text-align:left;">
                <h2>Register</h2>
                <hr />
                <div style="padding-bottom: 10px;">
                    <table style="width:100%;">
                        <tr>
                            <td><b>Username: </b></td>
                            <td><asp:TextBox ID="registerUsername" runat="server" Width="100%" TextMode="SingleLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Password: </b></td>
                            <td><asp:TextBox ID="registerPassword" runat="server" TextMode="Password"  Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Confirm Password: </b></td>
                            <td><asp:TextBox ID="registerConfirmPassword" runat="server" TextMode="Password"  Width="100%"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <br />
                <h5>What type of account are you registering for?</h5>
                <asp:RadioButtonList ID="accountTypeRadioButtons" runat="server">
                    <asp:ListItem>Student</asp:ListItem>
                    <asp:ListItem>Administrator</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <div style="text-align:center;">
                <asp:Button CssClass="btn btn-default" OnClick="fieldsValidation" ID="registerButton" runat="server" Text="Register" /><br />
                <asp:Label ID="registerErrorMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>

            </div>
        </div>
    </div>
     <% } %>

    <style>
        td { 
            padding: 5px;
        }
    </style>
</asp:Content>