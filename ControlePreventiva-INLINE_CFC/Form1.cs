using System;
using System.Windows.Forms;

namespace ControlePreventiva_INLINE_CFC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "fcsuser" && password.Text == "fcsuser")
            {
                this.Hide();
                Form2 ff = new Form2();
                ff.Show();

            }
            else
            {
                MessageBox.Show("Senha ou usuário incorretos!!!!");
                user.Text = "";
                password.Text = "";
            }
        }
    }
}
