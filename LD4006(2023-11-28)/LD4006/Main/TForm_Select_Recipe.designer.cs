namespace Main
{
    partial class TForm_Select_Recipe
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.參數");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2.列印格式");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("3.標籤機");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("4.機械參數");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Select_Recipe));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TV_Menu = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.B_Update_Tree = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TP_Grab_Pos = new System.Windows.Forms.TabPage();
            this.DG_Value = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.B_Value_Clear = new System.Windows.Forms.Button();
            this.B_Value_Add = new System.Windows.Forms.Button();
            this.B_Value_Move_Dn = new System.Windows.Forms.Button();
            this.B_Value_Delete = new System.Windows.Forms.Button();
            this.B_Value_Move_Up = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.E_Print_Format_List = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.B_Inport_File = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.E_Tear_Off = new System.Windows.Forms.TextBox();
            this.SB_Tear_Off = new System.Windows.Forms.HScrollBar();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Recipe_Info = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Recipe_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.B_Open = new System.Windows.Forms.Button();
            this.B_Save_As = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PM_Used = new System.Windows.Forms.ToolStripMenuItem();
            this.PM_Golden = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.B_Edit_MS_Param = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Grab_Pos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Value)).BeginInit();
            this.panel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1247, 741);
            this.splitContainer1.SplitterDistance = 989;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 137);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel5);
            this.splitContainer2.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(989, 604);
            this.splitContainer2.SplitterDistance = 321;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TV_Menu);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 59);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(321, 545);
            this.panel5.TabIndex = 2;
            // 
            // TV_Menu
            // 
            this.TV_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Menu.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TV_Menu.ImageIndex = 0;
            this.TV_Menu.ImageList = this.imageList1;
            this.TV_Menu.Indent = 32;
            this.TV_Menu.ItemHeight = 32;
            this.TV_Menu.Location = new System.Drawing.Point(0, 0);
            this.TV_Menu.Margin = new System.Windows.Forms.Padding(2);
            this.TV_Menu.Name = "TV_Menu";
            treeNode1.Name = "Value_Param";
            treeNode1.Text = "1.參數";
            treeNode2.Name = "Print_Format";
            treeNode2.Text = "2.列印格式";
            treeNode3.Name = "Printer";
            treeNode3.Text = "3.標籤機";
            treeNode4.Name = "Msparam";
            treeNode4.Text = "4.機械參數";
            treeNode5.Name = "Root";
            treeNode5.Text = "Root";
            this.TV_Menu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.TV_Menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TV_Menu.SelectedImageIndex = 0;
            this.TV_Menu.ShowNodeToolTips = true;
            this.TV_Menu.Size = new System.Drawing.Size(321, 545);
            this.TV_Menu.TabIndex = 0;
            this.TV_Menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Menu_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "019.bmp");
            this.imageList1.Images.SetKeyName(1, "No-02.bmp");
            this.imageList1.Images.SetKeyName(2, "Yes-01.bmp");
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.B_Update_Tree);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 59);
            this.panel4.TabIndex = 1;
            // 
            // B_Update_Tree
            // 
            this.B_Update_Tree.BackColor = System.Drawing.Color.LimeGreen;
            this.B_Update_Tree.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Update_Tree.Location = new System.Drawing.Point(46, 7);
            this.B_Update_Tree.Margin = new System.Windows.Forms.Padding(2);
            this.B_Update_Tree.Name = "B_Update_Tree";
            this.B_Update_Tree.Size = new System.Drawing.Size(148, 42);
            this.B_Update_Tree.TabIndex = 0;
            this.B_Update_Tree.Text = "更新狀態";
            this.B_Update_Tree.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.TP_Grab_Pos);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.ItemSize = new System.Drawing.Size(72, 0);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(665, 604);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(657, 576);
            this.tabPage1.TabIndex = 21;
            this.tabPage1.Text = "空白";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TP_Grab_Pos
            // 
            this.TP_Grab_Pos.BackColor = System.Drawing.SystemColors.Control;
            this.TP_Grab_Pos.Controls.Add(this.DG_Value);
            this.TP_Grab_Pos.Controls.Add(this.panel6);
            this.TP_Grab_Pos.Location = new System.Drawing.Point(4, 24);
            this.TP_Grab_Pos.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Grab_Pos.Name = "TP_Grab_Pos";
            this.TP_Grab_Pos.Size = new System.Drawing.Size(657, 576);
            this.TP_Grab_Pos.TabIndex = 19;
            this.TP_Grab_Pos.Text = "參數";
            // 
            // DG_Value
            // 
            this.DG_Value.AllowUserToAddRows = false;
            this.DG_Value.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Value.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.DG_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Value.Location = new System.Drawing.Point(0, 0);
            this.DG_Value.Name = "DG_Value";
            this.DG_Value.RowTemplate.Height = 24;
            this.DG_Value.Size = new System.Drawing.Size(576, 576);
            this.DG_Value.TabIndex = 3;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "No";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 40;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "變數名稱";
            this.Column1.Name = "Column1";
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "說明";
            this.Column2.Name = "Column2";
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Value";
            this.Column3.Name = "Column3";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.OliveDrab;
            this.panel6.Controls.Add(this.B_Value_Clear);
            this.panel6.Controls.Add(this.B_Value_Add);
            this.panel6.Controls.Add(this.B_Value_Move_Dn);
            this.panel6.Controls.Add(this.B_Value_Delete);
            this.panel6.Controls.Add(this.B_Value_Move_Up);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(576, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(81, 576);
            this.panel6.TabIndex = 2;
            // 
            // B_Value_Clear
            // 
            this.B_Value_Clear.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Value_Clear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Value_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Value_Clear.Location = new System.Drawing.Point(8, 11);
            this.B_Value_Clear.Margin = new System.Windows.Forms.Padding(2);
            this.B_Value_Clear.Name = "B_Value_Clear";
            this.B_Value_Clear.Size = new System.Drawing.Size(64, 64);
            this.B_Value_Clear.TabIndex = 32;
            this.B_Value_Clear.Text = "清除";
            this.B_Value_Clear.UseVisualStyleBackColor = false;
            this.B_Value_Clear.Click += new System.EventHandler(this.B_Value_Clear_Click);
            // 
            // B_Value_Add
            // 
            this.B_Value_Add.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Value_Add.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Value_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Value_Add.Location = new System.Drawing.Point(8, 215);
            this.B_Value_Add.Margin = new System.Windows.Forms.Padding(2);
            this.B_Value_Add.Name = "B_Value_Add";
            this.B_Value_Add.Size = new System.Drawing.Size(64, 64);
            this.B_Value_Add.TabIndex = 28;
            this.B_Value_Add.Text = "增加";
            this.B_Value_Add.UseVisualStyleBackColor = false;
            this.B_Value_Add.Click += new System.EventHandler(this.B_Value_Add_Click);
            // 
            // B_Value_Move_Dn
            // 
            this.B_Value_Move_Dn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Value_Move_Dn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Value_Move_Dn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Value_Move_Dn.Location = new System.Drawing.Point(8, 147);
            this.B_Value_Move_Dn.Margin = new System.Windows.Forms.Padding(2);
            this.B_Value_Move_Dn.Name = "B_Value_Move_Dn";
            this.B_Value_Move_Dn.Size = new System.Drawing.Size(64, 64);
            this.B_Value_Move_Dn.TabIndex = 31;
            this.B_Value_Move_Dn.Text = "下移";
            this.B_Value_Move_Dn.UseVisualStyleBackColor = false;
            this.B_Value_Move_Dn.Click += new System.EventHandler(this.B_Value_Move_Dn_Click);
            // 
            // B_Value_Delete
            // 
            this.B_Value_Delete.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Value_Delete.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Value_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Value_Delete.Location = new System.Drawing.Point(8, 283);
            this.B_Value_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.B_Value_Delete.Name = "B_Value_Delete";
            this.B_Value_Delete.Size = new System.Drawing.Size(64, 64);
            this.B_Value_Delete.TabIndex = 29;
            this.B_Value_Delete.Text = "刪除";
            this.B_Value_Delete.UseVisualStyleBackColor = false;
            this.B_Value_Delete.Click += new System.EventHandler(this.B_Value_Delete_Click);
            // 
            // B_Value_Move_Up
            // 
            this.B_Value_Move_Up.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Value_Move_Up.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Value_Move_Up.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Value_Move_Up.Location = new System.Drawing.Point(8, 79);
            this.B_Value_Move_Up.Margin = new System.Windows.Forms.Padding(2);
            this.B_Value_Move_Up.Name = "B_Value_Move_Up";
            this.B_Value_Move_Up.Size = new System.Drawing.Size(64, 64);
            this.B_Value_Move_Up.TabIndex = 30;
            this.B_Value_Move_Up.Text = "上移";
            this.B_Value_Move_Up.UseVisualStyleBackColor = false;
            this.B_Value_Move_Up.Click += new System.EventHandler(this.B_Value_Move_Up_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.E_Print_Format_List);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(657, 576);
            this.tabPage2.TabIndex = 22;
            this.tabPage2.Text = "列印格式";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // E_Print_Format_List
            // 
            this.E_Print_Format_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.E_Print_Format_List.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.E_Print_Format_List.Location = new System.Drawing.Point(0, 60);
            this.E_Print_Format_List.Multiline = true;
            this.E_Print_Format_List.Name = "E_Print_Format_List";
            this.E_Print_Format_List.Size = new System.Drawing.Size(657, 516);
            this.E_Print_Format_List.TabIndex = 9;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.B_Inport_File);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(657, 60);
            this.panel7.TabIndex = 8;
            // 
            // B_Inport_File
            // 
            this.B_Inport_File.Location = new System.Drawing.Point(13, 13);
            this.B_Inport_File.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Inport_File.Name = "B_Inport_File";
            this.B_Inport_File.Size = new System.Drawing.Size(137, 38);
            this.B_Inport_File.TabIndex = 11;
            this.B_Inport_File.Text = "從檔案匯入";
            this.B_Inport_File.UseVisualStyleBackColor = true;
            this.B_Inport_File.Click += new System.EventHandler(this.B_Inport_File_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.E_Tear_Off);
            this.tabPage3.Controls.Add(this.SB_Tear_Off);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(657, 576);
            this.tabPage3.TabIndex = 23;
            this.tabPage3.Text = "標籤機";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // E_Tear_Off
            // 
            this.E_Tear_Off.Location = new System.Drawing.Point(131, 79);
            this.E_Tear_Off.Name = "E_Tear_Off";
            this.E_Tear_Off.Size = new System.Drawing.Size(49, 24);
            this.E_Tear_Off.TabIndex = 13;
            // 
            // SB_Tear_Off
            // 
            this.SB_Tear_Off.Location = new System.Drawing.Point(17, 79);
            this.SB_Tear_Off.Maximum = 129;
            this.SB_Tear_Off.Minimum = -120;
            this.SB_Tear_Off.Name = "SB_Tear_Off";
            this.SB_Tear_Off.Size = new System.Drawing.Size(99, 21);
            this.SB_Tear_Off.TabIndex = 12;
            this.SB_Tear_Off.ValueChanged += new System.EventHandler(this.SB_Tear_Off_ValueChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(17, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 58);
            this.button4.TabIndex = 11;
            this.button4.Text = "Tear_Off";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 137);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Peru;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.E_Recipe_Info);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.E_Recipe_Name);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(989, 78);
            this.panel3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(205, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "說明";
            // 
            // E_Recipe_Info
            // 
            this.E_Recipe_Info.BackColor = System.Drawing.Color.Gray;
            this.E_Recipe_Info.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_Info.ForeColor = System.Drawing.Color.White;
            this.E_Recipe_Info.Location = new System.Drawing.Point(200, 36);
            this.E_Recipe_Info.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_Info.Name = "E_Recipe_Info";
            this.E_Recipe_Info.Size = new System.Drawing.Size(455, 33);
            this.E_Recipe_Info.TabIndex = 3;
            this.E_Recipe_Info.Text = "說明";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(176, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "/";
            // 
            // E_Recipe_Name
            // 
            this.E_Recipe_Name.BackColor = System.Drawing.Color.Gray;
            this.E_Recipe_Name.Enabled = false;
            this.E_Recipe_Name.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_Name.ForeColor = System.Drawing.Color.White;
            this.E_Recipe_Name.Location = new System.Drawing.Point(13, 36);
            this.E_Recipe_Name.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_Name.Name = "E_Recipe_Name";
            this.E_Recipe_Name.Size = new System.Drawing.Size(160, 33);
            this.E_Recipe_Name.TabIndex = 1;
            this.E_Recipe_Name.Text = "Recipe_Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(25, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recipe Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.B_Open);
            this.panel2.Controls.Add(this.B_Save_As);
            this.panel2.Controls.Add(this.B_Cancel);
            this.panel2.Controls.Add(this.B_Apply);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(989, 59);
            this.panel2.TabIndex = 2;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.Location = new System.Drawing.Point(289, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(97, 59);
            this.B_Open.TabIndex = 10;
            this.B_Open.Text = "開啟";
            this.B_Open.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Open.UseVisualStyleBackColor = false;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // B_Save_As
            // 
            this.B_Save_As.BackColor = System.Drawing.Color.White;
            this.B_Save_As.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Save_As.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save_As.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save_As.Location = new System.Drawing.Point(194, 0);
            this.B_Save_As.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save_As.Name = "B_Save_As";
            this.B_Save_As.Size = new System.Drawing.Size(95, 59);
            this.B_Save_As.TabIndex = 9;
            this.B_Save_As.Text = "另存檔案";
            this.B_Save_As.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Save_As.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Save_As.UseVisualStyleBackColor = false;
            this.B_Save_As.Click += new System.EventHandler(this.B_Save_As_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.Location = new System.Drawing.Point(97, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(97, 59);
            this.B_Cancel.TabIndex = 6;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.White;
            this.B_Apply.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Apply.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(97, 59);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PM_Used,
            this.PM_Golden});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // PM_Used
            // 
            this.PM_Used.Name = "PM_Used";
            this.PM_Used.Size = new System.Drawing.Size(116, 22);
            this.PM_Used.Text = "Used";
            // 
            // PM_Golden
            // 
            this.PM_Golden.Name = "PM_Golden";
            this.PM_Golden.Size = new System.Drawing.Size(116, 22);
            this.PM_Golden.Text = "Golden";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 1000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.B_Edit_MS_Param);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(657, 576);
            this.tabPage4.TabIndex = 24;
            this.tabPage4.Text = "機械參數";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // B_Edit_MS_Param
            // 
            this.B_Edit_MS_Param.Location = new System.Drawing.Point(21, 22);
            this.B_Edit_MS_Param.Name = "B_Edit_MS_Param";
            this.B_Edit_MS_Param.Size = new System.Drawing.Size(186, 97);
            this.B_Edit_MS_Param.TabIndex = 4;
            this.B_Edit_MS_Param.Text = "編輯機械參數";
            this.B_Edit_MS_Param.UseVisualStyleBackColor = true;
            this.B_Edit_MS_Param.Click += new System.EventHandler(this.B_Edit_MS_Param_Click);
            // 
            // TForm_Select_Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 741);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_Select_Recipe";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.TForm_Select_Recipe_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Grab_Pos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Value)).EndInit();
            this.panel6.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Recipe_Info;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Recipe_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView TV_Menu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save_As;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PM_Used;
        private System.Windows.Forms.ToolStripMenuItem PM_Golden;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button B_Update_Tree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_Grab_Pos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DG_Value;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button B_Value_Clear;
        private System.Windows.Forms.Button B_Value_Add;
        private System.Windows.Forms.Button B_Value_Move_Dn;
        private System.Windows.Forms.Button B_Value_Delete;
        private System.Windows.Forms.Button B_Value_Move_Up;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox E_Print_Format_List;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button B_Inport_File;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox E_Tear_Off;
        private System.Windows.Forms.HScrollBar SB_Tear_Off;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button B_Edit_MS_Param;
    }
}