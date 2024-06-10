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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            if (user.Text == "manut" && password.Text == "manut" + year.ToString())
            {
                Hide();
                Application ff = new Application();
                ff.Show();

            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!!!!");
                user.Text = "";
                password.Text = "";
            }
        }
    }
}
