using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM
{
    public partial class LoginPage : BasePage
    {
        
        #region Properties
        public string username { get; set; }
        public string password { get; set; }
        #endregion
        public void Login()
        {
            if (username != null)
            {
                EnterText(txtUsername, username); 
            }
            if (password != null)
            {
                EnterText(txtPassword, password);
            }
            Click(btnLogin);
        }
    
    }
}
//EnterText(txtUsername, username);
//EnterText(txtPassword, password);
