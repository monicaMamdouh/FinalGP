using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsKmeanClustering.HelperClasses
{
    class DataPoint
    {
        public int PointID { get; set; }
        public int XPoint { get; set; }
        public double YPoint { get; set; }
        public double ZPoint { get; set; }
        public string pointString { get; set; }

        public Cluster Cluster { get; set; }

        public double Distace { get; set; }

        public DataPoint(int PointId,string pointstr, int xPoint, double yPoint, double zPoint, Cluster cluster)
        {
            PointID = PointId;
            pointString = pointstr;
            XPoint = xPoint;
            YPoint = yPoint;
            ZPoint = zPoint;
            Cluster = cluster;
        }
    }
}
