﻿
namespace Academy
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagesStudent = new System.Windows.Forms.TabPage();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.tabPageGroups = new System.Windows.Forms.TabPage();
            this.cbGroupsDirection = new System.Windows.Forms.ComboBox();
            this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.tabPageDirections = new System.Windows.Forms.TabPage();
            this.dgvDirections = new System.Windows.Forms.DataGridView();
            this.tabPageDiscipline = new System.Windows.Forms.TabPage();
            this.dgvDiscepline = new System.Windows.Forms.DataGridView();
            this.tabPageTeachers = new System.Windows.Forms.TabPage();
            this.dgvTeachers = new System.Windows.Forms.DataGridView();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagesStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.tabPageGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
            this.tabPageDirections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
            this.tabPageDiscipline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscepline)).BeginInit();
            this.tabPageTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 424);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 26);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "Status";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(51, 20);
            this.toolStripStatusLabel1.Text = "Count:";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPagesStudent);
            this.tabControl.Controls.Add(this.tabPageGroups);
            this.tabControl.Controls.Add(this.tabPageDirections);
            this.tabControl.Controls.Add(this.tabPageDiscipline);
            this.tabControl.Controls.Add(this.tabPageTeachers);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 428);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPagesStudent
            // 
            this.tabPagesStudent.Controls.Add(this.comboBox3);
            this.tabPagesStudent.Controls.Add(this.comboBox1);
            this.tabPagesStudent.Controls.Add(this.dgvStudents);
            this.tabPagesStudent.Location = new System.Drawing.Point(4, 25);
            this.tabPagesStudent.Name = "tabPagesStudent";
            this.tabPagesStudent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagesStudent.Size = new System.Drawing.Size(792, 399);
            this.tabPagesStudent.TabIndex = 0;
            this.tabPagesStudent.Text = "Student";
            this.tabPagesStudent.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(174, 1);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(167, 24);
            this.comboBox3.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // dgvStudents
            // 
            this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(0, 26);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.Size = new System.Drawing.Size(792, 373);
            this.dgvStudents.TabIndex = 0;
            // 
            // tabPageGroups
            // 
            this.tabPageGroups.Controls.Add(this.cbGroupsDirection);
            this.tabPageGroups.Controls.Add(this.dataGridViewGroups);
            this.tabPageGroups.Location = new System.Drawing.Point(4, 25);
            this.tabPageGroups.Name = "tabPageGroups";
            this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroups.Size = new System.Drawing.Size(792, 399);
            this.tabPageGroups.TabIndex = 1;
            this.tabPageGroups.Text = "Groups";
            this.tabPageGroups.UseVisualStyleBackColor = true;
            // 
            // cbGroupsDirection
            // 
            this.cbGroupsDirection.FormattingEnabled = true;
            this.cbGroupsDirection.Location = new System.Drawing.Point(0, 2);
            this.cbGroupsDirection.Name = "cbGroupsDirection";
            this.cbGroupsDirection.Size = new System.Drawing.Size(371, 24);
            this.cbGroupsDirection.TabIndex = 1;
            this.cbGroupsDirection.SelectedIndexChanged += new System.EventHandler(this.cbGroupsDirection_SelectedIndexChanged);
            // 
            // dataGridViewGroups
            // 
            this.dataGridViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroups.Location = new System.Drawing.Point(0, 29);
            this.dataGridViewGroups.Name = "dataGridViewGroups";
            this.dataGridViewGroups.RowHeadersWidth = 51;
            this.dataGridViewGroups.RowTemplate.Height = 24;
            this.dataGridViewGroups.Size = new System.Drawing.Size(792, 370);
            this.dataGridViewGroups.TabIndex = 0;
            // 
            // tabPageDirections
            // 
            this.tabPageDirections.Controls.Add(this.dgvDirections);
            this.tabPageDirections.Location = new System.Drawing.Point(4, 25);
            this.tabPageDirections.Name = "tabPageDirections";
            this.tabPageDirections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDirections.Size = new System.Drawing.Size(792, 399);
            this.tabPageDirections.TabIndex = 2;
            this.tabPageDirections.Text = "Directions";
            this.tabPageDirections.UseVisualStyleBackColor = true;
            // 
            // dgvDirections
            // 
            this.dgvDirections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirections.Location = new System.Drawing.Point(0, 22);
            this.dgvDirections.Name = "dgvDirections";
            this.dgvDirections.RowHeadersWidth = 51;
            this.dgvDirections.RowTemplate.Height = 24;
            this.dgvDirections.Size = new System.Drawing.Size(792, 377);
            this.dgvDirections.TabIndex = 0;
            // 
            // tabPageDiscipline
            // 
            this.tabPageDiscipline.Controls.Add(this.dgvDiscepline);
            this.tabPageDiscipline.Location = new System.Drawing.Point(4, 25);
            this.tabPageDiscipline.Name = "tabPageDiscipline";
            this.tabPageDiscipline.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiscipline.Size = new System.Drawing.Size(792, 399);
            this.tabPageDiscipline.TabIndex = 3;
            this.tabPageDiscipline.Text = "Discipline";
            this.tabPageDiscipline.UseVisualStyleBackColor = true;
            // 
            // dgvDiscepline
            // 
            this.dgvDiscepline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscepline.Location = new System.Drawing.Point(0, 23);
            this.dgvDiscepline.Name = "dgvDiscepline";
            this.dgvDiscepline.RowHeadersWidth = 51;
            this.dgvDiscepline.RowTemplate.Height = 24;
            this.dgvDiscepline.Size = new System.Drawing.Size(792, 376);
            this.dgvDiscepline.TabIndex = 0;
            // 
            // tabPageTeachers
            // 
            this.tabPageTeachers.Controls.Add(this.dgvTeachers);
            this.tabPageTeachers.Location = new System.Drawing.Point(4, 25);
            this.tabPageTeachers.Name = "tabPageTeachers";
            this.tabPageTeachers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTeachers.Size = new System.Drawing.Size(792, 399);
            this.tabPageTeachers.TabIndex = 4;
            this.tabPageTeachers.Text = "Teachers";
            this.tabPageTeachers.UseVisualStyleBackColor = true;
            // 
            // dgvTeachers
            // 
            this.dgvTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeachers.Location = new System.Drawing.Point(0, 24);
            this.dgvTeachers.Name = "dgvTeachers";
            this.dgvTeachers.RowHeadersWidth = 51;
            this.dgvTeachers.RowTemplate.Height = 24;
            this.dgvTeachers.Size = new System.Drawing.Size(789, 369);
            this.dgvTeachers.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Academy";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPagesStudent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.tabPageGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
            this.tabPageDirections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).EndInit();
            this.tabPageDiscipline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscepline)).EndInit();
            this.tabPageTeachers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagesStudent;
        private System.Windows.Forms.TabPage tabPageDirections;
        private System.Windows.Forms.TabPage tabPageDiscipline;
        private System.Windows.Forms.TabPage tabPageTeachers;
        private System.Windows.Forms.DataGridView dgvTeachers;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.DataGridView dataGridViewGroups;
        private System.Windows.Forms.DataGridView dgvDirections;
        private System.Windows.Forms.DataGridView dgvDiscepline;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPageGroups;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cbGroupsDirection;
    }
}

