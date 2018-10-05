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
    public partial class RegisterUserForm : Form
    {
        User OldUser;
        public RegisterUserForm(User user)
        {
            OldUser = user;
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.username = txtusername.Text;
                user.password = txtpassword.Text;
                user.email = txtemail.Text;
                user.mobile = txtmobile.Text;
                user.address = txtaddress.Text;
                string query;
                if (StickyNoteHelper.CheckDuplicateUser(user.username))
                {
                    MessageBox.Show("username already exists!!");
                }
                else if (!StickyNoteHelper.CheckPasswordLength(user.password)) 
                {
                    MessageBox.Show("password length must be Greater than 6 character");
                }
                else if(!StickyNoteHelper.CheckEmail(user.email))
                {
                    MessageBox.Show("Invalid email Address");
                }
                else if(!StickyNoteHelper.CompareTwoPassword(user.password,txtcpassword.Text))
                {
                    MessageBox.Show("Password Do not match");
                }
                else
                {
                    if(OldUser != null)
                    {
                         query = "update tblUser set username='" + user.username + "',password='" + user.password + "',email='" + user.email + "',mobile='" + user.mobile + "',address='" + user.address + "' where user_id="+ OldUser.user_id;
                    }
                    else
                    {
                         query = " insert into tblUser values('" + user.username + "','" + user.password + "','" + user.email + "','" + user.mobile + "','" + user.address + "')";
                    }
                    

                    DBConnection db = new DBConnection();
                    db.executyQuery(query);
                    MessageBox.Show("Register successfully");
                    txtusername.Text = string.Empty;
                    txtpassword.Text = string.Empty;
                    txtemail.Text = string.Empty;
                    txtmobile.Text = string.Empty;
                    txtaddress.Text = string.Empty;
                    txtcpassword.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtusername.Text = string.Empty;
            txtpassword.Text = string.Empty;
            txtcpassword.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtmobile.Text = string.Empty;
            txtaddress.Text = string.Empty;
        }

        private void RegisterUserForm_Load(object sender, EventArgs e)
        {
            if(OldUser != null)
            {
                txtusername.Text = OldUser.username;
                txtpassword.Text = OldUser.password;
                txtcpassword.Text = OldUser.password;
                txtemail.Text = OldUser.email;
                txtmobile.Text = OldUser.mobile;
                txtaddress.Text = OldUser.address;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm frmLogin = new LoginForm();
            frmLogin.Show();
        }
    }
}


