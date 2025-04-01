using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Configuration;

namespace Academy
{
    public partial class Main : Form
    {

        Connector connector = new Connector
            (
                ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString
            );

        Dictionary<string, int> d_directions;
        DataGridView[] tables;
        Query[] queries = new Query[]
        {
            new Query("last_name,first_name,middle_name,birth_date,group_name,direction_name",
                "Students,Groups,Directions",
                "[group]=group_id AND direction=direction_id"),
            new Query
            ("group_name, dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
                    "Groups, Directions",
                    "direction=direction_id"
                ),
            new Query
            ( "direction_name AS N'Направление', COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
                        "Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
                        "",
                        "direction_name"

                ),
            new Query("*","Disciplines"),
            new Query("*","Teachers")
        };
        string[] status_messages = new string[]
        {
            $"Количество студентов: ",
            $"Количество групп: ",
            $"Количество направлений: ",
            $"Количество дисциплин: ",
            $"Количество преподавателей: "
        };

        public Main()
        {
            InitializeComponent();
            tables = new DataGridView[]
            {
                 dgvStudents,
                 dataGridViewGroups,
                 dgvDirections,
                 dgvDiscepline,
                 dgvTeachers
            };

            //dgvStudents.DataSource = connector.Select("*", "Students");
            //int rowcountStudent = dgvStudents.RowCount - 1;
            //toolStripStatusLabel1.Text = "Count Students " + rowcountStudent.ToString();
            //List<string> directions = connector.Directions();
            //cbGroupsDirection.Items.Clear();
            //cbGroupsDirection.Items.Add("All");
            //foreach (string direction in directions)
            //{
            //    cbGroupsDirection.SelectedIndex = 0;
            //    cbGroupsDirection.Items.Add(direction);
            //    Console.WriteLine(direction);
            //}
            d_directions = connector.GetDictionary("*", "Directions");
            cbGroupsDirection.Items.AddRange(d_directions.Select(k => k.Key).ToArray());

        }
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = tabControl.SelectedIndex;
            Query query = queries[i];
            tables[i].DataSource = 
                connector.Select(query.Colums, query.Tables, query.Condition, query.Group_by);
            toolStripStatusLabel1.Text = status_messages[i] + CountRecordsInDGV(tables[i]);
            Console.WriteLine(tabControl.SelectedIndex);
            //switch (tabControl.SelectedIndex)
            //{
            //    case 0:
            //        dgvStudents.DataSource = connector.Select("*", "Students");
            //        toolStripStatusLabel1.Text = $"Count Students :{CountRecordsInDGV(dgvStudents)}";
            //        break;
            //    case 1:
            //        dataGridViewGroups.DataSource = connector.Select("*", "Groups");
            //        toolStripStatusLabel1.Text = $"Count Groups :{CountRecordsInDGV(dataGridViewGroups)}";
            //        break;
            //    case 2:
            //        //dgvDirections.DataSource = connector.Select(
            //        //    "direction_name AS N'Направление', COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
            //        //    "Students, Groups, Directions",
            //        //    "[group]= group_id AND direction=direction_id",
            //        //    "direction_name"
            //        //    );
            //        dgvDirections.DataSource = connector.Select(
            //            "direction_name AS N'Направление', COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
            //            "Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
            //            "",
            //            "direction_name"
            //            );
            //        //int rowCount = dgvDirections.Rows.Count-1;
            //        toolStripStatusLabel1.Text = $"Count Directions :{CountRecordsInDGV(dgvDirections)}";
            //        break;
            //    case 3:
            //        dgvDiscepline.DataSource = connector.Select("*", "Disciplines");
            //        //int rowDisciplines = dgvDiscepline.Rows.Count-1;
            //        toolStripStatusLabel1.Text = $"Count Disciplines :{CountRecordsInDGV(dgvDiscepline)}";
            //        break;
            //    case 4:
            //        dgvTeachers.DataSource = connector.Select("*", "Teachers");
            //        //int countTeachers = dgvTeachers.Rows.Count-1 ;
            //        toolStripStatusLabel1.Text = $"Count Teachers : {CountRecordsInDGV(dgvTeachers)}";
            //        break;

            //}
        }

        private void cbGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewGroups.DataSource = connector.Select
                (
                    "group_name, dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
                    "Groups, Directions",
                    $"direction=direction_id AND direction = N'{d_directions[cbGroupsDirection.SelectedItem.ToString()]}'"
                );
            //int rowcountGroups = dataGridViewGroups.Rows.Count-1;
            toolStripStatusLabel1.Text = $"Count Groups :{CountRecordsInDGV(dataGridViewGroups)}";
        }
        int CountRecordsInDGV(DataGridView dgv)
        {
            return dgv.RowCount == 0 ? 0 : dgv.RowCount - 1;
        }
    }
}


