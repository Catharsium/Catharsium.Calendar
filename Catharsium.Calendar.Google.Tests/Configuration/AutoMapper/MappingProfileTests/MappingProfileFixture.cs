using AutoMapper;
using Catharsium.Calendar.Google.Configuration.AutoMapper;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Google.Tests.Configuration.AutoMapper.MappingProfileTests
{
    public abstract class MappingProfileFixture: TestFixture<MappingProfile>
    {
        #region Fixture

        protected IMapper Mapper { get; set; }


        [TestInitialize]
        public void SetupAutoMapperConfiguration()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(this.Target);
            });
            this.Mapper = mapperConfiguration.CreateMapper();
        }

        #endregion
    }
}
