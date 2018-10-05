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
    public partial class NoteSearch : Form
    {
        public NoteSearch()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if(txtsearch.Text.Trim()==string.Empty)
            {
                MessageBox.Show("please enter Note Title");
                return; //return because we don't want to run normal code of buton click
            }
            else
            {
                string query = "select * from tblNote where title like'" + txtsearch.Text + "%' or title like'" + txtsearch.Text + "%'";
                DBConnection db = new DBConnection();
                DataTable dt = db.GetData(query);
                this.dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (command.ToLower() == "delete")
            {
                if (MessageBox.Show("Are you sure to Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deletequery = "delete from tblNote where note_id=" + id; ;
                    DBConnection db = new DBConnection();
                    db.executyQuery(deletequery);
                    MessageBox.Show(" Note Successfully Deleted");
                    this.Close();
                    NoteSearch frmNoteSearch = new NoteSearch();
                    frmNoteSearch.Show();
                }
            }
        }

        private void imgback_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard frmDashBoard = new DashBoard();
            frmDashBoard.Show();
        }
    }
}
