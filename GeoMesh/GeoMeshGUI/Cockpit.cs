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
    public partial class Cockpit : Form
    {
        //***************************** INIT **************************\\
        float center_x;
        float center_y;
        int x, y;
        List<LineModel> links = new List<LineModel>();
        List<PointModel> matrix = new List<PointModel>();
        QTnode rootNode;
        public Cockpit()
        {
            InitializeComponent();
            //setting center point of graph
            center_x = (graph.Width / 2)+3;
            center_y = (graph.Height / 2) +3;
        }

        //***************************** GRAPH **************************\\
        Graphics g = null;
        Pen axis = new Pen(Color.DeepPink);
        Pen redLine = new Pen(Color.Red);
        Pen blueLine = new Pen(Color.LightBlue);
        Pen grayLine = new Pen(Color.Gray);
        Image image;
        bool set = true;
        bool setQT = false;
   

        /// <summary>
        /// init graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graph_Paint(object sender, PaintEventArgs e)
        {
            g = graph.CreateGraphics();
            if (set) { setGraph(); }
            if (setQT)
            {
               //putSubdivision(rootNode,0); 
                Bitmap bmp = new Bitmap(image);
                Engine.deleteRedundant(rootNode, bmp);
                putSubdivision(rootNode, 0);
            }
            
        }

        public void setGraph()
        {
            axis.Width = 2;
            g.DrawLine(axis, 3, graph.Height - 3, graph.Width - 3, graph.Height - 3); //x
            g.DrawLine(axis,3, 3, 3, graph.Height - 3); //y

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
            if(set == false)
            {
                labelAxis.Text = ("X: " + (e.X) + "   Y: " + -1 * (e.Y - graph.Height));
            }
            else
            {
                labelAxis.Text = ("X: " + (e.X - 3) + "   Y: " + -1 * (e.Y - graph.Height + 3));
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
                NewLinePen = new Pen(Color.Green, 2);
            }
            else if (color == "red")
            {
                NewLinePen = new Pen(Color.Red, 2);
            }
            else if (color == "pink")
            {
                NewLinePen = new Pen(Color.DeepPink, 2);
            }
            else if (color == "gray")
            {
                NewLinePen = new Pen(Color.LightGray, 2);
            }
            else
            {
                NewLinePen = new Pen(Color.Black, 2);
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
            Pen NewLinePen;
            //set color
            if (color == "green")
            {
                NewLinePen = new Pen(Color.Green, 2);
            }
            else if (color == "red")
            {
                NewLinePen = new Pen(Color.Red, 2);
            }
            else if (color == "pink")
            {
                NewLinePen = new Pen(Color.DeepPink, 2);
            }
            else if (color == "cyan")
            {
                NewLinePen = new Pen(Color.Cyan, 2);
            }
            else
            {
                NewLinePen = new Pen(Color.Black, 2);
            }


            for (int i = 0; i < PolygonVertices.Count - 1; i++)
            {
                System.Threading.Thread.Sleep(50);
                g.DrawLine(
                 NewLinePen,
                 (float)PolygonVertices[i].x + center_x + 3,
                 -1 * (float)PolygonVertices[i].y - center_y +3,
                 (float)PolygonVertices[i + 1].x + center_x +3,
                 -1 * (float)PolygonVertices[i + 1].y - center_y + 3);
            }
            System.Threading.Thread.Sleep(50);
            g.DrawLine(
                 NewLinePen,
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
        public void putSubdivision(QTnode root,int delay)
        {
            System.Threading.Thread.Sleep(delay);
            if (root.rect!=null)
            {
                //put diagonal
                g.DrawLine(
               new Pen(Color.DeepPink, 1),
               (int)root.rect.origin.x + (float)root.rect.width, (int)root.rect.origin.y,
                (float)root.rect.origin.x, (float)root.rect.origin.y+ (float)root.rect.height);

                //put traingle
                //Point[] triangle = new Point[] { new Point((int)root.rect.origin.x, (int)root.rect.origin.y),
                //    new Point((float)root.rect.origin.x, (float)root.rect.origin.y,
                //    new Point((int)root.rect.origin.x+(int)root.rect.width, (int)root.rect.origin.y) };
                //g.DrawPolygon(new Pen(Color.Cyan, 1), triangle);

                //put rectangle
                g.DrawRectangle(new Pen(Color.DeepPink, 1), (float)root.rect.origin.x, (float)root.rect.origin.y,
                   (float)root.rect.width, (float)root.rect.height);

            }
            

            if (root.n1 != null)
                putSubdivision(root.n1,delay);
            if (root.n2 != null)
                putSubdivision(root.n2,delay);
            if (root.n3 != null)
                putSubdivision(root.n3,delay);
            if (root.n4 != null)
                putSubdivision(root.n4,delay);
        }

        //***************************** BUTTONS **************************\\
        // mesh
        private void TRIANGULARbutton_Click(object sender, EventArgs e)
        {
            refreshGraph(true, false);
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
            refreshGraph(true,false);
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

        private void QTbutton_Click(object sender, EventArgs e)
        {
            try
            {
                refreshGraph(false, false);

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
                    rootNode = Engine.quadTreeGenerator(image,graph.Width,graph.Height,tolerance);
                    setQT = true;
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
            if (validate())
            {
                graph.Refresh();
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
            if (validate())
            {
                graph.Refresh();
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

        // other
        private void SAVEbutton_Click(object sender, EventArgs e)
        {
            string fileName = "default";
            
            if (matrix.Count > 0 && links.Count > 0)
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
                graph.Refresh();
               (matrix,links) = DataManager.importFromCSV(saveAs.fileName);
                //show imported
                putMatrix(matrix,10);
                putMesh(links,10);
                putMatrix(matrix,5);
            }
        }

      


        //***************************** ACTION **************************\\
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

        private void graph_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(image);
            Color pixelColor = bmp.GetPixel(e.X, e.Y);
            CustomMessageBox msg = new CustomMessageBox(pixelColor.ToString());
            msg.Show();
        }

        public void refreshGraph(bool setGraph,bool setQTT)
        {
            set = setGraph;
            setQT = setQTT;
            graph.Refresh();
            graph.BackgroundImage = null;

        }
    }
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