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
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            Mantis.ProjectData[] mprojects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            if (mprojects.Length < 1)
            {
                CreateNewProject(account, project);
            }
            issue.project.id = mprojects[0].id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        internal void CreateNewProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData mproject = new Mantis.ProjectData();
            mproject.name = project.Name;
            client.mc_project_add(account.Name, account.Password, mproject);
        }

        public void GetUserAccessible(AccountData account, List<ProjectData> listProjects)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] mprojects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            foreach(var p in mprojects)
            {
                listProjects.Add(new ProjectData(p.name));
            }
        }
    }
}