using GeoMesh;
using GeoMesh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoMeshGUI
{
    public class Engine
    {
        //***************************** MESH **************************\\
        /// <summary>
        /// generates mesh of given type
        /// </summary>
        /// <param name="meshType"></param>
        /// <returns></returns>
        public static List<LineModel> generateMesh(string meshType, List<PointModel> matrix, int x, int y)
        {
            List<LineModel> links = new List<LineModel>();
            if (meshType == "TRIANGULAR")
            {
                /// vertical loop
                int j = 0;
                for (int i = 0; i < matrix.Count - 1; i++) //goes in y axis
                {
                    if (j != y)
                    {
                        links.Add(new LineModel(matrix[i], matrix[i + 1]));
                    }
                    else
                    {
                        j = -1;
                    }
                    j++;
                }


                /// horizontal loop
                List<PointModel> sorted = matrix.OrderBy(p => p.y).ThenBy(p => p.x).ToList();
                j = 0;
                for (int i = 0; i < matrix.Count - 1; i++) //goes in y axis
                {
                    if (j != x)
                    {
                        links.Add(new LineModel(sorted[i], sorted[i + 1]));
                    }
                    else
                    {
                        j = -1;
                    }
                    j++;
                }


                /// diagonal loop
                j = 0;
                for (int i = 0; i < matrix.Count - y - 1; i++) //goes in y axis
                {
                    if (j != y)
                    {
                        links.Add(new LineModel(matrix[i], matrix[y + i + 2]));
                    }
                    else
                    {
                        j = -1;
                    }
                    j++;
                }
            }

            else if (meshType == "QUADRANGULR")
            {
                /// vertical loop
                int j = 0;
                for (int i = 0; i < matrix.Count - 1; i++) //goes in y axis
                {
                    if (j != y)
                    {
                        links.Add(new LineModel(matrix[i], matrix[i + 1]));
                    }
                    else
                    {
                        j = -1;
                    }
                    j++;
                }


                /// horizontal loop
                List<PointModel> sorted = matrix.OrderBy(p => p.y).ThenBy(p => p.x).ToList();
                j = 0;
                for (int i = 0; i < matrix.Count - 1; i++) //goes in y axis
                {
                    if (j != x)
                    {
                        links.Add(new LineModel(sorted[i], sorted[i + 1]));
                    }
                    else
                    {
                        j = -1;
                    }
                    j++;
                }
            }

            return links;
        }

        /// <summary>
        /// generates matrix of points of given size
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="graphsHeight"></param>
        /// <param name="graphsWidth"></param>
        /// <returns></returns>
        public static List<PointModel> generateMatrix(int x, int y, float graphsHeight, float graphsWidth)
        {
            List<PointModel> matrix = new List<PointModel>();
            double deltaX, deltaY;
            deltaX = graphsWidth / x;
            deltaY = graphsHeight / y;
            double Xactual = 0 - deltaX, Yactual = 0 - deltaY; //starting point
            for (int i = 0; i < x + 1; i++) //goes in x axis
            {
                Xactual += deltaX;
                Yactual = 0 - deltaY;
                for (int j = 0; j < y + 1; j++) //goes in y axis
                {
                    Yactual += deltaY;
                    matrix.Add(new PointModel(Xactual, Yactual));
                }
            }
            return matrix;
        }

        /// <summary>
        /// generates matrix of points for given polygon
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static List<PointModel> figureMatrixGenerator(List<PointModel> PolygonVertices, int x, int y)
        {
            List<PointModel> matrix = new List<PointModel>();
            List<PointModel> temp = new List<PointModel>();
            List<PointModel> edge = new List<PointModel>();
            List<PointModel> sortedY = PolygonVertices.OrderBy(p => p.y).ToList();
            List<PointModel> sortedX = PolygonVertices.OrderBy(p => p.x).ToList();
            double height = Math.Abs(sortedY[0].y - sortedY[sortedY.Count - 1].y);
            double width = Math.Abs(sortedX[0].x - sortedX[sortedX.Count - 1].x);
            double deltaX = width / x;
            double deltaY = height / y;


            double Xactual = sortedX[0].x - deltaX, Yactual = sortedY[0].y - deltaY; //starting point
                                                                                     // matrix = putPointsOnEdge(PolygonVertices, Xactual, Yactual, deltaX, deltaY);


            for (int i = 0; i < x + 1; i++) //goes in x axis
            {
                Xactual += deltaX;
                Yactual = sortedY[0].y - deltaY;
                for (int j = 0; j < y + 1; j++) //goes in y axis
                {
                    Yactual += deltaY;
                    //if (IsInPolygon(PolygonVertices, new PointModel(Xactual, Yactual)))
                    //{
                    //    matrix.Add(new PointModel(Xactual, Yactual));
                    //}
                    matrix.Add(new PointModel(Xactual, Yactual));
                }
            }

            matrix = matrix.OrderBy(p => p.x).ThenBy(p => p.y).ToList();
            return matrix;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------\\MESH



        //***************************** OTHER **************************\\
        /// <summary>
        /// computes distance between points (vector lenght)
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double Vlenght(PointModel p1, PointModel p2)
        {
            return Math.Sqrt(Math.Pow((p2.x - p1.x), 2) + Math.Pow((p2.y - p1.y), 2));
        }

        /// <summary>
        /// computes straight line equation of given line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static double[] LinetoSLE(LineModel line)
        {
            double a, b;
            double[] result = new double[2];
            a = (line.A.y - line.B.y) / (line.A.x - line.B.x); //(y1 - y2) / (x1 - x2);
            b = line.A.y - a * line.A.x;  //y1 - a * x1;
                                          //Console.WriteLine("equation: y=" +a+"x+"+b);
            result[0] = a;
            result[1] = b;

            return result;
        }

        /// <summary>
        /// checks if given point is inside the polygon
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool IsInPolygon(List<PointModel> polygon, PointModel point)
        {
            bool result = false;
            var a = polygon.Last();
            foreach (var b in polygon)
            {
                if ((b.x == point.x) && (b.y == point.y))
                    return true;

                if ((b.y == a.y) && (point.y == a.y) && (a.x <= point.x) && (point.x <= b.x))
                    return true;

                if ((b.y < point.y) && (a.y >= point.y) || (a.y < point.y) && (b.y >= point.y))
                {
                    if (b.x + (point.y - b.y) / (a.y - b.y) * (a.x - b.x) <= point.x)
                        result = !result;
                }
                a = b;
            }
            return result;
        }

        /// <summary>
        /// puts points on polygons edges
        /// </summary>
        /// <param name="PolygonVertices"></param>
        /// <param name="Xactual"></param>
        /// <param name="Yactual"></param>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        /// <returns></returns>
        public static List<PointModel> putPointsOnEdge(
            List<PointModel> PolygonVertices,
            double Xactual,
            double Yactual,
            double deltaX,
            double deltaY)
        {
            double[] SLE = new double[2];
            List<PointModel> edge = new List<PointModel>();
            LineModel l;
            double XYactual = Xactual;
            double YXactual = Yactual;
            // for all y - 1 edges
            for (int i = 0; i < PolygonVertices.Count - 1; i++)
            {
                l = new LineModel(new PointModel(PolygonVertices[i].x, PolygonVertices[i].y),
                        new PointModel(PolygonVertices[i + 1].x, PolygonVertices[i + 1].y));
                SLE = LinetoSLE(l);
                //goes in y axis
                if (SLE[0] != 0)
                {
                    for (int j = 0; Yactual <= PolygonVertices[i + 1].y - deltaY; j++)
                    {
                        Yactual += deltaY;
                        //Yactual = SLE[0] * Xactual + SLE[1];
                        XYactual = (Yactual - SLE[1]) / SLE[0];

                        edge.Add(new PointModel(XYactual, Yactual));
                    }
                }

            }

            //for last edge
            l = new LineModel(new PointModel(PolygonVertices[PolygonVertices.Count - 1].x, PolygonVertices[PolygonVertices.Count - 1].y),
                         new PointModel(PolygonVertices[0].x, PolygonVertices[0].y));
            SLE = LinetoSLE(l);

            // for y axis
            Yactual += deltaY;
            if (SLE[0] != 0)
            {
                for (int j = 0; Yactual >= PolygonVertices[0].y + deltaY; j++) //goes in y axis
                {
                    Yactual -= deltaY;
                    XYactual = (Yactual - SLE[1]) / SLE[0];

                    edge.Add(new PointModel(XYactual, Yactual));
                }
            }

            return edge;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------\\OTHER



        //***************************** QUAD TREE RECTANGLE **************************\\
        /// <summary>
        /// generates quad tree based on image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="tol"></param>
        /// <returns></returns>
        public static QTnode quadTreeGenerator(Image image, double width, double height, double tol)
        {
            //init
            Bitmap bmp = new Bitmap(image);
            QTnode rootNode = new QTnode(new RectangleModel(new PointModel(0, 0), width, height), null, null, null, null);

            subDivide(rootNode, tol, bmp);

            bmp.Dispose();
            return rootNode;
        }

        static void subDivide(QTnode root, double tol, Bitmap bmp)
        {
            if (checkFill(root.rect, bmp))
            {

                double width = root.rect.width / 2;
                double height = root.rect.height / 2;

                if (width > tol && height > tol)
                {

                    QTnode n1 = new QTnode(new RectangleModel(new PointModel(root.rect.origin.x, root.rect.origin.y), width, height), null, null, null, null);
                    QTnode n2 = new QTnode(new RectangleModel(new PointModel(root.rect.origin.x + width, root.rect.origin.y), width, height), null, null, null, null);
                    QTnode n3 = new QTnode(new RectangleModel(new PointModel(root.rect.origin.x, root.rect.origin.y + height), width, height), null, null, null, null);
                    QTnode n4 = new QTnode(new RectangleModel(new PointModel(root.rect.origin.x + width, root.rect.origin.y + height), width, height), null, null, null, null);

                    root.n1 = n1;
                    root.n2 = n2;
                    root.n3 = n3;
                    root.n4 = n4;

                    subDivide(n1, tol, bmp);
                    subDivide(n2, tol, bmp);
                    subDivide(n3, tol, bmp);
                    subDivide(n4, tol, bmp);
                }

            }
        }

        static bool checkFill(RectangleModel rect, Bitmap bmp)
        {

            bool isMixed = false;
            bool isBlack = false;
            bool isWhite = false;


            for (int wi = (int)rect.origin.x; wi < (rect.origin.x + rect.width); wi++)
            {
                for (int hi = (int)rect.origin.y; hi < (rect.origin.y + rect.height); hi++)
                {
                    Color pixelColor = bmp.GetPixel((int)wi, (int)hi);

                    if (pixelColor.R == 0 && (pixelColor.G == 0) && pixelColor.B == 0)
                        isBlack = true;

                    if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                        isWhite = true;

                    if (isBlack && isWhite)
                        return true;
                }
            }
            return isMixed;
        }

        /// <summary>
        /// deletes all nodes that are filled with only one color
        /// </summary>
        /// <param name="root"></param>
        /// <param name="bmp"></param>
        public static void deleteRedundant(QTnode root, Bitmap bmp)
        {
            if (root.n1 != null && root.n1.rect != null)
            {
                if (isRedundant(root.n1, bmp))
                {
                    root.n1 = null;
                }
                else deleteRedundant(root.n1, bmp);
            }
            if (root.n2 != null && root.n2.rect != null)
            {
                if (isRedundant(root.n2, bmp))
                {
                    root.n2 = null;
                }
                else deleteRedundant(root.n2, bmp);
            }
            if (root.n3 != null && root.n3.rect != null)
            {
                if (isRedundant(root.n3, bmp))
                {
                    root.n3 = null;
                }
                else deleteRedundant(root.n3, bmp);
            }
            if (root.n4 != null && root.n4.rect != null)
            {
                if (isRedundant(root.n4, bmp))
                {
                    root.n4 = null;
                }
                else deleteRedundant(root.n4, bmp);
            }

            //edge only
            //if (root.n1 != null || root.n2 != null || root.n3 != null || root.n4 != null)
            //{
            //    //if (root.n1 != null && root.n2 != null && root.n3 != null && root.n4 != null){}
            //    //else root.rect = null;
            //    root.rect = null;
            //}

        }

        static bool isRedundant(QTnode root, Bitmap bmp)
        {
            bool isBlack = false;
            bool isWhite = false;

            for (int wi = (int)root.rect.origin.x; wi < (root.rect.origin.x + root.rect.width); wi++)
            {
                for (int hi = (int)root.rect.origin.y; hi < (root.rect.origin.y + root.rect.height); hi++)
                {
                    Color pixelColor = bmp.GetPixel((int)wi, (int)hi);

                    if (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0)
                    {
                        isBlack = true;
                    }
                      
                    if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                    {
                        isWhite = true;
                    }
                    if (isBlack && isWhite)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// leaves only figure shape mesh
        /// </summary>
        /// <param name="root"></param>
        /// <param name="bmp"></param>
        /// <param name="isBlack"></param>
        public static void onlyFigure(QTnode root, Bitmap bmp, bool isBlack)
        {
            bool redundant, black;
            if (root.n1 != null)
            {
                (redundant, black) = isFigure(root.n1, bmp);
                if (redundant && black == false) // is it redundant
                {
                    root.n1 = null;
                }
                else onlyFigure(root.n1, bmp, black);
            }
            if (root.n2 != null)
            {
                (redundant, black) = isFigure(root.n2, bmp);
                if (redundant && black == false)
                {
                    root.n2 = null;
                }
                else onlyFigure(root.n2, bmp, black);
            }
            if (root.n3 != null)
            {
                (redundant, black) = isFigure(root.n3, bmp);
                if (redundant && black == false)
                {
                    root.n3 = null;
                }
                else onlyFigure(root.n3, bmp, black);
            }
            if (root.n4 != null)
            {
                (redundant, black) = isFigure(root.n4, bmp);
                if (redundant && black == false)
                {
                    root.n4 = null;
                }
                else onlyFigure(root.n4, bmp, black);
            }

            //edge only
            if (root.n1 != null || root.n2 != null || root.n3 != null || root.n4 != null)
            {
                root.rect = null;
            }

        }

        static (bool, bool) isFigure(QTnode root, Bitmap bmp)
        {
            bool isBlack = false;
            bool isWhite = false;

            for (int wi = (int)root.rect.origin.x; wi < (root.rect.origin.x + root.rect.width); wi++)
            {
                for (int hi = (int)root.rect.origin.y; hi < (root.rect.origin.y + root.rect.height); hi++)
                {
                    Color pixelColor = bmp.GetPixel((int)wi, (int)hi);

                    if (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0)
                    {
                        isBlack = true;
                    }

                    if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                    {
                        isWhite = true;
                    }
                    if (isBlack && isWhite)
                        return (false, false); //mixed 
                }
            }
            if (isBlack) return (true, true); //redundant && all black
            return (true, false); //redundant && all white
        }
        //-------------------------------------------------------------------------------------------------------------------------------------\\QUAD TREE RECTANGLE



        //***************************** QUAD TREE TRIANGLE **************************\\
        /// <summary>
        /// generates quad tree based on image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="tol"></param>
        /// <returns></returns>
        public static QTnodeTriangle quadTreeGenerator_Triangle(Image image, double width, double height, double tol)
        {
            //init
            Bitmap bmp = new Bitmap(image);
            QTnodeTriangle rootNode = new QTnodeTriangle(new TriangleModel(new PointModel(0, 0), width, height), //up
                new TriangleModel(new PointModel(width, height), width, height), //down
                null, null, null, null);

            subDivide_Triangle(rootNode, tol, bmp);

            bmp.Dispose();
            return rootNode;
        }

        static void subDivide_Triangle(QTnodeTriangle root, double tol, Bitmap bmp)
        {
            if (checkFill_TriangleUp(root.triaUp, bmp) || checkFill_TriangleDown(root.triaDown, bmp))
            {

                double width = root.triaUp.width / 2;
                double height = root.triaUp.height / 2;

                if (width > tol && height > tol)
                {
                    //up
                    QTnodeTriangle n1 = new QTnodeTriangle(new TriangleModel(new PointModel(root.triaUp.origin.x, root.triaUp.origin.y), width, height), //up
                        new TriangleModel(new PointModel(root.triaUp.origin.x + width, root.triaUp.origin.y + height), width, height), //down
                        null, null, null, null);

                    QTnodeTriangle n2 = new QTnodeTriangle(new TriangleModel(new PointModel(root.triaUp.origin.x + width, root.triaUp.origin.y), width, height), //up
                        new TriangleModel(new PointModel(root.triaUp.origin.x + width + width, root.triaUp.origin.y + height), width, height), //down
                        null, null, null, null);

                    QTnodeTriangle n3 = new QTnodeTriangle(new TriangleModel(new PointModel(root.triaUp.origin.x, root.triaUp.origin.y + height), width, height),
                        new TriangleModel(new PointModel(root.triaUp.origin.x + width, root.triaUp.origin.y + height + height), width, height),
                        null, null, null, null);

                    QTnodeTriangle n4 = new QTnodeTriangle(new TriangleModel(new PointModel(root.triaUp.origin.x + width, root.triaUp.origin.y + height), width, height),
                        new TriangleModel(new PointModel(root.triaUp.origin.x + width + width, root.triaUp.origin.y + height + height), width, height),
                        null, null, null, null);


                    root.n1 = n1;
                    root.n2 = n2;
                    root.n3 = n3;
                    root.n4 = n4;


                    subDivide_Triangle(n1, tol, bmp);
                    subDivide_Triangle(n2, tol, bmp);
                    subDivide_Triangle(n3, tol, bmp);
                    subDivide_Triangle(n4, tol, bmp);
                }
            }
        }

        static bool checkFill_TriangleUp(TriangleModel tria, Bitmap bmp)
        {

            bool isMixed = false;
            bool isBlack = false;
            bool isWhite = false;
            int i = 0;
            double coef = tria.height / tria.width;
            for (int wi = (int)tria.origin.x; wi < (tria.origin.x + tria.width); wi++)
            {
                for (int hi = (int)tria.origin.y; hi < (tria.origin.y + tria.height-i*coef); hi++)
                {
                    if(hi<0 || hi > 376)
                    {
                        break;
                    }
                    Color pixelColor = bmp.GetPixel((int)wi, (int)hi);

                    if (pixelColor.R == 0 && (pixelColor.G == 0) && pixelColor.B == 0)
                        isBlack = true;

                    if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                        isWhite = true;

                    if (isBlack && isWhite)
                        return true;
                }
                i++;
            }
            return isMixed;
        }

        static bool checkFill_TriangleDown(TriangleModel tria, Bitmap bmp)
        {

            bool isMixed = false;
            bool isBlack = false;
            bool isWhite = false;
            int i = 0;
            double coef = tria.height / tria.width;
            for (int wi = (int)tria.origin.x; wi > (tria.origin.x - tria.width); wi--)
            {
                for (int hi = (int)tria.origin.y; hi > (tria.origin.y - tria.height+i*coef); hi--)
                {
                    if (hi < 0 || hi > 376)
                    {
                        break;
                    }
                    Color pixelColor = bmp.GetPixel((int)wi, (int)hi);

                    if (pixelColor.R == 0 && (pixelColor.G == 0) && pixelColor.B == 0)
                        isBlack = true;

                    if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                        isWhite = true;

                    if (isBlack && isWhite)
                        return true;
                }
                i++;
            }
            return isMixed;
        }

        /// <summary>
        /// leaves only figure shape mesh
        /// </summary>
        /// <param name="root"></param>
        /// <param name="bmp"></param>
        /// <param name="isBlack"></param>
        public static void onlyFigure_Triangle(QTnodeTriangle root, Bitmap bmp, bool isBlack)
        {
            bool redundant, black;
            //check upper triangle
            if (root.n1 != null && root.n1.triaUp != null)
            {
                (redundant, black) = isFigure_Triangle_Up(root.n1.triaUp, bmp);
                if (redundant && black == false) // is it redundant
                {
                    root.n1.triaUp = null;
                }
                else onlyFigure_Triangle(root.n1, bmp, black);
            }
            if (root.n2 != null && root.n2.triaUp != null)
            {
                (redundant, black) = isFigure_Triangle_Up(root.n2.triaUp, bmp);
                if (redundant && black == false) // is it redundant
                {
                    root.n2.triaUp = null;
                }
                else onlyFigure_Triangle(root.n2, bmp, black);
            }
            if (root.n3 != null && root.n3.triaUp != null)
            {
                (redundant, black) = isFigure_Triangle_Up(root.n3.triaUp, bmp);
                if (redundant && black == false) // is it redundant
                {
                    root.n3.triaUp = null;
                }
                else onlyFigure_Triangle(root.n3, bmp, black);
            }
            if (root.n4 != null && root.n4.triaUp != null)
            {
                (redundant, black) = isFigure_Triangle_Up(root.n4.triaUp, bmp);
                if (redundant && black == false) // is it redundant
                {
                    root.n4.triaUp = null;
                }
                else onlyFigure_Triangle(root.n4, bmp, black);
            }


            //check upper triangle
            if (root.n1 != null && root.n1.triaDown != null)
            {
                (redundant, black) = isFigure_Triangle_Down(root.n1.triaDown, bmp);
                if (redundant && black == false) // is it redundant
                {
                    root.n1.triaDown = null;
                }
                else onlyFigure_Triangle(root.n1, bmp, black);
            }
            if (root.n2 != null && root.n2.triaDown != null)
            {
                (redundant, black) = isFigure_Triangle_Down(root.n2.triaDown, bmp);
                if (redundant && black == false) // is it redundant
                {
                    root.n2.triaDown = null;
                }
                else onlyFigure_Triangle(root.n2, bmp, black);
            }
            if (root.n3 != null && root.n3.triaDown != null)
            {
                (redundant, black) = isFigure_Triangle_Down(root.n3.triaDown, bmp);
                if (redundant && black == false) // is it redundant
                {
                    root.n3.triaDown = null;
                }
                else onlyFigure_Triangle(root.n3, bmp, black);
            }
            if (root.n4 != null && root.n4.triaDown != null)
            {
                (redundant, black) = isFigure_Triangle_Down(root.n4.triaDown, bmp);
                if (redundant && black == false) // is it redundant
                {
                    root.n4.triaDown = null;
                }
                else onlyFigure_Triangle(root.n4, bmp, black);
            }

            //edge only
            if (root.n1 != null || root.n2 != null || root.n3 != null || root.n4 != null)
            {
                root.triaDown = null;
            }

        }

        static (bool, bool) isFigure_Triangle_Down(TriangleModel tria, Bitmap bmp)
        {
            bool isBlack = false;
            bool isWhite = false;
            int i = 0;
            double coef = tria.height / tria.width;
            for (int wi = (int)tria.origin.x; wi > (tria.origin.x - tria.width); wi--)
            {
                for (int hi = (int)tria.origin.y; hi > (tria.origin.y - tria.height + i * coef); hi--)
                {
                    if (hi < 0 || hi > 376)
                    {
                        break;
                    }
                    Color pixelColor = bmp.GetPixel((int)wi, (int)hi);

                    if (pixelColor.R == 0 && (pixelColor.G == 0) && pixelColor.B == 0)
                        isBlack = true;

                    if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                        isWhite = true;

                    if (isBlack && isWhite)
                        return (false,false);
                }
                i++;
            }
            if (isBlack) return (true, true); //redundant && all black
            return (true, false); //redundant && all white
        }

        static (bool, bool) isFigure_Triangle_Up(TriangleModel tria, Bitmap bmp)
        {
            bool isBlack = false;
            bool isWhite = false;
            int i = 0;
            double coef = tria.height / tria.width;
            for (int wi = (int)tria.origin.x; wi < (tria.origin.x + tria.width); wi++)
            {
                for (int hi = (int)tria.origin.y; hi < (tria.origin.y + tria.height - i * coef); hi++)
                {
                    if (hi < 0 || hi > 376)
                    {
                        break;
                    }
                    Color pixelColor = bmp.GetPixel((int)wi, (int)hi);

                    if (pixelColor.R == 0 && (pixelColor.G == 0) && pixelColor.B == 0)
                        isBlack = true;

                    if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                        isWhite = true;

                    if (isBlack && isWhite)
                        return (false,false);
                }
                i++;
            }
            if (isBlack) return (true, true); //redundant && all black
            return (true, false); //redundant && all white
        }
        //-------------------------------------------------------------------------------------------------------------------------------------\\QUAD TREE TRIANGLE



        //***************************** QUAD TREE BY POINTS **************************\\

        public static QTnode quadTreeGenerator_ByPoint(List<PointModel> points, double width, double height, double tol)
        {
            //init
            QTnode rootNode = new QTnode(new RectangleModel(new PointModel(0, 0), width, height), null, null, null, null);

            subDivide_ByPoint( rootNode, tol, points);
            return rootNode;
        }

        static void subDivide_ByPoint(QTnode root, double tol, List<PointModel> points)
        {
            root.points = checkFill_ByPoint(root.rect, points);
            if (root.points.Count > 4)
            {

                double width = root.rect.width / 2;
                double height = root.rect.height / 2;

                if (width > tol && height > tol )
                {

                    QTnode n1 = new QTnode(new RectangleModel(new PointModel(root.rect.origin.x, root.rect.origin.y), width, height), null, null, null, null);
                    QTnode n2 = new QTnode(new RectangleModel(new PointModel(root.rect.origin.x + width, root.rect.origin.y), width, height), null, null, null, null);
                    QTnode n3 = new QTnode(new RectangleModel(new PointModel(root.rect.origin.x, root.rect.origin.y + height), width, height), null, null, null, null);
                    QTnode n4 = new QTnode(new RectangleModel(new PointModel(root.rect.origin.x + width, root.rect.origin.y + height), width, height), null, null, null, null);

                    root.n1 = n1;
                    root.n2 = n2;
                    root.n3 = n3;
                    root.n4 = n4;

                    subDivide_ByPoint(n1, tol, points);
                    subDivide_ByPoint(n2, tol, points);
                    subDivide_ByPoint(n3, tol, points);
                    subDivide_ByPoint(n4, tol, points);
                }

            }

        }

        static List<PointModel> checkFill_ByPoint(RectangleModel rect, List<PointModel> points)
        {
            List<PointModel> output = new List<PointModel>();

            foreach (PointModel point in points)
            {
                if ((point.x >= (int)rect.origin.x) && (point.x <= ((int)rect.origin.x + rect.width)) &&
                 (point.y >= (int)rect.origin.y) && (point.y <= ((int)rect.origin.y + rect.height)))
                {
                    output.Add(point);
                }
            }

            //for (int wi = (int)rect.origin.x; wi < (rect.origin.x + rect.width); wi++)
            //{
            //    for (int hi = (int)rect.origin.y; hi < (rect.origin.y + rect.height); hi++)
            //    {
            //        foreach(PointModel point in points)
            //        {
            //            if (point.x == wi && point.y == hi)
            //            {
            //                output.Add(point);
            //            }
            //        }
            //    }
            //}
            return output;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------\\QUAD TREE BY POINTS




        //***************************** RAYCASTING **************************\\
        public static PointModel cast (LineModel l1,LineModel l2)
        {
            //x 
            double x1 = l1.A.x;
            double x2 = l1.B.x;
            double x3 = l2.A.x;
            double x4 = l2.B.x;

            //y
            double y1 = l1.A.y;
            double y2 = l1.B.y;
            double y3 = l2.A.y;
            double y4 = l2.B.y;

            double den = (x1-x2) * (y3 - y4) - (y1 - y2) * (x3-x4);
            if(den == 0)//parallel
            {
                return null;
            }
            double t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
            double u = -1*((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / den;

            if (t > 0 && t < 1 && u >= 0 && u<=1)
            {
                PointModel p = new PointModel(0,0);
                p.x = x1 + t * (x2 - x1);
                p.y = y1 + t * (y2 - y1);
                return p;
            }
            else
            {
                return null;
            }
        }

        public static PointModel CrossingPointerCramer(LineModel l1, LineModel l2)
        {
            double W, Wx, Wy, X, Y;
            double[] coefficient;
            PointModel output = new PointModel(0,0);

            ////////////////////////////GATHER DATA
            coefficient = SLE(l1);
            double A1 = coefficient[0]; //a
            int B1 = -1;
            double C1 = coefficient[1]; //b

            coefficient = SLE(l2);
            double A2 = coefficient[0]; //a
            int B2 = -1;
            double C2 = coefficient[1]; //b


            ////////////////////////////COMPUTE
            W = (A1 * B2 - B1 * A2);
            Wx = ((-C1) * B2 - B1 * (-C2));
            Wy = (A1 * (-C2) - (-C1) * A2);

            X = Wx / W;
            Y = Wy / W;

            output.x = X;
            output.y = Y;

            return output;
        }

        public static double[] SLE(LineModel line)
        {
            double a, b;
            double[] result = new double[2];
            if (line != null)
            {
                a = (line.A.y - line.B.y) / (line.A.x - line.B.x); //(y1 - y2) / (x1 - x2);
                b = line.A.y - a * line.A.x;  //y1 - a * x1;
                                              //Console.WriteLine("equation: y=" +a+"x+"+b);
                result[0] = a;
                result[1] = b;         
            }
            else
            {
                result[0] = 0;
                result[1] = 0;
            }
            return result;

        }

        public static LineModel LineRotation(LineModel input, double angle)
        {
            LineModel line = new LineModel(new PointModel(0,0), new PointModel(0, 0));

            //origin
            line.A.x = input.A.x;
            line.A.y = input.A.y;
            //point
            line.B.x = input.B.x;
            line.B.y = input.B.y;
           
            angle = (Math.PI / 180) * angle;
            line.B.x = ((input.B.x - input.A.x) * Math.Cos(angle) - (input.B.y - input.A.y) * Math.Sin(angle))+ input.A.x;
            line.B.y = ((input.B.y - input.A.y) * Math.Cos(angle) + (input.B.x - input.A.x) * Math.Sin(angle)) + input.A.y;

            return line;
        }

        public static List<PointModel> generateRandomPoints(int elements)
        {
            List<PointModel> randomPointsList = new List<PointModel>();
            Random random = new Random();
            for (int i = 0; i < elements; i++)
            {
                randomPointsList.Add(new PointModel(random.Next(0, 570), random.Next(0, 370)));
            }
            return randomPointsList;
        }
        public static List<LineModel> generateRandomLines(int elements)
        {
            List<LineModel> randomLinesList = new List<LineModel>();
            Random random = new Random();
            List<PointModel> randomPointsList = generateRandomPoints(elements*2);
            for (int i = 0; i < elements*2-1; i++)
            {
                randomLinesList.Add(new LineModel(randomPointsList[i], randomPointsList[i+1]));
                i++;
            }
            return randomLinesList;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------\\RAYCASTING

        //***************************** DITHERING **************************\\
        public static Bitmap dithering_GenerateMatrix(Image image)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap bmp = new Bitmap(image);
            for (int y = 0; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    Color pix = bmp.GetPixel(x, y);
                    int oldR = pix.R;
                    int oldG = pix.G;
                    int oldB = pix.B;
                    int factor = 2;
                    int newR = (int)(factor * oldR / 255) * (255 / factor);
                    int newG = (int)(factor * oldG / 255) * (255 / factor);
                    int newB = (int)(factor * oldB / 255) * (255 / factor);
                    bmp.SetPixel(x, y, Color.FromArgb(newR, newG, newB));

                    float errR = oldR - newR;
                    float errG = oldG - newG;
                    float errB = oldB - newB;


                    Color c = bmp.GetPixel(x + 1, y);
                    float r = c.R;
                    float g = c.G;
                    float b = c.B;
                    r = (r + errR * 7 / 16);
                    g = (g + errG * 7 / 16);
                    b = (b + errB * 7 / 16);
                    if(r<=255 && g<=255 && b<=255)
                    {
                        bmp.SetPixel(x + 1, y, Color.FromArgb((int)r, (int)g, (int)b));
                    }
                    


                    c = bmp.GetPixel(x - 1, y + 1);
                    r = c.R;
                    g = c.G;
                    b = c.B;
                    r = (r + errR * 3 / 16);
                    g = (g + errG * 3 / 16);
                    b = (b + errB * 3 / 16);
                    if (r <= 255 && g <= 255 && b <= 255)
                    {
                        bmp.SetPixel(x - 1, y + 1, Color.FromArgb((int)r, (int)g, (int)b));
                    }

                    c = bmp.GetPixel(x, y + 1);
                    r = c.R;
                    g = c.G;
                    b = c.B;
                    r = (r + errR * 5 / 16);
                    g = (g + errG * 5 / 16);
                    b = (b + errB * 5 / 16);
                    if (r <= 255 && g <= 255 && b <= 255)
                    {
                        bmp.SetPixel(x, y + 1, Color.FromArgb((int)r, (int)g, (int)b));
                    }


                    c = bmp.GetPixel(x + 1, y + 1);
                    r = c.R;
                    g = c.G;
                    b = c.B;
                    r = (r + errR * 1 / 16);
                    g = (g + errG * 1 / 16);
                    b = (b + errB * 1 / 16);
                    if (r <= 255 && g <= 255 && b <= 255)
                    {
                        bmp.SetPixel(x + 1, y + 1, Color.FromArgb((int)r, (int)g, (int)b));
                    }
                }
            }
            return bmp;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------\\RAYCASTING
    }



}
