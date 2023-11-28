namespace DM200
{
    partial class Form1
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
            this.picResultImage = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbLiveDisplay = new System.Windows.Forms.CheckBox();
            this.BtnTrigger = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.listBoxDetectedSystems = new System.Windows.Forms.ListBox();
            this.lbIP = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCameraName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picResultImage)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // picResultImage
            // 
            this.picResultImage.BackColor = System.Drawing.Color.White;
            this.picResultImage.Location = new System.Drawing.Point(444, 18);
            this.picResultImage.Name = "picResultImage";
            this.picResultImage.Size = new System.Drawing.Size(490, 444);
            this.picResultImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResultImage.TabIndex = 1;
            this.picResultImage.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.LimeGreen;
            this.btnConnect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnConnect.Location = new System.Drawing.Point(49, 179);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(163, 42);
            this.btnConnect.TabIndex = 18;
            this.btnConnect.Tag = "0";
            this.btnConnect.Text = "Connected";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbLiveDisplay
            // 
            this.cbLiveDisplay.Enabled = false;
            this.cbLiveDisplay.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbLiveDisplay.Location = new System.Drawing.Point(49, 227);
            this.cbLiveDisplay.Name = "cbLiveDisplay";
            this.cbLiveDisplay.Size = new System.Drawing.Size(163, 40);
            this.cbLiveDisplay.TabIndex = 20;
            this.cbLiveDisplay.Text = "Live Display";
            this.cbLiveDisplay.CheckedChanged += new System.EventHandler(this.cbLiveDisplay_CheckedChanged);
            // 
            // BtnTrigger
            // 
            this.BtnTrigger.Enabled = false;
            this.BtnTrigger.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnTrigger.Location = new System.Drawing.Point(49, 282);
            this.BtnTrigger.Name = "BtnTrigger";
            this.BtnTrigger.Size = new System.Drawing.Size(154, 52);
            this.BtnTrigger.TabIndex = 19;
            this.BtnTrigger.Text = "Tigger";
            this.BtnTrigger.UseVisualStyleBackColor = true;
            this.BtnTrigger.Click += new System.EventHandler(this.BtnTrigger_Click);
            this.BtnTrigger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnTrigger_MouseDown);
            this.BtnTrigger.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnTrigger_MouseUp);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TxtResult);
            this.groupBox5.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox5.Location = new System.Drawing.Point(22, 368);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(392, 80);
            this.groupBox5.TabIndex = 33;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Result";
            // 
            // TxtResult
            // 
            this.TxtResult.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TxtResult.Location = new System.Drawing.Point(7, 30);
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.Size = new System.Drawing.Size(370, 43);
            this.TxtResult.TabIndex = 3;
            this.TxtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBoxDetectedSystems
            // 
            this.listBoxDetectedSystems.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBoxDetectedSystems.ItemHeight = 18;
            this.listBoxDetectedSystems.Location = new System.Drawing.Point(232, 179);
            this.listBoxDetectedSystems.Name = "listBoxDetectedSystems";
            this.listBoxDetectedSystems.Size = new System.Drawing.Size(191, 22);
            this.listBoxDetectedSystems.TabIndex = 34;
            this.listBoxDetectedSystems.SelectedIndexChanged += new System.EventHandler(this.listBoxDetectedSystems_SelectedIndexChanged_1);
            // 
            // lbIP
            // 
            this.lbIP.BackColor = System.Drawing.Color.LightGray;
            this.lbIP.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbIP.Location = new System.Drawing.Point(190, 93);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(227, 27);
            this.lbIP.TabIndex = 38;
            this.lbIP.Text = "---";
            this.lbIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(29, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 24);
            this.label5.TabIndex = 37;
            this.label5.Text = "Camera position:";
            // 
            // lbCameraName
            // 
            this.lbCameraName.BackColor = System.Drawing.Color.LightGray;
            this.lbCameraName.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbCameraName.Location = new System.Drawing.Point(190, 56);
            this.lbCameraName.Name = "lbCameraName";
            this.lbCameraName.Size = new System.Drawing.Size(227, 29);
            this.lbCameraName.TabIndex = 36;
            this.lbCameraName.Text = "DM-200";
            this.lbCameraName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 13.8F);
            this.label4.Location = new System.Drawing.Point(44, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 24);
            this.label4.TabIndex = 35;
            this.label4.Text = "Camera Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 472);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbCameraName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxDetectedSystems);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.cbLiveDisplay);
            this.Controls.Add(this.BtnTrigger);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.picResultImage);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picResultImage)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picResultImage;
        public System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox cbLiveDisplay;
        private System.Windows.Forms.Button BtnTrigger;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.ListBox listBoxDetectedSystems;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCameraName;
        private System.Windows.Forms.Label label4;
    }
}

