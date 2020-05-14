using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class GeoTypes
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Properties
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string borough { get; set; }
        public string neighborhood { get; set; }
        public string county { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public GeoTypes geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class RootObject
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
}
