using BasicGame.ConsoleGame.Extensions;
using BasicGame.ConsoleGame.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace BasicGame.Tests
{
    public class MapTests
    {
        //1. With Service
        //[Fact]
        //public void Map_Constructor_SetCorrectWidth()
        //{
        //    const int expectedWidth = 10;
        //    const int expectedHeight = 20;

        //    var mapServiceMock = new Mock<IMapService>();

        //    mapServiceMock.Setup(x => x.GetMap()).Returns((expectedWidth, expectedHeight));


        //    var map = new Map(mapServiceMock.Object);
        //    var actual = map.Width;

        //    Assert.Equal(expectedWidth, actual);
        //} 


        //2. With IConfiguration Extension wrapper with Interface
        //[Fact]
        //public void Map_Constructor_SetCorrectWidth()
        //{
        //    const int expected = 10;
        //    var mockConfig = new Mock<IConfiguration>();
        //    var getMapSizeMock = new Mock<IGetMapSize>();

        //    getMapSizeMock.Setup(m => m.GetMapSizeFor(mockConfig.Object, It.IsAny<string>())).Returns(expected);
        //    TestExtensionDemo.Implementation = getMapSizeMock.Object;

        //    var map = new Map(mockConfig.Object);
        //    var actual = map.Width;

        //    Assert.Equal(expected, actual);
        //}

        //3. With Func
        [Fact]
        public void Map_Constructor_SetCorrectWidth()
        {
            const int expected = 10;
            var mockConfig = new Mock<IConfiguration>();

            ExtensionTestFunc.Implementation = (c, v) => expected;

            var map = new Map(mockConfig.Object);

            var actual = map.Width;

            Assert.Equal(expected, actual);
        }
    }
}