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
    public partial class ConsultarFuncionario : Form
    {
        public ConsultarFuncionario()
        {
            InitializeComponent();

            txtNome.MaxLength = 100;
          
            txtEmail.MaxLength = 50;
          

            carregar();

        }

        private void dgvFale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ConsultarFuncionario_Load(object sender, EventArgs e)
        {

        }


        private void carregar()
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);


            string sqlSelect = "select * from Funcionario where StatusFunc = 'ativo'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

        }
        private void carregarInativos()
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);


            string sqlSelect = "select * from Funcionario where StatusFunc = 'inativo'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Funcionario where nome like '%" + txtNome.Text + "%'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
            txtNome.Clear();
            txtEmail.Clear();
            cboCargo.Text = " ";
            mskCPF.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            carregar();
            radioButton1.Checked = true;
            txtNome.Clear();
            txtEmail.Clear();
            cboCargo.Text = " ";
            mskCPF.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Funcionario where email like '%" + txtEmail.Text + "%'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
            txtNome.Clear();
            txtEmail.Clear();
            cboCargo.Text = " ";
            mskCPF.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Funcionario where cargo ='" + cboCargo.Text + "'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
            txtNome.Clear();
            txtEmail.Clear();
            cboCargo.Text = " ";
            mskCPF.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = " select * from Funcionario where CPF ='" + mskCPF.Text + "'";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
            txtNome.Clear();
            txtEmail.Clear();
            cboCargo.Text = " ";
            mskCPF.Clear();

        }

        private void dgvFale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFale.CurrentRow == null)
            {
                MessageBox.Show("NÃO HÁ FUNCIONÁRIOS CADASTRADOS!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                addfuncionario f2 = new addfuncionario();

                f2.txtIDfuncionario.Text = this.dgvFale.CurrentRow.Cells[0].Value.ToString();
                f2.txtNome.Text = this.dgvFale.CurrentRow.Cells[1].Value.ToString();
                f2.mskTelefone.Text = this.dgvFale.CurrentRow.Cells[2].Value.ToString();
                f2.mskCelular.Text = this.dgvFale.CurrentRow.Cells[3].Value.ToString();
                f2.txtEmail.Text = this.dgvFale.CurrentRow.Cells[4].Value.ToString();
                f2.cboSexo.Text = this.dgvFale.CurrentRow.Cells[5].Value.ToString();
                f2.cboCargo.Text = this.dgvFale.CurrentRow.Cells[6].Value.ToString();
                f2.mskNascimento.Text = this.dgvFale.CurrentRow.Cells[7].Value.ToString();
                f2.mskCEP.Text = this.dgvFale.CurrentRow.Cells[8].Value.ToString();
                f2.txtLogradouro.Text = this.dgvFale.CurrentRow.Cells[9].Value.ToString();
                f2.txtCidade.Text = this.dgvFale.CurrentRow.Cells[10].Value.ToString();
                f2.cboUF.Text = this.dgvFale.CurrentRow.Cells[11].Value.ToString();
                f2.txtBairro.Text = this.dgvFale.CurrentRow.Cells[12].Value.ToString();
                f2.txtNumero.Text = this.dgvFale.CurrentRow.Cells[13].Value.ToString();
                f2.mskRG.Text = this.dgvFale.CurrentRow.Cells[14].Value.ToString();
                f2.mskCPF.Text = this.dgvFale.CurrentRow.Cells[15].Value.ToString();
                f2.txtComplemento.Text = this.dgvFale.CurrentRow.Cells[16].Value.ToString();
                f2.cboStatus.Text = this.dgvFale.CurrentRow.Cells[17].Value.ToString();


                f2.ShowDialog();
            }
          
        }

        private void chkAtivos_CheckedChanged(object sender, EventArgs e)
        {
            
        
        }

        private void chkInativos_CheckedChanged(object sender, EventArgs e)
        {
            
        
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            carregar();
            txtNome.Clear();
            txtEmail.Clear();
            cboCargo.Text = " ";
            mskCPF.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            carregarInativos();
            txtNome.Clear();
            txtEmail.Clear();
            cboCargo.Text = " ";
            mskCPF.Clear();
        }

        private void mskCPF_Click(object sender, EventArgs e)
        {
            mskCPF.SelectionStart = 0;
        }

        //private void chkAtivos_CheckedChanged(object sender, EventArgs e)
        //{

        //    carregar();
        //    chkInativos.Checked = false;


        //}

        //private void chkInativos_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkInativos.Checked == true)
        //    {
        //        SqlConnection conexao = FabricaConexao.getConexao();
        //        ClientesDAL ClieDAL = new ClientesDAL();
        //        ClieDAL.abrirConexao(conexao);


        //        string sqlSelect = "select * from Funcionario where StatusFunc = 'inativos'";
        //        dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
        //        chkAtivos.Checked = false;
        //    }

        //}
    }
}
