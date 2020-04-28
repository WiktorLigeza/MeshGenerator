using System;
using System.Collections.Generic;
using System.Text;

namespace GeoMesh.Models
{
    public class QTnode
    {
        public QTnode n1;
        public QTnode n2;
        public QTnode n3;
        public QTnode n4;
        public RectangleModel rect;


        public QTnode(RectangleModel rect, QTnode n1, QTnode n2, QTnode n3, QTnode n4)
        {
            this.rect = rect;

            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
            this.n4 = n4;
        }
    }
}
