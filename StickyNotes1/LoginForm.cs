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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from tblUser where username='" + txtusername.Text + "'and password='" + txtpassword.Text + "'";
                DBConnection db = new DBConnection();
                DataTable dt = db.GetData(query);
                if(dt.Rows.Count>0)
                {
                    DashBoard frmDashBoard = new DashBoard();
                    frmDashBoard.user_id = Convert.ToInt32(dt.Rows[0]["user_id"]);
                    frmDashBoard.Show();
                }
                else
                {
                    MessageBox.Show("username and password not Exists");
                }
                txtpassword.Text = string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterUserForm frmRegister = new RegisterUserForm(null);
            frmRegister.Show();
        }
    }
}
