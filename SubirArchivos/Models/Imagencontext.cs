using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SubirArchivos.Models
{
    public class Imagencontext : DbContext
    {
        public DbSet<Imagen> Images { get; set; }
    }
}