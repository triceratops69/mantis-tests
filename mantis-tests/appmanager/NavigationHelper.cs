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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/my_view_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/my_view_page.php");
        }
        public void GoToLoginPage()
        {
            if (driver.Url == baseURL + "/login_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
        }

        public void GoToManagePage()
        {
            if (driver.Url == baseURL + "/manage_overview_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_overview_page.php");
        }

        public void GoToprojectPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");
        }
    }
}