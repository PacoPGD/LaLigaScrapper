using LaLigaInfraestructure.Redis;
using Moq;
using NUnit.Framework;
using StackExchange.Redis;

namespace LaLigaInfraestructure.UnitTests.Redis
{
    [TestFixture]
    public class RedisServiceTests
    {
        [Test]
        public async Task GetFromRedis_ShouldDeserializeAndGetDataFromRedis()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>();
            var mockConnectionMultiplexer = new Mock<IConnectionMultiplexer>();
            mockConnectionMultiplexer.Setup(x => x.GetDatabase(It.IsAny<int>(), It.IsAny<object>())).Returns(mockDatabase.Object);
            var redisService = new RedisService(mockConnectionMultiplexer.Object);
            var key = "testKey";
            var value = "\"testValue\""; 

            mockDatabase.Setup(x => x.StringGetAsync(key, CommandFlags.None)).ReturnsAsync(value);

            // Act
            var result = await redisService.GetFromRedis<string>(key);

            // Assert
            Assert.That(result, Is.EqualTo("testValue"));
        }
    }
}
