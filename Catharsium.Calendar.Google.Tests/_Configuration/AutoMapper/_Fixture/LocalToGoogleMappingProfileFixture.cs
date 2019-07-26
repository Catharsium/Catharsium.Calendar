﻿using AutoMapper;
using Catharsium.Calendar.Google._Configuration.AutoMapper;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Calendar.Google.Tests._Configuration.AutoMapper._Fixture
{
    public abstract class LocalToGoogleMappingProfileFixture : TestFixture<LocalToGoogleMappingProfile>
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
}