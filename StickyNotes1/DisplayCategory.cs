using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNotes1
{
    public partial class DisplayCategory : Form
    {
        public DisplayCategory()
        {
            InitializeComponent();
        }

        private void DisplayCategory_Load(object sender, EventArgs e)
        {
            LoadDisplayCategory();
        }
        private void LoadDisplayCategory()
        {
            DBConnection db = new DBConnection();
            string command = "Select * from tblCategory";
            DataTable dt = db.GetData(command);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string query = "Select * from tblCategory where category_id=" + id;
            DBConnection db = new DBConnection();
            db.GetData(query);
            DataTable dt = db.GetData(query);
            if (dt.Rows.Count > 0)
            {
                Category c = new Category();
                c.category_id = (int)dt.Rows[0]["category_id"];
                c.category_name = (string)dt.Rows[0]["category_name"];
                AddCategory category = new AddCategory(c);
                category.Show();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (command.ToLower() == "delete")
            {
                try
                {
                    if (MessageBox.Show("Are you sure to Delete", "message", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string deletequery = "delete from tblCategory where category_id=" + id; ;
                        DBConnection db = new DBConnection();
                        db.executyQuery(deletequery);
                        MessageBox.Show("Category Successfully Deleted");
                        LoadDisplayCategory();
                    }
                    else
                    {
                        LoadDisplayCategory();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if(command.ToLower()=="edit")
            {
                string query = "select * from tblCategory where category_id=" + id; ;
                DBConnection db = new DBConnection();
                DataTable dt = db.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    Category c = new Category();
                    c.category_id = (int)dt.Rows[0]["category_id"];
                    c.category_name = (string)dt.Rows[0]["category_name"];
                    this.Close();
                    AddCategory frmcategory = new AddCategory(c);
                    frmcategory.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard frmDashBoard = new DashBoard();
            frmDashBoard.Show();
        }
    }
}