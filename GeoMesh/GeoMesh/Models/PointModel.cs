using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GeoMesh.Models
{
    [Serializable()]
    public class PointModel : ISerializable
    {
        /// <summary>
        /// points x coordinate
        /// </summary>
        public double x;

        /// <summary>
        /// points y coordinate
        /// </summary>
        public double y;


        public PointModel(double x,double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// displays coordinates eg. x: 5, y:3
        /// </summary>
        public string Display
        {
            get
            {
                return $"x: {x}  , y:{y}";
            }
        }

        //serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", x);
            info.AddValue("y", y);
        }
        public PointModel(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the properties
            x = (double)info.GetValue("x", typeof(double));
            y = (double)info.GetValue("y", typeof(double));
        }
    }
}
