using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using Newtonsoft.Json;
using Xunit;

namespace LINQ.Tests
{
    public class UnitTest1
    {

        static string filename = "data.json";
        static string data = File.ReadAllText(filename);

        RootObject geojson = JsonConvert.DeserializeObject<RootObject>(data);

        [Fact]
        public void CapableOfReading()
        {


            Assert.NotEmpty(data);


            Assert.NotNull(geojson);

            Assert.Equal("10001", geojson.features.First().properties.zip);
            Assert.NotEmpty(
                geojson.features
                    .Select(feature => feature.properties.zip)
                    .Distinct()
                );

            Assert.Equal(147, geojson.features.Count());

        }

        [Fact]
        public void DataFirstAndLastInListIsCorrect()
        {

            var query = from feature 
                        in geojson.features 
                        select feature.properties.neighborhood;

            

            int counter = query.Count();

            Assert.Equal("Chelsea", query.First());
            Assert.Equal("Battery Park City", query.Last());
            Assert.Equal(147, counter);

        }

        [Fact]
        public void FilterNeighborhoodsWithNoNames()
        {
            var query = from feature
                        in geojson.features
                        where feature.properties.neighborhood != ""
                        select feature.properties.neighborhood;

            int counter = query.Count();

            Assert.Equal(142, counter);
        }
    }
}
