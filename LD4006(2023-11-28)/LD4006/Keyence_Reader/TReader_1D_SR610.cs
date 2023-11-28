using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using EFC.Tool;

namespace EFC.Reader.Keyence 
{
    public class TReader_1D_SR610 : TBase_SerialPort
    {
        string TypeName;
        bool Lock=false;
        public string read_str;
        //public Timer read_time;
        int    Timer_Out_Count;
        bool TimeOut;
        string Status_Message;      //讀取的狀態
        string Read_String;         //傳回的字串
        public bool Show_Read_Str_Flag;
        private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);

  
        public TReader_1D_SR610()
        {
            Setting("1,115200,E,8,1");
            Timer_Out_Count = 5000;
            //read_time = new Timer();
            //read_time.Enabled = false;
            //read_time.Tick += new System.EventHandler(this.FOn_TimeOut);
            //Comm = new SerialPort();
            //Comm.PortName = ComPort;
            //Comm.BaudRate = 115200;
            //Comm.Parity = System.IO.Ports.Parity.Even;
            //Comm.StopBits = System.IO.Ports.StopBits.One;
            //Comm.DataBits = 8;
            //Comm.ReadTimeout = 2000;
        }
        public void MS_Read_Code()
        {
            Lock = true;
            Status_Message = "Reader Reading....";
            Start();
            //read_time.Interval = Timer_Out_Count;
            //read_time.Enabled = true;
            TimeoutObject.WaitOne(200, false);
            Lock = false;
            //while (Lock) { Application->ProcessMessages(); };
            //Lock = true;
            //Status_Message = "Reader Reading....";
            //Start();
            //Timer->Interval = Timer_Out_Count;
            //Timer->Enabled = true;       
        }
        public void Start()
        {
            //while (Lock) {Application.DoEvents();};
            //Lock = true;
            try
            {
                Open();
            }
            catch
            {

            }
            if (IsOpen)
            {
                try
                {
                    //Comm.Write("\x4C\x4F\x4E\x0D\x0A");
                    Write("LON\x0D\x0A");
                    //read_str = Comm.ReadTo("\x0D\x0A");
                    read_str = ReadTo("\x0D");
                    //Comm.Write("LOFF\x0D\x0A");  
                    Close();
                    Show_Read_Str_Flag = true;
                }
                catch
                {
                    //MessageBox.Show("read error");
                    Status_Message = "read error";
                }
            }
            //Lock = false;    
        }
        public void Stop()
        {
            try
            {
                Open();
            }
            catch
            {

            }
            if (IsOpen)
            {
                try
                {
                    Write("LOFF\x0D\x0A");
                    Close();
                }
                catch
                { 
                    
                }
            }
        }
        private void StartTimer_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            
        }
        private void FOn_TimeOut(object sender, EventArgs e)
        {
            Lock = false;
            TimeOut = true;
            //read_time.Enabled = false;
            Status_Message = "Reader TimeOut....";
            Read_String = "";
            Stop();

            /*  BCB
            Lock = false;
            TimeOut = true;
            Timer->Enabled = false;
            Status_Message = "Reader TimeOut....";
            Read_String = "";
            Stop();
            FOn_Read_String();
            if (On_TimeOut) On_TimeOut((TObject*)this);
            */
        }
    }
}
