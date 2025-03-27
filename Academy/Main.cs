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
        public Main()
        {
            InitializeComponent();

            dgvStudents.DataSource = connector.Select("*", "Students");
            int rowcountStudent = dgvStudents.RowCount - 1;
            toolStripStatusLabel1.Text = "Count Students " + rowcountStudent.ToString();

        }
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            Console.WriteLine(tabControl.SelectedIndex);
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    dgvStudents.DataSource = connector.Select("*", "Students");
                    int rowcountStudent = dgvStudents.RowCount - 1;
                    toolStripStatusLabel1.Text = "Count Students " + rowcountStudent.ToString();
                    break;
                case 1:
                    dataGridViewGroups.DataSource = connector.Select("*", "Groups");
                    int rowcountGroups = dataGridViewGroups.RowCount - 1;
                    toolStripStatusLabel1.Text = "Count Groups " + rowcountGroups.ToString();
                    break;
                case 2:
                    dgvDirections.DataSource = connector.Select("*", "Directions");
                    int rowCount  = dgvDirections.RowCount-1;
                    toolStripStatusLabel1.Text = "Count Directions " +rowCount.ToString();
                    break;
                case 3:
                    dgvDiscepline.DataSource = connector.Select("*", "Disciplines");
                    int rowDisciplines  = dgvDiscepline.RowCount-1;
                    toolStripStatusLabel1.Text = "Count Disciplines " + rowDisciplines.ToString();
                    break;
                case 4:
                    dgvTeachers.DataSource = connector.Select("*", "Teachers");
                    int countTeachers = dgvTeachers.RowCount - 1;
                    toolStripStatusLabel1.Text = "Count Teachers " + countTeachers.ToString();
                    break;

            }
        }

    }
}
