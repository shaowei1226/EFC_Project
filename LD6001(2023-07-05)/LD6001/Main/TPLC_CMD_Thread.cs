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
    public class TPLC_CMD_Thread
    {
        private Thread Main_Thread = null;
        private TLog in_Log = null;
        public string Log_Source = "TPLC_CMD_Thread";
        private bool Terminate = false;
        private bool Thread_ON = false;
        private double in_Scan_Time;
        private System.Diagnostics.Stopwatch Watch = new System.Diagnostics.Stopwatch();

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
        public TPLC_CMD_Thread()
        {
            Main_Thread = new Thread(Thread_Start);
        }
        public void Dispose()
        {
            Stop();
        }
        public void Log_Add(string fun, string msg, emLog_Type type = emLog_Type.Generally)
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
            while (!Terminate)
            {
                Thread_ON = true;
                Watch.Reset();
                Watch.Start();

                #region Main
                No_Thread_Add(TPub.PLC.PLC_In.Set_Light_All_OFF_Req, TPub.PLC.PLC_Out.Set_Light_All_OFF, "Set_Light_All_OFF", Set_Light_All_OFF);
                No_Thread_Add(TPub.PLC.PLC_In.Barcode_Read_Req, TPub.PLC.PLC_Out.Barcode_Read, "Barcode_Read", Barcode_Read);
                No_Thread_Add(TPub.PLC.PLC_In.Printer_Label1_Req, TPub.PLC.PLC_Out.Printer_Label1, "Printer_Label1", Printer_Label1);
                No_Thread_Add(TPub.PLC.PLC_In.Printer_Label2_Req, TPub.PLC.PLC_Out.Printer_Label2, "Printer_Label2", Printer_Label2);
                #endregion

                #region Panel_Big
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Big_L_Set_Light_Req, TPub.PLC.PLC_Out.Panel_Big_L_Set_Light, "Panel_Big_L_Set_Light", Panel_Big_L_Set_Light);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Big_R_Set_Light_Req, TPub.PLC.PLC_Out.Panel_Big_R_Set_Light, "Panel_Big_R_Set_Light", Panel_Big_R_Set_Light);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Big_L_Grab_Req, TPub.PLC.PLC_Out.Panel_Big_L_Grab, "Panel_Big_L_Grab", Panel_Big_L_Grab);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Big_R_Grab_Req, TPub.PLC.PLC_Out.Panel_Big_R_Grab, "Panel_Big_R_Grab", Panel_Big_R_Grab);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Big_L_MU_Grab_Req, TPub.PLC.PLC_Out.Panel_Big_L_MU_Grab, "Panel_Big_L_MU_Grab", Panel_Big_L_MU_Grab);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Big_R_MU_Grab_Req, TPub.PLC.PLC_Out.Panel_Big_R_MU_Grab, "Panel_Big_R_MU_Grab", Panel_Big_R_MU_Grab);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Big_Cal_Req, TPub.PLC.PLC_Out.Panel_Big_Cal, "Panel_Big_Cal", Panel_Big_Cal);
                #endregion

                #region Panel_Small
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Small_L_Set_Light_Req, TPub.PLC.PLC_Out.Panel_Small_L_Set_Light, "Panel_Small_L_Set_Light", Panel_Small_L_Set_Light);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Small_R_Set_Light_Req, TPub.PLC.PLC_Out.Panel_Small_R_Set_Light, "Panel_Small_R_Set_Light", Panel_Small_R_Set_Light);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Small_L_Grab_Req, TPub.PLC.PLC_Out.Panel_Small_L_Grab, "Panel_Small_L_Grab", Panel_Small_L_Grab);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Small_R_Grab_Req, TPub.PLC.PLC_Out.Panel_Small_R_Grab, "Panel_Small_R_Grab", Panel_Small_R_Grab);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Small_L_MU_Grab_Req, TPub.PLC.PLC_Out.Panel_Small_L_MU_Grab, "Panel_Small_L_MU_Grab", Panel_Small_L_MU_Grab);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Small_R_MU_Grab_Req, TPub.PLC.PLC_Out.Panel_Small_R_MU_Grab, "Panel_Small_R_MU_Grab", Panel_Small_R_MU_Grab);
                No_Thread_Add(TPub.PLC.PLC_In.Panel_Small_Cal_Req, TPub.PLC.PLC_Out.Panel_Small_Cal, "Panel_Small_Cal", Panel_Small_Cal);
                #endregion

                Thread.Sleep(10);
                Watch.Stop();
                in_Scan_Time = Watch.Elapsed.TotalMilliseconds;
            }
            Thread_ON = false;
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

        #region Main
        public void Set_Light_All_OFF(string thread_name)
        {
            string fun = "Set_Light_All_OFF";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.Set_Light_All_OFF();
            TPub.PLC.PLC_Out.Set_Light_All_OFF.Finish = true;
        }
        public void Barcode_Read(string thread_name)
        {
            string fun = "Barcode_Read";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Barcode_Read.OK = TPub.Barcode_Read(ref TPub.PLC.PLC_Out.Barcode);
            TPub.PLC.PLC_Out.Barcode_Read.Finish = true;
        }
        public void Printer_Label1(string thread_name)
        {
            string fun = "Printer_Label1";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Printer_Label1.OK = TPub.Printer_Label1();
            TPub.PLC.PLC_Out.Printer_Label1.Finish = true;
        }
        public void Printer_Label2(string thread_name)
        {
            string fun = "Printer_Label2";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Printer_Label2.OK = TPub.Printer_Label2();
            TPub.PLC.PLC_Out.Printer_Label2.Finish = true;
        }
        #endregion

        #region Panel_Big
        public void Panel_Big_L_Set_Light(string thread_name)
        {
            string fun = "Panel_Big_L_Set_Light";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Big_L_Set_Light.OK = TPub.Set_Light(emModel.Big_L);
            TPub.PLC.PLC_Out.Panel_Big_L_Set_Light.Finish = true;
        }
        public void Panel_Big_R_Set_Light(string thread_name)
        {
            string fun = "Panel_Big_R_Set_Light";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Big_R_Set_Light.OK = TPub.Set_Light(emModel.Big_R);
            TPub.PLC.PLC_Out.Panel_Big_R_Set_Light.Finish = true;
        }
        public void Panel_Big_L_Grab(string thread_name)
        {
            string fun = "Panel_Big_L_Grab";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Big_L_Grab.OK = TPub.Find(emModel.Big_L);
            TPub.PLC.PLC_Out.Panel_Big_L_Grab.Finish = true;
        }
        public void Panel_Big_R_Grab(string thread_name)
        {
            string fun = "Panel_Big_R_Grab";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Big_R_Grab.OK = TPub.Find(emModel.Big_R);
            TPub.PLC.PLC_Out.Panel_Big_R_Grab.Finish = true;
        }
        public void Panel_Big_L_MU_Grab(string thread_name)
        {
            string fun = "Panel_Big_L_MU_Grab";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.MU_Select(emModel.Big_L);
        }
        public void Panel_Big_R_MU_Grab(string thread_name)
        {
            string fun = "Panel_Big_R_MU_Grab";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.MU_Select(emModel.Big_R);
        }
        public void Panel_Big_Cal(string thread_name)
        {
            string fun = "Panel_Big_Cal";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Big_Cal.OK = TPub.Panel_Big_Cal();
            TPub.PLC.PLC_Out.Panel_Big_Cal.Finish = true;
        }
        #endregion

        #region Panel_Small
        public void Panel_Small_L_Set_Light(string thread_name)
        {
            string fun = "Panel_Small_L_Set_Light";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Small_L_Set_Light.OK = TPub.Set_Light(emModel.Small_L);
            TPub.PLC.PLC_Out.Panel_Small_L_Set_Light.Finish = true;
        }
        public void Panel_Small_R_Set_Light(string thread_name)
        {
            string fun = "Panel_Small_R_Set_Light";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Small_R_Set_Light.OK = TPub.Set_Light(emModel.Small_R);
            TPub.PLC.PLC_Out.Panel_Small_R_Set_Light.Finish = true;
        }
        public void Panel_Small_L_Grab(string thread_name)
        {
            string fun = "Panel_Small_L_Grab";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Big_L_Grab.OK = TPub.Find(emModel.Small_L);
            TPub.PLC.PLC_Out.Panel_Big_L_Grab.Finish = true;
        }
        public void Panel_Small_R_Grab(string thread_name)
        {
            string fun = "Panel_Small_R_Grab";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Small_R_Grab.OK = TPub.Find(emModel.Small_R);
            TPub.PLC.PLC_Out.Panel_Small_R_Grab.Finish = true;
        }
        public void Panel_Small_L_MU_Grab(string thread_name)
        {
            string fun = "Panel_Small_L_MU_Grab";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.MU_Select(emModel.Small_L);
        }
        public void Panel_Small_R_MU_Grab(string thread_name)
        {
            string fun = "Panel_Small_R_MU_Grab";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.MU_Select(emModel.Small_R);
        }
        public void Panel_Small_Cal(string thread_name)
        {
            string fun = "Panel_Small_Cal";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Panel_Small_Cal.OK = TPub.Panel_Small_Cal();
            TPub.PLC.PLC_Out.Panel_Small_Cal.Finish = true;
        }
        #endregion
    }

}
