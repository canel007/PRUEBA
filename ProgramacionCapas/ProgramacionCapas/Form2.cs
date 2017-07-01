using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramacionCapas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtcodigo.Text == String.Empty)
            {
                Cliente cliente = new Cliente();
                cliente.Nombre = txtnombre.Text;
                cliente.Direccion = txtdireccion.Text;
                cliente.Telefono = Convert.ToInt32(txttelefono.Text);
                cliente.Insertar_Cliente(cliente);
                limpiarCampos();
                ActualizarGridview();

            }
            else {
                Cliente cliente = new Cliente();
                cliente.Codigo =Convert.ToInt32( txtcodigo.Text);
                cliente.Nombre = txtnombre.Text;
                cliente.Direccion = txtdireccion.Text;
                cliente.Telefono = Convert.ToInt32(txttelefono.Text);
                cliente.Actualizar_Cliente(cliente);
                limpiarCampos();
                ActualizarGridview();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ind = this.dataGridView1.CurrentRow.Index;
            if (ind > -1)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro de eliminar este registro " + dataGridView1.Rows[ind].Cells["NOMBRE"].Value.ToString(), "Eliminar el registro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Cliente cl = new Cliente();
                    DataGridViewRow fila = this.dataGridView1.Rows[ind];                    
                    cl.Eliminar_Cliente(Convert.ToInt32(fila.Cells["Codigo"].Value));
                    ActualizarGridview();
                }
            }
            else if(ind < 0){
                MessageBox.Show("Debe seleccionar una fila");
            }
        }
        private void Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarGridview();
        }


        public void ActualizarGridview() {
            Cliente CLIENTE = new Cliente();
            this.dataGridView1.DataSource = CLIENTE.Listado_Clientes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            int ind = this.dataGridView1.CurrentRow.Index;
            if (ind > -1)
            {

                Cliente cl = new Cliente();
                DataGridViewRow fila = this.dataGridView1.Rows[ind];                              
                this.txtcodigo.Text = fila.Cells["Codigo"].Value.ToString() ;
                this.txtnombre.Text= fila.Cells["Nombre"].Value.ToString();
                this.txtdireccion.Text= fila.Cells["Direccion"].Value.ToString();
                this.txttelefono.Text= fila.Cells["Telefono"].Value.ToString();
                ActualizarGridview();
            }
            else if (ind < 0)
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            limpiarCampos();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ActualizarGridview();
        }

        public void limpiarCampos() {

            this.txtcodigo.Text = string.Empty;
            this.txtdireccion.Text = string.Empty;
            this.txttelefono.Text = string.Empty;
            this.txtnombre.Text = string.Empty;
        }


    }
}
