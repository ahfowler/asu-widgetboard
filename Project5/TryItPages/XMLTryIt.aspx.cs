using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class XMLTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //memberView.Text = null;
            addError.Text = null;
            searchError.Text = null;
            string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/MemberTest.xml");

            if (System.IO.File.Exists(destPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(fs);
                System.Xml.XmlNode root = xd;
                System.Xml.XmlNodeList document = root.ChildNodes;
                System.Xml.XmlNodeList members = document[1].ChildNodes;
                foreach (System.Xml.XmlNode member in members)
                {
                    System.Xml.XmlNodeList credentials = member.ChildNodes;

                    //memberView.Text += credentials[0].InnerText + "\t \t  " + credentials[1].InnerText + "\n";
                    //ListBox1.Items.Add(new ListItem(credentials[0].InnerText, credentials[1].InnerText));
                }
                fs.Close();
            }

        }

        protected void ViewMembersXml(object sender, EventArgs e)
        {
            Response.Clear();
            //returnButton.Visible = true;
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/xml";
            Response.WriteFile(Server.MapPath("~/App_Data/MemberTest.xml"));
            Response.Flush();
            Response.End();
        }

        protected void searchUser(object sender, EventArgs e)
        {
            string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/MemberTest.xml");
            string username = searchUsername.Text;
            if (System.IO.File.Exists(destPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(fs);
                System.Xml.XmlNode root = xd;
                System.Xml.XmlNodeList document = root.ChildNodes;
                System.Xml.XmlNodeList members = document[1].ChildNodes;
                if (members == null)
                {
                    searchError.Text = "File is empty!";
                }
                else
                {
                    foreach (System.Xml.XmlNode member in members)
                    {
                        System.Xml.XmlNodeList credentials = member.ChildNodes;

                        if (credentials[0] == null)
                        {
                            break;
                        }
                        else if (credentials[0].InnerText == username)
                        {
                            searchError.Text = "User found!";
                            break;
                        }
                        searchError.Text = "User does not exist!";
                    }
                }
                fs.Close();
            }
        }

        protected void fieldsValidation(Object sender, EventArgs e)
        {
            if (addUsername.Text.Equals("") || confirmPassword.Text.Equals("") || addPassword.Text.Equals(""))
            {
                addError.Text = "All fields required.";
                if (addUsername.Text.Equals(""))
                {
                    addUsername.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (addPassword.Text.Equals(""))
                {
                    addPassword.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (confirmPassword.Text.Equals(""))
                {
                    confirmPassword.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
            }
            else
            {
                if (addPassword.Text.Equals(confirmPassword.Text))
                {
                    if (originalUserName(addUsername.Text))
                    {
                        addUser(addUsername.Text, addPassword.Text);
                        addError.Text = "User added!";
                        //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    else
                    {
                        addError.Text = "User already exists!";
                    }

                }
                else
                {
                    addError.Text = "Passwords must match.";
                }
            }

        }
        protected void addUser(string username, string password)
        {
            string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/MemberTest.xml");

            if (System.IO.File.Exists(destPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(destPath, System.IO.FileMode.Open);
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.Load(fs);

                System.Xml.XmlNode addUser = xd.CreateElement("element", "Member", "");
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
                fs.Close();

            }
        }
        protected Boolean originalUserName(string username)
        {
            Boolean result = true;
            string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/MemberTest.xml");

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