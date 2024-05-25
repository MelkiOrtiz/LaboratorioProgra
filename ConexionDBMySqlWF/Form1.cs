using ConexionDBMySqlWF.Data;
using ConexionDBMySqlWF.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionDBMySqlWF
{
    public partial class Form1 : Form
    {
        catalogo_consolas catalogo = new catalogo_consolas();
        List<Consola> todasConsolas;
        ClsCursor cursor = new ClsCursor();

        public Form1()
        {
            InitializeComponent();
            CargarCompanias();
            CargarDatos();
        }

        private void CargarCompanias()
        {
            comboBoxCompania.Items.AddRange(new string[] { "Atari", "Coleco", "Mattel", "Microsoft", "Nintendo", "Ouya Inc.", "Sega", "Sony" });
        }

        private void CargarDatos()
        {
            dataGridView.DataSource = catalogo.LeerTodos();
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            string filterCompania = comboBoxCompania.Text;
            List<Consola> filtered = todasConsolas.FindAll(c => c.Compania == filterCompania);
            dataGridView.DataSource = filtered;
        }

        private void buttonInsertar_Click_1(object sender, EventArgs e)
        {
           
                Consola consola = new Consola
                {
                    NombreConsola = textBoxNombreConsola.Text,
                    Compania = comboBoxCompania.Text,
                    AnioLanzamiento = int.Parse(textBoxAnioLanzamiento.Text),
                    Generacion = int.Parse(textBoxGeneracion.Text)
                };
                catalogo.Insertar(consola);
                CargarDatos();
            
        }

        private void buttonActualizar_Click_1(object sender, EventArgs e)
        {
           
                Consola consola = new Consola
                {
                    IdConsola = int.Parse(textBoxIdConsola.Text),
                    NombreConsola = textBoxNombreConsola.Text,
                    Compania = comboBoxCompania.Text,
                    AnioLanzamiento = int.Parse(textBoxAnioLanzamiento.Text),
                    Generacion = int.Parse(textBoxGeneracion.Text)
                };
                catalogo.Actualizar(consola);
                CargarDatos();
            
        }

        private void buttonLeerPorId_Click_1(object sender, EventArgs e)
        {
           
                int idConsola = int.Parse(textBoxIdConsola.Text);
                DataRow data = catalogo.LeerPorId(idConsola);
                if (data != null)
                {
                    textBoxNombreConsola.Text = data["nombre_consola"].ToString();
                    comboBoxCompania.Text = data["compania"].ToString();
                    textBoxAnioLanzamiento.Text = data["anio_lanzamiento"].ToString();
                    textBoxGeneracion.Text = data["generacion"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró el registro");
                }
            
        }

        private void buttonSeleccionarTodo_Click_1(object sender, EventArgs e)
        {
                todasConsolas = catalogo.ObtenerTodasLasConsolas();
                dataGridView.DataSource = todasConsolas; 
        }

        private void buttonFiltrar_Click_1(object sender, EventArgs e)
        {
           //Falta chambear esto :(
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}