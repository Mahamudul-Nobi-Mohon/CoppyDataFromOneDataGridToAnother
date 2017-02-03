using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CoppyDataFromOneDataGridToAnother
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QR81GF5\SQLEXPRESS;Initial Catalog=Sample_30-11-2016;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Employees", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = false;
                dataGridView1.Rows[n].Cells[1].Value = item["Id"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["FirstName"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["LastName"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["Gender"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["Salary"].ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            foreach (DataGridViewRow items in dataGridView1.Rows)
            {
                if ((bool)items.Cells[0].Value == true)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = items.Cells[1].Value.ToString();
                    dataGridView2.Rows[n].Cells[1].Value = items.Cells[2].Value.ToString();
                    dataGridView2.Rows[n].Cells[2].Value = items.Cells[3].Value.ToString();
                    dataGridView2.Rows[n].Cells[3].Value = items.Cells[4].Value.ToString();
                    dataGridView2.Rows[n].Cells[4].Value = items.Cells[5].Value.ToString();
                
                }

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((bool)dataGridView1.SelectedRows[0].Cells[0].Value == false)
            {
                dataGridView1.SelectedRows[0].Cells[0].Value = true;
            }
            else
            {
                dataGridView1.SelectedRows[0].Cells[0].Value = false;
            }
        }
    }
}
