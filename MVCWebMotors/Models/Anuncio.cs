using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebMotors.Models
{
    public class Anuncio
    {
        public int ID { get; set; }
        public string Color{ get; set; }
        public string KM { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string Version { get; set; }
        public int YearFab { get; set; }
        public int YearModel { get; set; }
        public string Obs { get; set; }
    }
}