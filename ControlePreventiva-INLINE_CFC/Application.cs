using System;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ControlePreventiva_INLINE_CFC
{
    public partial class Application : Form
    {
        public Application()
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
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados! : " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                controlePreventivasICBindingSource.MoveNext();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados! : " + ex);
            }
        }

        private void deletar_Click(object sender, EventArgs e)
        {
            try
            {
                controlePreventivasICBindingSource.RemoveCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados! : " + ex);
            }
        }

        private void incluir_Click(object sender, EventArgs e)
        {
            try
            {
                controlePreventivasICBindingSource.AddNew();
                textBoxUtilizacao.Text = "0%";
                textBoxAVG.Text = "0";
                textBoxPFAIL.Text = "0";
                textBoxPPASS.Text = "0";
                textBoxPYIELD.Text = "0%";
                textBoxPHANDLE.Text = "0";
                textBoxWeek.Text = "Week_";
                textBoxComentario.Text = "NA";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados! : " + ex);
            }
        }

        private void salvar_Click(object sender, EventArgs e)
        {
            try
            {
                controlePreventivasICBindingSource.EndEdit();
                controlePreventivasICTableAdapter.Update(controlePreventiva_ICDataSet);
                MessageBox.Show("Registro salvo com sucesso!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco de Dados! : " + ex);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=V:\Tools\Controle_Preventiva_IC\ControlePreventiva_IC.mdb; User Id=admin;Password=";
                string query = "SELECT * FROM ControlePreventivasIC";
                string separator = ",";
                string strFilePath = @"C:\temp\Controle_Preventiva_IC_export.csv";

                using (StreamWriter sw = new StreamWriter(strFilePath))
                using (OleDbCommand Cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    using (OleDbDataReader dr = Cmd.ExecuteReader())
                    {
                        int fields = dr.FieldCount - 1;
                        while (dr.Read())
                        {
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i <= fields; i++)
                            {
                                sb.Append(dr[i].ToString() + separator);
                            }
                            sw.WriteLine(sb.ToString());
                        }
                    }
                }
                MessageBox.Show("Dados exportados com sucesso para a folder C:\\temp\\Controle_Preventiva_IC_export.csv!!!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Não foi possivel exportar os dados para o excel!!!! : " + ex);
            }

        }
    }
}
