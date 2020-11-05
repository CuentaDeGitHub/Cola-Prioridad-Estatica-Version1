using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaPrioridadEstaticaImplementacion1
{
    class Datos
    {
        private int prioridad;
        public int Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        private string dato;
        public string Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public Datos()
        {
            Dato = "";
            Prioridad = -1;
        }
        public override string ToString()
        {
            return Dato;
        }
    }
}
