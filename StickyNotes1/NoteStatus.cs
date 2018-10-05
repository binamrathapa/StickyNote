using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StickyNotes1
{
    public partial class NoteStatus : Form
    {
        public int user_id = 0;
        public NoteStatus()
        {
            InitializeComponent();
        }

        private void NoteStatus_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            string query = "select count(*)As Total from tblNote N,tblNotesPerUser NPU where(N.note_id=NPU.note_id)and NPU.user_id='" + user_id + "'and N.completed=1";
            DBConnection db = new DBConnection();
            DataTable dt = db.GetData(query);
            int completed = Convert.ToInt32(dt.Rows[0]["Total"]);
                     
            chart1.Series.Clear();
            string query1 = "select count(*)As Total from tblNote N,tblNotesPerUser NPU where(N.note_id=NPU.note_id)and NPU.user_id='" + user_id + "'and N.completed=0";
            DBConnection db1 = new DBConnection();
            DataTable dt1 = db1.GetData(query1);
            int Incompleted = Convert.ToInt32(dt.Rows[0]["Total"]);

            int[] arrayValue =new int[2] {completed,Incompleted};
            string[] arrayStatus = new string[2] {"completed","uncompleted"};
            chart1.Titles.Add("Sticky Notes Status");
            Series series = new Series //constroctor
            {
               Name="series1",
               ChartType=SeriesChartType.Pie
            };
            chart1.Series.Add(series);
            for(int i=0;i<arrayValue.Length;i++)
            {
                series.Points.Add(arrayValue[i]);
                DataPoint dp = series.Points[i];
                dp.AxisLabel = Convert.ToString(arrayValue[i]);
                dp.LegendText = arrayStatus[i];
                if (arrayStatus[i] == "completed")
                    dp.Color = Color.Green;
                else
                    dp.Color = Color.Brown;


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
