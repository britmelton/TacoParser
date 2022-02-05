namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            var cells = line.Split(','); //will split a string everytime it sees a comma and turn it into an array of strings.

            if (cells.Length < 3)
            {
                logger.LogError($"\nError: length is less t han 3.");

                return null; 
            }

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var tacoBellName = cells[2];
         
            var tacoBell = new TacoBell();
            tacoBell.Name = tacoBellName;
            tacoBell.Location = new Point(longitude, latitude);

            return tacoBell;
        }
    }
}