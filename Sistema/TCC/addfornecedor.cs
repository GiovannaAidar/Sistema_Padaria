using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class addfornecedor : Form
    {
        public addfornecedor()
        {
            InitializeComponent();

            txtRazaoSocial.MaxLength = 100;
            txtNomeFantasia.MaxLength = 100;
            txtEmail.MaxLength = 50;
            txtLogradouro.MaxLength = 100;
            txtCidade.MaxLength = 100;
            txtBairro.MaxLength = 100;
            txtComplemento.MaxLength = 100;
            txtNumero.MaxLength = 6;


        }

        SqlConnection sqlCon = null;
        private string strCon = "server = localhost; database=Projeto; user id = sa; password=123456";
        private string strSql = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Salvar", btnSalvar);

            strSql = "insert into fornecedor(RazaoSocial,NomeFantasia,Telefone,Celular,Email,CEP,CNPJ,Logradouro,Cidade,UF,Bairro,Numero,Complemento,StatusForn) values(@RazaoSocial,@NomeFantasia,@Telefone,@Celular,@Email,@CEP,@CNPJ,@Logradouro,@Cidade,@UF,@Bairro,@Numero,@Complemento,'ativo')";

           sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@RazaoSocial", SqlDbType.VarChar).Value = txtRazaoSocial.Text;
            comando.Parameters.Add("@NomeFantasia", SqlDbType.VarChar).Value = txtNomeFantasia.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text.Replace("-", "").Replace("(", "").Replace(")", "").Trim();
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = mskCelular.Text.Replace("-", "").Replace("(", "").Replace(")", "").Trim();
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCEP.Text.Replace("-", "");
            comando.Parameters.Add("@CNPJ", SqlDbType.VarChar).Value = mskCNPJ.Text.Replace("-", "").Replace("/", "").Replace(",", "").Replace(".", "").Trim();
            comando.Parameters.Add("@Logradouro", SqlDbType.VarChar).Value = txtLogradouro.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = cboUF.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
            comando.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = txtComplemento.Text;


            try
            {
                if  (txtRazaoSocial.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO RAZÃO SOCIAL", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(txtNomeFantasia.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO NOME FANTASIA", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(mskTelefone.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO TELEFONE", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(mskCelular.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CELULAR", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO E-MAIL", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(mskCNPJ.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CNPJ", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(mskCEP.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CEP", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(txtLogradouro.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO LOGRADOURO", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(txtCidade.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CIDADE", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(cboUF.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO UF", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(txtBairro.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO BAIRRO", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(txtNumero.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO NUMERO", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            


                else
                {
                    sqlCon.Open();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("CADASTRO EFETUADO COM SUCESSO!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    txtPesquisa.Enabled = true;

                    //UF
                    txtRazaoSocial.Clear();
                    txtNomeFantasia.Clear();
                    mskTelefone.Clear();
                    mskCelular.Clear();
                    txtEmail.Clear();
                    mskCEP.Clear();
                    mskCNPJ.Clear();
                    txtLogradouro.Clear();
                    txtCidade.Clear();
                    txtPesquisa.Clear();
                    cboUF.Text = " ";
                    txtBairro.Clear();
                    cboStatus.Text = " ";
                    txtNumero.Clear();
                    txtComplemento.Clear();
                }

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
                //throw;
                if (ex.Message.ToString().Contains("UNIQUE"))
                {
                    MessageBox.Show("ESSE FORNECEDOR JÁ ESTÁ CADASTRADO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            finally
            {
                sqlCon.Close();
            }

            txtPesquisa.Enabled = true;

            //UF
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Limpar", btnAdicionar);

            txtRazaoSocial.Enabled = true;
            txtNomeFantasia.Enabled = true;
            mskTelefone.Enabled = true;
            mskCelular.Enabled = true;
            txtEmail.Enabled = true;
            mskCEP.Enabled = true;
            mskCNPJ.Enabled = true;
            txtLogradouro.Enabled = true;
            txtCidade.Enabled = true;
            txtPesquisa.Enabled = true;
            btnSalvar.Enabled = true;
            cboUF.Enabled = true;
            txtBairro.Enabled = true;
            txtNumero.Enabled = true;
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;
            txtComplemento.Enabled = true;


            txtRazaoSocial.Clear();
            txtNomeFantasia.Clear();
            mskTelefone.Clear();
            mskCelular.Clear();
            txtEmail.Clear();
            mskCEP.Clear();
            mskCNPJ.Clear();
            txtLogradouro.Clear();
            txtCidade.Clear();
            txtPesquisa.Clear();
            cboUF.Text = " ";
            txtBairro.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            cboStatus.Text = " ";
            
            
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtRazaoSocial.Enabled = true;
            txtNomeFantasia.Enabled = true;
            mskTelefone.Enabled = true;
            mskCelular.Enabled = true;
            txtEmail.Enabled = true;
            mskCEP.Enabled = true;
            mskCNPJ.Enabled = true;
            txtLogradouro.Enabled = true;
            txtCidade.Enabled = true;
            txtPesquisa.Enabled = true;
            btnSalvar.Enabled = true;
            cboUF.Enabled = true;
            txtBairro.Enabled = true;
            txtNumero.Enabled = true;
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;
            txtComplemento.Enabled = true;

            toolTip1.Show("Buscar", btnBuscar);

            strSql = "select*from fornecedor where CNPJ=@pesquisa ";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtPesquisa.Text.Replace("-", "").Replace("/", "").Replace(",", "").Trim();

            try
            {

                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if (txtPesquisa.Text == string.Empty)
                {
                    MessageBox.Show("VOCÊ NÃO DIGITOU UM CNPJ.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dr.HasRows == false)
                {
                    MessageBox.Show("ESTE CNPJ NÃO ESTÁ CADASTRADO", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              


                dr.Read();

                txtRazaoSocial.Text = Convert.ToString(dr["RazaoSocial"]);
                txtNomeFantasia.Text = Convert.ToString(dr["NomeFantasia"]);
                mskTelefone.Text = Convert.ToString(dr["Telefone"]);
                mskCelular.Text = Convert.ToString(dr["Celular"]);
                txtEmail.Text = Convert.ToString(dr["Email"]);
                mskCEP.Text = Convert.ToString(dr["CEP"]);
                mskCNPJ.Text = Convert.ToString(dr["CNPJ"]);
                txtLogradouro.Text = Convert.ToString(dr["Logradouro"]);
                txtCidade.Text = Convert.ToString(dr["Cidade"]);
                cboUF.Text = Convert.ToString(dr["UF"]);
                txtBairro.Text = Convert.ToString(dr["Bairro"]);
                txtNumero.Text = Convert.ToString(dr["Numero"]);
                txtComplemento.Text = Convert.ToString(dr["Complemento"]);
                cboStatus.Text = Convert.ToString(dr["StatusForn"]);

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

            strSql = "update fornecedor set RazaoSocial=@RazaoSocial, NomeFantasia=@NomeFantasia, Telefone=@Telefone, Celular=@Celular, Email=@Email, CEP=@CEP, CNPJ=@CNPJ, Logradouro=@Logradouro, Cidade=@Cidade, UF=@UF, Bairro=@Bairro, Numero=@Numero, Complemento=@Complemento, StatusForn=@StatusForn where CNPJ=@CNPJ";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

          
            comando.Parameters.Add("@RazaoSocial", SqlDbType.VarChar).Value = txtRazaoSocial.Text;
            comando.Parameters.Add("@NomeFantasia", SqlDbType.VarChar).Value = txtNomeFantasia.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text.Replace("-", "").Replace("(", "").Replace(")", "").Trim();
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = mskCelular.Text.Replace("-", "").Replace("(", "").Replace(")", "").Trim();
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCEP.Text.Replace("-", "");
            comando.Parameters.Add("@CNPJ", SqlDbType.VarChar).Value = mskCNPJ.Text.Replace("-", "").Replace("/", "").Replace(",", "").Replace(".", "").Trim();
            comando.Parameters.Add("@Logradouro", SqlDbType.VarChar).Value = txtLogradouro.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = cboUF.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
            comando.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = txtComplemento.Text;
            comando.Parameters.Add("@StatusForn", SqlDbType.VarChar).Value = cboStatus.Text;

            try
            {
                if (txtRazaoSocial.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO RAZÃO SOCIAL", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtNomeFantasia.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO NOME FANTASIA", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (mskTelefone.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO TELEFONE", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (mskCelular.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CELULAR", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO E-MAIL", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (mskCNPJ.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CNPJ", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (mskCEP.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CEP", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtLogradouro.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO LOGRADOURO", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtCidade.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CIDADE", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (cboUF.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO UF", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtBairro.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO BAIRRO", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtNumero.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO NUMERO", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    sqlCon.Open();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("CADASTRO ALTERADO COM SUCESSO!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    txtPesquisa.Enabled = true;

                    //UF
                    txtRazaoSocial.Clear();
                    txtNomeFantasia.Clear();
                    mskTelefone.Clear();
                    mskCelular.Clear();
                    txtEmail.Clear();
                    mskCEP.Clear();
                    mskCNPJ.Clear();
                    txtLogradouro.Clear();
                    txtCidade.Clear();
                    txtPesquisa.Clear();
                    cboUF.Text = " ";
                    txtBairro.Clear();
                    txtNumero.Clear();
                    cboStatus.Text = " ";
                    txtComplemento.Clear();

                }

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

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Apagar", btnApagar);

            strSql = "update fornecedor set StatusForn = 'inativo' where CNPJ=@CNPJ";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@CNPJ", SqlDbType.VarChar).Value = mskCNPJ.Text;

            if (mskCNPJ.Text == string.Empty.Trim())
            {
                MessageBox.Show("DIGITE UM CNPJ CADASTRADO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try

                {

                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("EXCLUSÃO DE CADASTRO FEITA COM SUCESSO.", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    // limpar
                    txtRazaoSocial.Clear();
                    txtNomeFantasia.Clear();
                    mskTelefone.Clear();
                    mskCelular.Clear();
                    txtEmail.Clear();
                    mskCEP.Clear();
                    mskCNPJ.Clear();
                    txtLogradouro.Clear();
                    txtCidade.Clear();
                    txtPesquisa.Clear();
                    cboUF.Text = " ";
                    cboStatus.Text = " ";
                    txtBairro.Clear();
                    txtComplemento.Clear();
                    txtNumero.Clear();
                    txtComplemento.Clear();
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
            }           

            
        }





        private void addfornecedor_Load(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        public void PreencherCEP()
        {
            string strConn = "server = localhost; database=Projeto; user id = sa; password=123456";
            SqlConnection con = new SqlConnection(strConn);
            string strQuery = "SELECT * FROM Cep WHERE CEP='" + mskCEP.Text + "' ";
            SqlCommand cmd = new SqlCommand(strQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (!dr.HasRows)
            {
                MessageBox.Show("CEP NÃO ENCONTRADO!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cboUF.Text = Convert.ToString(dr["UF"]);
                txtCidade.Text = Convert.ToString(dr["Cidade"]);
                txtBairro.Text = Convert.ToString(dr["Bairro"]);
                txtLogradouro.Text = Convert.ToString(dr["Logradouro"]);
            }
        }

        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PreencherCEP();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PreencherCEP();
        }

        public void VefiricarEmail()
        {
            string email = txtEmail.Text;

            Regex rg = new regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (rg.IsMatch(email))
            {
                //  MessageBox.Show("Email Valido!");
            }
            else
            {
                MessageBox.Show("DIGITE UM EMAIL VALIDO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Clear();
            }
        }


        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEmail.Text.Trim().Length != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    VefiricarEmail();
                    
                }
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim().Length != 0)
            {
                VefiricarEmail();
            }
        }


            private static bool IsCnpj(string cnpj)
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
                if (cnpj.Length != 14)
                    return false;

                string tempCnpj = cnpj.Substring(0, 12);
                int soma = 0;

                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

                int resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                string digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cnpj.EndsWith(digito);
            }
        

        private void mskCNPJ_Leave(object sender, EventArgs e)
        {
            if (mskCNPJ.Text.Trim().Length != 0)
            {
                if (IsCnpj(mskCNPJ.Text))
                {

                }
                else
                {
                    MessageBox.Show("DIGITE UM CNPJ VALIDO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskCNPJ.Clear();
                }

            }
        }

        private void mskCNPJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (mskCNPJ.Text.Trim().Length != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsCnpj(mskCNPJ.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("DIGITE UM CNPJ VALIDO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        mskCNPJ.Clear();
                    }
                }
            }

        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRazaoSocial.Enabled = true;
                txtNomeFantasia.Enabled = true;
                mskTelefone.Enabled = true;
                mskCelular.Enabled = true;
                txtEmail.Enabled = true;
                mskCEP.Enabled = true;
                mskCNPJ.Enabled = true;
                txtLogradouro.Enabled = true;
                txtCidade.Enabled = true;
                txtPesquisa.Enabled = true;
                btnSalvar.Enabled = true;
                cboUF.Enabled = true;
                txtBairro.Enabled = true;
                txtNumero.Enabled = true;
                btnApagar.Enabled = true;
                btnEditar.Enabled = true;
                txtComplemento.Enabled = true;

                toolTip1.Show("Buscar", btnBuscar);

                strSql = "select*from fornecedor where CNPJ=@pesquisa ";

                sqlCon = new SqlConnection(strCon);

                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtPesquisa.Text.Replace("-", "").Replace("/", "").Replace(",", "").Trim();

                try
                {
                    

                    sqlCon.Open();
                    SqlDataReader dr = comando.ExecuteReader();

                    if (dr.HasRows == false)
                    {
                        MessageBox.Show("ESTE CNPJ NÃO ESTÁ CADASTRADO", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else if (txtPesquisa.Text == string.Empty)
                    {
                        MessageBox.Show("VOCÊ NÃO DIGITOU UM CNPJ.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

              
                   

                    dr.Read();

                    txtRazaoSocial.Text = Convert.ToString(dr["RazaoSocial"]);
                    txtNomeFantasia.Text = Convert.ToString(dr["NomeFantasia"]);
                    mskTelefone.Text = Convert.ToString(dr["Telefone"]);
                    mskCelular.Text = Convert.ToString(dr["Celular"]);
                    txtEmail.Text = Convert.ToString(dr["Email"]);
                    mskCEP.Text = Convert.ToString(dr["CEP"]);
                    mskCNPJ.Text = Convert.ToString(dr["CNPJ"]);
                    txtLogradouro.Text = Convert.ToString(dr["Logradouro"]);
                    txtCidade.Text = Convert.ToString(dr["Cidade"]);
                    cboUF.Text = Convert.ToString(dr["UF"]);
                    txtBairro.Text = Convert.ToString(dr["Bairro"]);
                    txtNumero.Text = Convert.ToString(dr["Numero"]);
                    txtComplemento.Text = Convert.ToString(dr["Complemento"]);
                    txtPesquisa.Clear();
                }

                catch (Exception ex)
                {
                  //  MessageBox.Show(ex.Message);
                }

                finally
                {
                    sqlCon.Close();
                }
                

            }
        }

        private void txtPesquisa_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }



        public static bool ValidaCNPJ(string vrCNPJ)

        {

            string CNPJ = vrCNPJ.Replace(".", "");

            CNPJ = CNPJ.Replace("/", "");

            CNPJ = CNPJ.Replace("-", "");



            int[] digitos, soma, resultado;

            int nrDig;

            string ftmt;

            bool[] CNPJOk;



            ftmt = "6543298765432";

            digitos = new int[14];

            soma = new int[2];

            soma[0] = 0;

            soma[1] = 0;

            resultado = new int[2];

            resultado[0] = 0;

            resultado[1] = 0;

            CNPJOk = new bool[2];

            CNPJOk[0] = false;

            CNPJOk[1] = false;



            try

            {

                for (nrDig = 0; nrDig < 14; nrDig++)

                {

                    digitos[nrDig] = int.Parse(

                        CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)

                        soma[0] += (digitos[nrDig] *

                          int.Parse(ftmt.Substring(

                          nrDig + 1, 1)));

                    if (nrDig <= 12)

                        soma[1] += (digitos[nrDig] *

                          int.Parse(ftmt.Substring(

                          nrDig, 1)));

                }



                for (nrDig = 0; nrDig < 2; nrDig++)

                {

                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (

                         resultado[nrDig] == 1))

                        CNPJOk[nrDig] = (

                        digitos[12 + nrDig] == 0);

                    else

                        CNPJOk[nrDig] = (

                        digitos[12 + nrDig] == (

                        11 - resultado[nrDig]));

                }

                return (CNPJOk[0] && CNPJOk[1]);

            }

            catch

            {

                return false;

            }

        }

        private void mskCNPJ_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void mskCNPJ_Leave_1(object sender, EventArgs e)
        {
            if (mskCNPJ.Text.Trim().Length != 0)
            {
                if (ValidaCNPJ(mskCNPJ.Text))
                {

                }
                else
                {
                    MessageBox.Show("DIGITE UM CNPJ VALIDO!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskCNPJ.Clear();
                }

            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void txtPesquisa_Click(object sender, EventArgs e)
        {
            txtPesquisa.SelectionStart = 0;
        }

        private void mskTelefone_Click(object sender, EventArgs e)
        {
            mskTelefone.SelectionStart = 0;
        }

        private void mskCelular_Click(object sender, EventArgs e)
        {
            mskCelular.SelectionStart = 0;
        }

        private void mskCNPJ_Click(object sender, EventArgs e)
        {
            mskCNPJ.SelectionStart = 0;
        }

        private void mskCEP_Click(object sender, EventArgs e)
        {
            mskCEP.SelectionStart = 0;
        }
    }
}