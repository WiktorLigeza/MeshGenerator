using System;
using System.Collections.Generic;
using System.Text;

namespace GeoMesh.Models
{
    public class TriangleModel
    {
        public PointModel P1;
        public PointModel P2;
        public PointModel P3;

        /// <summary>
        /// constructor
        /// </summary>
        public TriangleModel(PointModel P1, PointModel P2, PointModel P3)
        {
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
        }

        public string Display
        {
            get
            {
                return $"P1: {P1.x} {P1.y} , P2: {P2.x} {P2.y} , P3: {P3.x} {P3.y}";
            }
        }
    }
}
