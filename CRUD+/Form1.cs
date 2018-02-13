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

namespace CRUD_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn;
        SqlDataAdapter dad;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int rc;

        public void loadData(int rc)
        {
            dr = dt.Rows[rc];
            textBox1.Text = dr[0].ToString();
            textBox2.Text = dr[1].ToString();
            textBox3.Text = dr[2].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rc = dt.Rows.Count - 1;
            loadData(rc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("server=siddiq;database=sample1;Trusted_Connection=yes ");
            dad = new SqlDataAdapter("select * from employees", cn);
            ds = new DataSet();
            dad.Fill(ds,"emp123");
            dt = ds.Tables["emp123"];
            rc = 0;
            loadData(rc);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rc = rc + 1;
                loadData(rc);
            }
            catch (Exception  )
            {
                MessageBox.Show("no more records");
                rc = rc - 1;
                MessageBox.Show(rc.ToString());
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                rc = rc - 1;
                loadData(rc);
            }
            catch (Exception)
            {
                MessageBox.Show("No previous records");
                rc = rc + 1;
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rc = 0;
            loadData(rc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dr = dt.NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dt.Rows.Add(dr);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dr = dt.Rows[rc];
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dr = dt.Rows[rc];
            dr.Delete();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cmb = new SqlCommandBuilder(dad);
            dad.Update(ds, "emp123");
        }
    }
}
