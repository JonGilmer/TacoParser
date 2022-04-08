namespace LoggingKata
{
    /// Parses a csv file to locate all the Taco Bells
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();


        // By using an ITrackable, multiple other classes can be created based off of it,
        // and if changes need to be made to those classes, instead of changing code inside of
        // each class, only the code of the interface needs to be changed
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Takes the line parameter and uses line.Split(',') to split it up into an array
            // of strings, separated by the char ','
            var cells = line.Split(',');

            // If array.Length is less than 3, log that something went wrong (do not fail) and return null
            if (cells.Length < 3)
            {
                logger.LogError($"Lines: {cells[0]}");
                return null;
            }

            // Gets latitude of array, which is at index 0
            var latitude = double.Parse(cells[0]);
            // Gets the longitude of the array located at index 1
            var longitude = double.Parse(cells[1]);
            // Gets the name of the taco bell which is at index 2
            var name = cells[2];

            // Instantiates new Taco Bell class with values initialized through paramaterized constructor
            TacoBell tacoBellVar = new TacoBell(latitude, longitude, name) { };

            // Returns the TacoBell instance (which conforms to ITrackable)
            return tacoBellVar;
        }
    }
}