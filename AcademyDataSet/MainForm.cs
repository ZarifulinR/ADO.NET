using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace AcademyDataSet
{
    public partial class MainForm : Form
    {
        Cache GroupsRelatedData;
        public MainForm()
        {
            InitializeComponent();
            AllocConsole();
            GroupsRelatedData = new Cache();
            GroupsRelatedData.AddTable("Directions", "direction_id,direction_name");
            GroupsRelatedData.AddTable("Groups", "group_id,group_name,direction");
            GroupsRelatedData.AddRelation("GroupsDirections", "Groups,direction", "Directions,direction_id");
            GroupsRelatedData.Load();

            cbDirections.DataSource = GroupsRelatedData.Set.Tables["Directions"];
            cbDirections.ValueMember = "direction_id";
            cbDirections.DisplayMember = "direction_name";
            cbGroups.DataSource = GroupsRelatedData.Set.Tables["Groups"];
            cbGroups.DisplayMember = "group_name";
            cbGroups.ValueMember = "group_id";
        }
        private void cbDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(GroupsRelatedData.Set.Tables["Directions"].ChildRelations);
           // DataRow row = GroupsRelatedData.Tables["Directions"].Rows.Find(cbDirections.SelectedValue);
            GroupsRelatedData.Set.Tables["Groups"].DefaultView.RowFilter = $"direction={cbDirections.SelectedValue}";
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

    }
}
