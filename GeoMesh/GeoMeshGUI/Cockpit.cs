using GeoMesh;
using GeoMesh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GeoMeshGUI
{
    public partial class Cockpit : Form
    {
        //***************************** INIT **************************\\
        float center_x;
        float center_y;
        float mouse_x;
        float mouse_y;
        int w;
        int h;
        int _x, _y, x, y;
        List<LineModel> links = new List<LineModel>();
        List<PointModel> matrix = new List<PointModel>();
        List<LineModel> walls;
        QTnode rootNode;
        QTnodeTriangle rootNode_Triangle;
        public Cockpit()
        {
            InitializeComponent();
            //setting center point of graph
            center_x = (graph.Width / 2)+3;
            center_y = (graph.Height / 2) +3;
            _x = 50;
            _y = 50;
            origin = graph.BackColor;
            w = graph.Width;
            h = graph.Height;
        }
        //graph rel
        Graphics g = null;
        Pen axis = new Pen(Color.DeepPink);
        Pen redLine = new Pen(Color.Red);
        Pen blueLine = new Pen(Color.LightBlue);
        Pen grayLine = new Pen(Color.Gray);
        Image image;
        Bitmap temp;
        string imPath;
        Color origin;
        bool set = true;
        bool setQTP = false; //quad tree by points
        bool setQTS = false; //quad tree by seed
        bool raycasting = false;
        List<PointModel> pointsQTP;
        //-------------------------------------------------------------------------------------------------------------------------------------\\INIT



        //***************************** GRAPH **************************\\

        /// <summary>
        /// init graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graph_Paint(object sender, PaintEventArgs e)
        { 
            g = graph.CreateGraphics();
            if (set) { setGraph(); }
            if (setQTP)
            {
                putSubdivision_ByPoints(pointsQTP);
            }
            else 
            if (raycasting)
            {
                putRaycasting();
            }
            
        }
        private Pen setPenColor(string color)
        {
            Pen NewLinePen;
            //set color
            if (color == "green")
            {
                NewLinePen = new Pen(Color.Green, 1);
            }
            else if (color == "red")
            {
                NewLinePen = new Pen(Color.Red, 1);
            }
            else if (color == "pink")
            {
                NewLinePen = new Pen(Color.DeepPink, 1);
            }
            else if (color == "cyan")
            {
                NewLinePen = new Pen(Color.Cyan, 1);
            }
            else
            {
                NewLinePen = new Pen(Color.Black, 1);
            }
            return NewLinePen;
        }

        public void setGraph()
        {
            graph.BackColor = origin;
            axis.Width = 2;
            g.DrawLine(axis, 3, graph.Height - 3, graph.Width - 3, graph.Height - 3); //x
            g.DrawLine(axis, 3, 3, 3, graph.Height - 3); //y

            center_x = 0;
            center_y = -1 * graph.Height + 6;
        }
        /// <summary>
        /// show mouse coordinates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graph_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;

            if (set == false)
            {
                labelAxis.Text = ("X: " + (mouse_x) + "   Y: " + -1 * (mouse_y - graph.Height));
            }
            else
            {
                labelAxis.Text = ("X: " + (mouse_x - 3) + "   Y: " + -1 * (mouse_y - graph.Height + 3));
            }
        }

        // custom drawing
        /// <summary>
        /// puts single point on canvas
        /// </summary>
        /// <param name="newPoint"></param>
        /// <param name="color"></param>
        public void putPoint(PointModel newPoint, string color)
        {
            // newPointsList.Add(newPoint);
            if (color == "green")
            {
                g.FillEllipse(
                Brushes.Green,
                (float)newPoint.x + center_x,
                -1 * (float)newPoint.y-center_y,
                 5,
                 5);
            }
            else if (color == "red")
            {
                g.FillEllipse(
               Brushes.Red,
               (float)newPoint.x + center_x,
               -1 * (float)newPoint.y - center_y,
                5,
                5);
            }
            else if (color == "pink")
            {
                g.FillEllipse(
               Brushes.DeepPink,
               (float)newPoint.x + center_x,
               -1 * (float)newPoint.y - center_y,
                5,
                5);
            }
            else
            {
                g.FillEllipse(
               Brushes.Black,
               (float)newPoint.x + center_x,
               -1 * (float)newPoint.y - center_y,
                5,
                5);
            }

        }

        /// <summary>
        /// puts single line on canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void putLine(LineModel line, string color)
        {
            Pen NewLinePen;
            //set color
            if (color == "green")
            {
                NewLinePen = new Pen(Color.Green, 1);
            }
            else if (color == "red")
            {
                NewLinePen = new Pen(Color.Red, 1);
            }
            else if (color == "pink")
            {
                NewLinePen = new Pen(Color.DeepPink, 1);
            }
            else if (color == "gray")
            {
                NewLinePen = new Pen(Color.LightGray, 1);
            }
            else if (color == "white")
            {
                NewLinePen = new Pen(Color.AntiqueWhite, 1);
            }
            else
            {
                NewLinePen = new Pen(Color.Black, 1);
            }

            //draw line
            if (line != null)
            {
                //newLinesList.Add(line);
                g.DrawLine(
                 NewLinePen,
                 (float)line.A.x + center_x + 3,
                 -1 * (float)line.A.y - center_y + 3,
                (float)line.B.x + center_x + 3,
                  -1 * (float)line.B.y - center_y + 3);
            }
        }

        /// <summary>
        /// matrix of points
        /// </summary>
        /// <param name="matrix"></param>
        public void putMatrix(List<PointModel> matrix, int delay)
        {
            foreach(PointModel point in matrix)
            {
                System.Threading.Thread.Sleep(delay);
                putPoint(point, "green");
            }
        }

        /// <summary>
        /// puts mesh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void putMesh(List<LineModel> links,int delay)
        {
            foreach(LineModel link in links)
            {
                System.Threading.Thread.Sleep(delay);
                putLine(link, "pink");
            }
        }

        /// <summary>
        /// puts new poligon
        /// </summary>
        /// <param name="PolygonVertices"></param>
        /// <param name="color"></param>
        public void putPolygon(List<PointModel> PolygonVertices, string color)
        {
            for (int i = 0; i < PolygonVertices.Count - 1; i++)
            {
                System.Threading.Thread.Sleep(50);
                g.DrawLine(
                setPenColor(color),
                 (float)PolygonVertices[i].x + center_x + 3,
                 -1 * (float)PolygonVertices[i].y - center_y +3,
                 (float)PolygonVertices[i + 1].x + center_x +3,
                 -1 * (float)PolygonVertices[i + 1].y - center_y + 3);
            }
            System.Threading.Thread.Sleep(50);
            g.DrawLine(
                 setPenColor(color),
                 (float)PolygonVertices[0].x + center_x +3 ,
                 -1 * (float)PolygonVertices[0].y - center_y + 3,
                 (float)PolygonVertices[PolygonVertices.Count - 1].x + center_x + 3,
                 -1 * (float)PolygonVertices[PolygonVertices.Count - 1].y - center_y + 3);
        }

        /// <summary>
        /// puts QT mesh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void putSubdivision(QTnode root,int delay, string color)
        {
            System.Threading.Thread.Sleep(delay);
            if (root.rect!=null)
            {
                //put diagonal
                // g.DrawLine(
                //new Pen(Color.DeepPink, 1),
                //(int)root.rect.origin.x + (float)root.rect.width, (int)root.rect.origin.y,
                // (float)root.rect.origin.x, (float)root.rect.origin.y + (float)root.rect.height);

                //put traingle
                //Point[] triangle = new Point[] { new Point((int)root.rect.origin.x, (int)root.rect.origin.y),
                //    new Point((float)root.rect.origin.x, (float)root.rect.origin.y,
                //    new Point((int)root.rect.origin.x+(int)root.rect.width, (int)root.rect.origin.y) };
                //g.DrawPolygon(new Pen(Color.Cyan, 1), triangle);

                if (graph.BackgroundImage != null)
                {
                    using (Graphics g = Graphics.FromImage(graph.BackgroundImage))
                    {
                        //put rectangle
                        g.DrawRectangle(setPenColor(color), (float)root.rect.origin.x, (float)root.rect.origin.y,
                           (float)root.rect.width, (float)root.rect.height);
                    }
                } 
                else
                {
                    g.DrawRectangle(setPenColor(color), (float)root.rect.origin.x, (float)root.rect.origin.y,
                              (float)root.rect.width, (float)root.rect.height);
                }

                //matrix
            //    g.FillEllipse(
            //Brushes.Cyan,
            //(float)(float)root.rect.origin.x-1,
            // (float)root.rect.origin.y-1,
            // 2,
            // 2);
            }
            


            if (root.n1 != null)
                putSubdivision(root.n1,delay,color);
            if (root.n2 != null)
                putSubdivision(root.n2,delay,color);
            if (root.n3 != null)
                putSubdivision(root.n3,delay,color);
            if (root.n4 != null)
                putSubdivision(root.n4,delay,color);
        }

        public void putSubdivision_Triangle(QTnodeTriangle root, int delay, string color)
        {
            System.Threading.Thread.Sleep(delay);
            if (root.triaUp != null)
            {
                using (Graphics g = Graphics.FromImage(graph.BackgroundImage))
                {
                    Point[] triangleUp = new Point[] {
                    new Point((int)root.triaUp.origin.x, (int)root.triaUp.origin.y),
                    new Point((int)root.triaUp.origin.x + (int)root.triaUp.width, (int)root.triaUp.origin.y),
                    new Point((int)root.triaUp.origin.x, (int)root.triaUp.origin.y + (int)root.triaUp.height) };
                    g.DrawPolygon(new Pen(Color.DeepPink, 1), triangleUp);
                }
               
            }
            if (root.triaDown != null )
            {
                using (Graphics g = Graphics.FromImage(graph.BackgroundImage))
                {
                    Point[] triangleDown = new Point[] {
                    new Point((int)root.triaDown.origin.x, (int)root.triaDown.origin.y),
                    new Point((int)root.triaDown.origin.x - (int)root.triaDown.width, (int)root.triaDown.origin.y),
                    new Point((int)root.triaDown.origin.x, (int)root.triaDown.origin.y - (int)root.triaDown.height) };
                    g.DrawPolygon(new Pen(Color.Cyan, 1), triangleDown);
                }

            }



            if (root.n1 != null)
                putSubdivision_Triangle(root.n1, delay, color);
            if (root.n2 != null)
                putSubdivision_Triangle(root.n2, delay, color);
            if (root.n3 != null)
                putSubdivision_Triangle(root.n3, delay, color);
            if (root.n4 != null)
                putSubdivision_Triangle(root.n4, delay, color);
        }

        public void putRaycasting()
        {
            PointModel mouse_position = new PointModel(mouse_x, -1 * (mouse_y - graph.Height));
            LineModel rayGen = new LineModel(mouse_position, new PointModel(mouse_x + 500, -1 * (mouse_y - graph.Height)));

            foreach (LineModel wall in walls)
            {

                g.DrawLine(
                new Pen(Color.DeepPink, 3),
               (float)wall.A.x + center_x + 3,
               -1 * (float)wall.A.y - center_y + 3,
              (float)wall.B.x + center_x + 3,
                -1 * (float)wall.B.y - center_y + 3);
                
            }

            for (int i = 0; i <= 360; i += 3)
            {
                LineModel ray = Engine.LineRotation(rayGen, i);
                //PointModel p = null;
                foreach (LineModel wall in walls)
                {
                    PointModel c = Engine.cast(ray, wall);
                    if(c !=null )
                    {
                        ray.B = c;
                    }

                }
                //draw ray
                    g.DrawLine(
                    new Pen(Color.Cyan, 1),
                   (float)ray.A.x + center_x + 3,
                   -1 * (float)ray.A.y - center_y + 3,
                  (float)ray.B.x + center_x + 3,
                    -1 * (float)ray.B.y - center_y + 3);
            }
            //System.Threading.Thread.Sleep(100);
        }

        public void putSubdivision_ByPoints(List<PointModel> points)
        {
            Rectangle rect = new Rectangle(0, 0, graph.Width, graph.Height);
            g.FillRectangle(Brushes.Black, rect);
            foreach (PointModel point in points)
            {
                g.FillEllipse(
                      Brushes.DeepPink,
                      (float)point.x - 1,
                       (float)point.y - 1,
                       3, 3);
            }
            rootNode = Engine.quadTreeGenerator_ByPoint(points, graph.Width, graph.Height, 3);
            putSubdivision(rootNode, 0, "cyan");

        }

        void putConvexHull(List<PointModel> list)
        {
            LineModel line = new LineModel(new PointModel(0,0), new PointModel(0, 0));

            //set initial
            list.Sort((a, b) => a.x == b.x ? a.y.CompareTo(b.y) : a.x.CompareTo(b.x));

            double initialX = list[0].x;
            double initialY = list[0].y;
            List<PointModel> hull = Engine.GetHull(list);
            for (int i = 0; i < hull.Count - 1; i++)
            {
                line.A = hull[i];
                line.B = hull[i + 1];
                g.DrawLine(
                new Pen(Color.DeepPink, 3),
               (float)line.A.x + center_x + 3,
               -1 * (float)line.A.y - center_y + 3,
              (float)line.B.x + center_x + 3,
                -1 * (float)line.B.y - center_y + 3);
            }
            line.A = hull[0];
            line.B = hull[hull.Count - 1];
            g.DrawLine(
            new Pen(Color.DeepPink, 3),
           (float)line.A.x + center_x + 3,
           -1 * (float)line.A.y - center_y + 3,
          (float)line.B.x + center_x + 3,
            -1 * (float)line.B.y - center_y + 3);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------\\GRAPH



        //***************************** BUTTONS **************************\\
        // mesh
        private void TRIANGULARbutton_Click(object sender, EventArgs e)
        {
            refreshGraph(true);
            if (validate())
            {
                graph.Refresh();
                //compute
                matrix = Engine.generateMatrix(x, y, graph.Height - 6, graph.Width - 6);
                links = Engine.generateMesh("TRIANGULAR", matrix, x, y);

                //display
                putMatrix(matrix,0);
                putMesh(links,0);
                putMatrix(matrix,0);
            }
        }

        private void QUADRANGULRbutton_Click(object sender, EventArgs e)
        {
            refreshGraph(true);
            if (validate())
            {
                graph.Refresh();
                //compute
                matrix = Engine.generateMatrix(x, y, graph.Height - 6, graph.Width - 6);
                links = Engine.generateMesh("QUADRANGULR", matrix, x, y);

                //display
                putMatrix(matrix,0);
                putMesh(links,0);
                putMatrix(matrix,0);
            }
        }

        // QT
        private void QTbutton_Click(object sender, EventArgs e)
        {
            refreshGraph(false);
            try
            {
                rootNode = null;
               

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int tolerance = 3; //default
                    CustomDialogBox tol = new CustomDialogBox("tolerance", "E N G A G E");
                    if (tol.ShowDialog() == DialogResult.OK)
                    {
                        int.TryParse(tol.fileName, out tolerance);
                    }

                    // get path
                    var filePath = dialog.FileName;

                    //add picture
                    image = Image.FromFile(filePath);
                    graph.BackgroundImage = image;

                    //generate QT
                    rootNode = Engine.quadTreeGenerator(image,graph.Width,graph.Height,tolerance); //rectangle

                    //putSubdivision(rootNode,0); 
                    Bitmap bmp = new Bitmap(image);

                    ///rect
                    Engine.onlyFigure(rootNode, bmp, false); //only fig
                    // Engine.deleteRedundant(rootNode, bmp); 
                    putSubdivision(rootNode, 0, "pink");
                    graph.Refresh();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msg = new CustomMessageBox(ex.ToString());
                msg.Show();
            }
        }

        private void QTTbutton_Click(object sender, EventArgs e)
        {
            refreshGraph(false);
            try
            {
                rootNode_Triangle = null;
                refreshGraph(false);

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int tolerance = 3; //default
                    CustomDialogBox tol = new CustomDialogBox("tolerance", "E N G A G E");
                    if (tol.ShowDialog() == DialogResult.OK)
                    {
                        int.TryParse(tol.fileName, out tolerance);
                    }

                    // get path
                    var filePath = dialog.FileName;

                    //add picture
                    image = Image.FromFile(filePath);
                    graph.BackgroundImage = image;

                    //generate QT
                    rootNode_Triangle = Engine.quadTreeGenerator_Triangle(image, graph.Width - 1, graph.Height, tolerance); //triangle

                    Bitmap bmp = new Bitmap(image);
                    Engine.onlyFigure_Triangle(rootNode_Triangle, bmp, false); //only fig
                    putSubdivision_Triangle(rootNode_Triangle, 0, "pink");
                    graph.Refresh();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msg = new CustomMessageBox(ex.ToString());
                msg.Show();
            }
        }

        private void QTPbutton_Click(object sender, EventArgs e)
        {
            refreshGraph(false);
            graph.BackColor = Color.Black;
            setQTP = true;
            set = false;
            pointsQTP = Engine.generateRandomPoints(200);
            graph.Refresh();

        }

        private void SEEDbutton1_Click(object sender, EventArgs e)
        {
            refreshGraph(false);
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp;";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    CustomMessageBox tol = new CustomMessageBox("cilck on seed");
                    if (tol.ShowDialog() == DialogResult.OK)
                    {
                    }

                    // get path
                    var filePath = dialog.FileName;
                    imPath = filePath;
                    image = Image.FromFile(imPath);
                    graph.BackgroundImage = image;
                    graph.Width = image.Width;
                    graph.Height = image.Height;
                    //add picture
                    setQTS = true;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msg = new CustomMessageBox(ex.ToString());
                msg.Show();
            }
        }

        // test
        private void RHOMBULARbutton_Click(object sender, EventArgs e)
        {
            refreshGraph(true);
            if (validate())
            {
                List<PointModel> PolygonVertices = new List<PointModel>();
                // dummy rhombus
                PolygonVertices.Add(new PointModel(100, 100));
                PolygonVertices.Add(new PointModel(300, 100));
                PolygonVertices.Add(new PointModel(350, 200));
                PolygonVertices.Add(new PointModel(150, 200));
                putPolygon(PolygonVertices,"pink");

                
                //compute
                matrix = Engine.figureMatrixGenerator(PolygonVertices, x, y);
                links = Engine.generateMesh("TRIANGULAR", matrix, x, y);

                //display
                putMatrix(matrix,0);
                putMesh(links,0);
                
                putPolygon(PolygonVertices, "cyan");
                putMatrix(matrix, 0);
            }
        }

        private void TRAPEZOIDALbutton_Click(object sender, EventArgs e)
        {
            refreshGraph(true);
            if (validate())
            {
                List<PointModel> PolygonVertices = new List<PointModel>();
                // dummy rhombus
                PolygonVertices.Add(new PointModel(100, 100));
                PolygonVertices.Add(new PointModel(300, 100));
                PolygonVertices.Add(new PointModel(250, 200));
                PolygonVertices.Add(new PointModel(150, 200));
                putPolygon(PolygonVertices, "pink");


                //compute
                matrix = Engine.figureMatrixGenerator(PolygonVertices, x, y);
                links = Engine.generateMesh("TRIANGULAR", matrix, x, y);

                //display
                putMatrix(matrix, 0);
                putMesh(links, 0);

                putPolygon(PolygonVertices, "cyan");
                putMatrix(matrix, 0);
            }
        }

        private void RAYCASTINGutton_Click_1(object sender, EventArgs e)
        {
            refreshGraph(true);
            graph.BackColor = Color.Black;
            raycasting = true;
            set = false;
            walls = Engine.generateRandomLines(3);
            //List<LineModel> bounds = new List<LineModel>
            //{ 
            //    (new LineModel(new PointModel(0, 0), new PointModel(0, graph.Height-6))),
            //    (new LineModel(new PointModel(0, graph.Height-6), new PointModel(graph.Width-6, graph.Height-6))),
            //    (new LineModel(new PointModel(graph.Width-6, graph.Height-6), new PointModel(graph.Width-6, 0))),
            //    (new LineModel(new PointModel(graph.Width-6, 0), new PointModel(0, 0))),

            //};
            //walls.AddRange(bounds);

        }

        private void DITHERINGbutton1_Click(object sender, EventArgs e)
        {
            raycasting = false;
            setQTP = false;
            rootNode = null;
            refreshGraph(false);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // get path
                var filePath = dialog.FileName;

                //result
                (List<PointModel> matrix, Bitmap bmp)  = Engine.dithering_GenerateMatrix(Image.FromFile(filePath),graph.Width,graph.Height);
                graph.BackgroundImage = bmp;
                graph.Refresh();
            }
        }

        // data
        private void SAVEbutton_Click(object sender, EventArgs e)
        {
            if(setQTS == true )
            {

                //get file name
                CustomDialogBox saveAs = new CustomDialogBox("SAVE AS", "S A V E");
                if (saveAs.ShowDialog() == DialogResult.OK)
                {
                    temp.Save(saveAs.fileName, ImageFormat.Png);
                    CustomMessageBox msg = new CustomMessageBox("S-A-V-E-D");
                    msg.Show();
                    temp.Dispose();
                }
            }
            else if (setQTS==false && matrix.Count > 0 && links.Count > 0)
            {
                //get file name
                CustomDialogBox saveAs = new CustomDialogBox("SAVE AS", "S A V E");
                if (saveAs.ShowDialog() == DialogResult.OK)
                {
                    DataManager.saveToCSV(saveAs.fileName, matrix, links);
                    CustomMessageBox msg = new CustomMessageBox("S-A-V-E-D");
                    msg.Show();
                }
               
            }
            else
            {
                CustomMessageBox msg = new CustomMessageBox("NOTHING TO SAVE");
                msg.Show();
            }
           
        }

        private void OPENbutton_Click(object sender, EventArgs e)
        {
            CustomDialogBox saveAs = new CustomDialogBox("FILE NAME", "O P E N ");
            if (saveAs.ShowDialog() == DialogResult.OK)
            {
                refreshGraph(false);
                (matrix,links) = DataManager.importFromCSV(saveAs.fileName);
                //show imported
                putMatrix(matrix,10);
                putMesh(links,10);
                putMatrix(matrix,5);
            }
        }

     








        //-------------------------------------------------------------------------------------------------------------------------------------\\BUTTONS



        //***************************** ACTION && TIMERS **************************\\
        bool validate()
        {
            bool output = true;
            if (!int.TryParse(textBoxX.Text, out x))
            {
                output = false;
            }
            if (!int.TryParse(textBoxY.Text, out y))
            {
                output = false;
            }
            if(output == false)
            {
                CustomMessageBox msg = new CustomMessageBox("PLEASE ENTER X AND Y NUMBER");
                msg.Show();
            }
            return output;
        }

        private void graph_MouseDown(object sender, MouseEventArgs e)
        {
            if (setQTP)
            {
                pointsQTP.Add(new PointModel(mouse_x, mouse_y));
                graph.Refresh();
            }
            if(setQTS)
            {
                image = Image.FromFile(imPath);
                graph.BackgroundImage = image;
                graph.Width = image.Width;
                graph.Height = image.Height;

                Bitmap bmp = new Bitmap(image);
                Color pixColor = bmp.GetPixel(e.X, e.Y);
                int tolerance = 1; //default
                CustomDialogBox tol = new CustomDialogBox("tolerance", "E N G A G E");
                if (tol.ShowDialog() == DialogResult.OK)
                {
                    int.TryParse(tol.fileName, out tolerance);
                }

                //rootNode = Engine.quadTreeGenerator_Seed(bmp, im.Width, im.Height, 2, pixColor); //rectangle
                //Engine.onlyFigure_Seed(rootNode, bmp, pixColor); //only fig



                rootNode_Triangle = Engine.quadTreeGenerator_Triangle_Seed(bmp, image.Width, image.Height, tolerance, pixColor); //triangle
                Engine.onlyFigure_Triangle_Seed(rootNode_Triangle, bmp, pixColor); //only fig



                //putSubdivision(rootNode, 0, "red");
                putSubdivision_Triangle(rootNode_Triangle, 0, "pink");
                graph.DrawToBitmap(bmp, new Rectangle(0, 0, image.Width, image.Height));
                temp = bmp;
                //bmp.Dispose();
                graph.Refresh();

            }
        }

        public void refreshGraph(bool setGraph)
        {
            set = setGraph;
            setQTP = false;
            setQTS = false;

            graph.Width = w;
            graph.Height = h;

            
            graph.BackgroundImage = null;
            raycasting = false;
            graph.BackColor = origin;
            graph.Refresh();
        }

        //timers
        private void tmrMoving_Tick(object sender, EventArgs e)
        {
            if (raycasting)
            {
                graph.Refresh();
            }
        }

        private void tmrQTP_Tick(object sender, EventArgs e)
        {
            if (setQTP)
            {
                tmrQTP.Interval = 1000;
                Random random = new Random();
                foreach (PointModel point in pointsQTP)
                {
                    int direction = random.Next(0, 4);
                    switch (direction)
                    {
                        case 1: { point.x += random.Next(0, 10); break; }
                        case 2: { point.y += random.Next(0, 10); break; }
                        case 3: { point.x -= random.Next(0, 10); break; }
                        case 4: { point.y -= random.Next(0, 10); break; }
                    }
                }
                graph.Refresh();
            }
        }

    }
        //-------------------------------------------------------------------------------------------------------------------------------------\\ACTION
    
}









//temp = new PictureBox();
//graph.Controls.Add(temp);
//temp.Width = graph.Width-6;
//temp.Height = graph.Height-6;
//temp.BorderStyle = BorderStyle.FixedSingle;
//temp.Top = Math.Abs(temp.Bottom - graph.Height) -3;
//temp.Left = 3;
//temp.Image = Image.FromFile(filePath);
//temp.Visible = true;