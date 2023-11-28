using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Tool;
using EFC.INI;


namespace Main
{
    public partial class TForm_Environment : Form
    {
        public TEnvironment Param = new TEnvironment();
        System.Windows.Forms.CheckBox[] CB_Lens_Enabled = new CheckBox[5];
        System.Windows.Forms.TextBox[]  E_Lens_Name = new TextBox[5];
        System.Windows.Forms.TextBox[] E_Lens_Pixel_Size_X = new TextBox[5];
        System.Windows.Forms.TextBox[] E_Lens_Pixel_Size_Y = new TextBox[5];
        System.Windows.Forms.Label[] L_Lens_Unit = new Label[3];


        public TForm_Environment()
        {
            InitializeComponent();
        }
        private void TForm_Environment_Shown(object sender, EventArgs e)
        {
            TV_Menu.TopNode.Expand();
            PageControl_Tool.Tab_Page_Hide(tabControl1);
            PageControl_Tool.Tab_Page_Select(tabControl1, "基本參數");
        }
        #region Set_Param
        public void Set_Param(TEnvironment param)
        {
            Param.Set(param);
            Set_Param();
        }
        public void Set_Param()
        {
            Set_Param_Base();
            Set_Param_Log();
            Set_Param_PLC();
            Set_Param_COM_Port();
            Set_Param_Reader();
            Set_Param_Light();
        }
        public void Set_Param_Reader()
        {
            E_Reader_Host.Text = Param.Reader.Host;
            E_Reader_Port.Text = Param.Reader.Port.ToString();
        }
        private void Set_Param_Light()
        {
            CB_Grab_Light1.Text = Param.Light.EFC_Light1_COM_Port.ToString();
        }
        private void Set_Param_Base()
        {
            E_Recipe_Path.Text = Param.Base.Recipe_Path;
            E_Database_Path.Text = Param.Base.Database_Path;
            E_Recipe_ID.Text = Param.Base.Recipe_Name;
            CB_Auto_Logout.Checked = Param.Base.Auto_Log_Out;
            E_Auto_Logout_Time.Text = Param.Base.Auto_Log_Out_Time.ToString();
            E_Language.Text = Param.Base.Language;
        }
        private void Set_Param_Log()
        {
            //畫面設定
            CB_Save_Sor_Image.Checked = Param.Log.Save_Sor_Image;
            CB_Save_OK_Image.Checked = Param.Log.Save_OK_Image;
            CB_Save_NG_Image.Checked = Param.Log.Save_NG_Image;
            CB_Auto_Delete_File.Checked = Param.Log.Auto_Delete_File;
            CB_Write_Log.Checked = Param.Log.Write_Log;
            E_Delete_Days.Text = string.Format("{0:d}", Param.Log.Days_Count);
        }
        private void Set_Param_PLC()
        {
            E_PLC_Host.Text = Param.PLC.Host;
            E_PLC_Port.Text = Param.PLC.Port.ToString();

            E_PLC_In_Start_Code.Text = Param.PLC.In_Start_Code;
            E_PLC_In_Count.Text = Param.PLC.In_Count.ToString();

            E_PLC_Out_Start_Code.Text = Param.PLC.Out_Start_Code;
            E_PLC_Out_Count.Text = Param.PLC.Out_Count.ToString();

            E_PLC_Recipe_Start_Code.Text = Param.PLC.Recipe_Start_Code;
            E_PLC_Recipe_Count.Text = Param.PLC.Recipe_Count.ToString();
        }
        private void Set_Param_COM_Port()
        {
           CB_Printer_COM_Port.SelectedIndex = Param.COM_Port.Printer - 1;
          //  CB_Casette_COM_Port.SelectedIndex = Param.COM_Port.Casette_Reader - 1;
        }
        #endregion

        #region Update_Param
        public void Update_Param()
        {
            Update_Param_Base();
            Update_Param_Log();
            Update_Param_PLC();
            Update_Param_COM_Port();
            Update_Param_Light();
        }
        private void Update_Param_Base()
        {
            try
            {
                Param.Base.Recipe_Path = E_Recipe_Path.Text;
                Param.Base.Database_Path = E_Database_Path.Text;

                Param.Base.Recipe_Name = E_Recipe_ID.Text;
                Param.Base.Auto_Log_Out = CB_Auto_Logout.Checked;
                Param.Base.Auto_Log_Out_Time = Convert.ToInt32(E_Auto_Logout_Time.Text);
            }
            catch { };
        }
        private void Update_Param_Light()
        {
            try
            {
                Param.Light.EFC_Light1_COM_Port = CB_Grab_Light1.SelectedIndex + 1;
            }
            catch { };
        }
        private void Update_Param_Log()
        {
            try
            {
                Param.Log.Save_Sor_Image = CB_Save_Sor_Image.Checked;
                Param.Log.Save_OK_Image = CB_Save_OK_Image.Checked;
                Param.Log.Save_NG_Image = CB_Save_NG_Image.Checked;
                Param.Log.Auto_Delete_File = CB_Auto_Delete_File.Checked;
                Param.Log.Write_Log = CB_Write_Log.Checked;
                Param.Log.Days_Count = Convert.ToInt32(E_Delete_Days.Text);
            }
            catch { }
        }
        private void Update_Param_PLC()
        {
            try
            {
                Param.PLC.Host = E_PLC_Host.Text;
                Param.PLC.Port = Convert.ToInt32(E_PLC_Port.Text);
                
                Param.PLC.In_Start_Code = E_PLC_In_Start_Code.Text;
                Param.PLC.In_Count = Convert.ToInt32(E_PLC_In_Count.Text);

                Param.PLC.Out_Start_Code = E_PLC_Out_Start_Code.Text;
                Param.PLC.Out_Count = Convert.ToInt32(E_PLC_Out_Count.Text);

                Param.PLC.Recipe_Start_Code = E_PLC_Recipe_Start_Code.Text;
                Param.PLC.Recipe_Count = Convert.ToInt32(E_PLC_Recipe_Count.Text);
            }
            catch { };
        }
        private void Update_Param_COM_Port()
        {
            Param.COM_Port.Printer = CB_Printer_COM_Port.SelectedIndex + 1;
         //   Param.COM_Port.Casette_Reader = CB_Casette_COM_Port.SelectedIndex + 1;
        }    
        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node;
            ArrayList node_list = new ArrayList();
            string node_full_name;
            string node_full_text;

            node = TV_Menu.SelectedNode;
            node_full_name = TreeView_Tool.Get_Node_Full_Name(node);
            node_full_text = TreeView_Tool.Get_Node_Full_Text(node);


            Update_Param();
            PageControl_Tool.Tab_Page_Select(tabControl1, "空白");
            switch (node_full_name)
            {
                //-----------------------------------------------------------------------------------
                //-- 基本參數
                //-----------------------------------------------------------------------------------
                case "\\Base":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "基本參數");
                    break;

                //-----------------------------------------------------------------------------------
                //-- PLC設定
                //-----------------------------------------------------------------------------------
                case "\\PLC":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "PLC設定");
                    break;

                //-----------------------------------------------------------------------------------
                //-- 光源設定
                //-----------------------------------------------------------------------------------
                case "\\Light":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "光源設定");
                    break;

                //-----------------------------------------------------------------------------------
                //-- Reader
                //-----------------------------------------------------------------------------------
                case "\\Reader":
                     PageControl_Tool.Tab_Page_Select(tabControl1, "Reader");
                    break;
                case "\\ComPort":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "COM Port設定");
                    break;
            }
            Set_Param();
        }
        private void B_Select_Recipe_Path_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = E_Recipe_Path.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Recipe_Path.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }
        private void B_Select_Database_Path_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = E_Database_Path.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Database_Path.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
     }

    //-----------------------------------------------------------------------------------------------------
    // TEnvironment
    //-----------------------------------------------------------------------------------------------------
    public class TEnvironment : TBase_Class
    {
        public string              FileName;
        public string              Info;
        public string              Default_Path;
        public string              Default_FileName;

        //檔案名稱
        public TEnv_Base           Base = new TEnv_Base();
        public TEnv_Log            Log = new TEnv_Log();
        public TEnv_COM_Port       COM_Port = new TEnv_COM_Port();
        public TEnv_PLC            PLC = new TEnv_PLC();
        public TEnv_Light Light = new TEnv_Light();
        public TEnv_Reader Reader = new TEnv_Reader();


        public TEnvironment()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnvironment();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnvironment && dis_base is TEnvironment)
            {
                TEnvironment sor = (TEnvironment)sor_base;
                TEnvironment dis = (TEnvironment)dis_base;

                dis.Base.Set(sor.Base);
                dis.Log.Set(sor.Log);
                dis.COM_Port.Set(sor.COM_Port);
                dis.PLC.Set(sor.PLC);
                dis.Reader.Set(sor.Reader);
                dis.Light.Set(sor.Light);
            }
        }
        public void Set_Default()
        {
            Base.Set_Default();
            Log.Set_Default();
            PLC.Set_Default();
            Light.Set_Default();
            //CCDs.Set_Default();
            //Printer.Set_Default();
            Reader.Set_Default();
        }
        public bool Read(string filename="", string section="Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "") filename = Default_Path + Default_FileName;
            if (System.IO.File.Exists(filename))
            {
                FileName = filename;
                ini = new TJJS_XML_File(FileName);
                result = Read(ini, section);
            }
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "") filename = Default_Path + Default_FileName;
            {
                FileName = filename;
                ini = new TJJS_XML_File(FileName);
                result = Write(ini, section);
                ini.Save_File();
            }
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Base.Read(ini, section + "/Base");
                Log.Read(ini, section + "/Log");
                COM_Port.Read(ini, section + "/COM_Port");
                Light.Read(ini, section + "/Light");
                PLC.Read(ini, section + "/PLC");
                Reader.Read(ini, section + "/Reader");

            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Base.Write(ini, section + "/Base");
                Log.Write(ini, section + "/Log");
                COM_Port.Write(ini, section + "/COM_Port");
                PLC.Write(ini, section + "/PLC");
                Reader.Write(ini, section + "/Reader");
                Light.Write(ini, section + "/Light");
            }
            return true;
        }

    }

    //-----------------------------------------------------------------------------------------------------
    // TEnv_Base
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_Base : TBase_Class
    {
        public string Recipe_Path,
                      Database_Path;
        public string Recipe_Name;
        public bool Auto_Log_Out;
        public int Auto_Log_Out_Time;
        public string Language;
        public bool Cal_White;
        public double Image_Mult;

        public TEnv_Base()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_Base();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_Base && dis_base is TEnv_Base)
            {
                TEnv_Base sor = (TEnv_Base)sor_base;
                TEnv_Base dis = (TEnv_Base)dis_base;
                dis.Recipe_Path = sor.Recipe_Path;
                dis.Database_Path = sor.Database_Path;

                dis.Recipe_Name = sor.Recipe_Name;
                dis.Auto_Log_Out = sor.Auto_Log_Out;
                dis.Auto_Log_Out_Time = sor.Auto_Log_Out_Time;
                dis.Language = sor.Language;
                dis.Cal_White = sor.Cal_White;
                dis.Image_Mult = sor.Image_Mult;
            }
        }


        public void Set_Default()
        {
            Recipe_Path = "";
            Database_Path = "";
            Recipe_Name = "";
            Auto_Log_Out = true;
            Auto_Log_Out_Time = 5;
            Language = "中文";
            Cal_White = true;
            Image_Mult = 1.0;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Recipe_Path = ini.ReadString(section, "Recipe_Path", Recipe_Path);
                Database_Path = ini.ReadString(section, "Database_Path", Database_Path);
                if (Recipe_Path == "") Recipe_Path = "E:\\Produxe\\";
                if (Database_Path == "") Database_Path = "E:\\Database\\";

                Recipe_Name = ini.ReadString(section, "Recipe_Name", Recipe_Name);
                Language = ini.ReadString(section, "Language", Language);

                Auto_Log_Out = ini.ReadBool(section, "Auto_Log_Out", Auto_Log_Out);
                Auto_Log_Out_Time = ini.ReadInteger(section, "Auto_Log_Out_Time", Auto_Log_Out_Time);
                Cal_White = ini.ReadBool(section, "Cal_White", Cal_White);
                Image_Mult = ini.ReadFloat(section, "Image_Mult", Image_Mult);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteString(section, "Recipe_Path", Recipe_Path);
                ini.WriteString(section, "Database_Path", Database_Path);

                ini.WriteString(section, "Recipe_Name", Recipe_Name);
                ini.WriteString(section, "Language", Language);

                ini.WriteBool(section, "Auto_Log_Out", Auto_Log_Out);
                ini.WriteInteger(section, "Auto_Log_Out_Time", Auto_Log_Out_Time);
                ini.WriteBool(section, "Cal_White", Cal_White);
                ini.WriteFloat(section, "Image_Mult", Image_Mult);
            }
        }
    }


    //-----------------------------------------------------------------------------------------------------
    // TEnv_Light
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_Light : TBase_Class
    {
        public int EFC_Light1_COM_Port;

        public TEnv_Light()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_Light();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_Light && dis_base is TEnv_Light)
            {
                TEnv_Light sor = (TEnv_Light)sor_base;
                TEnv_Light dis = (TEnv_Light)dis_base;
                dis.EFC_Light1_COM_Port = sor.EFC_Light1_COM_Port;
            }
        }


        public void Set_Default()
        {
            EFC_Light1_COM_Port = 1;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                EFC_Light1_COM_Port = ini.ReadInteger(section, "EFC_Light1_COM_Port", EFC_Light1_COM_Port);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteInteger(section, "EFC_Light1_COM_Port", EFC_Light1_COM_Port);
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TEnv_Log
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_Log : TBase_Class
    {
        public bool Save_Sor_Image,
                                Save_OK_Image,
                                Save_NG_Image,
                                Auto_Delete_File,
                                Write_Log;
        public int Days_Count;
        public string Save_Image_Type;


        public TEnv_Log()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_Log();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_Log && dis_base is TEnv_Log)
            {
                TEnv_Log sor = (TEnv_Log)sor_base;
                TEnv_Log dis = (TEnv_Log)dis_base;
                dis.Save_Sor_Image = sor.Save_Sor_Image;
                dis.Save_OK_Image = sor.Save_OK_Image;
                dis.Save_NG_Image = sor.Save_NG_Image;
                dis.Auto_Delete_File = sor.Auto_Delete_File;
                dis.Write_Log = sor.Write_Log;
                dis.Days_Count = sor.Days_Count;
                dis.Save_Image_Type = sor.Save_Image_Type;
            }
        }


        public void Set_Default()
        {
            Save_Sor_Image = true;
            Save_OK_Image = true;
            Save_NG_Image = true;
            Auto_Delete_File = true;
            Write_Log = true;
            Days_Count = 30;
            Save_Image_Type = "BMP";
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Save_Sor_Image = ini.ReadBool(section, "Save_Sor_Image", Save_Sor_Image);
                Save_OK_Image = ini.ReadBool(section, "Save_OK_Image", Save_OK_Image);
                Save_NG_Image = ini.ReadBool(section, "Save_NG_Image", Save_NG_Image);
                Auto_Delete_File = ini.ReadBool(section, "Auto_Delete_File", Auto_Delete_File);
                Write_Log = ini.ReadBool(section, "Write_Log", Write_Log);
                Days_Count = ini.ReadInteger(section, "Days_Count", Days_Count);
                Save_Image_Type = ini.ReadString(section, "Save_Image_Type", Save_Image_Type);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            bool result;
            if (ini != null && section != "")
            {
                ini.WriteBool(section, "Save_Sor_Image", Save_Sor_Image);
                ini.WriteBool(section, "Save_OK_Image", Save_OK_Image);
                ini.WriteBool(section, "Save_NG_Image", Save_NG_Image);
                ini.WriteBool(section, "Auto_Delete_File", Auto_Delete_File);
                ini.WriteBool(section, "Write_Log", Write_Log);
                ini.WriteInteger(section, "Days_Count", Days_Count);
                ini.WriteString(section, "Save_Image_Type", Save_Image_Type);
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TEnv_COM_Port
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_COM_Port : TBase_Class
    {
        public int Printer;
    //    public int Casette_Reader;



        public TEnv_COM_Port()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_COM_Port();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_COM_Port && dis_base is TEnv_COM_Port)
            {
                TEnv_COM_Port sor = (TEnv_COM_Port)sor_base;
                TEnv_COM_Port dis = (TEnv_COM_Port)dis_base;

                dis.Printer = sor.Printer;
              //  dis.Casette_Reader = sor.Casette_Reader;
            }
        }


        public void Set_Default()
        {
            Printer = 1;
           // Casette_Reader = 2;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Printer = ini.ReadInteger(section, "Printer", Printer);
              //  Casette_Reader = ini.ReadInteger(section, "Casette_Reader", Casette_Reader);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            bool result;
            if (ini != null && section != "")
            {
                ini.WriteInteger(section, "Printer", Printer);
              //  ini.WriteInteger(section, "Casette_Reader", Casette_Reader);
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TEnv_PLC
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_PLC : TBase_Class
    {
        public string           Host;
        public int              Port;
        public string           In_Start_Code,
                                Out_Start_Code,
                                Recipe_Start_Code;

        public int              In_Count,
                                Out_Count,
                                Recipe_Count;

        public TEnv_PLC()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_PLC();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_PLC && dis_base is TEnv_PLC)
            {
                TEnv_PLC sor = (TEnv_PLC)sor_base;
                TEnv_PLC dis = (TEnv_PLC)dis_base;
                dis.Host = sor.Host;
                dis.Port = sor.Port;
                dis.In_Start_Code = sor.In_Start_Code;
                dis.Out_Start_Code = sor.Out_Start_Code;
                dis.Recipe_Start_Code = sor.Recipe_Start_Code;

                dis.In_Count = sor.In_Count;
                dis.Out_Count = sor.Out_Count;
                dis.Recipe_Count = sor.Recipe_Count;
            }
        }

        
        public void Set_Default()
        {
            Host = "192.168.0.100";
            Port = 5002;
            In_Start_Code = "D100";
            Out_Start_Code = "D200";
            Recipe_Start_Code = "D300";

            In_Count = 100;
            Out_Count = 100;
            Recipe_Count = 300;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Host = ini.ReadString(section, "Host", Host);
                Port = ini.ReadInteger(section, "Port", Port);
                In_Start_Code = ini.ReadString(section, "In_Start_Code", In_Start_Code);
                Out_Start_Code = ini.ReadString(section, "Out_Start_Code", Out_Start_Code);
                Recipe_Start_Code = ini.ReadString(section, "Recipe_Start_Code", Recipe_Start_Code);

                In_Count = ini.ReadInteger(section, "In_Count", In_Count);
                Out_Count = ini.ReadInteger(section, "Out_Count", Out_Count);
                Recipe_Count = ini.ReadInteger(section, "Recipe_Count", Recipe_Count);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteString(section, "Host", Host);
                ini.WriteInteger(section, "Port", Port);

                ini.WriteString(section, "In_Start_Code", In_Start_Code);
                ini.WriteString(section, "Out_Start_Code", Out_Start_Code);
                ini.WriteString(section, "Recipe_Start_Code", Recipe_Start_Code);

                ini.WriteInteger(section, "In_Count", In_Count);
                ini.WriteInteger(section, "Out_Count", Out_Count);
                ini.WriteInteger(section, "Recipe_Count", Recipe_Count);
            }
        }
    }

        //-----------------------------------------------------------------------------------------------------
    // TEnv_Reader
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_Reader : TBase_Class
    {
        public string           Host;
        public int              Port;

        public TEnv_Reader()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_Reader();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_Reader && dis_base is TEnv_Reader)
            {
                TEnv_Reader sor = (TEnv_Reader)sor_base;
                TEnv_Reader dis = (TEnv_Reader)dis_base;

                dis.Host = sor.Host;
                dis.Port = sor.Port;
            }
        }


        public void Set_Default()
        {
            Host = "127.0.0.1";
            Port = 0;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Host = ini.ReadString(section, "Host", Host);
                Port = ini.ReadInteger(section, "Port", Port);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteString(section, "Host", Host);
                ini.WriteInteger(section, "Port", Port);
            }
        }
    }
}
