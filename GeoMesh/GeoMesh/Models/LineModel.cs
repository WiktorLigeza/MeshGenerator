using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GeoMesh.Models
{
    [Serializable()]
    public class LineModel : ISerializable
    {
        /// <summary>
        /// Lines A point - PointModel
        /// </summary>
        public PointModel A;

        /// <summary>
        /// Lines B point - PointModel
        /// </summary>
        public PointModel B;


        
        public LineModel(PointModel A, PointModel B)
        {
            this.A = A;
            this.B = B;
        }

        /// <summary>
        /// displays coordinates eg. "A: 5, 6 | B: 7, 3"
        /// </summary>
        public string Display
        {
            get
            {
                return $"A: {A.x} {A.y} | B: {B.x} {B.y}";
            }
        }


        //serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("A", A);
            info.AddValue("B", B);
        }
        public LineModel(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the properties
            A = (PointModel)info.GetValue("A", typeof(PointModel));
            B = (PointModel)info.GetValue("B", typeof(PointModel));
        }
    }
}
