using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;
using EFC.Tool;
using EFC.INI;

namespace EFC.Printer.Zebra
{
    //-----------------------------------------------------------------------------------------------------
    // TZebra_Printer
    //-----------------------------------------------------------------------------------------------------
    public class TZebra_Printer : TBase_SerialPort
    {
        public TLog Log = null;
        public TPrinter_Status Status = new TPrinter_Status();
        public string STX = "\x02";
        public string ETX = "\x03";
        public string CR_LF = "\x0D\x0A";


        public TZebra_Printer()
        {
            Setting("1,115200,N,8,2");
        }
        public string Read_String(int wait_time = 10)
        {
            string result = "";

            if (Enabled)
            {
                System.Threading.Thread.Sleep(wait_time);
                try
                {
                    result = ReadTo("\x0D\x0A");
                }
                catch(Exception e)
                {

                }
            }
            return result;
        }
        public bool Write_String(string cmd) 
        {
            bool result = false;

            if (Enabled)
            {
                Write(cmd);
                result = true;
            }
            return result;
        }
        public bool Write_String(Printer_Format format)
        {
            string cmd = format.ToString();
            return Write_String(cmd);
        }

        //number:-120~120 調整塗標位置
        public bool Set_Label_Top(int number)
        {
            bool result = false;
            string cmd = "";

            cmd = "^XA" + "^LT" + number.ToString() + "^XZ";
            result = Write_String(cmd);

            if (!result) Log_Add("Set_Label_Top", "[TZebra_Printer] Set_Label_Top 失敗");

            return result;
        }

        //number-120~120 調整撕下(Tear off)的位置
        public bool Set_Tear_Off(int number)
        {
            bool result = false;
            string cmd = "";

            cmd = "~TA" + number.ToString("000");

            result = Write_String(cmd);

            if (!result) Log_Add("Set_Tear_Off", "[TZebra_Printer] Set_Tear_Off 失敗");
            return result;
        }
        public void Get_Status()
        {
            string read_str1 = "", read_str2 = "", read_str3 = "";

            if (Write_String("~HS"))
            {
                read_str1 = Replace_Control(Read_String(20));
                read_str2 = Replace_Control(Read_String(20));
                read_str3 = Replace_Control(Read_String(20));
                Status.Set_Status(read_str1, read_str2, read_str3);

                if (Enabled && !Status.Paper_Out && !Status.Pause) Status.Ready = true;
                else Status.Ready = false;
            }
            else
            {
                Console.WriteLine("無法取得印表機狀態，請確認是否連線");
                Status.Ready = false;
            }
            
        }
        public bool Start()
        {
            bool result = false;
            string cmd = "";

            cmd = "~PS";
            result = Write_String(cmd);

            if (!result) Log_Add("Start", "[TZebra_Printer] 印表機啟動失敗");

            return result;
        }
        public string Replace_Control(string str)
        {
            string result = "";

            result = str;
            result = result.Replace(STX, "");
            result = result.Replace(ETX, "");
            result = result.Replace(CR_LF, "");
            return result; 
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TPrinter_Status
    //-----------------------------------------------------------------------------------------------------
    public class TPrinter_Status
    {
        public bool Ready;

        public int  Com_Setting;                //00,aaa       ,COM Port (0, 1, 2)
        public bool Paper_Out;                  //01,b         ,1 = 無標籤紙
        public bool Pause;                      //02,c         ,1 = 暫停
        public int  Label_Length;               //03,dddd      ,Label Length
        public int  Number_Of_Formats;          //04,eee       ,number of formats in recive buffer
        public bool Buffer_Full;                //05,f         ,buffer full flag ,1=recive buffer full
        public bool Diagnostic;                 //06,g         ,communication diagnostic mode flag  ,1=diagnostic mode active
        public bool Partial_Format;             //07,h         ,partial format flag,1=partial format in progress
        public int  Space1;                     //08,iii       ,unused
        public bool Config_Lost;                //09,j         ,currept ram flag,1=configuration data lost
        public bool Under_Temp;                 //10,k         ,temperature range,1=under temperature
        public bool Over_Temp;                  //11,l         ,temperature range,1=over temperature

        public int  Func_Setting;               //12,mmm       ,function settings
        public int  Space2;                     //13,n         ,unused
        public bool Head_Up;                    //14,o         ,hand up flag,1=hand up in position
        public bool Ribbon_Out;                 //15,p         ,ribbon out,1=ribbon out
        public bool Thermal_Transfer_Mode;      //16,q         ,thermal transfer mode flag,1=thermal transfer mode flag selected
        public int  Print_Mode;                 //17,r         ,print mode,1=rewind,2=pell-off,3=cutter,4=applicator
        public int  Print_Width_Mode;           //18,s         ,print width mode,
        public bool Label_Waiting;              //19,t         ,label waiting flag
        public int  Labels_Remaining;           //20,uuuuuuuu  ,labels remaining in batch
        public bool Format_While_Printing;      //21,v         ,format while printing
        public int  Num_Images_Stored;          //22,www       ,number of graphic images stored in memory


        public int  Password;                   //23,xxxx      ,password
        public bool Static_RAM_Installed;       //24,y         ,0=static RAM not install,1=static RAM install


        //-----------------------------------------------------------------------------------------------------
        // <STX>aaa,b,c,dddd,eee,f,g,h,iii,j,k,l<ETX><CR><LF>
        // <STX>mmm,n,o,p,q,r,s,t,uuuuuuuu,v,www<ETX><CR><LF>
        // <STX>xxxx,y<ETX><CR><LF>
        //-----------------------------------------------------------------------------------------------------
        public bool Set_Status(string status_str1, string status_str2, string status_str3)
        {
            bool result = false;
            string[] list = new string[0];

            String_Tool.Break_String(status_str1, ",", ref list);
            if (list.Length >= 12)
            {
                //Com_Setting            = Convert.ToInt32(list[0]);
                Paper_Out              = ToBoolean(list[1]);
                Pause                  = ToBoolean(list[2]);
                Label_Length           = ToInt32(list[3]);
                Number_Of_Formats      = ToInt32(list[4]);
                Buffer_Full            = ToBoolean(list[5]);
                Diagnostic             = ToBoolean(list[6]);
                Partial_Format         = ToBoolean(list[7]);
                Space1                 = ToInt32(list[8]);
                Config_Lost            = ToBoolean(list[9]);
                Under_Temp             = ToBoolean(list[10]);
                Over_Temp              = ToBoolean(list[11]);
            }

            String_Tool.Break_String(status_str2, ",", ref list);
            if (list.Length >= 10)
            {
                Func_Setting           = ToInt32(list[0]);
                Space2                 = ToInt32(list[1]);
                Head_Up                = ToBoolean(list[2]);
                Ribbon_Out             = ToBoolean(list[3]);
                Thermal_Transfer_Mode  = ToBoolean(list[4]);
                Print_Mode             = ToInt32(list[0]);
                Print_Width_Mode       = ToInt32(list[5]);
                Label_Waiting          = ToBoolean(list[6]);
                Labels_Remaining       = ToInt32(list[7]);
                Format_While_Printing  = ToBoolean(list[8]);
                Num_Images_Stored      = ToInt32(list[9]);
            }

            String_Tool.Break_String(status_str2, ",", ref list);
            if (list.Length > 0)
            {
                Password              = ToInt32(list[0]);
                Static_RAM_Installed  = ToBoolean(list[1]);
            }

            return result;
        }

        public bool ToBoolean(string value)
        {
            bool result = false;

            result = Convert.ToInt32(value) == 1;
            return result;
        }
        public int ToInt32(string value)
        {
            int result = 0;

            result = Convert.ToInt32(value);
            return result;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // Printer_Format
    //-----------------------------------------------------------------------------------------------------
    public class Printer_Format : TBase_Class
    {
        public string[] Items = new string[0];


        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count;

                old_count = Items.Length;
                Array.Resize(ref Items, value);
            }
        }
        public Printer_Format()
        {
        }
        override public TBase_Class New_Class()
        {
            return new Printer_Format();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is Printer_Format && dis_base is Printer_Format)
            {
                Printer_Format sor = (Printer_Format)sor_base;
                Printer_Format dis = (Printer_Format)dis_base;

                dis.Count = sor.Count;
                for (int i = 0; i < dis.Count; i++) dis.Items[i] = sor.Items[i];
            }
        }


        public void Set_Default()
        {
            Count = 0;
            for (int i = 0; i < Items.Length; i++) Items[i] = "";
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Count = ini.ReadInteger(section, "Count", Count);
                for (int i = 0; i < Items.Length; i++) Items[i] = ini.ReadString(section, "Items" + (i + 1).ToString(), Items[i]);

                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteInteger(section, "Count", Count);
                for (int i = 0; i < Items.Length; i++) ini.WriteString(section, "Items" + (i + 1).ToString(), Items[i]);

                Write_Other_File();
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }

        
        public bool LoadFromFile(string filename)
        {
            bool result = false;
            ArrayList list = new ArrayList();

            if (System.IO.File.Exists(filename))
            {

                ArrayList_Tool.LoadFromFile(ref list, filename);
                Items = ArrayList_Tool.To_Strings(list);
                result = true;
            }
            return result;
        }
        public void Replace_Value(TZebra_Value_List value_list)
        {
            for (int i = 0; i < value_list.Count; i++)
            {
                Replace_Value(value_list[i]);
            }
        }
        public void Replace_Value(TZebra_Value value)
        {
            Replace_Value(value.Name, value.Value);
        }
        public void Replace_Value(string old_str, string new_str)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = Items[i].Replace(old_str, new_str);
            }
        }
        public void Cut_Comment()
        {
            int pos = 0;

            for (int i = 0; i < Items.Length; i++)
            {
                pos = Items[i].IndexOf(";");
                if (pos >= 0)
                {
                    Items[i] = Items[i].Substring(0, pos);
                }
                Items[i] = Items[i].Trim();
            }
        }
        public string ToString()
        {
            string result = "";

            for (int i = 0; i < Items.Length; i++)
            {
                result = result + Items[i];
            }
           return result;
        }
        public void Disp_TextBox(TextBox text_box)
        {
            text_box.Lines = Items;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TZebra_Value_List
    //-----------------------------------------------------------------------------------------------------
    public class TZebra_Value_List : TBase_Class
    {
        public bool Reflash = false;
        public TZebra_Value[] Items = new TZebra_Value[0];


        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count;

                old_count = Items.Length;
                Array.Resize(ref Items, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Items[i] = new TZebra_Value();
                }
            }
        }
        public TZebra_Value this[int index]
        {
            get
            {
                TZebra_Value result = null;
                if (index >= 0 && index < Items.Length)
                {
                    result = Items[index];
                }
                return result;
            }
            set
            {
                TZebra_Value data = this[index];

                if (data != null)
                {
                    data.Set(value);
                }
            }
        }
        public TZebra_Value this[string name]
        {
            get
            {
                TZebra_Value result = null;
                int index = Get_Value_Index(name);
                if (index >= 0 && index < Items.Length)
                {
                    result = Items[index];
                }
                return result;
            }
            set
            {
                int index = Get_Value_Index(name);
                TZebra_Value data = this[index];

                if (data != null)
                {
                    data.Set(value);
                }
            }
        }
        public TZebra_Value_List()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TZebra_Value_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TZebra_Value_List && dis_base is TZebra_Value_List)
            {
                TZebra_Value_List sor = (TZebra_Value_List)sor_base;
                TZebra_Value_List dis = (TZebra_Value_List)dis_base;

                dis.Count = sor.Count;
                for (int i = 0; i < dis.Count; i++) dis.Items[i].Set(sor.Items[i]);
            }
        }


        public void Set_Default()
        {
            for (int i = 0; i < Items.Length; i++) Items[i].Set_Default();
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Count = ini.ReadInteger(section, "Count", Count);
                for (int i = 0; i < Items.Length; i++) Items[i].Read(ini, section + "/Value" + (i + 1).ToString());

                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteInteger(section, "Count", Count);
                for (int i = 0; i < Items.Length; i++) Items[i].Write(ini, section + "/Value" + (i + 1).ToString());

                Write_Other_File();
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }

        public void Clear()
        {
            Count = 0;
        }
        public void Add(TZebra_Value data)
        {
            int no = -1;
            no = Get_Value_Index(data.Name);
            if (no < 0)
            {
                no = Count;
                Count++;
                Items[no].Set(data);
            }
            else
            {
                if (data.Info != "") Items[no].Info = data.Info;
                if (data.Value != "") Items[no].Value = data.Value;
            }
        }
        public void Add(string name)
        {
            TZebra_Value data = new TZebra_Value(name);
            Add(data);
        }
        public void Add(string name, string info)
        {
            TZebra_Value data = new TZebra_Value(name, info);
            Add(data);
        }
        public void Add(string name, string value, string info)
        {
            TZebra_Value data = new TZebra_Value(name, info, value);
            Add(data);
        }
        public void Delete(int no)
        {
            if (no >= 0 && no < Count)
            {
                for (int i = no; i < Count - 1; i++)
                {
                    Items[i] = Items[i + 1];
                }
                Count = Count - 1;
            }
        }
        public void Move_Up(int no)
        {
            Swap(no, no - 1);
        }
        public void Move_Dn(int no)
        {
            Swap(no, no + 1);
        }
        public void Set_Param_Grid(DataGridView dg)
        {
            if (Count > 0)
            {
                dg.RowCount = Count;
                for (int i = 0; i < Count; i++)
                {
                    Set_Param_Grid(dg, i);
                }
            }
        }
        public void Set_Param_Grid(DataGridView dg, int no)
        {
            dg.Rows[no].Cells[0].Value = string.Format("{0:d}", no + 1);
            dg.Rows[no].Cells[1].Value = string.Format("{0:s}", Items[no].Name);
            dg.Rows[no].Cells[2].Value = string.Format("{0:s}", Items[no].Info);
            dg.Rows[no].Cells[3].Value = string.Format("{0:s}", Items[no].Value);
        }
        public void Update_Param_Grid(DataGridView dg)
        {

            for (int i = 0; i < Count; i++)
            {
                Update_Param_Grid(dg, i);
            }
        }
        public void Update_Param_Grid(DataGridView dg, int no)
        {
            Items[no].Name = (string)dg.Rows[no].Cells[1].Value;
            Items[no].Info = (string)dg.Rows[no].Cells[2].Value;
            Items[no].Value = (string)dg.Rows[no].Cells[3].Value;
        }
        public int Get_Value_Index(string name)
        {
            int result = -1;

            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].Name == name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public void Set_Value(string name , string in_value)
        {
            TZebra_Value value = this[name];

            if (value != null)
            {
                value.Value = in_value;
            }
        }




        private void Swap(int no1, int no2)
        {
            TZebra_Value temp;
            if (no1 >= 0 && no1 < Count && no2 >= 0 && no2 < Count)
            {
                temp = Items[no1];
                Items[no1] = Items[no2];
                Items[no2] = temp;
            }
        }
    }
    public class TZebra_Value : TBase_Class
    {
        public string Name;
        public string Info;
        public string Value;

        public TZebra_Value()
        {
            Set_Default();
        }
        public TZebra_Value(string name)
        {
            Name = name;
            Info = "";
            Value = "";
        }
        public TZebra_Value(string name, string value)
        {
            Name = name;
            Info = "";
            Value = value;
        }
        public TZebra_Value(string name, string info, string value)
        {
            Name = name;
            Info = info;
            Value = value;
        }
        override public TBase_Class New_Class()
        {
            return new TZebra_Value();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TZebra_Value && dis_base is TZebra_Value)
            {
                TZebra_Value sor = (TZebra_Value)sor_base;
                TZebra_Value dis = (TZebra_Value)dis_base;

                dis.Name = sor.Name;
                dis.Info = sor.Info;
                dis.Value = sor.Value;
            }
        }


        public void Set_Default()
        {
            Name = "";
            Info = "";
            Value = "";
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Name = ini.ReadString(section, "Name", Name);
                Info = ini.ReadString(section, "Info", Info);
                Value = ini.ReadString(section, "Value", Value);

                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteString(section, "Name", Name);
                ini.WriteString(section, "Info", Info);
                ini.WriteString(section, "Value", Value);

                Write_Other_File();
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }

    }

}
