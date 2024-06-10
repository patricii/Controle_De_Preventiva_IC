using System;
using System.Data;
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
        public static string errorDBMessage = "Não foi possivel conectar com o Banco de Dados! : ";
        public static string saveDBOK = "Registro salvo com sucesso!!!";
        public static string connectionDb = Properties.Settings.Default.ControlePreventiva_ICConnectionString;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.controlePreventivasICTableAdapter.Fill(this.controlePreventiva_ICDataSet.ControlePreventivasIC);
        }
        private void button1_Click(object sender, EventArgs e) //move previous
        {
            try
            {
                controlePreventivasICBindingSource.MovePrevious();
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorDBMessage + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e) //move Next
        {
            try
            {
                controlePreventivasICBindingSource.MoveNext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorDBMessage + ex.Message);
            }
        }
        private void deletar_Click(object sender, EventArgs e) //Delete
        {
            try
            {
                controlePreventivasICBindingSource.RemoveCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorDBMessage + ex.Message);
            }
        }
        private void incluir_Click(object sender, EventArgs e) //Add new
        {
            try
            {
                controlePreventivasICBindingSource.AddNew();
                setField();
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorDBMessage + ex.Message);
            }
        }
        private void salvar_Click(object sender, EventArgs e) //Save
        {
            try
            {
                controlePreventivasICBindingSource.EndEdit();
                controlePreventivasICTableAdapter.Update(controlePreventiva_ICDataSet);
                MessageBox.Show(saveDBOK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorDBMessage + ex.Message);
            }
        }
        private void button1_Click_1(object sender, EventArgs e) //exit
        {
            Environment.Exit(0);
        }
        private void button2_Click_1(object sender, EventArgs e) //csv export
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connectionDb;
            string query = "SELECT * FROM ControlePreventivasIC";
            string separator = ",";
            string strFilePath = @"C:\temp\Controle_Preventiva_IC_export.csv";
            try
            {

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

                MessageBox.Show("Não foi possivel exportar os dados para o excel!!!! : " + ex.Message);
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                conn.Close();
            }

        }
        private void button3_Click(object sender, EventArgs e) //DB backup
        {
            string strFilePath = @"\\jagnt092\transfer\MAPEAMENTO_DE_PONTOS_CFC\ControlePreventiva_IC.mdb";
            string strFileDestination = @"C:\temp\Backup_Controle_Preventiva_IC.mdb";

            try
            {
                File.Copy(strFilePath, strFileDestination, true);
                MessageBox.Show("Backup do DataBase criado com sucesso na folder C:\\temp\\Backup_Controle_Preventiva_IC.mdb!!!");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Não foi possivel criar um backup do DataBase! : " + ex.Message);
            }
        }
        private void setField()
        {
            //setting default
            textBoxUtilizacao.Text = "0%";
            textBoxAVG.Text = "0";
            textBoxPFAIL.Text = "0";
            textBoxPPASS.Text = "0";
            textBoxPYIELD.Text = "0%";
            textBoxPHANDLE.Text = "0";
            textBoxWeek.Text = "Week_";
            textBoxComentario.Text = "NA";
            dateTimePicker1.Value = DateTime.Now;
        }

    }
}
