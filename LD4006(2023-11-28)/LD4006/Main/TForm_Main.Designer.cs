namespace Main
{
     partial class TForm_Main
     {
          /// <summary>
          /// 設計工具所需的變數。
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// 清除任何使用中的資源。
          /// </summary>
          /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form 設計工具產生的程式碼

          /// <summary>
          /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
          /// 修改這個方法的內容。
          /// </summary>
          private void InitializeComponent()
          {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSM_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Environment = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_Recipe = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Recipe = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_Communication = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_ViewData_In = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_ViewData_Out = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_ViewData_Recipe = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Main = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.E_Print_Format = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DG_Value = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.E_Out_Print_Format = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.picResultImage = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.E_P_Reader_Code = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.B_P_Read_Code = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.E_C_Reader_Code = new System.Windows.Forms.TextBox();
            this.B_C_Read_Code = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_Printer_Ready = new System.Windows.Forms.CheckBox();
            this.CB_Printer_S2 = new System.Windows.Forms.CheckBox();
            this.CB_Printer_S1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Light_Setting = new System.Windows.Forms.TabPage();
            this.B_ALL_Close = new System.Windows.Forms.Button();
            this.B_ALL_Open = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tFrame_Set_Light4 = new EFC.Light.TFrame_Set_Light();
            this.tFrame_Set_Light3 = new EFC.Light.TFrame_Set_Light();
            this.tFrame_Set_Light2 = new EFC.Light.TFrame_Set_Light();
            this.tFrame_Set_Light1 = new EFC.Light.TFrame_Set_Light();
            this.label21 = new System.Windows.Forms.Label();
            this.CB_Light_Box = new System.Windows.Forms.ComboBox();
            this.TP_Log = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.DG_Log = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel14 = new System.Windows.Forms.Panel();
            this.B_Log_Sort = new System.Windows.Forms.Button();
            this.B_Log_Reset = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.P_Printer = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.B_Printer = new System.Windows.Forms.Button();
            this.P_Casette_Reader = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.B_Casette_Reader = new System.Windows.Forms.Button();
            this.P_PLC = new System.Windows.Forms.Panel();
            this.E_PLC_Time = new System.Windows.Forms.TextBox();
            this.B_PLC = new System.Windows.Forms.Button();
            this.L_PLC_Text = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.E_User_Level = new System.Windows.Forms.TextBox();
            this.E_User_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.E_Recipe_Info = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.E_Recipe_ID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Main.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Value)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResultImage)).BeginInit();
            this.panel6.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Light_Setting.SuspendLayout();
            this.panel10.SuspendLayout();
            this.TP_Log.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Log)).BeginInit();
            this.panel14.SuspendLayout();
            this.panel2.SuspendLayout();
            this.P_Printer.SuspendLayout();
            this.P_Casette_Reader.SuspendLayout();
            this.P_PLC.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(223)))), ((int)(((byte)(245)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.TSM_File,
            this.MI_Environment,
            this.TSM_Recipe,
            this.TSM_Communication,
            this.MI_Info});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1309, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(82, 36);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // TSM_File
            // 
            this.TSM_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_Login,
            this.MI_Logout,
            this.MI_Close});
            this.TSM_File.Name = "TSM_File";
            this.TSM_File.Size = new System.Drawing.Size(59, 36);
            this.TSM_File.Text = "檔案\r[File]";
            // 
            // MI_Login
            // 
            this.MI_Login.Name = "MI_Login";
            this.MI_Login.Size = new System.Drawing.Size(217, 36);
            this.MI_Login.Text = "使用者登入\r[Log In]";
            this.MI_Login.Click += new System.EventHandler(this.MI_Login_Click);
            // 
            // MI_Logout
            // 
            this.MI_Logout.Name = "MI_Logout";
            this.MI_Logout.Size = new System.Drawing.Size(217, 36);
            this.MI_Logout.Text = "使用者登出\r[Log Out]";
            this.MI_Logout.Click += new System.EventHandler(this.MI_Logout_Click);
            // 
            // MI_Close
            // 
            this.MI_Close.Name = "MI_Close";
            this.MI_Close.Size = new System.Drawing.Size(217, 36);
            this.MI_Close.Text = "關閉程式\r[Close Application]";
            this.MI_Close.Click += new System.EventHandler(this.MI_Close_Click);
            // 
            // MI_Environment
            // 
            this.MI_Environment.Name = "MI_Environment";
            this.MI_Environment.Size = new System.Drawing.Size(124, 36);
            this.MI_Environment.Text = "環境參數\r[Environment]";
            this.MI_Environment.Click += new System.EventHandler(this.MI_Environment_Click);
            // 
            // TSM_Recipe
            // 
            this.TSM_Recipe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_Recipe});
            this.TSM_Recipe.Name = "TSM_Recipe";
            this.TSM_Recipe.Size = new System.Drawing.Size(88, 36);
            this.TSM_Recipe.Text = "生產參數\r[Recipe]";
            // 
            // MI_Recipe
            // 
            this.MI_Recipe.Name = "MI_Recipe";
            this.MI_Recipe.Size = new System.Drawing.Size(146, 36);
            this.MI_Recipe.Text = "生產參數\r[Produce]";
            this.MI_Recipe.Click += new System.EventHandler(this.MI_Recipe_Click);
            // 
            // TSM_Communication
            // 
            this.TSM_Communication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_ViewData_In,
            this.MI_ViewData_Out,
            this.MI_ViewData_Recipe});
            this.TSM_Communication.Name = "TSM_Communication";
            this.TSM_Communication.Size = new System.Drawing.Size(152, 36);
            this.TSM_Communication.Text = "資料監控\r[Communications]";
            // 
            // MI_ViewData_In
            // 
            this.MI_ViewData_In.Name = "MI_ViewData_In";
            this.MI_ViewData_In.Size = new System.Drawing.Size(144, 22);
            this.MI_ViewData_In.Text = "輸入";
            this.MI_ViewData_In.Click += new System.EventHandler(this.MI_ViewData_In_Click);
            // 
            // MI_ViewData_Out
            // 
            this.MI_ViewData_Out.Name = "MI_ViewData_Out";
            this.MI_ViewData_Out.Size = new System.Drawing.Size(144, 22);
            this.MI_ViewData_Out.Text = "輸出";
            this.MI_ViewData_Out.Click += new System.EventHandler(this.MI_ViewData_Out_Click);
            // 
            // MI_ViewData_Recipe
            // 
            this.MI_ViewData_Recipe.Name = "MI_ViewData_Recipe";
            this.MI_ViewData_Recipe.Size = new System.Drawing.Size(144, 22);
            this.MI_ViewData_Recipe.Text = "生產參數";
            this.MI_ViewData_Recipe.Click += new System.EventHandler(this.MI_ViewData_Recipe_Click);
            // 
            // MI_Info
            // 
            this.MI_Info.Name = "MI_Info";
            this.MI_Info.Size = new System.Drawing.Size(117, 36);
            this.MI_Info.Text = "說明\r[Information]";
            this.MI_Info.Click += new System.EventHandler(this.MI_Info_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1309, 555);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Main);
            this.tabControl1.Controls.Add(this.TP_Log);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1309, 555);
            this.tabControl1.TabIndex = 0;
            // 
            // TP_Main
            // 
            this.TP_Main.Controls.Add(this.tabControl3);
            this.TP_Main.Location = new System.Drawing.Point(4, 26);
            this.TP_Main.Name = "TP_Main";
            this.TP_Main.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Main.Size = new System.Drawing.Size(1301, 525);
            this.TP_Main.TabIndex = 0;
            this.TP_Main.Text = "主畫面";
            this.TP_Main.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Controls.Add(this.tabPage4);
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Controls.Add(this.Light_Setting);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl3.Location = new System.Drawing.Point(3, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(789, 519);
            this.tabControl3.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.E_Print_Format);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(781, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "列印標籤格式";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // E_Print_Format
            // 
            this.E_Print_Format.Dock = System.Windows.Forms.DockStyle.Fill;
            this.E_Print_Format.Enabled = false;
            this.E_Print_Format.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.E_Print_Format.Location = new System.Drawing.Point(3, 3);
            this.E_Print_Format.Multiline = true;
            this.E_Print_Format.Name = "E_Print_Format";
            this.E_Print_Format.Size = new System.Drawing.Size(775, 483);
            this.E_Print_Format.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DG_Value);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "替換變數";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DG_Value
            // 
            this.DG_Value.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Value.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.DG_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Value.Enabled = false;
            this.DG_Value.Location = new System.Drawing.Point(3, 3);
            this.DG_Value.Name = "DG_Value";
            this.DG_Value.RowTemplate.Height = 24;
            this.DG_Value.Size = new System.Drawing.Size(775, 483);
            this.DG_Value.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "No";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 40;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "變數名稱";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "說明";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Value";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 300;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.E_Out_Print_Format);
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(781, 489);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "列印輸出內容";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // E_Out_Print_Format
            // 
            this.E_Out_Print_Format.Dock = System.Windows.Forms.DockStyle.Fill;
            this.E_Out_Print_Format.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.E_Out_Print_Format.Location = new System.Drawing.Point(0, 72);
            this.E_Out_Print_Format.Multiline = true;
            this.E_Out_Print_Format.Name = "E_Out_Print_Format";
            this.E_Out_Print_Format.Size = new System.Drawing.Size(781, 417);
            this.E_Out_Print_Format.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(781, 72);
            this.panel5.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 47);
            this.button2.TabIndex = 0;
            this.button2.Text = "列印";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel7);
            this.tabPage4.Controls.Add(this.panel6);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(781, 489);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Panel Reader";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.picResultImage);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 120);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(781, 369);
            this.panel7.TabIndex = 16;
            // 
            // picResultImage
            // 
            this.picResultImage.BackColor = System.Drawing.Color.White;
            this.picResultImage.Location = new System.Drawing.Point(1, 1);
            this.picResultImage.Name = "picResultImage";
            this.picResultImage.Size = new System.Drawing.Size(157, 140);
            this.picResultImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResultImage.TabIndex = 16;
            this.picResultImage.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button5);
            this.panel6.Controls.Add(this.E_P_Reader_Code);
            this.panel6.Controls.Add(this.button6);
            this.panel6.Controls.Add(this.B_P_Read_Code);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(781, 120);
            this.panel6.TabIndex = 15;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(14, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 43);
            this.button5.TabIndex = 11;
            this.button5.Text = "Connect";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // E_P_Reader_Code
            // 
            this.E_P_Reader_Code.Location = new System.Drawing.Point(129, 77);
            this.E_P_Reader_Code.Name = "E_P_Reader_Code";
            this.E_P_Reader_Code.Size = new System.Drawing.Size(421, 27);
            this.E_P_Reader_Code.TabIndex = 14;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(119, 18);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 43);
            this.button6.TabIndex = 12;
            this.button6.Text = "Live";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // B_P_Read_Code
            // 
            this.B_P_Read_Code.Location = new System.Drawing.Point(12, 67);
            this.B_P_Read_Code.Name = "B_P_Read_Code";
            this.B_P_Read_Code.Size = new System.Drawing.Size(113, 43);
            this.B_P_Read_Code.TabIndex = 13;
            this.B_P_Read_Code.Text = "Read_Code";
            this.B_P_Read_Code.UseVisualStyleBackColor = true;
            this.B_P_Read_Code.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel8);
            this.tabPage6.Location = new System.Drawing.Point(4, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(781, 489);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Cassette Reader";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.E_C_Reader_Code);
            this.panel8.Controls.Add(this.B_C_Read_Code);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(781, 120);
            this.panel8.TabIndex = 16;
            // 
            // E_C_Reader_Code
            // 
            this.E_C_Reader_Code.Location = new System.Drawing.Point(129, 77);
            this.E_C_Reader_Code.Name = "E_C_Reader_Code";
            this.E_C_Reader_Code.Size = new System.Drawing.Size(421, 27);
            this.E_C_Reader_Code.TabIndex = 14;
            // 
            // B_C_Read_Code
            // 
            this.B_C_Read_Code.Location = new System.Drawing.Point(12, 67);
            this.B_C_Read_Code.Name = "B_C_Read_Code";
            this.B_C_Read_Code.Size = new System.Drawing.Size(113, 43);
            this.B_C_Read_Code.TabIndex = 13;
            this.B_C_Read_Code.Text = "Read_Code";
            this.B_C_Read_Code.UseVisualStyleBackColor = true;
            this.B_C_Read_Code.Click += new System.EventHandler(this.B_C_Read_Code_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(781, 489);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Printer";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_Printer_Ready);
            this.groupBox1.Controls.Add(this.CB_Printer_S2);
            this.groupBox1.Controls.Add(this.CB_Printer_S1);
            this.groupBox1.Location = new System.Drawing.Point(21, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 117);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "狀態";
            // 
            // CB_Printer_Ready
            // 
            this.CB_Printer_Ready.AutoSize = true;
            this.CB_Printer_Ready.Location = new System.Drawing.Point(13, 26);
            this.CB_Printer_Ready.Name = "CB_Printer_Ready";
            this.CB_Printer_Ready.Size = new System.Drawing.Size(72, 20);
            this.CB_Printer_Ready.TabIndex = 2;
            this.CB_Printer_Ready.Text = "Ready";
            this.CB_Printer_Ready.UseVisualStyleBackColor = true;
            // 
            // CB_Printer_S2
            // 
            this.CB_Printer_S2.AutoSize = true;
            this.CB_Printer_S2.Location = new System.Drawing.Point(13, 80);
            this.CB_Printer_S2.Name = "CB_Printer_S2";
            this.CB_Printer_S2.Size = new System.Drawing.Size(61, 20);
            this.CB_Printer_S2.TabIndex = 1;
            this.CB_Printer_S2.Text = "暫停";
            this.CB_Printer_S2.UseVisualStyleBackColor = true;
            this.CB_Printer_S2.CheckedChanged += new System.EventHandler(this.CB_Printer_S2_CheckedChanged);
            // 
            // CB_Printer_S1
            // 
            this.CB_Printer_S1.AutoSize = true;
            this.CB_Printer_S1.Location = new System.Drawing.Point(13, 54);
            this.CB_Printer_S1.Name = "CB_Printer_S1";
            this.CB_Printer_S1.Size = new System.Drawing.Size(95, 20);
            this.CB_Printer_S1.TabIndex = 0;
            this.CB_Printer_S1.Text = "無標籤紙";
            this.CB_Printer_S1.UseVisualStyleBackColor = true;
            this.CB_Printer_S1.CheckedChanged += new System.EventHandler(this.CB_Printer_S1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 58);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Light_Setting
            // 
            this.Light_Setting.Controls.Add(this.B_ALL_Close);
            this.Light_Setting.Controls.Add(this.B_ALL_Open);
            this.Light_Setting.Controls.Add(this.panel10);
            this.Light_Setting.Controls.Add(this.label21);
            this.Light_Setting.Controls.Add(this.CB_Light_Box);
            this.Light_Setting.Location = new System.Drawing.Point(4, 26);
            this.Light_Setting.Name = "Light_Setting";
            this.Light_Setting.Padding = new System.Windows.Forms.Padding(3);
            this.Light_Setting.Size = new System.Drawing.Size(781, 489);
            this.Light_Setting.TabIndex = 6;
            this.Light_Setting.Text = "光源設定";
            this.Light_Setting.UseVisualStyleBackColor = true;
            this.Light_Setting.Click += new System.EventHandler(this.Light_Setting_Click);
            // 
            // B_ALL_Close
            // 
            this.B_ALL_Close.BackColor = System.Drawing.Color.Red;
            this.B_ALL_Close.Location = new System.Drawing.Point(185, 351);
            this.B_ALL_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.B_ALL_Close.Name = "B_ALL_Close";
            this.B_ALL_Close.Size = new System.Drawing.Size(120, 56);
            this.B_ALL_Close.TabIndex = 36;
            this.B_ALL_Close.Text = "光源\r\n全關";
            this.B_ALL_Close.UseVisualStyleBackColor = false;
            this.B_ALL_Close.Click += new System.EventHandler(this.B_ALL_Close_Click);
            // 
            // B_ALL_Open
            // 
            this.B_ALL_Open.BackColor = System.Drawing.Color.Lime;
            this.B_ALL_Open.Location = new System.Drawing.Point(10, 351);
            this.B_ALL_Open.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.B_ALL_Open.Name = "B_ALL_Open";
            this.B_ALL_Open.Size = new System.Drawing.Size(120, 56);
            this.B_ALL_Open.TabIndex = 31;
            this.B_ALL_Open.Text = "光源\r\n全開";
            this.B_ALL_Open.UseVisualStyleBackColor = false;
            this.B_ALL_Open.Click += new System.EventHandler(this.B_ALL_Open_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Peru;
            this.panel10.Controls.Add(this.tFrame_Set_Light4);
            this.panel10.Controls.Add(this.tFrame_Set_Light3);
            this.panel10.Controls.Add(this.tFrame_Set_Light2);
            this.panel10.Controls.Add(this.tFrame_Set_Light1);
            this.panel10.Location = new System.Drawing.Point(10, 44);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(295, 302);
            this.panel10.TabIndex = 35;
            // 
            // tFrame_Set_Light4
            // 
            this.tFrame_Set_Light4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light4.Light_Value = 0;
            this.tFrame_Set_Light4.Location = new System.Drawing.Point(26, 224);
            this.tFrame_Set_Light4.Margin = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.tFrame_Set_Light4.Name = "tFrame_Set_Light4";
            this.tFrame_Set_Light4.Size = new System.Drawing.Size(260, 55);
            this.tFrame_Set_Light4.TabIndex = 3;
            // 
            // tFrame_Set_Light3
            // 
            this.tFrame_Set_Light3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light3.Light_Value = 0;
            this.tFrame_Set_Light3.Location = new System.Drawing.Point(26, 154);
            this.tFrame_Set_Light3.Margin = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.tFrame_Set_Light3.Name = "tFrame_Set_Light3";
            this.tFrame_Set_Light3.Size = new System.Drawing.Size(260, 55);
            this.tFrame_Set_Light3.TabIndex = 2;
            // 
            // tFrame_Set_Light2
            // 
            this.tFrame_Set_Light2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light2.Light_Value = 0;
            this.tFrame_Set_Light2.Location = new System.Drawing.Point(26, 84);
            this.tFrame_Set_Light2.Margin = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.tFrame_Set_Light2.Name = "tFrame_Set_Light2";
            this.tFrame_Set_Light2.Size = new System.Drawing.Size(260, 55);
            this.tFrame_Set_Light2.TabIndex = 1;
            // 
            // tFrame_Set_Light1
            // 
            this.tFrame_Set_Light1.AutoSize = true;
            this.tFrame_Set_Light1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light1.Light_Value = 0;
            this.tFrame_Set_Light1.Location = new System.Drawing.Point(26, 14);
            this.tFrame_Set_Light1.Margin = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.tFrame_Set_Light1.Name = "tFrame_Set_Light1";
            this.tFrame_Set_Light1.Size = new System.Drawing.Size(260, 60);
            this.tFrame_Set_Light1.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 18);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 16);
            this.label21.TabIndex = 34;
            this.label21.Text = "調光器";
            // 
            // CB_Light_Box
            // 
            this.CB_Light_Box.FormattingEnabled = true;
            this.CB_Light_Box.Items.AddRange(new object[] {
            "1"});
            this.CB_Light_Box.Location = new System.Drawing.Point(95, 15);
            this.CB_Light_Box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_Light_Box.Name = "CB_Light_Box";
            this.CB_Light_Box.Size = new System.Drawing.Size(67, 24);
            this.CB_Light_Box.TabIndex = 33;
            this.CB_Light_Box.Text = "1";
            this.CB_Light_Box.SelectedIndexChanged += new System.EventHandler(this.CB_Light_Box_SelectedIndexChanged);
            // 
            // TP_Log
            // 
            this.TP_Log.Controls.Add(this.tabControl2);
            this.TP_Log.Location = new System.Drawing.Point(4, 26);
            this.TP_Log.Name = "TP_Log";
            this.TP_Log.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Log.Size = new System.Drawing.Size(1301, 525);
            this.TP_Log.TabIndex = 1;
            this.TP_Log.Text = "歷史紀錄";
            this.TP_Log.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1295, 519);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.DG_Log);
            this.tabPage7.Controls.Add(this.panel14);
            this.tabPage7.Location = new System.Drawing.Point(4, 26);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1287, 489);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Log";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // DG_Log
            // 
            this.DG_Log.AllowDrop = true;
            this.DG_Log.AllowUserToAddRows = false;
            this.DG_Log.AllowUserToDeleteRows = false;
            this.DG_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column6});
            this.DG_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Log.Location = new System.Drawing.Point(3, 46);
            this.DG_Log.MultiSelect = false;
            this.DG_Log.Name = "DG_Log";
            this.DG_Log.RowTemplate.Height = 24;
            this.DG_Log.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_Log.Size = new System.Drawing.Size(1281, 440);
            this.DG_Log.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Time";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "種類";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "來源";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "功能";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "訊息";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 800;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.B_Log_Sort);
            this.panel14.Controls.Add(this.B_Log_Reset);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(3, 3);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1281, 43);
            this.panel14.TabIndex = 5;
            // 
            // B_Log_Sort
            // 
            this.B_Log_Sort.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Log_Sort.Location = new System.Drawing.Point(112, 0);
            this.B_Log_Sort.Name = "B_Log_Sort";
            this.B_Log_Sort.Size = new System.Drawing.Size(112, 43);
            this.B_Log_Sort.TabIndex = 8;
            this.B_Log_Sort.Text = "Sort";
            this.B_Log_Sort.UseVisualStyleBackColor = true;
            this.B_Log_Sort.Click += new System.EventHandler(this.B_Log_Sort_Click);
            // 
            // B_Log_Reset
            // 
            this.B_Log_Reset.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Log_Reset.Location = new System.Drawing.Point(0, 0);
            this.B_Log_Reset.Name = "B_Log_Reset";
            this.B_Log_Reset.Size = new System.Drawing.Size(112, 43);
            this.B_Log_Reset.TabIndex = 7;
            this.B_Log_Reset.Text = "Reset";
            this.B_Log_Reset.UseVisualStyleBackColor = true;
            this.B_Log_Reset.Click += new System.EventHandler(this.B_Log_Reset_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "hard_drive_download.bmp");
            this.imageList1.Images.SetKeyName(1, "hard_drive_upload.bmp");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.P_Printer);
            this.panel2.Controls.Add(this.P_Casette_Reader);
            this.panel2.Controls.Add(this.P_PLC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 676);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1309, 66);
            this.panel2.TabIndex = 26;
            // 
            // P_Printer
            // 
            this.P_Printer.BackColor = System.Drawing.Color.Silver;
            this.P_Printer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P_Printer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.P_Printer.Controls.Add(this.textBox5);
            this.P_Printer.Controls.Add(this.B_Printer);
            this.P_Printer.Dock = System.Windows.Forms.DockStyle.Left;
            this.P_Printer.ForeColor = System.Drawing.Color.LawnGreen;
            this.P_Printer.Location = new System.Drawing.Point(280, 0);
            this.P_Printer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.P_Printer.Name = "P_Printer";
            this.P_Printer.Size = new System.Drawing.Size(140, 66);
            this.P_Printer.TabIndex = 26;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Silver;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(73, 21);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(51, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "Printer";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // B_Printer
            // 
            this.B_Printer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Printer.BackgroundImage")));
            this.B_Printer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Printer.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Printer.Location = new System.Drawing.Point(0, 0);
            this.B_Printer.Margin = new System.Windows.Forms.Padding(2);
            this.B_Printer.Name = "B_Printer";
            this.B_Printer.Size = new System.Drawing.Size(64, 62);
            this.B_Printer.TabIndex = 3;
            this.B_Printer.UseVisualStyleBackColor = true;
            // 
            // P_Casette_Reader
            // 
            this.P_Casette_Reader.BackColor = System.Drawing.Color.Silver;
            this.P_Casette_Reader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P_Casette_Reader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.P_Casette_Reader.Controls.Add(this.textBox4);
            this.P_Casette_Reader.Controls.Add(this.textBox2);
            this.P_Casette_Reader.Controls.Add(this.B_Casette_Reader);
            this.P_Casette_Reader.Dock = System.Windows.Forms.DockStyle.Left;
            this.P_Casette_Reader.ForeColor = System.Drawing.Color.LawnGreen;
            this.P_Casette_Reader.Location = new System.Drawing.Point(140, 0);
            this.P_Casette_Reader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.P_Casette_Reader.Name = "P_Casette_Reader";
            this.P_Casette_Reader.Size = new System.Drawing.Size(140, 66);
            this.P_Casette_Reader.TabIndex = 25;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Silver;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(69, 16);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(51, 20);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "Casette";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Silver;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(69, 33);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Reader";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // B_Casette_Reader
            // 
            this.B_Casette_Reader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Casette_Reader.BackgroundImage")));
            this.B_Casette_Reader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Casette_Reader.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Casette_Reader.Location = new System.Drawing.Point(0, 0);
            this.B_Casette_Reader.Margin = new System.Windows.Forms.Padding(2);
            this.B_Casette_Reader.Name = "B_Casette_Reader";
            this.B_Casette_Reader.Size = new System.Drawing.Size(64, 62);
            this.B_Casette_Reader.TabIndex = 3;
            this.B_Casette_Reader.UseVisualStyleBackColor = true;
            // 
            // P_PLC
            // 
            this.P_PLC.BackColor = System.Drawing.Color.Silver;
            this.P_PLC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P_PLC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.P_PLC.Controls.Add(this.E_PLC_Time);
            this.P_PLC.Controls.Add(this.B_PLC);
            this.P_PLC.Controls.Add(this.L_PLC_Text);
            this.P_PLC.Dock = System.Windows.Forms.DockStyle.Left;
            this.P_PLC.ForeColor = System.Drawing.Color.LawnGreen;
            this.P_PLC.Location = new System.Drawing.Point(0, 0);
            this.P_PLC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.P_PLC.Name = "P_PLC";
            this.P_PLC.Size = new System.Drawing.Size(140, 66);
            this.P_PLC.TabIndex = 18;
            // 
            // E_PLC_Time
            // 
            this.E_PLC_Time.BackColor = System.Drawing.Color.Silver;
            this.E_PLC_Time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.E_PLC_Time.Enabled = false;
            this.E_PLC_Time.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.E_PLC_Time.Location = new System.Drawing.Point(69, 44);
            this.E_PLC_Time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.E_PLC_Time.Name = "E_PLC_Time";
            this.E_PLC_Time.Size = new System.Drawing.Size(51, 20);
            this.E_PLC_Time.TabIndex = 7;
            this.E_PLC_Time.Text = "0";
            this.E_PLC_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // B_PLC
            // 
            this.B_PLC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_PLC.BackgroundImage")));
            this.B_PLC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_PLC.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_PLC.Location = new System.Drawing.Point(0, 0);
            this.B_PLC.Margin = new System.Windows.Forms.Padding(2);
            this.B_PLC.Name = "B_PLC";
            this.B_PLC.Size = new System.Drawing.Size(64, 62);
            this.B_PLC.TabIndex = 3;
            this.B_PLC.UseVisualStyleBackColor = true;
            // 
            // L_PLC_Text
            // 
            this.L_PLC_Text.AutoSize = true;
            this.L_PLC_Text.BackColor = System.Drawing.Color.Transparent;
            this.L_PLC_Text.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_PLC_Text.ForeColor = System.Drawing.Color.Black;
            this.L_PLC_Text.Location = new System.Drawing.Point(75, 13);
            this.L_PLC_Text.Name = "L_PLC_Text";
            this.L_PLC_Text.Size = new System.Drawing.Size(38, 23);
            this.L_PLC_Text.TabIndex = 0;
            this.L_PLC_Text.Text = "PLC";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Peru;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.E_User_Level);
            this.panel3.Controls.Add(this.E_User_Name);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.E_Recipe_Info);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.E_Recipe_ID);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(830, 81);
            this.panel3.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(749, 10);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 22);
            this.label10.TabIndex = 8;
            this.label10.Text = "LV:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(595, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 22);
            this.label9.TabIndex = 7;
            this.label9.Text = "使用者:";
            // 
            // E_User_Level
            // 
            this.E_User_Level.BackColor = System.Drawing.Color.Gray;
            this.E_User_Level.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_User_Level.ForeColor = System.Drawing.Color.White;
            this.E_User_Level.Location = new System.Drawing.Point(753, 36);
            this.E_User_Level.Margin = new System.Windows.Forms.Padding(2);
            this.E_User_Level.Name = "E_User_Level";
            this.E_User_Level.Size = new System.Drawing.Size(43, 33);
            this.E_User_Level.TabIndex = 6;
            this.E_User_Level.Text = "0";
            // 
            // E_User_Name
            // 
            this.E_User_Name.BackColor = System.Drawing.Color.Gray;
            this.E_User_Name.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_User_Name.ForeColor = System.Drawing.Color.White;
            this.E_User_Name.Location = new System.Drawing.Point(599, 36);
            this.E_User_Name.Margin = new System.Windows.Forms.Padding(2);
            this.E_User_Name.Name = "E_User_Name";
            this.E_User_Name.Size = new System.Drawing.Size(146, 33);
            this.E_User_Name.TabIndex = 5;
            this.E_User_Name.Text = "User_Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(270, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "說明:";
            // 
            // E_Recipe_Info
            // 
            this.E_Recipe_Info.BackColor = System.Drawing.Color.Gray;
            this.E_Recipe_Info.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_Info.ForeColor = System.Drawing.Color.White;
            this.E_Recipe_Info.Location = new System.Drawing.Point(274, 36);
            this.E_Recipe_Info.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_Info.Name = "E_Recipe_Info";
            this.E_Recipe_Info.Size = new System.Drawing.Size(304, 33);
            this.E_Recipe_Info.TabIndex = 3;
            this.E_Recipe_Info.Text = "Recipe_Info";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(250, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 27);
            this.label6.TabIndex = 2;
            this.label6.Text = "/";
            // 
            // E_Recipe_ID
            // 
            this.E_Recipe_ID.BackColor = System.Drawing.Color.Gray;
            this.E_Recipe_ID.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_ID.ForeColor = System.Drawing.Color.White;
            this.E_Recipe_ID.Location = new System.Drawing.Point(13, 36);
            this.E_Recipe_ID.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_ID.Name = "E_Recipe_ID";
            this.E_Recipe_ID.Size = new System.Drawing.Size(233, 33);
            this.E_Recipe_ID.TabIndex = 1;
            this.E_Recipe_ID.Text = "Recipe_Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(9, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "生產參數名稱:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1309, 81);
            this.panel4.TabIndex = 29;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // TForm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 742);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TForm_Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TForm_Main_FormClosed);
            this.Shown += new System.EventHandler(this.TForm_Main_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Main.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Value)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picResultImage)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Light_Setting.ResumeLayout(false);
            this.Light_Setting.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.TP_Log.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Log)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.P_Printer.ResumeLayout(false);
            this.P_Printer.PerformLayout();
            this.P_Casette_Reader.ResumeLayout(false);
            this.P_Casette_Reader.PerformLayout();
            this.P_PLC.ResumeLayout(false);
            this.P_PLC.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.MenuStrip menuStrip1;
          private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
          private System.Windows.Forms.ToolStripMenuItem TSM_File;
          private System.Windows.Forms.ToolStripMenuItem MI_Close;
          private System.Windows.Forms.ToolStripMenuItem TSM_Recipe;
          private System.Windows.Forms.ToolStripMenuItem MI_Recipe;
          private System.Windows.Forms.ToolStripMenuItem MI_Environment;
          private System.Windows.Forms.ToolStripMenuItem MI_Info;
          private System.Windows.Forms.ToolStripMenuItem TSM_Communication;
          private System.Windows.Forms.ToolStripMenuItem MI_ViewData_In;
          private System.Windows.Forms.ToolStripMenuItem MI_ViewData_Out;
          private System.Windows.Forms.ToolStripMenuItem MI_ViewData_Recipe;
          private System.Windows.Forms.ToolStripMenuItem MI_Login;
          private System.Windows.Forms.ToolStripMenuItem MI_Logout;
          private System.Windows.Forms.Timer timer1;
          private System.Windows.Forms.Panel panel1;
          private System.Windows.Forms.TabControl tabControl1;
          private System.Windows.Forms.TabPage TP_Main;
          private System.Windows.Forms.TabPage TP_Log;
          private System.Windows.Forms.Panel panel2;
          private System.Windows.Forms.Panel P_PLC;
          private System.Windows.Forms.TextBox E_PLC_Time;
          private System.Windows.Forms.Button B_PLC;
          private System.Windows.Forms.Label L_PLC_Text;
          private System.Windows.Forms.Panel panel3;
          private System.Windows.Forms.Label label10;
          private System.Windows.Forms.Label label9;
          private System.Windows.Forms.TextBox E_User_Level;
          private System.Windows.Forms.TextBox E_User_Name;
          private System.Windows.Forms.Label label5;
          private System.Windows.Forms.TextBox E_Recipe_Info;
          private System.Windows.Forms.Label label6;
          private System.Windows.Forms.TextBox E_Recipe_ID;
          private System.Windows.Forms.Label label7;
          private System.Windows.Forms.OpenFileDialog openFileDialog1;
          private System.Windows.Forms.SaveFileDialog saveFileDialog1;
          private System.Windows.Forms.Panel panel4;
          private System.Windows.Forms.ImageList imageList1;
          private System.Windows.Forms.TabControl tabControl3;
          private System.Windows.Forms.TabPage tabPage1;
          private System.Windows.Forms.TabPage tabPage2;
          private System.Windows.Forms.TabPage tabPage3;
          private System.Windows.Forms.DataGridView DG_Value;
          private System.Windows.Forms.TextBox E_Print_Format;
          private System.Windows.Forms.TextBox E_Out_Print_Format;
          private System.Windows.Forms.Panel panel5;
          private System.Windows.Forms.Button button2;
          private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.GroupBox groupBox1;
          private System.Windows.Forms.CheckBox CB_Printer_S1;
          private System.Windows.Forms.CheckBox CB_Printer_S2;
          private System.Windows.Forms.Button button5;
          private System.Windows.Forms.Button button6;
          private System.Windows.Forms.Button B_P_Read_Code;
          private System.Windows.Forms.TabPage tabPage4;
          private System.Windows.Forms.TextBox E_P_Reader_Code;
          private System.Windows.Forms.TabPage tabPage5;
          private System.Windows.Forms.PictureBox picResultImage;
          private System.Windows.Forms.Panel panel6;
          private System.Windows.Forms.Timer timer2;
          private System.Windows.Forms.Panel panel7;
          private System.Windows.Forms.CheckBox CB_Printer_Ready;
          private System.Windows.Forms.TabPage tabPage6;
          private System.Windows.Forms.Panel panel8;
          private System.Windows.Forms.TextBox E_C_Reader_Code;
          private System.Windows.Forms.Button B_C_Read_Code;
          private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
          private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
          private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
          private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
          private System.Windows.Forms.Panel P_Printer;
          private System.Windows.Forms.TextBox textBox5;
          private System.Windows.Forms.Button B_Printer;
          private System.Windows.Forms.Panel P_Casette_Reader;
          private System.Windows.Forms.TextBox textBox4;
          private System.Windows.Forms.TextBox textBox2;
          private System.Windows.Forms.Button B_Casette_Reader;
          private System.Windows.Forms.TabControl tabControl2;
          private System.Windows.Forms.TabPage tabPage7;
          private System.Windows.Forms.DataGridView DG_Log;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
          private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
          private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
          private System.Windows.Forms.Panel panel14;
          private System.Windows.Forms.Button B_Log_Sort;
          private System.Windows.Forms.Button B_Log_Reset;
          private System.Windows.Forms.TabPage Light_Setting;
          private System.Windows.Forms.Button B_ALL_Close;
          private System.Windows.Forms.Button B_ALL_Open;
          private System.Windows.Forms.Panel panel10;
          private EFC.Light.TFrame_Set_Light tFrame_Set_Light4;
          private EFC.Light.TFrame_Set_Light tFrame_Set_Light3;
          private EFC.Light.TFrame_Set_Light tFrame_Set_Light2;
          private EFC.Light.TFrame_Set_Light tFrame_Set_Light1;
          private System.Windows.Forms.Label label21;
          private System.Windows.Forms.ComboBox CB_Light_Box;
     }
}

