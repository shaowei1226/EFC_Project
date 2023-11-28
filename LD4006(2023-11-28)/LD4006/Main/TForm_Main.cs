using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EFC.Light;
using EFC.Tool;
using EFC.CAD;
using EFC.Printer.Zebra;

namespace Main
{
    public partial class TForm_Main : Form
    {
        public TFrame_Set_Light[] Frame_Set_Light = new TFrame_Set_Light[4];

        public TForm_Main()
        {
            InitializeComponent();//初始化組件
            Frame_Set_Light[0] = tFrame_Set_Light1;
            Frame_Set_Light[1] = tFrame_Set_Light2;
            Frame_Set_Light[2] = tFrame_Set_Light3;
            Frame_Set_Light[3] = tFrame_Set_Light4;
            //HSystem.SetSystem("clip_region", "false");    //設置HALCON系統參數(要更改的系統參數的名稱_默認值“init_new_image”,系統參數的新值_默認值“true”)
            TPub.Init();
        }
        private void TForm_Main_Shown(object sender, EventArgs e)
        {
            Update_Menu();
            picResultImage.Width = panel7.Width;
            picResultImage.Height = (int)(picResultImage.Width / 640.0 * 480.0);
            Update_Recipe();
            timer1.Enabled = true;
            timer2.Enabled = true;
        }
        private void TForm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Stop();
            TPub.Dispose();
            try
            {
                Environment.Exit(Environment.ExitCode); //強制結束所有處理程序
            }
            catch { }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            TPub.Update_Value_List_Date_Tiime();
            #region PLC
            if (TPub.PLC.PLC_Socket.Connect)
            {
                P_PLC.BackColor = Color.Green;
                L_PLC_Text.Text = "PLC連線中";
                E_PLC_Time.Text = string.Format("{0:f0}ms", TPub.PLC.Scan_Time);
            }
            else
            {
                P_PLC.BackColor = Color.Red;
                L_PLC_Text.Text = "PLC連線中斷";
                E_PLC_Time.Text = string.Format("{0:f0}ms", 0);
            }
            #endregion

           // Form_Tool.Set_Panel_Face(P_Panel_Reader, TPub.Panel_Reader.Connect, Color.Green, Color.Red);
            Form_Tool.Set_Panel_Face(P_Casette_Reader, TPub.Casette_Reader.Enabled, Color.Green, Color.Red);
            Form_Tool.Set_Panel_Face(P_Printer, TPub.Printer.Enabled, Color.Green, Color.Red);

            #region Log
            TPub.Log.Display(DG_Log);
            #endregion        

            if (TPub.Recipe.Value_List.Reflash)
            {
                TPub.Recipe.Value_List.Reflash = false;
                TPub.Recipe.Value_List.Set_Param_Grid(DG_Value);
            }

            CB_Printer_Ready.Checked = TPub.Printer.Status.Ready;
            CB_Printer_S1.Checked = TPub.Printer.Status.Paper_Out;
            CB_Printer_S2.Checked = TPub.Printer.Status.Pause;

            Form_Tool.Set_Button_Face(button5, TPub.Panel_Reader.Connect, Color.Green, Color.Gray);
            Form_Tool.Set_Button_Face(button6, TPub.Panel_Reader.On_Life, Color.Green, Color.Gray);
            Disp_Reader_Image();
            timer1.Enabled = true;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            TPub.Printer.Get_Status();
            timer2.Enabled = true;
        }
        public void Disp_Reader_Image()
        {
            if (TPub.Panel_Reader.Connect && TPub.Panel_Reader.Reflash)
            {
                TPub.Panel_Reader.Reflash = false;
                picResultImage.Image = TPub.Panel_Reader.Read_Image;
                picResultImage.Invalidate();
            }
        }
        public void Form_Stop()
        {
            timer1.Enabled = false;
            TPub.User_Management.Auto_Logout_Out = false;
        }
        public void Form_Start()
        {
            timer1.Enabled = true;
        }
        public void Update_Menu()
        {
            TPub.User_Management.User.Level = 9;

            E_User_Name.Text = TPub.User_Management.User.Name;
            E_User_Level.Text = TPub.User_Management.User.Level.ToString();
            if (TPub.User_Management.User.Level <= 0)
            {
                TSM_Recipe.Enabled = false;
                MI_Environment.Enabled = false;
            }
            else
            {
                TSM_Recipe.Enabled = true;
                MI_Environment.Enabled = true;
            }
        }
        public void Update_Recipe()
        {
            E_Recipe_ID.Text = TPub.Recipe.Recipe_Name;
            E_Recipe_Info.Text = TPub.Recipe.Info;
            TPub.Recipe.Print_Format.Disp_TextBox(E_Print_Format);
            TPub.Recipe.Value_List.Set_Param_Grid(DG_Value);
        }

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
            Form_Stop();
            TPub.Dispose();
            Close();
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
            }
            else
            {
                MessageBox.Show("請登入使用者帳號");
            }
        }
        private void MI_Recipe_Click(object sender, EventArgs e)
        {
            if (TPub.User_Management.User.Level >= 1)
            {
                Form_Stop();

                TForm_Select_Recipe form = new TForm_Select_Recipe();
                form.Set_Param(TPub.Recipe);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool flag = false;
                    //TPub.Recipe.Log_Diff(TPub.Log, "Recipe", form.Param, ref flag);
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
            TPub.PLC.PLC_In.View_Data(TPub.Environment.Base.Database_Path + "In.csv");
        }
        private void MI_ViewData_Out_Click(object sender, EventArgs e)
        {
            TPub.PLC.PLC_Out.View_Data(TPub.Environment.Base.Database_Path + "Out.csv");
        }
        private void MI_ViewData_Recipe_Click(object sender, EventArgs e)
        {
            TPub.PLC.PLC_Recipe.View_Data(TPub.Environment.Base.Database_Path + "Recipe.csv");
        }
        private void MI_Info_Click(object sender, EventArgs e)
        {
            TForm_Information form = new TForm_Information();
            form.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Printer_Format format = TPub.Get_Printer_Format();

            //format.Disp_TextBox(E_Out_Print_Format);
            E_Out_Print_Format.Text = format.ToString();
            TPub.Printer_Label();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TPub.Printer.Start();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            TPub.Panel_Reader.Connect = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            TPub.Panel_Reader.On_Life = !TPub.Panel_Reader.On_Life;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string read_str = "";

            E_P_Reader_Code.Text = "";
            if (TPub.P_Read_Code(ref read_str))
            {
                E_P_Reader_Code.Text = read_str;
            }
            else
                E_P_Reader_Code.Text = "Error";
        }

        private void CB_Printer_S2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CB_Printer_S1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void B_C_Read_Code_Click(object sender, EventArgs e)
        {
            string read_str = "";

            E_C_Reader_Code.Text = "";
            if (TPub.C_Read_Code(ref read_str))
            {
                E_C_Reader_Code.Text = read_str;
            }
            else
                E_C_Reader_Code.Text = "Error";
        }

        private void B_Log_Reset_Click(object sender, EventArgs e)
        {
            DG_Log.ClearSelection();
            if (DG_Log.RowCount > 0) DG_Log.FirstDisplayedScrollingRowIndex = 0;
        }

        private void B_Log_Sort_Click(object sender, EventArgs e)
        {
            TForm_Log_Sort form = new TForm_Log_Sort(TPub.Log);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TPub.Log.Reflash = true;
            }
        }

        private void Light_Setting_Click(object sender, EventArgs e)
        {

        }

        private void B_ALL_Open_Click(object sender, EventArgs e)
        {
         //   TPub.Set_Light_All_ON();
        }

        private void B_ALL_Close_Click(object sender, EventArgs e)
        {
          //  TPub.Set_Light_All_OFF();
        }
        public void Set_Light_Box(int index)
        {
            TLight_Channel[] light_data = new TLight_Channel[4];

            if (index >= 0 && index <= 3)
            {
                for (int i = 0; i < 4; i++)
                    light_data[i] = TPub.Light1.Channels[index * 4 + i];
            }

            for (int i = 0; i < light_data.Length; i++)
                Frame_Set_Light[i].Set(light_data[i]);
        }

        private void CB_Light_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_Light_Box(CB_Light_Box.SelectedIndex);
        }
    }
}
