using BasicGame.ConsoleGame.Services;
using Moq;
using Xunit;

namespace BasicGame.Tests
{
    public class MapTests
    {
        [Fact]
        public void Map_Constructor_SetCorrectWidth()
        {
            const int expectedWidth = 10;
            const int expectedHeight = 20;

            var mapServiceMock = new Mock<IMapService>();

            mapServiceMock.Setup(x => x.GetMap()).Returns((expectedWidth, expectedHeight));


            var map = new Map(mapServiceMock.Object);
            var actual = map.Width;

            Assert.Equal(expectedWidth, actual);
        }
    }
}