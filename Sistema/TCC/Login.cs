using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }






        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if((txtUsuario.Text == "admin") && 
                (txtSenha.Text == "123456"))
            {
                TelaPrincipal telaPrincipal = new TelaPrincipal();
                telaPrincipal.Show();
                this.Visible = false;
                MessageBox.Show("Login efetuado com sucesso!");
            } else
            {
                MessageBox.Show("Usuário ou senha inválidos!");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        public void TrocarSenha (object o, EventArgs e)
        {
            addtrocarsenha add= new addtrocarsenha();
            add.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
