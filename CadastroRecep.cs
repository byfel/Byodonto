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
    public partial class CadastroRecep : Form
    {
        public CadastroRecep()
        {
            InitializeComponent();
            DisplayRec();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\soufe\OneDrive\Documentos\ClinDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CadastroRecep_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void DisplayRec()
        {
            conn.Open();
            string Query = "select * from RecepTb ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            RecepcaoDGV.DataSource = ds.Tables[0];



            conn.Close();

        }
        private void button1_Cadastrar_Click(object sender, EventArgs e)
        {
            if (textBox_NameRec.Text == "" || textBox5_SenhaRec.Text == "" || textBox3_PhoneRec.Text == "" || textBox4_LoginRec.Text == "")
            {
                MessageBox.Show("Informações incompletas");
            } else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO RecepTb(RecpNome,RecpPhone,RecPLogin,RecpSenha) VALUES(@RN,@RP,@RL,@RS)", conn);
                    cmd.Parameters.AddWithValue("@RN", textBox_NameRec.Text);
                    cmd.Parameters.AddWithValue("@RP", textBox3_PhoneRec.Text);
                    cmd.Parameters.AddWithValue("@RL", textBox4_LoginRec.Text);
                    cmd.Parameters.AddWithValue("@RS", textBox5_SenhaRec.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário Cadastrado");
                    conn.Close();
                    DisplayRec();
                    Clear();

                } catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }
        int Key = 0;
        private void RecepcaoDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox_NameRec.Text = RecepcaoDGV.SelectedRows[0].Cells[1].Value.ToString();
                textBox3_PhoneRec.Text = RecepcaoDGV.SelectedRows[0].Cells[2].Value.ToString();
                textBox4_LoginRec.Text = RecepcaoDGV.SelectedRows[0].Cells[3].Value.ToString();
                textBox5_SenhaRec.Text = RecepcaoDGV.SelectedRows[0].Cells[3].Value.ToString();
                if (textBox_NameRec.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(textBox_NameRec.Text = RecepcaoDGV.SelectedRows[0].Cells[0].Value.ToString());
                }

            }catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }

        private void button1_Edit_Click(object sender, EventArgs e)
        {
            if (textBox_NameRec.Text == "" || textBox5_SenhaRec.Text == "" || textBox3_PhoneRec.Text == "" || textBox4_LoginRec.Text == "")
            {
                MessageBox.Show("Informações incompletas");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE RecepTb SET RecpNome=@RN,RecpPhone=@RP,RecPLogin=@RL,RecpSenha=@RS where RecepID=@Rkey ", conn);
                    cmd.Parameters.AddWithValue("@RN", textBox_NameRec.Text);
                    cmd.Parameters.AddWithValue("@RP", textBox3_PhoneRec.Text);
                    cmd.Parameters.AddWithValue("@RL", textBox4_LoginRec.Text);
                    cmd.Parameters.AddWithValue("@RS", textBox5_SenhaRec.Text);
                    cmd.Parameters.AddWithValue("@Rkey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário Atualizado");
                    conn.Close();
                    DisplayRec();
                    Clear();

                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }

        }

        private void button2_del_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Informações ");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from RecepTb where RecepID=@Rkey ", conn);

                    cmd.Parameters.AddWithValue("@Rkey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário Deletado");
                    conn.Close();
                    DisplayRec();
                    Clear();

                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }


            }
        }
        private void Clear()
        {
            textBox_NameRec.Text = "";
            textBox5_SenhaRec.Text = "";
            textBox3_PhoneRec.Text = "";
            textBox4_LoginRec.Text = "";
            Key = 0;
        }
        private void button2_Voltar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
