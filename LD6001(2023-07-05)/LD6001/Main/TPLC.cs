using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Tool;
using EFC.PLC;
using EFC.PLC.Melsec; 

namespace Main
{
    public delegate void evPLC_No_Thread_Run(string name);

    public class TPLC
    {
        public TMelsec_QPLC_Eth_Connect          PLC_Socket = new TMelsec_QPLC_Eth_Connect();      
        public TPLC_Data_In                      PLC_In = new TPLC_Data_In();
        public TPLC_Data_Out                     PLC_Out = new TPLC_Data_Out();
        public TPLC_Data_Recipe                  PLC_Recipe = new TPLC_Data_Recipe();
        private Thread                           Main_Thread = null;

        private TLog                             in_Log = null;
        public string                            Log_Source = "TPLC";
        private bool                             Terminate = false;
        private bool                             Thread_ON = false;
        private double                           in_Scan_Time;
        private System.Diagnostics.Stopwatch     Watch = new System.Diagnostics.Stopwatch();


        public TLog Log
        {
            get
            {
                return in_Log;
            }
            set
            {
                in_Log = value;
                PLC_Socket.Log = value; 
            }
        }
        public double Scan_Time
        {
            get
            {
                return in_Scan_Time;
            }
        }
        public TPLC()
        {
            Main_Thread = new Thread(Thread_Start);
        }
        public void Dispose()
        {
            Stop();
            PLC_Socket.Dispose();
        }
        public void Log_Add(string fun, string msg,emLog_Type type = emLog_Type.Generally)
        {
            if (in_Log != null) in_Log.Add(Log_Source, fun, msg, type);
        }
        public void Start()
        {
            Main_Thread.Start();
        }
        public void Stop()
        {
            Terminate = true;
            while (Thread_ON)
            {
                Application.DoEvents();
            }
        }
        public void Thread_Start()
        {
            Thread_ON = true;
            while (!Terminate)
            {
                Watch.Reset();
                Watch.Start();

                PLC_Out.On_Line = !PLC_Out.On_Line;

                Read_From_PLC();
                Write_To_PLC();
                No_Thread_Add(PLC_In.Write_Recipe_Req, PLC_Out.Write_Recipe, "Write_Recipe", Write_Recipe);
                Thread.Sleep(10);

                Watch.Stop();
                in_Scan_Time = Watch.Elapsed.TotalMilliseconds;
            }
            Thread_ON = false;
        }
        private void Read_From_PLC()
        {
            string fun = "Read_From_PLC";

            if (PLC_Socket.Connect)
            {
                if (!PLC_In.Read(PLC_Socket))
                    Log_Add(fun,"[PLC] Read_From_PLC Error.", emLog_Type.Error);
            }
        }
        private void Write_To_PLC()
        {
            string fun = "Write_To_PLC";

            if (PLC_Socket.Connect)
            {
                if (!PLC_Out.Write(PLC_Socket))
                    Log_Add(fun, "[PLC] Write_To_PLC Error.", emLog_Type.Error);
            }
        }
        private void No_Thread_Add(bool req, TPLC_CMD_Data cmd, string name, evPLC_No_Thread_Run run_fun)
        {
            if (req && !cmd.Running && !cmd.Finish)
            {
                cmd.Running = true;
                run_fun(name);
            }
            else if (!req)
            {
                cmd.Running = false;
                cmd.Finish = false;
                cmd.OK = false;
            }
        }
        private void Write_Recipe(string name)
        {
            string fun = "Write_Recipe";
            
            if (PLC_Socket.Connect)
            {
                if (PLC_In.Can_Change_Recipe)
                {
                    if (PLC_Recipe.Write(PLC_Socket))
                    {
                        PLC_Out.Write_Recipe.OK = true;
                        Log_Add(fun, "[PLC] PLC Recipe更新完成");
                    }
                    else
                    {
                        PLC_Out.Write_Recipe.OK = false;
                        Log_Add(fun, "[PLC] PLC Recipe更新失敗", emLog_Type.Error);
                    }
                }
                else
                {
                    PLC_Out.Write_Recipe.OK = false;
                    Log_Add(fun, "[PLC] PLC Recipe無法更新,請確認PLC狀態.", emLog_Type.Warning);
                }
            }
            else
            {
                PLC_Out.Write_Recipe.OK = false;
                Log_Add(fun, "[PLC] PLC  未連線, PLC Recipe更新失敗", emLog_Type.Warning);
            }
            PLC_Out.Write_Recipe.Finish = true;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TPLC_Data_In
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_Data_In : TPLC_Base_Data
    {
        public bool Write_Recipe_Req = false;
        public bool Can_Change_Recipe = false;
        public bool Set_Light_All_OFF_Req = false;
        public bool Barcode_Read_Req = false;
        public bool Printer_Label1_Req = false;
        public bool Printer_Label2_Req = false;
        public bool BR_live = false;

        public TPLC_Data_In_CIM_Data CIM_Data = new TPLC_Data_In_CIM_Data();


        #region Panel_Big
        public bool Panel_Big_L_Set_Light_Req;
        public bool Panel_Big_R_Set_Light_Req;
        public bool Panel_Big_L_Grab_Req;
        public bool Panel_Big_R_Grab_Req;
        public bool Panel_Big_L_MU_Grab_Req;
        public bool Panel_Big_R_MU_Grab_Req;
        public bool Panel_Big_Cal_Req;
        #endregion

        #region Panel_Small
        public bool Panel_Small_L_Set_Light_Req;
        public bool Panel_Small_R_Set_Light_Req;
        public bool Panel_Small_L_Grab_Req;
        public bool Panel_Small_R_Grab_Req;
        public bool Panel_Small_L_MU_Grab_Req;
        public bool Panel_Small_R_MU_Grab_Req;
        public bool Panel_Small_Cal_Req;
        #endregion

        public double Table_Y;
        public double Table_Q;
        public double CCD_X_L;
        public double CCD_X_R;
        public double Box_X;
        public double Box_Y;
        public double Robot_X;
        public double Robot_Y;
        public double Robot_Q;
        public double Table_D2_X;

        public double Panel_Ofs_X;
        public double Panel_Ofs_Y;
        public double Panel_Ofs_Q;

        public TPLC_Data_In()
        {
        }
        public bool Read(TMelsec_QPLC_Eth_Connect plc)
        {
            bool result = false;
            ushort[] read_data = new ushort[Count];
            if (plc.Connect)
            {
                int c = Max_Count;
                result = plc.Read_Byte(Start_Code, ref read_data, Count);
                Array.Copy(read_data, 0, Data, 0, Count);
            }
            Update();
            return result;
        }
        override public void Update() 
        {
            #region Bit
            #region Main
            Can_Change_Recipe = PLC_Data_Tool.Get_Bit(Data, 0, 1);
            Set_Light_All_OFF_Req = PLC_Data_Tool.Get_Bit(Data, 0, 2);
            BR_live = PLC_Data_Tool.Get_Bit(Data, 0, 6);
            #endregion

            #region Panel_Small
            Panel_Small_L_Set_Light_Req = PLC_Data_Tool.Get_Bit(Data, 2, 0);
            Panel_Small_R_Set_Light_Req = PLC_Data_Tool.Get_Bit(Data, 2, 1);
            Panel_Small_L_Grab_Req      = PLC_Data_Tool.Get_Bit(Data, 2, 2);
            Panel_Small_R_Grab_Req      = PLC_Data_Tool.Get_Bit(Data, 2, 3);
            Panel_Small_L_MU_Grab_Req   = PLC_Data_Tool.Get_Bit(Data, 2, 4);
            Panel_Small_R_MU_Grab_Req   = PLC_Data_Tool.Get_Bit(Data, 2, 5);
            Panel_Small_Cal_Req         = PLC_Data_Tool.Get_Bit(Data, 2, 6);
            #endregion

            Barcode_Read_Req = PLC_Data_Tool.Get_Bit(Data, 3, 0);
            Printer_Label1_Req = PLC_Data_Tool.Get_Bit(Data, 4, 0);
            //Printer_Label2_Req = PLC_Data_Tool.Get_Bit(Data, 4, 5);
            

            #region Panel_Big
            Panel_Big_L_Set_Light_Req = PLC_Data_Tool.Get_Bit(Data, 5, 0);
            Panel_Big_R_Set_Light_Req = PLC_Data_Tool.Get_Bit(Data, 5, 1);
            Panel_Big_L_Grab_Req      = PLC_Data_Tool.Get_Bit(Data, 5, 2);
            Panel_Big_R_Grab_Req      = PLC_Data_Tool.Get_Bit(Data, 5, 3);
            Panel_Big_L_MU_Grab_Req   = PLC_Data_Tool.Get_Bit(Data, 5, 4);
            Panel_Big_R_MU_Grab_Req   = PLC_Data_Tool.Get_Bit(Data, 5, 5);
            Panel_Big_Cal_Req         = PLC_Data_Tool.Get_Bit(Data, 5, 6);
            #endregion
            #endregion

            #region Word
            #region Pos
            Table_Y = PLC_Data_Tool.Get_DWord(Data, 10, 3);
            Table_Q = PLC_Data_Tool.Get_DWord(Data, 12, 3);
            CCD_X_L = PLC_Data_Tool.Get_DWord(Data, 14, 3);
            CCD_X_R = PLC_Data_Tool.Get_DWord(Data, 16, 3);
            Box_X = PLC_Data_Tool.Get_DWord(Data, 18, 3);
            Box_Y = PLC_Data_Tool.Get_DWord(Data, 20, 3);
            Robot_X = PLC_Data_Tool.Get_DWord(Data, 22, 3);
            Robot_Y = PLC_Data_Tool.Get_DWord(Data, 24, 3);
            Robot_Q = PLC_Data_Tool.Get_DWord(Data, 26, 3);
            Table_D2_X = PLC_Data_Tool.Get_DWord(Data, 28, 3);
            #endregion

            #region Ofs
            Panel_Ofs_X = PLC_Data_Tool.Get_DWord(Data, 30, 3);
            Panel_Ofs_Y = PLC_Data_Tool.Get_DWord(Data, 32, 3);
            Panel_Ofs_Q = PLC_Data_Tool.Get_DWord(Data, 34, 3);
            #endregion

            #region CIM_Data
            CIM_Data.Code = PLC_Data_Tool.Get_String(Data, 50, 20).Trim();//取得當前CIM資訊(Barcode)
            CIM_Data.Year = PLC_Data_Tool.Get_DWord(Data, 70);
            CIM_Data.Date = PLC_Data_Tool.Get_DWord(Data, 72);
            CIM_Data.Lot_ID = PLC_Data_Tool.Get_String(Data, 74, 10);
            CIM_Data.WORK_ID = PLC_Data_Tool.Get_String(Data, 84, 10);
            CIM_Data.Ver = PLC_Data_Tool.Get_DWord(Data, 94);

            TPub.Recipe.Printer.Value_List.Set_Value("%LOT_ID%", CIM_Data.Lot_ID);
            TPub.Recipe.Printer.Value_List.Set_Value("%CODE_CIM%", CIM_Data.Code);
            TPub.Recipe.Printer.Value_List.Set_Value("%WO_ID%", CIM_Data.WORK_ID);
            TPub.Recipe.Printer.Value_List.Set_Value("%VER%", CIM_Data.Ver.ToString());
            #endregion
            #endregion
        }
        public void View_Data()
        {
            TForm_Data_View form = new TForm_Data_View();
            form.Set_Param(this, TPub.Environment.Base.Database_Path + "In.csv");
            form.ShowDialog();
        }
    }
    public class TPLC_Data_In_CIM_Data  
    {
        public string Code = "";     //Code
        public int Year = 0;         //年份
        public int Date = 0;         //日期
        public string Lot_ID = "";   //Lot_ID
        public string WORK_ID = "";  //WORK_ID
        public int Ver = 0;          //版本

        public string Year_Str
        {
            get
            {
                return Year.ToString();
            }
        }
        public string Date_Str
        {
            get
            {
                return Date.ToString();
            }
        }
        public string Ver_Str
        {
            get
            {
                return Ver.ToString();
            }
        }
        public TPLC_Data_In_CIM_Data()
        {

        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TPLC_Data_Out
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_Data_Out : TPLC_Base_Data
    {
        #region Main
        public bool On_Line;
        public TPLC_CMD_Data Set_Light_All_OFF = new TPLC_CMD_Data();
        public TPLC_CMD_Data Write_Recipe = new TPLC_CMD_Data();
        public TPLC_CMD_Data Barcode_Read = new TPLC_CMD_Data();
        public TPLC_CMD_Data Printer_Label1 = new TPLC_CMD_Data();
        public TPLC_CMD_Data Printer_Label2 = new TPLC_CMD_Data();
        public string Barcode = "";
        #endregion

        public bool Printer_Ready;
        public bool Printer_Paper_Out;
        public bool Printer_Pause;
        public bool Printer_Ribbon_Out;

        #region Panel_Big
        public TPLC_CMD_Data Panel_Big_L_Set_Light = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Big_R_Set_Light = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Big_L_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Big_R_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Big_L_MU_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Big_R_MU_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Big_Cal = new TPLC_CMD_Data();
        #endregion

        #region Panel_Small
        public TPLC_CMD_Data Panel_Small_L_Set_Light = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Small_R_Set_Light = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Small_L_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Small_R_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Small_L_MU_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Small_R_MU_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data Panel_Small_Cal = new TPLC_CMD_Data();
        #endregion

        public double DX;
        public double DY;                 
        public double DQ;
        public double Tray_Weight;

        
        public TPLC_Data_Out()
        {
        }
        public bool Write(TMelsec_QPLC_Eth_Connect plc)
        {
            bool result = false;

            Update();
            if (plc.Connect)
            {
                result = plc.Write_Byte(Start_Code, Data, Count);
            }
            return result;
        }
        override public void Update()
        {
            Printer_Ready = TPub.Printer.Status.Ready;
            Printer_Pause = TPub.Printer.Status.Pause;
            Printer_Paper_Out = TPub.Printer.Status.Paper_Out;
            Printer_Ribbon_Out = TPub.Printer.Status.Ribbon_Out;

            #region Bit
            #region Main
            PLC_Data_Tool.Set_Bit(Data, 0, 00, On_Line);
            PLC_Data_Tool.Set_Bit(Data, 0, 01, Write_Recipe.Finish);
          
            PLC_Data_Tool.Set_Bit(Data, 0, 02, Set_Light_All_OFF.Finish);
            PLC_Data_Tool.Set_Bit(Data, 1, 02, Set_Light_All_OFF.OK);
            #endregion

            #region Panel_Small
            PLC_Data_Tool.Set_Bit(Data, 4, 00, Panel_Small_L_Set_Light.Finish);
            PLC_Data_Tool.Set_Bit(Data, 4, 01, Panel_Small_R_Set_Light.Finish);
            PLC_Data_Tool.Set_Bit(Data, 4, 02, Panel_Small_L_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 4, 03, Panel_Small_R_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 4, 04, Panel_Small_L_MU_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 4, 05, Panel_Small_R_MU_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 4, 06, Panel_Small_Cal.Finish);
                                                    
            PLC_Data_Tool.Set_Bit(Data, 5, 00, Panel_Small_L_Set_Light.OK);
            PLC_Data_Tool.Set_Bit(Data, 5, 01, Panel_Small_R_Set_Light.OK);
            PLC_Data_Tool.Set_Bit(Data, 5, 02, Panel_Small_L_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 5, 03, Panel_Small_R_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 5, 04, Panel_Small_L_MU_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 5, 05, Panel_Small_R_MU_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 5, 06, Panel_Small_Cal.OK);
            #endregion

            PLC_Data_Tool.Set_Bit(Data, 6, 00, Barcode_Read.Finish);
            PLC_Data_Tool.Set_Bit(Data, 7, 00, Barcode_Read.OK);

            PLC_Data_Tool.Set_Bit(Data, 8, 00, Printer_Label1.Finish);
            PLC_Data_Tool.Set_Bit(Data, 8, 02, Printer_Paper_Out);
            PLC_Data_Tool.Set_Bit(Data, 8, 03, Printer_Pause);
            PLC_Data_Tool.Set_Bit(Data, 8, 04, Printer_Ribbon_Out);
            
            PLC_Data_Tool.Set_Bit(Data, 9, 00, Printer_Label1.OK);

            #region Panel_Big
            PLC_Data_Tool.Set_Bit(Data, 10, 00, Panel_Big_L_Set_Light.Finish);
            PLC_Data_Tool.Set_Bit(Data, 10, 01, Panel_Big_R_Set_Light.Finish);
            PLC_Data_Tool.Set_Bit(Data, 10, 02, Panel_Big_L_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 10, 03, Panel_Big_R_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 10, 04, Panel_Big_L_MU_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 10, 05, Panel_Big_R_MU_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 10, 06, Panel_Big_Cal.Finish);

            PLC_Data_Tool.Set_Bit(Data, 11, 00, Panel_Big_L_Set_Light.OK);
            PLC_Data_Tool.Set_Bit(Data, 11, 01, Panel_Big_R_Set_Light.OK);
            PLC_Data_Tool.Set_Bit(Data, 11, 02, Panel_Big_L_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 11, 03, Panel_Big_R_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 11, 04, Panel_Big_L_MU_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 11, 05, Panel_Big_R_MU_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 11, 06, Panel_Big_Cal.OK);
            #endregion
            #endregion

            #region Word
            #region Ofs
            PLC_Data_Tool.Set_DWord(Data, 20, 3, DX);
            PLC_Data_Tool.Set_DWord(Data, 22, 3, DY);
            PLC_Data_Tool.Set_DWord(Data, 24, 3, DQ);
            PLC_Data_Tool.Set_DWord(Data, 26, 3, Tray_Weight);
            #endregion

            PLC_Data_Tool.Set_String(Data, 50, 20, Barcode);
            #endregion
        }
        public void View_Data()
        {
            TForm_Data_View form = new TForm_Data_View();
            form.Set_Param(this, TPub.Environment.Base.Database_Path + "Out.csv");
            form.ShowDialog();
        }
    }
    
    public class TPLC_CMD_Data
    {
        public bool Running;
        public bool Finish;
        public bool OK;
    }

    //-----------------------------------------------------------------------------------------------------
    // TPLC_Data_Recipe
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_Data_Recipe : TPLC_Base_Data
    {
        public int Recipe_Code;
        public string Recipe_Name;

        public double Table_In_X;
        public double Table_In_Y;
        public double Table_In_Q;     //(A=180,B=90,C=360,D=270)
        public double Table_Out_X;
        public double Table_Out_Y;
        public double Table_Out_Q;     //(A=180,B=90,C=360,D=270)

        public double Table_Align_X;
        public double Table_Align_Y;
        public double Table_Align_Q;     //(A=180,B=90,C=360,D=270)
        public double Table_CCD;

        public double Table_Barcode_Read_X;
        public double Table_Barcode_Read_Y;
        public double Table_Barcode_Read_Q;     //(A=180,B=90,C=360,D=270)
        public bool Box_Load_Supply_Vacc;
        public double Box_Load_Z;
        public int Box_Load_X_Num;
       

        public TPLC_MS_Param MS_Param = new TPLC_MS_Param();

        public TPLC_Data_Recipe()
        {
            //for (int i = 0; i < LD_Panel_Space_Get_Pos.Length; i++) LD_Panel_Space_Get_Pos[i] = new TPLC_Recipe_Pos();
            //for (int i = 0; i < LD_Panel_Space_Put_Pos.Length; i++) LD_Panel_Space_Put_Pos[i] = new TPLC_Recipe_Pos();
        }
        public bool Write(TMelsec_QPLC_Eth_Connect plc)
        {
            bool result = false;

            Update();
            if (plc.Connect)
            {
                result = plc.Write_Byte(Start_Code, Data, Count);
            }
            return result;
        }
        override public void Update()
        {
            int no = 0;
            int start_no = 0;
            int tmp_no = 0;

            PLC_Data_Tool.Set_DWord(Data, 0, Recipe_Code);
            PLC_Data_Tool.Set_String(Data, 2, 18, Recipe_Name);

            PLC_Data_Tool.Set_Bit(Data, 30, 0, Box_Load_Supply_Vacc);
            
            PLC_Data_Tool.Set_DWord(Data, 50, 3, Table_In_X);
            PLC_Data_Tool.Set_DWord(Data, 52, 3, Table_In_Y);
            PLC_Data_Tool.Set_DWord(Data, 54, 3, Table_In_Q);

            PLC_Data_Tool.Set_DWord(Data, 56, 3, Table_Out_X);
            PLC_Data_Tool.Set_DWord(Data, 58, 3, Table_Out_Y);
            PLC_Data_Tool.Set_DWord(Data, 60, 3, Table_Out_Q);

            PLC_Data_Tool.Set_DWord(Data, 62, 3, Table_Align_X);
            PLC_Data_Tool.Set_DWord(Data, 64, 3, Table_Align_Y);
            PLC_Data_Tool.Set_DWord(Data, 66, 3, Table_Align_Q);

            PLC_Data_Tool.Set_DWord(Data, 68, 3, Table_CCD);


            PLC_Data_Tool.Set_DWord(Data, 70, 3, Table_Barcode_Read_X);
            PLC_Data_Tool.Set_DWord(Data, 72, 3, Table_Barcode_Read_Y);
            PLC_Data_Tool.Set_DWord(Data, 74, 3, Table_Barcode_Read_Q);

            PLC_Data_Tool.Set_DWord(Data, 100, 3, Box_Load_Z);
            PLC_Data_Tool.Set_DWord(Data, 102, Box_Load_X_Num);
            

            #region MS_Param
            start_no = 200;
            for (int i = 0; i < MS_Param.Axis.Length; i++)
            {
                for (int j = 0; j < MS_Param.Axis[i].Pos.Length; j++)
                {
                    tmp_no = start_no + i * 20 + j * 2;
                    PLC_Data_Tool.Set_DWord(Data, tmp_no, 3, MS_Param.Axis[i].Pos[j]);
                }
            }
            #endregion
        }
        public void View_Data()
        {
            TForm_Data_View form = new TForm_Data_View();
            form.Set_Param(this, TPub.Environment.Base.Database_Path + "Recipe.csv");
            form.ShowDialog();
        }
    }

    public class TPLC_Recipe_Pos
    {
        public double X;
        public double Y;
    }

    //-----------------------------------------------------------------------------------------------------
    // TPLC_Data_MS_Param
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_MS_Param
    {
        public TPLC_MS_Param_Axis_Pos[] Axis = new TPLC_MS_Param_Axis_Pos[20];

        public TPLC_MS_Param()
        {
            for (int i = 0; i < Axis.Length; i++) Axis[i] = new TPLC_MS_Param_Axis_Pos();
        }
    }

    public class TPLC_MS_Param_Axis_Pos
    {
        public double[] Pos = new double[10];

        public TPLC_MS_Param_Axis_Pos()
        {
        }
    }

}