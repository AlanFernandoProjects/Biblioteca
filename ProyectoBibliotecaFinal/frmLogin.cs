using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ProyectoBibliotecaFinal
{
    public partial class frmLogin : Form
    {
        public OleDbConnection Conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Erick\\Desktop\\Database21.accdb");
        public OleDbCommand Comando = new OleDbCommand();
        public frmLogin()
        {
            InitializeComponent();
            Conexion.Open();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Autentificar();      
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir del progeama", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                txtClave.Focus();
            }
        }

        public void Autentificar()
        {
            int Cartel = 0;


            OleDbCommand BuscarUsuario = new OleDbCommand("Select Nombre, Clave from Usuarios", Conexion);
            OleDbDataReader Lectrodedatos = BuscarUsuario.ExecuteReader();
            while (Lectrodedatos.Read())
            {
                if (txtUsuario.Text == Lectrodedatos.GetValue(0).ToString() && txtClave.Text == Lectrodedatos.GetValue(1).ToString())
                {
                    MessageBox.Show("Bienvenido(a) " + txtUsuario.Text, "Inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPrincipal Principal = new frmPrincipal(); Principal.ShowDialog();
                    this.Hide();
                    Cartel = 1;
                }


                if (Cartel == 0)
                {
                    MessageBox.Show("Usuario o clave incorrectos ", "Inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Text = string.Empty;
                    txtClave.Text = string.Empty;
                    txtUsuario.Focus();
                }

            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Autentificar();
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                txtClave.Focus();
            }
        }
    }
}
