using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class addpersonalizar : Form
    {
        public addpersonalizar()
        {
            InitializeComponent();
            txtTotal.Enabled = false;
            //a vista
            txtPagoVista.Enabled = false;
            //credito
            cboQuantCredito.Enabled = false;
            txtPagoCredito1.Enabled = false;
            txtPagoCredito2.Enabled = false;
            cboParcela1.Enabled = false;
            cboParcela2.Enabled = false;
            txtValorParcela1.Enabled = false;
            txtValorParcela2.Enabled = false;
            //debito
            cboQuantDebito.Enabled = false;
            txtPagoDebito1.Enabled = false;
            txtPagoDebito2.Enabled = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addpersonalizar_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboFormas.Text == "À Vista & Crédito")
                {
                    //a vista
                    txtPagoVista.Enabled = true;
                    //credito
                    cboQuantCredito.Enabled = true;
                    txtPagoCredito1.Enabled = false;
                    txtPagoCredito2.Enabled = false;
                    cboParcela1.Enabled = false;
                    cboParcela2.Enabled = false;
                    txtValorParcela1.Enabled = false;
                    txtValorParcela2.Enabled = false;
                    //debito
                    cboQuantDebito.Enabled = false;
                    txtPagoDebito1.Enabled = false;
                    txtPagoDebito2.Enabled = false;
                }
                if (cboFormas.Text == "À Vista & Débito")
                {
                    //a vista
                    txtPagoVista.Enabled = true;
                    //credito
                    cboQuantCredito.Enabled = false;
                    txtPagoCredito1.Enabled = false;
                    txtPagoCredito2.Enabled = false;
                    cboParcela1.Enabled = false;
                    cboParcela2.Enabled = false;
                    txtValorParcela1.Enabled = false;
                    txtValorParcela2.Enabled = false;
                    //debito
                    cboQuantDebito.Enabled = true;
                    txtPagoDebito1.Enabled = false;
                    txtPagoDebito2.Enabled = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cboQuantCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboQuantCredito.Text == " ")
                {
                    cboParcela1.Enabled = false;
                    txtPagoCredito1.Enabled = false;
                    cboParcela2.Enabled = false;
                    txtPagoCredito2.Enabled = false;
                }
                if (cboQuantCredito.Text == "1")
                {
                    cboParcela1.Enabled = true;
                    txtPagoCredito1.Enabled = true;
                    cboParcela2.Enabled = false;
                    txtPagoCredito2.Enabled = false;
                }
                if (cboQuantCredito.Text == "2")
                {
                    cboParcela2.Enabled = true;
                    txtPagoCredito1.Enabled = true;
                    cboParcela1.Enabled = true;
                    txtPagoCredito2.Enabled = true;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void cboQuantDebito_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboQuantDebito.Text == " ")
                {
                    txtPagoDebito1.Enabled = false;
                    txtPagoDebito2.Enabled = false;
                }
                if (cboQuantDebito.Text == "1")
                {
                    txtPagoDebito1.Enabled = true;
                    txtPagoDebito2.Enabled = false;
                }
                if (cboQuantDebito.Text == "2")
                {
                    txtPagoDebito1.Enabled = true;
                    txtPagoDebito2.Enabled = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
