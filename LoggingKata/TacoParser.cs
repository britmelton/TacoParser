namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {

         readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string record)
        {
            var values = record.Split(','); //will split a string everytime it sees a comma and turn it into an array of strings.

            // If your array.Length is less than 3, something went wrong
            if (values.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                logger.LogError($"\nError: length is less than 3.");

                return null; 
            }

            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            var latitude = double.Parse(values[0]);
            var longitude = double.Parse(values[1]);
            var tacoBellName = values[2];
         
            var tacoBell = new TacoBell();
            tacoBell.Name = tacoBellName;
            tacoBell.Location = new Point(longitude, latitude);

            return tacoBell;

        }
    }
}