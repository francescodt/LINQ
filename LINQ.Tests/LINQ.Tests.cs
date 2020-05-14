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

            int counter = 0;

            foreach (string neighborhood in query)
            {
                counter++;
            }



            Assert.Equal("10001", geojson.features.First().properties.zip);
            Assert.Equal("10292", geojson.features.Last().properties.zip);
            Assert.Equal(147, counter);

        }

        [Fact]
        public void FilterNeighborhoodsWithNoNames()
        {

        }
    }
}
