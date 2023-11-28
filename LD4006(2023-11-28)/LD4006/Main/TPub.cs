using System;
using System.Collections;
using System.ComponentModel; 
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;  
using System.Threading.Tasks;
using EFC.Light;
using EFC.Light.EFC;
using EFC.PLC.Melsec; 
using EFC.Tool; 
using EFC.CAD;
using EFC.User_Manager;
using EFC.Printer.Zebra;
using EFC.Reader.Keyence;
using Cognex.DataMan;


namespace Main
{
    public static class TPub
    {
        #region 參數
        static public string Log_Source = "TPub";
        static public TEnvironment Environment = new TEnvironment();
        static public TRecipe Recipe = new TRecipe();
        static public TPLC PLC = new TPLC();
        static public TPLC_CMD_Thread CMD_Thread = new TPLC_CMD_Thread();

        static public TLight_EFC Light1 = new TLight_EFC();
        static public TLight_Channel_List Light_Channels = new TLight_Channel_List();

        static public TLog Log = new TLog();
        static public TLog Log_Panel_ID = new TLog();
        static public TLog Log_Casette_ID = new TLog();

        static public User_Manager User_Management = new User_Manager();
        static public TZebra_Printer Printer = new TZebra_Printer();
        static public TReader_Cognex_DataMan Panel_Reader = new TReader_Cognex_DataMan();
        static public TReader_BL_U2 Casette_Reader = new TReader_BL_U2();
        #endregion

        #region 初始化相關函數&結束相關函數
        static public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            Log.Add(Log_Source, fun, msg_str, type);
        }
        static public void Dispose()
        {
            CMD_Thread.Dispose();
            PLC.Dispose();
            Environment.Write();
            JJS_LIB.Sleep(300);
        }

        public static void Init()
        {
            Application.DoEvents();
            TEFC_Message.Show("初始化環境", "", 500);

            TEFC_Message.Add_Message("初始化環境檔案");
            JJS_LIB.Sleep(100);
            Init_File();

            TEFC_Message.Add_Message("初始化Log");
            JJS_LIB.Sleep(100);
            Init_Log();

            TEFC_Message.Add_Message("初始化使用者管理");
            JJS_LIB.Sleep(100);
            Init_User_Management();

            TEFC_Message.Add_Message("初始化PLC");
            JJS_LIB.Sleep(100);
            Init_PLC();

            TEFC_Message.Add_Message("初始化Recipe");
            JJS_LIB.Sleep(100);
            Init_Recipe();

            TEFC_Message.Add_Message("初始化Printer");
            JJS_LIB.Sleep(100);
            Init_Printer();

            TEFC_Message.Add_Message("初始化Light");
            JJS_LIB.Sleep(100);
            Init_Light();

            TEFC_Message.Add_Message("初始化Reader");
            JJS_LIB.Sleep(100);
            Init_Reader();

            TEFC_Message.Add_Message("初始化完成");
            Log.Add("Pub Init Ok.");
            TEFC_Message.End();
           
            PLC.Start();
            CMD_Thread.Start();
            Log.Add("Pub Init Ok.");
        }
        public static void Init_File()
        {
            try
            {
                Environment.Default_Path = System.Windows.Forms.Application.StartupPath + "\\";
                Environment.Default_FileName = "Environment.xml";
                Environment.Read();
               
                User_Management.Log = Log;
                Update_Environment();

            }
            catch { }
        }
        public static void Init_Light()
        {
            string fun = "Init_Light";

            Log_Add(fun, "Init_Light");
            //設定燈源連線ComPort
            Light1.COM.Set_Com_Port("COM" + Environment.Light.EFC_Light1_COM_Port.ToString());
            Light1.Enabled = true;
            Light1.Channels[0].Set(Light1, "Barcode", 0);
            Light1.Channels[1].Set(Light1, "預留", 1);
            Light1.Channels[2].Set(Light1, "預留", 2);
            Light1.Channels[3].Set(Light1, "預留", 3);
            Light1.Channels[4].Set(Light1, "預留", 4);
            Light1.Channels[5].Set(Light1, "預留", 5);
            Light1.Channels[6].Set(Light1, "預留", 6);
            Light1.Channels[7].Set(Light1, "預留", 7);
            Light1.Channels[8].Set(Light1, "預留", 8);
            Light1.Channels[9].Set(Light1, "預留", 9);
            Light1.Channels[10].Set(Light1, "預留", 10);
            Light1.Channels[11].Set(Light1, "預留", 11);
            Light1.Channels[12].Set(Light1, "預留", 12);
            Light1.Channels[13].Set(Light1, "預留", 13);
            Light1.Channels[14].Set(Light1, "預留", 14);
            Light1.Channels[15].Set(Light1, "預留", 15);

            Light_Channels.Count = 0;
            for (int i = 0; i < Light1.Channel_Count; i++) Light_Channels.Add(Light1.Channels[i]);
        }
        public static void Init_Log()
        {
            Log.Default_Path = Environment.Base.Database_Path + "Log\\";
            Log.Enabled = true;

            Log_Panel_ID.Default_Path = Environment.Base.Database_Path + "Log_Panel_ID\\";
            Log_Panel_ID.Enabled = true;

            Log_Casette_ID.Default_Path = Environment.Base.Database_Path + "Log_Casette_ID\\";
            Log_Casette_ID.Enabled = true;
        }
        public static void Init_PLC()
        {
            Log.Add("Init_PLC");
            TMelsec_QPLC_Eth_Connect Temp_PLC = (TMelsec_QPLC_Eth_Connect)PLC.PLC_Socket;
            Temp_PLC.Host = Environment.PLC.Host;
            Temp_PLC.Port = Environment.PLC.Port;

            PLC.Log = Log;
            PLC.PLC_In.Start_Code = Environment.PLC.In_Start_Code;
            PLC.PLC_In.Count = Environment.PLC.In_Count;

            PLC.PLC_Out.Start_Code = Environment.PLC.Out_Start_Code;
            PLC.PLC_Out.Count = Environment.PLC.Out_Count;

            PLC.PLC_Recipe.Start_Code = Environment.PLC.Recipe_Start_Code;
            PLC.PLC_Recipe.Count = Environment.PLC.Recipe_Count;

            PLC.PLC_Socket.Connect = true;
        }
        public static void Init_Recipe()
        {
            Log.Add("Init_Recipe");
            Recipe.Default_Path = Environment.Base.Recipe_Path;
            Recipe.Recipe_Name = Environment.Base.Recipe_Name;
            Recipe.Default_FileName = "Produce.xml";
            Recipe.Read();

            Apply_Recipe();
        }
        public static void Init_Printer()
        {
            Log.Add("Init_Printer");
            Printer.Set_Com_Port(Environment.COM_Port.Printer);
            Printer.Log = Log;
            Printer.Enabled = true;
        }
        public static void Init_Reader()
        {
            Log.Add("Init_Reader");
            Panel_Reader.Log = Log;
            Panel_Reader.Connect = true;

        //    Casette_Reader.Set_Com_Port(Environment.COM_Port.Casette_Reader);
            Casette_Reader.Log = Log;
            Casette_Reader.Enabled = true;
        }
        static public void Init_User_Management()
        {
            string filename = "";

            Log.Add("Init_User_Manabement");
            filename = Environment.Base.Database_Path + "UserTable.xml";

            if (!System.IO.File.Exists(filename))
            {
                User_Management.Create_Table(filename);
            }
            else
            {
                User_Management.User_List.Read_File(filename);
            }

            User_Management.Log = Log;
            //Reader[0] = new TSoyal_RFID_Reader();
            //Reader[0].Com_Port = Environment.Other.RFID_COM_Port;
            //Reader[0].Log = Log;
            //Reader[0].Enabled = true;
            //User_Management.Add_Reader(Reader[0]);
            User_Management.Logout_Time = Environment.Base.Auto_Log_Out_Time;
            User_Management.Auto_Logout_Out = Environment.Base.Auto_Log_Out;
        }
        static public void Update_Environment()
        {
            User_Management.Auto_Logout_Out = Environment.Base.Auto_Log_Out;
            User_Management.Logout_Time = Environment.Base.Auto_Log_Out_Time;
        }
        #endregion


        static public void Apply_Recipe()
        {
            Apply_Recipe_To_Pub();
            Apply_Recipe_To_View();
            Apply_Recipe_To_PLC();
        }
        static public void Apply_Recipe_To_Pub()
        {
        }
        static public void Apply_Recipe_To_View()
        {
        }
        static public void Apply_Recipe_To_PLC()
        {
            string section = "";
            int axis_no = 0;

            #region MS_Param
            #region LD
            #region 供料
            axis_no = 0;
            section = "LD升降/供料";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "供料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "供料完成位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region 出料
            axis_no = 1;
            section = "LD升降/出料";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "供料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "供料完成位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion
            #endregion

            #region 取料手臂
            #region X
            axis_no = 2;
            section = "取料手臂/X";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "放料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] =0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region 供料Y
            axis_no = 3;
            section = "取料手臂/供料Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion
           

            
            axis_no = 4;
            section = "取料手臂/供料Z";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "放料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;

            axis_no = 5;
            section = "取料手臂/出料Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;

            axis_no = 6;
            section = "取料手臂/出料Z";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "放料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region 載台
            #region Y
            axis_no = 7;
            section = "載台/Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "讀碼位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region 靠位X
            axis_no = 8;
            section = "載台/靠位X";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "靠位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region 靠位Y
            axis_no = 9;
            section = "載台/靠位Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "靠位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion
            #endregion

            #region 貼標手臂
            axis_no = 10;
            section = "貼標手臂/X";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "讀碼位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "取標位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "貼標位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            axis_no = 11;
            section = "貼標手臂/Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "讀碼位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "取標位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "貼標位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            axis_no = 9;
            section = "貼標手臂/Q";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "讀碼位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "取標位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "貼標位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region ULD手臂
            axis_no = 12;
            section = "ULD手臂/Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "出料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            axis_no = 9;
            section = "ULD手臂/Z";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "出料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion
            #endregion

            PLC.PLC_Recipe.Update();
        }
        static public bool Write_Recipe_To_PLC()
        {
            bool result = true;
            string fun = "Write_Recipe_To_PLC";

            Log_Add(fun, "Update Recipe To PLC.");
            PLC.PLC_In.Write_Recipe_Req = true;
            while (!PLC.PLC_Out.Write_Recipe.Finish)
            {
                Application.DoEvents();
                JJS_LIB.Sleep(1);
            }

            if (!PLC.PLC_Out.Write_Recipe.OK)
            {
                Log_Add(fun, "Recipe 更新至PLC失敗.", emLog_Type.Warning);
                MessageBox.Show("Recipe 更新至PLC失敗", "警告", MessageBoxButtons.OK);
            }
            PLC.PLC_In.Write_Recipe_Req = false;
            return result;
        }


        static public Printer_Format Get_Printer_Format()
        {
            Printer_Format result = new Printer_Format();

            result.Set(Recipe.Print_Format);
            result.Cut_Comment();
            result.Replace_Value(Recipe.Value_List);

            return result;
        }
        static public bool Printer_Label()
        {
            bool result = false;
            Printer_Format format = TPub.Get_Printer_Format();

            result = Printer.Write_String(format);
            return result;
        }
        static public bool P_Read_Code(ref string code)
        {
            bool result = false;

            Recipe.Value_List.Set_Value(Recipe.Value_Panel_ID, "");
            Recipe.Value_List.Reflash = true;

            result = Panel_Reader.Get_Code(ref code);
            if (result)
            {
                Recipe.Value_List.Set_Value(Recipe.Value_Panel_ID, code);
                PLC.PLC_Out.P_Code = code;
                Recipe.Value_List.Reflash = true;
            }
            //Recipe.Value_List
            return result;
        }
        static public bool C_Read_Code(ref string code)
        {
            bool result = false;

            result = Casette_Reader.Read_Code(ref code);
            if (result)
            {
                Recipe.Value_List.Set_Value(Recipe.Value_Cassette_ID, code);
                PLC.PLC_Out.C_Code = code;
                Recipe.Value_List.Reflash = true;
            }
            return result;
        }
        static public void Update_Value_List_Date_Tiime()
        {
            DateTime time = DateTime.Now;

            Recipe.Value_List.Set_Value("%DATE%", time.ToString("MM") + "/" + DateTime.Now.ToString("dd"));
            Recipe.Value_List.Set_Value("%TIME%", time.ToString("hh:mm"));
            Recipe.Value_List.Reflash = true;
        }
    }
}
