using System;

namespace Soteria.RiskScore
{
    public class GeoLocation
    {
        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double DistanceFrom(GeoLocation geoLocation2)
        {
            return CalculateDistance(this, geoLocation2);
        }

        public static double CalculateDistance(GeoLocation geoLocation1, GeoLocation geoLocation2)
        {
            const double earthRadius = 6371; // Earth's Radius (in meters)

            var sinDistanceLatitude = Math.Sin((geoLocation2.Latitude - geoLocation1.Latitude) / 2);
            var sinDistanceLongitude = Math.Sin((geoLocation2.Longitude - geoLocation1.Longitude) / 2);
            var q = sinDistanceLatitude * sinDistanceLatitude + Math.Cos(geoLocation1.Latitude) * Math.Cos(geoLocation2.Latitude) * sinDistanceLongitude * sinDistanceLongitude;

            return 2 * earthRadius * Math.Asin(Math.Sqrt(q));
        }
    }
}
