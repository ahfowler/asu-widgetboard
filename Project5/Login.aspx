<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project5.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display: flex; align-items: center;">
        <div style="width:50%;">
            <div style="margin:50% 10% auto 10%;border: solid 1px #cccccc;border-radius:5px;padding:10px;text-align:left;">
                <h2>Login</h2>
                <hr />
                <div style="padding-bottom: 10px;">
                    <table>
                        <tr>
                            <td><b>Username: </b></td>
                            <td>
                                <asp:TextBox ID="loginUsername" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Password: </b></td>
                            <td>
                                <asp:TextBox ID="loginPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="logInErrorMessage" runat="server" Text="" CssClass="warning"></asp:Label>
                </div>
                <br />
                <div style="display: flex; align-items: center;justify-content:space-evenly;">
                    <asp:Button CssClass="btn btn-default" OnClick="logInFunction" ID="logIn" runat="server" Text="Login" />
                    <asp:CheckBox ID="rememberMeCheckBox" runat="server" Height="12px" Text="Remember me?" />
                </div>
            </div>
        </div>
        <div style="width:50%;">
            <div style="margin:50% 10% auto 10%;border: solid 1px #cccccc;border-radius:5px;padding:10px;text-align:left;">
                <h2>Register</h2>
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
                <h5>What type of account are you registering for?</h5>
                <asp:RadioButtonList ID="accountTypeRadioButtons" runat="server">
                    <asp:ListItem>Student</asp:ListItem>
                    <asp:ListItem>Staff</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <div style="text-align:center;">
                <a class="btn btn-default">Register</a>
                </div>

            </div>
        </div>
    </div>

    <style>
        td { 
            padding: 5px;
        }
    </style>

    <script language="C#" runat="server">
        void logInFunction(Object sender, EventArgs e)
        {
            if (logInAuthenticate(loginUsername.Text,loginPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(loginUsername.Text, rememberMeCheckBox.Checked);
            } else
            {
                logInErrorMessage.Text = "Invalid username or password.";
            }
        }

        bool logInAuthenticate(string username, string password)
        {
            bool exists = false;

            if (username == "Azaria")
            {
                exists = true;
            } else
            {
                exists = false;
            }

            return exists;
        }
    </script>
</asp:Content>
