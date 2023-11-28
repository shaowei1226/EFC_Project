using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO.Ports; 
using System.Timers;
using System.Runtime.InteropServices;
using EFC.Tool;
using EFC.Light;


namespace EFC.Light.EFC
{
    public class TLight_EFC : TLight_Base 
    {
        public TBase_SerialPort COM = new TBase_SerialPort();
        public bool Lock = false;

        public bool Enabled
        {
            get
            {
                return COM.Enabled;
            }
            set
            {
                COM.Enabled = value;
            }
        }
        public TLight_EFC()
        {
            Channel_Count = 16;
            Max_Value = 255;
            COM.Setting("2,115200,N,8,1");
            COM.Read_Timer.Interval = 200;
        }
        override public bool Set_Light(int in_channel, int in_value)
        {
            bool result = false;
            string no_str, value_str;
            String send_str;
            int channel = 0;
            int value = 0;
            int LRC = 0;
            string asciiLRC;
         

            channel = Get_Channel(in_channel);
            value = Get_Value(in_value);
            Channels[channel].Value = value;
            Wait_Ready();
            if (COM.IsOpen)
           {
                Lock = true;
                no_str = String_Tool.IntToHexStr(channel, 2);
                value_str = String_Tool.IntToHexStr(value, 2);
                LRC = 255 - (1 + 6 + 0 + 1 + value) + 1;
                asciiLRC = String_Tool.IntToHexStr(LRC, 2);
                send_str = "0x3A"+"0x30"+"0x31"+"0x30"+"0x36"+"0x30"+"0x30"+"0x30"+"0x31"+"0x" +value_str + "0x" + asciiLRC + "0x0D" + "0x0A";
                COM.Write(send_str);
                Lock = false;
                result = true;
            }
            return result;
        }
        public void Wait_Ready()
        {
            bool time_out = false;
            DateTime in_time = DateTime.Now;

            while (Lock && !time_out)
            {
                Application.DoEvents();
                JJS_LIB.Sleep(10);
                time_out = JJS_LIB.Is_Timeout(in_time, 3000);
            };
            Lock = false;
        }
    }
}
