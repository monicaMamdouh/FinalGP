using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WordsKmeanClustering.HelperClasses
{
    class Cluster
    {
        public int Number { get; set; }
        public int XPoint { get; set; }
        public double YPoint { get; set; }
        public double ZPoint { get; set; }
        public Color ColorOfPoint { get; set; }

        public int XTotal { get; set; }
        public double YTotal { get; set; }
        public double ZTotal { get; set; }
        public int TotalDataPoints { get; set; }

        public int OldXPoint { get; set; }
        public double OldYPoint { get; set; }
        public double OldZPoint { get; set; }
        public int OldTotalDataPoints { get; set; }

        public Cluster(int number, int xPoint, double yPoint,double zPoint, Color colorOfPoint)
        {
            Number = number;
            XPoint = xPoint;
            YPoint = yPoint;
            ZPoint = zPoint;
            ColorOfPoint = colorOfPoint;

            XTotal = 0;
            YTotal = 0;
            ZTotal = 0;
            TotalDataPoints = 0;
        }

        public void SetToDefaultTotal()
        {
            OldTotalDataPoints = TotalDataPoints;

            XTotal = 0;
            YTotal = 0;
            ZTotal = 0;
            TotalDataPoints = 0;
        }

        public void setXPoint(int xPoint)
        {
            OldXPoint = XPoint;
            XPoint = xPoint;
        }

        public void setYPoint(double yPoint)
        {
            OldYPoint = YPoint;
            YPoint = yPoint;
        }
        public void setZPoint(double zPoint)
        {
            OldZPoint = ZPoint;
            ZPoint = zPoint;
        }
    }
}
