using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class ConsultarEncomendas : Form
    {
        public ConsultarEncomendas()
        {
            InitializeComponent();
            carregar();
            Coluna();

            txtEmail.MaxLength = 50;
            txtID.MaxLength = 4;
            txtOcasioes.MaxLength = 50;
        }

        private void carregar()
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);




            string sqlSelect = "select * from  Encomendas";
            dgvEncomendas.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mskNascimento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Encomendas where ocasiao like '%" + txtOcasioes.Text + "%'";
            dgvEncomendas.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

            txtID.Clear();
            txtEmail.Clear();
            txtOcasioes.Clear();
            mskNascimento.Text = DateTime.Now.ToString();
        }

        private void ConsultarEncomendas_Load(object sender, EventArgs e)
        {

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Encomendas where email like '%" + txtEmail.Text + "%'";
            dgvEncomendas.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

            txtID.Clear();
            txtEmail.Clear();
            txtOcasioes.Clear();
            mskNascimento.Text = DateTime.Now.ToString();

        }

        private void btnID_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Encomendas where idPedido like '%" + txtID.Text + "%'";
            dgvEncomendas.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

            txtID.Clear();
            txtEmail.Clear();
            txtOcasioes.Clear();
            mskNascimento.Text = DateTime.Now.ToString();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Encomendas where data_entrega = '" + mskNascimento.Text + "'";
            dgvEncomendas.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

            txtID.Clear();
            txtEmail.Clear();
            txtOcasioes.Clear();
            mskNascimento.Text = DateTime.Now.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            carregar();
            txtID.Clear();
            txtEmail.Clear();
            txtOcasioes.Clear();
            mskNascimento.Text = DateTime.Now.ToString();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();
                    ClieDAL.abrirConexao(conexao);

                    string sqlSelect = " select * from Encomendas where email like '%" + txtEmail.Text + "%'";
                    dgvEncomendas.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

                    txtID.Clear();
                    txtEmail.Clear();
                    txtOcasioes.Clear();
                    mskNascimento.Text = DateTime.Now.ToString();

                }
                catch (Exception)
                {

                }
            }
        }

        private void txtOcasioes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();
                    ClieDAL.abrirConexao(conexao);

                    string sqlSelect = " select * from Encomendas where ocasiao like '%" + txtOcasioes.Text + "%'";
                    dgvEncomendas.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

                    txtID.Clear();
                    txtEmail.Clear();
                    txtOcasioes.Clear();
                    mskNascimento.Text = DateTime.Now.ToString();

                }
                catch (Exception)
                {

                }
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();
                    ClieDAL.abrirConexao(conexao);

                    string sqlSelect = " select * from Encomendas where idPedido like '%" + txtID.Text + "%'";
                    dgvEncomendas.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

                    txtID.Clear();
                    txtEmail.Clear();
                    txtOcasioes.Clear();
                    mskNascimento.Text = DateTime.Now.ToString();

                }
                catch (Exception)
                {

                }
            }
        }

        private void mskNascimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();
                    ClieDAL.abrirConexao(conexao);

                    string sqlSelect = " select * from Encomendas where data_entrega = '" + mskNascimento.Text + "'";
                    dgvEncomendas.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

                    txtID.Clear();
                    txtEmail.Clear();
                    txtOcasioes.Clear();
                    mskNascimento.Text = DateTime.Now.ToString();

                }
                catch (Exception)
                {

                }
            }
        }

        private void dgvEncomendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEncomendas.CurrentRow == null)
            {
                MessageBox.Show("NÃO HÁ ENCOMENDAS!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Encomendas f2 = new Encomendas();
                f2.txtID2.Text = this.dgvEncomendas.CurrentRow.Cells[0].Value.ToString();
                f2.txtIDcliente2.Text = this.dgvEncomendas.CurrentRow.Cells[1].Value.ToString();
                f2.mskData2.Text = this.dgvEncomendas.CurrentRow.Cells[2].Value.ToString();
                f2.txtOcasiao2.Text = this.dgvEncomendas.CurrentRow.Cells[3].Value.ToString();
                f2.mskTelefone2.Text = this.dgvEncomendas.CurrentRow.Cells[4].Value.ToString();
                f2.txtEmail2.Text = this.dgvEncomendas.CurrentRow.Cells[5].Value.ToString();
                f2.txtDescricao.Text = this.dgvEncomendas.CurrentRow.Cells[6].Value.ToString();
                f2.ShowDialog();
            }
        
        }

        private void Coluna()
        {
            dgvEncomendas.Columns[0].Width = 90;
            dgvEncomendas.Columns[1].Width = 90;
            dgvEncomendas.Columns[2].Width = 140;
            dgvEncomendas.Columns[3].Width = 150;
            dgvEncomendas.Columns[4].Width = 160;
            dgvEncomendas.Columns[5].Width = 250;
            dgvEncomendas.Columns[6].Width = 250;
        
        }

        private void dgvEncomendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
