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
    public partial class Paciente : Form
    {
        public Paciente()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\soufe\OneDrive\Documentos\ClinDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1_NomeP.Text == "" || textBox2_SobNomeP.Text == "" || textBox3_Endrc.Text == "" || textBox4_Bairro.Text == "" || textBox5_Municp.Text == "" || textBox6_Phone.Text == "" || textBox7_NumDOc.Text == "" || textBox8_Alergia.Text == "" || comboBox2_Genero.Text == "" || comboBox3_Tdoc.Text == "" || comboBox4_ALer.Text == "")
            {
                MessageBox.Show("Informações incompletas");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO RecepTb(PatName,PatGenero,PatEndereco,PatMunicipio,PatUF,PatBairro,PatTelefone,PatTipoDoc,PatNumDoc,AlerDesc,Data) VALUES(@PN,@PG,@PE,@PM,@PUF,@PB,@PT,@PTD,@PND,@PALE,@PDATA)", conn);
                    cmd.Parameters.AddWithValue("@PN", textBox1_NomeP.Text);
                    cmd.Parameters.AddWithValue("@PN", textBox2_SobNomeP.Text);
                    cmd.Parameters.AddWithValue("@PE", textBox3_Endrc.Text);
                    cmd.Parameters.AddWithValue("@PB", textBox4_Bairro.Text);
                    cmd.Parameters.AddWithValue("@PM", textBox5_Municp.Text);
                    cmd.Parameters.AddWithValue("@PF", textBox6_Phone.Text);
                    cmd.Parameters.AddWithValue("@PND", textBox7_NumDOc.Text);
                    cmd.Parameters.AddWithValue("@PALE", textBox8_Alergia.Text);

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
