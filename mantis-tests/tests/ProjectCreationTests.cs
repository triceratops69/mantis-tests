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
            ProjectData project = new ProjectData("project" + GenerateRandomString(3));
            app.Project.Create(project);
        }
    }
}