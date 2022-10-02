using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsloggedIn())
            {
                if (IsloggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }

        public void Logout()
        {
            if (IsloggedIn())
            {
                driver.FindElement(By.CssSelector("i.fa.fa-sign-out.ace-icon")).Click();
            }
        }
        public bool IsloggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }
        public bool IsloggedIn(AccountData account)
        {
            return IsloggedIn()
                && GetLoggedUserName() == account.Name;
        }

        public string GetLoggedUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;
        }
    }
}