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
    public partial class ConsultarFornecedor : Form
    {
        public ConsultarFornecedor()
        {
            InitializeComponent();
            carregar();

            txtEmail.MaxLength = 50;
            txtNome.MaxLength = 100;
        }

        private void carregar()
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);


            string sqlSelect = "select * from Fornecedor where StatusForn = 'ativo'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

        }
        private void carregarInativos()
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);


            string sqlSelect = "select * from Fornecedor where StatusForn = 'inativo'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

        }

        private void ConsultarFornecedor_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            carregar();

            txtNome.Clear();
            txtEmail.Clear();
            mskCNPJ.Clear();
            radioButton1.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Fornecedor where NomeFantasia like '%" + txtNome.Text + "%'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

            txtNome.Clear();
            txtEmail.Clear();
            mskCNPJ.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Fornecedor where email like '%" + txtEmail.Text + "%'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

            txtNome.Clear();
            txtEmail.Clear();
            mskCNPJ.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Fornecedor where CNPJ ='" + mskCNPJ.Text + "'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

            txtNome.Clear();
            txtEmail.Clear();
            mskCNPJ.Clear();

        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();
                    ClieDAL.abrirConexao(conexao);

                    string sqlSelect = " select * from Fornecedor where NomeFantasia like '%" + txtNome.Text + "%'";
                    dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

                    txtNome.Clear();
                    txtEmail.Clear();
                    mskCNPJ.Clear();

                }
                catch (Exception)
                {

                }
            }

            

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

                    string sqlSelect = " select * from Fornecedor where email like '%" + txtEmail.Text + "%'";
                    dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

                    txtNome.Clear();
                    txtEmail.Clear();
                    mskCNPJ.Clear();

                }
                catch (Exception)
                {

                }
            }


        }

        private void mskCNPJ_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();
                    ClieDAL.abrirConexao(conexao);

                    string sqlSelect = " select * from Fornecedor where CNPJ ='" + mskCNPJ.Text + "'";
                    dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

                    txtNome.Clear();
                    txtEmail.Clear();
                    mskCNPJ.Clear();

                }
                catch (Exception)
                {

                }
            }


        }

        private void dgvFale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFale.CurrentRow == null)
            {
                MessageBox.Show("NÃO HÁ FORNECEDORES CADASTRADOS!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                addfornecedor f2 = new addfornecedor();

                f2.txtIDfornecedor.Text = this.dgvFale.CurrentRow.Cells[0].Value.ToString();
                f2.txtNomeFantasia.Text = this.dgvFale.CurrentRow.Cells[2].Value.ToString();
                f2.txtRazaoSocial.Text = this.dgvFale.CurrentRow.Cells[1].Value.ToString();

                f2.mskTelefone.Text = this.dgvFale.CurrentRow.Cells[3].Value.ToString();
                f2.mskCelular.Text = this.dgvFale.CurrentRow.Cells[4].Value.ToString();
                f2.txtEmail.Text = this.dgvFale.CurrentRow.Cells[5].Value.ToString();


                f2.mskCEP.Text = this.dgvFale.CurrentRow.Cells[6].Value.ToString();
                f2.mskCNPJ.Text = this.dgvFale.CurrentRow.Cells[7].Value.ToString();

                f2.txtLogradouro.Text = this.dgvFale.CurrentRow.Cells[8].Value.ToString();
                f2.txtCidade.Text = this.dgvFale.CurrentRow.Cells[9].Value.ToString();
                f2.cboUF.Text = this.dgvFale.CurrentRow.Cells[10].Value.ToString();
                f2.txtBairro.Text = this.dgvFale.CurrentRow.Cells[11].Value.ToString();
                f2.txtNumero.Text = this.dgvFale.CurrentRow.Cells[12].Value.ToString();


                f2.txtComplemento.Text = this.dgvFale.CurrentRow.Cells[13].Value.ToString();
                f2.cboStatus.Text = this.dgvFale.CurrentRow.Cells[14].Value.ToString();

                f2.ShowDialog();
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            carregar();
            txtNome.Clear();
            txtEmail.Clear();
            mskCNPJ.Clear();
        }

        private void dgvFale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            carregarInativos();
            txtNome.Clear();
            txtEmail.Clear();
            mskCNPJ.Clear();
        }

        private void mskCNPJ_Click(object sender, EventArgs e)
        {
            mskCNPJ.SelectionStart = 0;
        }
    }
}
