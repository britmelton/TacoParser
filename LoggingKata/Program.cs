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
            // TODO:  Find the two Taco Bells that are the furthest from one another.

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            var lines = File.ReadAllLines(csvPath);

            if (lines.Length == 0)
            {
                logger.LogError($"\nERROR ZERO LINES");
            }
            else if (lines.Length == 1)
            {
                logger.LogWarning($"\nWARNING only 1 line");
            }
            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(x => parser.Parse(x)).ToArray();

            ITrackable longestOrigin = null;
            ITrackable longestDestination = null;
            double longestDistance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            
            foreach (var origin in locations)
            { 
                var originCoordinates = new GeoCoordinate(origin.Location.Latitude, origin.Location.Longitude);

                foreach(var destination in locations)
                {
                    var destinationCoordinates = new GeoCoordinate(destination.Location.Latitude, destination.Location.Longitude);
                    var distance = originCoordinates.GetDistanceTo(destinationCoordinates);  // Now, compare the two using `.GetDistanceTo()`, which returns a double

                    logger.LogInfo($"distance from {origin.Name} to {destination.Name} is {distance}");

                    if (distance > longestDistance)
                    {
                        longestDistance = distance;
                        longestOrigin = origin;
                        longestDestination = destination;
                        logger.LogInfo($"\nCurrent longest distance is {longestDistance}");
                    }
                }
            }
            logger.LogInfo($"\n{longestDestination.Name} is furthest away from {longestOrigin.Name}.\n Distance:{longestDistance}");
        }
    }
}
