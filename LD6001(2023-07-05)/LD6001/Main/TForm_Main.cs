using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.IO;
using EFC.CAD;
using EFC.Measure;
using EFC.Vision.Halcon;
using EFC.Camera;
using EFC.File_Manager;
using EFC.Light;
using EFC.Tool;
using EFC.Printer.Zebra;
//using RCAPINet;

namespace Main
{
    public enum emLog_Display_Mode { None, X2_1, X2_2, X4_3 };
    public enum emDisplay_Mode { None, X1_1, X1_2, X1_3, X1_4, X2_1, X2_2 };

    public partial class TForm_Main : Form
    {
        public bool On_MU_Select = false;
        public string Log_Source = "TForm_Main";
        public emLog_Display_Mode Log_Disp_Mode = emLog_Display_Mode.X4_3;
        public emDisplay_Mode Dsip_Mode = emDisplay_Mode.X2_1;
        public int Disp_Mode_Page = 0;
        public TFrame_Set_Light[] Frame_Set_Light = new TFrame_Set_Light[4];


        public int Page_Count
        {
            get
            {
                int result = 0;
                switch (Log_Disp_Mode)
                {
                    case emLog_Display_Mode.X2_1: result = 2; break;
                    case emLog_Display_Mode.X2_2: result = 4; break;
                    case emLog_Display_Mode.X4_3: result = 12; break;
                }
                return result;
            }
        }

        #region Main
        public TForm_Main()
        {
            InitializeComponent();//初始化組件

            Frame_Set_Light[0] = tFrame_Set_Light1;
            Frame_Set_Light[1] = tFrame_Set_Light2;
            Frame_Set_Light[2] = tFrame_Set_Light3;
            Frame_Set_Light[3] = tFrame_Set_Light4;

            HSystem.SetSystem("clip_region", "false");    //設置HALCON系統參數(要更改的系統參數的名稱_默認值“init_new_image”,系統參數的新值_默認值“true”)
            TPub.Init();
        }
        private void TForm_Main_Shown(object sender, EventArgs e)
        {
            tFrame_Display1.Dock = DockStyle.Fill;
            tFrame_Display1.On_Display += TPub.Disp;
            Set_Disp_Mode(Dsip_Mode);

            tFrame_Display2.Dock = DockStyle.Fill;
            tFrame_Display2.On_Display += TPub.Disp_Log;
            Set_Log_Disp_Mode(Log_Disp_Mode);

            Set_CCD_Name();
            Set_Light_Box(0);

            Update_Menu();
            Update_Recipe();

            picResultImage.Width = panel7.Width;
            picResultImage.Height = (int)(picResultImage.Width / 640.0 * 480.0);
            Form_Start();
        }
        public void Log_Add(string fun, string msg, emLog_Type type = emLog_Type.Generally)
        {
            TPub.Log.Add(Log_Source, fun, msg, type);
        }
        private void TSB_Reset_All_Click(object sender, EventArgs e)
        {
            TPub.Reset_All();
        }
        private void Form_Close()
        {
            Form_Stop();
            TPub.Set_Light_All_OFF();
            TPub.Dispose();
        }
        public void Form_Stop()
        {
            timer1.Enabled = false;
            tFrame_Display1.Disp_Enabled = false;
            tFrame_Display2.Disp_Enabled = false;
        }
        public void Form_Start()
        {
            timer1.Enabled = true;
            tFrame_Display1.Disp_Enabled = true;
            tFrame_Display2.Disp_Enabled = true;
        }
        private void TForm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            #region PLC
            if (TPub.PLC.PLC_Socket.Connect)
            {
                P_PLC.BackColor = Color.Green;
                L_PLC_Text.Text = "連線中";
                L_PLC_Time.Text = string.Format("{0:f0}ms", TPub.PLC.Scan_Time);
            }
            else
            {
                P_PLC.BackColor = Color.Red;
                L_PLC_Text.Text = "連線中斷";
                L_PLC_Time.Text = string.Format("{0:f0}ms", 0);
            }
            #endregion

            #region Log
            TPub.Log.Display(DG_Log);
            #endregion

            #region Printer
            Disp_Printer_Status();
            #endregion

            #region Reader
            Disp_Reader_Image();
            #endregion

            #region Other
            Open_MU_Select();
            File_Manager.Delete();
            #endregion

            timer1.Enabled = true;
        }
        public void Open_MU_Select()
        {
            if (TPub.MU_Data_List.Count > 0)
            {
                TForm_MU_Select form = new TForm_MU_Select(TPub.MU_Data_List[0], TPub.MU_Select_Display, TPub.MU_Select_Get_Find_Data, TPub.MU_Select_Get_Finish);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TPub.MU_Data_List.RemoveAt(0);
                }
            }
        }
        public void Update_Menu()
        {
            //權限先強制設成 9 方便使用
            TPub.User_Management.User.Level = 9;

            E_User_Name.Text = TPub.User_Management.User.Name;
            E_User_Level.Text = TPub.User_Management.User.Level.ToString();
            if (TPub.User_Management.User.Level <= 0)
            {
                MI_Recipe.Enabled = false;
                MI_Teach.Enabled = false;
                MI_Environment.Enabled = false;
            }
            else
            {
                MI_Recipe.Enabled = true;
                MI_Teach.Enabled = true;
                MI_Environment.Enabled = true;
            }
        }
        public void Update_Recipe()
        {
            E_Recipe_ID.Text = TPub.Recipe.Recipe_Name;
            E_Recipe_Info.Text = TPub.Recipe.Info;

            TPub.Recipe.Printer.Format1.Disp_TextBox(E_Printer_Format1);
            TPub.Recipe.Printer.Format2.Disp_TextBox(E_Printer_Format2);
            TPub.Recipe.Printer.Value_List.Set_Param_Grid(DG_Printer_Value);
        }
        #endregion

        #region tFrame_Display1
        private void Set_Disp_Mode(emDisplay_Mode mode)
        {
            int w, h;

            w = TPub.Cameras[0].Image_Width;
            h = TPub.Cameras[0].Image_Height;
            Dsip_Mode = mode;
            switch (Dsip_Mode)
            {
                #region X1
                case emDisplay_Mode.X1_1:
                    tFrame_Display1.Set_HW_Size(1, 1, new int[] { 0 }, w, h);
                    break;

                case emDisplay_Mode.X1_2:
                    tFrame_Display1.Set_HW_Size(1, 1, new int[] { 1 }, w, h);
                    break;

                case emDisplay_Mode.X1_3:
                    tFrame_Display1.Set_HW_Size(1, 1, new int[] { 2 }, w, h);
                    break;

                case emDisplay_Mode.X1_4:
                    tFrame_Display1.Set_HW_Size(1, 1, new int[] { 3 }, w, h);
                    break;
                #endregion

                #region X2
                case emDisplay_Mode.X2_1:
                    tFrame_Display1.Set_HW_Size(2, 1, new int[] { 0, 1 }, w, h);
                    break;

                case emDisplay_Mode.X2_2:
                    tFrame_Display1.Set_HW_Size(2, 1, new int[] { 2, 3 }, w, h);
                    break;
                #endregion

                //#region X4
                //case emDisplay_Mode.X4_1:
                //    tFrame_Display1.Set_HW_Size(2, 2, new int[] { 0, 1, 2, 3 }, w, h);
                //    break;
                //#endregion
            }
            tFrame_Display1.Repaint();
        }
        public void Set_Log_Disp_Mode(emLog_Display_Mode mode)
        {
            Log_Disp_Mode = mode;
            int[] index = null;
            int w = 640;
            int h = 480;

            index = Get_Disp_Mode_Index();
            switch (Log_Disp_Mode)
            {
                case emLog_Display_Mode.X2_1: tFrame_Display2.Set_HW_Size(2, 1, index, w, h); break;
                case emLog_Display_Mode.X2_2: tFrame_Display2.Set_HW_Size(2, 2, index, w, h); break;
                case emLog_Display_Mode.X4_3: tFrame_Display2.Set_HW_Size(4, 3, index, w, h); break;
            }
            //CB_View_Mode.SelectedIndex = Get_Display_Mode_Int(View_Mode);
            Set_Page_List();
            //Update_HW_View();
        }
        private void Set_Page_List()
        {
            int count = TPub.Get_Max_Int(TPub.Image_Logs.Count, Page_Count);
            int old_index = CB_Page_Name.SelectedIndex;

            CB_Page_Name.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                CB_Page_Name.Items.Add((i + 1).ToString());
            }
            if (old_index >= CB_Page_Name.Items.Count) old_index = CB_Page_Name.Items.Count - 1;
            if (old_index < CB_Page_Name.Items.Count) CB_Page_Name.SelectedIndex = old_index;
        }
        public int[] Get_Disp_Mode_Index()
        {
            int[] result = new int[Page_Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Disp_Mode_Page * Page_Count + i;
            }
            return result;
        }
        private void B_2X1_Click(object sender, EventArgs e)
        {
            Set_Log_Disp_Mode(emLog_Display_Mode.X2_1);
        }
        private void B_2X2_Click(object sender, EventArgs e)
        {
            Set_Log_Disp_Mode(emLog_Display_Mode.X2_2);
        }
        private void B_4X3_Click(object sender, EventArgs e)
        {
            Set_Log_Disp_Mode(emLog_Display_Mode.X4_3);
        }
        private void CB_Page_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] index = null;

            Disp_Mode_Page = CB_Page_Name.SelectedIndex;
            index = Get_Disp_Mode_Index();
            tFrame_Display2.Set_Index(index);
            tFrame_Display2.Repaint();
        }
        #endregion

        #region MI
        private void MI_Login_Click(object sender, EventArgs e)
        {
            TPub.User_Management.RFID_Login = false;
            if (TPub.User_Management.Login_Form_User(TPub.User_Management.User))
            {

            }
            Update_Menu();
            TPub.User_Management.RFID_Login = true;
        }
        private void MI_Logout_Click(object sender, EventArgs e)
        {
            TPub.User_Management.Logout();
            Update_Menu();
        }
        private void MI_Close_Click(object sender, EventArgs e)
        {
            Form_Close();
        }
        private void MI_Environment_Click(object sender, EventArgs e)
        {
            if (TPub.User_Management.User.Level >= 1)
            {
                Form_Stop();
                TForm_Environment form = new TForm_Environment();
                form.Set_Param(TPub.Environment);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    TPub.Environment.Set(form.Param);
                    TPub.Environment.Write();
                    TPub.Update_Environment();
                }
                Form_Start();
            }
            else
            {
                MessageBox.Show("請登入使用者帳號");
            }
        }
        private void MI_Teach2_Click(object sender, EventArgs e)
        {
            Form_Stop();
            TForm_Teaching form = new TForm_Teaching();
            form.Set_Param(TPub.Teach);
            if (form.ShowDialog() == DialogResult.OK)
            {
                TPub.Teach.Set(form.Param);
                TPub.Teach.Teach_Name = TPub.Recipe.Recipe_Name;
                TPub.Teach.Write();
            }
            Form_Start();
        }
        private void TSM_Recipe_Click(object sender, EventArgs e)
        {
            if (TPub.User_Management.User.Level >= 1)
            {
                Form_Stop();
                TForm_Select_Recipe form = new TForm_Select_Recipe();
                form.Set_Param(TPub.Recipe);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool flag = false;
                    TPub.Recipe.Log_Diff(TPub.Log, "Recipe", form.Param, ref flag);
                    TPub.Recipe.Set(form.Param);
                    TPub.Recipe.Write();
                    TPub.Environment.Base.Recipe_Name = TPub.Recipe.Recipe_Name;

                    TPub.Environment.Write();
                    TPub.Apply_Recipe();
                    TPub.Write_Recipe_To_PLC();
                    Update_Recipe();
                }
                Form_Start();
            }
            else
            {
                MessageBox.Show("請登入使用者帳號");
            }
        }
        private void MI_ViewData_In_Click(object sender, EventArgs e)
        {
            TPub.PLC.PLC_In.View_Data();
        }
        private void MI_ViewData_Out_Click(object sender, EventArgs e)
        {
            TPub.PLC.PLC_Out.View_Data();
        }
        private void MI_ViewData_Recipe_Click(object sender, EventArgs e)
        {
            TPub.PLC.PLC_Recipe.View_Data();
        }
        private void MI_Info_Click(object sender, EventArgs e)
        {
            TForm_Information form = new TForm_Information();
            form.ShowDialog();
        }
        #endregion

        #region 影像測試
        private void B_Load_Image_Click(object sender, EventArgs e)
        {
            int ccd_no = CB_Select_CCD.SelectedIndex;
            //int pos_no = CB_Pos.SelectedIndex;
            HImage image = null;

            if (ccd_no >= 0)
            {
                image = Dialog_Tool.Open_Dialog_Image();
                if (JJS_Vision.Is_Not_Empty(image))
                {
                    TPub.Cameras[ccd_no].Select_Image = image.Clone();
                    TPub.Cameras[ccd_no].Used_Select_Image = true;
                    TPub.Cameras[ccd_no].Refalsh = true;
                    CB_Used_Select_Image.Checked = TPub.Cameras[ccd_no].Used_Select_Image;
                }
            }
        }
        private void B_Save_Image_Click(object sender, EventArgs e)
        {
            int ccd_no = CB_Select_CCD.SelectedIndex;
            //int pos_no = CB_Pos.SelectedIndex;
            HImage image = null;

            if (ccd_no >= 0)
            {
                image = TPub.Cameras[ccd_no].Get_HImage();
                Dialog_Tool.Save_Dialog_Image(image);
            }
        }
        private void CB_MU_CCD_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_Image_Tool(CB_Select_CCD.SelectedIndex);
        }
        private void CB_Used_Select_Image_CheckedChanged(object sender, EventArgs e)
        {
            int no = 0;

            no = CB_Select_CCD.SelectedIndex;
            if (no < TPub.Cameras.Length && TPub.Cameras[no] != null)
            {
                TPub.Cameras[no].Used_Select_Image = CB_Used_Select_Image.Checked;
                Set_Image_Tool(CB_Select_CCD.SelectedIndex);
            }
        }
        private void Set_Image_Tool(int no)
        {
            if (no < TPub.Cameras.Length)
                if (TPub.Cameras[no] != null)
                    CB_Used_Select_Image.Checked = TPub.Cameras[no].Used_Select_Image;
        }
        public void Set_CCD_Name()
        {
            string[] ccd_name = new string[TPub.Cameras.Length];

            ccd_name = TPub.Get_CCD_Name_All();
            CB_Select_CCD.Items.Clear();
            for (int i = 0; i < ccd_name.Length; i++)
                CB_Select_CCD.Items.Add(ccd_name[i]);
            CB_Select_CCD.SelectedIndex = 0;
        }
        #endregion

        #region 光源設定
        private void B_ALL_Open_Click(object sender, EventArgs e)
        {
            TPub.Set_Light_All_ON();
        }
        private void B_ALL_Close_Click(object sender, EventArgs e)
        {
            TPub.Set_Light_All_OFF();
        }
        private void CB_Light_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_Light_Box(CB_Light_Box.SelectedIndex);
        }
        public void Set_Light_Box(int index)
        {
            TLight_Channel[] light_data = new TLight_Channel[4];

            for (int i = 0; i < 4; i++)
                light_data[i] = TPub.Light.Channels[index * 4 + i];

            for (int i = 0; i < light_data.Length; i++)
                Frame_Set_Light[i].Set(light_data[i]);
        }
        #endregion

        #region Panel_Big標靶測試
        private void B_Panel_Big_L_Find_Click(object sender, EventArgs e)
        {
            TPub.Find(emModel.Big_L);
        }
        private void B_Panel_Big_R_Find_Click(object sender, EventArgs e)
        {
            TPub.Find(emModel.Big_R);
        }
        private void B_Panel_Big_L_Set_Light_Click(object sender, EventArgs e)
        {
            TPub.Set_Light(emModel.Big_L);
        }
        private void B_Panel_Big_R_Set_Light_Click(object sender, EventArgs e)
        {
            TPub.Set_Light(emModel.Big_R);
        }
        private void B_Panel_Big_L_MU_Find_Click(object sender, EventArgs e)
        {
            TPub.MU_Select(emModel.Big_L);
        }
        private void B_Panel_Big_R_MU_Find_Click(object sender, EventArgs e)
        {
            TPub.MU_Select(emModel.Big_R);
        }
        private void B_Panel_BigC_Cal_Click(object sender, EventArgs e)
        {
            TPub.Panel_Big_Cal();
        }
        #endregion

        #region Panel_Small標靶測試
        private void B_Panel_Small_L_Find_Click(object sender, EventArgs e)
        {
            TPub.Find( emModel.Small_L);
        }
        private void B_Panel_Small_R_Find_Click(object sender, EventArgs e)
        {
            TPub.Find(emModel.Small_R);
        }
        private void B_Panel_Small_L_Set_Light_Click(object sender, EventArgs e)
        {
            TPub.Set_Light(emModel.Small_L);
        }
        private void B_Panel_Small_R_Set_Light_Click(object sender, EventArgs e)
        {
            TPub.Set_Light(emModel.Small_R);
        }
        private void B_Panel_Small_L_MU_Find_Click(object sender, EventArgs e)
        {
            TPub.MU_Select(emModel.Small_L);
        }
        private void B_Panel_Small_R_MU_Find_Click(object sender, EventArgs e)
        {
            TPub.MU_Select(emModel.Small_R);
        }
        private void B_Panel_Small_Cal_Click(object sender, EventArgs e)
        {
            TPub.Panel_Small_Cal();
        }
        #endregion

        #region Main_Life
        private void TSM_View_Click(object sender, EventArgs e)
        {
            ToolStripItem obj = (ToolStripItem)sender;
            string name = obj.Name;

            switch (name)
            {
                #region X1
                case "TSM_X1_1": Set_Disp_Mode(emDisplay_Mode.X1_1); break;
                case "TSM_X1_2": Set_Disp_Mode(emDisplay_Mode.X1_2); break;
                case "TSM_X1_3": Set_Disp_Mode(emDisplay_Mode.X1_3); break;
                case "TSM_X1_4": Set_Disp_Mode(emDisplay_Mode.X1_4); break;
                #endregion

                #region X2
                case "TSM_X2_1": Set_Disp_Mode(emDisplay_Mode.X2_1); break;
                case "TSM_X2_2": Set_Disp_Mode(emDisplay_Mode.X2_2); break;
                #endregion

                //#region X4
                //case "TSM_X4": Set_Disp_Mode(emDisplay_Mode.X4_1); break;
                //#endregion
            }
        }
        private void TS_All_Grab_Life_Click(object sender, EventArgs e)
        {
            TPub.All_Grab_Life();
        }
        private void TS_All_Grab_Stop_Click(object sender, EventArgs e)
        {
            TPub.All_Grab_Stop();
        }
        #endregion

        #region Log
        private void B_Log_Reset_Click(object sender, EventArgs e)
        {
            DG_Log.ClearSelection();
            DG_Log.FirstDisplayedScrollingRowIndex = 0;
        }
        private void B_Log_Sort_Click(object sender, EventArgs e)
        {
            TForm_Log_Sort form = new TForm_Log_Sort(TPub.Log);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TPub.Log.Reflash = true;
            }
        }
        #endregion

        #region Other
        private void B_Measure_Click(object sender, EventArgs e)
        {
            Form_Stop();
            TForm_Measure form = new TForm_Measure(TPub.Get_CCD_Name_All(), TPub.Measure_CCD_Change, TPub.Measure_Get_Find_Data, TPub.Measure_Get_Abs_Pos);
            form.ShowDialog();
            Form_Start();
        }
        #endregion

        private void panel16_VisibleChanged(object sender, EventArgs e)
        {
            tFrame_Display2.Repaint();
        }

        #region Printer
        private void Disp_Printer_Status()
        {
            Form_Tool.Set_Panel_Face(P_Printer, TPub.Printer.Enabled, Color.Green, Color.Red);

            if (TPub.Recipe.Printer.Value_List.Reflash)
            {
                TPub.Recipe.Printer.Value_List.Reflash = false;
                TPub.Recipe.Printer.Value_List.Set_Param_Grid(DG_Printer_Value);
            }

            CB_Printer_Ready.Checked = TPub.Printer.Status.Ready;
            CB_Printer_S1.Checked = TPub.Printer.Status.Paper_Out;
            CB_Printer_S2.Checked = TPub.Printer.Status.Pause;
            CB_Printer_S3.Checked = TPub.Printer.Status.Ribbon_Out;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TPub.Printer.Start();
        }
        private void B_Printer_Format1_Out_Click(object sender, EventArgs e)
        {
            Printer_Format format = TPub.Get_Printer_Format1();

            format.Disp_TextBox(E_Out_Print_Format);
            E_Out_Print_Format.Text = format.ToString();
            TPub.Printer_Label1();
        }
        private void B_Printer_Format2_Out_Click(object sender, EventArgs e)
        {
            Printer_Format format = TPub.Get_Printer_Format2();

            format.Disp_TextBox(E_Out_Print_Format);
            E_Out_Print_Format.Text = format.ToString();
            TPub.Printer_Label1();
        }
        #endregion

        #region Reader
        public void Disp_Reader_Image()
        {
            picResultImage.Height = picResultImage.Width * 480 / 640;

            Form_Tool.Set_Panel_Face(P_Reader, TPub.Reader_2D.Connect, Color.Green, Color.Red);
            Form_Tool.Set_Button_Face(B_Reader_Connect, TPub.Reader_2D.Connect, Color.Green, Color.Red);
            Form_Tool.Set_Button_Face(B_Reader_Life, TPub.Reader_2D.On_Life, Color.Green, Color.Red);

            if (TPub.Reader_2D.On_Life)
            {
                B_Reader_Read_Code.Enabled = false;
            }
            else
            {
                B_Reader_Read_Code.Enabled = true;
            }


            if (TPub.Reader_2D.Connect && TPub.Reader_2D.Reflash)
            {
                TPub.Reader_2D.Reflash = false;
                picResultImage.Image = TPub.Reader_2D.Read_Image;
                picResultImage.Invalidate();
            }
        }
        private void E_Reader_Connect_Click(object sender, EventArgs e)
        {
            TPub.Reader_2D.Connect = true;
        }
        private void E_Reader_Life_Click(object sender, EventArgs e)
        {
            TPLC_Data_In BR = new TPLC_Data_In();
            TPub.Reader_2D.On_Life = !TPub.Reader_2D.On_Life;
            if (TPub.Reader_2D.On_Life)
            {
                BR.BR_live = true;

            }
        }
        private void E_Reader_Read_Code_Click(object sender, EventArgs e)
        {
            string read_str = "";

            E_Reader_Code.Text = "";
            if (TPub.Barcode_Read(ref read_str))
            {
                E_Reader_Code.Text = read_str;
            }
            else
                E_Reader_Code.Text = "Error";
        }
        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {
            TPub.Printer.Get_Status();
        }

    }
}
