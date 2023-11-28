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

using EFC.Camera; 
using EFC.Camera.Sentech;
using EFC.Light;
using EFC.Light.EFC;
using EFC.PLC.Melsec; 
using EFC.Tool; 
using EFC.Vision.Halcon;
using EFC.CAD;
using EFC.File_Manager;
using EFC.User_Manager;
using EFC.Measure;
using EFC.Printer.Zebra;
using Cognex.DataMan;
using HalconDotNet;

namespace Main
{
    public enum emCCD_Name { None, Small_L, Small_R, Big_L, Big_R };
    public enum emModel { None, Small_L, Small_R, Big_L, Big_R };

    class TPub
    {
        #region 參數
        static public string in_Panel_ID = "Default";

        static public TLog Log = new TLog();
        static public string Log_Source = "TPub";

        static public TEnvironment Environment = new TEnvironment();
        static public TRecipe Recipe = new TRecipe();

        static public TPLC PLC = new TPLC();
        static public TPLC_CMD_Thread CMD_Thread = new TPLC_CMD_Thread();

        static public TTeach Teach = new TTeach();
        static public TLight_EFC Light = new TLight_EFC();
        static public TLight_Channel_List Light_Channels = new TLight_Channel_List();

        static public int Cameras_Count = 4; //2個CCD
        static public TCamera_Base[] Cameras = new TCamera_Base[Cameras_Count];
        static public TCamera_View[] Camera_View = new TCamera_View[Cameras_Count];
        static public TFind_Data_Result[] Find_Data = new TFind_Data_Result[4];
        static public TImage_Logs Image_Logs = new TImage_Logs(4);
        static public TMU_Select_Data_List MU_Data_List = new TMU_Select_Data_List();
        static public User_Manager User_Management = new User_Manager();

        static public TZebra_Printer Printer = new TZebra_Printer();
        static public TReader_Cognex_DataMan Reader_2D = new TReader_Cognex_DataMan();

        static public string Panel_ID
        {
            get
            {
                return in_Panel_ID;
            }
            set
            {
                if (value != "") in_Panel_ID = value;
                else in_Panel_ID = "Default";
            }
        }
        #endregion

        #region 初始化相關函數&結束相關函數
        static public void Dispose()
        {
            All_Grab_Stop();
            All_Grab_Close();
            Environment.Write();
            CMD_Thread.Dispose();
            PLC.Dispose();
            Log.Dispose();
        }
        static public void Log_Add(string fun, string msg, emLog_Type type = emLog_Type.Generally)
        {
            Log.Add(Log_Source, fun, msg, type);
        }
        static public void Init()
        {
            string fun = "Init";

            for (int i = 0; i < Cameras.Length; i++)  Cameras[i] = new TCamera_Base();
            for (int i = 0; i < Camera_View.Length; i++)
            {
                Camera_View[i] = new TCamera_View();
                Camera_View[i].Camera = Cameras[i];
            }

            for (int i = 0; i < Find_Data.Length; i++) Find_Data[i] = new TFind_Data_Result();
           
            Application.DoEvents();
            TEFC_Message.Show("初始化環境", "", 500);
            //TEFC_Message.Show_Form.Location = new System.Drawing.Point(0, 0);

            TEFC_Message.Add_Message("初始化環境檔案");
            JJS_LIB.Sleep(100);
            Init_File();

            TEFC_Message.Add_Message("初始化Log");
            JJS_LIB.Sleep(100);
            Init_Log();

            TEFC_Message.Add_Message("初始化使用者管理");
            JJS_LIB.Sleep(100);
            Init_User_Management();

            TEFC_Message.Add_Message("初始化檔案管理");
            JJS_LIB.Sleep(100);
            Init_File_Management();

            TEFC_Message.Add_Message("初始化Image_Log");
            JJS_LIB.Sleep(100);
            Init_Image_Log();

            TEFC_Message.Add_Message("初始化PLC");
            JJS_LIB.Sleep(100);
            Init_PLC();

            TEFC_Message.Add_Message("初始化Recipe");
            JJS_LIB.Sleep(100);
            Init_Recipe();

            TEFC_Message.Add_Message("初始化Camera");
            JJS_LIB.Sleep(100);
            Init_Camera();

            TEFC_Message.Add_Message("初始化Light");
            JJS_LIB.Sleep(100);
            Init_Light();

            TEFC_Message.Add_Message("初始化Teach");
            JJS_LIB.Sleep(100);
            Init_Teach();

            TEFC_Message.Add_Message("初始化Printer");
            JJS_LIB.Sleep(100);
            Init_Printer();

            TEFC_Message.Add_Message("初始化Reader");
            JJS_LIB.Sleep(100);
            Init_Reader();
            
            TEFC_Message.Add_Message("初始化完成");
            TEFC_Message.End();

            Apply_Recipe();
            PLC.Start();
            CMD_Thread.Start();
            Log_Add(fun, "Pub Init Ok.");
        }
        static public void Init_File()
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
        static public void Init_Log()
        {
            Log.Default_Path = Environment.Base.Database_Path + "Log\\";
            Log.Enabled = true;
        }
        static public void Init_PLC()
        {
            string fun = "Init_PLC";
            
            Log_Add(fun, "Init_PLC");
            //TQPLC_RS232_Connect Temp_PLC = (TQPLC_RS232_Connect)PLC.PLC_Socket;
            //Temp_PLC.COM.Set_Com_Port(Environment.PLC.COM_Port);

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

            CMD_Thread.Log = Log;
        }

        static public void Init_Recipe()
        {
            string fun = "Init_Recipe";

            Log_Add(fun, "Init_Recipe");
            Recipe.Default_FileName = "Produce.xml";
            Recipe.Default_Path = Environment.Base.Recipe_Path;
            Recipe.Recipe_Name = Environment.Base.Recipe_Name;
            Recipe.Read();
        }
        static public void Init_Teach()
        {
            string fun = "Init_Teach";

            Log_Add(fun, "Init_Teach");
            Teach.Default_Path = Environment.Base.Recipe_Path + "Teach\\";
            Teach.Teach_Name = Environment.Base.Recipe_Name;
            Teach.Default_FileName = "Teach.xml";
            Teach.Read();
        }
        static public void Init_Camera()
        {
            string fun = "Init_Camera";

            Log_Add(fun, "Init_Camera");
            for (int i = 0; i < Cameras.Length; i++) Cameras[i].Set_Camera_Size(Environment.CCDs[i].Pixel_X, Environment.CCDs[i].Pixel_Y);

            #region Sentech
            try
            {
                TSentech_Giga.Find_All_Camera();
                Set_Camera_Sentech(fun, Environment.CCDs[0].CCD_Name, ref Cameras[0]);
                Set_Camera_Sentech(fun, Environment.CCDs[1].CCD_Name, ref Cameras[1]);
                Set_Camera_Sentech(fun, Environment.CCDs[2].CCD_Name, ref Cameras[2]);
                Set_Camera_Sentech(fun, Environment.CCDs[3].CCD_Name, ref Cameras[3]);
            }
            catch (Exception ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            };

            #endregion

            #region Other
            for (int i = 0; i < Cameras.Length; i++)
            {
                if (Environment.CCDs[i] != null)
                    Cameras[i].Name = string.Format("({0:d}) {1:s}", i + 1, Environment.CCDs[i].Name);

                Cameras[i].Log = Log;
            }
            for (int i = 0; i < Camera_View.Length; i++)
            {
                Camera_View[i].Camera = Cameras[i];
            }
            //Cameras[0].Mirror_Row = true;
            //Cameras[1].Mirror_Row = true;
            Cameras[2].Mirror_Row = true;
            Cameras[2].Mirror_Col = true;
            Cameras[3].Mirror_Row = true;
            Cameras[3].Mirror_Col = true;
            All_Grab_Life();
            #endregion
        }
        static public void Set_Camera_Sentech(string fun, string ccd_name, ref TCamera_Base dist_camera)
        {
            TCamera_Sentech_Giga camera = null;

            camera = TSentech_Giga.Get_Camera_By_UserDefinedName(ccd_name);
            if (camera != null) dist_camera = camera;
            else
            {
                Log_Add(fun, string.Format("CCD_Name={0:s} 初始化失敗.", ccd_name), emLog_Type.Error);
            }
        }

        static public void Init_Light()
        {
            string fun = "Init_Light";

            Log_Add(fun, "Init_Light");
            //設定燈源連線ComPort
            Light.COM.Set_Com_Port("COM" + Environment.Light.EFC_Light_COM_Port.ToString());
            Light.Enabled = true;

            Light.Channels[0].Set(Light, "Panel同軸L", 0);
            Light.Channels[1].Set(Light, "Panel同軸R", 1);
            Light.Channels[2].Set(Light, "Panel環光L", 2);
            Light.Channels[3].Set(Light, "Panel環光R", 3);
            Light.Channels[4].Set(Light, "預留", 4);
            Light.Channels[5].Set(Light, "預留", 5);
            Light.Channels[6].Set(Light, "預留", 6);
            Light.Channels[7].Set(Light, "預留", 7);
            Light.Channels[8].Set(Light, "預留", 8);
            Light.Channels[9].Set(Light, "預留", 9);
            Light.Channels[10].Set(Light, "預留", 10);
            Light.Channels[11].Set(Light, "預留", 11);
            Light.Channels[12].Set(Light, "預留", 12);
            Light.Channels[13].Set(Light, "預留", 13);
            Light.Channels[14].Set(Light, "預留", 14);
            Light.Channels[15].Set(Light, "預留", 15);

            Light_Channels.Count = 0;
            for (int i = 0; i < Light.Channel_Count; i++) Light_Channels.Add(Light.Channels[i]);
        }
        static public void Init_Image_Log()
        {
            string fun = "Init_Image_Log";
            int page = 0;
            int page_count = 12;

            Log_Add(fun, "Init_Image_Log");
            page = 0;
            Image_Logs[page * page_count + 00].Set_Data(emModel.Big_L.ToString(), new TFind_Mothed_1_Result());
            Image_Logs[page * page_count + 01].Set_Data(emModel.Big_R.ToString(), new TFind_Mothed_1_Result());
            Image_Logs[page * page_count + 02].Set_Data(emModel.Small_L.ToString(), new TFind_Mothed_1_Result());
            Image_Logs[page * page_count + 03].Set_Data(emModel.Small_R.ToString(), new TFind_Mothed_1_Result());

            for (int i = 0; i < Image_Logs.Count; i++)
            {
                Image_Logs[i].No = i;
                TFind_Mothed_1_Result result_mothed1 = Image_Logs[i].Result_Mothed_1;
                if (result_mothed1 != null)
                {
                    result_mothed1.Disp_Param.Msg_X = 20;
                    result_mothed1.Disp_Param.Msg_Y = 50;
                    result_mothed1.Disp_Param.Msg_Font_Size = 16;
                }
            }

        }
        static public void Init_User_Management()
        {
            string fun = "Init_User_Management";
            string filename = "";

            Log_Add(fun, "Init_User_Manabement");
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
        static public void Init_File_Management()
        {
            string fun = "Init_File_Management";
            
            Log_Add(fun, "Init_File_Management");
            File_Manager.Log = TPub.Log;
            File_Manager.Add_Path(Environment.Base.Database_Path + "Log\\");
            File_Manager.Add_Files(Environment.Base.Database_Path + "Log\\", "log");
            File_Manager.Auto_Delete_File = Environment.Log.Auto_Delete_File;
            File_Manager.Days = Environment.Log.Days_Count;
            File_Manager.Delete();
        }
        static public void Update_Environment()
        {
            User_Management.Auto_Logout_Out = Environment.Base.Auto_Log_Out;
            User_Management.Logout_Time = Environment.Base.Auto_Log_Out_Time;
            for (int i = 0; i < Cameras.Length; i++)
            {
                if (Environment.CCDs[i] != null)
                    Cameras[i].Name = string.Format("({0:d}) {1:s}", i + 1, Environment.CCDs[i].Name);
            }

        }
        public static void Init_Printer()
        {
            Log.Add("Init_Printer");
            Printer.Set_Com_Port(Environment.Printer.COM_Port);
            Printer.Log = Log;
            Printer.Enabled = true;
        }
        public static void Init_Reader()
        {
            Log.Add("Init_Reader");
            Reader_2D.Log = Log;
            Reader_2D.Connect = true;

            //Reader_1D.Set_Com_Port(2);
            //Reader_1D.Enabled = true;

            //Reader_test.Host = "192.168.1.5";
            //Reader_test.Connect();

        }
        #endregion

        #region Recipe
        static public void Apply_Recipe()
        {
            Apply_Recipe_To_Pub();
            Apply_Recipe_To_View();
            Apply_Recipe_To_PLC();
        }
        static public void Apply_Recipe_To_Pub()
        {
            Find_Data[0].Find_Mothed_1_Result.JJS_Model.Set(Recipe.Panel.Model_Big.L.JJS_Model);
            Find_Data[1].Find_Mothed_1_Result.JJS_Model.Set(Recipe.Panel.Model_Big.R.JJS_Model);
            Find_Data[2].Find_Mothed_1_Result.JJS_Model.Set(Recipe.Panel.Model_Small.L.JJS_Model);
            Find_Data[3].Find_Mothed_1_Result.JJS_Model.Set(Recipe.Panel.Model_Small.R.JJS_Model);
        }
        static public void Apply_Recipe_To_View()
        {
            TCamera_View view = null;

            #region Camera_View 0
            view = Camera_View[0];
            view.Find_Data_Count = 1;
            for (int i = 0; i < view.Find_Data_Count; i++)
            {
                view.Find_Data[i] = Find_Data[i];
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Name = "標靶" + (i + 1).ToString();
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Font_Size = 20;
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_X = 10;
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Y = 60 + 25 * i;
            }
            #endregion

            #region Camera_View 1
            view = Camera_View[1];
            view.Find_Data_Count = 1;
            for (int i = 0; i < view.Find_Data_Count; i++)
            {
                view.Find_Data[i] = Find_Data[i + 1];
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Name = "標靶" + (i + 1).ToString();
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Font_Size = 20;
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_X = 10;
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Y = 60 + 25 * i;
            }
            #endregion

            #region Camera_View 2
            view = Camera_View[2];
            view.Find_Data_Count = 1;
            for (int i = 0; i < view.Find_Data_Count; i++)
            {
                view.Find_Data[i] = Find_Data[i + 2];
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Name = "標靶" + (i + 1).ToString();
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Font_Size = 20;
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_X = 10;
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Y = 60 + 25 * i;
            }
            #endregion

            #region Camera_View 3
            view = Camera_View[3];
            view.Find_Data_Count = 1;
            for (int i = 0; i < view.Find_Data_Count; i++)
            {
                view.Find_Data[i] = Find_Data[i + 3];
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Name = "標靶" + (i + 1).ToString();
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Font_Size = 20;
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_X = 10;
                view.Find_Data[i].Find_Mothed_1_Result.Disp_Param.Msg_Y = 60 + 25 * i;
            }
            #endregion
        }
        static public void Apply_Recipe_To_PLC()
        {
            int no = 0;
            int axis_no = 0;
            string section = "";
            TJJS_Point p = new TJJS_Point();

            PLC.PLC_Recipe.Recipe_Code = Recipe.Recipe_Code;
            PLC.PLC_Recipe.Recipe_Name = Recipe.Recipe_Name;

            PLC.PLC_Recipe.Box_Load_Supply_Vacc = Recipe.Box_Load.Supply_Vacc;
            PLC.PLC_Recipe.Box_Load_Z = Recipe.Box_Load.Box_Z;
            PLC.PLC_Recipe.Box_Load_X_Num = Recipe.Box_Load.X_Num;
            if (PLC.PLC_Recipe.Box_Load_X_Num <= 1) PLC.PLC_Recipe.Box_Load_X_Num = 1;
            #region 機械參數
            #region 載台/Y
            axis_no = 0;
            section = "載台/Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "入料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "出料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "對位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = Recipe.MS_Param.Get_Value_Double(section, "條碼讀取位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = Recipe.MS_Param.Get_Value_Double(section, "標籤貼附位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = Recipe.MS_Param.Get_Value_Double(section, "初對位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion
            
            #region 載台/Q
            axis_no = 1;
            section = "載台/Q";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "入料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "出料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "對位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = Recipe.MS_Param.Get_Value_Double(section, "條碼讀取位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = Recipe.MS_Param.Get_Value_Double(section, "標籤貼附位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = Recipe.MS_Param.Get_Value_Double(section, "初對位位置"); 
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region CCD/L
            axis_no = 2;
            section = "CCD/L";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "對位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "初對位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region CCD/R
            axis_no = 3;
            section = "CCD/R";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "對位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "初對位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region 載台/D2_X
            axis_no = 4;
            section = "載台/D2_X";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "條碼讀取位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "標籤取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "標籤貼附位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region LD/BOX_X
            axis_no = 5;
            section = "LD/BOX_X";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "靠位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region LD/BOX_Y
            axis_no = 6;
            section = "LD/BOX_Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "靠位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = 0.0;
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
        #endregion

        #region 相機
        static public string Get_CCD_Name(int no)
        {
            string result = "";
            result = Cameras[no].Name;
            return result;
        }
        static public string[] Get_CCD_Name_All()
        {
            string[] result = new string[Cameras.Length];

            for (int i = 0; i < Cameras.Length; i++)
                result[i] = Get_CCD_Name(i);
            return result;
        }
        static public int Get_Camera_No(emCCD_Name ccd_name)
        {
            int result = 0;
            switch (ccd_name)
            {
                case emCCD_Name.Big_L: result = 0; break;
                case emCCD_Name.Big_R: result = 1; break;
                case emCCD_Name.Small_L: result = 2; break;
                case emCCD_Name.Small_R: result = 3; break;
            }
            return result;
        }
        static public emCCD_Name Get_emCCD_Name(int no)
        {
            emCCD_Name result = emCCD_Name.None;

            switch (no)
            {
                case 0: result = emCCD_Name.Big_L; break;
                case 1: result = emCCD_Name.Big_R; break;
                case 2: result = emCCD_Name.Small_L; break;
                case 3: result = emCCD_Name.Small_R; break;
            }
            return result;
        }
        static public emCCD_Name Get_emCCD_Name(emModel model)
        {
            emCCD_Name result = emCCD_Name.None;
            switch (model)
            {
                case emModel.Big_L: result = emCCD_Name.Big_L; break;
                case emModel.Big_R: result = emCCD_Name.Big_R; break;
                case emModel.Small_L: result = emCCD_Name.Small_L; break;
                case emModel.Small_R: result = emCCD_Name.Small_R; break;
            }
            return result;

        }
        static public TCamera_Base Get_Camera(emCCD_Name em_ccd_name)
        {
            TCamera_Base result = null;
            int no = Get_Camera_No(em_ccd_name);

            result = Cameras[no]; 
            return result;
        }
        static public TCamera_Base Get_Camera(emModel model)
        {
            TCamera_Base result = Get_Camera(Get_emCCD_Name(model));
            return result;
        }

        static public void All_Grab_Life()
        {
            for (int i = 0; i < Cameras.Length; i++)
                if (Cameras[i] != null) Cameras[i].Grab_Life();
        }
        static public void All_Grab_Stop()
        {
            for (int i = 0; i < Cameras.Length; i++)
                if (Cameras[i] != null) Cameras[i].Grab_Stop();
        }
        static public void All_Grab_Close()
        {
            for (int i = 0; i < Cameras.Length; i++)
            {
                Cameras[i].Dispose();
            }
        }
        #endregion

        #region Display相關
        public static HImage Get_Image_Log_Image(TImage_Log image_log)
        {
            HImage result = null;

            result = image_log.Image;
            return result;
        }
        public static void Disp(ref TFrame_JJS_HW jjs_hw, int index, bool fore_disp)
        {
            string fun = "Disp";
            TCamera_View view = null;
            HImage image = new HImage();
            double scale = 1;
            int line_width = 1;
            int w, h;

            //hw_buf.HalconWindow.ClearWindow();
            try
            {
                if (index < Camera_View.Length)
                {
                    view = Camera_View[index];
                    //display image
                    view.Camera.Get_HImage(ref image);
                    image.GetImageSize(out w, out h);
                    scale = (double)w / jjs_hw.Width;
                    view.Set_Scale(scale);

                    jjs_hw.SetPart(image);
                    jjs_hw.HW_Buf.HalconWindow.DispObj(image);


                    //display CCD name
                    JJS_Vision.Display_String(jjs_hw.HW_Buf, view.Camera.Name, 10, 10, 25, scale, "blue");

                    //display 畫面十字線
                    line_width = (int)Math.Round(2 * scale + 1, 0);
                    jjs_hw.HW_Buf.HalconWindow.SetLineWidth(line_width);
                    JJS_Vision.Display_Hairline(jjs_hw.HW_Buf, image, "red");

                    //display find data
                    Disp_View_Message(jjs_hw.HW_Buf, view);
                    Disp_View_Model(jjs_hw.HW_Buf, view);

                }
            }
            catch (Exception e) 
            {
                    Log_Add(fun, e.Message, emLog_Type.Error);
            }
            jjs_hw.Copy_HW();
            image.Dispose();
        }
        public static void Disp_View_Message(HWindowControl hw, TCamera_View view)
        {
            for (int i = 0; i < view.Find_Data_Count; i++)
                view.Find_Data[i].Find_Mothed_1_Result.Display_Message(hw);
        }
        public static void Disp_View_Model(HWindowControl hw, TCamera_View view)
        {
            //for (int i = 0; i < view.Find_Data.Length; i++)
            //    JJS_Vision.Display_Hairline(hw, view.Find_Data[i].Edge_Measure.Col, view.Find_Data[i].Find_Mothed1.Row, 30, 0, "yellow");

            view.Find_Data[view.Last_No].Find_Mothed_1_Result.Display_Model(hw);
        }
        public static void Disp_Log(ref TFrame_JJS_HW jjs_hw, int index, bool fore_disp)
        {
            TImage_Log image_log = null;
            HImage tmp_image = null;
            string disp_name = "";
            double scale = 1;
            double line_width = 1;
            int w = 640, h = 480;
            string msg = "";

            image_log = Image_Logs[index];
            if (image_log != null && image_log.Result != null && (image_log.Reflash || fore_disp))
            {
                image_log.Reflash = false;
                tmp_image = Get_Image_Log_Image(image_log);
                if (JJS_Vision.Is_Not_Empty(tmp_image))
                {
                    tmp_image.GetImageSize(out w, out h);
                    jjs_hw.SetPart(tmp_image);
                    jjs_hw.HW_Buf.HalconWindow.DispObj(tmp_image);
                }

                if (jjs_hw.Width > 0) scale = (double)w / jjs_hw.Width;
                image_log.Set_Scale(scale);

                //display result info
                image_log.Result.Display(jjs_hw.HW_Buf);

                //display CCD name
                disp_name = string.Format("({0:d}).{1:s}", image_log.No + 1, image_log.Name);
                JJS_Vision.Display_String(jjs_hw.HW_Buf, disp_name, 10, 10, 20, scale, emSetColor.blue);

                //display 螢幕十字線
                if (JJS_Vision.Is_Not_Empty(tmp_image))
                {
                    line_width = 2 * scale + 1;
                    jjs_hw.HW_Buf.HalconWindow.SetLineWidth((int)line_width);
                    JJS_Vision.Display_Hairline(jjs_hw.HW_Buf, tmp_image, emSetColor.red);
                }

                //check_result = image_log.Result_ACF_Check;
                //if (check_result != null)
                //{
                //    msg = string.Format("SN={0:d}", check_result.SN);
                //    JJS_Vision.Display_String(jjs_hw.HW_Buf, msg, 10, 40, 16, scale, "green");
                //}
                jjs_hw.Copy_HW();
            }
        }
        public static void Reset_All()
        {
            for (int i = 0; i < Find_Data.Length; i++) Find_Data[i].Reset();
        }
        #endregion

        #region 光源
        static public void Set_Light_All_OFF()
        {
            for (int i = 0; i < Light.Channel_Count; i++)
            {
                TPub.Light.Set_Light(i, 0);
            }
        }
        static public void Set_Light_All_ON()
        {
            for (int i = 0; i < Light.Channel_Count; i++)
            {
                TPub.Light.Set_Light(i, Light.Max_Value);
            }
        }
        static public TLight_Channel_List Get_Light_Channels(emModel model)
        {
            TLight_Channel_List result = new TLight_Channel_List();

            switch (model)
            {
                case emModel.Big_L:
                    result.Add(Light_Channels["Panel環光L"]);
                    break;

                case emModel.Big_R:
                    result.Add(Light_Channels["Panel環光R"]);
                    break;

                case emModel.Small_L:
                    result.Add(Light_Channels["Panel同軸L"]);
                    break;

                case emModel.Small_R:
                    result.Add(Light_Channels["Panel同軸R"]);
                    break;
            }
            return result;
        }
        static public bool Set_Light(emModel model)
        {
            bool result = true;
            string fun = "Set_Light";
            
            string tmp_str = "";
            TLight_Channel_List light_channels = new TLight_Channel_List();

            tmp_str = string.Format("[Set_Light] Model={0:s}", model.ToString());
            Log_Add(fun, tmp_str);
            light_channels = Get_Light_Channels(model);

            switch (model)
            {
                case emModel.Small_L: light_channels.Set_Value(Recipe.Panel.Model_Small.Light_L); break;
                case emModel.Small_R: light_channels.Set_Value(Recipe.Panel.Model_Small.Light_R); break;
                case emModel.Big_L: light_channels.Set_Value(Recipe.Panel.Model_Big.Light_L); break;
                case emModel.Big_R: light_channels.Set_Value(Recipe.Panel.Model_Big.Light_R); break;
            }
            for (int i = 0; i < light_channels.Count; i++) light_channels[i].Set_Light();
            return result;
        }
        #endregion

        #region Model
        static public void Get_PLC_Pos(emModel model, ref TJJS_Value_List pos)
        {
            switch (model)
            {
                case emModel.Big_L:
                    pos.Add("X", 0);
                    pos.Add("Y", PLC.PLC_In.Table_Y);
                    pos.Add("Z", 0);
                    pos.Add("Q", PLC.PLC_In.Table_Q);
                    pos.Add("CCD", PLC.PLC_In.CCD_X_L);
                    break;

                case emModel.Big_R:
                    pos.Add("X", 0);
                    pos.Add("Y", PLC.PLC_In.Table_Y);
                    pos.Add("Z", 0);
                    pos.Add("Q", PLC.PLC_In.Table_Q);
                    pos.Add("CCD", PLC.PLC_In.CCD_X_R);
                    break;

                case emModel.Small_L:
                    pos.Add("X", 0);
                    pos.Add("Y", PLC.PLC_In.Table_Y);
                    pos.Add("Z", 0);
                    pos.Add("Q", PLC.PLC_In.Table_Q);
                    pos.Add("CCD", PLC.PLC_In.CCD_X_L);
                    break;

                case emModel.Small_R:
                    pos.Add("X", 0);
                    pos.Add("Y", PLC.PLC_In.Table_Y);
                    pos.Add("Z", 0);
                    pos.Add("Q", PLC.PLC_In.Table_Q);
                    pos.Add("CCD", PLC.PLC_In.CCD_X_R);
                    break;
            }
        }
        static public TCamera_View Get_View(emModel model)
        {
            TCamera_View result = null;
            switch (model)
            {
                case emModel.Big_L: result = Camera_View[0]; break;
                case emModel.Big_R: result = Camera_View[1]; break;
                case emModel.Small_L: result = Camera_View[2]; break;
                case emModel.Small_R: result = Camera_View[3]; break;
            }
            return result;
        }
        static public TFind_Mothed_1_Param Get_Model_Param(emModel model)
        {
            TFind_Mothed_1_Param result = null;
            switch (model)
            {
                case emModel.Big_L: result = Recipe.Panel.Model_Big.L; break;
                case emModel.Big_R: result = Recipe.Panel.Model_Big.R; break;
                case emModel.Small_L: result = Recipe.Panel.Model_Small.L; break;
                case emModel.Small_R: result = Recipe.Panel.Model_Small.R; break;
            }
            return result;
        }
        static public TFind_Data_Result Get_Find_Data(emModel model)
        {
            TFind_Data_Result result = null;
            switch (model)
            {
                case emModel.Big_L: result = Find_Data[0]; break;
                case emModel.Big_R: result = Find_Data[1]; break;
                case emModel.Small_L: result = Find_Data[2]; break;
                case emModel.Small_R: result = Find_Data[3]; break;
            }
            return result;
        }
        static public TImage_Log Get_Log_Data(emModel model)
        {
            TImage_Log result = null;
            switch (model)
            {
                case emModel.Big_L: result = Image_Logs["Big_L"]; break;
                case emModel.Big_R: result = Image_Logs["Big_R"]; break;
                case emModel.Small_L: result = Image_Logs["Small_L"]; break;
                case emModel.Small_R: result = Image_Logs["Small_R"]; break;
            }
            return result;
        }
        static public int Get_Last_No(emModel model)
        {
            int result = 0;
            switch (model)
            {
                case emModel.Big_L: result = 0; break;
                case emModel.Big_R: result = 0; break;
                case emModel.Small_L: result = 0; break;
                case emModel.Small_R: result = 0; break;
            }
            return result;
        }
        static public void Get_Param(emModel model, ref TCamera_View view, ref TFind_Mothed_1_Param param, ref TFind_Data_Result find_data, ref TImage_Log image_log, ref int last_no)
        {
            view = Get_View(model);
            param = Get_Model_Param(model);
            find_data = Get_Find_Data(model);
            image_log = Get_Log_Data(model);
            last_no = Get_Last_No(model);
        }
        static public bool Find(emModel model)
        {
            bool result = false;
            string fun = "Find";
            HImage tmp_image = new HImage();
            HImage tmp_image2 = new HImage();
            TCamera_View view = null;
            TFind_Data_Result find_data = null;
            TImage_Log image_log = null;
            TFind_Mothed_1_Param model_param = null;
            TFind_Mothed_1_Result model_result = null;
            int last_no = 0;
            string title_str = "";

            title_str = string.Format("[Find] Panel_ID={0:s}, Model={1:s} ", Panel_ID, model.ToString());
            Log_Add(fun, title_str);
            Get_Param(model, ref view, ref model_param, ref find_data, ref image_log, ref last_no);
            view.Last_No = last_no;
            if (model_param != null && find_data != null)
            {
                model_result = find_data.Find_Mothed_1_Result;
               
                Get_PLC_Pos(model, ref find_data.Pos);
                view.Camera.Grab_Image(ref tmp_image);

                tmp_image2 = tmp_image.Clone();
                switch (model)
                {
                    case emModel.Big_L: 
                        if (Recipe.Panel.Model_Big.Pre_Process_L_SW) 
                            tmp_image2 = Recipe.Panel.Model_Big.Pre_Process_L.Run_Process(tmp_image2); 
                            break;

                    case emModel.Big_R:
                            if (Recipe.Panel.Model_Big.Pre_Process_L_SW)
                                tmp_image2 = Recipe.Panel.Model_Big.Pre_Process_L.Run_Process(tmp_image2);
                            break;
                }

                model_result.Reset();
                result = model_param.Find_Base(tmp_image2, ref model_result);
                Log_Find_Data(fun, title_str, find_data);
                image_log.Set_Data(tmp_image, model_result);

                tmp_image = DumpWindowImage(tmp_image, image_log);
                Save_Image(tmp_image, model_result.Find_OK, image_log.Name);
            }
            if (!result) Log_Add(fun, title_str + "Find Error.", emLog_Type.Warning);
            return result;
        }
        static public bool Panel_Big_Cal()
        {
            bool result = false;
            string fun = "Panel_Big_Cal";
            string title_str = "";
            emModel em_model_l = emModel.Big_L;
            emModel em_model_r = emModel.Big_R;
            TFind_Data_Result f1 = null;
            TFind_Data_Result f2 = null;
            TFind_Mothed_1_Result f1_mothed1 = null;
            TFind_Mothed_1_Result f2_mothed1 = null;
            TJJS_Point center = new TJJS_Point();
            TJJS_Line target_line = new TJJS_Line();
            TJJS_Line move_line = new TJJS_Line();
            TJJS_Line new_move_line = new TJJS_Line();
            TJJS_Point tmp_p = new TJJS_Point();
            TJJS_Point tmp_p2 = new TJJS_Point();
            TOfs ofs = new TOfs();
            TLimit limit = new TLimit();
            TAlign_Limit align_limit = new TAlign_Limit();
            double dx, dy, dq;
            double len;

            title_str = string.Format("Cal Panel_ID={0:s} ", Panel_ID);
            Log_Add(fun, title_str);

            f1 = Get_Find_Data(em_model_l);
            f2 = Get_Find_Data(em_model_r);

            if (f1 != null) f1_mothed1 = f1.Find_Mothed_1_Result;
            if (f2 != null) f2_mothed1 = f2.Find_Mothed_1_Result;
            if (f1_mothed1 != null && f2_mothed1 != null && f1_mothed1.Find_OK && f2_mothed1.Find_OK)
            {
                center = Teach.Cal_Data.Panel_Big.Center;
                ofs = Recipe.Panel.Ofs;
                limit = Recipe.Panel.Model_Big.Limit_Length;
                align_limit = Recipe.Panel.Align_Limit;

                Log_Find_Data(fun, title_str + "Model1", f1);
                Log_Find_Data(fun, title_str + "Model2", f2);

                //target_line
                target_line.Start = Get_Abs_Pos(em_model_l, Cameras[0].Image_Width / 2, Cameras[0].Image_Height / 2, f1.Pos);
                target_line.End = Get_Abs_Pos(em_model_r, Cameras[1].Image_Width / 2, Cameras[1].Image_Height / 2, f2.Pos);

                //move_line
                move_line.Start = Get_Abs_Pos(em_model_l, f1_mothed1.Col, f1_mothed1.Row, f1.Pos);
                move_line.End = Get_Abs_Pos(em_model_r, f2_mothed1.Col, f2_mothed1.Row, f2.Pos);
                len = move_line.Length();

                //旋轉角度
                dq = (move_line.V.Angle.d - target_line.V.Angle.d) + ofs.Q;

                //旋轉move_line
                new_move_line = move_line.Rotate(center, -dq);

                Log_Add(fun, title_str + string.Format("center = ({0:f3},{1:f3})", center.X, center.Y));
                Log_Line(fun, title_str + "target_line", target_line);
                Log_Line(fun, title_str + "move_line", move_line);
                Log_Line(fun, title_str + "new_move_line", new_move_line);

                //計算誤差X Y
                tmp_p = target_line.Mid - new_move_line.Mid;
                dx = -tmp_p.X + ofs.X;
                dy = -tmp_p.Y + ofs.Y;

                Log_Add(fun, title_str + string.Format("Ofs_X = {0:f3}, Ofs_Y ={1:f3}, Ofs_Q ={2:f3}", ofs.X, ofs.Y, ofs.Q));

                TPub.PLC.PLC_Out.DX = dx;
                TPub.PLC.PLC_Out.DY = dy;
                TPub.PLC.PLC_Out.DQ = dq;
               
                result = true;
                if (!Cal_Length_Limit(fun, title_str, len, limit)) result = false;
                if (!Cal_Align_Limit(fun, title_str, dx, dy, dq, align_limit)) result = false;

                Log_Add(fun, title_str + string.Format(" DX = {0:f3}, DY = {1:f3}, DQ = {2:f4}, Result={3:s}",
                    TPub.PLC.PLC_Out.DX, TPub.PLC.PLC_Out.DY, TPub.PLC.PLC_Out.DQ, result ? "OK" : "NG"));
            }
            else
            {
                Log_Add(fun, title_str + "搜尋標靶錯誤，無法計算.", emLog_Type.Warning);
            }
            if (!result) Log_Add(fun, title_str + "Cal Error.", emLog_Type.Warning);
            return result;
        }
        static public bool Panel_Small_Cal()
        {
            bool result = false;
            string fun = "Cal";
            string title_str = "";
            emModel em_model_l = emModel.Small_L;
            emModel em_model_r = emModel.Small_R;
            TFind_Data_Result f1 = null;
            TFind_Data_Result f2 = null;
            TFind_Mothed_1_Result f1_mothed1 = null;
            TFind_Mothed_1_Result f2_mothed1 = null;
            TJJS_Point center = new TJJS_Point();
            TJJS_Line target_line = new TJJS_Line();
            TJJS_Line move_line = new TJJS_Line();
            TJJS_Line new_move_line = new TJJS_Line();
            TJJS_Point tmp_p = new TJJS_Point();
            TJJS_Point tmp_p2 = new TJJS_Point();
            TOfs ofs = new TOfs();
            TLimit limit = new TLimit();
            double dx, dy, dq;
            double len;

            title_str = string.Format("Cal Panel_ID={0:s} ", Panel_ID);
            Log_Add(fun, title_str);

            f1 = Get_Find_Data(em_model_l);
            f2 = Get_Find_Data(em_model_r);

            if (f1 != null) f1_mothed1 = f1.Find_Mothed_1_Result;
            if (f2 != null) f2_mothed1 = f2.Find_Mothed_1_Result;
            if (f1_mothed1 != null && f2_mothed1 != null && f1_mothed1.Find_OK && f2_mothed1.Find_OK)
            {
                center = Teach.Cal_Data.Panel_Big.Center;
                ofs = Recipe.Panel.Ofs;
                limit = Recipe.Panel.Model_Small.Limit_Length;

                Log_Find_Data(fun, title_str + "Model1", f1);
                Log_Find_Data(fun, title_str + "Model2", f2);

                //target_line
                target_line.Start = Get_Abs_Pos(em_model_l, Cameras[0].Image_Width / 2, Cameras[0].Image_Height / 2, f1.Pos);
                target_line.End = Get_Abs_Pos(em_model_r, Cameras[1].Image_Width / 2, Cameras[1].Image_Height / 2, f2.Pos);

                //move_line
                move_line.Start = Get_Abs_Pos(em_model_l, f1_mothed1.Col, f1_mothed1.Row, f1.Pos);
                move_line.End = Get_Abs_Pos(em_model_r, f2_mothed1.Col, f2_mothed1.Row, f2.Pos);
                len = move_line.Length();

                //旋轉角度
                dq = -(move_line.V.Angle.d - target_line.V.Angle.d) + ofs.Q;

                //旋轉move_line
                new_move_line = move_line.Rotate(center, dq);

                Log_Add(fun, title_str + string.Format("center = ({0:f3},{1:f3})", center.X, center.Y));
                Log_Line(fun, title_str + "target_line", target_line);
                Log_Line(fun, title_str + "move_line", move_line);
                Log_Line(fun, title_str + "new_move_line", new_move_line);

                //計算誤差X Y
                tmp_p = target_line.Mid - new_move_line.Mid;
                dx = tmp_p.X + ofs.X;
                dy = tmp_p.Y + ofs.Y;

                Log_Add(fun, title_str + string.Format("Ofs_X = {0:f3}, Ofs_Y ={1:f3}, Ofs_Q ={2:f3}", ofs.X, ofs.Y, ofs.Q));

                TPub.PLC.PLC_Out.DX = dx;
                TPub.PLC.PLC_Out.DY = dy;
                TPub.PLC.PLC_Out.DQ = dq;

                result = Cal_Length_Limit(fun, title_str, len, limit);

                Log_Add(fun, title_str + string.Format(" DX = {0:f3}, DY = {1:f3}, DQ = {2:f4}, Result={3:s}",
                    TPub.PLC.PLC_Out.DX, TPub.PLC.PLC_Out.DY, TPub.PLC.PLC_Out.DQ, result ? "OK" : "NG"));

            }
            else
            {
                Log_Add(fun, title_str + "搜尋標靶錯誤，無法計算.", emLog_Type.Warning);
            }
            if (!result) Log_Add(fun, title_str + "Cal Error.", emLog_Type.Warning);
            return result;
        }
        static public bool Cal_Length_Limit(string fun, string title_str, double len, TLimit limit)
        {
            bool result = true;

            if (!Cal_Min_Max(fun, title_str + "Length ", len, limit.SW, limit.Min, limit.Max)) result = false;
            return result;
        }
        static public bool Cal_Align_Limit(string fun, string title_str, double dx, double dy, double dq, TAlign_Limit align_limit)
        {
            bool result = true;

            if (!Cal_Min_Max(fun, title_str + "DX ", dx, align_limit.SW_DX, align_limit.DX_Min, align_limit.DX_Max)) result = false;
            if (!Cal_Min_Max(fun, title_str + "DY ", dy, align_limit.SW_DY, align_limit.DY_Min, align_limit.DY_Max)) result = false;
            if (!Cal_Min_Max(fun, title_str + "DQ ", dq, align_limit.SW_DQ, align_limit.DQ_Min, align_limit.DQ_Max)) result = false;
            return result;
        }
        static public bool Cal_Min_Max(string fun, string title_str, double value, bool sw, double min, double max)
        {
            string msg = "";
            bool result = true;

            if (sw)
            {
                msg = title_str + string.Format("Min = {0:f3}, value = {1:f3}, Max = {2:f3}", min, value, max);
                if (value > min && value < max)
                {
                    Log_Add(fun, msg);
                    result = true;
                }
                else
                {
                    Log_Add(fun, msg, emLog_Type.Warning);
                    result = false;
                }
            }
            return result;
        }
        #endregion

        #region 量測相關
        public static TJJS_Point Pixel_To_Pos(int CCD_NO, TJJS_Point in_pixel)
        {
            TJJS_Point result = new TJJS_Point();

            result.X = in_pixel.X * Environment.CCDs[CCD_NO].Pixel_Size_X;
            result.Y = in_pixel.Y * Environment.CCDs[CCD_NO].Pixel_Size_Y;
            return result;
        }
        public static TJJS_Point Get_Abs_Pos(emModel model, double col, double row, TJJS_Value_List pos)
        {
            TJJS_Point result = new TJJS_Point();

            switch (model)
            {
                case emModel.Big_L: result = Get_Abs_Pos_Panel_Big_L(col, row, pos); break;
                case emModel.Big_R: result = Get_Abs_Pos_Panel_Big_R(col, row, pos); break;
                case emModel.Small_L: result = Get_Abs_Pos_Panel_Small_L(col, row, pos); break;
                case emModel.Small_R: result = Get_Abs_Pos_Panel_Small_R(col, row, pos); break;
            }
            return result;
        }
        public static TJJS_Point Get_Abs_Pos_Panel_Big_L(double col, double row, TJJS_Value_List pos)
        {
            TJJS_Point result = new TJJS_Point();
            TJJS_Point tmp = new TJJS_Point();
            emModel model = emModel.Big_L;
            emCCD_Name ccd_name = emCCD_Name.None;
            int ccd_no = 0;
            double x = 0, y = 0, ccd = 0;

            ccd_name = Get_emCCD_Name(model);
            ccd_no = Get_Camera_No(ccd_name);
            x = pos.Get_Value_Double("X");
            y = pos.Get_Value_Double("Y");
            ccd = pos.Get_Value_Double("CCD");
            tmp = Pixel_To_Pos(ccd_no, new TJJS_Point(col - Cameras[ccd_no].Image_Width / 2, row - Cameras[ccd_no].Image_Height / 2));
            result.X = tmp.X - x - ccd;
            result.Y = -tmp.Y - y;
            return result;
        }
        public static TJJS_Point Get_Abs_Pos_Panel_Big_R(double col, double row, TJJS_Value_List pos)
        {
            TJJS_Point result = new TJJS_Point();
            TJJS_Point tmp = new TJJS_Point();
            emModel model = emModel.Big_R;
            emCCD_Name ccd_name = emCCD_Name.None;
            int ccd_no = 0;
            double x = 0, y = 0, ccd = 0;

            ccd_name = Get_emCCD_Name(model);
            ccd_no = Get_Camera_No(ccd_name);
            x = pos.Get_Value_Double("X");
            y = pos.Get_Value_Double("Y");
            ccd = pos.Get_Value_Double("CCD");

            tmp = Pixel_To_Pos(ccd_no, new TJJS_Point(col - Cameras[ccd_no].Image_Width / 2, row - Cameras[ccd_no].Image_Height / 2));
            result.X = tmp.X - x + ccd;
            result.Y = -tmp.Y - y;
            return result;
        }
        public static TJJS_Point Get_Abs_Pos_Panel_Small_L(double col, double row, TJJS_Value_List pos)
        {
            TJJS_Point result = new TJJS_Point();
            TJJS_Point tmp = new TJJS_Point();
            emModel model = emModel.Small_L;
            emCCD_Name ccd_name = emCCD_Name.None;
            int ccd_no = 0;
            double x = 0, y = 0, ccd = 0;

            ccd_name = Get_emCCD_Name(model);
            ccd_no = Get_Camera_No(ccd_name);
            x = pos.Get_Value_Double("X");
            y = pos.Get_Value_Double("Y");
            ccd = pos.Get_Value_Double("CCD");
            tmp = Pixel_To_Pos(ccd_no, new TJJS_Point(col - Cameras[ccd_no].Image_Width / 2, row - Cameras[ccd_no].Image_Height / 2));
            result.X = tmp.X - x - ccd;
            result.Y = -tmp.Y - y;
            return result;
        }
        public static TJJS_Point Get_Abs_Pos_Panel_Small_R(double col, double row, TJJS_Value_List pos)
        {
            TJJS_Point result = new TJJS_Point();
            TJJS_Point tmp = new TJJS_Point();
            emModel model = emModel.Small_R;
            emCCD_Name ccd_name = emCCD_Name.None;
            int ccd_no = 0;
            double x = 0, y = 0, ccd = 0;

            ccd_name = Get_emCCD_Name(model);
            ccd_no = Get_Camera_No(ccd_name);
            x = pos.Get_Value_Double("X");
            y = pos.Get_Value_Double("Y");
            ccd = pos.Get_Value_Double("CCD");

            tmp = Pixel_To_Pos(ccd_no, new TJJS_Point(col - Cameras[ccd_no].Image_Width / 2, row - Cameras[ccd_no].Image_Height / 2));
            result.X = tmp.X - x + ccd;
            result.Y = -tmp.Y - y;
            return result;
        }


        //量測相關 
        static public void Measure_Get_Find_Data(int ccd_no, ref TMeasure_Data m_data)
        {
            emModel model = emModel.None;

            switch (ccd_no)
            {
                case 0: model = emModel.Big_L; break;
                case 1: model = emModel.Big_R; break;
                case 2: model = emModel.Small_L; break;
                case 3: model = emModel.Small_R; break;
            }
            m_data.Param.Clear();
            Get_PLC_Pos(model, ref m_data.Param);
        }
        static public void Measure_CCD_Change(TForm_Measure form, int no)
        {
            HImage image = new HImage();

            form.Camera = Cameras[no];
            image = form.Camera.Get_HImage();
            form.Set_Scale(image);
        }
        static public TJJS_Point Measure_Get_Abs_Pos(int ccd_no, TMeasure_Data m_data)
        {
            TJJS_Point result = new TJJS_Point();
            emModel model = emModel.None;
            
            switch (ccd_no)
            {
                case 0: model = emModel.Big_L; break;
                case 1: model = emModel.Big_R; break;
                case 2: model = emModel.Small_L; break;
                case 3: model = emModel.Small_R; break;
            }
            result = Get_Abs_Pos(model, m_data.Col, m_data.Row, m_data.Param);
            return result;
        }
        #endregion

        #region MU Select 手動選取相關功能
        static public bool MU_Select(emModel model)
        {
            bool result = false;
            string fun = "MU_Select";
            TMU_Select_Data mu_data = new TMU_Select_Data();
            TJJS_Value_List mu_param = new TJJS_Value_List();
            string tmp_str = "";

            tmp_str = string.Format("[MU_Select] Model={0:s}", model.ToString());
            Log_Add(fun, tmp_str);

            Set_MU_Param(ref mu_param, model);
            switch (model)
            {
                case emModel.Big_L:
                    mu_data.Set(model.ToString(), "左Model手動選取中", Get_Camera(model), mu_param);
                    break;

                case emModel.Big_R:
                    mu_data.Set(model.ToString(), "右Model手動選取中", Get_Camera(model), mu_param);
                    break;

                case emModel.Small_L:
                    mu_data.Set(model.ToString(), "左Model手動選取中", Get_Camera(model), mu_param);
                    break;

                case emModel.Small_R:
                    mu_data.Set(model.ToString(), "右Model手動選取中", Get_Camera(model), mu_param);
                    break;
            }
            MU_Data_List.Add(mu_data);
            return result;
        }
        static public void MU_Select_Display(TFrame_JJS_HW jjs_hw, TMU_Select_Data mu_data)
        {
            TCamera_Base camera = null;
            TFind_Data_Result f_result = null;
            emModel model = emModel.None;
            HImage image = new HImage();
            double scale = 1;
            int line_width = 1;
            int w, h;


            Get_MU_Data(mu_data, ref camera, ref f_result, ref model);

            //hw_buf.HalconWindow.ClearWindow();
            try
            {
                //display image
                mu_data.Camera.Get_HImage(ref image);
                image.GetImageSize(out w, out h);
                if (jjs_hw.Width > 0) scale = (double)w / jjs_hw.Width;
                //f_result.Find_Mothed_1_Result.Set_Scale(scale);

                jjs_hw.SetPart(image);
                jjs_hw.HW_Buf.HalconWindow.DispObj(image);

                //display 畫面十字線
                line_width = (int)Math.Round(2 * scale + 1, 0);
                jjs_hw.HW_Buf.HalconWindow.SetLineWidth(line_width);
                JJS_Vision.Display_Hairline(jjs_hw.HW_Buf, image, "red");

                //display find data
                f_result.Find_Mothed_1_Result.Disp_Param.Scale = scale * 2;
                f_result.Find_Mothed_1_Result.Display(jjs_hw.HW_Buf);
            }
            catch { }
        }
        static public void MU_Select_Get_Find_Data(TMU_Select_Data mu_data)
        {
            TCamera_Base camera = null;
            TFind_Data_Result f_result = null;
            emModel model = emModel.None;

            Get_MU_Data(mu_data, ref camera, ref f_result, ref model);
            if (f_result != null)
            {
                Get_PLC_Pos(model, ref f_result.Pos);
                if (f_result!= null)
                {
                    f_result.Find_Mothed_1_Result.Find_OK = true;
                    f_result.Find_Mothed_1_Result.Col = mu_data.Col;
                    f_result.Find_Mothed_1_Result.Row = mu_data.Row;
                    f_result.Find_Mothed_1_Result.Score = 0.99;
                    f_result.Find_Mothed_1_Result.Angle = 0;
                    f_result.Find_Mothed_1_Result.Reflash = true;
                }
            }
        }
        static public void MU_Select_Get_Finish(TMU_Select_Data mu_data)
        {
            TCamera_Base camera = null;
            TFind_Data_Result f_result = null;
            emModel model = emModel.None;
            TCamera_View view = null;

            Get_MU_Data(mu_data, ref camera, ref f_result, ref model);
            view = Get_View(model);
            view.Last_No = Get_Last_No(model);
            switch (model)
            {
                case emModel.Big_L:
                    TPub.PLC.PLC_Out.Panel_Big_L_MU_Grab.Finish = true;
                    TPub.PLC.PLC_Out.Panel_Big_L_MU_Grab.OK = mu_data.Select_OK;
                    break;

                case emModel.Big_R:
                    TPub.PLC.PLC_Out.Panel_Big_R_MU_Grab.Finish = true;
                    TPub.PLC.PLC_Out.Panel_Big_R_MU_Grab.OK = mu_data.Select_OK;
                    break;

                case emModel.Small_L:
                    TPub.PLC.PLC_Out.Panel_Small_L_MU_Grab.Finish = true;
                    TPub.PLC.PLC_Out.Panel_Small_L_MU_Grab.OK = mu_data.Select_OK;
                    break;

                case emModel.Small_R:
                    TPub.PLC.PLC_Out.Panel_Small_R_MU_Grab.Finish = true;
                    TPub.PLC.PLC_Out.Panel_Small_R_MU_Grab.OK = mu_data.Select_OK;
                    break;
            }
            mu_data.Select = false;
        }
        static public void Set_MU_Param(ref TJJS_Value_List mu_param, emModel model)
        {
            mu_param.Add("Model", model);
        }
        static public void Get_MU_Data(TMU_Select_Data mu_data, ref TCamera_Base camera, ref TFind_Data_Result f_result, ref emModel model)
        {
            TJJS_Value value = null;

            camera = mu_data.Camera;

            value = mu_data.Param.Get_Value("Model");
            if (value != null) model = (emModel)value.Value;
            f_result = Get_Find_Data(model);
        }
        #endregion

        #region Log
        static public void Log_Find_Data(string fun, string title, TFind_Data_Result find_data)
        {
            string pos_str = "";
            for (int i = 0; i < find_data.Pos.Count; i++)
                pos_str = pos_str + ", " + find_data.Pos[i].Name + "=" + find_data.Pos[i].Get_Value_Double().ToString("0.000");

            if (find_data.Mode == 0)
            {
                Log_Add(fun, string.Format("{0:s} Col={1:f1} Row={2:f1} result={3:s} {4:s}.",
                                       title, find_data.Find_Mothed_1_Result.Col, find_data.Find_Mothed_1_Result.Row, find_data.Find_Mothed_1_Result.Find_OK ? "OK" : "NG",
                                       pos_str));
            }

        }
        static public void Log_Line(string fun, string title, TJJS_Line line)
        {
            Log_Add(fun, string.Format("{0:s} S({1:f3},{2:f3}), E({3:f3},{4:f3}) Len={5:f3} angle={6:f4}",
                                   title, line.Start.X, line.Start.Y, line.End.X, line.End.Y, line.Length(), line.V.Angle.d));
        }


        static public string Get_Log_Path(bool f_result)
        {
            string result = "";
            System.DateTime dt;
            string date_str = "";
            string find_str = "";

            dt = System.DateTime.Now;
            date_str = dt.ToString("yyyy_MM_dd");

            if (f_result) find_str = "Image_OK";
            else find_str = "Image_NG";

            result = Environment.Base.Database_Path + "Log\\" + date_str + "\\" + Panel_ID + "\\" + find_str + "\\";
            return result;
        }
        static public string Get_Log_File_Name(string title_str)
        {
            string result = "";
            System.DateTime dt;
            string time_str = "";

            dt = System.DateTime.Now;
            time_str = dt.ToString("_hh_mm_ss") + string.Format("_{0:d3}", dt.Millisecond);
            result = title_str + time_str + Get_Log_File_Ext();
            return result;
        }
        static public string Get_Log_File_Ext()
        {
            string result = ".jpg";

            //if (Environment.Log.Save_Image_Type == "BMP") result = result + ".bmp";
            //if (Environment.Log.Save_Image_Type == "JPG") result = result + ".jpg";
            return result;
        }
        static public string Get_Log_Full_File_Name(bool f_result, string title_str)
        {
            string result = "";
            result = Get_Log_Path(f_result) + Get_Log_File_Name(title_str);
            return result;
        }
        static public void Save_Image(HImage in_image, bool f_result, string log_name)
        {
            string filename = Get_Log_Full_File_Name(f_result, log_name);

            if ((f_result && Environment.Log.Save_OK_Image) ||
                (!f_result && Environment.Log.Save_NG_Image))
                Save_Image(in_image, filename);
        }
        static public void Save_Image(HImage in_image, string filename)
        {
            JJS_Vision.Write_File(in_image, filename);
        }

        static public HImage DumpWindowImage(HImage in_image, TImage_Log f_result)
        {
            HImage result = new HImage();
            HWindowControl hw = new HWindowControl();
            TImage_Log tmp_result = new TImage_Log();

            if (JJS_Vision.Is_Not_Empty(in_image))
            {
                tmp_result.Set(f_result);
                tmp_result.Set_Scale(1);
                JJS_Vision.Set_HW_Size(hw, in_image);
                JJS_Vision.SetPart(hw, in_image);
                hw.HalconWindow.DispObj(in_image);
                tmp_result.Display_Message(hw);
                tmp_result.Display_Model(hw);
                result = hw.HalconWindow.DumpWindowImage();
            }
            return result;
        }
        #endregion

        #region Printer
        static public Printer_Format Get_Printer_Format1()
        {
            Printer_Format result = new Printer_Format();
            TZebra_Value_List tmp_list = new TZebra_Value_List();
            string date_str = "";
            string time_str = "";

            result.Set(Recipe.Printer.Format1);
            result.Cut_Comment();
            tmp_list.Set(Recipe.Printer.Value_List);

            date_str = DateTime.Now.ToString(tmp_list.Get_Value("%DATE%"));
            tmp_list.Set_Value("%DATE%", date_str);

            time_str = DateTime.Now.ToString(tmp_list.Get_Value("%TIME%"));
            tmp_list.Set_Value("%TIME%", time_str);

            result.Replace_Value(tmp_list);

            return result;
        }
        static public Printer_Format Get_Printer_Format2()
        {
            Printer_Format result = new Printer_Format();

            result.Set(Recipe.Printer.Format2);
            result.Cut_Comment();
            result.Replace_Value(Recipe.Printer.Value_List);

            return result;
        }
        static public bool Printer_Label1()
        {
            bool result = false;
            Printer_Format format = Get_Printer_Format1();

            result = Printer.Write_String(format);
            return result;
        }
        static public bool Printer_Label2()
        {
            bool result = false;
            Printer_Format format = Get_Printer_Format2();

            result = Printer.Write_String(format);
            return result;
        }
        #endregion

        #region Other
        static public bool Barcode_Read(ref string read_str)
        {
            bool result = false;
            string fun = "Barcode_Read";
            string msg = "";

            if (Reader_2D.Get_Code(ref read_str))
            {
                Panel_ID = read_str;
                //Recipe.Printer.Value_List.Set_Value("%PANEL_ID%", read_str);
                result = true;
            }
            else
            {
                msg = "Barcode_Read Error";
                Log_Add(fun, msg, emLog_Type.Error);
            }
            return result;
        }
        static public int Get_Max_Int(double x, double block_x)
        {
            int result = 0;
            result = (int)(x / block_x);

            if (result * block_x != x) result = result + 1;
            return result;
        }
        #endregion
    }

    //-----------------------------------------------------------------------------------------------------
    // TCamera_View
    //-----------------------------------------------------------------------------------------------------
    public class TCamera_View
    {
        public TCamera_Base Camera = null;
        public int Last_No = 0;
        public TFind_Data_Result[] Find_Data = new TFind_Data_Result[0];
 
        public int Find_Data_Count
        {
            get
            {
                return Find_Data.Length;
            }
            set
            {
                int old_count;

                old_count = Find_Data.Length;
                Array.Resize(ref Find_Data, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Find_Data[i] = new TFind_Data_Result();
                }
            }
        }
        public TCamera_View()
        {
        }
        public void Set_Scale(double scale)
        {
            for (int i = 0; i < Find_Data.Length; i++)
            {
                Find_Data[i].Set_Scale(scale);
            }
        }

    }

    //-----------------------------------------------------------------------------------------------------
    // TFind_Data_Result
    //-----------------------------------------------------------------------------------------------------
    public class TFind_Data_Result : TBase_Class
    {
        public TJJS_Value_List Pos = new TJJS_Value_List();
        public int Mode = 0;
        public TFind_Mothed_1_Result Find_Mothed_1_Result = new TFind_Mothed_1_Result();


        public TBase_Result Result
        {
            get
            {
                TBase_Result result = Find_Mothed_1_Result;

                switch (Mode)
                {
                    case 0: result = Find_Mothed_1_Result; break;
                }
                return result;
            }
        }
        public bool Find_OK
        {
            get
            {
                return Result.Find_OK;
            }
        }
        public TFind_Data_Result()
        {
        }
        override public TBase_Class New_Class()
        {
            return new TFind_Data_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Data_Result && dis_base is TFind_Data_Result)
            {
                TFind_Data_Result sor = (TFind_Data_Result)sor_base;
                TFind_Data_Result dis = (TFind_Data_Result)dis_base;
                dis.Pos.Set(sor.Pos);
                dis.Result.Set(sor.Result);
            }
        }

        public void Reset()
        {
            Result.Reset();
        }
        public void Set_Scale(double scale)
        {
            Find_Mothed_1_Result.Disp_Param.Scale = scale;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TImage_Logs
    //-----------------------------------------------------------------------------------------------------
    public class TImage_Logs
    {
        public TImage_Log[] Items = new TImage_Log[0];

        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count = Items.Length;
                Array.Resize(ref Items, value);
                for (int i = old_count; i < value; i++)
                {
                    Items[i] = new TImage_Log();
                }
            }
        }
        public TImage_Log this[int index]
        {
            get
            {
                TImage_Log result = null;

                if (index >= 0 && index < Items.Length)
                {
                    result = Items[index];
                }
                return result;
            }
        }
        public TImage_Log this[string name]
        {
            get
            {
                TImage_Log result = null;
                int index = Get_Index(name);

                return this[index];
            }
        }
        public TImage_Logs(int count = 0)
        {
            Count = count;
            for (int i = 0; i < Count; i++) Items[i].Name = string.Format("({0:d2})", i + 1);
        }
        public void Set_Data(string name, TBase_Result result)
        {
            TImage_Log image_log = this[name];
            if (image_log != null)
            {
                image_log.Set_Result(result);
            }
        }
        public int Get_Index(string name)
        {
            int result = -1;

            for (int i = 0; i < Items.Length; i++)
            {
                if (name == Items[i].Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public TImage_Log Get_Image_Log(emModel model)
        {
            TImage_Log result = null;

            result = this[model.ToString()];
            return result;
        }
        public TFind_Mothed_1_Result Get_Result_Mothed_1(emModel model)
        {
            TFind_Mothed_1_Result result = null;
            TImage_Log image_log = null;

            image_log = Get_Image_Log(model);
            if (image_log != null)
            {
                result = image_log.Result_Mothed_1;
            }
            return result;
        }
    }
    public class TImage_Log : TBase_Class
    {
        public string Name = "";
        public int No = 0;
        public HImage Image = new HImage();
        public TBase_Result Result = null;

        public bool Reflash
        {
            get
            {
                return Result.Reflash;
            }
            set
            {
                Result.Reflash = value;
            }
        }
        public TFind_Mothed_1_Result Result_Mothed_1
        {
            get
            {
                TFind_Mothed_1_Result result = null;

                if (Result != null && Result is TFind_Mothed_1_Result)
                {
                    result = (TFind_Mothed_1_Result)Result;
                }
                return result;
            }
        }
        public TImage_Log()
        {
            Name = "default";
            Image.GenImageConst("byte", 640, 480);
        }
        override public TBase_Class New_Class()
        {
            return new TImage_Log();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TImage_Log && dis_base is TImage_Log)
            {
                TImage_Log sor = (TImage_Log)sor_base;
                TImage_Log dis = (TImage_Log)dis_base;

                dis.Name = sor.Name;
                JJS_Vision.Copy_Obj(sor.Image, ref dis.Image);
                dis.Result = (TBase_Result)sor.Result.Copy();
                dis.Reflash = sor.Reflash;
            }
        }
        public void Set_Data(string name, TBase_Result result)
        {
            Name = name;
            Set_Result(result);
        }
        public void Set_Data(HImage in_image, TBase_Result result)
        {
            JJS_Vision.Copy_Obj(in_image, ref Image);
            Set_Result(result);
        }
        public void Set_Result(TBase_Result result)
        {
            Result = (TBase_Result)result.Copy();
            Result.Reflash = true;
        }

        public void Reset()
        {
            Result.Reset();
        }
        public void Display_Message(HWindowControl hw)
        {
            Result.Display_Message(hw);
        }
        public void Display_Model(HWindowControl hw)
        {
            Result.Display_Model(hw);
        }
        public void Set_Scale(double scale)
        {
            if (Result_Mothed_1 != null)
                Result_Mothed_1.Disp_Param.Scale = scale;

            //if (Result_ACF_Check != null)
            //    Result_ACF_Check.Disp_Param.Scale = scale;
        }
    }

}
