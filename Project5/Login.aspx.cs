using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecurityLibrary;

/*********************************************************************
 *                  PROJECT 5 CONTRIBUTION
 * Login.aspx - Azaria Fowler
 * User Control - Azaria Fowler
 * Log In Functionality - Azaria Fowler
 * 
 * Hashing Password - Kaitlyn Allen
 * Register User - Kaitlyn Allen
 *********************************************************************/
namespace Project5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){}

        //Log in functionality - Azaria Fowler
        protected void logInFunction(Object sender, EventArgs e)
        {
            if (logInAuthenticate(loginUsername.Text, loginPassword.Text) != "")
            {
                FormsAuthentication.RedirectFromLoginPage(loginUsername.Text, rememberMeCheckBox.Checked);
                logInErrorMessage.Text = "";
            }
            else
            {
                logInErrorMessage.Text = "Invalid username or password.";
            }
        }

        //Log in authentications - Azaria Fowler
        protected string logInAuthenticate(string username, string password)
        {
            string userType = "";
            string Hashedpass = hashPassword(password);
            string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/Students.xml");

            if (System.IO.File.Exists(destPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(fs);
                System.Xml.XmlNode root = xd;
                System.Xml.XmlNodeList document = root.ChildNodes;
                System.Xml.XmlNodeList students = document[1].ChildNodes;
                if (students == null)
                {
                    logInErrorMessage.Text = "Invalid username or password.";
                }
                else
                {
                    foreach (System.Xml.XmlNode student in students)
                    {
                        System.Xml.XmlNodeList credentials = student.ChildNodes;

                        if (credentials[0] == null)
                        {
                            break;
                        }
                        else if (credentials[0].InnerText == username && credentials[1].InnerText == Hashedpass)
                        {
                            userType = "student";
                            break;
                        }
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
                if (students == null)
                {
                    logInErrorMessage.Text = "Invalid username or password.";
                }
                else
                {
                    foreach (System.Xml.XmlNode student in students)
                {
                    System.Xml.XmlNodeList credentials = student.ChildNodes;

                        if (credentials[0] == null)
                        {
                            break;
                        }
                        else if (credentials[0].InnerText == username && credentials[1].InnerText == Hashedpass)
                    {
                        userType = "admin";
                        break;
                    }
                }
                    }
                fs.Close();
            }

            return userType;
        }

        //Register User forms validation - Kaitlyn Allen
        protected void fieldsValidation(Object sender, EventArgs e)
        {
            if (registerUsername.Text.Equals("") || registerConfirmPassword.Text.Equals("") || registerPassword.Text.Equals("") || accountTypeRadioButtons.SelectedItem == null)
            {
                registerErrorMessage.Text = "All fields required.";
                if (registerUsername.Text.Equals(""))
                {
                    registerUsername.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (registerPassword.Text.Equals(""))
                {
                    registerPassword.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (registerConfirmPassword.Text.Equals(""))
                {
                    registerConfirmPassword.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
            }
            else
            {
                if (registerPassword.Text.Equals(registerConfirmPassword.Text))
                {
                    if (originalUserName(registerUsername.Text, accountTypeRadioButtons.SelectedValue))
                    {
                        string userType = accountTypeRadioButtons.SelectedValue;
                        string pass = hashPassword(registerPassword.Text);
                        addUser(registerUsername.Text, pass, userType);
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

        //Hashing functionality - Kaitlyn Allen
        protected string hashPassword(string password)
        {
            string newPass ="";
            string salt = "KW?OEfw9";
            byte[] hashCode;
            UnicodeEncoding Uce = new UnicodeEncoding(); // UnicodeEncoding object
            byte[] BytesShort = Uce.GetBytes(password); // convert to byte array
            SHA1Managed SHhash = new SHA1Managed(); //Create a SHA1 object
            hashCode = SHhash.ComputeHash(BytesShort); // Hashing 
            foreach (byte b in hashCode)
            {
                newPass += b.ToString() ;
            }
            HashFunctions newHashAction = new HashFunctions();
            string endPass = newHashAction.HashAlg(newPass , salt);
            return endPass;
        }

        //Register Users - Kaitlyn Allen
        protected void addUser(string username, string password, string userType)
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

        //check for username originality - Kaitlyn Allen
        protected Boolean originalUserName(string username, string file)
        {
            Boolean result = true;
            string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/" + file + "s.xml");

            if (System.IO.File.Exists(destPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(fs);
                System.Xml.XmlNode root = xd;
                System.Xml.XmlNodeList document = root.ChildNodes;
                System.Xml.XmlNodeList userList = document[1].ChildNodes;
                if (userList == null)
                {
                    return result;
                }
                else
                {
                    foreach (System.Xml.XmlNode user in userList)
                    {
                        System.Xml.XmlNodeList credentials = user.ChildNodes;

                        if (credentials[0] == null)
                        {
                            break;
                        }
                        else if (credentials[0].InnerText == username)
                        {
                            result = false;
                            break;
                        }
                    }
                }
                fs.Close();
            }

            return result;
        }
    }
}