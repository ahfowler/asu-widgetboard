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

    <script language="C#" runat="server">
        void logInFunction(Object sender, EventArgs e)
        {
            if (logInAuthenticate(loginUsername.Text,loginPassword.Text) != "")
            {
                FormsAuthentication.RedirectFromLoginPage(loginUsername.Text, rememberMeCheckBox.Checked);
                logInErrorMessage.Text = "";
            } else
            {
                logInErrorMessage.Text = "Invalid username or password.";
            }
        }

        string logInAuthenticate(string username, string password)
        {
            string userType = "";

            string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/Students.xml");

            if (System.IO.File.Exists(destPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(fs);
                System.Xml.XmlNode root = xd;
                System.Xml.XmlNodeList document = root.ChildNodes;
                System.Xml.XmlNodeList students = document[1].ChildNodes;
                foreach(System.Xml.XmlNode student in students)
                {
                    System.Xml.XmlNodeList credentials = student.ChildNodes;

                    if (credentials[0].InnerText == username && credentials[1].InnerText == password)
                    {
                        userType = "student";
                        break;
                    }
                }
                fs.Close();
            }

            destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/Administrators.xml");

            if (System.IO.File.Exists(destPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(fs);
                System.Xml.XmlNode root = xd;
                System.Xml.XmlNodeList document = root.ChildNodes;
                System.Xml.XmlNodeList students = document[1].ChildNodes;
                foreach(System.Xml.XmlNode student in students)
                {
                    System.Xml.XmlNodeList credentials = student.ChildNodes;

                    if (credentials[0].InnerText == username && credentials[1].InnerText == password)
                    {
                        userType = "admin";
                        break;
                    }
                }
                fs.Close();
            }

            return userType;
        }

        void fieldsValidation(Object sender, EventArgs e)
        {
            if (registerUsername.Text.Equals("") || registerConfirmPassword.Text.Equals("") || registerPassword.Text.Equals("") || accountTypeRadioButtons.SelectedItem==null)
            {
                registerErrorMessage.Text = "All fields required.";
                if (registerUsername.Text.Equals(""))
                {
                    registerUsername.BackColor= System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (registerPassword.Text.Equals(""))
                {
                    registerPassword.BackColor= System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (registerConfirmPassword.Text.Equals(""))
                {
                    registerConfirmPassword.BackColor= System.Drawing.Color.FromArgb(252, 199, 187);
                }
            }
            else
            {
                if (registerPassword.Text.Equals(registerConfirmPassword.Text))
                {
                    if (originalUserName(registerUsername.Text, accountTypeRadioButtons.SelectedValue))
                    {
                        string userType = accountTypeRadioButtons.SelectedValue;
                        addUser(registerUsername.Text, registerPassword.Text, userType);
                        FormsAuthentication.RedirectFromLoginPage(registerUsername.Text, rememberMeCheckBox.Checked);
                    }
                    else
                    {
                        registerErrorMessage.Text = "User already exists!";
                    }

                }
                else
                {
                    registerErrorMessage.Text = "Passwords must match.";
                }
            }

        }

        void addUser(string username, string password, string userType)
        {
            System.Diagnostics.Debug.WriteLine("INSIDE ADDUSER METHOD");
            string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/" + userType + "s.xml");

            if (System.IO.File.Exists(destPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(fs);

                System.Xml.XmlNode addUser = xd.CreateElement("element", userType, "");
                System.Xml.XmlNode userName = xd.CreateElement("Username");
                userName.InnerText = username;
                System.Xml.XmlNode passWord = xd.CreateElement("Password");
                passWord.InnerText = password;
                addUser.AppendChild(userName);
                addUser.AppendChild(passWord);
                System.Diagnostics.Debug.WriteLine("Add the new element to the document...");
                System.Xml.XmlElement root = xd.DocumentElement;
                root.AppendChild(addUser);
                System.Diagnostics.Debug.WriteLine("Display the modified XML document...");
                System.Diagnostics.Debug.WriteLine(xd.OuterXml);
                fs.Position = 0;
                xd.Save(fs);


                if (userType.Equals("Administrator"))
                {
                    destPath = HttpContext.Current.Server.MapPath(@"~/Staff/Web.config");
                    if (System.IO.File.Exists(destPath))
                    {
                        System.IO.FileStream fsA = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                        System.Xml.XmlDocument xdA = new System.Xml.XmlDocument();
                        xdA.Load(fsA);
                        System.Xml.XmlNodeList rootA = xdA.GetElementsByTagName("allow");
                        String prevList;
                        foreach (System.Xml.XmlNode node in rootA)
                        {
                            prevList = node.Attributes["users"].Value;
                            node.Attributes["users"].Value = prevList + "," + username;
                        }
                        //System.Diagnostics.Debug.WriteLine("Add the new element to the document...");
                        //System.Diagnostics.Debug.WriteLine("Display the modified XML document...");
                        //System.Diagnostics.Debug.WriteLine(xdA.OuterXml);
                        fsA.Position = 0;
                        xdA.Save(fsA);
                        fsA.Close();
                    }
                }
                fs.Close();

            }
        }
        Boolean originalUserName(string username, string file)
        {
            Boolean result = true;
            string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/"+file+"s.xml");

            if (System.IO.File.Exists(destPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(fs);
                System.Xml.XmlNode root = xd;
                System.Xml.XmlNodeList document = root.ChildNodes;
                System.Xml.XmlNodeList userList = document[1].ChildNodes;
                foreach(System.Xml.XmlNode user in userList)
                {
                    System.Xml.XmlNodeList credentials = user.ChildNodes;

                    if (credentials[0].InnerText == username)
                    {
                        result = false;
                        break;
                    }
                }
                fs.Close();
            }

            return result;
        }
    </script>
</asp:Content>