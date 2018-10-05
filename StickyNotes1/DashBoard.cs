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
    public partial class DashBoard : Form
    {
        public int user_id = 0;
        public DashBoard()
        {
            InitializeComponent();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            AddNote A = new AddNote(null);
            A.user_id = this.user_id;
            A.Show();

        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            AddCategory Ac = new AddCategory(null);
            Ac.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RegisterUserForm register = new RegisterUserForm(null);
            register.Show();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            int id = user_id;
            LoadStickiedNotes();
        }
        private void LoadStickiedNotes()
        {
            string query = "SELECT N.*,NPC.category_id,NPU.user_id FROM tblNote N INNER JOIN tblNotesPerCategory NPC ON(n.note_id = npc.note_id)" +
                " JOIN tblNotesPerUser NPU ON(n.note_id = npu.note_id) WHERE npu.user_id = " + user_id + " and N.Stickied=1 Order by N.Create_Date desc";
            DBConnection db = new DBConnection();
            DataTable dt = db.GetData(query);
        
            decimal totalNotes = dt.Rows.Count;
            decimal rows = Math.Ceiling(totalNotes / 4);
            int c = 0;
            int r = 0;
            int countIndex = 1;
            foreach (DataRow dr in dt.Rows)
            {
                int dHeight = 263 * r;

                if (countIndex > totalNotes)
                    return;
                int dWidth = 290 * c;


                Panel pnlNotes = new Panel();
                pnlNotes.Name = "pnlNotes_" + r;
                pnlNotes.BorderStyle = BorderStyle.FixedSingle;
                pnlNotes.Width = 290;
                pnlNotes.Height = 263;
                pnlNotes.AutoScroll = true;
                //pnlNotes.BackColor=new Color().get
                pnlNotes.Location = new Point(5 + dWidth, 5 + dHeight);
                this.panel.Controls.Add(pnlNotes);

                Label lblCategory = new Label();
                lblCategory.Text = "Category";
                lblCategory.Name = "lblCategory_" + Convert.ToString(dr["category_id"]);
                lblCategory.Width = 70;
                lblCategory.Location = new Point(5, 5);
                pnlNotes.Controls.Add(lblCategory);

                ComboBox cbCategory = new ComboBox();
                cbCategory.Name = "cbCategory_" + Convert.ToString(dr["category_id"]);
                cbCategory.DisplayMember = "Name";
                cbCategory.ValueMember = "Id";
                //List<Category> categories = new List<Category>();
                Category category;
                int selectIndex = -1;
                int count = 0;
                foreach (DataRow drc in GetCategory().Rows)
                {
                    if (Convert.ToString(dr["Category_id"]) == Convert.ToString(drc["category_id"]))
                    {
                        selectIndex = count;
                    }
                    category = new Category();
                    category.category_id = (int)drc["category_id"];
                    category.category_name = (string)drc["category_name"];
                    //categories.Add(category);
                    cbCategory.Items.Add(category);
                    count++;
                }
                //cbCategory.DataSource = categories;
                //cbCategory.DataSource = GetCategory();
                cbCategory.Location = new Point(80, 5);
                cbCategory.SelectedIndex = selectIndex;
                pnlNotes.Controls.Add(cbCategory);

                Label lblTitle = new Label();
                lblTitle.Text = "Title";
                lblTitle.Name = "lblTitle_" + Convert.ToString(dr["note_id"]);
                lblTitle.Width = 70;
                lblTitle.Location = new Point(5, 35);
                pnlNotes.Controls.Add(lblTitle);

                TextBox txtTitle = new TextBox();
                txtTitle.Name = "txtTitle_" + Convert.ToString(dr["note_id"]);
                txtTitle.Text = (string)dr["title"];
                txtTitle.Height = 20;
                txtTitle.Width = 200;
                txtTitle.Location = new Point(80, 35);
                pnlNotes.Controls.Add(txtTitle);

                Label lblContent = new Label();
                lblContent.Text = "Content";
                lblContent.Name = "lblContent_" + Convert.ToString(dr["note_id"]);
                lblContent.Width = 70;
                lblContent.Location = new Point(5, 70);
                pnlNotes.Controls.Add(lblContent);

                RichTextBox rtbContent = new RichTextBox();
                rtbContent.Name = "rtbContent_" + Convert.ToString(dr["note_id"]);
                rtbContent.Location = new Point(80, 70);
                rtbContent.Text = (string)dr["content"];
                rtbContent.Width = 200;
                rtbContent.Height = 100;
                pnlNotes.Controls.Add(rtbContent);

                CheckBox cbStickied = new CheckBox();
                cbStickied.Name = "cbStickied_" + Convert.ToString(dr["note_id"]);
                cbStickied.Location = new Point(80, 180);
                cbStickied.Checked = Convert.ToBoolean(dr["Stickied"]);
                cbStickied.Height = 20;
                cbStickied.Text = "is Stickied ?";
                cbStickied.Checked = true;
                cbStickied.CheckedChanged += new System.EventHandler(this.cbStickied_Changed); ;
                pnlNotes.Controls.Add(cbStickied);

                CheckBox cbCompleted = new CheckBox();
                cbCompleted.Name = "cbCompleted_" + Convert.ToString(dr["note_id"]);
                cbCompleted.Location = new Point(80, 210);
                cbCompleted.Checked = Convert.ToBoolean(dr["completed"]);
                cbCompleted.Height = 20;
                cbCompleted.Text = "is Completed ?";
                cbCompleted.CheckedChanged += new System.EventHandler(this.cbCompleted_Changed);
                pnlNotes.Controls.Add(cbCompleted);


                c++;
                if (countIndex % 4 == 0)
                {
                    c = 0;
                    r++;
                }
                countIndex++;

            }


        }

        protected void cbStickied_Changed(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = (CheckBox)sender;
                string name = chk.Name;
                string query;
                string id = name.Substring(name.LastIndexOf("_") + 1);
                if (MessageBox.Show("Are you sure to Update:", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "Update tblNote set Stickied=" + Convert.ToInt16(chk.Checked) + " Where note_id=" + id;
                    DBConnection db = new DBConnection();
                    db.executyQuery(query);
                    MessageBox.Show("Updated successfully");
                }
                else
                {
                    DashBoard frmDashBoard = new DashBoard();
                    frmDashBoard.Show();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void cbCompleted_Changed(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = (CheckBox)sender;
                string name = chk.Name;
                string query;
                string id = name.Substring(name.LastIndexOf("_") + 1);
                if (MessageBox.Show("Are you sure to Update:", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "Update tblNote set Completed=" + Convert.ToInt16(chk.Checked) + " Where note_id=" + id;
                    DBConnection db = new DBConnection();
                    db.executyQuery(query);
                    MessageBox.Show("Updated successfully");
                }
                else
                {
                    DashBoard frmDashBoard = new DashBoard();
                    frmDashBoard.Show();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private DataTable GetCategory()
        {
            string query = "select * from tblCategory";
            DBConnection db = new DBConnection();
            return db.GetData(query);
        }





        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            DisplayNote note = new DisplayNote();
            note.Show();
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            DisplayCategory category = new DisplayCategory();
            category.Show();
        }

        private void stickiedChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            NoteStatus frmNoteStatus = new NoteStatus();
            frmNoteStatus.user_id = this.user_id;
            frmNoteStatus.Show();
        }
        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm frmlogin = new LoginForm();
            frmlogin.Show();
        }

        private void searchNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            NoteSearch frmNoteSearch = new NoteSearch();
            frmNoteSearch.Show();
        }

        private void listToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            DisplayUser frmUser = new DisplayUser();
            frmUser.Show();
        }
    }
}

