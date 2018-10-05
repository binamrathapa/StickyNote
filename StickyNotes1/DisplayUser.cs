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
    public partial class DisplayUser : Form
    {
        public DisplayUser()
        {
            InitializeComponent();
        }

        private void DisplayUser_Load(object sender, EventArgs e)
        {
            LoadDisplayUser();
        }
        private void LoadDisplayUser()
        {
            DBConnection db = new DBConnection();
            string command = "select * from tblUser";
            DataTable dt = db.GetData(command);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (command.ToLower() == "delete")
            {
                try
                {
                    if (MessageBox.Show("Are you sure to Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string deletequery = "delete from [tblUser] where user_id=" + id;
                        DBConnection db = new DBConnection();
                        db.executyQuery(deletequery);
                        MessageBox.Show("successfully Deleted");
                        LoadDisplayUser();
                    }
                    else
                    {
                        LoadDisplayUser();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (command.ToLower() == "edit")
            {
                string query = "select * from [tblUser] where user_id=" + id; ;
                DBConnection db = new DBConnection();
                DataTable dt = db.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    User user = new User();
                    user.user_id = (int)dt.Rows[0]["user_id"];
                    user.username = (string)dt.Rows[0]["username"];
                    user.password = (string)dt.Rows[0]["password"];
                    user.email = (string)dt.Rows[0]["email"];
                    user.mobile = (string)dt.Rows[0]["mobile"];
                    user.address = (string)dt.Rows[0]["address"];
                    RegisterUserForm frmregister = new RegisterUserForm(user);
                    frmregister.Show();
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

