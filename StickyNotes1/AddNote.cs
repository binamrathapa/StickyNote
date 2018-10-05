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
    public partial class AddNote : Form
    {
        Note oldNote;
        public int user_id = 0;
        public AddNote(Note note1)
        {
            oldNote = note1;
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Note n = new Note();
                n.title = txttitle.Text;
                n.content = richTextBox1.Text;
                n.create_date = DateTime.Now;
                n.stickied = checkBox1.Checked;
                n.completed = checkBox2.Checked;
                string query1;
                if (oldNote != null)
                {
                    query1 = "update tblNote set title='" + txttitle.Text + "',content='" + richTextBox1.Text + "',stickied='" + checkBox1.Checked + "',completed='" + checkBox2.Checked + "' where note_id=" + oldNote.note_id;
                }
                else
                {
                    query1 = "insert into tblNote values('" + n.title + "','" + n.content + "','" + n.create_date + "','" + n.stickied + "','" + n.completed + "')";
                }
                DBConnection db = new DBConnection();
                db.executyQuery(query1);


                string query = "select max(note_id) As note_id from tblNote";
                DataTable dt = db.GetData(query);
                int note_id = (int)dt.Rows[0]["note_id"];

                string insertNotePerUserQuery = "insert into tblNotesPerUser values(" + user_id + "," + note_id + ")";
                db.executyQuery(insertNotePerUserQuery);

                int category_id = Convert.ToInt32(cbocategory.SelectedValue);

                string insertNotePerCategoryQuery = "insert into tblNotesPerCategory values(" + category_id + "," + note_id + ")";
                db.executyQuery(insertNotePerCategoryQuery);

                MessageBox.Show("Note Successfully Added");

                txttitle.Text = string.Empty;
                richTextBox1.Text = string.Empty;
                checkBox1.Text = string.Empty;
                checkBox2.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadCategory()
        {
            string query = "select * from tblCategory";
            DBConnection db = new DBConnection();
            DataTable dt = db.GetData(query);
            cbocategory.DisplayMember = "category_name";
            cbocategory.ValueMember = "category_id";
            cbocategory.DataSource = dt;
        }

        private void AddNote_Load(object sender, EventArgs e)
        {
            if (oldNote != null)
            {
                txttitle.Text = oldNote.title;
                richTextBox1.Text = oldNote.content;
                checkBox1.Checked = oldNote.stickied;
                checkBox2.Checked = oldNote.completed;

            }
            LoadCategory();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NoteStatus frmstatus = new NoteStatus();
            frmstatus.Show();
        }

        private void imgback_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard frmDashBoard = new DashBoard();
            frmDashBoard.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void imglogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
