using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{

    [TestFixture]
    public class ProjectRemoveTests : ProjectTestBase
    {
        [Test]
        public void TestProjectRemove()
        {
            List<ProjectData> oldProjects = new List<ProjectData>();
            app.API.GetUserAccessible(account, oldProjects);

            if (oldProjects.Count < 1)
            {
                ProjectData project = new ProjectData("removeme");
                app.API.CreateNewProject(account, project);
                oldProjects.Add(project);
            }

            app.Project.Remove();

            List<ProjectData> newProjects = new List<ProjectData>();
            app.API.GetUserAccessible(account, newProjects);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}