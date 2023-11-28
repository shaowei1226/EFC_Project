﻿using System;
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
        public static int Lens_Count = 3;
        public TEnvironment Param = new TEnvironment();
        public TEnv_CCD CCD = null;

        public TForm_Environment()
        {
            InitializeComponent();
        }
        private void TForm_Environment_Shown(object sender, EventArgs e)
        {
            TreeView_Set_CCDs();
            TV_Menu.TopNode.Expand();
            PageControl_Tool.Tab_Page_Hide(tabControl1);
            PageControl_Tool.Tab_Page_Select(tabControl1, "基本參數");
        }
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
            Set_Param_Light();
            Set_Param_CCD();
            Set_Param_Printer();
            Set_Param_Reader();
        }
        public void Set_Param_Base()
        {
            E_Recipe_Path.Text = Param.Base.Recipe_Path;
            E_Database_Path.Text = Param.Base.Database_Path;
            E_Recipe_ID.Text = Param.Base.Recipe_Name;
            CB_Auto_Logout.Checked = Param.Base.Auto_Log_Out;
            E_Auto_Logout_Time.Text = Param.Base.Auto_Log_Out_Time.ToString();
            E_Language.Text = Param.Base.Language;
        }
        public void Set_Param_Log()
        {
            //畫面設定
            CB_Save_Sor_Image.Checked = Param.Log.Save_Sor_Image;
            CB_Save_OK_Image.Checked = Param.Log.Save_OK_Image;
            CB_Save_NG_Image.Checked = Param.Log.Save_NG_Image;
            CB_Auto_Delete_File.Checked = Param.Log.Auto_Delete_File;
            CB_Write_Log.Checked = Param.Log.Write_Log;
            E_Delete_Days.Text = string.Format("{0:d}", Param.Log.Days_Count);
        }
        public void Set_Param_PLC()
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
        public void Set_Param_Light()
        {
            CB_Grab_Light.Text = Param.Light.EFC_Light_COM_Port.ToString();
        }
        public void Set_Param_CCD()
        {
            if (CCD != null)
            {
                CB_Lens_Enabled.Checked = CCD.Enabled;
                E_Lens_Name.Text = CCD.Name;
                E_Lens_CCD_Name.Text = CCD.CCD_Name;
                E_Lens_Pixel_X.Text = CCD.Pixel_X.ToString();
                E_Lens_Pixel_Y.Text = CCD.Pixel_Y.ToString();
                E_Lens_Pixel_Size_X.Text = CCD.Pixel_Size_X_um.ToString("0.0000");
                E_Lens_Pixel_Size_Y.Text = CCD.Pixel_Size_Y_um.ToString("0.0000");
                E_Lens_FOV_X.Text = CCD.FOV_X.ToString("0.0000");
                E_Lens_FOV_Y.Text = CCD.FOV_Y.ToString("0.0000");
            }
        }
        public void Set_Param_Printer()
        {
            CB_Printer_Com_Port.Text = Param.Printer.COM_Port.ToString();
        }
        public void Set_Param_Reader()
        {
            E_Reader_Host.Text = Param.Reader.Host;
            E_Reader_Port.Text = Param.Reader.Port.ToString();
        }

        public void Update_Param()
        {
            Update_Param_Base();
            Update_Param_Log();
            Update_Param_PLC();
            Update_Param_Light();
            Update_Param_CCD();
            Update_Param_Robot();
            Update_Param_Reader();
        }
        public void Update_Param_Base()
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
        public void Update_Param_Log()
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
        public void Update_Param_PLC()
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
        public void Update_Param_Light()
        {
            try
            {
                Param.Light.EFC_Light_COM_Port = CB_Grab_Light.SelectedIndex + 1;
            }
            catch { };
        }
        public void Update_Param_CCD()
        {
            if (CCD != null)
            {
                try
                {
                    CCD.Enabled = CB_Lens_Enabled.Checked;
                    CCD.Name = E_Lens_Name.Text;
                    CCD.Pixel_X = Convert.ToInt32(E_Lens_Pixel_X.Text);
                    CCD.Pixel_Y = Convert.ToInt32(E_Lens_Pixel_Y.Text);
                    CCD.Pixel_Size_X = Convert.ToDouble(E_Lens_Pixel_Size_X.Text) / 1000;
                    CCD.Pixel_Size_Y = Convert.ToDouble(E_Lens_Pixel_Size_Y.Text) / 1000;
                }
                catch { };
            }
        }
        public void Update_Param_Robot()
        {
            try
            {
                Param.Printer.COM_Port = CB_Printer_Com_Port.SelectedIndex + 1;
            }
            catch { };

        }
        public void Update_Param_Reader()
        {
            try
            {
                Param.Reader.Host = E_Reader_Host.Text;
                Param.Reader.Port = Convert.ToInt32(E_Reader_Port.Text);
            }
            catch { };
        }

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
            CCD = null;
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
                //-- Log設定
                //-----------------------------------------------------------------------------------
                case "\\Log":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Log設定");
                    break;

                //-----------------------------------------------------------------------------------
                //-- PLC設定
                //-----------------------------------------------------------------------------------
                case "\\PLC":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "PLC設定");
                    break;

                //-----------------------------------------------------------------------------------
                //-- MES設定
                //-----------------------------------------------------------------------------------
                case "\\MES":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "MES設定");
                    break;

                //-----------------------------------------------------------------------------------
                //-- 光源設定
                //-----------------------------------------------------------------------------------
                case "\\Light":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "光源設定");
                    break;

                //-----------------------------------------------------------------------------------
                //-- 相機設定
                //-----------------------------------------------------------------------------------
                case "\\CCD\\Lens":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "相機設定");
                    CCD = Param.CCDs[String_Tool.Get_Name_No(node_full_text, "\\", 2)];
                  break;

                //-----------------------------------------------------------------------------------
                //-- Printer
                //-----------------------------------------------------------------------------------
                case "\\Printer":
                  PageControl_Tool.Tab_Page_Select(tabControl1, "Printer設定");
                  break;

                //-----------------------------------------------------------------------------------
                //-- Reader
                //-----------------------------------------------------------------------------------
                case "\\Reader":
                  PageControl_Tool.Tab_Page_Select(tabControl1, "Reader設定");
                  break;
            }
            Set_Param();
        }
        public void TreeView_Set_CCDs()
        {
            TreeNode key_tree = null;
            string tmp_str;
            TreeNode node = null;

            key_tree = TreeView_Tool.Find_Node_Name(TV_Menu, "CCD");
            if (key_tree != null)
            {
                key_tree.Nodes.Clear();
                for (int i = 0; i < Param.CCDs.Count; i++)
                {
                    tmp_str = string.Format("Lens{0:d2}", i + 1);
                    node = key_tree.Nodes.Add("Lens", tmp_str, 0, 0);
                }
            }
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

        public TEnv_Base           Base = new TEnv_Base();                 
        public TEnv_Log            Log = new TEnv_Log();
        public TEnv_PLC            PLC = new TEnv_PLC();
        public TEnv_MES            MES = new TEnv_MES();
        public TEnv_Light          Light = new TEnv_Light();
        public TEnv_CCD_List       CCDs = new TEnv_CCD_List();
        public TEnv_Printer        Printer = new TEnv_Printer();
        public TEnv_Reader         Reader = new TEnv_Reader();

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
                dis.FileName = sor.FileName;
                dis.Info = sor.Info;
                dis.Default_Path = sor.Default_Path;
                dis.Default_FileName = sor.Default_FileName;

                dis.Base.Set(sor.Base);
                dis.Log.Set(sor.Log);
                dis.PLC.Set(sor.PLC);
                dis.Light.Set(sor.Light);
                dis.CCDs.Set(sor.CCDs);
                dis.Printer.Set(sor.Printer);
                dis.Reader.Set(sor.Reader);
            }
        }
        public void Set_Default()
        {
            Base.Set_Default();
            Log.Set_Default();
            PLC.Set_Default();
            Light.Set_Default();
            CCDs.Set_Default();
            Printer.Set_Default();
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
                PLC.Read(ini, section + "/PLC");
                Light.Read(ini, section + "/Light");
                CCDs.Read(ini, section + "/CCD");
                Printer.Read(ini, section + "/Printer");
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
                PLC.Write(ini, section + "/PLC");
                Light.Write(ini, section + "/Light");
                CCDs.Write(ini, section + "/CCD");
                Printer.Write(ini, section + "/Printer");
                Reader.Write(ini, section + "/Reader");
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
        public bool   Auto_Log_Out;
        public int    Auto_Log_Out_Time;
        public string Language;


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
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            bool result;
            if (ini != null && section != "")
            {
                ini.WriteString(section, "Recipe_Path", Recipe_Path);
                ini.WriteString(section, "Database_Path", Database_Path);

                ini.WriteString(section, "Recipe_Name", Recipe_Name);
                ini.WriteString(section, "Language", Language);

                ini.WriteBool(section, "Auto_Log_Out", Auto_Log_Out);
                ini.WriteInteger(section, "Auto_Log_Out_Time", Auto_Log_Out_Time);
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
    // TEnv_Light
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_Light : TBase_Class
    {
        public int EFC_Light_COM_Port;


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
                dis.EFC_Light_COM_Port = sor.EFC_Light_COM_Port;
            }
        }


        public void Set_Default()
        {
            EFC_Light_COM_Port = 1;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                EFC_Light_COM_Port = ini.ReadInteger(section, "EFC_Light_COM_Port", EFC_Light_COM_Port);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteInteger(section, "EFC_Light_COM_Port", EFC_Light_COM_Port);
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

        public string           In_Start_Code;
        public int              In_Count;

        public string           Out_Start_Code;
        public int              Out_Count;

        public string           Recipe_Start_Code;
        public int              Recipe_Count;

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
                dis.In_Count = sor.In_Count;

                dis.Out_Start_Code = sor.Out_Start_Code;
                dis.Out_Count = sor.Out_Count;

                dis.Recipe_Start_Code = sor.Recipe_Start_Code;
                dis.Recipe_Count = sor.Recipe_Count;
            }
        }

        
        public void Set_Default()
        {
            Host = "192.168.0.100";
            Port = 5002;
            In_Start_Code = "D100";
            In_Count = 100;
          
            Out_Start_Code = "D200";
            Out_Count = 100;

            Recipe_Start_Code = "D300"; 
            Recipe_Count = 300;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Host = ini.ReadString(section, "Host", Host);
                Port = ini.ReadInteger(section, "Port", Port);

                In_Start_Code = ini.ReadString(section, "In_Start_Code", In_Start_Code);
                In_Count = ini.ReadInteger(section, "In_Count", In_Count);

                Out_Start_Code = ini.ReadString(section, "Out_Start_Code", Out_Start_Code);
                Out_Count = ini.ReadInteger(section, "Out_Count", Out_Count);

                Recipe_Start_Code = ini.ReadString(section, "Recipe_Start_Code", Recipe_Start_Code);
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
                ini.WriteInteger(section, "In_Count", In_Count);

                ini.WriteString(section, "Out_Start_Code", Out_Start_Code);
                ini.WriteInteger(section, "Out_Count", Out_Count);

                ini.WriteString(section, "Recipe_Start_Code", Recipe_Start_Code);
                ini.WriteInteger(section, "Recipe_Count", Recipe_Count);
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TEnv_MES
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_MES : TBase_Class
    {
        public string Host;
        public int Port;

        public TEnv_MES()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_PLC();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_MES && dis_base is TEnv_MES)
            {
                TEnv_MES sor = (TEnv_MES)sor_base;
                TEnv_MES dis = (TEnv_MES)dis_base;
                dis.Host = sor.Host;
                dis.Port = sor.Port;
            }
        }


        public void Set_Default()
        {
            Host = "192.168.1.135";
            Port = 8021;
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

    //-----------------------------------------------------------------------------------------------------
    // TEnv_CCD
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_CCD_List : TBase_Class
    {
        private TEnv_CCD[] Items = new TEnv_CCD[0];


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
                        Items[i] = new TEnv_CCD();
                }
            }
        }
        public TEnv_CCD this[int index]
        {
            get
            {
                TEnv_CCD result = null;
                if (index >= 0 && index < Items.Length) result = Items[index];
                return result;
            }
        }
        public TEnv_CCD_List()
        {
            Count = 4;
            for (int i = 0; i < Items.Length; i++) Items[i] = new TEnv_CCD();
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_CCD_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_CCD_List && dis_base is TEnv_CCD_List)
            {
                TEnv_CCD_List sor = (TEnv_CCD_List)sor_base;
                TEnv_CCD_List dis = (TEnv_CCD_List)dis_base;
                for (int i = 0; i < dis.Items.Length; i++)
                {
                    dis.Items[i].Set(sor.Items[i]);
                }
            }
        }

        public void Set_Default()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].Set_Default();
            }
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                for (int i = 0; i < Items.Length; i++)
                    Items[i].Read(ini, section + string.Format("/CCD{0:d}", i + 1));

                Items[0].CCD_Name = "Big_L";
                Items[1].CCD_Name = "Big_R";
                Items[2].CCD_Name = "Small_L";
                Items[3].CCD_Name = "Small_R";
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                for (int i = 0; i < Items.Length; i++)
                    Items[i].Write(ini, section + string.Format("/CCD{0:d}", i + 1));
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TEnv_Lens
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_CCD : TBase_Class
    {
        public string           Name;
        public string           CCD_Name;        
        public bool             Enabled;
        public int              Pixel_X,
                                Pixel_Y;
        public double           Pixel_Size_X,
                                Pixel_Size_Y;


        public double FOV_X
        {
            get
            {
                return Pixel_X * Pixel_Size_X;
            }
        }
        public double FOV_Y
        {
            get
            {
                return Pixel_Y * Pixel_Size_Y;
            }
        }
        public double Pixel_Size_X_um
        {
            get
            {
                return Pixel_Size_X * 1000;
            }
        }
        public double Pixel_Size_Y_um
        {
            get
            {
                return Pixel_Size_Y * 1000;
            }
        }
        public TEnv_CCD()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_CCD();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_CCD && dis_base is TEnv_CCD)
            {
                TEnv_CCD sor = (TEnv_CCD)sor_base;
                TEnv_CCD dis = (TEnv_CCD)dis_base;
                dis.Name = sor.Name;
                dis.CCD_Name = sor.CCD_Name;
                dis.Enabled = sor.Enabled;
                dis.Pixel_X = sor.Pixel_X;
                dis.Pixel_Y = sor.Pixel_Y;
                dis.Pixel_Size_X = sor.Pixel_Size_X;
                dis.Pixel_Size_Y = sor.Pixel_Size_Y;
            }
        }

        
        public void Set_Default()
        {
            Name = "CCD";
            Enabled = true;
            Pixel_X = 1024;
            Pixel_Y = 768;
            Pixel_Size_X = 0.010;
            Pixel_Size_Y = 0.010;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Name = ini.ReadString(section, "Name", Name);
                CCD_Name = ini.ReadString(section, "CCD_Name", CCD_Name);
                Enabled = ini.ReadBool(section, "Enabled", Enabled);
                Pixel_X = ini.ReadInteger(section, "Pixel_X", Pixel_X);
                Pixel_Y = ini.ReadInteger(section, "Pixel_Y", Pixel_Y);
                Pixel_Size_X = ini.ReadFloat(section, "Pixel_Size_X", Pixel_Size_X);
                Pixel_Size_Y = ini.ReadFloat(section, "Pixel_Size_Y", Pixel_Size_Y);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteString(section, "Name", Name);
                ini.WriteString(section, "CCD_Name", CCD_Name);
                ini.WriteBool(section, "Enabled", Enabled);
                ini.WriteInteger(section, "Pixel_X", Pixel_X);
                ini.WriteInteger(section, "Pixel_Y", Pixel_Y);
                ini.WriteFloat(section, "Pixel_Size_X", Pixel_Size_X);
                ini.WriteFloat(section, "Pixel_Size_Y", Pixel_Size_Y);
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TEnv_Printer
    //-----------------------------------------------------------------------------------------------------
    public class TEnv_Printer : TBase_Class
    {
        public int COM_Port;



        public TEnv_Printer()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TEnv_Printer();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEnv_Printer && dis_base is TEnv_Printer)
            {
                TEnv_Printer sor = (TEnv_Printer)sor_base;
                TEnv_Printer dis = (TEnv_Printer)dis_base;

                dis.COM_Port = sor.COM_Port;
            }
        }


        public void Set_Default()
        {
            COM_Port = 9;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                COM_Port = ini.ReadInteger(section, "COM_Port", COM_Port);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteInteger(section, "COM_Port", COM_Port);
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
