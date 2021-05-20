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
    public partial class addcliente : Form
    {
        public addcliente()
        {

            
            InitializeComponent();

          //  txtNome.Enabled = false;
          //  mskTelefone.Enabled = false;
          //  mskCPF.Enabled = false;
          //  txtEmail.Enabled = false;
          //  txtLogradouro.Enabled = false;
          //  txtNumero.Enabled = false;
          //  txtBairro.Enabled = false;
          //  mskRG.Enabled = false;
          //  cboUF.Enabled = false;
          //  mskCelular.Enabled = false;
          //  txtPesquisa.Enabled = true;
          //  //btnSalvar.Enabled = false;
          //  txtCidade.Enabled = false;
          //  mskCEP.Enabled = false;
          //  cboSexo.Enabled = false;
          //  mskNascimento.Enabled = false;
          //  btnApagar.Enabled = false;
          ////  btnEditar.Enabled = false;
          //  txtComplemento.Enabled = false;

            mskRG.MaxLength = 14;
        }

        SqlConnection sqlCon = null;
        private string strCon = "server = localhost; database=Projeto; user id = sa; password=123456";
        private string strSql = string.Empty;


        private void addcliente_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Apagar", btnApagar);

            


            strSql = " delete from Encomendas where IDcliente=@IDcliente " + " delete from venda where CPFcliente=@CPF " + " delete from Faleconosco where idcliente=@IDcliente " + " delete from cliente where CPF=@CPF " ; 
            //strSql = "delete from cliente where CPF=@CPF "; 

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@IDcliente", SqlDbType.VarChar).Value = txtIDcliente.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = mskCPF.Text;
           





            if (mskCPF.Text == string.Empty.Trim())
            {
                MessageBox.Show("DIGITE UM CPF CADASTRADO!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("EXCLUSÃO DE CADASTRO CONCLUIDA COM SUCESSO.", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

                // limpar
                txtNome.Clear();
                mskTelefone.Clear();
                txtEmail.Clear();
                txtLogradouro.Clear();
                txtNumero.Clear();
                txtBairro.Clear();
                mskRG.Clear();
                mskCPF.Clear();
                mskCelular.Clear();
                mskCEP.Clear();
                txtCidade.Clear();
                mskNascimento.Text = DateTime.Now.ToString();

                cboSexo.Text = " ";
                cboUF.Text = " ";
                txtComplemento.Clear();

            }

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Limpar", btnAdicionar);

          //  txtNome.Enabled = true;
          //  mskTelefone.Enabled = true;
          //  mskCPF.Enabled = true;
          //  txtEmail.Enabled = true;
          //  txtLogradouro.Enabled = true;
          //  txtNumero.Enabled = true;
          //  txtBairro.Enabled = true;
          //  mskRG.Enabled = true;
          //  mskCelular.Enabled = true;
          //  txtPesquisa.Enabled = true;
          //  //btnSalvar.Enabled = true;
          //  cboUF.Enabled = true;
          //  mskCEP.Enabled = true;
          //  txtCidade.Enabled = true;
          //  cboSexo.Enabled = true;
          ////  btnEditar.Enabled = true;
          //  btnApagar.Enabled = true;
          //  txtComplemento.Enabled = true;
          //  mskNascimento.Enabled = true;

            txtNome.Clear();
            mskTelefone.Clear();
            txtEmail.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            mskRG.Clear();
            mskCPF.Clear();
            mskCelular.Clear();
            mskCEP.Clear();
            txtCidade.Clear();
            mskNascimento.Text = DateTime.Now.ToString();
            cboSexo.Text = " ";
            cboUF.Text = " ";
            txtComplemento.Clear();

        }

        //private void btnSalvar_Click(object sender, EventArgs e)
        //{
        //    toolTip1.Show("Salvar", btnSalvar);

        //    strSql = "insert into cliente(Nome,Telefone,Celular,Email,Sexo,DataNascimento,CEP,Logradouro,Cidade,UF,Bairro,Numero,RG,CPF,Complemento) values(@Nome,@Telefone,@Celular,@Email,@Sexo,@DataNascimento,@CEP,@Logradouro,@Cidade,@UF,@Bairro,@Numero,@RG,@CPF,@Complemento)";

        //    sqlCon = new SqlConnection(strCon);

        //    SqlCommand comando = new SqlCommand(strSql, sqlCon);

        //    comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
        //    comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
        //    comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = mskCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
        //    comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
        //    comando.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = cboSexo.Text;
        //    comando.Parameters.Add("@DataNascimento", SqlDbType.VarChar).Value = mskNascimento.Value;
        //    comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCEP.Text.Replace("-", "").Trim();
        //    comando.Parameters.Add("@Logradouro", SqlDbType.VarChar).Value = txtLogradouro.Text;
        //    comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
        //    comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = cboUF.Text;
        //    comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
        //    comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
        //    comando.Parameters.Add("@RG", SqlDbType.VarChar).Value = mskRG.Text.Replace(".", "").Replace("-", "").Trim();
        //    comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = mskCPF.Text.Replace(",", "").Replace("-", "").Trim();
        //    comando.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = txtComplemento.Text;


        //    try
        //    {
        //        if (txtNome.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO NOME", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

               

        //        else if (txtEmail.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO EMAIL", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (cboSexo.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO SEXO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (mskCPF.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO CPF", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (mskNascimento.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO DAT. NASCIMENTO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (mskRG.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO RG", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (mskCEP.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO CEP", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (txtLogradouro.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO LOGRADOURO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (txtCidade.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO CIDADE", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (cboUF.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO UF", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (txtBairro.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO BAIRRO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (txtNumero.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO NUMERO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else if (txtNumero.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO COMPLEMENTO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            sqlCon.Open();

        //            comando.ExecuteNonQuery();

        //            MessageBox.Show("CADASTRO EFETUADO COM SUCESSO!");

        //            txtNome.Clear();
        //            mskTelefone.Clear();
        //            txtEmail.Clear();
        //            txtLogradouro.Clear();
        //            txtNumero.Clear();
        //            txtBairro.Clear();
        //            mskRG.Clear();
        //            mskCPF.Clear();
        //            mskCelular.Clear();
        //            mskCEP.Clear();
        //            txtCidade.Clear();
        //            mskNascimento.Text = DateTime.Now.ToString();

        //            cboSexo.Text = " ";
        //            cboUF.Text = " ";
        //            txtComplemento.Clear();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.ToString().Contains("UNIQUE"))
        //        {
        //            MessageBox.Show("ESSE FUNCIONÁRIO JÁ ESTÁ CADASTRADO!");
        //        }
        //    }

        //    finally
        //    {
        //        sqlCon.Close();
        //    }

        //    txtPesquisa.Enabled = true;

        //    //UF


        //}

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          //  txtNome.Enabled = true;
          //  mskTelefone.Enabled = true;
          //  mskCPF.Enabled = true;
          //  txtEmail.Enabled = true;
          //  txtLogradouro.Enabled = true;
          //  txtNumero.Enabled = true;
          //  txtBairro.Enabled = true;
          //  mskRG.Enabled = true;
          //  mskCelular.Enabled = true;
          //  txtPesquisa.Enabled = true;
          //  //btnSalvar.Enabled = true;
          //  cboUF.Enabled = true;
          //  mskNascimento.Enabled = true;
          //  txtCidade.Enabled = true;
          //  cboSexo.Enabled = true;
          //  mskCEP.Enabled = true;
          ////  btnEditar.Enabled = true;
          //  btnApagar.Enabled = true;
          //  txtComplemento.Enabled = true;

            toolTip1.Show("Buscar", btnBuscar);

            strSql = "select*from cliente where CPF=@pesquisa ";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtPesquisa.Text.Replace(",", "").Replace("-", "").Trim();

            try
            {
                


                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if (txtPesquisa.Text == string.Empty)
                {
                    MessageBox.Show("VOCÊ NÃO DIGITOU UM CPF.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (dr.HasRows == false)
                {
                    MessageBox.Show("ESTE CPF NÃO ESTÁ CADASTRADO", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                dr.Read();

                txtIDcliente.Text = Convert.ToString(dr["IDcliente"]);
                txtNome.Text = Convert.ToString(dr["Nome"]);
                mskTelefone.Text = Convert.ToString(dr["Telefone"]);
                mskCelular.Text = Convert.ToString(dr["Celular"]);
                txtEmail.Text = Convert.ToString(dr["Email"]);
                cboSexo.Text = Convert.ToString(dr["Sexo"]);
                mskNascimento.Text = Convert.ToString(dr["DataNascimento"]);
                mskCEP.Text = Convert.ToString(dr["CEP"]);
                txtLogradouro.Text = Convert.ToString(dr["Logradouro"]);
                txtCidade.Text = Convert.ToString(dr["Cidade"]);
                cboUF.Text = Convert.ToString(dr["UF"]);
                txtBairro.Text = Convert.ToString(dr["Bairro"]);
                txtNumero.Text = Convert.ToString(dr["Numero"]);
                mskRG.Text = Convert.ToString(dr["RG"]);
                mskCPF.Text = Convert.ToString(dr["CPF"]);
                txtComplemento.Text = Convert.ToString(dr["Complemento"]);

            }

            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlCon.Close();
            }
            txtPesquisa.Clear();


        }

        //private void btnEditar_Click(object sender, EventArgs e)
        //{
        //    toolTip1.Show("Editar", btnEditar);

        //    strSql = "update cliente set Nome=@Nome, Telefone=@Telefone, Celular=@Celular, Email=@Email, Sexo=@Sexo, DataNascimento=@DataNascimento, CEP=@CEP, Logradouro=@Logradouro, Cidade=@Cidade, UF=@UF, Bairro=@Bairro, Numero=@Numero, RG=@RG,Complemento=@Complemento where CPF=@CPF";

        //    sqlCon = new SqlConnection(strCon);

        //    SqlCommand comando = new SqlCommand(strSql, sqlCon);

        //    comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
        //    comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
        //    comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = mskCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
        //    comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
        //    comando.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = cboSexo.Text;
        //    comando.Parameters.Add("@DataNascimento", SqlDbType.VarChar).Value = mskNascimento.Value;
        //    comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCEP.Text.Replace("-", "").Trim();
        //    comando.Parameters.Add("@Logradouro", SqlDbType.VarChar).Value = txtLogradouro.Text;
        //    comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
        //    comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = cboUF.Text;
        //    comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
        //    comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
        //    comando.Parameters.Add("@RG", SqlDbType.VarChar).Value = mskRG.Text.Replace(".", "").Replace("-", "").Trim();
        //    comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = mskCPF.Text.Replace(",", "").Replace("-", "").Trim();

        //    comando.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = txtComplemento.Text;


        //    try
        //    {
        //        if (txtNome.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO NOME", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }



        //        else if (txtEmail.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO EMAIL", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (cboSexo.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO SEXO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }


        //        else if (mskNascimento.Text == string.Empty)
        //        {
        //            MessageBox.Show("DATA INVÁLIDA", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (mskRG.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO RG", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (mskCPF.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO CPF", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (mskCEP.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO CEP", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (txtLogradouro.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO LOGRADOURO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (txtCidade.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO CIDADE", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (cboUF.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO UF", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (txtBairro.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO BAIRRO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else if (txtNumero.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO NUMERO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else if (txtNumero.Text == string.Empty)
        //        {
        //            MessageBox.Show("PREENCHA O CAMPO COMPLEMENTO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        else
        //        {
        //            sqlCon.Open();

        //            comando.ExecuteNonQuery();

        //            MessageBox.Show("CADASTRO ALTERADO COM SUCESSO!");

        //            txtPesquisa.Enabled = true;

        //            //UF
        //            txtNome.Clear();
        //            mskTelefone.Clear();
        //            txtEmail.Clear();
        //            txtLogradouro.Clear();
        //            txtNumero.Clear();
        //            txtBairro.Clear();
        //            mskRG.Clear();
        //            mskCPF.Clear();
        //            mskCelular.Clear();
        //            mskCEP.Clear();
        //            txtCidade.Clear();
        //            mskNascimento.Text = DateTime.Now.ToString();
        //            cboSexo.Text = " ";
        //            cboUF.Text = " ";
        //            txtComplemento.Clear();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        // throw;
        //    }
        //    finally
        //    {
        //        sqlCon.Close();
        //    }


        //}

        private void mskCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        public void PreencherCEP()
        {
            string strConn = @"server = localhost; database=Projeto; user id = sa; password=123456";
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

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

        private void groupBox3_Leave(object sender, EventArgs e)
        {

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

        public static bool verificarCPF(string CPF)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return CPF.EndsWith(Digito);
        }
      

        private void mskCPF_Leave(object sender, EventArgs e)
        {
            
            {
                if (mskCPF.Text.Trim().Length != 0)
                {
                    if (verificarCPF(mskCPF.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("DIGITE UM CPF VALIDO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        mskCPF.Clear();
                    }

                }




            }
        }

        private void mskCPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (mskCPF.Text.Trim().Length != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (verificarCPF(mskCPF.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("DIGITE UM CPF VALIDO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        mskCPF.Clear();
                    }
                }
            }

        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNome.Enabled = true;
                mskTelefone.Enabled = true;
                mskCPF.Enabled = true;
                txtEmail.Enabled = true;
                txtLogradouro.Enabled = true;
                txtNumero.Enabled = true;
                txtBairro.Enabled = true;
                mskRG.Enabled = true;
                mskCelular.Enabled = true;
                txtPesquisa.Enabled = true;
                // btnSalvar.Enabled = true;
                cboUF.Enabled = true;
                mskNascimento.Enabled = true;
                txtCidade.Enabled = true;
                cboSexo.Enabled = true;
                mskCEP.Enabled = true;
               // btnEditar.Enabled = true;
                btnApagar.Enabled = true;
                txtComplemento.Enabled = true;

                toolTip1.Show("Buscar", btnBuscar);

                strSql = "select*from cliente where CPF=@pesquisa ";

                sqlCon = new SqlConnection(strCon);

                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtPesquisa.Text.Replace(",", "").Replace("-", "").Trim();

                try
                {
                    if (txtPesquisa.Text == string.Empty)
                    {
                        MessageBox.Show("VOCÊ NÃO DIGITOU UM CPF.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    sqlCon.Open();
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        MessageBox.Show("ESTE CPF NÃO ESTÁ CADASTRADO", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    dr.Read();

                    txtNome.Text = Convert.ToString(dr["Nome"]);
                    mskTelefone.Text = Convert.ToString(dr["Telefone"]);
                    mskCelular.Text = Convert.ToString(dr["Celular"]);
                    txtEmail.Text = Convert.ToString(dr["Email"]);
                    cboSexo.Text = Convert.ToString(dr["Sexo"]);
                    mskNascimento.Text = Convert.ToString(dr["DataNascimento"]);
                    mskCEP.Text = Convert.ToString(dr["CEP"]);
                    txtLogradouro.Text = Convert.ToString(dr["Logradouro"]);
                    txtCidade.Text = Convert.ToString(dr["Cidade"]);
                    cboUF.Text = Convert.ToString(dr["UF"]);
                    txtBairro.Text = Convert.ToString(dr["Bairro"]);
                    txtNumero.Text = Convert.ToString(dr["Numero"]);
                    mskRG.Text = Convert.ToString(dr["RG"]);
                    mskCPF.Text = Convert.ToString(dr["CPF"]);
                    txtComplemento.Text = Convert.ToString(dr["Complemento"]);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    sqlCon.Close();
                }
                txtPesquisa.Clear();

            }
        }

        private void mskNascimento_Validated(object sender, EventArgs e)
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataInvalida = dataAtual.AddYears(-18);
            DateTime dataSist = mskNascimento.Value;
            if (dataSist > dataInvalida)
            {
                MessageBox.Show("É NECESSARIO QUE O CLIENTE SEJA MAIOR DE IDADE\nPARA QUE O CADASTRO SEJA EFETUADO COM SUCESSO!", "DATA INVÁLIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskNascimento.Focus();
            }
        }

        private void mskNascimento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void txtPesquisa_Click(object sender, EventArgs e)
        {
            txtPesquisa.SelectionStart = 0;
        }

        private void mskCelular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskCelular_Click(object sender, EventArgs e)
        {
            mskCelular.SelectionStart = 0;
        }

        private void mskCPF_Click(object sender, EventArgs e)
        {
            mskCPF.SelectionStart = 0;
        }

        private void mskCEP_Click(object sender, EventArgs e)
        {
            mskCEP.SelectionStart = 0;
        }
    }
}


