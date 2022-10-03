using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{

    [TestFixture]
    public class ProjectCreationTests : ProjectTestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            List<ProjectData> oldProjects = new List<ProjectData>();
            app.API.GetUserAccessible(account, oldProjects);

            string name = app.Project.UniqName("project", oldProjects);
            ProjectData project = new ProjectData(name);

            app.Project.Create(project);

            List<ProjectData> newProjects = new List<ProjectData>();
            app.API.GetUserAccessible(account, newProjects);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void TestRandomNameProjectCreation()
        {
            List<ProjectData> oldProjects = new List<ProjectData>();
            app.Project.GetProjectListFromUI(oldProjects);

            string name = app.Project.UniqName(app.Project.GenerateRandomName(), oldProjects);
            ProjectData project = new ProjectData(name);
            app.Project.Create(project); 
            
            List<ProjectData> newProjects = new List<ProjectData>();
            app.Project.GetProjectListFromUI(newProjects); 

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}