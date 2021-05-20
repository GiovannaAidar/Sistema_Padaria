using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace TCC
{
    public partial class addproduto : Form
    {
        public addproduto()
        {
            InitializeComponent();

            txtCodBarras.MaxLength = 13;
            txtPesquisa.MaxLength = 13;
            txtValorUn.MaxLength = 7;
            txtMarca.MaxLength = 50;
            txtNome.MaxLength = 100;
            txtValorUn.MaxLength = 6;
            txtDesc.MaxLength = 300;


            txtCodBarras.Enabled = false;
            txtMarca.Enabled = false;
            txtNome.Enabled = false;
            txtValorUn.Enabled = false;
            NumQuant.Enabled = false;
            cboCategoria.Enabled = false;
            cboFornecedor.Enabled = false;
            mskVencimento.Enabled = false;
            txtDesc.Enabled = false;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnApagar.Enabled = false;

             
    }


        SqlConnection sqlCon = null;
        private string strCon = "server = localhost; database=Projeto; user id = sa; password=123456";
        private string strSql = string.Empty;
        Conexao cn;
        SqlCommand cmd;
        SqlDataAdapter da;

        public DataTable buscarFornec(string nomeFornec)
        {
            cn = new Conexao();
            string Query = "select IDfornecedor, NomeFantasia from fornecedor where NomeFantasia='" + nomeFornec + "'";
            cmd = new SqlCommand(Query, cn.conectar());
            cmd.ExecuteNonQuery();

            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.desconectar();
            return dt;
        }

        public int SelectFornec(string nomeFornec)
        {
            DataTable t = buscarFornec(nomeFornec);
            int z = Convert.ToInt16(t.Rows[0][0].ToString());
            return z;
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void addproduto_Load(object sender, EventArgs e)
        {
            CarregarFornecedor();
        }

        public void CarregarFornecedor()
        {
            var SqlDataAdapter = new SqlDataAdapter("select * from Fornecedor where StatusForn = 'ativo'", @"server = localhost; database=Projeto; user id = sa; password=123456");
            var cmd = new SqlCommandBuilder(SqlDataAdapter);
            var dataTable = new DataTable();
            SqlDataAdapter.Fill(dataTable);
            var bd = new BindingSource();

            bd.DataSource = dataTable;
            this.cboFornecedor.DataSource = dataTable;
            this.cboFornecedor.ValueMember = "IDfornecedor";
            this.cboFornecedor.DisplayMember = "NomeFantasia";
            cboFornecedor.DataSource = bd;
        }



        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Adicionar", btnAdicionar);

            txtCodBarras.Enabled = true;
            txtMarca.Enabled = true;
            txtNome.Enabled = true;
            txtPesquisa.Enabled = true;
            txtValorUn.Enabled = true;
            NumQuant.Enabled = true;
            cboCategoria.Enabled = true;
            cboFornecedor.Enabled = true;
            mskVencimento.Enabled = true;
            txtDesc.Enabled = true;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = true;
            btnApagar.Enabled = true;

            txtCodBarras.Clear();
            txtMarca.Clear();
            txtNome.Clear();
            txtPesquisa.Clear();
            txtValorUn.Clear();
            NumQuant.Text = "0";
            cboCategoria.Text = " ";
            cboFornecedor.Text = " ";
            mskVencimento.Text = DateTime.Now.ToString();
            txtDesc.Clear();
            pictureBox.Image = null;
            txtCaminhoFt.Clear();

            txtCodBarras.Focus();
        }



        DateTime Vencimento;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Salvar", btnSalvar);

            Vencimento = Convert.ToDateTime(mskVencimento.Text);
            string dataAlterada = Vencimento.Year.ToString() + "-" + Vencimento.Month.ToString() + "-" + Vencimento.Day.ToString();

            int fornec = Convert.ToInt32(SelectFornec(cboFornecedor.Text.ToString()));
            
            strSql = "insert into Produtos(CodigoDeBarras,Marca,Nome,ValorUnitario,Quantidade,Categoria,Fornecedor,DataEntrada,DataVencimento,Descricao,Foto,NomeArquivo) values(@CodigoDeBarras,@Marca,@Nome,@ValorUnitario,@Quantidade,@Categoria,@Fornecedor,SYSDATETIME(),@DataVencimento,@Descricao,@Foto,@NomeArquivo)";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@CodigoDeBarras", SqlDbType.VarChar).Value = txtCodBarras.Text.Trim();
            comando.Parameters.Add("@Marca", SqlDbType.VarChar).Value = txtMarca.Text.Trim();
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text.Trim();
            comando.Parameters.Add("@ValorUnitario", SqlDbType.Money).Value = txtValorUn.Text.Trim();
            comando.Parameters.Add("@Quantidade", SqlDbType.VarChar).Value = NumQuant.Text.Trim();
            comando.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = cboCategoria.Text.Trim();
            comando.Parameters.Add("@Fornecedor", SqlDbType.VarChar).Value = fornec;
            comando.Parameters.Add("@DataVencimento", SqlDbType.VarChar).Value = dataAlterada;
            comando.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = txtDesc.Text.Trim();
            comando.Parameters.Add("@Foto", SqlDbType.VarChar).Value = txtCaminhoFt.Text;
            comando.Parameters.Add("@NomeArquivo", SqlDbType.VarChar).Value = lblNomeArquivo.Text;




            try
            {
                if (txtCodBarras.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CÓD. DE BARRAS", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtMarca.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO MARCA", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtNome.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO NOME", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtValorUn.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO VALOR UNITÁRIO", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (NumQuant.Text == "0")
                {
                    MessageBox.Show("PREENCHA O CAMPO QUANTIDADE", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (cboCategoria.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CATEGORIA", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (cboFornecedor.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO FORNECEDOR", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (mskVencimento.Value <= DateTime.Now)
                {
                    MessageBox.Show("DATA INVÁLIDA", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtDesc.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO DESCRIÇÃO", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (pictureBox.Image == null)
                {
                    MessageBox.Show("ADICIONE UMA IMAGEM", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    sqlCon.Open();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("CADASTRO EFETUADO COM SUCESSO!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtPesquisa.Enabled = true;
                    txtCodBarras.Clear();
                    txtMarca.Clear();
                    txtNome.Clear();
                    txtPesquisa.Clear();
                    txtValorUn.Clear();
                    NumQuant.Text = "0";
                    cboCategoria.Text = " ";
                    cboFornecedor.Text = " ";
                    mskVencimento.Text = DateTime.Now.ToString();
                    txtDesc.Clear();
                    txtCaminhoFt.Clear();
                    pictureBox.Image = null;
                }

            }
            catch (Exception )
            {
                MessageBox.Show("ESSE PRODUTO JÁ ESTÁ CADASTRADO", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }

            finally
            {
                sqlCon.Close();
            }
        }



        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            txtCodBarras.Enabled = true;
            txtMarca.Enabled = true;
            txtNome.Enabled = true;
            txtPesquisa.Enabled = true;
            txtValorUn.Enabled = true;
            NumQuant.Enabled = true;
            cboCategoria.Enabled = true;
            cboFornecedor.Enabled = true;
            mskVencimento.Enabled = true;
            txtDesc.Enabled = true;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = true;
            btnApagar.Enabled = true;

            toolTip1.Show("Buscar", btnPesquisa);

            strSql = "select*from produtos where CodigoDeBarras=@pesquisa ";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtPesquisa.Text.Replace(",", "").Replace("-", "").Trim();

            try
            {
               


                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (txtPesquisa.Text == string.Empty)
                {
                    MessageBox.Show("VOCÊ NÃO DIGITOU UM CÓDIGO DE BARRAS.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dr.HasRows == false)
                {
                    MessageBox.Show("ESTE CÓDIGO NÃO ESTÁ CADASTRADO", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                


                dr.Read();

                txtCodBarras.Text = Convert.ToString(dr["CodigoDeBarras"]);
                txtMarca.Text = Convert.ToString(dr["Marca"]);
                txtNome.Text = Convert.ToString(dr["Nome"]);
                txtValorUn.Text = Convert.ToString(dr["ValorUnitario"]);
                NumQuant.Text = Convert.ToString(dr["Quantidade"]);
                cboCategoria.Text = Convert.ToString(dr["Categoria"]);
                cboFornecedor.SelectedValue = Convert.ToString(dr["Fornecedor"]);
                mskVencimento.Text = Convert.ToString(dr["DataVencimento"]);
                txtDesc.Text = Convert.ToString(dr["Descricao"]);
                pictureBox.ImageLocation = Convert.ToString(dr["Foto"]);
                txtCaminhoFt.Text = Convert.ToString(dr["Foto"]);
                lblNomeArquivo.Text = Convert.ToString(dr["NomeArquivo"]);
                //caminho foto tem que aparecer

                // MessageBox.Show("" + Convert.ToString(dr["Fornecedor"]) + "  " + Convert.ToString(dr["Foto"]));


            }

            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlCon.Close();
            }
            txtPesquisa.Clear();


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Editar", btnEditar);

            Vencimento = Convert.ToDateTime(mskVencimento.Text);
            string dataAlterada = Vencimento.Year.ToString() + "-" + Vencimento.Month.ToString() + "-" + Vencimento.Day.ToString();

            int fornec = Convert.ToInt32(SelectFornec(cboFornecedor.Text.ToString()));

            strSql = "update Produtos set CodigoDeBarras=@CodigoDeBarras,Marca=@Marca,Nome=@Nome,ValorUnitario=@ValorUnitario,Quantidade=@Quantidade,Categoria=@Categoria,Fornecedor=@Fornecedor,DataVencimento=@DataVencimento,Descricao=@Descricao,Foto=@Foto, NomeArquivo=@NomeArquivo where CodigoDeBarras=@CodigoDeBarras";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@CodigoDeBarras", SqlDbType.VarChar).Value = txtCodBarras.Text.Trim();
            comando.Parameters.Add("@Marca", SqlDbType.VarChar).Value = txtMarca.Text.Trim();
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text.Trim();
            comando.Parameters.Add("@ValorUnitario", SqlDbType.Decimal).Value = txtValorUn.Text.Trim();
            comando.Parameters.Add("@Quantidade", SqlDbType.VarChar).Value = NumQuant.Text.Trim();
            comando.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = cboCategoria.Text.Trim();
            comando.Parameters.Add("@Fornecedor", SqlDbType.VarChar).Value = fornec;
            comando.Parameters.Add("@DataVencimento", SqlDbType.VarChar).Value = dataAlterada;
            comando.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = txtDesc.Text.Trim();
            comando.Parameters.Add("@Foto", SqlDbType.VarChar).Value = txtCaminhoFt.Text;
            comando.Parameters.Add("@NomeArquivo", SqlDbType.VarChar).Value = lblNomeArquivo.Text;

            try
            {
                if (txtCodBarras.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CÓD. DE BARRAS", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtMarca.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO MARCA", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtNome.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO NOME", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtValorUn.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO VALOR UNITÁRIO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (NumQuant.Text == "0")
                {
                    MessageBox.Show("PREENCHA O CAMPO QUANTIDADE", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (cboCategoria.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CATEGORIA", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (cboFornecedor.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO FORNECEDOR", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (mskVencimento.Value <= DateTime.Now)
                {
                    MessageBox.Show("DATA INVÁLIDA", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtDesc.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO DESCRIÇÃO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (pictureBox.Image == null)
                {
                    MessageBox.Show("ADICIONE UMA IMAGEM", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    sqlCon.Open();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("CADASTRO ALTERADO COM SUCESSO!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtPesquisa.Enabled = true;
                    txtCodBarras.Clear();
                    txtMarca.Clear();
                    txtNome.Clear();
                    txtPesquisa.Clear();
                    txtValorUn.Clear();
                    NumQuant.Text = "0";
                    cboCategoria.Text = " ";
                    cboFornecedor.SelectedIndex = 0;
                    mskVencimento.Text = DateTime.Now.ToString();
                    txtDesc.Clear();
                    pictureBox.Image = null;
                    txtCaminhoFt.Clear();
                }

            }



            catch (Exception ex)
            {
          
                MessageBox.Show("VALOR UNITÁRIO INVÁLIDO!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // throw;
                txtValorUn.Clear();
            }
            finally
            {
                sqlCon.Close();
            }

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Apagar", btnApagar);

            strSql = "delete from Produtos where CodigoDeBarras=@CodigoDeBarras";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@CodigoDeBarras", SqlDbType.VarChar).Value = txtCodBarras.Text;

            if (txtPesquisa.Text == string.Empty.Trim())
            {
                MessageBox.Show("DIGITE UM CNPJ CADASTRADO!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("EXCLUSÃO DE CADASTRO FEITA COM SUCESSO.", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // throw;
                }
                finally
                {
                    sqlCon.Close();
                }

                txtCodBarras.Clear();
                txtMarca.Clear();
                txtNome.Clear();
                txtPesquisa.Clear();
                txtValorUn.Clear();
                NumQuant.Text = "0";
                cboCategoria.Text = " ";
                cboFornecedor.Text = " ";
                mskVencimento.Text = DateTime.Now.ToString();
                txtDesc.Clear();
                pictureBox.Image = null;
            }

                

        }





        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

     //   string caminho;
     //   private object openFileDialog1;

        private void button1_Click_3(object sender, EventArgs e)
        {
            //OpenFileDialog abrir = new OpenFileDialog();
            //abrir.Multiselect = false;

            //if (abrir.ShowDialog() == DialogResult.OK)
            //{
            //pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox.Image = new Bitmap(abrir.FileName);
            //caminho = abrir.FileName;
            //}

            if (openFileDialog2.ShowDialog() == DialogResult.OK) {

                txtCaminhoFt.Text = openFileDialog2.FileName;
                pictureBox.ImageLocation = openFileDialog2.FileName;
                pictureBox.Image = new Bitmap(txtCaminhoFt.Text);


                string caminhoCompleto = openFileDialog2.FileName;
                FileInfo fileInfo = new FileInfo(caminhoCompleto);
                string nomearquivo = fileInfo.Name;

                lblNomeArquivo.Text = nomearquivo;
            }
        }

        private void txtValorUn_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtCodBarras.Enabled = true;
                txtMarca.Enabled = true;
                txtNome.Enabled = true;
                txtPesquisa.Enabled = true;
                txtValorUn.Enabled = true;
                NumQuant.Enabled = true;
                cboCategoria.Enabled = true;
                cboFornecedor.Enabled = true;
                mskVencimento.Enabled = true;
                txtDesc.Enabled = true;
                btnSalvar.Enabled = true;
                btnEditar.Enabled = true;
                btnApagar.Enabled = true;

                toolTip1.Show("Buscar", btnPesquisa);

                strSql = "select*from produtos where CodigoDeBarras=@pesquisa ";

                sqlCon = new SqlConnection(strCon);

                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtPesquisa.Text.Replace(",", "").Replace("-", "").Trim();

                try
                {
                    if (txtPesquisa.Text == string.Empty)
                    {
                        MessageBox.Show("VOCÊ NÃO DIGITOU UM CÓDIGO DE BARRAS.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    sqlCon.Open();
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        MessageBox.Show("ESTE CÓDIGO NÃO ESTÁ CADASTRADO", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    dr.Read();

                    txtCodBarras.Text = Convert.ToString(dr["CodigoDeBarras"]);
                    txtMarca.Text = Convert.ToString(dr["Marca"]);
                    txtNome.Text = Convert.ToString(dr["Nome"]);
                    txtValorUn.Text = Convert.ToString(dr["ValorUnitario"]);
                    NumQuant.Text = Convert.ToString(dr["Quantidade"]);
                    cboCategoria.Text = Convert.ToString(dr["Categoria"]);
                    cboFornecedor.SelectedValue = Convert.ToString(dr["Fornecedor"]);
                    mskVencimento.Text = Convert.ToString(dr["DataVencimento"]);
                    txtDesc.Text = Convert.ToString(dr["Descricao"]);
                    pictureBox.ImageLocation = Convert.ToString(dr["Foto"]);
                    txtCaminhoFt.Text = Convert.ToString(dr["Foto"]);

                    // MessageBox.Show("" + Convert.ToString(dr["Fornecedor"]) + "  " + Convert.ToString(dr["Foto"]));


                }

                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }

                finally
                {
                    sqlCon.Close();
                }
                txtPesquisa.Clear();



            }
        }

        private void cboFornecedor_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

        }

        private void txtValorUn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (txtValorUn.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtCodBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtValorUn_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
             
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
               
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
