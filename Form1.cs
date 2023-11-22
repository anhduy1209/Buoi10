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
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public SqlConnection con;
        string a = "Data Source = A209PC41;Initial Catalog = siem;Integrated Security = true";
        public DataTable dataTable;
        public int count = 1;
        public Form1()
        {
            
            
            InitializeComponent();
        }
        
        

        

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            count++;
            LoadQuestion();

        }
        private void LoadDataIntoTextBox()
        {
            SqlCommand cmd = new SqlCommand();
            con = new SqlConnection(a);
            con.Open();
            string query = "SELECT * FROM TracNghiem ";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Đọc giá trị từ cột và đặt nó vào TextBox
                        textBox1.Text = reader["CauHoi"].ToString();
                    }
                    else
                    {
                        // Không tìm thấy dữ liệu
                        textBox1.Text = "No data found";
                    }
                }
            }
        }
        
        private void LoadQuestion()
    {
        using (SqlConnection connection = new SqlConnection(a))
        {
            connection.Open();

            string query = "SELECT CauHoi FROM TracNghiem WHERE SoCau = {count}";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Hiển thị câu hỏi mới
                        textBox1.Text = reader["CauHoi"].ToString();
                        
                    }
                    else
                    {
                        // Đã hết câu hỏi
                        MessageBox.Show("End of questions");
                    }
                }
            }
        }
    }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataIntoTextBox();
        }

        
    }
}
