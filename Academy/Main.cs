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
        public Main()
        {
            InitializeComponent();
            Connector connector = new Connector
                (
                    ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString
                );
            dgvStudents.DataSource = connector.Select("*", "Students");
            int rowcountStudent = dgvStudents.RowCount - 1;
            toolStripStatusLabel1.Text = rowcountStudent.ToString();
            //////Console.WriteLine($"Колличество студентов " + rowcountStudent);

            //dgvDirections.DataSource = connector.Select("*", "Directions");
            //int rowCount  = dgvDirections.RowCount-1;
            //toolStripStatusLabel2.Text = rowCount.ToString();
            //Console.WriteLine(rowCount);
            //toolStripStatusLabel2.Text = rowCount.ToString();
            //dataGridTeachers.DataSource = connector.Select("*", "Teachers");
            //dataGridViewGroups.DataSource = connector.Select("*", "Groups");

            //dgvDirections.DataSource = connector.Select("*", "Directions");
            //dataGridView1.DataSource = connector.Select("*", "Disciplines");

        }

      
    }
}
