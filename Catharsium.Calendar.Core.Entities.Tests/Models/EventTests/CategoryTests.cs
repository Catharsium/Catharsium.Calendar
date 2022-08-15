using Catharsium.Clients.GoogleCalendar.Models;
using Catharsium.Clients.GoogleCalendar.Models.Enums;
using Catharsium.Util.Reflection.Attributes;
using Catharsium.Util.Reflection.Attributes.Extensions;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Core.Entities.Tests.Models.EventTests;

[TestClass]
public class CategoryTests : TestFixture<Event>
{
    [TestMethod]
    public void Category_ValidColorId_ReturnsCategory()
    {
        var expected = Category.PersonalOption;
        this.Target.ColorId = expected.GetAttribute<AliasAttribute>("PersonalOption").Aliases[0];
        var actual = this.Target.Category;
        Assert.AreEqual(Category.PersonalOption, actual);
    }


    [TestMethod]
    public void Category_NoValidColorId_ReturnsUnknown()
    {
        this.Target.ColorId = "-1";
        var actual = this.Target.Category;
        Assert.AreEqual(Category.Unknown, actual);
    }


    [TestMethod]
    public void Category_NullColorId_ReturnsUnknown()
    {
        this.Target.ColorId = null;
        var actual = this.Target.Category;
        Assert.AreEqual(Category.Unknown, actual);
    }
}