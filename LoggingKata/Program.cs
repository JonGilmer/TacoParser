using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            // using File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            if (lines == null || lines.Length == 0)
            {
                logger.LogError($"Lines: {lines[0]}");
            }

            if (lines.Length == 1 )
            {
                logger.LogWarning($"Lines: {lines[0]}");
            }

            // New instance of TacoParser class
            var parser = new TacoParser();

            // Gets an IEnumerable of locations using the Select method and
            // converts the data of the string "lines" into an ITrackable[] of all locations
            // that were stored in the csv file.
            // This will be used to pick locations to compare the distance between
            var locations = lines.Select(parser.Parse).ToArray();



            // Creating two ITrackable Taco Bell variables with initial values of `null`.
            // Used to store your two taco bells that are the farthest from each other.
            ITrackable tacoBell_A = null;
            ITrackable tacoBell_B = null;

            // double var used to store the distance
            double distance = 0;


            // Loops through locations to grab each location as the origin location
            foreach (var location in locations)
            {
                var locA = location;
                var corA = locA.Location;

                // Another loop to grab each location as the secondary location to comapre
                // against the origin location
                for (int i2 = 0; i2 < locations.Length; i2++)
                {
                    var locB = locations[i2];
                    var corB = locB.Location;

                    // Sets the locations to GeoCoordinates for use with the GetDistanceTo Method
                    var locAGeo = new GeoCoordinate(corA.Latitude, corA.Longitude);
                    var locBGeo = new GeoCoordinate(corB.Latitude, corB.Longitude);
                    // Method compares the distance between locA and locB and stores the calculated value in double geoDistance
                    var geoDistance = locAGeo.GetDistanceTo(locBGeo);

                    // if calculated distance is greater than the current stored distance,
                    // then distance stores the new greatest distance
                    if (geoDistance > distance)
                    {
                        distance = geoDistance;
                        tacoBell_A = locA;
                        tacoBell_B = locB;
                    }
                }
            }

            // Converts to distance in miles
            var distance_In_Miles = distance * 0.0006213712;
            // Rounds distance to the nearest 2 decimals
            distance_In_Miles = Math.Round(distance_In_Miles, 2);

            // Uses string interpolation to print the results
            Console.WriteLine($"\n{tacoBell_A.Name} and {tacoBell_B.Name} are the 2 furthest Taco Bells in Alabama.");
            Console.WriteLine($"The distance between them is {distance_In_Miles} miles.");
   
        }
    }
}
