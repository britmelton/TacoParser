using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            //Assert
            Assert.NotNull(actual);
        }


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expectedLongitude)
        {
            //Arrange
            TacoParser longitudetester = new TacoParser();

            //Act
            ITrackable trackableLon = longitudetester.Parse(line);

            //Assert
            Assert.Equal(expectedLongitude, trackableLon.Location.Longitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string line, double expectedLatitude)
        {
            TacoParser latitudetester = new TacoParser();
            ITrackable trackableLat = latitudetester.Parse(line);
            Assert.Equal(expectedLatitude, trackableLat.Location.Latitude);
        }
    }
}
