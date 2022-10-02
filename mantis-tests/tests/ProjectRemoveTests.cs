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
            app.Project.Remove();
        }
    }
}