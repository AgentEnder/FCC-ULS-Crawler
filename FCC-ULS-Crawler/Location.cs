using System;
using System.Collections.Generic;
using System.Linq;

namespace FCC_ULS_Crawler
{
    internal class Location
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string AdvertisedDownstreamSpeed { get; set; }
        public string AdvertisedUpstreamSpeed { get; set; }
        public string WirelessSpectrum { get; set; }
        public string PrimaryPopulationCenter { get; set; }
        public string PhysicalAddressOfTransimitSite { get; set; }
        public string TransmissionLocation { get; set; }
        public Coordinates Coordinates { get; set; }
        public bool? IsOmniDirectional { get; set; }
        public float? AntennaAzimuth { get; set; }
        public int? SectorAntennaType { get; set; }
        public float? TransmitRadius { get; set; }
        public float? TransmitFrequency { get; set; }
        public string? Polarity { get; set; }
        public float? TransmitAntennaGain { get; set; }
        public float? LineLoss { get; set; }
        public float? MechanicalBeamTilt { get; set; }
        public float? ElectricalBeamTilt { get; set; }
        public string EquipmentManufacturer { get; set; }
        public float? EIRP { get; set; }
        public float? PowerOutput { get { return EIRP - 30 - TransmitAntennaGain; } }
        public float? GroundElevationAtBase{ get; set; }
        public float? AntennaElevation { get; set; }
        public DateTime ProposedLaunchDate { get; set; }
        public Uri RecordLink { get; set; }
    }

    internal class Coordinates
    {
        public Coordinate Latitude { get; set; }
        public float LatitudeFloat { get { return Latitude.Degrees + Latitude.Minutes / 60 + Latitude.Seconds / 3600; } }
        public Coordinate Longitude { get; set; }
        public float LongitudeFloat { get { return Longitude.Degrees + Longitude.Minutes / 60 + Longitude.Seconds / 3600; } }

        /// <summary>
        /// Parses the coordinate representation used by the ULS License Search
        /// </summary>
        /// <param name="representation">Coordinates in the form 39-28-06.5 N, 087-23-44.5 W</param>
        /// <returns>Structured Object</returns>
        public static Coordinates Parse(string representation)
        {
            string longitude = representation.Split(',')[1].Trim();
            string longitudeDirection = longitude.Split(' ')[1].Trim();
            List<float> longitudeNums = new List<string>(longitude.Split(' ')[0].Split('-'))
                                           .Select(x => float.Parse(x) * (longitudeDirection == "E" ? 1 : -1))
                                           .ToList();
            string latitude = representation.Split(',')[0].Trim();
            string latitudeDirection = latitude.Split(' ')[1].Trim();
            List<float> latitudeNums = new List<string>(latitude.Split(' ')[0].Split('-'))
                                           .Select(x => float.Parse(x) * (latitudeDirection == "N" ? 1 : -1))
                                           .ToList();

            return new Coordinates
            {
                Latitude = new Coordinate
                {
                    Degrees = latitudeNums[0],
                    Minutes = latitudeNums[1],
                    Seconds = latitudeNums[2]
                },
                Longitude = new Coordinate
                {
                    Degrees = longitudeNums[0],
                    Minutes = longitudeNums[1],
                    Seconds = longitudeNums[2],
                }
            };
        }
    }

    internal class Coordinate
    {
        public float Degrees { get; set; }
        public float Minutes { get; set; }
        public float Seconds { get; set; }
    }
}