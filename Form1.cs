using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindData();
        }

        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-GTOJ0GO;Initial Catalog=FormTestDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand cmd = new SqlCommand("insert into testTable values (@id, @name, @age)", sql);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            sql.Close();
            BindData();
            MessageBox.Show("Data successfully inserted!");
        }

        void BindData()
        {
            SqlCommand cmd = new SqlCommand("Select * from testTable", sql);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand cmd = new SqlCommand("update testTable set name = @name, age = @age where id= @id", sql);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            sql.Close();
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand command = new SqlCommand("delete testTable where id = @id", sql);
            command.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            command.ExecuteNonQuery();
            sql.Close ();
            BindData();
        }
    }
}
