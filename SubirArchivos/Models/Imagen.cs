using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubirArchivos.Models
{
    public class Imagen
    {
        public int id { get; set; }
        public String nombre{get; set;}
        public Byte[] img { get; set; }
    }
}