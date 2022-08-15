using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic._Configuration.Settings;
using Catharsium.Calendar.Core.Logic.Presentation;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Logic.Tests.Presentation
{
    [TestClass]
    public class ConsoleColorFactoryTests : TestFixture<ConsoleColorFactory>
    {
        #region Fixture

        private static string CalendarKey => "My calendar key";
        private static string ColorId => "My color id";
        private static ConsoleColor Color => ConsoleColor.Blue;

        #endregion

        [TestMethod]
        public void GetById_ValidId_ReturnsColorFromConfiguration()
        {
            var configuration = new CalendarCoreLogicSettings {
                CalendarColors = new List<CalendarColor> {
                    new CalendarColor {
                        Id = ColorId,
                        ConsoleColor = Color.ToString()
                    }
                }
            };
            this.SetDependency(configuration);

            var actual = this.Target.GetById(CalendarKey, ColorId);
            Assert.AreEqual(Color, actual);
        }


        [TestMethod]
        public void GetById_InvalidColorId_ReturnsDefaultColor()
        {
            var configuration = new CalendarCoreLogicSettings {
                CalendarColors = new List<CalendarColor> {
                    new CalendarColor {
                        Id = ColorId + 1,
                        ConsoleColor = Color.ToString()
                    }
                }
            };
            this.SetDependency(configuration);

            var actual = this.Target.GetById(CalendarKey, ColorId);
            Assert.AreEqual(ConsoleColor.White, actual);
        }
    }
}