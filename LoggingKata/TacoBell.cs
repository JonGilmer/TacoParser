using System;
namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        // Default Constructor
        public TacoBell()
        {
        }

        // Paramaterized Constructor
        public TacoBell(double latitude, double longitude, string name)
        {
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
