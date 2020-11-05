using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaPrioridadEstaticaImplementacion1
{
    class ColaPrioridad
    {
        private int tail;
        public int Tail
        {
            get { return tail; }
            set { tail = value; }
        }
        private int head;
        public int Head
        {
            get { return head; }
            set { head = value; }
        }
        private int maximo;
        public int Maximo
        {
            get { return maximo; }
            set { maximo = value; }
        }
        public Datos[] colaPrioridad;

        public ColaPrioridad(int Tamaño)
        {
            Maximo = Tamaño;
            colaPrioridad = new Datos[Maximo];
            Tail = Head = -1;
        }
        public bool EstaVacia()
        {
            if (Head == -1) return true;
            else return false;
        }
        public bool EstaLlena()
        {
            if (Tail == Maximo - 1)
            {
                return true;
            }
            return false;
        }
        public void Encolar(Datos d)
        {
            if (EstaLlena())
            {
                MessageBox.Show("La cola esta llena");
                return;
            }
            if (EstaVacia())
            {
                head = tail = 0;
                colaPrioridad[head] = d;
                return;
            }
            else
            {
                if (colaPrioridad[head].Prioridad < d.Prioridad)
                {
                    tail++;
                    int contador = tail;
                    for (int i = 0; i < tail; i++)
                    {
                        colaPrioridad[contador] = colaPrioridad[--contador];
                    }
                    colaPrioridad[head] = d;
                    return;
                }
                if (colaPrioridad[tail].Prioridad > d.Prioridad || colaPrioridad[tail].Prioridad == d.Prioridad)
                {
                    colaPrioridad[++tail] = d;
                    return;
                }
                else
                {
                    int posicionactual = 0;
                    tail++;
                    int indice = tail;
                    
                    while (colaPrioridad[posicionactual].Prioridad > d.Prioridad)
                    {
                        posicionactual++;
                    }
                    for (int i = 0; i < (tail - posicionactual); i++)
                    {
                        colaPrioridad[indice] = colaPrioridad[--indice];
                        
                    }
                    colaPrioridad[posicionactual] = d;
                    return;
                }

            }
        }
        public void Desencolar()
        {
            if (EstaVacia())
            {
                return;
            }
            if (tail == 0)
            {
                colaPrioridad[tail] = null;
                head = tail = -1;
                return;
            }
            int contador = 0;
            for (int i = 0; i < tail; i++)
            {
                colaPrioridad[contador] = colaPrioridad[++contador];
            }
            colaPrioridad[tail] = null;
            tail--;
        }
        public void IncrementarPrioridad()
        {
            try
            {
                int PrioridadMaximo = colaPrioridad[Head].Prioridad;
                int contador = 0;
                while (colaPrioridad[contador].Prioridad == PrioridadMaximo)
                {
                    contador++;
                }
                int Uhhh = (Tail - contador) + 1;
                for (int i = 0; i < Uhhh; i++)
                {
                    colaPrioridad[contador].Prioridad++;
                    contador++;
                }
            }
            catch
            {
                return;
            }
            
        }
        public string ImprimirDatos()
        {
            string colaString = "";
            if (EstaVacia())
            {
                return "La cola esta vacia";
            }
            else
            {
                colaString += colaPrioridad[Head].Dato;
                for (int i = 0; i < Tail; i++)
                {
                    colaString += "," + colaPrioridad[i+1].Dato;
                }
                return colaString;  
            }
        }
        public string ImprimirPrioridad()
        {
            string colaString = "";
            if (EstaVacia())
            {
                return "La cola esta vacia";
            }
            else
            {
                colaString += colaPrioridad[Head].Prioridad;
                for (int i = 0; i < Tail; i++)
                {
                    colaString += "," + colaPrioridad[i + 1].Prioridad;
                }
                return colaString;
            }
        }
        public string regresarfinal()
        {
            return colaPrioridad[Tail].Dato + "";
        }
    }
}
