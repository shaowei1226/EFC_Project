namespace EFC.Vision.Halcon
{
    partial class TForm_Align_Mothed4
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Step0 = new System.Windows.Forms.TabPage();
            this.B_Set_Default = new System.Windows.Forms.Button();
            this.B_Next1 = new System.Windows.Forms.Button();
            this.TP_Step1 = new System.Windows.Forms.TabPage();
            this.B_Next2 = new System.Windows.Forms.Button();
            this.B_Base_Image = new System.Windows.Forms.Button();
            this.E_Base_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Trans_Image = new System.Windows.Forms.Button();
            this.B_Trans_Image = new System.Windows.Forms.Button();
            this.E_Trans_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Base_Image = new System.Windows.Forms.Button();
            this.TP_Step2 = new System.Windows.Forms.TabPage();
            this.B_Create_Region_Disp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.E_Find_Ofs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Create_Region_Edit = new System.Windows.Forms.Button();
            this.CB_Align_Angle = new System.Windows.Forms.CheckBox();
            this.B_Next3 = new System.Windows.Forms.Button();
            this.TP_Step3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tFrame_Create_Param1 = new EFC.Vision.Halcon.TFrame_Create_Param();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tFrame_Find_Param1 = new EFC.Vision.Halcon.TFrame_Find_Param();
            this.TP_Step4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.B_Next4 = new System.Windows.Forms.Button();
            this.TP_Step5 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.B_Next5 = new System.Windows.Forms.Button();
            this.TP_Step6 = new System.Windows.Forms.TabPage();
            this.B_Result_Image = new System.Windows.Forms.Button();
            this.B_Sample_Image2 = new System.Windows.Forms.Button();
            this.B_Base_Image2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Step0.SuspendLayout();
            this.TP_Step1.SuspendLayout();
            this.TP_Step2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TP_Step3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TP_Step4.SuspendLayout();
            this.TP_Step5.SuspendLayout();
            this.TP_Step6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 59);
            this.panel1.TabIndex = 3;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.Image = global::EFC.Vision.Halcon.Properties.Resources.button_cross;
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.Location = new System.Drawing.Point(97, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(97, 59);
            this.B_Cancel.TabIndex = 6;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.White;
            this.B_Apply.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Apply.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Apply.Image = global::EFC.Vision.Halcon.Properties.Resources.magic_wand;
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(97, 59);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 591);
            this.panel3.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Step0);
            this.tabControl1.Controls.Add(this.TP_Step1);
            this.tabControl1.Controls.Add(this.TP_Step2);
            this.tabControl1.Controls.Add(this.TP_Step3);
            this.tabControl1.Controls.Add(this.TP_Step4);
            this.tabControl1.Controls.Add(this.TP_Step5);
            this.tabControl1.Controls.Add(this.TP_Step6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 591);
            this.tabControl1.TabIndex = 0;
            // 
            // TP_Step0
            // 
            this.TP_Step0.Controls.Add(this.B_Set_Default);
            this.TP_Step0.Controls.Add(this.B_Next1);
            this.TP_Step0.Location = new System.Drawing.Point(4, 24);
            this.TP_Step0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TP_Step0.Name = "TP_Step0";
            this.TP_Step0.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TP_Step0.Size = new System.Drawing.Size(368, 563);
            this.TP_Step0.TabIndex = 0;
            this.TP_Step0.Text = "空白";
            this.TP_Step0.UseVisualStyleBackColor = true;
            this.TP_Step0.Enter += new System.EventHandler(this.TP_Step0_Enter);
            // 
            // B_Set_Default
            // 
            this.B_Set_Default.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Set_Default.Location = new System.Drawing.Point(49, 94);
            this.B_Set_Default.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Set_Default.Name = "B_Set_Default";
            this.B_Set_Default.Size = new System.Drawing.Size(140, 49);
            this.B_Set_Default.TabIndex = 18;
            this.B_Set_Default.Text = "Set Default";
            this.B_Set_Default.UseVisualStyleBackColor = true;
            this.B_Set_Default.Click += new System.EventHandler(this.B_Set_Default_Click);
            // 
            // B_Next1
            // 
            this.B_Next1.BackColor = System.Drawing.Color.Orange;
            this.B_Next1.Location = new System.Drawing.Point(270, 10);
            this.B_Next1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Next1.Name = "B_Next1";
            this.B_Next1.Size = new System.Drawing.Size(93, 36);
            this.B_Next1.TabIndex = 17;
            this.B_Next1.Text = "下一步 =>";
            this.B_Next1.UseVisualStyleBackColor = false;
            this.B_Next1.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step1
            // 
            this.TP_Step1.Controls.Add(this.B_Next2);
            this.TP_Step1.Controls.Add(this.B_Base_Image);
            this.TP_Step1.Controls.Add(this.E_Base_Image_File);
            this.TP_Step1.Controls.Add(this.B_Select_Trans_Image);
            this.TP_Step1.Controls.Add(this.B_Trans_Image);
            this.TP_Step1.Controls.Add(this.E_Trans_Image_File);
            this.TP_Step1.Controls.Add(this.B_Select_Base_Image);
            this.TP_Step1.Location = new System.Drawing.Point(4, 24);
            this.TP_Step1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TP_Step1.Name = "TP_Step1";
            this.TP_Step1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TP_Step1.Size = new System.Drawing.Size(368, 562);
            this.TP_Step1.TabIndex = 1;
            this.TP_Step1.Text = "Step1";
            this.TP_Step1.UseVisualStyleBackColor = true;
            this.TP_Step1.Enter += new System.EventHandler(this.TP_Step1_Enter);
            // 
            // B_Next2
            // 
            this.B_Next2.BackColor = System.Drawing.Color.Orange;
            this.B_Next2.Location = new System.Drawing.Point(270, 10);
            this.B_Next2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Next2.Name = "B_Next2";
            this.B_Next2.Size = new System.Drawing.Size(93, 36);
            this.B_Next2.TabIndex = 17;
            this.B_Next2.Text = "下一步 =>";
            this.B_Next2.UseVisualStyleBackColor = false;
            this.B_Next2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Base_Image
            // 
            this.B_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image.Location = new System.Drawing.Point(20, 61);
            this.B_Base_Image.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Base_Image.Name = "B_Base_Image";
            this.B_Base_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Base_Image.TabIndex = 0;
            this.B_Base_Image.Text = "Base Image";
            this.B_Base_Image.UseVisualStyleBackColor = true;
            this.B_Base_Image.Click += new System.EventHandler(this.B_Base_Image_Click);
            // 
            // E_Base_Image_File
            // 
            this.E_Base_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Image_File.Location = new System.Drawing.Point(20, 114);
            this.E_Base_Image_File.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.E_Base_Image_File.Name = "E_Base_Image_File";
            this.E_Base_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Base_Image_File.TabIndex = 3;
            // 
            // B_Select_Trans_Image
            // 
            this.B_Select_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Trans_Image.Location = new System.Drawing.Point(238, 221);
            this.B_Select_Trans_Image.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Select_Trans_Image.Name = "B_Select_Trans_Image";
            this.B_Select_Trans_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Trans_Image.TabIndex = 6;
            this.B_Select_Trans_Image.Text = "...";
            this.B_Select_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Select_Trans_Image.Click += new System.EventHandler(this.B_Select_Trans_Image_Click);
            // 
            // B_Trans_Image
            // 
            this.B_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Trans_Image.Location = new System.Drawing.Point(20, 167);
            this.B_Trans_Image.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Trans_Image.Name = "B_Trans_Image";
            this.B_Trans_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Trans_Image.TabIndex = 1;
            this.B_Trans_Image.Text = "Trans Image";
            this.B_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Trans_Image.Click += new System.EventHandler(this.B_Trans_Image_Click);
            // 
            // E_Trans_Image_File
            // 
            this.E_Trans_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Trans_Image_File.Location = new System.Drawing.Point(20, 221);
            this.E_Trans_Image_File.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.E_Trans_Image_File.Name = "E_Trans_Image_File";
            this.E_Trans_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Trans_Image_File.TabIndex = 5;
            // 
            // B_Select_Base_Image
            // 
            this.B_Select_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Base_Image.Location = new System.Drawing.Point(238, 114);
            this.B_Select_Base_Image.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Select_Base_Image.Name = "B_Select_Base_Image";
            this.B_Select_Base_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Base_Image.TabIndex = 4;
            this.B_Select_Base_Image.Text = "...";
            this.B_Select_Base_Image.UseVisualStyleBackColor = true;
            this.B_Select_Base_Image.Click += new System.EventHandler(this.B_Select_Base_Image_Click);
            // 
            // TP_Step2
            // 
            this.TP_Step2.Controls.Add(this.B_Create_Region_Disp);
            this.TP_Step2.Controls.Add(this.groupBox1);
            this.TP_Step2.Controls.Add(this.B_Create_Region_Edit);
            this.TP_Step2.Controls.Add(this.CB_Align_Angle);
            this.TP_Step2.Controls.Add(this.B_Next3);
            this.TP_Step2.Location = new System.Drawing.Point(4, 24);
            this.TP_Step2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TP_Step2.Name = "TP_Step2";
            this.TP_Step2.Size = new System.Drawing.Size(368, 562);
            this.TP_Step2.TabIndex = 4;
            this.TP_Step2.Text = "Step2";
            this.TP_Step2.UseVisualStyleBackColor = true;
            this.TP_Step2.Enter += new System.EventHandler(this.TP_Step2_Enter);
            // 
            // B_Create_Region_Disp
            // 
            this.B_Create_Region_Disp.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Create_Region_Disp.Location = new System.Drawing.Point(176, 113);
            this.B_Create_Region_Disp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Create_Region_Disp.Name = "B_Create_Region_Disp";
            this.B_Create_Region_Disp.Size = new System.Drawing.Size(70, 41);
            this.B_Create_Region_Disp.TabIndex = 32;
            this.B_Create_Region_Disp.Text = "顯示";
            this.B_Create_Region_Disp.UseVisualStyleBackColor = true;
            this.B_Create_Region_Disp.Click += new System.EventHandler(this.B_Create_Region_Disp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.E_Find_Ofs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(150, 52);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 搜尋參數 ]";
            // 
            // E_Find_Ofs
            // 
            this.E_Find_Ofs.Location = new System.Drawing.Point(102, 23);
            this.E_Find_Ofs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.E_Find_Ofs.Name = "E_Find_Ofs";
            this.E_Find_Ofs.Size = new System.Drawing.Size(36, 24);
            this.E_Find_Ofs.TabIndex = 1;
            this.E_Find_Ofs.Text = "123";
            this.E_Find_Ofs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "容許偏差量";
            // 
            // B_Create_Region_Edit
            // 
            this.B_Create_Region_Edit.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Create_Region_Edit.Location = new System.Drawing.Point(16, 113);
            this.B_Create_Region_Edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Create_Region_Edit.Name = "B_Create_Region_Edit";
            this.B_Create_Region_Edit.Size = new System.Drawing.Size(155, 41);
            this.B_Create_Region_Edit.TabIndex = 26;
            this.B_Create_Region_Edit.Text = "建立標靶區域";
            this.B_Create_Region_Edit.UseVisualStyleBackColor = true;
            this.B_Create_Region_Edit.Click += new System.EventHandler(this.B_Create_Region_Edit_Click);
            // 
            // CB_Align_Angle
            // 
            this.CB_Align_Angle.AutoSize = true;
            this.CB_Align_Angle.Location = new System.Drawing.Point(16, 15);
            this.CB_Align_Angle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CB_Align_Angle.Name = "CB_Align_Angle";
            this.CB_Align_Angle.Size = new System.Drawing.Size(86, 18);
            this.CB_Align_Angle.TabIndex = 29;
            this.CB_Align_Angle.Text = "角度定位";
            this.CB_Align_Angle.UseVisualStyleBackColor = true;
            // 
            // B_Next3
            // 
            this.B_Next3.BackColor = System.Drawing.Color.Orange;
            this.B_Next3.Location = new System.Drawing.Point(270, 10);
            this.B_Next3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Next3.Name = "B_Next3";
            this.B_Next3.Size = new System.Drawing.Size(93, 36);
            this.B_Next3.TabIndex = 18;
            this.B_Next3.Text = "下一步 =>";
            this.B_Next3.UseVisualStyleBackColor = false;
            this.B_Next3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step3
            // 
            this.TP_Step3.Controls.Add(this.button2);
            this.TP_Step3.Controls.Add(this.tabControl2);
            this.TP_Step3.Location = new System.Drawing.Point(4, 24);
            this.TP_Step3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TP_Step3.Name = "TP_Step3";
            this.TP_Step3.Size = new System.Drawing.Size(368, 562);
            this.TP_Step3.TabIndex = 7;
            this.TP_Step3.Text = "Step3";
            this.TP_Step3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(270, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 19;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(15, 43);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(326, 455);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tFrame_Create_Param1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(318, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tFrame_Create_Param1
            // 
            this.tFrame_Create_Param1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Create_Param1.Location = new System.Drawing.Point(12, 13);
            this.tFrame_Create_Param1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tFrame_Create_Param1.Name = "tFrame_Create_Param1";
            this.tFrame_Create_Param1.Size = new System.Drawing.Size(256, 356);
            this.tFrame_Create_Param1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tFrame_Find_Param1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(318, 427);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Find";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tFrame_Find_Param1
            // 
            this.tFrame_Find_Param1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Find_Param1.Location = new System.Drawing.Point(12, 13);
            this.tFrame_Find_Param1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tFrame_Find_Param1.Name = "tFrame_Find_Param1";
            this.tFrame_Find_Param1.Size = new System.Drawing.Size(252, 328);
            this.tFrame_Find_Param1.TabIndex = 0;
            // 
            // TP_Step4
            // 
            this.TP_Step4.Controls.Add(this.button1);
            this.TP_Step4.Controls.Add(this.B_Next4);
            this.TP_Step4.Location = new System.Drawing.Point(4, 24);
            this.TP_Step4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TP_Step4.Name = "TP_Step4";
            this.TP_Step4.Size = new System.Drawing.Size(368, 562);
            this.TP_Step4.TabIndex = 2;
            this.TP_Step4.Text = "Step4";
            this.TP_Step4.UseVisualStyleBackColor = true;
            this.TP_Step4.Enter += new System.EventHandler(this.TP_Step3_Enter);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(34, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 49);
            this.button1.TabIndex = 19;
            this.button1.Text = "Base Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // B_Next4
            // 
            this.B_Next4.BackColor = System.Drawing.Color.Orange;
            this.B_Next4.Location = new System.Drawing.Point(270, 10);
            this.B_Next4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Next4.Name = "B_Next4";
            this.B_Next4.Size = new System.Drawing.Size(93, 36);
            this.B_Next4.TabIndex = 16;
            this.B_Next4.Text = "下一步 =>";
            this.B_Next4.UseVisualStyleBackColor = false;
            this.B_Next4.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step5
            // 
            this.TP_Step5.Controls.Add(this.button3);
            this.TP_Step5.Controls.Add(this.B_Next5);
            this.TP_Step5.Location = new System.Drawing.Point(4, 24);
            this.TP_Step5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TP_Step5.Name = "TP_Step5";
            this.TP_Step5.Size = new System.Drawing.Size(368, 562);
            this.TP_Step5.TabIndex = 5;
            this.TP_Step5.Text = "Step5";
            this.TP_Step5.UseVisualStyleBackColor = true;
            this.TP_Step5.Enter += new System.EventHandler(this.TP_Step4_Enter);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(34, 34);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 49);
            this.button3.TabIndex = 21;
            this.button3.Text = "Trans Image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // B_Next5
            // 
            this.B_Next5.BackColor = System.Drawing.Color.Orange;
            this.B_Next5.Location = new System.Drawing.Point(270, 10);
            this.B_Next5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Next5.Name = "B_Next5";
            this.B_Next5.Size = new System.Drawing.Size(93, 36);
            this.B_Next5.TabIndex = 20;
            this.B_Next5.Text = "下一步 =>";
            this.B_Next5.UseVisualStyleBackColor = false;
            this.B_Next5.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step6
            // 
            this.TP_Step6.Controls.Add(this.B_Result_Image);
            this.TP_Step6.Controls.Add(this.B_Sample_Image2);
            this.TP_Step6.Controls.Add(this.B_Base_Image2);
            this.TP_Step6.Controls.Add(this.button5);
            this.TP_Step6.Location = new System.Drawing.Point(4, 24);
            this.TP_Step6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TP_Step6.Name = "TP_Step6";
            this.TP_Step6.Size = new System.Drawing.Size(368, 562);
            this.TP_Step6.TabIndex = 6;
            this.TP_Step6.Text = "Step6";
            this.TP_Step6.UseVisualStyleBackColor = true;
            this.TP_Step6.Enter += new System.EventHandler(this.TP_Step5_Enter);
            // 
            // B_Result_Image
            // 
            this.B_Result_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Result_Image.Location = new System.Drawing.Point(26, 174);
            this.B_Result_Image.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Result_Image.Name = "B_Result_Image";
            this.B_Result_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Result_Image.TabIndex = 25;
            this.B_Result_Image.Text = "Result Image";
            this.B_Result_Image.UseVisualStyleBackColor = true;
            this.B_Result_Image.Click += new System.EventHandler(this.B_Result_Image_Click_1);
            // 
            // B_Sample_Image2
            // 
            this.B_Sample_Image2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Sample_Image2.Location = new System.Drawing.Point(26, 102);
            this.B_Sample_Image2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Sample_Image2.Name = "B_Sample_Image2";
            this.B_Sample_Image2.Size = new System.Drawing.Size(140, 49);
            this.B_Sample_Image2.TabIndex = 24;
            this.B_Sample_Image2.Text = "Trans Image";
            this.B_Sample_Image2.UseVisualStyleBackColor = true;
            this.B_Sample_Image2.Click += new System.EventHandler(this.B_Sample_Image2_Click_1);
            // 
            // B_Base_Image2
            // 
            this.B_Base_Image2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image2.Location = new System.Drawing.Point(26, 33);
            this.B_Base_Image2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Base_Image2.Name = "B_Base_Image2";
            this.B_Base_Image2.Size = new System.Drawing.Size(140, 49);
            this.B_Base_Image2.TabIndex = 23;
            this.B_Base_Image2.Text = "Base Image";
            this.B_Base_Image2.UseVisualStyleBackColor = true;
            this.B_Base_Image2.Click += new System.EventHandler(this.B_Base_Image2_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lime;
            this.button5.Location = new System.Drawing.Point(270, 10);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 36);
            this.button5.TabIndex = 22;
            this.button5.Text = "完成";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(376, 59);
            this.tFrame_JJS_HW1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Only_Window = false;
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(471, 591);
            this.tFrame_JJS_HW1.TabIndex = 6;
            // 
            // TForm_Align_Mothed4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 650);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TForm_Align_Mothed4";
            this.Text = "TForm_Align_Mothed4";
            this.Shown += new System.EventHandler(this.TForm_Align_Mothed4_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Step0.ResumeLayout(false);
            this.TP_Step1.ResumeLayout(false);
            this.TP_Step1.PerformLayout();
            this.TP_Step2.ResumeLayout(false);
            this.TP_Step2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TP_Step3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.TP_Step4.ResumeLayout(false);
            this.TP_Step5.ResumeLayout(false);
            this.TP_Step6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_Step0;
        private System.Windows.Forms.Button B_Set_Default;
        private System.Windows.Forms.Button B_Next1;
        private System.Windows.Forms.TabPage TP_Step1;
        private System.Windows.Forms.Button B_Next2;
        private System.Windows.Forms.Button B_Base_Image;
        private System.Windows.Forms.TextBox E_Base_Image_File;
        private System.Windows.Forms.Button B_Select_Trans_Image;
        private System.Windows.Forms.Button B_Trans_Image;
        private System.Windows.Forms.TextBox E_Trans_Image_File;
        private System.Windows.Forms.Button B_Select_Base_Image;
        private System.Windows.Forms.TabPage TP_Step2;
        private System.Windows.Forms.Button B_Next3;
        private System.Windows.Forms.TabPage TP_Step4;
        private System.Windows.Forms.Button B_Next4;
        private EFC.Vision.Halcon.TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.Button B_Create_Region_Edit;
        private System.Windows.Forms.TabPage TP_Step5;
        private System.Windows.Forms.Button B_Next5;
        private System.Windows.Forms.TabPage TP_Step6;
        private System.Windows.Forms.CheckBox CB_Align_Angle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button B_Result_Image;
        private System.Windows.Forms.Button B_Sample_Image2;
        private System.Windows.Forms.Button B_Base_Image2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox E_Find_Ofs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Create_Region_Disp;
        private System.Windows.Forms.TabPage TP_Step3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private TFrame_Create_Param tFrame_Create_Param1;
        private System.Windows.Forms.TabPage tabPage2;
        private TFrame_Find_Param tFrame_Find_Param1;
    }
}