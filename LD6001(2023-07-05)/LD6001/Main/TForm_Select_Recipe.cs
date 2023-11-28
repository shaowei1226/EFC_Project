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
using HalconDotNet;

using EFC.Tool;
using EFC.INI;
using EFC.Camera;
using EFC.Vision.Halcon;
using EFC.CAD;
using EFC.Light;
using EFC.Printer.Zebra;
using Cognex.DataMan;

namespace Main
{
    public partial class TForm_Select_Recipe : Form
    {
        public string                     Default_Path,
                                          Default_FileName;
        public TRecipe                    Param = new TRecipe();
        public bool                       On_Setting = false;
        public TRecipe_Panel_Model        Model = null;
        public TOfs                       Ofs = null;
        public TAlign_Limit               Align_Limit = null;
        public Printer_Format             Printer_Format = null;
        
        public TForm_Select_Recipe()
        {
            InitializeComponent();
        }
        private void TForm_Select_Recipe_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TV_Menu.TopNode.Expand();
            PageControl_Tool.Tab_Page_Hide(tabControl1);
            tFrame_JJS_HW1.Only_Window = true;
            tFrame_JJS_HW2.Only_Window = true;
        }
        public void Set_Param(TRecipe param)
        {
            Param.Set(param);
            Set_Param();
        }
        public void Set_Param()
        {
            On_Setting = true;
            E_Recipe_Code.Text = Param.Recipe_Code.ToString("0000");
            E_Recipe_Name.Text = Param.Recipe_Name;
            E_Recipe_Info.Text = Param.Info;

            Set_Param_Panel();
            Set_Param_Ofs();
            Set_Param_Limit_Ofs();
            Set_Param_Other();
            Set_Param_Painter_Format();
            Set_Param_Painter_Value_List();
            Set_Param_Box_Load();
            On_Setting = false;
        }
        public void Set_Param_Panel()
        {
            E_Panel_X.Text = Param.Panel.X.ToString("0.000");
            E_Panel_Y.Text = Param.Panel.Y.ToString("0.000");
            E_Panel_Z.Text = Param.Panel.Z.ToString("0.000");

            Set_Param_Panel_Model();
        }
        public void Set_Param_Panel_Model()
        {
            if (Model != null)
            {
                E_Panel_X.Text = Param.Panel.X.ToString("0.000");
                E_Panel_Y.Text = Param.Panel.Y.ToString("0.000");
                E_Panel_Z.Text = Param.Panel.Z.ToString("0.000");

                E_Panel_L_X.Text = Model.L_X.ToString("0.000");
                E_Panel_L_Y.Text = Model.L_Y.ToString("0.000");
                E_Panel_R_X.Text = Model.R_X.ToString("0.000");
                E_Panel_R_Y.Text = Model.R_Y.ToString("0.000");

                CB_Panel_Length_SW.Checked = Model.Limit_Length.SW;
                E_Panel_Length_Min.Text = Model.Limit_Length.Min.ToString("0.000");
                E_Panel_Length_Max.Text = Model.Limit_Length.Max.ToString("0.000");
                CB_Pre_Process_L_SW.Checked = Model.Pre_Process_L_SW;
                CB_Pre_Process_R_SW.Checked = Model.Pre_Process_R_SW;
            }
        }
        public void Set_Param_Ofs()
        {
            if (Ofs != null)
            {
                E_Ofs_X.Text = Ofs.X.ToString("0.000");
                E_Ofs_Y.Text = Ofs.Y.ToString("0.000");
                E_Ofs_Q.Text = Ofs.Q.ToString("0.000");
            }
        }
        public void Set_Param_Limit_Ofs()
        {
            if (Align_Limit != null)
            {
                CB_Limit_Ofs_DX_SW.Checked = Align_Limit.SW_DX;
                CB_Limit_Ofs_DY_SW.Checked = Align_Limit.SW_DY;
                CB_Limit_Ofs_DQ_SW.Checked = Align_Limit.SW_DQ;

                E_Limit_Ofs_DX_Min.Text = Align_Limit.DX_Min.ToString("0.000");
                E_Limit_Ofs_DX_Max.Text = Align_Limit.DX_Max.ToString("0.000");
                E_Limit_Ofs_DY_Min.Text = Align_Limit.DY_Min.ToString("0.000");
                E_Limit_Ofs_DY_Max.Text = Align_Limit.DY_Max.ToString("0.000");
                E_Limit_Ofs_DQ_Min.Text = Align_Limit.DQ_Min.ToString("0.000");
                E_Limit_Ofs_DQ_Max.Text = Align_Limit.DQ_Max.ToString("0.000");
            }
        }
        public void Set_Param_Other()
        {
            //CB_OK_Panel_Stack_Count.Text = Param.Other.OK_Panel_Stack_Count.ToString();
            //CB_OK_Tray_Stack_Count.Text = Param.Other.OK_Tray_Stack_Count.ToString();
            //CB_OK_Tray_Z.Text = Param.Other.OK_Tray_Z.ToString();

            //CB_NG_Panel_Stack_Count.Text = Param.Other.NG_Panel_Stack_Count.ToString();
            //CB_NG_Tray_Stack_Count.Text = Param.Other.NG_Tray_Stack_Count.ToString();
            //CB_NG_Tray_Z.Text = Param.Other.NG_Tray_Z.ToString();

            //E_Tray_Weight.Text = Param.Other.Tray_Weight.ToString("0.000");
            //E_Tray_Weight_Ofs.Text = Param.Other.Tray_Weight_Ofs.ToString("0.000");
        }
        public void Set_Param_Painter_Format()
        {
            if (Printer_Format != null)
            {
                Printer_Format.Disp_TextBox(E_Print_Format_List);
            }
        }
        public void Set_Param_Painter_Value_List()
        {
            E_Printer_Tear_Off.Text = Param.Printer.Tear_Off.ToString();
            Param.Printer.Value_List.Set_Param_Grid(DG_Value);
        }
        public void Set_Param_Box_Load()
        {
            E_Box_Load_X.Text = Param.Box_Load.Box_X.ToString("0.000");
            E_Box_Load_Y.Text = Param.Box_Load.Box_Y.ToString("0.000");
            E_Box_Load_Z.Text = Param.Box_Load.Box_Z.ToString("0.000");
            E_Box_Load_X_Num.Text = Param.Box_Load.X_Num.ToString("");
            E_Box_Load_Y_Num.Text = Param.Box_Load.Y_Num.ToString("");
            CB_Supply_Vacc.Checked = Param.Box_Load.Supply_Vacc;
        }


        public void Update_Param()
        {
            Param.Recipe_Code = Convert.ToInt32(E_Recipe_Code.Text);
            Param.Info = E_Recipe_Info.Text;

            Update_Param_Panel();
            Update_Param_Ofs();
            Update_Param_Limit_Ofs();
            Update_Param_Printer_Format();
            Update_Param_Printer_Value_List();
            Update_Param_Box_Load();
            Param.Update();
        }
        public void Update_Param_Panel()
        {
            try
            {
                Param.Panel.X = Convert.ToDouble(E_Panel_X.Text);
                Param.Panel.Y = Convert.ToDouble(E_Panel_Y.Text);
                Param.Panel.Z = Convert.ToDouble(E_Panel_Z.Text);
                Update_Param_Panel_Model();
            }
            catch { };
        }
        public void Update_Param_Panel_Model()
        {
            if (Model != null)
            {
                try
                {
                    Model.L_X = Convert.ToDouble(E_Panel_L_X.Text);
                    Model.L_Y = Convert.ToDouble(E_Panel_L_Y.Text);
                    Model.R_X = Convert.ToDouble(E_Panel_R_X.Text);
                    Model.R_Y = Convert.ToDouble(E_Panel_R_Y.Text);

                    Model.Limit_Length.SW = CB_Panel_Length_SW.Checked;
                    Model.Limit_Length.Min = Convert.ToDouble(E_Panel_Length_Min.Text);
                    Model.Limit_Length.Max = Convert.ToDouble(E_Panel_Length_Max.Text);
                    Model.Pre_Process_L_SW = CB_Pre_Process_L_SW.Checked;
                    Model.Pre_Process_R_SW = CB_Pre_Process_R_SW.Checked;
                }
                catch { };
            }
        }
        public void Update_Param_Ofs()
        {
            if (Ofs != null)
            {
                try
                {
                    Ofs.X = Convert.ToDouble(E_Ofs_X.Text);
                    Ofs.Y = Convert.ToDouble(E_Ofs_Y.Text);
                    Ofs.Q = Convert.ToDouble(E_Ofs_Q.Text);
                }
                catch { };
            }
        }
        public void Update_Param_Limit_Ofs()
        {
            if (Align_Limit != null)
            {
                try
                {
                    Align_Limit.SW_DX = CB_Limit_Ofs_DX_SW.Checked;
                    Align_Limit.SW_DY = CB_Limit_Ofs_DY_SW.Checked;
                    Align_Limit.SW_DQ = CB_Limit_Ofs_DQ_SW.Checked;

                    Align_Limit.DX_Min = Convert.ToDouble(E_Limit_Ofs_DX_Min.Text);
                    Align_Limit.DX_Max = Convert.ToDouble(E_Limit_Ofs_DX_Max.Text);
                    Align_Limit.DY_Min = Convert.ToDouble(E_Limit_Ofs_DY_Min.Text);
                    Align_Limit.DY_Max = Convert.ToDouble(E_Limit_Ofs_DY_Max.Text);
                    Align_Limit.DQ_Min = Convert.ToDouble(E_Limit_Ofs_DQ_Min.Text);
                    Align_Limit.DQ_Max = Convert.ToDouble(E_Limit_Ofs_DQ_Max.Text);
                }
                catch { };
            }
        }
        public void Update_Param_Printer_Format()
        {
            //Param.Printer.Value_List.Update_Param_Grid(DG_Value);
        }
        public void Update_Param_Printer_Value_List()
        {
            try
            {
                Param.Printer.Tear_Off = Convert.ToInt32(E_Printer_Tear_Off.Text);
                Param.Printer.Value_List.Update_Param_Grid(DG_Value);
            }
            catch { };
        }
        public void Update_Param_Box_Load()
        {
            try
            {
                Param.Box_Load.Box_X = Convert.ToDouble(E_Box_Load_X.Text);
                Param.Box_Load.Box_Y = Convert.ToDouble(E_Box_Load_Y.Text);
                Param.Box_Load.Box_Z = Convert.ToDouble(E_Box_Load_Z.Text);
                Param.Box_Load.X_Num = Convert.ToInt32(E_Box_Load_X_Num.Text);
                Param.Box_Load.Y_Num = Convert.ToInt32(E_Box_Load_Y_Num.Text);
                Param.Box_Load.Supply_Vacc = CB_Supply_Vacc.Checked;
            }
            catch { };
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
            TreeNode node = null;
            string[] node_full_text_list = null;
            string node_full_name;
            string node_full_text;


            node = TV_Menu.SelectedNode;
            node_full_name = TreeView_Tool.Get_Node_Full_Name(node);
            node_full_text = TreeView_Tool.Get_Node_Full_Text(node);
            node_full_text_list = String_Tool.Break_String(node_full_text, "\\");

            Update_Param();
            Model = null;
            Ofs = null;
            Align_Limit = null;
            Printer_Format = null;

            PageControl_Tool.Tab_Page_Select(tabControl1, "空白");
            switch (node_full_name)
            {
                #region Panel
                //-----------------------------------------------------------------------------------
                //-- Panel\\Size
                //-----------------------------------------------------------------------------------
                case "\\Panel\\Size":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Panel尺寸");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    break;

                //-----------------------------------------------------------------------------------
                //-- Panel\\Big
                //-----------------------------------------------------------------------------------
                case "\\Panel\\Big":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Panel對位參數");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    Model = Param.Panel.Model_Big;
                    break;

                //-----------------------------------------------------------------------------------
                //-- Panel\\Small
                //-----------------------------------------------------------------------------------
                case "\\Panel\\Small":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Panel對位參數");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    Model = Param.Panel.Model_Small;
                    break;

                //-----------------------------------------------------------------------------------
                //-- 補償
                //-----------------------------------------------------------------------------------
                case "\\Panel\\Ofs":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "補償");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    Ofs = Param.Panel.Ofs;
                    break;

                //-----------------------------------------------------------------------------------
                //-- 修正量限制
                //-----------------------------------------------------------------------------------
                case "\\Panel\\Align_Limit":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "修正量限制");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    Align_Limit = Param.Panel.Align_Limit;
                    break;
                #endregion

                #region Printer
                //-----------------------------------------------------------------------------------
                //-- Printer
                //-----------------------------------------------------------------------------------
                case "\\Printer":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "標籤機");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    break;

                //-----------------------------------------------------------------------------------
                //-- Printer\\Format1
                //-----------------------------------------------------------------------------------
                case "\\Printer\\Format1":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "列印格式");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    Printer_Format = Param.Printer.Format1;
                    break;

                //-----------------------------------------------------------------------------------
                //-- Printer\\Format2
                //-----------------------------------------------------------------------------------
                case "\\Printer\\Format2":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "列印格式");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    Printer_Format = Param.Printer.Format2;
                    break;

                //-----------------------------------------------------------------------------------
                //-- Printer\\Value
                //-----------------------------------------------------------------------------------
                case "\\Printer\\Value":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "標籤機變數");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    break;               
                #endregion

                #region Box_Load
                //-----------------------------------------------------------------------------------
                //-- Box_Load
                //-----------------------------------------------------------------------------------
                case "\\Box_Load":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Box_Load");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    break;
                #endregion

                #region 機械參數
                //-----------------------------------------------------------------------------------
                //-- 機械參數
                //-----------------------------------------------------------------------------------
                case "\\MS_Param":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "機械參數");
                    PageControl_Tool.Tab_Page_Select(tabControl2, "影像");
                    break;
                #endregion
            }
            Set_Param();
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

        #region Panel
        public emModel Get_Model_L(TRecipe_Panel_Model model)
        {
            emModel result = emModel.None;

            if (model == Param.Panel.Model_Big) result = emModel.Big_L;
            if (model == Param.Panel.Model_Small) result = emModel.Small_L;
            return result;
        }
        public emModel Get_Model_R(TRecipe_Panel_Model model)
        {
            emModel result = emModel.None;

            if (model == Param.Panel.Model_Big) result = emModel.Big_R;
            if (model == Param.Panel.Model_Small) result = emModel.Small_R;
            return result;
        }
        private void B_Panel_L_Edit_Click(object sender, EventArgs e)
        {
            emModel emModel = emModel.None;
            HImage image = new HImage();

            if (Model != null)
            {
                emModel = Get_Model_L(Model);
                TCamera_Base camera = TPub.Get_Camera(emModel);
                camera.Grab_Image(ref image);
                if (Model.Pre_Process_L_SW) image = Model.Pre_Process_L.Run_Process(image);
                Model.L.Set_Param(image);
            }
        }
        private void B_Panel_R_Edit_Click(object sender, EventArgs e)
        {
            emModel emModel = emModel.None;
            HImage image = new HImage();

            if (Model != null)
            {
                emModel = Get_Model_R(Model);
                TCamera_Base camera = TPub.Get_Camera(emModel);
                camera.Grab_Image(ref image);
                if (Model.Pre_Process_R_SW) image = Model.Pre_Process_R.Run_Process(image);
                Model.R.Set_Param(image);
            }
        }
        private void B_Panel_L_Set_Light_Click(object sender, EventArgs e)
        {
            TCamera_Base camera = null;
            TLight_Channel_List light_channels = new TLight_Channel_List();
            int[] light_value = null;
            emModel emModel = emModel.None;

            if (Model != null)
            {
                Update_Param();
                emModel = Get_Model_L(Model);
                camera = TPub.Get_Camera(emModel);
                light_value = Model.Light_L;
                light_channels = TPub.Get_Light_Channels(emModel);
                light_channels.Set_Value(light_value);
                if (light_channels.Set_Param(camera))
                {
                    light_channels.Get_Value(ref light_value);
                }
            }
        }
        private void B_Panel_R_Set_Light_Click(object sender, EventArgs e)
        {
            TCamera_Base camera = null;
            TLight_Channel_List light_channels = new TLight_Channel_List();
            int[] light_value = null;
            emModel emModel = emModel.None;

            if (Model != null)
            {
                Update_Param();
                emModel = Get_Model_R(Model);
                camera = TPub.Get_Camera(emModel);
                light_value = Model.Light_R;
                light_channels = TPub.Get_Light_Channels(emModel);
                light_channels.Set_Value(light_value);
                if (light_channels.Set_Param(camera))
                {
                    light_channels.Get_Value(ref light_value);
                }
            }
        }
        private void B_Pre_Process_Edit_L_Click(object sender, EventArgs e)
        {
            emModel emModel = emModel.None;
            HImage image = new HImage();
            TImage_Pre_Process_Param pre_process = null;

            if (Model != null)
            {
                emModel = Get_Model_L(Model);
                pre_process = Param.Panel.Model_Big.Pre_Process_L;
                TCamera_Base camera = TPub.Get_Camera(emModel);
                camera.Grab_Image(ref image);
                pre_process.Set_Param(image);
            }
        }
        private void B_Pre_Process_Edit_R_Click(object sender, EventArgs e)
        {
            emModel emModel = emModel.None;
            HImage image = new HImage();
            TImage_Pre_Process_Param pre_process = null;

            if (Model != null)
            {
                emModel = Get_Model_R(Model);
                pre_process = Param.Panel.Model_Big.Pre_Process_R;
                TCamera_Base camera = TPub.Get_Camera(emModel);
                camera.Grab_Image(ref image);
                pre_process.Set_Param(image);
            }
        }
        #endregion

        private void B_Edit_MS_Param_Click(object sender, EventArgs e)
        {
            Param.MS_Param.Set_Param();
        }

        #region Printer
        private void B_Printer_Inport_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (Printer_Format != null)
            {
                Update_Param();
                dialog.Filter = "Print Format(*.dat)|*.dat";
                dialog.InitialDirectory = Param.Get_Recipe_Path();
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Printer_Format.LoadFromFile(dialog.FileName);
                    Set_Param();
                }
            }
        }
        private void B_Printer_Tear_off_Click(object sender, EventArgs e)
        {
            int num = SB_Printer_Tear_Off.Value;

            TPub.Printer.Set_Tear_Off(num);
        }
        private void B_Printer_Value_Clear_Click(object sender, EventArgs e)
        {
            Param.Printer.Value_List.Clear();
        }
        private void B_Printer_Value_Move_Up_Click(object sender, EventArgs e)
        {
            int no = 0;

            Update_Param();
            no = Get_Grid_Select_Row(DG_Value);
            Param.Printer.Value_List.Move_Up(no);
            Set_Param_Painter_Value_List();
            Set_Grid_Select_Row(DG_Value, no - 1);
        }
        private void B_Printer_Value_Move_Dn_Click(object sender, EventArgs e)
        {
            int no = 0;

            Update_Param();
            no = Get_Grid_Select_Row(DG_Value);
            Param.Printer.Value_List.Move_Dn(no);
            Set_Param_Painter_Value_List();
            Set_Grid_Select_Row(DG_Value, no + 1);
        }
        private void B_Printer_Value_Add_Click(object sender, EventArgs e)
        {
            Update_Param();
            Param.Printer.Value_List.Add(new TZebra_Value());
            Set_Param_Painter_Value_List();
        }
        private void B_Printer_Value_Delete_Click(object sender, EventArgs e)
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
                Param.Printer.Value_List.Delete(no);
            }
            Set_Param_Painter_Value_List();
            Set_Grid_Select_Row(dg, old_select_no);
        }
        private void SB_Printer_Tear_Off_ValueChanged(object sender, EventArgs e)
        {
            E_Printer_Tear_Off.Text = SB_Printer_Tear_Off.Value.ToString();
        }
        #endregion
    }



    //-----------------------------------------------------------------------------------------------------
    // TRecipe
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe : TBase_Class
    {
        public string                  In_Default_Path;
        public string                  Recipe_Name,
                                       Default_FileName,
                                       FileName,
                                       Info;

        public int                     Recipe_Code;
        public TRecipe_Panel           Panel = new TRecipe_Panel();
        public TRecipe_Printer         Printer = new TRecipe_Printer();
        public TRecipe_Box_Load        Box_Load = new TRecipe_Box_Load();

        public TMS_Param               MS_Param = new TMS_Param();

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

                dis.Recipe_Name = sor.Recipe_Name;
                dis.Default_FileName = sor.Default_FileName;
                dis.FileName = sor.FileName;
                dis.Info = sor.Info;
                dis.Recipe_Code = sor.Recipe_Code;
                dis.Panel.Set(sor.Panel);
                dis.Printer.Set(sor.Printer);
                dis.Box_Load.Set(sor.Box_Load);

                dis.MS_Param.Set(sor.MS_Param);
                dis.Default_Path = sor.Default_Path;
            }
        }


        public void Set_Default()
        {
            Recipe_Name = "Default";
            Default_FileName = "produce.xml";
            Info = "";
            Recipe_Code = 0;

            Panel.Set_Default();
            Printer.Set_Default();
            Box_Load.Set_Default();

            MS_Param_Set_Default();
        }
        public void MS_Param_Set_Default()
        {
            string section = "";

            MS_Param.Clear();

            #region 機械參數
            #region 載台/Y
            section = "載台/Y";
            MS_Param.Add_Value_Double(section, "等待位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "入料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "出料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "對位位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "條碼讀取位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "標籤貼附位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "初對位位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region 載台/Q
            section = "載台/Q";
            MS_Param.Add_Value_Double(section, "入料位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "出料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "對位位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "條碼讀取位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "標籤貼附位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "初對位位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region CCD/L
            section = "CCD/L";
            MS_Param.Add_Value_Double(section, "對位位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "初對位位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region CCD/R
            section = "CCD/R";
            MS_Param.Add_Value_Double(section, "對位位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "初對位位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region 載台/D2_X
            section = "載台/D2_X";
            MS_Param.Add_Value_Double(section, "條碼讀取位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "標籤取料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "標籤貼附位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region LD/BOX_X
            section = "LD/BOX_X";
            MS_Param.Add_Value_Double(section, "靠位位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region LD/BOX_Y
            section = "LD/BOX_Y";
            MS_Param.Add_Value_Double(section, "靠位位置", "", false, false, MS_Param_Value_Get);
            #endregion
            #endregion

            #region 基準位置
            section = "基準位置/Big取像";
            MS_Param.Add_Value_Double(section, "CCD_X_L", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "CCD_X_R", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Y", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Q", MS_Param_Value_Get);

            section = "基準位置/Small取像";
            MS_Param.Add_Value_Double(section, "CCD_X_L", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "CCD_X_R", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Y", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Q", MS_Param_Value_Get);

            section = "基準位置/讀碼位置";
            MS_Param.Add_Value_Double(section, "D2_X", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Y", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Q", MS_Param_Value_Get);

            section = "基準位置/貼標位置";
            MS_Param.Add_Value_Double(section, "D2_X", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Y", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Q", MS_Param_Value_Get);
            #endregion
        }
        public void MS_Param_Value_Get(TMS_Info_Section section, TMS_Info_Value value)
        {
            double tmp_value = 0;
            string name = section.Name + "/" + value.Name;

            switch (name)
            {
                #region 基準位置/Big取像
                case "基準位置/Big取像/CCD_X_L":
                    tmp_value = TPub.PLC.PLC_In.CCD_X_L + Panel.Model_Big.L_X + TPub.PLC.PLC_In.Panel_Ofs_X;
                    value.Value = tmp_value.ToString("0.000");
                    break;

                case "基準位置/Big取像/CCD_X_R":
                    tmp_value = TPub.PLC.PLC_In.CCD_X_R - Panel.Model_Big.R_X - TPub.PLC.PLC_In.Panel_Ofs_X;
                    value.Value = tmp_value.ToString("0.000");
                    break;

                case "基準位置/Big取像/Y":
                    tmp_value = TPub.PLC.PLC_In.Table_Y + Panel.Model_Big.L_Y + TPub.PLC.PLC_In.Panel_Ofs_Y;
                    value.Value = tmp_value.ToString("0.000");
                    break;
                #endregion

                #region 基準位置/Small取像
                case "基準位置/Small取像/CCD_X_L":
                    tmp_value = TPub.PLC.PLC_In.CCD_X_L + Panel.Model_Small.L_X + TPub.PLC.PLC_In.Panel_Ofs_X;
                    value.Value = tmp_value.ToString("0.000");
                    break;

                case "基準位置/Small取像/CCD_X_R":
                    tmp_value = TPub.PLC.PLC_In.CCD_X_R - Panel.Model_Small.R_X - TPub.PLC.PLC_In.Panel_Ofs_X;
                    value.Value = tmp_value.ToString("0.000");
                    break;

                case "基準位置/Small取像/Y":
                    tmp_value = TPub.PLC.PLC_In.Table_Y + Panel.Model_Small.L_Y + TPub.PLC.PLC_In.Panel_Ofs_Y;
                    value.Value = tmp_value.ToString("0.000");
                    break;
                #endregion

                #region 基準位置/讀碼位置
                case "基準位置/讀碼位置/D2_X":
                    tmp_value = TPub.PLC.PLC_In.Table_D2_X - TPub.PLC.PLC_In.Panel_Ofs_X;
                    value.Value = tmp_value.ToString("0.000");
                    break;

                case "基準位置/讀碼位置/Y":
                    tmp_value = TPub.PLC.PLC_In.Table_Y + TPub.PLC.PLC_In.Panel_Ofs_Y;
                    value.Value = tmp_value.ToString("0.000");
                    break;
                #endregion

                #region 基準位置/貼標位置
                case "基準位置/貼標位置/D2_X":
                    tmp_value = TPub.PLC.PLC_In.Table_D2_X - TPub.PLC.PLC_In.Panel_Ofs_X;
                    value.Value = tmp_value.ToString("0.000");
                    break;

                case "基準位置/貼標位置/Y":
                    tmp_value = TPub.PLC.PLC_In.Table_Y + TPub.PLC.PLC_In.Panel_Ofs_Y;
                    value.Value = tmp_value.ToString("0.000");
                    break;
                #endregion
            }
        }
        public void MS_Param_Update(TMS_Param param)
        {
            string section = "";
            double base_value = 0;
            double value = 0;
            string info = "";

            #region 載台/Y
            section = "載台/Y";
            base_value = param.Get_Value_Double("基準位置/Small取像", "Y");
            value = base_value - Panel.Model_Small.L_Y;
            info = string.Format("基準位置_Small取像Y({0:f3}) - Model_Small.L_Y({1:f3})", base_value, Panel.Model_Small.L_Y);
            param.Set_Value_Info(section, "對位位置", value, info);

            base_value = param.Get_Value_Double("基準位置/讀碼位置", "Y");
            value = base_value;
            info = string.Format("基準位置_讀碼位置Y({0:f3})", base_value);
            param.Set_Value_Info(section, "條碼讀取位置", value, info);

            base_value = param.Get_Value_Double("基準位置/貼標位置", "Y");
            value = base_value;
            info = string.Format("基準位置_貼標位置Y({0:f3})", base_value);
            param.Set_Value_Info(section, "標籤貼附位置", value, info);

            base_value = param.Get_Value_Double("基準位置/Big取像", "Y");
            value = base_value - Panel.Model_Big.L_Y;
            info = string.Format("基準位置_Big取像Y({0:f3}) - Recipe.Panel.Model_Big.L_Y({1:f3})", base_value, Panel.Model_Big.L_Y);
            param.Set_Value_Info(section, "初對位位置", value, info);
            #endregion

            #region 載台/Q
            section = "載台/Q";
            base_value = param.Get_Value_Double("基準位置/Small取像", "Q");
            value = base_value;
            info = string.Format("基準位置_Small取像Q({0:f3})", base_value);
            param.Set_Value_Info(section, "對位位置", value, info);

            base_value = param.Get_Value_Double("基準位置/讀碼位置", "Q");
            value = base_value;
            info = string.Format("基準位置_讀碼位置Q({0:f3})", base_value);
            param.Set_Value_Info(section, "條碼讀取位置", value, info);

            base_value = param.Get_Value_Double("基準位置/貼標位置", "Q");
            value = base_value;
            info = string.Format("基準位置_貼標位置Q({0:f3})", base_value);
            param.Set_Value_Info(section, "標籤貼附位置", value, info);

            base_value = param.Get_Value_Double("基準位置/Big取像", "Q");
            value = base_value;
            info = string.Format("基準位置_Big取像Q({0:f3})", base_value);
            param.Set_Value_Info(section, "初對位位置", value, info);
            #endregion

            #region CCD/L
            section = "CCD/L";
            base_value = param.Get_Value_Double("基準位置/Small取像", "CCD_X_L");
            value = base_value - Panel.Model_Small.L_X;
            info = string.Format("基準位置_Small取像CCD_X_L({0:f3}) - Panel.Model_Small.L_X({1:f3})", base_value, Panel.Model_Small.L_X);
            param.Set_Value_Info(section, "對位位置", value, info);

            base_value = param.Get_Value_Double("基準位置/Big取像", "CCD_X_L");
            value = base_value - Panel.Model_Big.L_X;
            info = string.Format("基準位置_Big取像CCD_X_L({0:f3}) - Panel.Model_Big.L_X({1:f3})", base_value, Panel.Model_Big.L_X);
            param.Set_Value_Info(section, "初對位位置", value, info);
            #endregion

            #region CCD/R
            section = "CCD/R";
            base_value = param.Get_Value_Double("基準位置/Small取像", "CCD_X_R");
            value = base_value + Panel.Model_Small.R_X;
            info = string.Format("基準位置_Small取像CCD_X_R({0:f3}) + Panel.Model_Small.R_X({1:f3})", base_value, Panel.Model_Small.R_X);
            param.Set_Value_Info(section, "對位位置", value, info);

            base_value = param.Get_Value_Double("基準位置/Big取像", "CCD_X_R");
            value = base_value + Panel.Model_Big.R_X;
            info = string.Format("基準位置_Big取像CCD_X_R({0:f3}) + Panel.Model_Big.R_X({1:f3})", base_value, Panel.Model_Big.R_X);
            param.Set_Value_Info(section, "初對位位置", value, info);
            #endregion

            #region D2_X
            section = "載台/D2_X";
            base_value = param.Get_Value_Double("基準位置/讀碼位置", "D2_X");
            value = base_value;
            info = string.Format("基準位置_讀碼位置D2_X({0:f3})", base_value);
            param.Set_Value_Info(section, "條碼讀取位置", value, info);

            base_value = param.Get_Value_Double("基準位置/貼標位置", "D2_X");
            value = base_value;
            info = string.Format("基準位置_貼標位置D2_X({0:f3})", base_value);
            param.Set_Value_Info(section, "標籤貼附位置", value, info);
            #endregion
        }

        public void Set_Default_Path(string path)
        {
            string tmp_path = "";
            In_Default_Path = path;

            tmp_path = Get_Recipe_Path();
            Panel.Default_Path = tmp_path + "Panel\\";
            Printer.Default_Path = tmp_path + "Printer\\";
            MS_Param.Default_Path = tmp_path + "MS_Param\\"; 
        }
        public string Get_Recipe_Path()
        {
            string result;
            result = In_Default_Path + Recipe_Name + "\\";
            return result;
        }
        public string Get_Recipe_Name(string file_name)
        {
            string result;

            result = System.IO.Path.GetDirectoryName(file_name);
            result = System.IO.Path.GetFileName(result);
            return result;                     
        }
        public bool SaveAs(string sor_recipe_id)
        {
            bool result = true;

            //Recipe_Name = sor_recipe_id;
            Write();
            return result;
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "")
                FileName = In_Default_Path + Recipe_Name + "\\" + Default_FileName;
            else
                FileName = filename;
            Recipe_Name = Get_Recipe_Name(FileName);
            Set_Default_Path(In_Default_Path);
            ini = new TJJS_XML_File(FileName);
            result = Read(ini, section);
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "")
                FileName = In_Default_Path + Recipe_Name + "\\" + Default_FileName;
            else
                FileName = filename;
            Recipe_Name = Get_Recipe_Name(FileName);
            Set_Default_Path(In_Default_Path);
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();

            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Info = ini.ReadString(section, "Info", Info);
                Recipe_Code = ini.ReadInteger(section, "Recipe_Code", Recipe_Code);

                Panel.Read(ini, section + "/Panel");
                Printer.Read(ini, section + "/Printer");
                Box_Load.Read(ini, section + "/Box_Load");

                MS_Param.Read(ini, section + "/MS_Param");
                Update();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteString(section, "Info", Info);
                ini.WriteInteger(section, "Recipe_Code", Recipe_Code);

                Panel.Write(ini, section + "/Panel");
                Printer.Write(ini, section + "/Printer");
                Box_Load.Write(ini, section + "/Box_Load");

                MS_Param.Write(ini, section + "/MS_Param");
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TRecipe new_value, ref bool flag)
        {
            log.Add("---------------------Recipe 差異---------------------");
            Panel.Log_Diff(log, section + "/Panel", new_value.Panel, ref flag);
            Printer.Log_Diff(log, section + "/Printer", new_value.Printer, ref flag);
            Box_Load.Log_Diff(log, section + "/Box_Load", new_value.Box_Load, ref flag);

            MS_Param.Log_Diff(log, section + "/MS_Param", new_value.MS_Param, ref flag);
            log.Add("---------------------Recipe 差異---------------------");
        }
        public void Update()
        {
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Panel
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Panel : TBase_Class
    {
        public string In_Default_Path = "";
        public double X = 0;
        public double Y = 0;
        public double Z = 0;

        public TRecipe_Panel_Model Model_Big = new TRecipe_Panel_Model();
        public TRecipe_Panel_Model Model_Small = new TRecipe_Panel_Model();
        public TOfs Ofs = new TOfs();
        public TAlign_Limit Align_Limit = new TAlign_Limit();

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
        public TRecipe_Panel()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Panel();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Panel && dis_base is TRecipe_Panel)
            {
                TRecipe_Panel sor = (TRecipe_Panel)sor_base;
                TRecipe_Panel dis = (TRecipe_Panel)dis_base;

                dis.X = sor.X;
                dis.Y = sor.Y;
                dis.Z = sor.Z;
                dis.Model_Big.Set(sor.Model_Big);
                dis.Model_Small.Set(sor.Model_Small);
                dis.Ofs.Set(sor.Ofs);
                dis.Align_Limit.Set(sor.Align_Limit);
            }
        }

        public void Set_Default()
        {
            X = 100.0;
            Y = 100.0;
            Z = 1.0;
            Model_Big.Set_Default();
            Model_Small.Set_Default();
            Ofs.Set_Default();
            Align_Limit.Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Model_Big.Default_Path = In_Default_Path + "Model_Big\\";
            Model_Small.Default_Path = In_Default_Path + "Model_Small\\";
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                X = ini.ReadFloat(section, "X", X);
                Y = ini.ReadFloat(section, "Y", Y);
                Z = ini.ReadFloat(section, "Z", Z);
                Model_Big.Read(ini, section + "/Model_Big");
                Model_Small.Read(ini, section + "/Model_Small");
                Ofs.Read(ini, section + "/Ofs");
                Align_Limit.Read(ini, section + "/Align_Limit");
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "X", X);
                ini.WriteFloat(section, "Y", Y);
                ini.WriteFloat(section, "Z", Z);
                Model_Big.Write(ini, section + "/Model_Big");
                Model_Small.Write(ini, section + "/Model_Small");
                Ofs.Write(ini, section + "/Ofs");
                Align_Limit.Write(ini, section + "/Align_Limit");
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TRecipe_Panel new_value, ref bool flag)
        {
            log.Log_Diff(section + "/X", X, new_value.X, ref flag);
            log.Log_Diff(section + "/Y", Y, new_value.Y, ref flag);
            log.Log_Diff(section + "/Z", Z, new_value.Z, ref flag);

            Model_Big.Log_Diff(log, section + "/Model_Big", new_value.Model_Big, ref flag);
            Model_Small.Log_Diff(log, section + "/Model_Small", new_value.Model_Small, ref flag);
            Ofs.Log_Diff(log, section + "/Ofs", new_value.Ofs, ref flag);
            Align_Limit.Log_Diff(log, section + "/Align_Limit", new_value.Align_Limit, ref flag);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Panel
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Panel_Model : TBase_Class
    {
        public string In_Default_Path = "";

        public double L_X = 0;
        public double L_Y = 0;
        public double R_X = 0;
        public double R_Y = 0;
        public TFind_Mothed_1_Param L = new TFind_Mothed_1_Param();
        public TFind_Mothed_1_Param R = new TFind_Mothed_1_Param();
        public int[] Light_L = new int[4];
        public int[] Light_R = new int[4];
        public TLimit Limit_Length = new TLimit();
        public bool Pre_Process_L_SW = false;
        public bool Pre_Process_R_SW = false;
        public TImage_Pre_Process_Param Pre_Process_L = new TImage_Pre_Process_Param();
        public TImage_Pre_Process_Param Pre_Process_R = new TImage_Pre_Process_Param();

        public TJJS_Point Model_Center
        {
            get
            {
                TJJS_Point result = new TJJS_Point();

                result.X = (L_X + R_X) / 2;
                result.Y = (L_Y + R_Y) / 2;
                return result;
            }
        }
        public double Model_Pitch
        {
            get
            {
                double result = new double();

                result = R_X - L_X;
                return result;
            }
        }
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
        public TRecipe_Panel_Model()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Panel_Model();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Panel_Model && dis_base is TRecipe_Panel_Model)
            {
                TRecipe_Panel_Model sor = (TRecipe_Panel_Model)sor_base;
                TRecipe_Panel_Model dis = (TRecipe_Panel_Model)dis_base;

                dis.L_X = sor.L_X;
                dis.L_Y = sor.L_Y;
                dis.R_X = sor.R_X;
                dis.R_Y = sor.R_Y;
                dis.L.Set(sor.L);
                dis.R.Set(sor.R);
                for (int i = 0; i < dis.Light_L.Length; i++) dis.Light_L[i] = sor.Light_L[i];
                for (int i = 0; i < dis.Light_R.Length; i++) dis.Light_R[i] = sor.Light_R[i];
                dis.Limit_Length.Set(sor.Limit_Length);

                dis.Pre_Process_L_SW = sor.Pre_Process_L_SW;
                dis.Pre_Process_R_SW = sor.Pre_Process_R_SW;
                dis.Pre_Process_L.Set(sor.Pre_Process_L);
                dis.Pre_Process_R.Set(sor.Pre_Process_R);
            }
        }

        public void Set_Default()
        {
            L_X = 0.0;
            L_Y = 0.0;
            R_X = 0.0;
            R_Y = 0.0;
            L.Set_Default();
            R.Set_Default();
            for (int i = 0; i < Light_L.Length; i++) Light_L[i] = 0;
            for (int i = 0; i < Light_R.Length; i++) Light_R[i] = 0;
            Limit_Length.Set_Default();

            Pre_Process_L_SW = false;
            Pre_Process_R_SW = false;
            Pre_Process_L.Set_Default();
            Pre_Process_R.Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            L.Default_Path = path + "L\\";
            R.Default_Path = path + "R\\";
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                L_X = ini.ReadFloat(section, "L_X", L_X);
                L_Y = ini.ReadFloat(section, "L_Y", L_Y);
                R_X = ini.ReadFloat(section, "R_X", R_X);
                R_Y = ini.ReadFloat(section, "R_Y", R_Y);
                L.Read(ini, section + "/L");
                R.Read(ini, section + "/R");
                for (int i = 0; i < Light_L.Length; i++) Light_L[i] = ini.ReadInteger(section, "Light_L" + (i + 1).ToString(), Light_L[i]);
                for (int i = 0; i < Light_R.Length; i++) Light_R[i] = ini.ReadInteger(section, "Light_R" + (i + 1).ToString(), Light_R[i]);
                Limit_Length.Read(ini, section + "/Limit_Length");

                Pre_Process_L_SW = ini.ReadBool(section, "Pre_Process_L_SW", Pre_Process_L_SW);
                Pre_Process_R_SW = ini.ReadBool(section, "Pre_Process_R_SW", Pre_Process_R_SW);
                Pre_Process_L.Read(ini, section + "/Pre_Process_L");
                Pre_Process_R.Read(ini, section + "/Pre_Process_R");
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "L_X", L_X);
                ini.WriteFloat(section, "L_Y", L_Y);
                ini.WriteFloat(section, "R_X", R_X);
                ini.WriteFloat(section, "R_Y", R_Y);
                L.Write(ini, section + "/L");
                R.Write(ini, section + "/R");
                for (int i = 0; i < Light_L.Length; i++) ini.WriteInteger(section, "Light_L" + (i + 1).ToString(), Light_L[i]);
                for (int i = 0; i < Light_R.Length; i++) ini.WriteInteger(section, "Light_R" + (i + 1).ToString(), Light_R[i]);
                Limit_Length.Write(ini, section + "/Limit_Length");

                ini.WriteBool(section, "Pre_Process_L_SW", Pre_Process_L_SW);
                ini.WriteBool(section, "Pre_Process_R_SW", Pre_Process_R_SW);
                Pre_Process_L.Write(ini, section + "/Pre_Process_L");
                Pre_Process_R.Write(ini, section + "/Pre_Process_R");
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TRecipe_Panel_Model new_value, ref bool flag)
        {
            log.Log_Diff(section + "/L_X", L_X, new_value.L_X, ref flag);
            log.Log_Diff(section + "/L_Y", L_Y, new_value.L_Y, ref flag);
            log.Log_Diff(section + "/R_X", R_X, new_value.R_X, ref flag);
            log.Log_Diff(section + "/R_Y", R_Y, new_value.R_Y, ref flag);

            L.Log_Diff(log, section + "/L", new_value.L, ref flag);
            R.Log_Diff(log, section + "/R", new_value.R, ref flag);

            for (int i = 0; i < Light_L.Length; i++)
                log.Log_Diff(section + "/Light_L" + (i + 1).ToString(), Light_L[i], new_value.Light_L[i], ref flag);

            for (int i = 0; i < Light_R.Length; i++)
                log.Log_Diff(section + "/Light_R" + (i + 1).ToString(), Light_R[i], new_value.Light_R[i], ref flag);

            Limit_Length.Log_Diff(log, section + "/Limit_Length", new_value.Limit_Length, ref flag);

            log.Log_Diff(section + "/Pre_Process_L_SW", Pre_Process_L_SW, new_value.Pre_Process_L_SW, ref flag);
            log.Log_Diff(section + "/Pre_Process_R_SW", Pre_Process_R_SW, new_value.Pre_Process_R_SW, ref flag);
            Pre_Process_L.Log_Diff(log, section + "/Pre_Process_L", new_value.Pre_Process_L, ref flag);
            Pre_Process_R.Log_Diff(log, section + "/Pre_Process_R", new_value.Pre_Process_R, ref flag);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TOfs
    //-----------------------------------------------------------------------------------------------------
    public class TOfs : TBase_Class
    {
        public string In_Default_Path;
        public double X,
                      Y,
                      Q;

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
        public TOfs()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TOfs();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TOfs && dis_base is TOfs)
            {
                TOfs sor = (TOfs)sor_base;
                TOfs dis = (TOfs)dis_base;
                dis.X = sor.X;
                dis.Y = sor.Y;
                dis.Q = sor.Q;
            }
        }


        public void Set_Default()
        {
            X = 0;
            Y = 0;
            Q = 0;
        }
        public void Set_Default_Path(string path)
        {
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                X = ini.ReadFloat(section, "X", 0.0);
                Y = ini.ReadFloat(section, "Y", 0.0);
                Q = ini.ReadFloat(section, "Q", 0.0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "X", X);
                ini.WriteFloat(section, "Y", Y);
                ini.WriteFloat(section, "Q", Q);
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
        public void Log_Diff(TLog log, string section, TOfs new_value, ref bool flag)
        {
            log.Log_Diff(section + "/X", X, new_value.X, ref flag);
            log.Log_Diff(section + "/Y", Y, new_value.Y, ref flag);
            log.Log_Diff(section + "/Q", Q, new_value.Q, ref flag);
        }
    }

     //-----------------------------------------------------------------------------------------------------
    // TLimit
    //-----------------------------------------------------------------------------------------------------
    public class TLimit : TBase_Class
    {
        public string In_Default_Path;
        public bool SW;
        public double Min,
                      Max;

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
        public TLimit()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TLimit();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TLimit && dis_base is TLimit)
            {
                TLimit sor = (TLimit)sor_base;
                TLimit dis = (TLimit)dis_base;

                dis.SW = sor.SW;
                dis.Min = sor.Min;
                dis.Max = sor.Max;
            }
        }


        
        public void Set_Default()
        {
            SW = false;
            Min = 0;
            Max = 0;
        }
        public void Set_Default_Path(string path)
        {
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                SW = ini.ReadBool(section, "Enabled", false);
                Min = ini.ReadFloat(section, "Min", 0.0);
                Max = ini.ReadFloat(section, "Max", 0.0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteBool(section, "Enabled", SW);
                ini.WriteFloat(section, "Min", Min);
                ini.WriteFloat(section, "Max", Max);
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
        public void Log_Diff(TLog log, string section, TLimit new_value, ref bool flag)
        {
            log.Log_Diff(section + "/SW", SW, new_value.SW, ref flag);
            log.Log_Diff(section + "/Min", Min, new_value.Min, ref flag);
            log.Log_Diff(section + "/Max", Max, new_value.Max, ref flag);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TAlign_Limit
    //-----------------------------------------------------------------------------------------------------
    public class TAlign_Limit : TBase_Class
    {
        public string In_Default_Path;
        public bool SW_DX;
        public bool SW_DY;
        public bool SW_DQ;
        public double DX_Min,
                      DX_Max;
        public double DY_Min,
                      DY_Max;
        public double DQ_Min,
                      DQ_Max;

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
        public TAlign_Limit()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TAlign_Limit();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAlign_Limit && dis_base is TAlign_Limit)
            {
                TAlign_Limit sor = (TAlign_Limit)sor_base;
                TAlign_Limit dis = (TAlign_Limit)dis_base;

                dis.SW_DX = sor.SW_DX;
                dis.SW_DY = sor.SW_DY;
                dis.SW_DQ = sor.SW_DQ;
                dis.DX_Min = sor.DX_Min;
                dis.DX_Max = sor.DX_Max;
                dis.DY_Min = sor.DY_Min;
                dis.DY_Max = sor.DY_Max;
                dis.DQ_Min = sor.DQ_Min;
                dis.DQ_Max = sor.DQ_Max;
            }
        }



        public void Set_Default()
        {
            SW_DX = false;
            SW_DY = false;
            SW_DQ = false;
            DX_Min = 0.0;
            DX_Max = 0.0;
            DY_Min = 0.0;
            DY_Max = 0.0;
            DQ_Min = 0.0;
            DQ_Max = 0.0;
        }
        public void Set_Default_Path(string path)
        {
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                SW_DX = ini.ReadBool(section, "SW_DX", SW_DX);
                SW_DY = ini.ReadBool(section, "SW_DY", SW_DY);
                SW_DQ = ini.ReadBool(section, "SW_DQ", SW_DQ);
                DX_Min = ini.ReadFloat(section, "DX_Min", DX_Min);
                DX_Max = ini.ReadFloat(section, "DX_Max", DX_Max);
                DY_Min = ini.ReadFloat(section, "DY_Min", DY_Min);
                DY_Max = ini.ReadFloat(section, "DY_Max", DY_Max);
                DQ_Min = ini.ReadFloat(section, "DQ_Min", DQ_Min);
                DQ_Max = ini.ReadFloat(section, "DQ_Max", DQ_Max);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteBool(section, "SW_DX", SW_DX);
                ini.WriteBool(section, "SW_DY", SW_DY);
                ini.WriteBool(section, "SW_DQ", SW_DQ);
                ini.WriteFloat(section, "DX_Min", DX_Min);
                ini.WriteFloat(section, "DX_Max", DX_Max);
                ini.WriteFloat(section, "DY_Min", DY_Min);
                ini.WriteFloat(section, "DY_Max", DY_Max);
                ini.WriteFloat(section, "DQ_Min", DQ_Min);
                ini.WriteFloat(section, "DQ_Max", DQ_Max);
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
        public void Log_Diff(TLog log, string section, TAlign_Limit new_value, ref bool flag)
        {
            log.Log_Diff(section + "/SW_DX", SW_DX, new_value.SW_DX, ref flag);
            log.Log_Diff(section + "/SW_DY", SW_DY, new_value.SW_DY, ref flag);
            log.Log_Diff(section + "/SW_DQ", SW_DQ, new_value.SW_DQ, ref flag);
            log.Log_Diff(section + "/DX_Min", DX_Min, new_value.DX_Min, ref flag);
            log.Log_Diff(section + "/DX_Max", DX_Max, new_value.DX_Max, ref flag);
            log.Log_Diff(section + "/DY_Min", DY_Min, new_value.DY_Min, ref flag);
            log.Log_Diff(section + "/DY_Max", DY_Max, new_value.DY_Max, ref flag);
            log.Log_Diff(section + "/DQ_Min", DQ_Min, new_value.DQ_Min, ref flag);
            log.Log_Diff(section + "/DQ_Max", DQ_Max, new_value.DQ_Max, ref flag);
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

    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Box_Load
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Box_Load : TBase_Class
    {
        public string In_Default_Path = "";
        public double Box_X = 0;
        public double Box_Y = 0;
        public double Box_Z = 0;
        public int X_Num = 0;
        public int Y_Num = 0;
        public bool Supply_Vacc;

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
        public TRecipe_Box_Load()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Box_Load();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Box_Load && dis_base is TRecipe_Box_Load)
            {
                TRecipe_Box_Load sor = (TRecipe_Box_Load)sor_base;
                TRecipe_Box_Load dis = (TRecipe_Box_Load)dis_base;

                dis.Box_X = sor.Box_X;
                dis.Box_Y = sor.Box_Y;
                dis.Box_Z = sor.Box_Z;
                dis.X_Num = sor.X_Num;
                dis.Y_Num = sor.Y_Num;
                dis.Supply_Vacc = sor.Supply_Vacc;
            }
        }

        public void Set_Default()
        {
            Box_X = 100;
            Box_Y = 100;
            Box_Z = 100;
            X_Num = 1;
            Y_Num = 1;
            Supply_Vacc = false;
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Box_X = ini.ReadFloat(section, "Box_X", Box_X);
                Box_Y = ini.ReadFloat(section, "Box_Y", Box_Y);
                Box_Z = ini.ReadFloat(section, "Box_Z", Box_Z);
                X_Num = ini.ReadInteger(section, "X_Num", X_Num);
                Y_Num = ini.ReadInteger(section, "Y_Num", Y_Num);
                Supply_Vacc = ini.ReadBool(section, "Supply_Vacc", Supply_Vacc);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "Box_X", Box_X);
                ini.WriteFloat(section, "Box_Y", Box_Y);
                ini.WriteFloat(section, "Box_Z", Box_Z);
                ini.WriteInteger(section, "X_Num", X_Num);
                ini.WriteInteger(section, "Y_Num", Y_Num);
                ini.WriteBool(section, "Supply_Vacc", Supply_Vacc);
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TRecipe_Box_Load new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Box_X", Box_X, new_value.Box_X, ref flag);
            log.Log_Diff(section + "/Box_Y", Box_Y, new_value.Box_Y, ref flag);
            log.Log_Diff(section + "/Box_Z", Box_Z, new_value.Box_Z, ref flag);
            log.Log_Diff(section + "/X_Num", X_Num, new_value.X_Num, ref flag);
            log.Log_Diff(section + "/Y_Num", Y_Num, new_value.Y_Num, ref flag);
            log.Log_Diff(section + "/Supply_Vacc", Supply_Vacc, new_value.Supply_Vacc, ref flag);
        }
    }
}
