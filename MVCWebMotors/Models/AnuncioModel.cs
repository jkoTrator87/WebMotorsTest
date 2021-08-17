using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebMotors.Models
{
    public class AnuncioModel
    {
        public AnuncioModel()
        {
        }
        public List<Marca> Marcas { get; set; }
        public List<Modelo> Modelos { get; set; }
        public List<Versao> Versoes{ get; set; }
        public List<Anuncio> Anuncios{ get; set; }
    }
}