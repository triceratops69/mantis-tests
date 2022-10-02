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
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        //Create project

        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Navigator.GoToManagePage();
            manager.Menu.GoToProjectPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }

        public ProjectManagementHelper InitProjectCreation()
        {
            driver.FindElement(By.CssSelector("button.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }
        internal string UniqName(string name, List<ProjectData> oldProjects)
        {
            for (int i = 0; i < oldProjects.Count; i++)
            {
                if (name == oldProjects[i].Name)
                {
                    name += GenerateRandomString(5);
                    i = 0;
                }
            }
            return name;
        }
        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            return this;
        }
        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }

        //Remove project

        public ProjectManagementHelper Remove()
        {
            manager.Navigator.GoToManagePage();
            manager.Menu.GoToProjectPage();
            SelectProject();
            RemoveProject();
            return this;
        }
        public ProjectManagementHelper SelectProject()
        {
            driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a")).Click();
            return this;
        }
        public ProjectManagementHelper RemoveProject()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }
    }
}