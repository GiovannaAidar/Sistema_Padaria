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
    public partial class DesejaCPF : Form
    {

        public static int RESPOSTA_CPF = 0;

        public DesejaCPF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            RESPOSTA_CPF = 1;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RESPOSTA_CPF = 0;
            this.Visible = false;
            //this.Close();
            
            
        }
    }
}
