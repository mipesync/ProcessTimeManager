namespace ProcessTimeManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.processList = new System.Windows.Forms.DataGridView();
            this.process_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.process_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.processName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabAllProcesses = new System.Windows.Forms.TabPage();
            this.tabSelectedProcesses = new System.Windows.Forms.TabPage();
            this.selectedProcesses = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.processList)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabAllProcesses.SuspendLayout();
            this.tabSelectedProcesses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // processList
            // 
            this.processList.AllowUserToAddRows = false;
            this.processList.AllowUserToDeleteRows = false;
            this.processList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.processList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.processList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.processList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.processList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.processList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.process_Select,
            this.process_Id,
            this.processIcon,
            this.processName,
            this.processTime});
            this.processList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.processList.Location = new System.Drawing.Point(3, 3);
            this.processList.Name = "processList";
            this.processList.ReadOnly = true;
            this.processList.RowHeadersVisible = false;
            this.processList.RowTemplate.Height = 30;
            this.processList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.processList.Size = new System.Drawing.Size(786, 416);
            this.processList.TabIndex = 0;
            this.processList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.processList_CellClick);
            // 
            // process_Select
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = false;
            this.process_Select.DefaultCellStyle = dataGridViewCellStyle2;
            this.process_Select.FalseValue = "false";
            this.process_Select.HeaderText = "Select";
            this.process_Select.Name = "process_Select";
            this.process_Select.ReadOnly = true;
            this.process_Select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.process_Select.TrueValue = "true";
            this.process_Select.Width = 60;
            // 
            // process_Id
            // 
            this.process_Id.HeaderText = "Id";
            this.process_Id.Name = "process_Id";
            this.process_Id.ReadOnly = true;
            this.process_Id.Visible = false;
            // 
            // processIcon
            // 
            this.processIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            this.processIcon.DefaultCellStyle = dataGridViewCellStyle3;
            this.processIcon.HeaderText = "Icon";
            this.processIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.processIcon.Name = "processIcon";
            this.processIcon.ReadOnly = true;
            this.processIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.processIcon.Width = 45;
            // 
            // processName
            // 
            this.processName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.processName.HeaderText = "Name";
            this.processName.Name = "processName";
            this.processName.ReadOnly = true;
            this.processName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // processTime
            // 
            this.processTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.processTime.HeaderText = "Time";
            this.processTime.Name = "processTime";
            this.processTime.ReadOnly = true;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabAllProcesses);
            this.tabs.Controls.Add(this.tabSelectedProcesses);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(800, 450);
            this.tabs.TabIndex = 1;
            this.tabs.Click += new System.EventHandler(this.tabs_Click);
            // 
            // tabAllProcesses
            // 
            this.tabAllProcesses.Controls.Add(this.processList);
            this.tabAllProcesses.Location = new System.Drawing.Point(4, 24);
            this.tabAllProcesses.Name = "tabAllProcesses";
            this.tabAllProcesses.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllProcesses.Size = new System.Drawing.Size(792, 422);
            this.tabAllProcesses.TabIndex = 0;
            this.tabAllProcesses.Text = "All processes";
            this.tabAllProcesses.ToolTipText = "All processes";
            this.tabAllProcesses.UseVisualStyleBackColor = true;
            // 
            // tabSelectedProcesses
            // 
            this.tabSelectedProcesses.Controls.Add(this.selectedProcesses);
            this.tabSelectedProcesses.Location = new System.Drawing.Point(4, 24);
            this.tabSelectedProcesses.Name = "tabSelectedProcesses";
            this.tabSelectedProcesses.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelectedProcesses.Size = new System.Drawing.Size(792, 422);
            this.tabSelectedProcesses.TabIndex = 1;
            this.tabSelectedProcesses.Text = "Selected processes";
            this.tabSelectedProcesses.ToolTipText = "Selected processes";
            this.tabSelectedProcesses.UseVisualStyleBackColor = true;
            // 
            // selectedProcesses
            // 
            this.selectedProcesses.AllowUserToAddRows = false;
            this.selectedProcesses.AllowUserToDeleteRows = false;
            this.selectedProcesses.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.selectedProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedProcesses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.selectedProcesses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedProcesses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.selectedProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.selectedProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedProcesses.GridColor = System.Drawing.SystemColors.ControlLight;
            this.selectedProcesses.Location = new System.Drawing.Point(3, 3);
            this.selectedProcesses.Name = "selectedProcesses";
            this.selectedProcesses.ReadOnly = true;
            this.selectedProcesses.RowHeadersVisible = false;
            this.selectedProcesses.RowTemplate.Height = 30;
            this.selectedProcesses.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selectedProcesses.Size = new System.Drawing.Size(786, 416);
            this.selectedProcesses.TabIndex = 1;
            // 
            // Selected
            // 
            this.Selected.HeaderText = "Selected";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            this.Selected.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewImageColumn1.HeaderText = "Icon";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Time";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabs);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Time Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.processList)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabAllProcesses.ResumeLayout(false);
            this.tabSelectedProcesses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedProcesses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView processList;
        private TabControl tabs;
        private TabPage tabAllProcesses;
        private TabPage tabSelectedProcesses;
        private DataGridViewCheckBoxColumn process_Select;
        private DataGridViewTextBoxColumn process_Id;
        private DataGridViewImageColumn processIcon;
        private DataGridViewTextBoxColumn processName;
        private DataGridViewTextBoxColumn processTime;
        private DataGridView selectedProcesses;
        private DataGridViewCheckBoxColumn Selected;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}