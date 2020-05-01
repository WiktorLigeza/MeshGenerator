using System;
using System.Collections.Generic;
using System.Text;

namespace GeoMesh.Models
{
    public class QTnodeTriangle
    {
        public QTnodeTriangle n1;
        public QTnodeTriangle n2;
        public QTnodeTriangle n3;
        public QTnodeTriangle n4;
        public TriangleModel triaUp;
        public TriangleModel triaDown;


        public QTnodeTriangle(TriangleModel triaUp, TriangleModel triaDown, QTnodeTriangle n1, QTnodeTriangle n2, QTnodeTriangle n3, QTnodeTriangle n4)
        {
            this.triaUp = triaUp;
            this.triaDown = triaDown;

            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
            this.n4 = n4;
        }
    }
}
//public class QTnodeTriangle
//{
//    public QTnodeTriangle n1;
//    public QTnodeTriangle n2;
//    public QTnodeTriangle n3;
//    public QTnodeTriangle n4;
//    public QTnodeTriangle n5;
//    public QTnodeTriangle n6;
//    public QTnodeTriangle n7;
//    public QTnodeTriangle n8;
//    public TriangleModel tria;


//    public QTnodeTriangle(TriangleModel tria,
//        QTnodeTriangle n1, QTnodeTriangle n2,
//        QTnodeTriangle n3, QTnodeTriangle n4,
//        QTnodeTriangle n5, QTnodeTriangle n6,
//        QTnodeTriangle n8, QTnodeTriangle n7)
//    {
//        this.tria = tria;

//        this.n1 = n1;
//        this.n2 = n2;
//        this.n3 = n3;
//        this.n4 = n4;
//        this.n1 = n5;
//        this.n2 = n6;
//        this.n3 = n7;
//        this.n4 = n8;
//    }
//}