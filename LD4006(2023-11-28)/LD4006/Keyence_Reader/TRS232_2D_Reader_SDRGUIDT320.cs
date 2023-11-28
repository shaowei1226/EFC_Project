using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace TEFC_Communication
{
    public class TRS232_2D_Reader_SDRGUIDT320
    {
        string TypeName;
        private SerialPort Comm = null;
        bool Lock;
        public String read_str;
        public Timer read_time;
        int Timer_Out_Count;
        bool TimeOut;
        string Status_Message;      //讀取的狀態
        string Read_String;         //傳回的字串

        public TRS232_2D_Reader_SDRGUIDT320()
        {            
            Timer_Out_Count = 5000;
            read_time = new Timer();
            read_time.Enabled = false;
            read_time.Tick += new System.EventHandler(this.FOn_TimeOut);
            Lock = false; 
        }
        public void Set_ComPort(String ComPort)
        {
            Comm = new SerialPort();
            Comm.PortName = ComPort;
            Comm.BaudRate = 9600;
            Comm.Parity = System.IO.Ports.Parity.None;
            Comm.StopBits = System.IO.Ports.StopBits.One;
            Comm.DataBits = 8;
            Comm.ReadTimeout = 200;
        }
        private void FOn_TimeOut(object sender, EventArgs e)
        {
            Lock = false;
            TimeOut = true;
            read_time.Enabled = false;
            Status_Message = "Reader TimeOut....";
            Read_String = "";
            //Stop();

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
        public void Start()
        {
            //while (Lock) {Application.DoEvents();};
            //Lock = true;
            try
            {
                Comm.Open();
            }
            catch
            {

            }
            if (Comm.IsOpen)
            {
                try
                {
                    Comm.Write("READ\x0D\x0A");
                    //read_str = Comm.ReadTo("\x0D\x0A");
                    read_str = Comm.ReadTo("\x03");
                    //Comm.Write("LOFF");                     
                    Comm.Close();
                }
                catch
                {
                }
            }
            //Lock = false;    
        }
        public void Stop()
        {
            try
            {
                Comm.Open();
            }
            catch
            {

            }
            if (Comm.IsOpen)
            {
                try
                {
                    while (Lock) { Application.DoEvents(); };
                    Lock = true;
                    Comm.Write("LOFF\x0d");
                    Lock = false;
                }
                catch
                { 
                    
                }
            }
        }
    }
}
