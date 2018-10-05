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
    public partial class AddCategory : Form
    {
        Category oldCategory;
        public AddCategory(Category category1)
        {
            oldCategory = category1;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.category_name = txtcategoryname.Text;
            string query;
            if(oldCategory!=null)
            {
                query = "update tblCategory set category_name='" + txtcategoryname.Text + "' where category_id=" + oldCategory.category_id;
            }
            else
            {
                query = "insert into tblCategory values('" + c.category_name + "')";
            }
            

            DBConnection db = new DBConnection();
            db.executyQuery(query);
            MessageBox.Show("category successfully Add");

        }

        private void imgback_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard frmDashBoard = new DashBoard();
            frmDashBoard.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            if(oldCategory!=null)
            {
                txtcategoryname.Text = oldCategory.category_name;
            }
        }
    }
}
