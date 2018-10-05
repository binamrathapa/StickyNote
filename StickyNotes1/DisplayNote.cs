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
    public partial class DisplayNote : Form
    {
        public DisplayNote()
        {
            InitializeComponent();
        }

        private void DisplayNote_Load(object sender, EventArgs e)
        {
            LoadDisplayNote();
        }
        private void LoadDisplayNote()
        {
            DBConnection db = new DBConnection();
            string command = "select * from tblNote";
            DataTable dt = db.GetData(command);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { /* {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string query = "select * from tblNote where note_id=" + id;
            DBConnection db = new DBConnection();
            db.GetData(query);
            DataTable dt = db.GetData(query);
            if (dt.Rows.Count > 0)
            {
                Note n = new Note();
                n.note_id = (int)dt.Rows[0]["note_id"];
                n.title = (string)dt.Rows[0]["title"];
                n.content = (string)dt.Rows[0]["content"];
                n.create_date = (DateTime)dt.Rows[0]["create_date"];
                n.stickied = (bool)dt.Rows[0]["stickied"];
                n.completed = (bool)dt.Rows[0]["completed"];
                AddNote note = new AddNote();
                note.Show();

            }*/
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
                        string deletequery = "delete from tblNote where note_id=" + id; ;
                        DBConnection db = new DBConnection();
                        db.executyQuery(deletequery);
                        MessageBox.Show("Note Successfully Deleted");
                        LoadDisplayNote();
                    }
                    else
                    {
                        LoadDisplayNote();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else if(command.ToLower()=="edit")
            {
                string query = "select * from tblNote where note_id=" + id; ;
                DBConnection db = new DBConnection();
                DataTable dt = db.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    Note n = new Note();
                    n.note_id = (int)dt.Rows[0]["note_id"];
                    n.title = (string)dt.Rows[0]["title"];
                    n.content = (string)dt.Rows[0]["content"];
                    n.create_date = (DateTime)dt.Rows[0]["create_date"];
                    n.stickied = (bool)dt.Rows[0]["stickied"];
                    n.completed = (bool)dt.Rows[0]["completed"];
                    this.Close();
                    AddNote note = new AddNote(n);
                    note.Show();
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