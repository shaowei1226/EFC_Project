using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;

namespace EFC.Reader.Keyence 
{
    //---------------------------------------------------------------------------------------------------
    //- RS232型
    //- 適用型號 BL185
    //-
    //---------------------------------------------------------------------------------------------------
    public class TReader_BL_U2 : TBase_SerialPort
    {
        public string STX = "";
        public string ETX = "\x0d";


        public TReader_BL_U2()
        {
            Setting("1,9600,E,7,1");
        }
        public bool Read_Code(ref string read_code)
        {
            bool result = false;

            read_code = "";
            LON();
            read_code = Read_String();
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
                result = ReadTo(ETX);
                Log_Add("Read_String", string.Format("Get_Code = {0:s}", result));
            }
            catch (Exception e)
            {
                Log_Add("Read_String", string.Format("Get_Code = {0:s}", e.Message));
            }
            return result;
        }
        private bool Write_CMD(string cmd)
        {
            bool result = false;

            if (Enabled)
            {
                Write(STX + cmd + ETX);
                result = true;
            }
            return result;
        }
    }

}
