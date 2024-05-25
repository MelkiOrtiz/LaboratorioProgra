using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDBMySqlWF.Data.Models
{
    public class Consola
    {
        public int IdConsola { get; set; }
        public string NombreConsola { get; set; }
        public string Compania { get; set; }
        public int AnioLanzamiento { get; set; }
        public int Generacion { get; set; }

        // Constructor sin parámetros
        public Consola() { }

        // Constructor con parámetros
        public Consola(int idConsola, string nombreConsola, string compania, int anioLanzamiento, int generacion)
        {
            IdConsola = idConsola;
            NombreConsola = nombreConsola;
            Compania = compania;
            AnioLanzamiento = anioLanzamiento;
            Generacion = generacion;
        }
    }
}