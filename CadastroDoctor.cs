using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ByOdonto
{
    public partial class CadastroDoctor : Form
    {
        public CadastroDoctor()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\soufe\OneDrive\Documentos\ClinDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CadastroDoctor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1_NameDoc.Text == "" || textBox5_SenhaDoc.Text == "" || textBox3_PhoneDoc.Text == "" || textBox4_LoginDoc.Text == "")
            {
                MessageBox.Show("Informações incompletas");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO DoctorDb(DocName,DocPhone,DocLogin,DocPassword) VALUES(@DN,@DP,@DL,@DS)", conn);
                    cmd.Parameters.AddWithValue("@DN", textBox1_NameDoc.Text);
                    cmd.Parameters.AddWithValue("@DP", textBox3_PhoneDoc.Text);
                    cmd.Parameters.AddWithValue("@DL", textBox4_LoginDoc.Text);
                    cmd.Parameters.AddWithValue("@DS", textBox5_SenhaDoc.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário Cadastrado");
                    conn.Close();

                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }
    }
}
