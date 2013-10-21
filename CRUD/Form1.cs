using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Librerias
using Capa_Entidades;
using Capa_Negocio;

namespace CRUD
{
    public partial class frm_Principal : Form
    {
        bool edition = false;
        int ID = 0;
        public frm_Principal()
        {
            InitializeComponent();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
           
            Entidades ENTI = new Entidades()
            {
               Cedula = msk_Cedula.Text,
               Nombre = txt_Nombre.Text,
               Apellido = txt_Apellido.Text,
               Telefono = txt_Tel.Text,
               Direccion = txt_Direccion.Text
            };

            try
            {
                if (edition == false)
                {
                    if (new Logica().GetClientes(ENTI) != 0)
                    {
                        MessageBox.Show("Regiostro Exitoso");
                        Grid_Clientes.DataSource = new Logica().llenarDataGrid();
                        msk_Cedula.Clear();
                        txt_Nombre.Clear();
                        txt_Apellido.Clear();
                        txt_Tel.Clear();
                        txt_Direccion.Clear();
                    }
                }
                else
                {
                    if(new Logica().actualizar(ID,ENTI) != 0)
                    {
                      MessageBox.Show("Registro Actualizado");
                        Grid_Clientes.DataSource = new Logica().llenarDataGrid();
                        msk_Cedula.Clear();
                        txt_Nombre.Clear();
                        txt_Apellido.Clear();
                        txt_Tel.Clear();
                        txt_Direccion.Clear();
                        edition = false;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            
        }

        private void frm_Principal_Load(object sender, EventArgs e)
        {
            Grid_Clientes.DataSource = new Logica().llenarDataGrid();
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            msk_Cedula.Clear();
            txt_Nombre.Clear();
            txt_Apellido.Clear();
            txt_Tel.Clear();
            txt_Direccion.Clear();
        }

        private void editarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ID = Convert.ToInt16(Grid_Clientes.CurrentCell.Value);
            Entidades ENTI = new Logica().Editar(ID);

            txt_Nombre.Text = ENTI.Nombre;
            txt_Apellido.Text = ENTI.Apellido;
            txt_Tel.Text = ENTI.Telefono;
            txt_Direccion.Text = ENTI.Direccion;
            msk_Cedula.Text = ENTI.Cedula;
            edition = true;
        }

        private void btn_bRegistro_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Quieres borrar este Registro","Alerta",MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                if (new Logica().Borrar(Convert.ToInt32(Grid_Clientes.CurrentCell.Value)) != 0)
                {
                    MessageBox.Show("Registro Borrado");
                    Grid_Clientes.DataSource = new Logica().llenarDataGrid();
                }
            }
            else
            {
                return;
            }
        }
    }
}
