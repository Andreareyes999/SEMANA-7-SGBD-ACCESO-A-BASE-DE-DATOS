using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data;
using MySql.Data.MySqlClient;
 


namespace Login_DB
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        

        SqlConnection conexionsql = new SqlConnection("server=LAPTOP-C6KTNLFR; database=Login; integrated security=true");
        OleDbConnection conexionacceses = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Login.accdb");
        public string conexionmysql = "Database=login;Data Source=localhost;User Id=root;Password="; //cadena de conexión a mysql



        private void Login_Load(object sender, EventArgs e)
        {
            conexionacceses.Open();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            try
            {

                string usuario = txtusuario.Text;
                string pass = txtclave.Text;

                if (usuario == "" || pass == "")
                {
                    MessageBox.Show("Debe de completar los campos para poder continuar");
                }
                else
                {
                    conexionsql.Open();
                    String consulta_sql = "select * from usuarios where usuario = '" + usuario + "' and clave = '" + pass + "'";
                    SqlCommand comando = new SqlCommand(consulta_sql, conexionsql);
                    SqlDataReader leersql;
                    leersql = comando.ExecuteReader();

                    if (leersql.HasRows == true)
                    {
                        MessageBox.Show("bienvendo al Sistema " + usuario);
                        menu abrirnuevo = new menu();
                        abrirnuevo.capturardatos("Bienvenido " + usuario + " a Iniciado Secion desde SQL Server");
                        abrirnuevo.Show();

                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Los Datos son incorectos");

                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Los Datos son incorectos");

            }


        }

        private void Btnaccess_Click(object sender, EventArgs e)
        {

            try
            {
                //conexionacceses.Open();
                string usuario = txtusuario.Text;
                string pass = txtclave.Text;

                if (usuario == "" || pass == "")
                {
                    MessageBox.Show("Debe de completar los campos para poder continuar");
                }
                else
                {
                    string consulta_access = "select * from usuarios where usuario = '" + usuario + "' and clave = '" + pass + "'";
                    OleDbCommand comando = new OleDbCommand(consulta_access, conexionacceses);
                    OleDbDataReader leeraccess;
                    leeraccess = comando.ExecuteReader();
                    Boolean siexiste = leeraccess.HasRows;
                    if (siexiste)
                    {
                        MessageBox.Show("bienvendo al Sistema " + usuario);
                        menu abrirnuevo = new menu();
                        abrirnuevo.capturardatos("Bienvenido " + usuario + " a Iniciado Secion desde MS Access");
                        abrirnuevo.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error Datos Incorectos");
                        //conexionacceses.Close();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Datos Incorectos");

            }

        }

        private void Btnmysql_Click(object sender, EventArgs e)
        {

            try
            {
                string usuario = txtusuario.Text;
                string pass = txtclave.Text;

                if (usuario == "" || pass == "")
                {
                    MessageBox.Show("Debe de completar los campos para poder continuar");
                }
                else
                {

                    MySqlConnection myConnection = new MySqlConnection(conexionmysql);
                    string mySelectQuery = "select * from usuarios where usuario = '" + usuario + "' and clave = '" + pass + "'";
                    MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
                    myConnection.Open();
                    MySqlDataReader myReader;
                    myReader = myCommand.ExecuteReader();

                    //string consulta_access = "select * from login where usuario = '" + usuario + "' and clave = '" + pass + "'";
                    //OleDbCommand comando = new OleDbCommand(consulta_access, conexionacceses);
                    //OleDbDataReader leeraccess;
                    //leeraccess = comando.ExecuteReader();
                    Boolean siexiste = myReader.HasRows;
                    if (siexiste)
                    {
                        MessageBox.Show("bienvendo al Sistema " + usuario);
                        menu abrirnuevo = new menu();
                        abrirnuevo.capturardatos("Bienvenido " + usuario + " a Iniciado Secion desde MySQL");
                        abrirnuevo.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error Datos Incorectos");
                        //conexionacceses.Close();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Datos Incorectos");

            }






        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Esta Seguro que desea Salir", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
