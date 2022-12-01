using System;
using System.Windows.Forms;

namespace ControlePreventiva_INLINE_CFC
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "manut" && password.Text == "manut2022")
            {
                this.Hide();
                Application ff = new Application();
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
