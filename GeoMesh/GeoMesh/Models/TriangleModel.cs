using System;
using System.Collections.Generic;
using System.Text;

namespace GeoMesh.Models
{
    public class TriangleModel
    {
        public PointModel origin;
        public double width;
        public double height;

        public TriangleModel(PointModel origin, double width, double height)
        {
            this.height = height;
            this.width = width;
            this.origin = origin;
        }
    }
}
