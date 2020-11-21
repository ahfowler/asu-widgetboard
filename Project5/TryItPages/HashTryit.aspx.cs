using SecurityLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class HashTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string hashPassword(string password)
        {
            string newPass = "";
            string salt = "KW?OEfw9";
            byte[] hashCode;
            UnicodeEncoding Uce = new UnicodeEncoding(); // UnicodeEncoding object
            byte[] BytesShort = Uce.GetBytes(password); // convert to byte array
            SHA1Managed SHhash = new SHA1Managed(); //Create a SHA1 object
            hashCode = SHhash.ComputeHash(BytesShort); // Hashing 
            foreach (byte b in hashCode)
            {
                newPass += b.ToString();
            }
            HashFunctions newHashAction = new HashFunctions();
            string endPass = newHashAction.HashAlg(newPass, salt);
            return endPass;
        }

        protected void hashText(object sender, EventArgs e)
        {
            if (hashInput == null)
            {
                errorMsg.Text = "No data entered.";
            }
            else
            {
                string output = hashPassword(hashInput.Text);
                userInput.Text = hashInput.Text;
                hashOutput.Text = output;
            }
        }
    }
}