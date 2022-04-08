using System;
namespace LoggingKata
{
    // Inherits from ITrackable interface
    public class TacoBell : ITrackable
    {
        // Default Constructor
        public TacoBell()
        {
        }

        // Paramaterized Constructor
        public TacoBell(double latitude, double longitude, string name)
        {
            // Instantiates a new point to store the lat and long within
            // paramaterized constructor of Taco Bell class

            // This allows the Taco Bell class to conform to ITrackable,
            // (which has the properties of string Name and Point Location), thus allowing it to be used by Geo
            Point tacoLocation = new Point()
            {
                Latitude = latitude,
                Longitude = longitude
            };

            Name = name;
            Location = tacoLocation;

        }


        // Properties
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
