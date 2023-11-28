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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Select_Recipe));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.外觀尺寸");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2.Big對位參數");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("3.Small對位參數");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("4.補償");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("5.修正量限制");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("1.Panel參數", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("1.標籤格式1");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("2.標籤格式2");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("3.變數");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("2.標籤機", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("3.Box_Load");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("4.機械參數");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Tool_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PM_Used = new System.Windows.Forms.ToolStripMenuItem();
            this.PM_Golden = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TV_Menu = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.B_Update_Tree = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TP_Panel_Size = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.E_Panel_Z = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.E_Panel_Y = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.E_Panel_X = new System.Windows.Forms.TextBox();
            this.TP_Panel_Align = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.CB_Panel_Length_SW = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.E_Panel_Length_Max = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.E_Panel_Length_Min = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.B_Pre_Process_Edit_L = new System.Windows.Forms.Button();
            this.CB_Pre_Process_L_SW = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.E_Panel_L_Y = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.E_Panel_L_X = new System.Windows.Forms.TextBox();
            this.B_Panel_L_Set_Light = new System.Windows.Forms.Button();
            this.B_Panel_L_Edit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B_Pre_Process_Edit_R = new System.Windows.Forms.Button();
            this.CB_Pre_Process_R_SW = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.E_Panel_R_Y = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.E_Panel_R_X = new System.Windows.Forms.TextBox();
            this.B_Panel_R_Set_Light = new System.Windows.Forms.Button();
            this.B_Panel_R_Edit = new System.Windows.Forms.Button();
            this.TP_Ofs = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.E_Ofs_Q = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.E_Ofs_Y = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.E_Ofs_X = new System.Windows.Forms.TextBox();
            this.TP_Limit_Ofs = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CB_Limit_Ofs_DQ_SW = new System.Windows.Forms.CheckBox();
            this.E_Limit_Ofs_DQ_Max = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.E_Limit_Ofs_DQ_Min = new System.Windows.Forms.TextBox();
            this.CB_Limit_Ofs_DY_SW = new System.Windows.Forms.CheckBox();
            this.E_Limit_Ofs_DY_Max = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.E_Limit_Ofs_DY_Min = new System.Windows.Forms.TextBox();
            this.CB_Limit_Ofs_DX_SW = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.E_Limit_Ofs_DX_Max = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.E_Limit_Ofs_DX_Min = new System.Windows.Forms.TextBox();
            this.TP_Printer = new System.Windows.Forms.TabPage();
            this.E_Printer_Tear_Off = new System.Windows.Forms.TextBox();
            this.SB_Printer_Tear_Off = new System.Windows.Forms.HScrollBar();
            this.B_Printer_Tear_off = new System.Windows.Forms.Button();
            this.TP_Printer_Value = new System.Windows.Forms.TabPage();
            this.DG_Value = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.B_Printer_Value_Clear = new System.Windows.Forms.Button();
            this.B_Printer_Value_Add = new System.Windows.Forms.Button();
            this.B_Printer_Value_Move_Dn = new System.Windows.Forms.Button();
            this.B_Printer_Value_Delete = new System.Windows.Forms.Button();
            this.B_Printer_Value_Move_Up = new System.Windows.Forms.Button();
            this.TP_Printe_Format = new System.Windows.Forms.TabPage();
            this.E_Print_Format_List = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.B_Printer_Inport_File = new System.Windows.Forms.Button();
            this.TP_Box_Load = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CB_Supply_Vacc = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.E_Box_Load_Y_Num = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.E_Box_Load_Z = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.E_Box_Load_Y = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.E_Box_Load_X_Num = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.E_Box_Load_X = new System.Windows.Forms.TextBox();
            this.TP_MS_Param = new System.Windows.Forms.TabPage();
            this.B_Edit_MS_Param = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.E_Recipe_Code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tFrame_JJS_HW2 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Panel_Size.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TP_Panel_Align.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TP_Ofs.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.TP_Limit_Ofs.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.TP_Printer.SuspendLayout();
            this.TP_Printer_Value.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Value)).BeginInit();
            this.panel6.SuspendLayout();
            this.TP_Printe_Format.SuspendLayout();
            this.panel7.SuspendLayout();
            this.TP_Box_Load.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.TP_MS_Param.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "019.bmp");
            this.imageList1.Images.SetKeyName(1, "No-02.bmp");
            this.imageList1.Images.SetKeyName(2, "Yes-01.bmp");
            // 
            // Tool_ImageList
            // 
            this.Tool_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Tool_ImageList.ImageStream")));
            this.Tool_ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.Tool_ImageList.Images.SetKeyName(0, "magic_wand.bmp");
            this.Tool_ImageList.Images.SetKeyName(1, "button_cross.bmp");
            this.Tool_ImageList.Images.SetKeyName(2, "hard_drive_download.bmp");
            this.Tool_ImageList.Images.SetKeyName(3, "hard_drive_upload.bmp");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PM_Used,
            this.PM_Golden});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 48);
            // 
            // PM_Used
            // 
            this.PM_Used.Name = "PM_Used";
            this.PM_Used.Size = new System.Drawing.Size(118, 22);
            this.PM_Used.Text = "Used";
            // 
            // PM_Golden
            // 
            this.PM_Golden.Name = "PM_Golden";
            this.PM_Golden.Size = new System.Drawing.Size(118, 22);
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1266, 741);
            this.splitContainer1.SplitterDistance = 1150;
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
            this.splitContainer2.Size = new System.Drawing.Size(1150, 604);
            this.splitContainer2.SplitterDistance = 321;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TV_Menu);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 55);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(321, 549);
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
            treeNode1.Name = "Size";
            treeNode1.Text = "1.外觀尺寸";
            treeNode2.Name = "Big";
            treeNode2.Text = "2.Big對位參數";
            treeNode3.Name = "Small";
            treeNode3.Text = "3.Small對位參數";
            treeNode4.Name = "Ofs";
            treeNode4.Text = "4.補償";
            treeNode5.Name = "Align_Limit";
            treeNode5.Text = "5.修正量限制";
            treeNode6.Name = "Panel";
            treeNode6.Text = "1.Panel參數";
            treeNode7.Name = "Format1";
            treeNode7.Text = "1.標籤格式1";
            treeNode8.Name = "Format2";
            treeNode8.Text = "2.標籤格式2";
            treeNode9.Name = "Value";
            treeNode9.Text = "3.變數";
            treeNode10.Name = "Printer";
            treeNode10.Text = "2.標籤機";
            treeNode11.Name = "Box_Load";
            treeNode11.Text = "3.Box_Load";
            treeNode12.Name = "MS_Param";
            treeNode12.Text = "4.機械參數";
            treeNode13.Name = "Root";
            treeNode13.Text = "Root";
            this.TV_Menu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13});
            this.TV_Menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TV_Menu.SelectedImageIndex = 0;
            this.TV_Menu.ShowNodeToolTips = true;
            this.TV_Menu.Size = new System.Drawing.Size(321, 549);
            this.TV_Menu.TabIndex = 0;
            this.TV_Menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Menu_AfterSelect);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.B_Update_Tree);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 55);
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
            this.tabControl1.Controls.Add(this.TP_Panel_Size);
            this.tabControl1.Controls.Add(this.TP_Panel_Align);
            this.tabControl1.Controls.Add(this.TP_Ofs);
            this.tabControl1.Controls.Add(this.TP_Limit_Ofs);
            this.tabControl1.Controls.Add(this.TP_Printer);
            this.tabControl1.Controls.Add(this.TP_Printer_Value);
            this.tabControl1.Controls.Add(this.TP_Printe_Format);
            this.tabControl1.Controls.Add(this.TP_Box_Load);
            this.tabControl1.Controls.Add(this.TP_MS_Param);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.ItemSize = new System.Drawing.Size(72, 0);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(826, 604);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(818, 576);
            this.tabPage1.TabIndex = 21;
            this.tabPage1.Text = "空白";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TP_Panel_Size
            // 
            this.TP_Panel_Size.Controls.Add(this.groupBox2);
            this.TP_Panel_Size.Location = new System.Drawing.Point(4, 24);
            this.TP_Panel_Size.Name = "TP_Panel_Size";
            this.TP_Panel_Size.Size = new System.Drawing.Size(818, 576);
            this.TP_Panel_Size.TabIndex = 24;
            this.TP_Panel_Size.Text = "Panel尺寸";
            this.TP_Panel_Size.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.E_Panel_Z);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.E_Panel_Y);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.E_Panel_X);
            this.groupBox2.Location = new System.Drawing.Point(16, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 110);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[ 尺寸 ]";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(115, 80);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 14);
            this.label28.TabIndex = 16;
            this.label28.Text = "mm";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 80);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(16, 14);
            this.label29.TabIndex = 15;
            this.label29.Text = "Z";
            // 
            // E_Panel_Z
            // 
            this.E_Panel_Z.Location = new System.Drawing.Point(38, 77);
            this.E_Panel_Z.Name = "E_Panel_Z";
            this.E_Panel_Z.Size = new System.Drawing.Size(71, 24);
            this.E_Panel_Z.TabIndex = 14;
            this.E_Panel_Z.Text = "123.456";
            this.E_Panel_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(115, 50);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 14);
            this.label30.TabIndex = 13;
            this.label30.Text = "mm";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 50);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 14);
            this.label31.TabIndex = 11;
            this.label31.Text = "Y";
            // 
            // E_Panel_Y
            // 
            this.E_Panel_Y.Location = new System.Drawing.Point(38, 47);
            this.E_Panel_Y.Name = "E_Panel_Y";
            this.E_Panel_Y.Size = new System.Drawing.Size(71, 24);
            this.E_Panel_Y.TabIndex = 10;
            this.E_Panel_Y.Text = "123.456";
            this.E_Panel_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(115, 20);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 14);
            this.label32.TabIndex = 9;
            this.label32.Text = "mm";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 20);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(17, 14);
            this.label33.TabIndex = 1;
            this.label33.Text = "X";
            // 
            // E_Panel_X
            // 
            this.E_Panel_X.Location = new System.Drawing.Point(38, 17);
            this.E_Panel_X.Name = "E_Panel_X";
            this.E_Panel_X.Size = new System.Drawing.Size(71, 24);
            this.E_Panel_X.TabIndex = 0;
            this.E_Panel_X.Text = "123.456";
            this.E_Panel_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TP_Panel_Align
            // 
            this.TP_Panel_Align.Controls.Add(this.groupBox7);
            this.TP_Panel_Align.Controls.Add(this.groupBox4);
            this.TP_Panel_Align.Controls.Add(this.groupBox1);
            this.TP_Panel_Align.Location = new System.Drawing.Point(4, 24);
            this.TP_Panel_Align.Name = "TP_Panel_Align";
            this.TP_Panel_Align.Size = new System.Drawing.Size(818, 576);
            this.TP_Panel_Align.TabIndex = 27;
            this.TP_Panel_Align.Text = "Panel對位參數";
            this.TP_Panel_Align.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.CB_Panel_Length_SW);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.E_Panel_Length_Max);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.E_Panel_Length_Min);
            this.groupBox7.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox7.Location = new System.Drawing.Point(12, 322);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(246, 73);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "[ Panel 尺寸限制 ]";
            // 
            // CB_Panel_Length_SW
            // 
            this.CB_Panel_Length_SW.AutoSize = true;
            this.CB_Panel_Length_SW.Location = new System.Drawing.Point(162, 0);
            this.CB_Panel_Length_SW.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Panel_Length_SW.Name = "CB_Panel_Length_SW";
            this.CB_Panel_Length_SW.Size = new System.Drawing.Size(78, 18);
            this.CB_Panel_Length_SW.TabIndex = 31;
            this.CB_Panel_Length_SW.Text = "Enabled";
            this.CB_Panel_Length_SW.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(183, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 8;
            this.label11.Text = "Max";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 14);
            this.label12.TabIndex = 7;
            this.label12.Text = "Min";
            // 
            // E_Panel_Length_Max
            // 
            this.E_Panel_Length_Max.Location = new System.Drawing.Point(162, 37);
            this.E_Panel_Length_Max.Name = "E_Panel_Length_Max";
            this.E_Panel_Length_Max.Size = new System.Drawing.Size(71, 24);
            this.E_Panel_Length_Max.TabIndex = 6;
            this.E_Panel_Length_Max.Text = "123.456";
            this.E_Panel_Length_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(86, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(79, 14);
            this.label26.TabIndex = 1;
            this.label26.Text = "<= 長度 <=";
            // 
            // E_Panel_Length_Min
            // 
            this.E_Panel_Length_Min.Location = new System.Drawing.Point(14, 37);
            this.E_Panel_Length_Min.Name = "E_Panel_Length_Min";
            this.E_Panel_Length_Min.Size = new System.Drawing.Size(71, 24);
            this.E_Panel_Length_Min.TabIndex = 0;
            this.E_Panel_Length_Min.Text = "123.456";
            this.E_Panel_Length_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.B_Pre_Process_Edit_L);
            this.groupBox4.Controls.Add(this.CB_Pre_Process_L_SW);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.E_Panel_L_Y);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.E_Panel_L_X);
            this.groupBox4.Controls.Add(this.B_Panel_L_Set_Light);
            this.groupBox4.Controls.Add(this.B_Panel_L_Edit);
            this.groupBox4.Location = new System.Drawing.Point(12, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(172, 266);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[ L Model ]";
            // 
            // B_Pre_Process_Edit_L
            // 
            this.B_Pre_Process_Edit_L.Location = new System.Drawing.Point(21, 209);
            this.B_Pre_Process_Edit_L.Name = "B_Pre_Process_Edit_L";
            this.B_Pre_Process_Edit_L.Size = new System.Drawing.Size(133, 45);
            this.B_Pre_Process_Edit_L.TabIndex = 32;
            this.B_Pre_Process_Edit_L.Text = "編輯參數";
            this.B_Pre_Process_Edit_L.UseVisualStyleBackColor = true;
            this.B_Pre_Process_Edit_L.Click += new System.EventHandler(this.B_Pre_Process_Edit_L_Click);
            // 
            // CB_Pre_Process_L_SW
            // 
            this.CB_Pre_Process_L_SW.AutoSize = true;
            this.CB_Pre_Process_L_SW.Location = new System.Drawing.Point(21, 185);
            this.CB_Pre_Process_L_SW.Name = "CB_Pre_Process_L_SW";
            this.CB_Pre_Process_L_SW.Size = new System.Drawing.Size(101, 18);
            this.CB_Pre_Process_L_SW.TabIndex = 33;
            this.CB_Pre_Process_L_SW.Text = "影像前處理";
            this.CB_Pre_Process_L_SW.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(115, 56);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 14);
            this.label34.TabIndex = 19;
            this.label34.Text = "mm";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 56);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(17, 14);
            this.label35.TabIndex = 18;
            this.label35.Text = "Y";
            // 
            // E_Panel_L_Y
            // 
            this.E_Panel_L_Y.Location = new System.Drawing.Point(38, 53);
            this.E_Panel_L_Y.Name = "E_Panel_L_Y";
            this.E_Panel_L_Y.Size = new System.Drawing.Size(71, 24);
            this.E_Panel_L_Y.TabIndex = 17;
            this.E_Panel_L_Y.Text = "123.456";
            this.E_Panel_L_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(115, 26);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 14);
            this.label36.TabIndex = 16;
            this.label36.Text = "mm";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 26);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(17, 14);
            this.label37.TabIndex = 15;
            this.label37.Text = "X";
            // 
            // E_Panel_L_X
            // 
            this.E_Panel_L_X.Location = new System.Drawing.Point(38, 23);
            this.E_Panel_L_X.Name = "E_Panel_L_X";
            this.E_Panel_L_X.Size = new System.Drawing.Size(71, 24);
            this.E_Panel_L_X.TabIndex = 14;
            this.E_Panel_L_X.Text = "123.456";
            this.E_Panel_L_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // B_Panel_L_Set_Light
            // 
            this.B_Panel_L_Set_Light.Location = new System.Drawing.Point(21, 134);
            this.B_Panel_L_Set_Light.Name = "B_Panel_L_Set_Light";
            this.B_Panel_L_Set_Light.Size = new System.Drawing.Size(133, 45);
            this.B_Panel_L_Set_Light.TabIndex = 1;
            this.B_Panel_L_Set_Light.Text = "設定光源";
            this.B_Panel_L_Set_Light.UseVisualStyleBackColor = true;
            this.B_Panel_L_Set_Light.Click += new System.EventHandler(this.B_Panel_L_Set_Light_Click);
            // 
            // B_Panel_L_Edit
            // 
            this.B_Panel_L_Edit.Location = new System.Drawing.Point(21, 83);
            this.B_Panel_L_Edit.Name = "B_Panel_L_Edit";
            this.B_Panel_L_Edit.Size = new System.Drawing.Size(133, 45);
            this.B_Panel_L_Edit.TabIndex = 0;
            this.B_Panel_L_Edit.Text = "編輯參數";
            this.B_Panel_L_Edit.UseVisualStyleBackColor = true;
            this.B_Panel_L_Edit.Click += new System.EventHandler(this.B_Panel_L_Edit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.B_Pre_Process_Edit_R);
            this.groupBox1.Controls.Add(this.CB_Pre_Process_R_SW);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.E_Panel_R_Y);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.E_Panel_R_X);
            this.groupBox1.Controls.Add(this.B_Panel_R_Set_Light);
            this.groupBox1.Controls.Add(this.B_Panel_R_Edit);
            this.groupBox1.Location = new System.Drawing.Point(198, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 266);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ R Model ]";
            // 
            // B_Pre_Process_Edit_R
            // 
            this.B_Pre_Process_Edit_R.Location = new System.Drawing.Point(21, 209);
            this.B_Pre_Process_Edit_R.Name = "B_Pre_Process_Edit_R";
            this.B_Pre_Process_Edit_R.Size = new System.Drawing.Size(133, 45);
            this.B_Pre_Process_Edit_R.TabIndex = 34;
            this.B_Pre_Process_Edit_R.Text = "編輯參數";
            this.B_Pre_Process_Edit_R.UseVisualStyleBackColor = true;
            this.B_Pre_Process_Edit_R.Click += new System.EventHandler(this.B_Pre_Process_Edit_R_Click);
            // 
            // CB_Pre_Process_R_SW
            // 
            this.CB_Pre_Process_R_SW.AutoSize = true;
            this.CB_Pre_Process_R_SW.Location = new System.Drawing.Point(21, 185);
            this.CB_Pre_Process_R_SW.Name = "CB_Pre_Process_R_SW";
            this.CB_Pre_Process_R_SW.Size = new System.Drawing.Size(101, 18);
            this.CB_Pre_Process_R_SW.TabIndex = 35;
            this.CB_Pre_Process_R_SW.Text = "影像前處理";
            this.CB_Pre_Process_R_SW.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(115, 56);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 14);
            this.label20.TabIndex = 25;
            this.label20.Text = "mm";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 14);
            this.label21.TabIndex = 24;
            this.label21.Text = "Y";
            // 
            // E_Panel_R_Y
            // 
            this.E_Panel_R_Y.Location = new System.Drawing.Point(38, 53);
            this.E_Panel_R_Y.Name = "E_Panel_R_Y";
            this.E_Panel_R_Y.Size = new System.Drawing.Size(71, 24);
            this.E_Panel_R_Y.TabIndex = 23;
            this.E_Panel_R_Y.Text = "123.456";
            this.E_Panel_R_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(115, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 14);
            this.label22.TabIndex = 22;
            this.label22.Text = "mm";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 14);
            this.label23.TabIndex = 21;
            this.label23.Text = "X";
            // 
            // E_Panel_R_X
            // 
            this.E_Panel_R_X.Location = new System.Drawing.Point(38, 23);
            this.E_Panel_R_X.Name = "E_Panel_R_X";
            this.E_Panel_R_X.Size = new System.Drawing.Size(71, 24);
            this.E_Panel_R_X.TabIndex = 20;
            this.E_Panel_R_X.Text = "123.456";
            this.E_Panel_R_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // B_Panel_R_Set_Light
            // 
            this.B_Panel_R_Set_Light.Location = new System.Drawing.Point(21, 134);
            this.B_Panel_R_Set_Light.Name = "B_Panel_R_Set_Light";
            this.B_Panel_R_Set_Light.Size = new System.Drawing.Size(133, 45);
            this.B_Panel_R_Set_Light.TabIndex = 2;
            this.B_Panel_R_Set_Light.Text = "設定光源";
            this.B_Panel_R_Set_Light.UseVisualStyleBackColor = true;
            this.B_Panel_R_Set_Light.Click += new System.EventHandler(this.B_Panel_R_Set_Light_Click);
            // 
            // B_Panel_R_Edit
            // 
            this.B_Panel_R_Edit.Location = new System.Drawing.Point(21, 83);
            this.B_Panel_R_Edit.Name = "B_Panel_R_Edit";
            this.B_Panel_R_Edit.Size = new System.Drawing.Size(133, 45);
            this.B_Panel_R_Edit.TabIndex = 1;
            this.B_Panel_R_Edit.Text = "編輯參數";
            this.B_Panel_R_Edit.UseVisualStyleBackColor = true;
            this.B_Panel_R_Edit.Click += new System.EventHandler(this.B_Panel_R_Edit_Click);
            // 
            // TP_Ofs
            // 
            this.TP_Ofs.BackColor = System.Drawing.SystemColors.Control;
            this.TP_Ofs.Controls.Add(this.groupBox11);
            this.TP_Ofs.Location = new System.Drawing.Point(4, 24);
            this.TP_Ofs.Name = "TP_Ofs";
            this.TP_Ofs.Size = new System.Drawing.Size(818, 576);
            this.TP_Ofs.TabIndex = 13;
            this.TP_Ofs.Text = "補償";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label65);
            this.groupBox11.Controls.Add(this.label66);
            this.groupBox11.Controls.Add(this.E_Ofs_Q);
            this.groupBox11.Controls.Add(this.label67);
            this.groupBox11.Controls.Add(this.label68);
            this.groupBox11.Controls.Add(this.E_Ofs_Y);
            this.groupBox11.Controls.Add(this.label69);
            this.groupBox11.Controls.Add(this.label72);
            this.groupBox11.Controls.Add(this.E_Ofs_X);
            this.groupBox11.Location = new System.Drawing.Point(12, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(181, 113);
            this.groupBox11.TabIndex = 10;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "[ 補正修正量 ]";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(144, 86);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(22, 14);
            this.label65.TabIndex = 17;
            this.label65.Text = "度";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(9, 86);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(27, 14);
            this.label66.TabIndex = 15;
            this.label66.Text = "DQ";
            // 
            // E_Ofs_Q
            // 
            this.E_Ofs_Q.Location = new System.Drawing.Point(67, 83);
            this.E_Ofs_Q.Name = "E_Ofs_Q";
            this.E_Ofs_Q.Size = new System.Drawing.Size(71, 24);
            this.E_Ofs_Q.TabIndex = 14;
            this.E_Ofs_Q.Text = "123.456";
            this.E_Ofs_Q.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(144, 57);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(29, 14);
            this.label67.TabIndex = 13;
            this.label67.Text = "mm";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(9, 57);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(27, 14);
            this.label68.TabIndex = 11;
            this.label68.Text = "DY";
            // 
            // E_Ofs_Y
            // 
            this.E_Ofs_Y.Location = new System.Drawing.Point(67, 54);
            this.E_Ofs_Y.Name = "E_Ofs_Y";
            this.E_Ofs_Y.Size = new System.Drawing.Size(71, 24);
            this.E_Ofs_Y.TabIndex = 10;
            this.E_Ofs_Y.Text = "123.456";
            this.E_Ofs_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(144, 26);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(29, 14);
            this.label69.TabIndex = 9;
            this.label69.Text = "mm";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(9, 26);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(27, 14);
            this.label72.TabIndex = 1;
            this.label72.Text = "DX";
            // 
            // E_Ofs_X
            // 
            this.E_Ofs_X.Location = new System.Drawing.Point(67, 23);
            this.E_Ofs_X.Name = "E_Ofs_X";
            this.E_Ofs_X.Size = new System.Drawing.Size(71, 24);
            this.E_Ofs_X.TabIndex = 0;
            this.E_Ofs_X.Text = "123.456";
            this.E_Ofs_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TP_Limit_Ofs
            // 
            this.TP_Limit_Ofs.Controls.Add(this.groupBox5);
            this.TP_Limit_Ofs.Location = new System.Drawing.Point(4, 24);
            this.TP_Limit_Ofs.Name = "TP_Limit_Ofs";
            this.TP_Limit_Ofs.Size = new System.Drawing.Size(818, 576);
            this.TP_Limit_Ofs.TabIndex = 32;
            this.TP_Limit_Ofs.Text = "修正量限制";
            this.TP_Limit_Ofs.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CB_Limit_Ofs_DQ_SW);
            this.groupBox5.Controls.Add(this.E_Limit_Ofs_DQ_Max);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.E_Limit_Ofs_DQ_Min);
            this.groupBox5.Controls.Add(this.CB_Limit_Ofs_DY_SW);
            this.groupBox5.Controls.Add(this.E_Limit_Ofs_DY_Max);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.E_Limit_Ofs_DY_Min);
            this.groupBox5.Controls.Add(this.CB_Limit_Ofs_DX_SW);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.E_Limit_Ofs_DX_Max);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.E_Limit_Ofs_DX_Min);
            this.groupBox5.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox5.Location = new System.Drawing.Point(32, 31);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(341, 131);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "[ Panel 尺寸限制 ]";
            // 
            // CB_Limit_Ofs_DQ_SW
            // 
            this.CB_Limit_Ofs_DQ_SW.AutoSize = true;
            this.CB_Limit_Ofs_DQ_SW.Location = new System.Drawing.Point(5, 98);
            this.CB_Limit_Ofs_DQ_SW.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Limit_Ofs_DQ_SW.Name = "CB_Limit_Ofs_DQ_SW";
            this.CB_Limit_Ofs_DQ_SW.Size = new System.Drawing.Size(78, 18);
            this.CB_Limit_Ofs_DQ_SW.TabIndex = 39;
            this.CB_Limit_Ofs_DQ_SW.Text = "Enabled";
            this.CB_Limit_Ofs_DQ_SW.UseVisualStyleBackColor = true;
            // 
            // E_Limit_Ofs_DQ_Max
            // 
            this.E_Limit_Ofs_DQ_Max.Location = new System.Drawing.Point(250, 96);
            this.E_Limit_Ofs_DQ_Max.Name = "E_Limit_Ofs_DQ_Max";
            this.E_Limit_Ofs_DQ_Max.Size = new System.Drawing.Size(71, 24);
            this.E_Limit_Ofs_DQ_Max.TabIndex = 38;
            this.E_Limit_Ofs_DQ_Max.Text = "123.456";
            this.E_Limit_Ofs_DQ_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(179, 99);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 14);
            this.label24.TabIndex = 37;
            this.label24.Text = "<= DQ <=";
            // 
            // E_Limit_Ofs_DQ_Min
            // 
            this.E_Limit_Ofs_DQ_Min.Location = new System.Drawing.Point(102, 96);
            this.E_Limit_Ofs_DQ_Min.Name = "E_Limit_Ofs_DQ_Min";
            this.E_Limit_Ofs_DQ_Min.Size = new System.Drawing.Size(71, 24);
            this.E_Limit_Ofs_DQ_Min.TabIndex = 36;
            this.E_Limit_Ofs_DQ_Min.Text = "123.456";
            this.E_Limit_Ofs_DQ_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CB_Limit_Ofs_DY_SW
            // 
            this.CB_Limit_Ofs_DY_SW.AutoSize = true;
            this.CB_Limit_Ofs_DY_SW.Location = new System.Drawing.Point(5, 68);
            this.CB_Limit_Ofs_DY_SW.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Limit_Ofs_DY_SW.Name = "CB_Limit_Ofs_DY_SW";
            this.CB_Limit_Ofs_DY_SW.Size = new System.Drawing.Size(78, 18);
            this.CB_Limit_Ofs_DY_SW.TabIndex = 35;
            this.CB_Limit_Ofs_DY_SW.Text = "Enabled";
            this.CB_Limit_Ofs_DY_SW.UseVisualStyleBackColor = true;
            // 
            // E_Limit_Ofs_DY_Max
            // 
            this.E_Limit_Ofs_DY_Max.Location = new System.Drawing.Point(250, 66);
            this.E_Limit_Ofs_DY_Max.Name = "E_Limit_Ofs_DY_Max";
            this.E_Limit_Ofs_DY_Max.Size = new System.Drawing.Size(71, 24);
            this.E_Limit_Ofs_DY_Max.TabIndex = 34;
            this.E_Limit_Ofs_DY_Max.Text = "123.456";
            this.E_Limit_Ofs_DY_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(179, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 14);
            this.label19.TabIndex = 33;
            this.label19.Text = "<= DY <=";
            // 
            // E_Limit_Ofs_DY_Min
            // 
            this.E_Limit_Ofs_DY_Min.Location = new System.Drawing.Point(102, 66);
            this.E_Limit_Ofs_DY_Min.Name = "E_Limit_Ofs_DY_Min";
            this.E_Limit_Ofs_DY_Min.Size = new System.Drawing.Size(71, 24);
            this.E_Limit_Ofs_DY_Min.TabIndex = 32;
            this.E_Limit_Ofs_DY_Min.Text = "123.456";
            this.E_Limit_Ofs_DY_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CB_Limit_Ofs_DX_SW
            // 
            this.CB_Limit_Ofs_DX_SW.AutoSize = true;
            this.CB_Limit_Ofs_DX_SW.Location = new System.Drawing.Point(5, 38);
            this.CB_Limit_Ofs_DX_SW.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Limit_Ofs_DX_SW.Name = "CB_Limit_Ofs_DX_SW";
            this.CB_Limit_Ofs_DX_SW.Size = new System.Drawing.Size(78, 18);
            this.CB_Limit_Ofs_DX_SW.TabIndex = 31;
            this.CB_Limit_Ofs_DX_SW.Text = "Enabled";
            this.CB_Limit_Ofs_DX_SW.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(271, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 14);
            this.label16.TabIndex = 8;
            this.label16.Text = "Max";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(125, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 14);
            this.label17.TabIndex = 7;
            this.label17.Text = "Min";
            // 
            // E_Limit_Ofs_DX_Max
            // 
            this.E_Limit_Ofs_DX_Max.Location = new System.Drawing.Point(250, 36);
            this.E_Limit_Ofs_DX_Max.Name = "E_Limit_Ofs_DX_Max";
            this.E_Limit_Ofs_DX_Max.Size = new System.Drawing.Size(71, 24);
            this.E_Limit_Ofs_DX_Max.TabIndex = 6;
            this.E_Limit_Ofs_DX_Max.Text = "123.456";
            this.E_Limit_Ofs_DX_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(179, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 14);
            this.label18.TabIndex = 1;
            this.label18.Text = "<= DX <=";
            // 
            // E_Limit_Ofs_DX_Min
            // 
            this.E_Limit_Ofs_DX_Min.Location = new System.Drawing.Point(102, 36);
            this.E_Limit_Ofs_DX_Min.Name = "E_Limit_Ofs_DX_Min";
            this.E_Limit_Ofs_DX_Min.Size = new System.Drawing.Size(71, 24);
            this.E_Limit_Ofs_DX_Min.TabIndex = 0;
            this.E_Limit_Ofs_DX_Min.Text = "123.456";
            this.E_Limit_Ofs_DX_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TP_Printer
            // 
            this.TP_Printer.Controls.Add(this.E_Printer_Tear_Off);
            this.TP_Printer.Controls.Add(this.SB_Printer_Tear_Off);
            this.TP_Printer.Controls.Add(this.B_Printer_Tear_off);
            this.TP_Printer.Location = new System.Drawing.Point(4, 24);
            this.TP_Printer.Name = "TP_Printer";
            this.TP_Printer.Size = new System.Drawing.Size(818, 576);
            this.TP_Printer.TabIndex = 29;
            this.TP_Printer.Text = "標籤機";
            this.TP_Printer.UseVisualStyleBackColor = true;
            // 
            // E_Printer_Tear_Off
            // 
            this.E_Printer_Tear_Off.Location = new System.Drawing.Point(134, 79);
            this.E_Printer_Tear_Off.Name = "E_Printer_Tear_Off";
            this.E_Printer_Tear_Off.Size = new System.Drawing.Size(49, 24);
            this.E_Printer_Tear_Off.TabIndex = 16;
            // 
            // SB_Printer_Tear_Off
            // 
            this.SB_Printer_Tear_Off.Location = new System.Drawing.Point(20, 79);
            this.SB_Printer_Tear_Off.Maximum = 129;
            this.SB_Printer_Tear_Off.Minimum = -120;
            this.SB_Printer_Tear_Off.Name = "SB_Printer_Tear_Off";
            this.SB_Printer_Tear_Off.Size = new System.Drawing.Size(99, 21);
            this.SB_Printer_Tear_Off.TabIndex = 15;
            this.SB_Printer_Tear_Off.ValueChanged += new System.EventHandler(this.SB_Printer_Tear_Off_ValueChanged);
            // 
            // B_Printer_Tear_off
            // 
            this.B_Printer_Tear_off.Location = new System.Drawing.Point(20, 14);
            this.B_Printer_Tear_off.Name = "B_Printer_Tear_off";
            this.B_Printer_Tear_off.Size = new System.Drawing.Size(99, 58);
            this.B_Printer_Tear_off.TabIndex = 14;
            this.B_Printer_Tear_off.Text = "Tear_Off";
            this.B_Printer_Tear_off.UseVisualStyleBackColor = true;
            this.B_Printer_Tear_off.Click += new System.EventHandler(this.B_Printer_Tear_off_Click);
            // 
            // TP_Printer_Value
            // 
            this.TP_Printer_Value.Controls.Add(this.DG_Value);
            this.TP_Printer_Value.Controls.Add(this.panel6);
            this.TP_Printer_Value.Location = new System.Drawing.Point(4, 24);
            this.TP_Printer_Value.Name = "TP_Printer_Value";
            this.TP_Printer_Value.Size = new System.Drawing.Size(818, 576);
            this.TP_Printer_Value.TabIndex = 30;
            this.TP_Printer_Value.Text = "標籤機變數";
            this.TP_Printer_Value.UseVisualStyleBackColor = true;
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
            this.DG_Value.Size = new System.Drawing.Size(737, 576);
            this.DG_Value.TabIndex = 5;
            // 
            // Column4
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "No";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 40;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "變數名稱";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "說明";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Value";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 200;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.OliveDrab;
            this.panel6.Controls.Add(this.B_Printer_Value_Clear);
            this.panel6.Controls.Add(this.B_Printer_Value_Add);
            this.panel6.Controls.Add(this.B_Printer_Value_Move_Dn);
            this.panel6.Controls.Add(this.B_Printer_Value_Delete);
            this.panel6.Controls.Add(this.B_Printer_Value_Move_Up);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(737, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(81, 576);
            this.panel6.TabIndex = 4;
            // 
            // B_Printer_Value_Clear
            // 
            this.B_Printer_Value_Clear.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Printer_Value_Clear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Printer_Value_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Printer_Value_Clear.Location = new System.Drawing.Point(8, 11);
            this.B_Printer_Value_Clear.Margin = new System.Windows.Forms.Padding(2);
            this.B_Printer_Value_Clear.Name = "B_Printer_Value_Clear";
            this.B_Printer_Value_Clear.Size = new System.Drawing.Size(64, 64);
            this.B_Printer_Value_Clear.TabIndex = 32;
            this.B_Printer_Value_Clear.Text = "清除";
            this.B_Printer_Value_Clear.UseVisualStyleBackColor = false;
            this.B_Printer_Value_Clear.Click += new System.EventHandler(this.B_Printer_Value_Clear_Click);
            // 
            // B_Printer_Value_Add
            // 
            this.B_Printer_Value_Add.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Printer_Value_Add.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Printer_Value_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Printer_Value_Add.Location = new System.Drawing.Point(8, 215);
            this.B_Printer_Value_Add.Margin = new System.Windows.Forms.Padding(2);
            this.B_Printer_Value_Add.Name = "B_Printer_Value_Add";
            this.B_Printer_Value_Add.Size = new System.Drawing.Size(64, 64);
            this.B_Printer_Value_Add.TabIndex = 28;
            this.B_Printer_Value_Add.Text = "增加";
            this.B_Printer_Value_Add.UseVisualStyleBackColor = false;
            this.B_Printer_Value_Add.Click += new System.EventHandler(this.B_Printer_Value_Add_Click);
            // 
            // B_Printer_Value_Move_Dn
            // 
            this.B_Printer_Value_Move_Dn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Printer_Value_Move_Dn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Printer_Value_Move_Dn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Printer_Value_Move_Dn.Location = new System.Drawing.Point(8, 147);
            this.B_Printer_Value_Move_Dn.Margin = new System.Windows.Forms.Padding(2);
            this.B_Printer_Value_Move_Dn.Name = "B_Printer_Value_Move_Dn";
            this.B_Printer_Value_Move_Dn.Size = new System.Drawing.Size(64, 64);
            this.B_Printer_Value_Move_Dn.TabIndex = 31;
            this.B_Printer_Value_Move_Dn.Text = "下移";
            this.B_Printer_Value_Move_Dn.UseVisualStyleBackColor = false;
            this.B_Printer_Value_Move_Dn.Click += new System.EventHandler(this.B_Printer_Value_Move_Dn_Click);
            // 
            // B_Printer_Value_Delete
            // 
            this.B_Printer_Value_Delete.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Printer_Value_Delete.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Printer_Value_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Printer_Value_Delete.Location = new System.Drawing.Point(8, 283);
            this.B_Printer_Value_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.B_Printer_Value_Delete.Name = "B_Printer_Value_Delete";
            this.B_Printer_Value_Delete.Size = new System.Drawing.Size(64, 64);
            this.B_Printer_Value_Delete.TabIndex = 29;
            this.B_Printer_Value_Delete.Text = "刪除";
            this.B_Printer_Value_Delete.UseVisualStyleBackColor = false;
            this.B_Printer_Value_Delete.Click += new System.EventHandler(this.B_Printer_Value_Delete_Click);
            // 
            // B_Printer_Value_Move_Up
            // 
            this.B_Printer_Value_Move_Up.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Printer_Value_Move_Up.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Printer_Value_Move_Up.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Printer_Value_Move_Up.Location = new System.Drawing.Point(8, 79);
            this.B_Printer_Value_Move_Up.Margin = new System.Windows.Forms.Padding(2);
            this.B_Printer_Value_Move_Up.Name = "B_Printer_Value_Move_Up";
            this.B_Printer_Value_Move_Up.Size = new System.Drawing.Size(64, 64);
            this.B_Printer_Value_Move_Up.TabIndex = 30;
            this.B_Printer_Value_Move_Up.Text = "上移";
            this.B_Printer_Value_Move_Up.UseVisualStyleBackColor = false;
            this.B_Printer_Value_Move_Up.Click += new System.EventHandler(this.B_Printer_Value_Move_Up_Click);
            // 
            // TP_Printe_Format
            // 
            this.TP_Printe_Format.Controls.Add(this.E_Print_Format_List);
            this.TP_Printe_Format.Controls.Add(this.panel7);
            this.TP_Printe_Format.Location = new System.Drawing.Point(4, 24);
            this.TP_Printe_Format.Name = "TP_Printe_Format";
            this.TP_Printe_Format.Size = new System.Drawing.Size(818, 576);
            this.TP_Printe_Format.TabIndex = 28;
            this.TP_Printe_Format.Text = "列印格式";
            this.TP_Printe_Format.UseVisualStyleBackColor = true;
            // 
            // E_Print_Format_List
            // 
            this.E_Print_Format_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.E_Print_Format_List.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.E_Print_Format_List.Location = new System.Drawing.Point(0, 60);
            this.E_Print_Format_List.Multiline = true;
            this.E_Print_Format_List.Name = "E_Print_Format_List";
            this.E_Print_Format_List.Size = new System.Drawing.Size(818, 516);
            this.E_Print_Format_List.TabIndex = 11;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.B_Printer_Inport_File);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(818, 60);
            this.panel7.TabIndex = 10;
            // 
            // B_Printer_Inport_File
            // 
            this.B_Printer_Inport_File.Location = new System.Drawing.Point(13, 13);
            this.B_Printer_Inport_File.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Printer_Inport_File.Name = "B_Printer_Inport_File";
            this.B_Printer_Inport_File.Size = new System.Drawing.Size(137, 38);
            this.B_Printer_Inport_File.TabIndex = 11;
            this.B_Printer_Inport_File.Text = "從檔案匯入";
            this.B_Printer_Inport_File.UseVisualStyleBackColor = true;
            this.B_Printer_Inport_File.Click += new System.EventHandler(this.B_Printer_Inport_File_Click);
            // 
            // TP_Box_Load
            // 
            this.TP_Box_Load.Controls.Add(this.groupBox3);
            this.TP_Box_Load.Location = new System.Drawing.Point(4, 24);
            this.TP_Box_Load.Name = "TP_Box_Load";
            this.TP_Box_Load.Size = new System.Drawing.Size(818, 576);
            this.TP_Box_Load.TabIndex = 31;
            this.TP_Box_Load.Text = "Box_Load";
            this.TP_Box_Load.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CB_Supply_Vacc);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.E_Box_Load_Y_Num);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.E_Box_Load_Z);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.E_Box_Load_Y);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.E_Box_Load_X_Num);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.E_Box_Load_X);
            this.groupBox3.Location = new System.Drawing.Point(23, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 213);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ L Model ]";
            // 
            // CB_Supply_Vacc
            // 
            this.CB_Supply_Vacc.AutoSize = true;
            this.CB_Supply_Vacc.Location = new System.Drawing.Point(94, 177);
            this.CB_Supply_Vacc.Name = "CB_Supply_Vacc";
            this.CB_Supply_Vacc.Size = new System.Drawing.Size(86, 18);
            this.CB_Supply_Vacc.TabIndex = 28;
            this.CB_Supply_Vacc.Text = "輔助真空";
            this.CB_Supply_Vacc.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 14);
            this.label6.TabIndex = 27;
            this.label6.Text = "Y數量";
            // 
            // E_Box_Load_Y_Num
            // 
            this.E_Box_Load_Y_Num.Location = new System.Drawing.Point(94, 147);
            this.E_Box_Load_Y_Num.Name = "E_Box_Load_Y_Num";
            this.E_Box_Load_Y_Num.Size = new System.Drawing.Size(71, 24);
            this.E_Box_Load_Y_Num.TabIndex = 26;
            this.E_Box_Load_Y_Num.Text = "123";
            this.E_Box_Load_Y_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(171, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 14);
            this.label14.TabIndex = 25;
            this.label14.Text = "mm";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 14);
            this.label15.TabIndex = 24;
            this.label15.Text = "箱體Z";
            // 
            // E_Box_Load_Z
            // 
            this.E_Box_Load_Z.Location = new System.Drawing.Point(94, 83);
            this.E_Box_Load_Z.Name = "E_Box_Load_Z";
            this.E_Box_Load_Z.Size = new System.Drawing.Size(71, 24);
            this.E_Box_Load_Z.TabIndex = 23;
            this.E_Box_Load_Z.Text = "123.456";
            this.E_Box_Load_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(171, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 14);
            this.label10.TabIndex = 22;
            this.label10.Text = "mm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 21;
            this.label13.Text = "箱體Y";
            // 
            // E_Box_Load_Y
            // 
            this.E_Box_Load_Y.Location = new System.Drawing.Point(94, 53);
            this.E_Box_Load_Y.Name = "E_Box_Load_Y";
            this.E_Box_Load_Y.Size = new System.Drawing.Size(71, 24);
            this.E_Box_Load_Y.TabIndex = 20;
            this.E_Box_Load_Y.Text = "123.456";
            this.E_Box_Load_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "X數量";
            // 
            // E_Box_Load_X_Num
            // 
            this.E_Box_Load_X_Num.Location = new System.Drawing.Point(94, 117);
            this.E_Box_Load_X_Num.Name = "E_Box_Load_X_Num";
            this.E_Box_Load_X_Num.Size = new System.Drawing.Size(71, 24);
            this.E_Box_Load_X_Num.TabIndex = 17;
            this.E_Box_Load_X_Num.Text = "123";
            this.E_Box_Load_X_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "箱體X";
            // 
            // E_Box_Load_X
            // 
            this.E_Box_Load_X.Location = new System.Drawing.Point(94, 23);
            this.E_Box_Load_X.Name = "E_Box_Load_X";
            this.E_Box_Load_X.Size = new System.Drawing.Size(71, 24);
            this.E_Box_Load_X.TabIndex = 14;
            this.E_Box_Load_X.Text = "123.456";
            this.E_Box_Load_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TP_MS_Param
            // 
            this.TP_MS_Param.Controls.Add(this.B_Edit_MS_Param);
            this.TP_MS_Param.Location = new System.Drawing.Point(4, 24);
            this.TP_MS_Param.Name = "TP_MS_Param";
            this.TP_MS_Param.Size = new System.Drawing.Size(818, 576);
            this.TP_MS_Param.TabIndex = 25;
            this.TP_MS_Param.Text = "機械參數";
            this.TP_MS_Param.UseVisualStyleBackColor = true;
            // 
            // B_Edit_MS_Param
            // 
            this.B_Edit_MS_Param.Location = new System.Drawing.Point(20, 21);
            this.B_Edit_MS_Param.Name = "B_Edit_MS_Param";
            this.B_Edit_MS_Param.Size = new System.Drawing.Size(186, 97);
            this.B_Edit_MS_Param.TabIndex = 3;
            this.B_Edit_MS_Param.Text = "編輯機械參數";
            this.B_Edit_MS_Param.UseVisualStyleBackColor = true;
            this.B_Edit_MS_Param.Click += new System.EventHandler(this.B_Edit_MS_Param_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 137);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Peru;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.E_Recipe_Code);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.E_Recipe_Info);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.E_Recipe_Name);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 64);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1150, 73);
            this.panel3.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(27, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Code";
            // 
            // E_Recipe_Code
            // 
            this.E_Recipe_Code.BackColor = System.Drawing.SystemColors.Window;
            this.E_Recipe_Code.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_Code.ForeColor = System.Drawing.SystemColors.WindowText;
            this.E_Recipe_Code.Location = new System.Drawing.Point(17, 36);
            this.E_Recipe_Code.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_Code.Name = "E_Recipe_Code";
            this.E_Recipe_Code.Size = new System.Drawing.Size(72, 33);
            this.E_Recipe_Code.TabIndex = 6;
            this.E_Recipe_Code.Text = "0000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(92, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(308, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "說明";
            // 
            // E_Recipe_Info
            // 
            this.E_Recipe_Info.BackColor = System.Drawing.SystemColors.Window;
            this.E_Recipe_Info.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_Info.ForeColor = System.Drawing.SystemColors.WindowText;
            this.E_Recipe_Info.Location = new System.Drawing.Point(302, 28);
            this.E_Recipe_Info.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_Info.Name = "E_Recipe_Info";
            this.E_Recipe_Info.Size = new System.Drawing.Size(354, 33);
            this.E_Recipe_Info.TabIndex = 3;
            this.E_Recipe_Info.Text = "說明";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(279, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "/";
            // 
            // E_Recipe_Name
            // 
            this.E_Recipe_Name.BackColor = System.Drawing.Color.Gray;
            this.E_Recipe_Name.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_Name.ForeColor = System.Drawing.Color.White;
            this.E_Recipe_Name.Location = new System.Drawing.Point(116, 36);
            this.E_Recipe_Name.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_Name.Name = "E_Recipe_Name";
            this.E_Recipe_Name.ReadOnly = true;
            this.E_Recipe_Name.Size = new System.Drawing.Size(160, 33);
            this.E_Recipe_Name.TabIndex = 1;
            this.E_Recipe_Name.Text = "Recipe_Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(128, 7);
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
            this.panel2.Size = new System.Drawing.Size(1150, 64);
            this.panel2.TabIndex = 2;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.ImageIndex = 3;
            this.B_Open.ImageList = this.Tool_ImageList;
            this.B_Open.Location = new System.Drawing.Point(360, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(120, 64);
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
            this.B_Save_As.ImageIndex = 2;
            this.B_Save_As.ImageList = this.Tool_ImageList;
            this.B_Save_As.Location = new System.Drawing.Point(240, 0);
            this.B_Save_As.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save_As.Name = "B_Save_As";
            this.B_Save_As.Size = new System.Drawing.Size(120, 64);
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
            this.B_Cancel.ImageIndex = 1;
            this.B_Cancel.ImageList = this.Tool_ImageList;
            this.B_Cancel.Location = new System.Drawing.Point(120, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(120, 64);
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
            this.B_Apply.ImageIndex = 0;
            this.B_Apply.ImageList = this.Tool_ImageList;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(120, 64);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(113, 741);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tFrame_JJS_HW1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(105, 711);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "影像";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(3, 3);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Only_Window = true;
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(99, 705);
            this.tFrame_JJS_HW1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tFrame_JJS_HW2);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(105, 711);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Tray";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tFrame_JJS_HW2
            // 
            this.tFrame_JJS_HW2.Disp_Scale = 1D;
            this.tFrame_JJS_HW2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW2.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW2.Location = new System.Drawing.Point(3, 3);
            this.tFrame_JJS_HW2.Name = "tFrame_JJS_HW2";
            this.tFrame_JJS_HW2.Only_Window = false;
            this.tFrame_JJS_HW2.Size = new System.Drawing.Size(99, 705);
            this.tFrame_JJS_HW2.TabIndex = 1;
            // 
            // TForm_Select_Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 741);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_Select_Recipe";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.TForm_Select_Recipe_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Panel_Size.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TP_Panel_Align.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TP_Ofs.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.TP_Limit_Ofs.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.TP_Printer.ResumeLayout(false);
            this.TP_Printer.PerformLayout();
            this.TP_Printer_Value.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Value)).EndInit();
            this.panel6.ResumeLayout(false);
            this.TP_Printe_Format.ResumeLayout(false);
            this.TP_Printe_Format.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.TP_Box_Load.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.TP_MS_Param.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage TP_Ofs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox E_Recipe_Code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox E_Ofs_Q;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox E_Ofs_Y;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox E_Ofs_X;
        private System.Windows.Forms.TabPage TP_Panel_Size;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox E_Panel_R_Y;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox E_Panel_R_X;
        private System.Windows.Forms.Button B_Panel_R_Set_Light;
        private System.Windows.Forms.Button B_Panel_R_Edit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox E_Panel_Z;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox E_Panel_Y;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox E_Panel_X;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox E_Panel_L_Y;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox E_Panel_L_X;
        private System.Windows.Forms.Button B_Panel_L_Set_Light;
        private System.Windows.Forms.Button B_Panel_L_Edit;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox CB_Panel_Length_SW;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox E_Panel_Length_Max;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox E_Panel_Length_Min;
        private System.Windows.Forms.ImageList Tool_ImageList;
        private System.Windows.Forms.TabPage TP_MS_Param;
        private System.Windows.Forms.Button B_Edit_MS_Param;
        private System.Windows.Forms.TabPage TP_Panel_Align;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private EFC.Vision.Halcon.TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.TabPage tabPage3;
        private EFC.Vision.Halcon.TFrame_JJS_HW tFrame_JJS_HW2;
        private System.Windows.Forms.TabPage TP_Printe_Format;
        private System.Windows.Forms.TextBox E_Print_Format_List;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button B_Printer_Inport_File;
        private System.Windows.Forms.TabPage TP_Printer;
        private System.Windows.Forms.TextBox E_Printer_Tear_Off;
        private System.Windows.Forms.HScrollBar SB_Printer_Tear_Off;
        private System.Windows.Forms.Button B_Printer_Tear_off;
        private System.Windows.Forms.TabPage TP_Printer_Value;
        private System.Windows.Forms.DataGridView DG_Value;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button B_Printer_Value_Clear;
        private System.Windows.Forms.Button B_Printer_Value_Add;
        private System.Windows.Forms.Button B_Printer_Value_Move_Dn;
        private System.Windows.Forms.Button B_Printer_Value_Delete;
        private System.Windows.Forms.Button B_Printer_Value_Move_Up;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button B_Pre_Process_Edit_L;
        private System.Windows.Forms.TabPage TP_Box_Load;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox E_Box_Load_X_Num;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox E_Box_Load_X;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox E_Box_Load_Y_Num;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox E_Box_Load_Z;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox E_Box_Load_Y;
        private System.Windows.Forms.CheckBox CB_Supply_Vacc;
        private System.Windows.Forms.TabPage TP_Limit_Ofs;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox CB_Limit_Ofs_DQ_SW;
        private System.Windows.Forms.TextBox E_Limit_Ofs_DQ_Max;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox E_Limit_Ofs_DQ_Min;
        private System.Windows.Forms.CheckBox CB_Limit_Ofs_DY_SW;
        private System.Windows.Forms.TextBox E_Limit_Ofs_DY_Max;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox E_Limit_Ofs_DY_Min;
        private System.Windows.Forms.CheckBox CB_Limit_Ofs_DX_SW;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox E_Limit_Ofs_DX_Max;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox E_Limit_Ofs_DX_Min;
        private System.Windows.Forms.CheckBox CB_Pre_Process_L_SW;
        private System.Windows.Forms.Button B_Pre_Process_Edit_R;
        private System.Windows.Forms.CheckBox CB_Pre_Process_R_SW;
    }
}