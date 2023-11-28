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
using EFC.CAD;
using EFC.Printer.Zebra;



namespace Main
{
    public partial class TForm_Select_Recipe : Form
    {
        public string                 Default_Path,
                                      Default_FileName;
        public TRecipe                Param = new TRecipe();

        public TForm_Select_Recipe()
        {
            InitializeComponent();
        }
        private void TForm_Select_Recipe_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TV_Menu.TopNode.Expand();
            PageControl_Tool.Tab_Page_Hide(tabControl1);
        }
        public void Set_Param(TRecipe param)
        {
            Param.Set(param);
            Set_Param();
        }
        public void Set_Param()
        {
            E_Recipe_Name.Text = Param.Recipe_Name;
            E_Recipe_Info.Text = Param.Info;
            Set_Param_Value_List();
            SB_Tear_Off.Value = Param.Printer_Tear_Off;
            E_Tear_Off.Text = Param.Printer_Tear_Off.ToString();

            Param.Print_Format.Disp_TextBox(E_Print_Format_List);
            Set_Param_Print_Format();
        }
        public void Set_Param_Value_List()
        {
            Param.Value_List.Set_Param_Grid(DG_Value);
        }
        public void Set_Param_Print_Format()
        {
            E_Print_Format_List.Lines = (string[])Param.Print_Format.Items.Clone();
        }

        public void Update_Param()
        {
            Param.Printer_Tear_Off = SB_Tear_Off.Value;
            Update_Param_Value_List();
            Update_Param_Print_Format();
        }
        public void Update_Param_Value_List()
        {
            Param.Value_List.Update_Param_Grid(DG_Value);
        } 
        public void Update_Param_Print_Format()
        {
            Param.Print_Format.Items = (string[])E_Print_Format_List.Lines.Clone();
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要套用設定並儲存檔案??", "套用生產設定", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Update_Param();
                DialogResult = System.Windows.Forms.DialogResult.OK;
               

               
            }
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Save_As_Click(object sender, EventArgs e)
        {
            TForm_Select_Path form = new TForm_Select_Path();
            string old_recipe_id;

            form.Default_Path = Param.Default_Path;
            form.Dialog_Type = "SaveDialog";
            form.Check_File = "produce.xml";
            form.Path_Name = Param.Recipe_Name;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MessageBox.Show("確定要套用設定並儲存檔案??", "另存生產設定", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {

                    Update_Param();
                    old_recipe_id = Param.Recipe_Name;
                    Param.Recipe_Name = form.Path_Name;
                    Param.SaveAs(old_recipe_id);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }
        private void B_Open_Click(object sender, EventArgs e)
        {
            TForm_Select_Path form = new TForm_Select_Path();

            form.Default_Path = Param.Default_Path;
            form.Check_File = "produce.xml";
            form.Path_Name = Param.Recipe_Name;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MessageBox.Show("確定要開啟檔案，套用設定??", "開啟生產設定", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    Param.Read(Param.Default_Path + form.Path_Name + "\\produce.xml");
                    E_Recipe_Name.Text = Param.Recipe_Name;
                    Set_Param();
                }
            }
        }
        private void TV_Menu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node;
            ArrayList node_list = new ArrayList();
            string node_full_name;

            node = TV_Menu.SelectedNode;
            node_full_name = TreeView_Tool.Get_Node_Full_Name(node);


            Update_Param();
            PageControl_Tool.Tab_Page_Select(tabControl1, "空白");
            switch (node_full_name)
            {
                //-----------------------------------------------------------------------------------
                //-- 參數
                //-----------------------------------------------------------------------------------
                case "\\Value_Param":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "參數");
                    break;

                //-----------------------------------------------------------------------------------
                //-- 列印格式
                //-----------------------------------------------------------------------------------
                case "\\Print_Format":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "列印格式");
                    break;

                //-----------------------------------------------------------------------------------
                //-- 標籤機
                //-----------------------------------------------------------------------------------
                case "\\Printer":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "標籤機");
                    break;
                //-----------------------------------------------------------------------------------
                //-- 機械參數
                //-----------------------------------------------------------------------------------
                case "\\Msparam":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "機械參數");
                    break;
            }
        }

        private void B_Value_Clear_Click(object sender, EventArgs e)
        {
            Param.Value_List.Clear();
        }
        private void B_Value_Move_Up_Click(object sender, EventArgs e)
        {
            int no = 0;

            Update_Param();
            no = Get_Grid_Select_Row(DG_Value);
            Param.Value_List.Move_Up(no);
            Set_Param_Value_List();
            Set_Grid_Select_Row(DG_Value, no - 1);
        }
        private void B_Value_Move_Dn_Click(object sender, EventArgs e)
        {
            int no = 0;

            Update_Param();
            no = Get_Grid_Select_Row(DG_Value);
            Param.Value_List.Move_Dn(no);
            Set_Param_Value_List();
            Set_Grid_Select_Row(DG_Value, no + 1);
        }
        private void B_Value_Add_Click(object sender, EventArgs e)
        {
            Update_Param();
            Param.Value_List.Add(new TZebra_Value());
            Set_Param_Value_List();
        }
        private void B_Value_Delete_Click(object sender, EventArgs e)
        {
            DataGridView dg = DG_Value;
            int old_select_no = 0;
            int no = 0;
            int[] select_row = null;

            Update_Param();
            old_select_no = Get_Grid_Select_Row(dg);
            select_row = Get_Grid_Select_Rows(dg);

            for (int i = 0; i < select_row.Length; i++)
            {
                no = select_row[0];
                Param.Value_List.Delete(no);
            }
            Set_Param_Value_List();
            Set_Grid_Select_Row(dg, old_select_no);
        }



        public int Get_Grid_Select_Row(DataGridView dg)
        {
            int result = -1;
            int[] select = Get_Grid_Select_Rows(dg);

            if (select.Length > 0) result = select[0];
            return result;
        }
        public int[] Get_Grid_Select_Rows(DataGridView dg)
        {
            int[] result = new int[0];
            ArrayList list = new ArrayList();
            int no = 0;
            bool select = false;

            for (int i = 0; i < dg.SelectedCells.Count; i++)
            {
                no = dg.SelectedCells[i].RowIndex;
                select = false;
                for (int j = 0; j < list.Count; j++)
                {
                    if ((int)list[j] == no)
                    {
                        select = true;
                        break;
                    }
                }
                if (!select) list.Add(no);
            }
            list.Sort();

            Array.Resize(ref result, list.Count);
            for (int i = 0; i < list.Count; i++) result[i] = (int)list[i];

            return result;
        }
        public void Set_Grid_Select_Row(DataGridView dg, int no)
        {
            if (no >= 0)
            {
                for (int i = 0; i < dg.Rows.Count; i++) dg.Rows[i].Selected = false;
                if (no < dg.Rows.Count) dg.Rows[no].Selected = true;
                else if (dg.Rows.Count > 0) dg.Rows[dg.Rows.Count - 1].Selected = true;
            }
        }
        private void B_Inport_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Print Format(*.dat)|*.dat";
            dialog.InitialDirectory = Param.Get_Recipe_Path();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Print_Format.LoadFromFile(dialog.FileName);
                Set_Param();
            }
        }
        private void SB_Tear_Off_ValueChanged(object sender, EventArgs e)
        {
            E_Tear_Off.Text = SB_Tear_Off.Value.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int num = SB_Tear_Off.Value;

            TPub.Printer.Set_Tear_Off(num);
        }

        private void B_Edit_MS_Param_Click(object sender, EventArgs e)
        {
            Param.MS_Param.Set_Param();
        }

    }



    //-----------------------------------------------------------------------------------------------------
    // TRecipe
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe : TBase_Class
    {
        public string In_Default_Path;
        public string                  Default_Path;
        public string                  Recipe_Name,
                                       Default_FileName,
                                       FileName,
                                       Info;

        public TZebra_Value_List      Value_List = new TZebra_Value_List();
        public Printer_Format         Print_Format = new Printer_Format();

        public int                    Printer_Tear_Off = 0;

        public string                 Value_Panel_ID = "%PANEL_ID%";
        public string                 Value_Cassette_ID = "%CASETTE_ID%";

        public TMS_Param MS_Param = new TMS_Param();


        public TRecipe()
        {
            MS_Param.On_Update += MS_Param_Update;
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe && dis_base is TRecipe)
            {
                TRecipe sor = (TRecipe)sor_base;
                TRecipe dis = (TRecipe)dis_base;

                dis.Default_Path = sor.Default_Path;
                dis.Recipe_Name = sor.Recipe_Name;
                dis.Default_FileName = sor.Default_FileName;
                dis.FileName = sor.FileName;
                dis.Info = sor.Info;

                dis.Value_List.Set(sor.Value_List);
                dis.Print_Format.Set(sor.Print_Format);
                dis.Printer_Tear_Off = sor.Printer_Tear_Off;
                dis.Update_Default_Path();
                dis.Update();
                dis.MS_Param.Set(sor.MS_Param);
              //  dis.Default_Path = sor.Default_Path;
            }
        }


        public void Set_Default()
        {
            Default_Path = "";
            Recipe_Name = "Default";
            Default_FileName = "produce.xml";
            Info = "";

            Value_List.Set_Default();
            MS_Param_Set_Default();
            Print_Format.Set_Default();
        }
        public void MS_Param_Set_Default()
        {
            string section = "";

            MS_Param.Clear();
            #region LD
            section = "LD升降/供料";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "供料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "供料完成位置", "", false, false, MS_Param_Value_Get);
           

      
            section = "LD升降/出料";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "供料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "供料完成位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region 取料手臂
            section = "取料手臂/X";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "放料位置", "", false, false, MS_Param_Value_Get);
            section = "取料手臂/供料Y";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取料位置", "", false, false, MS_Param_Value_Get);
            
            section = "取料手臂/供料Z";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "放料位置", "", false, false, MS_Param_Value_Get);
            section = "取料手臂/出料Y";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取料位置", "", false, false, MS_Param_Value_Get);
            section = "取料手臂/出料Z";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "放料位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region 載台
            section = "載台/Y";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "讀碼位置", "", false, false, MS_Param_Value_Get);
            section = "載台/靠位X";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "靠位位置", "", false, false, MS_Param_Value_Get);
            section = "載台/靠位Y";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "靠位位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region 貼標手臂
            section = "貼標手臂/X";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "讀碼位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取標位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "貼標位置", "", false, false, MS_Param_Value_Get);
            section = "貼標手臂/Y";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "讀碼位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取標位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "貼標位置", "", false, false, MS_Param_Value_Get);
            section = "貼標手臂/Q";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "讀碼位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取標位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "貼標位置", "", false, false, MS_Param_Value_Get);
            
            #endregion

            #region ULD手臂
            section = "ULD手臂/Y";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "出料位置", "", false, false, MS_Param_Value_Get);

            section = "ULD手臂/Z";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "出料位置", "", false, false, MS_Param_Value_Get);
            #endregion
       
        }
        public void MS_Param_Value_Get(TMS_Info_Section section, TMS_Info_Value value)
        {
            double tmp_value = 0;
            string name = section.Name + "/" + value.Name;

            switch (name)
            {
                
            }
        }
        public void MS_Param_Update(TMS_Param param)
        {
            string section = "";
            double base_value = 0;
            double value = 0;
            string info = "";

        }
        public bool SaveAs(string sor_recipe_id)
        {
            bool result = true;
            //string sor_path, dis_path, tmp_path;
            //string sor_filename, dis_filename;
            //int d_no;
            //
            //sor_path = Default_Path + sor_recipe_id + "\\";
            //dis_path = Default_Path + Recipe_Name + "\\";
            //System.IO.Directory.CreateDirectory(dis_path);

            ////die golden image
            //for (int i = 0; i < Die_Mapping.Golden_Die_Count; i++ )
            //{
            //    d_no = Die_Mapping.Golden_Die[i].No;
            //    tmp_path = dis_path + Get_Die_Path(d_no);
            //    System.IO.Directory.CreateDirectory(tmp_path);
            //
            //    for (int j = 0; j < Die_Mapping.Golden_Die[i].Area_Count; j++)
            //    {
            //        sor_filename = sor_path + Get_Die_Path(d_no) + Get_Die_Area_Name(d_no, j);
            //        dis_filename = dis_path + Get_Die_Path(d_no) + Get_Die_Area_Name(d_no, j);
            //
            //        if (System.IO.File.Exists(sor_filename)) 
            //            System.IO.File.Copy(sor_filename, dis_filename, true);
            //    }
            //}

            //Write();
            return result;
        }
        public void Set_Default_Path(string path)
        {
            string tmp_path = "";
            In_Default_Path = path;

            tmp_path = Get_Recipe_Path();
          //  Panel.Default_Path = tmp_path + "Panel\\";
           // Printer.Default_Path = tmp_path + "Printer\\";
            MS_Param.Default_Path = tmp_path + "MS_Param\\";
        }
        public string Get_Recipe_Path()
        {
            string result;
            result = Default_Path + Recipe_Name + "\\";
            return result;
        }
        public string Get_Recipe_Name(string file_name)
        {
            string result;

            result = System.IO.Path.GetDirectoryName(file_name);
            result = System.IO.Path.GetFileName(result);
            return result;                     
        }
        public void Update_Default_Path()
        {
            string path = Get_Recipe_Path();
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "")
                FileName = Default_Path + Recipe_Name + "\\" + Default_FileName;
            else
                FileName = filename;
            Recipe_Name = Get_Recipe_Name(FileName);
            ini = new TJJS_XML_File(FileName);
            result = Read(ini, section);
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "")
                FileName = Default_Path + Recipe_Name + "\\" + Default_FileName;
            else
                FileName = filename;
            Recipe_Name = Get_Recipe_Name(FileName);
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();

            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Update_Default_Path();

                Info = ini.ReadString(section, "Info", "");
                Value_List.Read(ini, section + "/Value_List");
                Print_Format.Read(ini, section + "/Print_Format");
                Printer_Tear_Off = ini.ReadInteger(section, "Printer_Tear_Off", Printer_Tear_Off);
                Read_Other_File();
                Update();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Update_Default_Path();

                ini.WriteString(section, "Info", Info);
                Value_List.Write(ini, section + "/Value_List");
                Print_Format.Write(ini, section + "/Print_Format");
                ini.WriteInteger(section, "Printer_Tear_Off", Printer_Tear_Off);

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
        public void Add_Default_Value()
        {
            Value_List.Add(Value_Panel_ID, "", "Panel_ID");
            Value_List.Add(Value_Cassette_ID, "", "Casette_ID");
        }
        public void Update()
        {
            Add_Default_Value();
        }
    }
    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Printer
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Printer : TBase_Class
    {
        public string In_Default_Path = "";
        public TZebra_Value_List Value_List = new TZebra_Value_List();
        public Printer_Format Format1 = new Printer_Format();
        public Printer_Format Format2 = new Printer_Format();
        public int Tear_Off = 0;

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_Printer()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Printer();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Printer && dis_base is TRecipe_Printer)
            {
                TRecipe_Printer sor = (TRecipe_Printer)sor_base;
                TRecipe_Printer dis = (TRecipe_Printer)dis_base;

                dis.Value_List.Set(sor.Value_List);
                dis.Format1.Set(sor.Format1);
                dis.Format2.Set(sor.Format2);
            }
        }

        public void Set_Default()
        {
            Value_List.Set_Default();
            Format1.Set_Default();
            Format2.Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Value_List.Read(ini, section + "/Value_List");
                Format1.Read(ini, section + "/Print_Format1");
                Format2.Read(ini, section + "/Print_Format2");
                Tear_Off = ini.ReadInteger(section, "Tear_Off", Tear_Off);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Value_List.Write(ini, section + "/Value_List");
                Format1.Write(ini, section + "/Print_Format1");
                Format2.Write(ini, section + "/Print_Format2");
                ini.WriteInteger(section, "Tear_Off", Tear_Off);
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TRecipe_Printer new_value, ref bool flag)
        {
            //Value_List.Log_Diff(log, section + "/Value_List", new_value.Value_List, ref flag);
            //Format1.Log_Diff(log, section + "/Format1", new_value.Format1, ref flag);
            //Format2.Log_Diff(log, section + "/Format2", new_value.Format2, ref flag);
            log.Log_Diff(section + "/Tear_Off", Tear_Off, new_value.Tear_Off, ref flag);
        }
    }
}
