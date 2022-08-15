using AutoMapper;
using Catharsium.Clients.GoogleCalendar._Configuration.AutoMapper;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Clients.GoogleCalendar.Tests._Configuration.AutoMapper._Fixture;

public abstract class GoogleToLocalMappingProfileFixture : TestFixture<GoogleToLocalMappingProfile>
{
    #region Fixture

    protected IMapper Mapper { get; set; }


    [TestInitialize]
    public void SetupAutoMapperConfiguration()
    {
        var mapperConfiguration = new MapperConfiguration(cfg => {
            cfg.AddProfile(this.Target);
        });
        this.Mapper = mapperConfiguration.CreateMapper();
    }

    #endregion
}