using Catharsium.Calendar.Core.Entities.Models.Comparers;
using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Core.Entities.Tests.Models.Comparers.EventEqualityComparerTests;

[TestClass]
public class GetHashCodeTests : TestFixture<EventEqualityComparer>
{
    [TestMethod]
    public void GetHashCode_ReturnsEventHashCode()
    {
        var eventData = new Event();
        var actual = this.Target.GetHashCode(eventData);
        Assert.AreEqual(eventData.GetHashCode(), actual.GetHashCode());
    }
}