using DomainLogic;
using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Can_create_strategy()
        {
            var strategy = new VideoStrategy("Test Strat",
                        "Test Summary",
                        null,
                        new DomainLogic.Version(0,1,0));

            Assert.IsType<VideoStrategy>(strategy);            
        }

    }
}
