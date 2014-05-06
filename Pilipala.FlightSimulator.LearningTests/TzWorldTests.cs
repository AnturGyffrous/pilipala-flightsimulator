using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

using DotSpatial.Data;

using Ionic.Zip;

using NetTopologySuite.Geometries;

using NUnit.Framework;

using Pilipala.FlightSimulator.LearningTests.Properties;

using Shapefile = NetTopologySuite.IO.Shapefile;

namespace Pilipala.FlightSimulator.LearningTests
{
    [TestFixture]
    public class TzWorldTests
    {
        [Test]
        public void CanExtractTzWorldData()
        {
            var stream = new MemoryStream(Resources.tz_world);
            var zipFile = ZipFile.Read(stream);
            // ZipEntry::world/index.html
            // ZipEntry::world/tz_world.png
            // ZipEntry::world/tz_world.prj
            // ZipEntry::world/tz_world.shp
            // ZipEntry::world/tz_world.shx
            // ZipEntry::world/tz_world.dbf

            var directory = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "tz_world"));

            zipFile.ExtractAll(directory.FullName, ExtractExistingFileAction.OverwriteSilently);

            foreach (var file in directory.GetFiles("*.shp", SearchOption.AllDirectories))
            {
                var featureSet = FeatureSet.Open(file.FullName);
                var feature = featureSet.Features[0];
                Debug.Print(feature.DataRow["TZID"].ToString());
                Debug.Print(feature.BasicGeometry.Coordinates.First().X.ToString(CultureInfo.InvariantCulture));
                Debug.Print(feature.BasicGeometry.Coordinates.First().Y.ToString(CultureInfo.InvariantCulture));
                featureSet.Close();

                var reader = Shapefile.CreateDataReader(file.FullName, (GeometryFactory)GeometryFactory.Default);
                reader.Read();
                Debug.Print(reader["TZID"].ToString());
                Debug.Print(reader.Geometry.Coordinates.First().X.ToString(CultureInfo.InvariantCulture));
                Debug.Print(reader.Geometry.Coordinates.First().Y.ToString(CultureInfo.InvariantCulture));
                reader.Close();
            }

            foreach (var file in directory.GetFiles("*.*", SearchOption.AllDirectories))
            {
                try
                {
                    file.Delete();
                }
                catch (Exception exception)
                {
                    Debug.Print("Error deleting file {0}: {1} - {2}", file.Name, exception.GetType().FullName, exception.Message);
                }
            }
        }
    }
}
