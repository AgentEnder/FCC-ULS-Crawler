using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCC_ULS_Crawler
{
    class LocationMap: ClassMap<Location>
    {
        public LocationMap()
        {
            Map(m => m.Name).Name("Name of Access Point / Transmission Location").Index(0);
            Map(m => m.Status).Name("Tower Status").Index(1);
            Map(m => m.AdvertisedDownstreamSpeed).Name("Maximum Advertised Downstream Speed").Index(2);
            Map(m => m.AdvertisedUpstreamSpeed).Name("Maximum Advertised Upstream Speed").Index(3);
            Map(m => m.WirelessSpectrum).Name("Wireless Spectrum Used").Index(4);
            Map(m => m.PrimaryPopulationCenter).Name("Primary Population Center Covered by Service (city, county, etc)").Index(5);
            Map(m => m.PhysicalAddressOfTransimitSite).Name("Physical Address of Transmit Site").Index(6);
            Map(m => m.TransmissionLocation).Name("Transmission Location").Index(7);
            Map(m => m.Coordinates.Latitude.Degrees).Name("Coordinates: Latitude - Degrees").Index(8);
            Map(m => m.Coordinates.Latitude.Minutes).Name("Coordinates: Latitude - Minutes").Index(9);
            Map(m => m.Coordinates.Latitude.Seconds).Name("Coordinates: Latitude - Seconds").Index(10);
            Map(m => m.Coordinates.LatitudeFloat).Name("Latitude").Index(11);
            Map(m => m.Coordinates.Longitude.Degrees).Name("Coordinates: Longitude - Degrees").Index(12);
            Map(m => m.Coordinates.Longitude.Minutes).Name("Coordinates: Longitude - Minutes").Index(13);
            Map(m => m.Coordinates.Longitude.Seconds).Name("Coordinates: Longitude - Seconds").Index(14);
            Map(m => m.Coordinates.LongitudeFloat).Name("Longitude").Index(15);
            Map(m => m.IsOmniDirectional).Name("Is the Transmit Antenna Omni-Directional").Index(16);
            Map(m => m.AntennaAzimuth).Name("Azimuth of Sectorized Antenna, if used").Index(17);
            Map(m => m.SectorAntennaType).Name("Type of Sector Antenna Used").Index(18);
            Map(m => m.TransmitRadius).Name("Transmit Radius (in miles)").Index(19);
            Map(m => m.TransmitFrequency).Name("Transmit Frequency (MHz)").Index(20);
            Map(m => m.Polarity).Name("Polarity (V or H)").Index(21);
            Map(m => m.TransmitAntennaGain).Name("Transmit Antenna Gain in dBi").Index(22);
            Map(m => m.LineLoss).Name("Line Loss (dB)").Index(23);
            Map(m => m.MechanicalBeamTilt).Name("Mechanical Beam Tilt (degrees)").Index(24);
            Map(m => m.ElectricalBeamTilt).Name("Electrical Beam Tilt (degrees)").Index(25);
            Map(m => m.EquipmentManufacturer).Name("Equipment Manufacturer").Index(26);
            Map(m => m.PowerOutput).Name("dBw Power Output of the Manufacturer's Radio").Index(27);
            Map(m => m.GroundElevationAtBase).Name("Ground Elevation at Base of Transmit Site").Index(28);
            Map(m => m.AntennaElevation).Name("Antenna Elevation (meters above ground)").Index(29);
            Map(m => m.ProposedLaunchDate).Name("Proposed Launch Date").Index(30);
            Map(m => m.Comments).Name("Comments").Index(31);
            Map(m => m.EIRP).Name("Total System EIRP in Dbm").Index(32);
        }
    }
}
