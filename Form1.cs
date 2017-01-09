using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;



namespace Office365UpdatingCSOM
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = "snagar@SPMMRA.onmicrosoft.com";
            string password = "Sunder101";
            SecureString securePassword = new SecureString();
            foreach (char ch in password.ToCharArray())
                securePassword.AppendChar(ch);
           
            SharePointOnlineCredentials crendentials = new SharePointOnlineCredentials(userName, securePassword);

      
           
                using (ClientContext ctx = new ClientContext("https://spmmra.sharepoint.com/sites/MyCompany/HR/"))
                {
                    ctx.Credentials = crendentials;
                    Web myWeb = ctx.Web;
                    ctx.Load(myWeb, wde => wde.Title);
                List lst = myWeb.Lists.GetByTitle("HRPolicyDocuments");
                ListItemCreationInformation itmCreastionInfo = new ListItemCreationInformation();
                ListItem newItem = lst.AddItem(itmCreastionInfo);
                newItem["Title"]= "My Title First and I am on the top of the moon";
                newItem.Update();
                ctx.ExecuteQuery();
                MessageBox.Show(myWeb.Title);

                }
            
           
            
           
         }
    }
}
