using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ColaPrioridadEstaticaImplementacion1
{
    public partial class Form1 : Form
    {
        ColaPrioridad MiCola;
        Datos d;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncolar_Click(object sender, EventArgs e)
        {
            try
            {
                string dato = txtDato.Text;
                int prioridad = int.Parse(txtPrioridad.Text);
                d = new Datos();
                d.Dato = dato;
                d.Prioridad = prioridad;
                MiCola.Encolar(d);
                txtDato.Clear();
                txtPrioridad.Clear();

            }
            catch
            {
                MessageBox.Show("Error");
            }

            //MessageBox.Show(MiCola.regresarfinal());
            lblCola.Text = MiCola.ImprimirDatos();
            lblPrioridad.Text = MiCola.ImprimirPrioridad();
        }

        private void btnDesencolar_Click(object sender, EventArgs e)
        {
            MiCola.Desencolar();
            lblCola.Text = MiCola.ImprimirDatos();
            lblPrioridad.Text = MiCola.ImprimirPrioridad();

        }

        private void btnIncrementar_Click(object sender, EventArgs e)
        {
            MiCola.IncrementarPrioridad();
            lblPrioridad.Text = MiCola.ImprimirPrioridad();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void lblPrioridad_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                int tamaño = int.Parse(txtTamaño.Text);
                if (tamaño <= 0)
                {
                    MessageBox.Show("Tamaño minimo : 1");
                    return;
                }
                MiCola = new ColaPrioridad(tamaño);
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            catch
            {
                MessageBox.Show("Dato no valido");
            }
         
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog Dialogo = new FolderBrowserDialog();
                if (Dialogo.ShowDialog() == DialogResult.OK)
                {
                    string datos = lblCola.Text;
                    string prioridades = lblPrioridad.Text;
                    int tamaño = MiCola.colaPrioridad.Length;
                    string[] DatosYTamaño = { datos, prioridades, tamaño + "" };
                    string nombreDelArchivo;
                    if (txtArchivo.Text == "")
                    {
                        nombreDelArchivo = "Cola";
                    }
                    else
                    {
                        nombreDelArchivo = txtArchivo.Text;
                    }
                    string ruta = Dialogo.SelectedPath + "\\" + nombreDelArchivo + ".txt";
                    using (var writer = new StreamWriter(ruta))
                    {
                        writer.Close();
                    }
                    File.WriteAllLines(ruta, DatosYTamaño);
                    MessageBox.Show("Datos guardados en la ruta : " + ruta);
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar el archivo");
                this.Close();
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Seleccionar = new OpenFileDialog();
            if (Seleccionar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ruta = Seleccionar.FileName;
                    string[] DatosYTamaño = File.ReadAllLines(ruta);
                    string datos = DatosYTamaño[0];
                    string prioridades = DatosYTamaño[1];
                    int tamaño = int.Parse(DatosYTamaño[2]);
                    string[] DatosArreglo = datos.Split(',');
                    string[] PrioridadesArreglo = prioridades.Split(',');
                    MiCola = new ColaPrioridad(tamaño);
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    int contador = 0;
                    foreach(string i in DatosArreglo)
                    {
                        d = new Datos();
                        d.Dato = DatosArreglo[contador];
                        d.Prioridad = int.Parse(PrioridadesArreglo[contador]);
                        MiCola.Encolar(d);
                        contador++;
                    }
                    lblCola.Text = MiCola.ImprimirDatos();
                    lblPrioridad.Text = MiCola.ImprimirPrioridad();
                }
                catch
                {
                    MessageBox.Show("Error al cargar el archivo");
                }

            }
        }
    }
}
