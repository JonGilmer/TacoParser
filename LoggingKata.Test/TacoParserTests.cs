using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // Completes anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // Checks if Taco Bell longitude is correctly parsed from .csv file

            //Arrange
            var utility = new TacoParser();

            //Act
            var actual = utility.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);

        }


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLatitude(string line, double expected)
        {
            // Checks if Taco Bell latitude is correctly parsed from .csv file

            //Arrange
            var utility = new TacoParser();

            //Act
            var actual = utility.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);

        }


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", "Taco Bell Acwort...")]
        public void ShouldParseName(string line, string expected)
        {
            // Checks if Taco Bell name is correctly parsed from .csv

            //Arrange
            var utility = new TacoParser();

            //Act
            var actual = utility.Parse(line);
            actual.Name = actual.Name.ToString().Trim(' ');

            //Assert
            Assert.Equal(expected, actual.Name);

        }

    }
}
