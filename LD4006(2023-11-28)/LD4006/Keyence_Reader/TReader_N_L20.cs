using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;

namespace EFC.Reader.Keyence 
{
    //---------------------------------------------------------------------------------------------------
    //- 網路型
    //- 適用型號 SR-700, SR-710
    //-
    //---------------------------------------------------------------------------------------------------
    public class TReader_N_L20 : TJJS_ClientSockect
    {
        public string STX = "";
        public string ETX = "\x0d";
        protected System.Timers.Timer Timer_Timeout = new System.Timers.Timer();
        private bool Timeout = false;

        public TReader_N_L20()
        {
            Host = "192.168.100.100";
            Port = 9004;
            Timer_Timeout.Enabled = false;
            Timer_Timeout.Interval = 500;
            Timer_Timeout.Elapsed += On_Timeout;
        }
        public bool Read_Code(ref string read_code)
        {
            bool result = false;

            read_code = "";
            LON();

            Timeout = false;
            Timer_Timeout.Enabled = true;
            read_code = Read_String();
            Timer_Timeout.Enabled = false;

            if (read_code != "") result = true;
            LOFF();

            return result;
        }
        public bool LON()
        {
            bool result = false;
            string cmd = "LON";

            result = Write_CMD(cmd);
            return result;
        }
        public bool LOFF()
        {
            bool result = false;
            string cmd = "LOFF";

            result = Write_CMD(cmd);
            return result;
        }

        private string Read_String()
        {
            string result = "";

            try
            {
                while (result == "" && !Timeout)
                {
                    if (Recive_Length > 0)
                    {
                        result = Recive_String(ETX);
                        result = result.Replace(ETX, "");
                    }
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }
        private bool Write_CMD(string cmd)
        {
            bool result = false;

            if (Connected)
            {
                Send_String(STX + cmd + ETX);
                result = true;
            }
            return result;
        }
        private void On_Timeout(object sender, EventArgs e)
        {
            Timer_Timeout.Enabled = false;
            Timeout = true;
        }
    }

}
