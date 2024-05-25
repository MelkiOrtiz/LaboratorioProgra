using ConexionDBMySqlWF.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionDBMySqlWF.Data
{
    internal class catalogo_consolas
    {
        string connectionString = "server=localhost;database=db_universidad;user=root;password=Melki-2004";
        MySqlConnection connection;

        public catalogo_consolas()
        {
            connection = new MySqlConnection(connectionString);
        }

        public void Insertar(Consola consola)
        {
            try
            {
                string query = "INSERT INTO catalogo_consolas (nombre_consola, compania, anio_lanzamiento, generacion) VALUES (@NombreConsola, @Compania, @AnioLanzamiento, @Generacion)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NombreConsola", consola.NombreConsola);
                cmd.Parameters.AddWithValue("@Compania", consola.Compania);
                cmd.Parameters.AddWithValue("@AnioLanzamiento", consola.AnioLanzamiento);
                cmd.Parameters.AddWithValue("@Generacion", consola.Generacion);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void Actualizar(Consola consola)
        {
            try
            {
                string query = "UPDATE catalogo_consolas SET nombre_consola = @NombreConsola, compania = @Compania, anio_lanzamiento = @AnioLanzamiento, generacion = @Generacion WHERE id_consola = @IdConsola";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdConsola", consola.IdConsola);
                cmd.Parameters.AddWithValue("@NombreConsola", consola.NombreConsola);
                cmd.Parameters.AddWithValue("@Compania", consola.Compania);
                cmd.Parameters.AddWithValue("@AnioLanzamiento", consola.AnioLanzamiento);
                cmd.Parameters.AddWithValue("@Generacion", consola.Generacion);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable LeerTodos()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM catalogo_consolas";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los registros: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public DataRow LeerPorId(int idConsola)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM catalogo_consolas WHERE id_consola = @IdConsola";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdConsola", idConsola);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt.Rows[0];
        }

        public List<Consola> ObtenerTodasLasConsolas()
        {
            List<Consola> consolas = new List<Consola>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM catalogo_consolas";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Consola consola = new Consola
                        (
                            idConsola: reader.GetInt32("id_consola"),
                            nombreConsola: reader.GetString("nombre_consola"),
                            compania: reader.GetString("compania"),
                            anioLanzamiento: reader.GetInt32("anio_lanzamiento"),
                            generacion: reader.GetInt32("generacion")
                        );

                        consolas.Add(consola);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return consolas;
        }
    }
}