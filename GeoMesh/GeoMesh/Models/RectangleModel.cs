using System;
using System.Collections.Generic;
using System.Text;

namespace GeoMesh.Models
{
    public class RectangleModel
    {
        public PointModel origin;
        public double width;
        public double height;

        public RectangleModel(PointModel origin, double width, double height)
        {

            this.height = height;
            this.width = width;

            this.origin = origin;

        }
    }
}
