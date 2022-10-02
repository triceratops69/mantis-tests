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
    public class ManagementMenuHelper : HelperBase
    {
        private string baseURL;

        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void GoToProjectPage()
        {
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }
        public void GoToUserPage()
        {
            driver.FindElement(By.LinkText("Управление пользователями")).Click();
        }        
    }
}