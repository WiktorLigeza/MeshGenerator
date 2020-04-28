using System;
using System.Collections.Generic;
using System.Text;
//serialization
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using GeoMesh.Models;

namespace GeoMesh
{
    public class DataManager
    {
        public static void saveToCSV(string fileName,List<PointModel> matrix, List<LineModel> links)
        {
            string name;
            // save matrix to file
            name = fileName + "MATRIX" + ".csv";
            Stream stream = File.Open(name, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, matrix);
            stream.Close();

            //save links to file
            name = fileName + "LINKS" + ".csv";
            stream = File.Open(name, FileMode.Create);
            bf = new BinaryFormatter();
            bf.Serialize(stream, links);
            stream.Close();
        }

        public static (List<PointModel>,List<LineModel>) importFromCSV(string fileName)
        {
            string name;
            List<PointModel> matrix;
            List<LineModel> links;

            //import matrix
            name = fileName + "MATRIX" + ".csv";
            Stream stream = File.Open(name, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            matrix = (List<PointModel>)bf.Deserialize(stream);
            stream.Close();

            //import links
            name = fileName + "LINKS" + ".csv";
            stream = File.Open(name, FileMode.Open);
            bf = new BinaryFormatter();
            links = (List<LineModel>)bf.Deserialize(stream);
            stream.Close();

            return (matrix, links);
        }
    }
}
