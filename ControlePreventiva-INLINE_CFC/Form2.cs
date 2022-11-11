using System;
using System.Windows.Forms;

namespace ControlePreventiva_INLINE_CFC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'controlePreventiva_ICDataSet.ControlePreventivasIC' table. You can move, or remove it, as needed.
            this.controlePreventivasICTableAdapter.Fill(this.controlePreventiva_ICDataSet.ControlePreventivasIC);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                controlePreventivasICBindingSource.MovePrevious();
            }
            catch {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                controlePreventivasICBindingSource.MoveNext();
            }
            catch
            {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados!");
            }
        }

        private void deletar_Click(object sender, EventArgs e)
        {
            try
            {
                controlePreventivasICBindingSource.RemoveCurrent();
            }
            catch
            {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados!");
            }
        }

        private void incluir_Click(object sender, EventArgs e)
        {
            try
            {
                controlePreventivasICBindingSource.AddNew();
            }
            catch
            {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados!");
            }
        }

        private void salvar_Click(object sender, EventArgs e)
        {
            try
            {
                controlePreventivasICBindingSource.EndEdit();
                controlePreventivasICTableAdapter.Update(controlePreventiva_ICDataSet);
            }
            catch
            {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
