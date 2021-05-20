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
    public partial class addestoque : Form
    {
        public addestoque()
        {
            InitializeComponent();
            carregar();
            txtBarras.MaxLength = 13;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            addproduto add = new addproduto();
            add.ShowDialog();
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            addproduto add = new addproduto();
            add.ShowDialog();
        }

        private void carregar()
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);


            string sqlSelect = "select * from Produtos ";
            DgvEstoque.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addestoque_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();


                if (txtBarras.Text.Trim() == string.Empty || txtBarras.Text.Equals(""))
                {
                    MessageBox.Show("Digite um Código de Barras", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                     ClieDAL.abrirConexao(conexao);
                string sqlSelect = " select IDproduto,CodigoDeBarras,Marca,Nome,ValorUnitario,Quantidade,Categoria,Fornecedor,DataEntrada,DataVencimento from Produtos where CodigoDeBarras ='" + txtBarras.Text + "'";
                DgvEstoque.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                ClieDAL.fecharConexao(conexao);
                    mskVencimento.Clear();
                    cboCategoria.Text = " ";
   
                }
                
             
               
            }
            catch (Exception )
            {
                
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();


                ClieDAL.abrirConexao(conexao);
                string sqlSelect = "select IDproduto,CodigoDeBarras,Marca,Nome,ValorUnitario,Quantidade,Categoria,Fornecedor,DataEntrada,DataVencimento from Produtos where DataVencimento ='" + mskVencimento.Text + "'";
                DgvEstoque.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                ClieDAL.fecharConexao(conexao);

                txtBarras.Clear();
                cboCategoria.Text = " ";

            }
            catch (Exception )
            {

                //DATA INVÁLIDA!\nO PRODUTO DEVE SER CADASTRADO COM A VALIDADE DE NO MÍNIMO 30 DIAS!
                MessageBox.Show("DATA INVALIDA!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();


                if (cboCategoria.Text.Trim() == string.Empty || cboCategoria.Text.Equals(""))
                {
                    MessageBox.Show("ESCOLHA UMA CATEGORIA!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClieDAL.abrirConexao(conexao);
                    string sqlSelect = " select IDproduto,CodigoDeBarras,Marca,Nome,ValorUnitario,Quantidade,Categoria,Fornecedor,DataEntrada,DataVencimento from Produtos where Categoria ='" + cboCategoria.Text + "'";
                    DgvEstoque.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                    ClieDAL.fecharConexao(conexao);

                    mskVencimento.Clear();
                    txtBarras.Clear();

                }



            }
            catch (Exception )
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            {
                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();
                ClieDAL.abrirConexao(conexao);


                string sqlSelect = "select * from Produtos ";
                DgvEstoque.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);

                mskVencimento.Clear();
                cboCategoria.Text = " ";
                txtBarras.Clear();

            }
        }

        private void txtBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {


                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();


                    if (txtBarras.Text.Trim() == string.Empty || txtBarras.Text.Equals(""))
                    {
                        MessageBox.Show("DIGÍTE UM CÓDIGO DE BARRAS!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ClieDAL.abrirConexao(conexao);
                        string sqlSelect = " select IDproduto,CodigoDeBarras,Marca,Nome,ValorUnitario,Quantidade,Categoria,Fornecedor,DataEntrada,DataVencimento from Produtos where CodigoDeBarras ='" + txtBarras.Text + "'";
                        DgvEstoque.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                        ClieDAL.fecharConexao(conexao);

                        mskVencimento.Clear();
                        cboCategoria.Text = " ";
                    }



                }
                catch (Exception )
                {

                }
            }
        }

        private void mskVencimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();


                    ClieDAL.abrirConexao(conexao);
                    string sqlSelect = "select IDproduto,CodigoDeBarras,Marca,Nome,ValorUnitario,Quantidade,Categoria,Fornecedor,DataEntrada,DataVencimento from Produtos where DataVencimento ='" + mskVencimento.Text + "'";
                    DgvEstoque.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                    ClieDAL.fecharConexao(conexao);

                    txtBarras.Clear();
                    cboCategoria.Text = " ";

                }
                catch (Exception )
                {


                    MessageBox.Show("DATA INVALIDA!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cboCategoria_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBarras_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void mskVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DgvEstoque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //addproduto f2 = new addproduto();

            //f2.txtCodBarras.Text = this.DgvEstoque.CurrentRow.Cells[1].Value.ToString();
            //f2.txtMarca.Text = this.DgvEstoque.CurrentRow.Cells[2].Value.ToString();
            //f2.txtNome.Text = this.DgvEstoque.CurrentRow.Cells[3].Value.ToString();
            //f2.txtValorUn.Text = this.DgvEstoque.CurrentRow.Cells[4].Value.ToString();
            //f2.NumQuant.Text = this.DgvEstoque.CurrentRow.Cells[5].Value.ToString();
            //f2.cboFornecedor.Text = this.DgvEstoque.CurrentRow.Cells[7].Value.ToString();
            //f2.cboCategoria.Text = this.DgvEstoque.CurrentRow.Cells[6].Value.ToString();
            //f2.mskVencimento.Text = this.DgvEstoque.CurrentRow.Cells[9].Value.ToString();
            //f2.txtDesc.Text = this.DgvEstoque.CurrentRow.Cells[10].Value.ToString();
            //f2.txtCaminhoFt.Text = this.DgvEstoque.CurrentRow.Cells[11].Value.ToString();
            //f2.pictureBox.Text = this.DgvEstoque.CurrentRow.Cells[12].Value.ToString();

          

            //f2.ShowDialog();
        }

        private void mskVencimento_Click(object sender, EventArgs e)
        {
            mskVencimento.SelectionStart = 0;
        }
    }
}
