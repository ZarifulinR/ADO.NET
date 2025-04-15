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
	public partial class MainForm : Form
	{

		Connector connector = new Connector
			(
				ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString
			);

		public Dictionary<string, int> d_directions;
		public Dictionary<string, int> d_groups;
		DataGridView[] tables;

		Query[] queries = new Query[]
		{
			new Query("last_name,first_name,middle_name,birth_date,group_name,direction_name",
				"Students JOIN Groups ON([group]=group_id) JOIN Directions ON (direction =direction_id)"),
                //"[group]=group_id AND direction=direction_id"),
            new Query
			("group_name, dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
					"Groups JOIN Directions ON (direction=direction_id)"//,
                    //"direction=direction_id"
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

		public MainForm()
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
			dgvStudents.DataSource = connector.Select(queries[0].Colums, queries[0].Tables, queries[0].Condition);

			d_directions = connector.GetDictionary("*", "Directions");
			d_groups = connector.GetDictionary("group_id,group_name", "Groups");
			//int i = tabControl.SelectedIndex;
			//Query query = queries[i];
			//toolStripStatusLabel1.Text = status_messages[i] + CountRecordsInDGV(tables[i]);
			cbStudentsGroup.Items.AddRange(d_groups.Select(g => g.Key).ToArray());
			cbGroupsDirection.Items.AddRange(d_directions.Select(d => d.Key).ToArray());
			cbStudentsDirection.Items.AddRange(d_directions.Select(d => d.Key).ToArray());
			cbStudentsGroup.Items.Insert(0, "Все группы");
			cbStudentsDirection.Items.Insert(0, "Все направления");
			cbGroupsDirection.Items.Insert(0, "Все направления");
			cbStudentsGroup.SelectedIndex = 0;
			cbStudentsDirection.SelectedIndex = 0;
			cbGroupsDirection.SelectedIndex = 0;
			loadPage(0);
		}
		void loadPage(int i, Query query = null)
		{
			if (query == null) query = queries[i];
			//Query query = queries[i];
			tables[i].DataSource =
			 connector.Select(query.Colums, query.Tables, query.Condition, query.Group_by);
			toolStripStatusLabel1.Text = status_messages[i] + CountRecordsInDGV(tables[i]);
		}
		private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			//nt i = tabControl.SelectedIndex;
			//string tab_name = tabControl.SelectedTab.Name;
			//Console.WriteLine(tab_name);
			loadPage(tabControl.SelectedIndex);
			// Console.WriteLine(tabControl.SelectedIndex);

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


		int CountRecordsInDGV(DataGridView dgv)
		{
			return dgv.RowCount == 0 ? 0 : dgv.RowCount - 1;
		}

		private void cbDisciplines_CheckedChanged(object sender, EventArgs e)
		{

			string condition = cbDisciplines.Checked ? "" : "HAVING COUNT(stud_id) > 0";

			dgvDirections.DataSource = connector.Select(
				"direction_name AS N'Направление', COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
				"Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
				"",
				"direction_name " + condition
			);

			toolStripStatusLabel1.Text = $"Количество направлений: {CountRecordsInDGV(dgvDirections)}";
		}

		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string cb_name = (sender as ComboBox).Name;
			string tab_name = tabControl.SelectedTab.Name;

			int last_capital_index = Array.FindLastIndex<char>(cb_name.ToCharArray(), Char.IsUpper);
			string cb_suffix = cb_name.
				Substring(last_capital_index, cb_name.Length - last_capital_index);
			Console.WriteLine(cb_name);
			Console.WriteLine(tab_name);
			Console.WriteLine(cb_suffix);
			int i = (sender as ComboBox).SelectedIndex;
			string dictionary_name = $"d_{cb_suffix.ToLower()}s";
			Dictionary<string, int> dictionary =
				this.GetType().GetField(dictionary_name).GetValue(this) as Dictionary<string, int>;
			Dictionary<string, int> d_groups = connector.GetDictionary
				("group_id,group_name",
				"Groups",
				i == 0 ? "" : $"{cb_suffix.ToLower()}={dictionary[(sender as ComboBox).SelectedItem.ToString()]}");
			cbStudentsGroup.Items.Clear();
			cbStudentsGroup.Items.AddRange(d_groups.Select(g => g.Key).ToArray());
			Query query = new Query(queries[tabControl.SelectedIndex]);
			string condition =
				(i == 0 || (sender as ComboBox).SelectedItem == null ? "" : $"{cb_suffix.ToLower()} = {dictionary[$"{(sender as ComboBox).SelectedItem}"]}");
			if (condition != "") query.Condition = condition;
			else if (query.Condition != "") query.Condition += $" AND {condition}";
			loadPage(tabControl.SelectedIndex, query);
		}


	}
}


