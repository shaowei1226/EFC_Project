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
        private PLC_Thread_List Thread_List = new PLC_Thread_List();
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
        public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(Log_Source, fun, msg_str, type);
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

                TPub.PLC.PLC_Out.On_Line = !TPub.PLC.PLC_Out.On_Line;

                Thread_List.Remove_Stop_Thread(); //關掉工作完成的執行序

                Run_Fun(TPub.PLC.PLC_In.Printer_Req, TPub.PLC.PLC_Out.Printer_Label, "Printer_Label", Printer_Label);
                Run_Fun(TPub.PLC.PLC_In.P_Read_Code_Req, TPub.PLC.PLC_Out.P_Reader_Read, "P_Reader_Read", P_Reader_Read);
                Run_Fun(TPub.PLC.PLC_In.C_Read_Code_Req, TPub.PLC.PLC_Out.C_Reader_Read, "C_Reader_Read", C_Reader_Read);

               
                Watch.Stop();
                in_Scan_Time = Watch.Elapsed.TotalMilliseconds;
                Thread.Sleep(100);
            }
            Thread_ON = false;
        }
        private void Run_Fun(bool req, TPLC_CMD_Data cmd, string name, evPLC_Thread_Run run_fun)
        {
            bool thread_run = false;

            if (req && !cmd.Running && !cmd.Finish)
            {
                cmd.Running = true;
                if (thread_run)
                {
                    Log_Add(name, string.Format("[PLC] Thread Name={0:s}", name));
                    Thread_List.Add(new PLC_Thread(name, run_fun));
                }
                else
                {
                    Log_Add(name, string.Format("[PLC] No Thread Name={0:s}", name));
                    run_fun(name);
                }
            }
            else if (!req)
            {
                cmd.Running = false;
                cmd.Finish = false;
                cmd.OK = false;
            }
        }

        public void Printer_Label(string name)
        {
            TPub.PLC.PLC_Out.Printer_Label.OK = TPub.Printer_Label();
            TPub.PLC.PLC_Out.Printer_Label.Finish = true;
        }
        public void P_Reader_Read(string name)
        {
            TPub.PLC.PLC_Out.P_Reader_Read.OK = TPub.P_Read_Code(ref TPub.PLC.PLC_Out.P_Code);
            TPub.PLC.PLC_Out.P_Reader_Read.Finish = true;
        }
        public void C_Reader_Read(string name)
        {
            TPub.PLC.PLC_Out.C_Reader_Read.OK = TPub.C_Read_Code(ref TPub.PLC.PLC_Out.C_Code);
            TPub.PLC.PLC_Out.C_Reader_Read.Finish = true;
        }

    }

}
