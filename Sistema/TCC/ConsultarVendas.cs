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
using DAL;


namespace TCC
{
    public partial class ConsultarVendas : Form
    {
        public ConsultarVendas()
        {
            InitializeComponent();
            carregar();

            txtIDvenda.MaxLength = 4;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void carregar()
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);

            string sqlSelect = "select IDvenda,CPFcliente,DataVenda, ValorTotal,FormaPagamento from venda";
            DgvVenda.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);


        }


        private void ConsultarVendas_Load(object sender, EventArgs e)
        {

        }

        private void DgvEstoque_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();
        

                ClieDAL.abrirConexao(conexao);
                string sqlSelect = "select IDvenda,CPFcliente,DataVenda,ValorTotal,FormaPagamento from venda where DataVenda ='" + mskPesquisa.Text + "'";
                DgvVenda.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                ClieDAL.fecharConexao(conexao);
                txtIDvenda.Clear();
                mskPesquisa.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Data invalida!","ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();


                ClieDAL.abrirConexao(conexao);
                string sqlSelect = "select IDvenda,CPFcliente,DataVenda,ValorTotal,FormaPagamento from venda where IDvenda ='" + txtIDvenda.Text + "'";
                DgvVenda.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                ClieDAL.fecharConexao(conexao);
                txtIDvenda.Clear();
                mskPesquisa.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("ID invalido!","ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtIDvenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();


                    ClieDAL.abrirConexao(conexao);
                    string sqlSelect = "select IDvenda,CPFcliente,DataVenda,ValorTotal,FormaPagamento from venda where IDvenda ='" + txtIDvenda.Text + "'";
                    DgvVenda.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                    ClieDAL.fecharConexao(conexao);
                }
                catch (Exception)
                {

                    MessageBox.Show("ID inválido","ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void mskPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();


                    ClieDAL.abrirConexao(conexao);
                    string sqlSelect = "select IDvenda,CPFcliente,DataVenda,ValorTotal,FormaPagamento from venda where DataVenda ='" + mskPesquisa.Text + "'";
                    DgvVenda.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                    ClieDAL.fecharConexao(conexao);
                }
                catch (Exception)
                {

                    MessageBox.Show("Verificar data","ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            carregar();
        }

        private void txtIDvenda_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskPesquisa_Click(object sender, EventArgs e)
        {
            mskPesquisa.SelectionStart = 0;
        }
    }
}
