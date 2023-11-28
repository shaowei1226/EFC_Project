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
using EFC.PLC.Melsec;//TMelsec_QPLC_Eth_Connect功能

namespace Main
{
    public class TPLC
    {
        public TMelsec_QPLC_Eth_Connect          PLC_Socket = new TMelsec_QPLC_Eth_Connect();      
        public TLog                              in_Log = null;
        public TPLC_Data_In                      PLC_In = new TPLC_Data_In();
        public TPLC_Data_Out                     PLC_Out = new TPLC_Data_Out();
        public TPLC_Data_Recipe                  PLC_Recipe = new TPLC_Data_Recipe();
        private Thread                           PLC_Thread;
        private PLC_Thread_List                  Thread_List = new PLC_Thread_List();
        static public int                        alarm_tmp_count = 10;
        public String[,]                         Alarm_Message_list = new String[alarm_tmp_count, 16];
        public bool                              Update_Recipe_Flag = false;
        public bool                              MU_Right_OK = false;
        public bool                              MU_Left_OK = false;
        public string                            Log_Source = "TPLC";
                                               
                                                

        private bool                             Terminate = false;
        private bool                             Thread_ON = false;
        private double                           in_Scan_Time;
        private System.Diagnostics.Stopwatch     Watch = new System.Diagnostics.Stopwatch();


        public TPLC()
        {
            
            PLC_Thread = new Thread(Thread_Start); }
        public void Dispose()
        {
            Stop();
        }
        public TLog Log
        {
            get
            { 
                return in_Log; 
            }
            set
            {
                in_Log = value; 
                //PLC_Socket.Log = value; 
            }
        }
        public double Scan_Time
        {
            get
            {
                return in_Scan_Time;
            }
        }
        public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(Log_Source, fun, msg_str, type);
        }
        public void Start()
        {
            PLC_Thread.Start();
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
            while (!Terminate)
            {
                Thread_ON = true;
                Watch.Reset();
                Watch.Start();

                PLC_Out.On_Line = !PLC_Out.On_Line;

                Read_From_PLC();
                Write_To_PLC();
                Run_Fun(PLC_In.Write_Recipe_Req, PLC_Out.Write_Recipe, "Write_Recipe", Write_Recipe);

                Thread_List.Remove_Stop_Thread(); //關掉工作完成的執行序

                Watch.Stop();
                in_Scan_Time = Watch.Elapsed.TotalMilliseconds;
                Thread.Sleep(10);
            }
            Thread_ON = false;
        }
        private void Run_Fun(bool req, TPLC_CMD_Data cmd, string name, evPLC_Thread_Run run_fun)
        {
            if (req && !cmd.Running && !cmd.Finish)
            {
                cmd.Running = true;
                Log_Add(name, string.Format("[PLC] Thread Name={0:s}", name));
                run_fun(name);
            }
            else if (!req)
            {
                cmd.Running = false;
                cmd.Finish = false;
                cmd.OK = false;
            }
        }


        private void Read_From_PLC()
        {
            string fun = "Read_From_PLC";

            if (PLC_Socket.Connect)
            {
                if (!PLC_In.Read(PLC_Socket))
                {
                    Log_Add(fun, "[PLC] Read_From_PLC Error.", emLog_Type.Error);
                    JJS_LIB.Sleep(2000);
                }
            }
        }
        private void Write_To_PLC()
        {
            string fun = "Read_From_PLC";

            if (PLC_Socket.Connect)
            {
                if (!PLC_Out.Write(PLC_Socket))
                {
                    Log_Add(fun, "[PLC] Write_To_PLC Error.", emLog_Type.Error);
                    JJS_LIB.Sleep(2000);
                }
            }
        }
        private void Write_Recipe(string thread_Name)
        {
            string fun = "Write_Recipe";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_Name));
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

        public bool Printer_Req;
        public bool P_Read_Code_Req;
        public bool C_Read_Code_Req;

        public double LD_UD_IN_Z;
        public double LD_UD_OUT_Z;
        public double Get_Hand_X;
        public double Get_Hand_In_Y;
        public double Get_Hand_In_Z;
        //public double Out_Hand_X;
        public double Get_Hand_Out_Y;
        public double Get_Hand_Out_Z;
        public double Table_Y;
        public double Table_hold_X;//載台靠位
        public double Table_hold_Y;//載台靠位
        public double ULD_Y;
        public double ULD_Z;
        public double Zebra_Hand_X;//貼標手臂
        public double Zebra_Hand_Z;//貼標手臂
        public double Zebra_Hand_Q;//貼標手臂
        public TPLC_Data_In()
        {
        }
        public bool Read(TMelsec_QPLC_Eth_Connect plc)
        {
            bool result = false;

            if (plc.Connect)
            {
                result = plc.Read_Byte(Start_Code, ref Data, Count);
            }
            Update();
            return result;
        }
        override public void Update()
        {
            Can_Change_Recipe       = PLC_Data_Tool.Get_Bit(Data, 0, 1);

            Printer_Req           = PLC_Data_Tool.Get_Bit(Data, 1, 8);
            P_Read_Code_Req       = PLC_Data_Tool.Get_Bit(Data, 2, 8);
            C_Read_Code_Req       = PLC_Data_Tool.Get_Bit(Data, 2, 9);
            LD_UD_IN_Z = PLC_Data_Tool.Get_DWord(Data, 200, 3);
            LD_UD_OUT_Z = PLC_Data_Tool.Get_DWord(Data, 202, 3);
            Get_Hand_X = PLC_Data_Tool.Get_DWord(Data, 204, 3);

            Get_Hand_In_Y = PLC_Data_Tool.Get_DWord(Data, 206, 3);
            Get_Hand_In_Z = PLC_Data_Tool.Get_DWord(Data, 208, 3);
            Get_Hand_Out_Y = PLC_Data_Tool.Get_DWord(Data, 210, 3);
            Get_Hand_Out_Z = PLC_Data_Tool.Get_DWord(Data, 212, 3);
            Table_Y = PLC_Data_Tool.Get_DWord(Data, 214, 3);
            Table_hold_X = PLC_Data_Tool.Get_DWord(Data, 216, 3);

            Table_hold_Y = PLC_Data_Tool.Get_DWord(Data, 218, 3);
            ULD_Y = PLC_Data_Tool.Get_DWord(Data, 220, 3);
            ULD_Z = PLC_Data_Tool.Get_DWord(Data, 222, 3);
            Zebra_Hand_X = PLC_Data_Tool.Get_DWord(Data, 224, 3);
            Zebra_Hand_Z = PLC_Data_Tool.Get_DWord(Data, 226, 3);
            Zebra_Hand_Q = PLC_Data_Tool.Get_DWord(Data, 228, 3);
         
        }
        public void View_Data(string filename)
        {
            TForm_Data_View form = new TForm_Data_View();
            form.Set_Param(this, filename);
            form.ShowDialog();
        }

    }

    //-----------------------------------------------------------------------------------------------------
    // TPLC_Data_Out
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_Data_Out : TPLC_Base_Data
    {
        #region Bit
        public bool On_Line;
        public TPLC_CMD_Data Write_Recipe = new TPLC_CMD_Data();
        public TPLC_CMD_Data Printer_Label = new TPLC_CMD_Data();
        public TPLC_CMD_Data P_Reader_Read = new TPLC_CMD_Data();
        public TPLC_CMD_Data C_Reader_Read = new TPLC_CMD_Data();

        public bool Printer_Ready = false;
        public bool Printer_Paper_Out = false;
        public bool Printer_Pause = false;
        public bool P_Reader_Ready = false;
        public bool C_Reader_Ready = false;
        #endregion

        #region Word
        public string P_Code = "";
        public string C_Code = "";
        #endregion

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
            Printer_Paper_Out = TPub.Printer.Status.Paper_Out;
            Printer_Pause = TPub.Printer.Status.Pause;
            P_Reader_Ready = TPub.Panel_Reader.Connect;

            #region Bit
            #region Main
            PLC_Data_Tool.Set_Bit(Data, 0, 00, On_Line);
            PLC_Data_Tool.Set_Bit(Data, 0, 01, Write_Recipe.Finish);
            PLC_Data_Tool.Set_Bit(Data, 1, 01, Write_Recipe.OK);
            #endregion

            #region P_Reader
            PLC_Data_Tool.Set_Bit(Data, 2, 00, P_Reader_Read.Finish);
            PLC_Data_Tool.Set_Bit(Data, 2, 15, P_Reader_Ready);

            PLC_Data_Tool.Set_Bit(Data, 3, 00, P_Reader_Read.OK);
            #endregion

            #region C_Reader
            PLC_Data_Tool.Set_Bit(Data, 4, 00, C_Reader_Read.Finish);
            PLC_Data_Tool.Set_Bit(Data, 4, 15, C_Reader_Ready);

            PLC_Data_Tool.Set_Bit(Data, 5, 00, C_Reader_Read.OK);
            #endregion

            #region Printer
            PLC_Data_Tool.Set_Bit(Data, 6, 00, Printer_Label.Finish);
            PLC_Data_Tool.Set_Bit(Data, 6, 13, Printer_Paper_Out);
            PLC_Data_Tool.Set_Bit(Data, 6, 14, Printer_Pause);
            PLC_Data_Tool.Set_Bit(Data, 6, 15, Printer_Ready);
            
            PLC_Data_Tool.Set_Bit(Data, 7, 00, Printer_Label.OK);
            #endregion
            #endregion

            #region Word
            PLC_Data_Tool.Set_String(Data, 10, 10, P_Code);
            PLC_Data_Tool.Set_String(Data, 20, 10, C_Code);
            #endregion
        }
        public void View_Data(string filename)
        {
            TForm_Data_View form = new TForm_Data_View();
            form.Set_Param(this, filename);
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
        public double Tray_Hand_Get_Full_X,
                      Tray_Hand_Get_Full_Y,
                      Tray_Hand_Get_Full_Z;
        public double Tray_Hand_Put_Full_Up_X,
                      Tray_Hand_Put_Full_Up_Y,
                      Tray_Hand_Put_Full_Up_Z;
        public double Tray_Hand_Put_Full_Dn_X,
                      Tray_Hand_Put_Full_Dn_Y,
                      Tray_Hand_Put_Full_Dn_Z;
        public double Tray_Hand_Put_Empty_X,
                      Tray_Hand_Put_Empty_Y,
                      Tray_Hand_Put_Empty_Z;
        
        public double Tray_Slider_Up_In,
                      Tray_Slider_Up_Out,
                      Tray_Slider_Dn_In,
                      Tray_Slider_Dn_Out;
        
        public double LightBar_Hand_Get_X,
                      LightBar_Hand_Get_Y,
                      LightBar_Hand_Get_Z, 
                      LightBar_Hand_Get_Q;
        public double LightBar_Hand_Put_X,
                      LightBar_Hand_Put_Y,
                      LightBar_Hand_Put_Z,
                      LightBar_Hand_Put_Q;
        
        public double Out_Hand_Get_X,
                      Out_Hand_Get_Y,
                      Out_Hand_Get_Z,
                      Out_Hand_Get_Q;        
        public double Out_Hand_Grab_X,
                      Out_Hand_Grab_Y,
                      Out_Hand_Grab_Z,
                      Out_Hand_Grab_Q;
        public double Out_Hand_Put_X,
                      Out_Hand_Put_Y,
                      Out_Hand_Put_Z,
                      Out_Hand_Put_Q;

        public TPLC_MS_Param MS_Param = new TPLC_MS_Param();

        public double CCD_X;

        public int LightBar_Count;
        public TPLC_Tray_Pos[] LightBar_Pos = new TPLC_Tray_Pos[30];

        public TPLC_Data_Recipe() 
        {
            for (int i = 0; i < LightBar_Pos.Length; i++) LightBar_Pos[i] = new TPLC_Tray_Pos();
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
            //PLC_Data_Tool.Set_DWord(Data,  0, 2, Tray_Hand_Get_Full_X);
            //PLC_Data_Tool.Set_DWord(Data,  2, 2, Tray_Hand_Get_Full_Y);
            //PLC_Data_Tool.Set_DWord(Data,  4, 2, Tray_Hand_Get_Full_Z);
            //PLC_Data_Tool.Set_DWord(Data,  6, 2, Tray_Hand_Put_Full_Up_X);
            //PLC_Data_Tool.Set_DWord(Data,  8, 2, Tray_Hand_Put_Full_Up_Y);
            //PLC_Data_Tool.Set_DWord(Data, 10, 2, Tray_Hand_Put_Full_Up_Z);
            //PLC_Data_Tool.Set_DWord(Data, 12, 2, Tray_Hand_Put_Full_Dn_X);
            //PLC_Data_Tool.Set_DWord(Data, 14, 2, Tray_Hand_Put_Full_Dn_Y);
            //PLC_Data_Tool.Set_DWord(Data, 16, 2, Tray_Hand_Put_Full_Dn_Z);
                                          
            //PLC_Data_Tool.Set_DWord(Data, 18, 2, Tray_Hand_Put_Empty_X);
            //PLC_Data_Tool.Set_DWord(Data, 20, 2, Tray_Hand_Put_Empty_Y);
            //PLC_Data_Tool.Set_DWord(Data, 22, 2, Tray_Hand_Put_Empty_Z);
                                           
            //PLC_Data_Tool.Set_DWord(Data, 24, 2, Tray_Slider_Up_In);
            //PLC_Data_Tool.Set_DWord(Data, 26, 2, Tray_Slider_Up_Out);
            //PLC_Data_Tool.Set_DWord(Data, 28, 2, Tray_Slider_Dn_In);
            //PLC_Data_Tool.Set_DWord(Data, 30, 2, Tray_Slider_Dn_Out);

            //PLC_Data_Tool.Set_DWord(Data, 32, 2, LightBar_Hand_Get_X);
            //PLC_Data_Tool.Set_DWord(Data, 34, 2, LightBar_Hand_Get_Y);
            //PLC_Data_Tool.Set_DWord(Data, 36, 2, LightBar_Hand_Get_Z);
            //PLC_Data_Tool.Set_DWord(Data, 38, 2, LightBar_Hand_Get_Q);
            //PLC_Data_Tool.Set_DWord(Data, 40, 2, LightBar_Hand_Put_X);
            //PLC_Data_Tool.Set_DWord(Data, 42, 2, LightBar_Hand_Put_Y);
            //PLC_Data_Tool.Set_DWord(Data, 44, 2, LightBar_Hand_Put_Z);
            //PLC_Data_Tool.Set_DWord(Data, 46, 2, LightBar_Hand_Put_Q);

            //PLC_Data_Tool.Set_DWord(Data, 48, 2, Out_Hand_Get_X);
            //PLC_Data_Tool.Set_DWord(Data, 50, 2, Out_Hand_Get_Y);
            //PLC_Data_Tool.Set_DWord(Data, 52, 2, Out_Hand_Get_Z);
            //PLC_Data_Tool.Set_DWord(Data, 54, 2, Out_Hand_Get_Q);
            //PLC_Data_Tool.Set_DWord(Data, 56, 2, Out_Hand_Grab_X);
            //PLC_Data_Tool.Set_DWord(Data, 58, 2, Out_Hand_Grab_Y);
            //PLC_Data_Tool.Set_DWord(Data, 60, 2, Out_Hand_Grab_Z);
            //PLC_Data_Tool.Set_DWord(Data, 62, 2, Out_Hand_Grab_Q);
            //PLC_Data_Tool.Set_DWord(Data, 64, 2, Out_Hand_Put_X);
            //PLC_Data_Tool.Set_DWord(Data, 66, 2, Out_Hand_Put_Y);
            //PLC_Data_Tool.Set_DWord(Data, 68, 2, Out_Hand_Put_Z);
            //PLC_Data_Tool.Set_DWord(Data, 70, 2, Out_Hand_Put_Q);

            //PLC_Data_Tool.Set_DWord(Data, 72, 2, CCD_X);


            PLC_Data_Tool.Set_DWord(Data, 99, LightBar_Count);
            for (int i = 0; i < LightBar_Count; i++)
            {
                PLC_Data_Tool.Set_DWord(Data, 100 + i * 6 + 0, 2, LightBar_Pos[i].X);
                PLC_Data_Tool.Set_DWord(Data, 100 + i * 6 + 2, 2, LightBar_Pos[i].Y);
                PLC_Data_Tool.Set_DWord(Data, 100 + i * 6 + 4, 2, LightBar_Pos[i].Q);
            }
        }
        public void View_Data(string filename)
        {
            TForm_Data_View form = new TForm_Data_View();
            form.Set_Param(this, filename);
            form.ShowDialog();
        }

    }
    public class TPLC_Tray_Pos
    {
        public double X, Y, Q;
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
        public int Dot_Num = 3;
        public double[] Pos = new double[10];

        public TPLC_MS_Param_Axis_Pos()
        {

        }
    }
}