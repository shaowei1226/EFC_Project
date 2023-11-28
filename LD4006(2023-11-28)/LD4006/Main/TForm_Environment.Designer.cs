namespace Main
{
    partial class TForm_Environment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Environment));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("基本參數");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("PLC設定");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("光源設定");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Reader");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("ComPort");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("步驟", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.Tool_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.B_Apply = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TV_Menu = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Space = new System.Windows.Forms.TabPage();
            this.TP_Base = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.E_Language = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Recipe_ID = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.E_Auto_Logout_Time = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_Auto_Logout = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.B_Select_Database_Path = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.E_Database_Path = new System.Windows.Forms.TextBox();
            this.B_Select_Recipe_Path = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.E_Recipe_Path = new System.Windows.Forms.TextBox();
            this.TP_Log = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.CB_Auto_Delete_File = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.E_Delete_Days = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.CB_Write_Log = new System.Windows.Forms.CheckBox();
            this.CB_Save_NG_Image = new System.Windows.Forms.CheckBox();
            this.CB_Save_OK_Image = new System.Windows.Forms.CheckBox();
            this.CB_Save_Sor_Image = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.E_PLC_Recipe_Count = new System.Windows.Forms.TextBox();
            this.E_PLC_Recipe_Start_Code = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.E_PLC_Out_Count = new System.Windows.Forms.TextBox();
            this.E_PLC_Out_Start_Code = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.E_PLC_In_Count = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.E_PLC_In_Start_Code = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.E_PLC_Port = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.E_PLC_Host = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_Printer_COM_Port = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.E_Reader_Port = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.E_Reader_Host = new System.Windows.Forms.TextBox();
            this.Light = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.CB_Grab_Light1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Base.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TP_Log.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.Light.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 59);
            this.panel1.TabIndex = 3;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.ImageIndex = 1;
            this.B_Cancel.ImageList = this.Tool_ImageList;
            this.B_Cancel.Location = new System.Drawing.Point(97, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(97, 59);
            this.B_Cancel.TabIndex = 6;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // Tool_ImageList
            // 
            this.Tool_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Tool_ImageList.ImageStream")));
            this.Tool_ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.Tool_ImageList.Images.SetKeyName(0, "magic_wand.bmp");
            this.Tool_ImageList.Images.SetKeyName(1, "button_cross.bmp");
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.White;
            this.B_Apply.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Apply.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.ImageIndex = 0;
            this.B_Apply.ImageList = this.Tool_ImageList;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(97, 59);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 59);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TV_Menu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(930, 475);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 4;
            // 
            // TV_Menu
            // 
            this.TV_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Menu.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TV_Menu.Indent = 24;
            this.TV_Menu.ItemHeight = 32;
            this.TV_Menu.Location = new System.Drawing.Point(0, 0);
            this.TV_Menu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TV_Menu.Name = "TV_Menu";
            treeNode1.Name = "Base";
            treeNode1.Text = "基本參數";
            treeNode2.Name = "PLC";
            treeNode2.Text = "PLC設定";
            treeNode3.Name = "Light";
            treeNode3.Text = "光源設定";
            treeNode4.Name = "Reader";
            treeNode4.Text = "Reader";
            treeNode5.Name = "ComPort";
            treeNode5.Text = "ComPort";
            treeNode6.Name = "Node0";
            treeNode6.Text = "步驟";
            this.TV_Menu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.TV_Menu.Size = new System.Drawing.Size(228, 475);
            this.TV_Menu.TabIndex = 3;
            this.TV_Menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Space);
            this.tabControl1.Controls.Add(this.TP_Base);
            this.tabControl1.Controls.Add(this.TP_Log);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.Light);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(699, 475);
            this.tabControl1.TabIndex = 3;
            // 
            // TP_Space
            // 
            this.TP_Space.Location = new System.Drawing.Point(4, 24);
            this.TP_Space.Name = "TP_Space";
            this.TP_Space.Size = new System.Drawing.Size(691, 447);
            this.TP_Space.TabIndex = 6;
            this.TP_Space.Text = "空白";
            this.TP_Space.UseVisualStyleBackColor = true;
            // 
            // TP_Base
            // 
            this.TP_Base.Controls.Add(this.groupBox7);
            this.TP_Base.Controls.Add(this.groupBox3);
            this.TP_Base.Controls.Add(this.groupBox4);
            this.TP_Base.Controls.Add(this.groupBox2);
            this.TP_Base.Location = new System.Drawing.Point(4, 24);
            this.TP_Base.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Base.Name = "TP_Base";
            this.TP_Base.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Base.Size = new System.Drawing.Size(691, 447);
            this.TP_Base.TabIndex = 0;
            this.TP_Base.Text = "基本參數";
            this.TP_Base.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.E_Language);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Location = new System.Drawing.Point(25, 174);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(406, 57);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Language";
            // 
            // E_Language
            // 
            this.E_Language.BackColor = System.Drawing.Color.DimGray;
            this.E_Language.ForeColor = System.Drawing.Color.White;
            this.E_Language.Location = new System.Drawing.Point(118, 23);
            this.E_Language.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Language.Name = "E_Language";
            this.E_Language.ReadOnly = true;
            this.E_Language.Size = new System.Drawing.Size(121, 24);
            this.E_Language.TabIndex = 4;
            this.E_Language.Text = "繁體中文";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 27);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 14);
            this.label15.TabIndex = 3;
            this.label15.Text = "Language:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.E_Recipe_ID);
            this.groupBox3.Location = new System.Drawing.Point(25, 112);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(406, 56);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "參數路徑";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Recipe_Name:";
            // 
            // E_Recipe_ID
            // 
            this.E_Recipe_ID.BackColor = System.Drawing.Color.DimGray;
            this.E_Recipe_ID.ForeColor = System.Drawing.Color.White;
            this.E_Recipe_ID.Location = new System.Drawing.Point(118, 23);
            this.E_Recipe_ID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Recipe_ID.Name = "E_Recipe_ID";
            this.E_Recipe_ID.Size = new System.Drawing.Size(276, 24);
            this.E_Recipe_ID.TabIndex = 0;
            this.E_Recipe_ID.Text = "1234567890";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.E_Auto_Logout_Time);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.CB_Auto_Logout);
            this.groupBox4.Location = new System.Drawing.Point(25, 237);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Size = new System.Drawing.Size(406, 63);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "帳號相關";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(361, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 14);
            this.label10.TabIndex = 4;
            this.label10.Text = "Min";
            // 
            // E_Auto_Logout_Time
            // 
            this.E_Auto_Logout_Time.Location = new System.Drawing.Point(319, 25);
            this.E_Auto_Logout_Time.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Auto_Logout_Time.Name = "E_Auto_Logout_Time";
            this.E_Auto_Logout_Time.Size = new System.Drawing.Size(38, 24);
            this.E_Auto_Logout_Time.TabIndex = 3;
            this.E_Auto_Logout_Time.Text = "5";
            this.E_Auto_Logout_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "登出時間：";
            // 
            // CB_Auto_Logout
            // 
            this.CB_Auto_Logout.AutoSize = true;
            this.CB_Auto_Logout.Location = new System.Drawing.Point(16, 30);
            this.CB_Auto_Logout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CB_Auto_Logout.Name = "CB_Auto_Logout";
            this.CB_Auto_Logout.Size = new System.Drawing.Size(206, 18);
            this.CB_Auto_Logout.TabIndex = 0;
            this.CB_Auto_Logout.Text = "是否要自動登出使用者帳號";
            this.CB_Auto_Logout.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.B_Select_Database_Path);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.E_Database_Path);
            this.groupBox2.Controls.Add(this.B_Select_Recipe_Path);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.E_Recipe_Path);
            this.groupBox2.Location = new System.Drawing.Point(25, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(406, 88);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "參數路徑";
            // 
            // B_Select_Database_Path
            // 
            this.B_Select_Database_Path.Location = new System.Drawing.Point(343, 57);
            this.B_Select_Database_Path.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Select_Database_Path.Name = "B_Select_Database_Path";
            this.B_Select_Database_Path.Size = new System.Drawing.Size(56, 22);
            this.B_Select_Database_Path.TabIndex = 8;
            this.B_Select_Database_Path.Text = "...";
            this.B_Select_Database_Path.UseVisualStyleBackColor = true;
            this.B_Select_Database_Path.Click += new System.EventHandler(this.B_Select_Database_Path_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "資料庫路徑：";
            // 
            // E_Database_Path
            // 
            this.E_Database_Path.BackColor = System.Drawing.Color.DimGray;
            this.E_Database_Path.ForeColor = System.Drawing.Color.White;
            this.E_Database_Path.Location = new System.Drawing.Point(118, 57);
            this.E_Database_Path.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Database_Path.Name = "E_Database_Path";
            this.E_Database_Path.Size = new System.Drawing.Size(221, 24);
            this.E_Database_Path.TabIndex = 6;
            this.E_Database_Path.Text = "Full_File_Name";
            // 
            // B_Select_Recipe_Path
            // 
            this.B_Select_Recipe_Path.Location = new System.Drawing.Point(343, 27);
            this.B_Select_Recipe_Path.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Select_Recipe_Path.Name = "B_Select_Recipe_Path";
            this.B_Select_Recipe_Path.Size = new System.Drawing.Size(56, 22);
            this.B_Select_Recipe_Path.TabIndex = 2;
            this.B_Select_Recipe_Path.Text = "...";
            this.B_Select_Recipe_Path.UseVisualStyleBackColor = true;
            this.B_Select_Recipe_Path.Click += new System.EventHandler(this.B_Select_Recipe_Path_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "生產參數路徑：";
            // 
            // E_Recipe_Path
            // 
            this.E_Recipe_Path.BackColor = System.Drawing.Color.DimGray;
            this.E_Recipe_Path.ForeColor = System.Drawing.Color.White;
            this.E_Recipe_Path.Location = new System.Drawing.Point(118, 27);
            this.E_Recipe_Path.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Recipe_Path.Name = "E_Recipe_Path";
            this.E_Recipe_Path.Size = new System.Drawing.Size(221, 24);
            this.E_Recipe_Path.TabIndex = 0;
            this.E_Recipe_Path.Text = "Full_File_Name";
            // 
            // TP_Log
            // 
            this.TP_Log.Controls.Add(this.groupBox6);
            this.TP_Log.Location = new System.Drawing.Point(4, 24);
            this.TP_Log.Name = "TP_Log";
            this.TP_Log.Size = new System.Drawing.Size(691, 447);
            this.TP_Log.TabIndex = 5;
            this.TP_Log.Text = "Log設定";
            this.TP_Log.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.CB_Write_Log);
            this.groupBox6.Controls.Add(this.CB_Save_NG_Image);
            this.groupBox6.Controls.Add(this.CB_Save_OK_Image);
            this.groupBox6.Controls.Add(this.CB_Save_Sor_Image);
            this.groupBox6.Location = new System.Drawing.Point(20, 18);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox6.Size = new System.Drawing.Size(178, 243);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "[影像資訊]";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.CB_Auto_Delete_File);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.E_Delete_Days);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Location = new System.Drawing.Point(10, 152);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(158, 78);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "[ 檔案 ]";
            // 
            // CB_Auto_Delete_File
            // 
            this.CB_Auto_Delete_File.AutoSize = true;
            this.CB_Auto_Delete_File.Location = new System.Drawing.Point(12, 22);
            this.CB_Auto_Delete_File.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Auto_Delete_File.Name = "CB_Auto_Delete_File";
            this.CB_Auto_Delete_File.Size = new System.Drawing.Size(116, 18);
            this.CB_Auto_Delete_File.TabIndex = 8;
            this.CB_Auto_Delete_File.Text = "自動刪除檔案";
            this.CB_Auto_Delete_File.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(135, 52);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 14);
            this.label11.TabIndex = 7;
            this.label11.Text = "天";
            // 
            // E_Delete_Days
            // 
            this.E_Delete_Days.Location = new System.Drawing.Point(86, 50);
            this.E_Delete_Days.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Delete_Days.Name = "E_Delete_Days";
            this.E_Delete_Days.Size = new System.Drawing.Size(45, 24);
            this.E_Delete_Days.TabIndex = 6;
            this.E_Delete_Days.Text = "123";
            this.E_Delete_Days.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 52);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 14);
            this.label18.TabIndex = 5;
            this.label18.Text = "保留數量:";
            // 
            // CB_Write_Log
            // 
            this.CB_Write_Log.AutoSize = true;
            this.CB_Write_Log.Location = new System.Drawing.Point(10, 122);
            this.CB_Write_Log.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CB_Write_Log.Name = "CB_Write_Log";
            this.CB_Write_Log.Size = new System.Drawing.Size(116, 18);
            this.CB_Write_Log.TabIndex = 4;
            this.CB_Write_Log.Text = "儲存歷史紀錄";
            this.CB_Write_Log.UseVisualStyleBackColor = true;
            // 
            // CB_Save_NG_Image
            // 
            this.CB_Save_NG_Image.AutoSize = true;
            this.CB_Save_NG_Image.Location = new System.Drawing.Point(10, 89);
            this.CB_Save_NG_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CB_Save_NG_Image.Name = "CB_Save_NG_Image";
            this.CB_Save_NG_Image.Size = new System.Drawing.Size(106, 18);
            this.CB_Save_NG_Image.TabIndex = 2;
            this.CB_Save_NG_Image.Text = "儲存NG影像";
            this.CB_Save_NG_Image.UseVisualStyleBackColor = true;
            // 
            // CB_Save_OK_Image
            // 
            this.CB_Save_OK_Image.AutoSize = true;
            this.CB_Save_OK_Image.Location = new System.Drawing.Point(10, 59);
            this.CB_Save_OK_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CB_Save_OK_Image.Name = "CB_Save_OK_Image";
            this.CB_Save_OK_Image.Size = new System.Drawing.Size(106, 18);
            this.CB_Save_OK_Image.TabIndex = 1;
            this.CB_Save_OK_Image.Text = "儲存OK影像";
            this.CB_Save_OK_Image.UseVisualStyleBackColor = true;
            // 
            // CB_Save_Sor_Image
            // 
            this.CB_Save_Sor_Image.AutoSize = true;
            this.CB_Save_Sor_Image.Location = new System.Drawing.Point(10, 29);
            this.CB_Save_Sor_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CB_Save_Sor_Image.Name = "CB_Save_Sor_Image";
            this.CB_Save_Sor_Image.Size = new System.Drawing.Size(116, 18);
            this.CB_Save_Sor_Image.TabIndex = 0;
            this.CB_Save_Sor_Image.Text = "儲存原始影像";
            this.CB_Save_Sor_Image.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox13);
            this.tabPage4.Controls.Add(this.tabControl2);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(691, 447);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "PLC設定";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.E_PLC_Recipe_Count);
            this.groupBox13.Controls.Add(this.E_PLC_Recipe_Start_Code);
            this.groupBox13.Controls.Add(this.label43);
            this.groupBox13.Controls.Add(this.E_PLC_Out_Count);
            this.groupBox13.Controls.Add(this.E_PLC_Out_Start_Code);
            this.groupBox13.Controls.Add(this.label42);
            this.groupBox13.Controls.Add(this.label41);
            this.groupBox13.Controls.Add(this.E_PLC_In_Count);
            this.groupBox13.Controls.Add(this.label40);
            this.groupBox13.Controls.Add(this.E_PLC_In_Start_Code);
            this.groupBox13.Controls.Add(this.label39);
            this.groupBox13.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox13.Location = new System.Drawing.Point(15, 138);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox13.Size = new System.Drawing.Size(398, 138);
            this.groupBox13.TabIndex = 2;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "資料範圍";
            // 
            // E_PLC_Recipe_Count
            // 
            this.E_PLC_Recipe_Count.Location = new System.Drawing.Point(314, 102);
            this.E_PLC_Recipe_Count.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_PLC_Recipe_Count.Name = "E_PLC_Recipe_Count";
            this.E_PLC_Recipe_Count.Size = new System.Drawing.Size(54, 30);
            this.E_PLC_Recipe_Count.TabIndex = 36;
            this.E_PLC_Recipe_Count.Text = "100";
            this.E_PLC_Recipe_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_PLC_Recipe_Start_Code
            // 
            this.E_PLC_Recipe_Start_Code.Location = new System.Drawing.Point(229, 102);
            this.E_PLC_Recipe_Start_Code.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_PLC_Recipe_Start_Code.Name = "E_PLC_Recipe_Start_Code";
            this.E_PLC_Recipe_Start_Code.Size = new System.Drawing.Size(74, 30);
            this.E_PLC_Recipe_Start_Code.TabIndex = 35;
            this.E_PLC_Recipe_Start_Code.Text = "D300";
            this.E_PLC_Recipe_Start_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(4, 104);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(183, 19);
            this.label43.TabIndex = 34;
            this.label43.Text = "PC品種資料(Recipe)";
            // 
            // E_PLC_Out_Count
            // 
            this.E_PLC_Out_Count.Location = new System.Drawing.Point(314, 69);
            this.E_PLC_Out_Count.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_PLC_Out_Count.Name = "E_PLC_Out_Count";
            this.E_PLC_Out_Count.Size = new System.Drawing.Size(54, 30);
            this.E_PLC_Out_Count.TabIndex = 33;
            this.E_PLC_Out_Count.Text = "100";
            this.E_PLC_Out_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_PLC_Out_Start_Code
            // 
            this.E_PLC_Out_Start_Code.Location = new System.Drawing.Point(229, 69);
            this.E_PLC_Out_Start_Code.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_PLC_Out_Start_Code.Name = "E_PLC_Out_Start_Code";
            this.E_PLC_Out_Start_Code.Size = new System.Drawing.Size(74, 30);
            this.E_PLC_Out_Start_Code.TabIndex = 32;
            this.E_PLC_Out_Start_Code.Text = "D200";
            this.E_PLC_Out_Start_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(4, 71);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(157, 19);
            this.label42.TabIndex = 31;
            this.label42.Text = "PC輸出資料(Out)";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label41.Location = new System.Drawing.Point(320, 16);
            this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(42, 16);
            this.label41.TabIndex = 30;
            this.label41.Text = "數量";
            // 
            // E_PLC_In_Count
            // 
            this.E_PLC_In_Count.Location = new System.Drawing.Point(314, 36);
            this.E_PLC_In_Count.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_PLC_In_Count.Name = "E_PLC_In_Count";
            this.E_PLC_In_Count.Size = new System.Drawing.Size(54, 30);
            this.E_PLC_In_Count.TabIndex = 29;
            this.E_PLC_In_Count.Text = "100";
            this.E_PLC_In_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label40.Location = new System.Drawing.Point(232, 16);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(76, 16);
            this.label40.TabIndex = 28;
            this.label40.Text = "起始位置";
            // 
            // E_PLC_In_Start_Code
            // 
            this.E_PLC_In_Start_Code.Location = new System.Drawing.Point(229, 36);
            this.E_PLC_In_Start_Code.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_PLC_In_Start_Code.Name = "E_PLC_In_Start_Code";
            this.E_PLC_In_Start_Code.Size = new System.Drawing.Size(74, 30);
            this.E_PLC_In_Start_Code.TabIndex = 27;
            this.E_PLC_In_Start_Code.Text = "D100";
            this.E_PLC_In_Start_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(4, 39);
            this.label39.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(144, 19);
            this.label39.TabIndex = 26;
            this.label39.Text = "PC輸入資料(In)";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl2.Location = new System.Drawing.Point(12, 11);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(404, 110);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.E_PLC_Port);
            this.tabPage8.Controls.Add(this.label38);
            this.tabPage8.Controls.Add(this.E_PLC_Host);
            this.tabPage8.Controls.Add(this.label37);
            this.tabPage8.Location = new System.Drawing.Point(4, 28);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage8.Size = new System.Drawing.Size(396, 78);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Ethernet";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // E_PLC_Port
            // 
            this.E_PLC_Port.Location = new System.Drawing.Point(240, 46);
            this.E_PLC_Port.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_PLC_Port.Name = "E_PLC_Port";
            this.E_PLC_Port.Size = new System.Drawing.Size(74, 30);
            this.E_PLC_Port.TabIndex = 16;
            this.E_PLC_Port.Text = "8080";
            this.E_PLC_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(17, 50);
            this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(115, 19);
            this.label38.TabIndex = 15;
            this.label38.Text = "PLC IP Port:";
            // 
            // E_PLC_Host
            // 
            this.E_PLC_Host.Location = new System.Drawing.Point(240, 14);
            this.E_PLC_Host.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_PLC_Host.Name = "E_PLC_Host";
            this.E_PLC_Host.Size = new System.Drawing.Size(124, 30);
            this.E_PLC_Host.TabIndex = 14;
            this.E_PLC_Host.Text = "192.168.0.1";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(17, 16);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(119, 19);
            this.label37.TabIndex = 13;
            this.label37.Text = "PLC IP Host:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(691, 447);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "COM Port設定";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_Printer_COM_Port);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(353, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // CB_Printer_COM_Port
            // 
            this.CB_Printer_COM_Port.FormattingEnabled = true;
            this.CB_Printer_COM_Port.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.CB_Printer_COM_Port.Location = new System.Drawing.Point(246, 25);
            this.CB_Printer_COM_Port.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CB_Printer_COM_Port.Name = "CB_Printer_COM_Port";
            this.CB_Printer_COM_Port.Size = new System.Drawing.Size(92, 26);
            this.CB_Printer_COM_Port.TabIndex = 14;
            this.CB_Printer_COM_Port.Text = "COM1";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(16, 29);
            this.label45.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(155, 19);
            this.label45.TabIndex = 13;
            this.label45.Text = "Printer Com Port:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(691, 447);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Reader";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.E_Reader_Port);
            this.groupBox9.Controls.Add(this.label17);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.E_Reader_Host);
            this.groupBox9.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox9.Location = new System.Drawing.Point(6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(398, 100);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "[ 參數 ]";
            // 
            // E_Reader_Port
            // 
            this.E_Reader_Port.Location = new System.Drawing.Point(229, 59);
            this.E_Reader_Port.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Reader_Port.Name = "E_Reader_Port";
            this.E_Reader_Port.Size = new System.Drawing.Size(74, 30);
            this.E_Reader_Port.TabIndex = 16;
            this.E_Reader_Port.Text = "5010";
            this.E_Reader_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 26);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 19);
            this.label17.TabIndex = 13;
            this.label17.Text = "Host:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 64);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 19);
            this.label19.TabIndex = 15;
            this.label19.Text = "Port:";
            // 
            // E_Reader_Host
            // 
            this.E_Reader_Host.Location = new System.Drawing.Point(229, 23);
            this.E_Reader_Host.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Reader_Host.Name = "E_Reader_Host";
            this.E_Reader_Host.Size = new System.Drawing.Size(145, 30);
            this.E_Reader_Host.TabIndex = 14;
            this.E_Reader_Host.Text = "192.168.0.1";
            // 
            // Light
            // 
            this.Light.Controls.Add(this.groupBox10);
            this.Light.Location = new System.Drawing.Point(4, 24);
            this.Light.Name = "Light";
            this.Light.Padding = new System.Windows.Forms.Padding(3);
            this.Light.Size = new System.Drawing.Size(691, 447);
            this.Light.TabIndex = 8;
            this.Light.Text = "光源設定";
            this.Light.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.CB_Grab_Light1);
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox10.Location = new System.Drawing.Point(15, 6);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox10.Size = new System.Drawing.Size(353, 69);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            // 
            // CB_Grab_Light1
            // 
            this.CB_Grab_Light1.FormattingEnabled = true;
            this.CB_Grab_Light1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.CB_Grab_Light1.Location = new System.Drawing.Point(246, 25);
            this.CB_Grab_Light1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CB_Grab_Light1.Name = "CB_Grab_Light1";
            this.CB_Grab_Light1.Size = new System.Drawing.Size(92, 26);
            this.CB_Grab_Light1.TabIndex = 14;
            this.CB_Grab_Light1.Text = "COM1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "調光器1 Com Port:";
            // 
            // TForm_Environment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 534);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TForm_Environment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TForm_Environment";
            this.Shown += new System.EventHandler(this.TForm_Environment_Shown);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Base.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TP_Log.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.Light.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TV_Menu;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_Base;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox CB_Auto_Logout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button B_Select_Recipe_Path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox E_Recipe_Path;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox E_Auto_Logout_Time;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_Printer_COM_Port;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox E_PLC_Recipe_Count;
        private System.Windows.Forms.TextBox E_PLC_Recipe_Start_Code;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox E_PLC_Out_Count;
        private System.Windows.Forms.TextBox E_PLC_Out_Start_Code;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox E_PLC_In_Count;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox E_PLC_In_Start_Code;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TextBox E_PLC_Port;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox E_PLC_Host;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button B_Select_Database_Path;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox E_Database_Path;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Recipe_ID;
        private System.Windows.Forms.ImageList Tool_ImageList;
        private System.Windows.Forms.TabPage TP_Log;
        private System.Windows.Forms.TabPage TP_Space;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox CB_Auto_Delete_File;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox E_Delete_Days;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox CB_Write_Log;
        private System.Windows.Forms.CheckBox CB_Save_NG_Image;
        private System.Windows.Forms.CheckBox CB_Save_OK_Image;
        private System.Windows.Forms.CheckBox CB_Save_Sor_Image;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox E_Language;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox E_Reader_Port;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox E_Reader_Host;
        private System.Windows.Forms.TabPage Light;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox CB_Grab_Light1;
        private System.Windows.Forms.Label label2;
    }
}