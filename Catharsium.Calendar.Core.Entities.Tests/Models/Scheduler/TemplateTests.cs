using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Core.Entities.Tests.Models.Scheduler
{
    [TestClass]
    public class TemplateTests : TestFixture<Template>
    {
        [TestMethod]
        public void ToString_ReturnsName()
        {
            this.Target.Name = "My name";
            var actual = this.Target.ToString();
            Assert.AreEqual(this.Target.Name, actual);
        }
    }
}