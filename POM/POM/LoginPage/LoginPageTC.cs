
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM
{
    [TestClass]
    public class LoginPageTC : ExecutionClass
    {
        LoginPage lP = new LoginPage();

        [TestMethod]
        
        public void ValidLogin()
        {
            

            lP.username = "admin0812";
            lP.password = "power123";

            lP.Login();
        }
        [TestMethod]
        [Owner("Muhammad Saad")]
        [Description("Login with Invalid Credentials")]
        public void InValidLogin()
        {
            lP.username = "admin081";
            lP.password = "power123";

            lP.Login();
        }
        [TestMethod]
        
        [Owner("Muhammad Saad")]
        [Description("Login without Entering Credentials")]
        public void EmptyLoginField()
        {
            lP.username = "";
            lP.password = "";

            lP.Login();
        }
    }
}
