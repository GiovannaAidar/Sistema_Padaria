using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC.Apresentacao;
using TCC.Modelo;
using System.Data.SqlClient;
using System.IO;

namespace TCC
{
    public partial class Login : Form
    {

        SqlConnection sqlCon = null;
        private string strCon = "server = localhost; database=Projeto; user id = sa; password=123456";
        private string strSql = string.Empty;

        public Login()
        {
            InitializeComponent();
            txbSenha.MaxLength = 25;
            txbLogin.MaxLength = 50;
        }




        public void Logar()
        {
            Controle controle = new Controle();
            controle.acessar(txbLogin.Text, txbSenha.Text);
            if (controle.mensagem.Equals(""))
            {
                if (txbLogin.Text == string.Empty) //Ou qualquer outro número que você definir
                {
                    MessageBox.Show("DIGITE O E-MAIL!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txbSenha.Text == string.Empty) //Ou qualquer outro número que você definir
                {
                    MessageBox.Show("DIGITE A SENHA!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (controle.tem)
                    {
                        strSql = "SELECT NivelAcesso, usuario FROM Logins WHERE email='"+ txbLogin.Text +"'";
                        sqlCon = new SqlConnection(strCon);
                        sqlCon.Open();
                        SqlCommand comando = new SqlCommand(strSql, sqlCon);
                        SqlDataReader dr = comando.ExecuteReader();
                        dr.Read();
                        string lvlAcesso = dr["NivelAcesso"].ToString();
                        string nome = dr["usuario"].ToString();

                        if (lvlAcesso == "GERENTE" || lvlAcesso == "ATENDENTE")
                        {
                            if (lvlAcesso == "GERENTE")
                            {
                                TelaPrincipal tela = new TelaPrincipal();
                                tela.lblnome.Text = "BEM VINDO(A) " + nome.ToUpper();
                                tela.lblfunc.Text = "GERENTE";
                                tela.ShowDialog();

                                txbLogin.Clear();
                                txbSenha.Clear();
                            }
                            else if (lvlAcesso == "ATENDENTE")
                            {
                                TelaPrincipal tela = new TelaPrincipal();
                                tela.lblnome.Text = "BEM VINDO(A) " + nome.ToUpper();
                                tela.lblfunc.Text = "ATENDENTE";
                                tela.clienteToolStripMenuItem.Enabled = false;
                                tela.fornecedorToolStripMenuItem.Enabled = false;
                                tela.produtoToolStripMenuItem.Enabled = false;
                                tela.ShowDialog();

                                txbLogin.Clear();
                                txbSenha.Clear();
                            }                            
                        }
                        else
                        {
                            MessageBox.Show("O FUNCIONÁRIO NÃO TEM PERMISSÃO\nPARA ACESSAR O SISTEMA!", "USUÁRIO SEM PERMISSÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txbSenha.Clear();
                        }


                    }
                    else
                    {
                        txbSenha.Clear();
                        MessageBox.Show("Login não encontrado", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txbSenha.Clear();
                    }
                }

                
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Logar();
        }
    


        private void Login_Load(object sender, EventArgs e)
        {

        }
    

    private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastreSe_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txbSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void txbSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            Logar();
            checkBox1.Checked = false;
        }

        private void btnSair_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NovaSenha frm = new NovaSenha();
            frm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    txbSenha.PasswordChar = '\u0000';
                }
                else
                {
                    txbSenha.PasswordChar = '•';
                }
            }
            catch (Exception)
            {             
                throw;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public class ButtonImage : Form
        {
            Button btn;
            Image img;

            public ButtonImage()
            {
                Text = "Button Properties";
                Size = new Size(34,33);

                img = Image.FromFile("TCC/Resources/mostrar-senha.png");

                btn = new Button();
                btn.Parent = this;
                btn.Text = "test";
                btn.Location = new Point(350, 267);

                btn.Image = img;

                
            }
           
        }

        private void VerSenha_Click(object sender, EventArgs e)
        {
            Button btn;
            Image img;

            
            
                Text = "Button Properties";
                Size = new Size(34, 33);

                img = Image.FromFile("TCC/Resources/mostrar-senha.png");

                btn = new Button();
                btn.Parent = this;
                btn.Text = "test";
                btn.Location = new Point(350, 267);

                btn.Image = img;


            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.ImageLocation = "iconfinder -lock-open - 4341301_120523.png";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            

        }
        
    }
}
