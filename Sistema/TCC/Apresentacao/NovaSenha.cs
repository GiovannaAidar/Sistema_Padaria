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
using TCC.Modelo;

namespace TCC.Apresentacao
{
    public partial class NovaSenha : Form
    {
        public NovaSenha()
        {
            InitializeComponent();

            txtEmail.MaxLength = 50;
            txtSenha.MaxLength = 25;
            txtSenhaNova.MaxLength = 25;
            txtConfirmar.MaxLength = 25;
            

        }

        SqlConnection sqlCon = null;
        private string strCon = "server = localhost; database=Projeto; user id = sa; password=123456";
        private string strSql = string.Empty;

        private void txbLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txbSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                if (txtSenhaNova.Text == txtConfirmar.Text)
                {
                    strSql = "update logins set Senha=@NovaSenha where Email=@Email and Senha=@Senha ";

                    sqlCon = new SqlConnection(strCon);

                    SqlCommand comando = new SqlCommand(strSql, sqlCon);

                    comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                    comando.Parameters.Add("@Senha", SqlDbType.VarChar).Value = txtSenha.Text;
                    comando.Parameters.Add("@NovaSenha", SqlDbType.VarChar).Value = txtSenhaNova.Text;


                    try
                    {
                        if (txtConfirmar.Text == string.Empty)
                        {
                            MessageBox.Show("CONFIRME A SUA SENHA","ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                       

                        if (txtEmail.Text == string.Empty)
                        {
                            MessageBox.Show("DIGITE O EMAIL", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtSenha.Text == string.Empty)
                        {
                            MessageBox.Show("DIGITE SUA SENHA ATUAL", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtSenhaNova.Text == string.Empty)
                        {
                            MessageBox.Show("DIGITE SUA NOVA SENHA", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtSenhaNova.Text == string.Empty)
                        {
                            MessageBox.Show("CONFIRME A SUA SENHA", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        else if (txtSenhaNova.Text.Length < 6) //Ou qualquer outro número que você definir
                        {
                            MessageBox.Show ("A SENHA DEVE CONTER NO MÍNIMO 6 CARACTERES", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        else if (txtConfirmar.Text.Length < 6) //Ou qualquer outro número que você definir
                        {
                            MessageBox.Show("A SENHA DEVE CONTER NO MÍNIMO 6 CARACTERES", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                        else
                        {
                            sqlCon.Open();

                            comando.ExecuteNonQuery();

                            MessageBox.Show("SENHA ALTERADA COM SUCESSO!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtEmail.Clear();
                            txtSenha.Clear();
                            txtSenhaNova.Clear();
                            txtConfirmar.Clear();
                            checkBox4.Checked = false;
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
                else
                {
                    MessageBox.Show("AS SENHAS NÃO SE COINCIDEM", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenhaNova.Clear();
                    txtConfirmar.Clear();
                }
            }
            else
            {
                MessageBox.Show("VERIFIQUE SEUS DADOS!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void NovaSenha_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    txtSenha.PasswordChar = '\u0000';
                }
                else
                {
                    txtSenha.PasswordChar = '•';
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == true)
                {
                    txtSenhaNova.PasswordChar = '\u0000';
                }
                else
                {
                    txtSenhaNova.PasswordChar = '•';
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked == true)
                {
                    txtConfirmar.PasswordChar = '\u0000';
                }
                else
                {
                    txtConfirmar.PasswordChar = '•';
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtSenha_MouseDown(object sender, MouseEventArgs e)
        {
             
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            
        }

        public void Logar()
        {
            if (checkBox4.Checked == true)
            {
                Controle controle = new Controle();
                controle.acessar(txtEmail.Text, txtSenha.Text);
                if (controle.mensagem.Equals(""))
                {

                    if (controle.tem)
                    {
                        MessageBox.Show("CONTA VERIFICADA. \nDIGITE UMA NOVA SENHA!", "VERIFICAÇÃO COMPLETA!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        txtSenha.Clear();
                        MessageBox.Show("EMAIL OU SENHA INCORRETOS", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkBox4.Checked = false;

                    }
                }
                else
                {
                    MessageBox.Show(controle.mensagem);
                }
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            //Logar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Logar();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Logar();
            if (checkBox4.Checked == true)
            {
                txtEmail.Enabled = false;
                txtSenha.Enabled = false;
            }
            else
            {
                txtEmail.Enabled = true;
                txtSenha.Enabled = true;
            }
        }
    }
}
