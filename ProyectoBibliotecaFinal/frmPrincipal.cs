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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            EstadoTabs();
            ToolTip ToolTip = new ToolTip();
            ToolTip.AutomaticDelay = 5000;
            ToolTip.InitialDelay = 500;
            ToolTip.ReshowDelay = 500;
            ToolTip.ShowAlways = true;
            ToolTip.SetToolTip(picClientes,"Administrar clientes, puede agregar, modificar, eliminar o buscar clientes");
            ToolTip.SetToolTip(picLibros, "Administrar libros, puede agregar, modificar, eliminar o buscar libros");
            ToolTip.SetToolTip(picAlquiler,"Puede prestar o devolver un libro a un cliente");
            ToolTip.SetToolTip(picReportes,"Puede generar reportes");
        }
         
        //
        // Eventos
        //

        private void picClientes_Click(object sender, EventArgs e)
        {
            EstadoTabs();
            tabUsuarios.Visible = true;
        }

        private void picLibros_Click(object sender, EventArgs e)
        {
            EstadoTabs();
            tabLibros.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            EstadoTabs();
            tabAlquilaar.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            EstadoTabs();
            tabReportes.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            EstadoTabs();
            tabUsuarios.Visible = true;
            pagBucarUsuario.Show();
            pagBucarUsuario.Select();
            pagBucarUsuario.Focus();


        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "nodLibPresClie":
                    MessageBox.Show("Genrando reporte: " + e.Node.Text);
                    break;
                case "nodDatosCliente":
                    MessageBox.Show("Genrando reporte: " + e.Node.Text);
                    break;
                case "nodLibPretados":
                    MessageBox.Show("Genrando reporte: " + e.Node.Text);
                    break;
                case "nodCatLibros":
                    MessageBox.Show("Genrando reporte: "+ e.Node.Text);
                    break;
            }
        }

        private void picLibroReg_Click(object sender, EventArgs e)
        {
            OpenFileDialog Foto = new OpenFileDialog();
            Foto.InitialDirectory = "C:";
            Foto.Filter = "Archivos de imagen (*.jpeg)(*.png)|*.jpeg|*.jpeg| *.png|PNG (*.png)|*.png";
            if (Foto.ShowDialog() == DialogResult.OK)
            {
                picLibroReg.ImageLocation = Foto.FileName;
                picLibroReg.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("No se selecciono un archivo con formato requerido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picLibroMod_Click(object sender, EventArgs e)
        {
            OpenFileDialog Foto = new OpenFileDialog();
            Foto.InitialDirectory = "C:";
            Foto.Filter = "Archivos de imagen (*.jpeg)(*.png)|*.jpeg|*.jpeg| *.png|PNG (*.png)|*.png";
            if (Foto.ShowDialog() == DialogResult.OK)
            {
                picLibroMod.ImageLocation = Foto.FileName;
                picLibroMod.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("No se selecciono un archivo con formato requerido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picUsuarioReg_Click(object sender, EventArgs e)
        {
            OpenFileDialog Foto = new OpenFileDialog();
            Foto.InitialDirectory = "C:";
            Foto.Filter = "Archivos de imagen (*.jpeg)(*.png)|*.jpeg|*.jpeg| *.png|PNG (*.png)|*.png";
            if (Foto.ShowDialog() == DialogResult.OK)
            {
                picUsuarioReg.ImageLocation = Foto.FileName;
                picUsuarioReg.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("No se selecciono un archivo con formato requerido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picUsuarioMod_Click(object sender, EventArgs e)
        {
            OpenFileDialog Foto = new OpenFileDialog();
            Foto.InitialDirectory = "C:";
            Foto.Filter = "Archivos de imagen (*.jpeg)(*.png)|*.jpeg|*.jpeg|*.png|PNG (*.png)|*.png";
            if (Foto.ShowDialog() == DialogResult.OK)
            {
                picUsuarioMod.ImageLocation = Foto.FileName;
                picUsuarioMod.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("No se selecciono un archivo con formato requerido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloNumeros(e);
            if (e.KeyChar==Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                btnUsuModBuscar.Focus();
            }
        }

        private void txtUsuApPat_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloLetras(e);
            if (e.KeyChar ==Convert.ToChar( Keys.Enter))
            {
                txtUsuApMat.Focus();
            }
        }

        private void txtUsuApMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloLetras(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtUsuNom.Focus();
            }
        }

        private void txtUsuNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloLetras(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                dateTimeUsuMod.Focus();
            }
        }

        private void dateTimeUsuMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtUsuDir.Focus();
            }

        }

        private void txtUsuTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnUsuMod.Focus();
            }
        }

        private void txtUsuDir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                txtUsuTel.Focus();
            }
        }

        private void txtUsuRegCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtUsuRegApPa.Focus();
            }
        }

        private void txtUsuRegApPa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloLetras(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtUsuRegApMat.Focus();
            }
        }

        private void txtUsuRegApMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloLetras(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtUsuRegNombre.Focus();
            }
        }

        private void txtUsuRegNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloLetras(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                dateTimeUsuReg.Focus();
            }
        }

        private void dateTimeUsuReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtUsuRegDir.Focus();
            }
        }

        private void txtUsuRegDir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                txtUsuRegRel.Focus();
            }
        }

        private void txtUsuRegRel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_TextBox.Validar.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnUsuReg.Focus();
            }
        }




        //
        // Botones
        //

        private void btnUsuReg_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin X = new frmLogin();
                int i = 0;
                X.Comando.Connection = X.Conexion;
                X.Comando.CommandText = "insert into Clientes (ApPaterno, ApMaterno, Nombre, FechaNacimiento,Direccion,Telefono,Curp) values ('" + txtUsuRegApPa.Text + "','" + txtUsuRegApMat.Text + "','" + txtUsuRegNombre.Text + "','" + dateTimeUsuReg.Text + "','" + txtUsuRegDir.Text + "','" + txtUsuRegRel.Text + "','" + txtUsuRegCurp.Text + "')";
                i = X.Comando.ExecuteNonQuery();

                {
                    X.Comando.Parameters.AddWithValue("@ApPaterno", txtUsuRegApPa.Text);
                    X.Comando.Parameters.AddWithValue("@ApMaterno", txtUsuRegApMat.Text);
                    X.Comando.Parameters.AddWithValue("@Nombre", txtUsuRegNombre.Text);
                    X.Comando.Parameters.AddWithValue("@FechaNacimiento", dateTimeUsuReg.Text);
                    X.Comando.Parameters.AddWithValue("@Direccion", txtUsuRegDir.Text);
                    X.Comando.Parameters.AddWithValue("@Telefono", txtUsuRegRel.Text);
                    X.Comando.Parameters.AddWithValue("@Curp", txtUsuRegCurp.Text);
                    MessageBox.Show("Guardado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    X.Comando.CommandText = "Select * from Clientes where ApPaterno= '" + txtUsuRegApPa.Text + "' ";
                    OleDbDataReader BuscarID = X.Comando.ExecuteReader();
                    while (BuscarID.Read())
                    {
                        if (txtUsuRegApPa.Text == BuscarID.GetValue(1).ToString())
                        {
                            MessageBox.Show("El codigo del cliene es: " + BuscarID.GetValue(0).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                LmpiarTXT();
            }
            catch
            {
                MessageBox.Show("Error al guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLibMod_Click(object sender, EventArgs e)
        {

        }

        private void btnLibRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin x = new frmLogin();
                x.Comando.Connection = x.Conexion;
                int i = 0;
                x.Comando.CommandText = "insert into Libros (ISBN,Titulo,Autores,Idioma,Editorial,Edicion,Categoria) values ('" + txtLibRegISBN.Text + "','" + txtLibRegTitulo.Text + "','" + txtLibRegAutor.Text + "','" + cmbLibRegIdioma.Text + "','" + txtLibRegEditorial.Text + "','" + txtLibRegEdicion.Text + "','" + cmbLibRegCategoria.Text + "')";
                i = x.Comando.ExecuteNonQuery();
                        {
                            x.Comando.Parameters.AddWithValue("@ISBN", txtLibRegISBN.Text);
                            x.Comando.Parameters.AddWithValue("@Titulo", txtLibRegTitulo.Text);
                            x.Comando.Parameters.AddWithValue("@Autores", txtLibRegAutor.Text);
                            x.Comando.Parameters.AddWithValue("@Idioma", cmbLibRegIdioma.Text);
                            x.Comando.Parameters.AddWithValue("@Editorial", txtLibRegEditorial.Text);
                            x.Comando.Parameters.AddWithValue("@Edicion", txtLibRegEdicion.Text);
                            x.Comando.Parameters.AddWithValue("@Categoria", cmbLibRegCategoria.Text);
                            MessageBox.Show("Libro registrado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LmpiarTXT();
                        }

            }
            catch
            {
                MessageBox.Show("Error al guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LmpiarTXT();
        }

        private void btnLibModBuscar_Click(object sender, EventArgs e)
        {
            frmLogin x = new frmLogin();
            int i = 0;
            x.Comando.Connection = x.Conexion;
            x.Comando.CommandText = "Select * from Libros where ISBN = '" + txtLibModBuscar.Text + "'";
            OleDbDataReader BuscarISBN = x.Comando.ExecuteReader();
            while (BuscarISBN.Read())
            {
                if (txtLibModBuscar.Text == BuscarISBN.GetValue(0).ToString())
                {
                    txtLibModTitulo.Text = BuscarISBN.GetValue(1).ToString();
                    txtLibModAutor.Text = BuscarISBN.GetValue(2).ToString();
                    cmbLibModIdioma.Text = BuscarISBN.GetValue(3).ToString();
                    txtLibModEdit.Text = BuscarISBN.GetValue(4).ToString();
                    txtLibModEdicion.Text = BuscarISBN.GetValue(5).ToString();
                    txtLibModCate.Text = BuscarISBN.GetValue(6).ToString();
                    i = 1;
                }
            }
            if (i == 0)
            {
                MessageBox.Show("Nose encontro el libro ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLibModLimpiar_Click(object sender, EventArgs e)
        {
            LmpiarTXT();
        }

        private void btnUsuModBuscar_Click(object sender, EventArgs e)
        {
            frmLogin x = new frmLogin();
            int i = 0;
            x.Comando.Connection = x.Conexion;
            x.Comando.CommandText = "Select * from Clientes where Id=" + txtUsuBuscar.Text + " ";
            OleDbDataReader BuscarID = x.Comando.ExecuteReader();
            while (BuscarID.Read())
            {
                if (txtUsuBuscar.Text == BuscarID.GetValue(0).ToString())
                {
                    txtUsuApPat.Text = BuscarID.GetValue(0).ToString();
                    txtUsuApMat.Text = BuscarID.GetValue(1).ToString();
                    txtUsuNom.Text = BuscarID.GetValue(2).ToString();
                    dateTimeUsuMod.Text = BuscarID.GetValue(4).ToString();
                    txtUsuDir.Text = BuscarID.GetValue(5).ToString();
                    txtUsuTel.Text = BuscarID.GetValue(6).ToString();
                    i = 1;
                }
            }
            if (i == 0)
            {
                MessageBox.Show("Nose encontro el cliente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUsuMod_Click(object sender, EventArgs e)
        {
            if (txtUsuApMat.Text != string.Empty && txtUsuApPat.Text != string.Empty && txtUsuNom.Text != string.Empty && dateTimeUsuMod.Text != string.Empty && txtUsuDir.Text != string.Empty && txtUsuTel.Text != string.Empty)
            {
                MessageBox.Show("Registro Modificado", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LmpiarTXT();
            }
            else
            {
                MessageBox.Show("Los campos no pueden satr vacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnUsuModLimpiar_Click(object sender, EventArgs e)
        {
            LmpiarTXT();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea cerrar sesion", "Cerrar Sesion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Close();
                frmLogin Login = new frmLogin();
                Login.Show();

            }
        }


        //
        // Metodos
        //

        public void LmpiarTXT()
        {
            txtUsuApPat.Text = string.Empty;
            txtUsuApMat.Text = string.Empty;
            txtUsuNom.Text = string.Empty;
            dateTimeUsuMod.Text = string.Empty;
            txtUsuDir.Text = string.Empty;
            txtUsuTel.Text = string.Empty;
            txtUsuApMat.Enabled = false;
            txtUsuApPat.Enabled = false;
            txtUsuDir.Enabled = false;
            txtUsuNom.Enabled = false;
            txtUsuTel.Enabled = false;
            dateTimeUsuMod.Enabled = false;
            picUsuarioMod.Enabled = false;
            txtUsuBuscar.Text = string.Empty;
            picUsuarioMod.Image = null;
            txtUsuRegApMat.Text = string.Empty;
            txtUsuRegApPa.Text = string.Empty;
            txtUsuRegNombre.Text = string.Empty;
            txtUsuRegDir.Text = string.Empty;
            dateTimeUsuReg.Text = string.Empty;
            txtUsuRegRel.Text = string.Empty;
            picUsuarioReg.Image = null;
            txtUsuRegCurp.Text = string.Empty;
            txtLibRegISBN.Text = string.Empty;
            txtLibRegTitulo.Text = string.Empty;
            txtLibRegEditorial.Text = string.Empty;
            txtLibRegEdicion.Text = string.Empty;
            txtLibRegAutor.Text = string.Empty;
            cmbLibRegCategoria.Text = string.Empty;
            cmbLibRegIdioma.Text = string.Empty;
            picLibroReg.Image = null;
            txtLibModTitulo.Text = string.Empty;
            txtLibModEdit.Text = string.Empty;
            txtLibModEdicion.Text = string.Empty;
            txtLibModCate.Text = string.Empty;
            txtLibModBuscar.Text = string.Empty;
            txtLibModAutor.Text = string.Empty;
            cmbLibModIdioma.Text = string.Empty;
            picLibroMod.Image = null;
        }

        private void EstadoTabs()
        {
            tabLibros.Visible = false;
            tabUsuarios.Visible = false;
            tabAlquilaar.Visible = false;
            tabReportes.Visible = false;

        }
    }
}
