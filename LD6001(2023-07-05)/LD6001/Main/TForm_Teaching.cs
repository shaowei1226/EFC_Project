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
using EFC.Vision.Halcon;
using EFC.Tool;
using EFC.INI;
using EFC.Camera;
using EFC.CAD;


namespace Main
{
    public enum emTeach_Model { None, Panel_Big, Panel_Small };

    public partial class TForm_Teaching : Form
    {
        public TFind_Mothed_1_Result F_Result = new TFind_Mothed_1_Result();
        public TTeach Param = new TTeach();
        emTeach_Model Teach_Model = emTeach_Model.Panel_Big;


        public TForm_Teaching()
        {
            InitializeComponent();

            PageControl_Tool.Tab_Page_Select(TC_Main_01, "空白");
            PageControl_Tool.Tab_Page_Hide(TC_Main_01);
        }
        private void TForm_Teaching_Shown(object sender, EventArgs e)
        {
            TV_Menu.ExpandAll();
            TV_Menu.SelectedNode = TV_Menu.Nodes[0];

            tFrame_Display1.Dock = DockStyle.Fill;
            tFrame_Display1.On_Display = Disp_View;//畫線與文字
            tFrame_Display1.Disp_Enabled = true;
            Update_CCD();
        }
        private void TForm_Teaching_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        public void Disp_View(ref TFrame_JJS_HW jjs_hw, int index, bool foce_disp)
        {

            TCamera_Base camera = null;
            HImage image = new HImage();
            double scale = 1;
            int line_width = 1;
            int w, h;
            TFind_Mothed_1_Result f_result = null;

            try
            {
                camera = TPub.Cameras[index];
                f_result = F_Result;

                //display image
                camera.Get_HImage(ref image);
                image.GetImageSize(out w, out h);
                scale = (double)w / jjs_hw.Width;

                jjs_hw.SetPart(image);
                jjs_hw.HW_Buf.HalconWindow.DispObj(image);
                f_result.Disp_Param.Msg_Font_Size = 20;
                f_result.Disp_Param.Msg_X = 20;
                f_result.Disp_Param.Msg_Y = 60;
                f_result.Disp_Param.Scale = scale;

                //display CCD name
                JJS_Vision.Display_String(jjs_hw.HW_Buf, camera.Name, 10, 10, 25, scale, "blue");

                //display 畫面十字線
                line_width = (int)Math.Round(2 * scale + 1, 0);
                jjs_hw.HW_Buf.HalconWindow.SetLineWidth(line_width);
                JJS_Vision.Display_Hairline(jjs_hw.HW_Buf, image, "red");

                //display find data
                f_result.Display_Message(jjs_hw.HW_Buf);
                f_result.Display_Model(jjs_hw.HW_Buf);
            }
            catch { }
            jjs_hw.Copy_HW();
            image.Dispose();
        }

        public void Set_Param(TTeach param)
        {
            Param.Set(param);

            TJJS_Point center = null;

            center = Param.Cal_Data.Panel_Big.Center;
            E_Center_X.Text = TPub.Teach.Cal_Data.Panel_Big.Center.X.ToString("f3");
            E_Center_Y.Text = TPub.Teach.Cal_Data.Panel_Big.Center.Y.ToString("f3");

            E_Q1_Col.Text = Param.Teach_Data.Panel_Big.Q1.Col.ToString("0.000");
            E_Q1_Row.Text = Param.Teach_Data.Panel_Big.Q1.Row.ToString("0.000");
            E_Q1_Pos.Text = Param.Teach_Data.Panel_Big.Q1.Pos.ToString("0.000");

            E_Q2_Col.Text = Param.Teach_Data.Panel_Big.Q2.Col.ToString("0.000");
            E_Q2_Row.Text = Param.Teach_Data.Panel_Big.Q2.Row.ToString("0.000");
            E_Q2_Pos.Text = Param.Teach_Data.Panel_Big.Q2.Pos.ToString("0.000");

            E_Q_TX.Text = Param.Teach_Data.Panel_Big.Q_TX.ToString("0.000");
            E_Q_TY.Text = Param.Teach_Data.Panel_Big.Q_TY.ToString("0.000");
            E_Q_CCD.Text = Param.Teach_Data.Panel_Big.Q_CCD.ToString("0.000");

            E_CCD_Ofs_X.Text = Param.Teach_Data.Panel_Big.CCD_Ofs_X.ToString("0.000");
            E_CCD_Ofs_Y.Text = Param.Teach_Data.Panel_Big.CCD_Ofs_Y.ToString("0.000");

        }
        public void Update_Param()
        {
            Param.Teach_Data.Panel_Big.Q1.Col = Convert.ToDouble(E_Q1_Col.Text);
            Param.Teach_Data.Panel_Big.Q1.Row = Convert.ToDouble(E_Q1_Row.Text);
            Param.Teach_Data.Panel_Big.Q1.Pos = Convert.ToDouble(E_Q1_Pos.Text);

            Param.Teach_Data.Panel_Big.Q2.Col = Convert.ToDouble(E_Q2_Col.Text);
            Param.Teach_Data.Panel_Big.Q2.Row = Convert.ToDouble(E_Q2_Row.Text);
            Param.Teach_Data.Panel_Big.Q2.Pos = Convert.ToDouble(E_Q2_Pos.Text);

            Param.Teach_Data.Panel_Big.Q_TX = Convert.ToDouble(E_Q_TX.Text);
            Param.Teach_Data.Panel_Big.Q_TY = Convert.ToDouble(E_Q_TY.Text);
            Param.Teach_Data.Panel_Big.Q_CCD = Convert.ToDouble(E_Q_CCD.Text);

            Param.Teach_Data.Panel_Big.CCD_Ofs_X = Convert.ToDouble(E_CCD_Ofs_X.Text);
            Param.Teach_Data.Panel_Big.CCD_Ofs_Y = Convert.ToDouble(E_CCD_Ofs_Y.Text);
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

        }
        private void B_Open_Click(object sender, EventArgs e)
        {

        }
        private void TV_Menu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node;
            string node_full_name;

            Update_Param();
            node = TV_Menu.SelectedNode;
            node_full_name = TreeView_Tool.Get_Node_Full_Name(node);

            PageControl_Tool.Tab_Page_Select(TC_Main_01, "空白");
            L_Tree_Info.Text = "Root" + TreeView_Tool.Get_Node_Full_Text(node);
            switch (node_full_name)
            {
                #region Panel_Big
                case "\\Panel_Big\\Edit_Model":
                    PageControl_Tool.Tab_Page_Select(TC_Main_01, "編輯標靶");
                    Teach_Model = emTeach_Model.Panel_Big;
                    Update_CCD();
                    break;

                case "\\Panel_Big\\Teach":
                    PageControl_Tool.Tab_Page_Select(TC_Main_01, "校驗");
                    Teach_Model = emTeach_Model.Panel_Big;
                    Update_CCD();
                    break;

                case "\\Panel_Big\\Result":
                    PageControl_Tool.Tab_Page_Select(TC_Main_01, "校驗資訊");
                    Teach_Model = emTeach_Model.Panel_Big;
                    Update_CCD();
                    break;
                #endregion

                #region Panel_Small
                case "\\Panel_Small\\Edit_Model":
                    PageControl_Tool.Tab_Page_Select(TC_Main_01, "編輯標靶");
                    Teach_Model = emTeach_Model.Panel_Small;
                    Update_CCD();
                    break;

                case "\\Panel_Small\\Teach":
                    PageControl_Tool.Tab_Page_Select(TC_Main_01, "校驗");
                    Teach_Model = emTeach_Model.Panel_Small;
                    Update_CCD();
                    break;

                case "\\Panel_Small\\Result":
                    PageControl_Tool.Tab_Page_Select(TC_Main_01, "校驗資訊");
                    Teach_Model = emTeach_Model.Panel_Small;
                    Update_CCD();
                    break;
                #endregion
            }
        }
        private void Update_CCD()
        {
            int no = TPub.Get_Camera_No(Get_emCCD_Name());
            TCamera_Base camera = Get_Camera();
            tFrame_Display1.Set_HW_Size(1, 1, new int[] { no }, camera.Image_Width, camera.Image_Height);
        }
        private void B_Model_L_Edit_Click(object sender, EventArgs e)
        {
            TFind_Mothed_1_Param param = null;
            TCamera_Base camera = null;
            HImage image = new HImage();

            param = Get_Model_Param();
            camera = Get_Camera();
            camera.Get_HImage(ref image);
            param.Set_Param(image);
        }

        private void B_Q1_Click(object sender, EventArgs e)
        {
            double x = 0, y = 0, q = 0, ccd = 0;

            F_Result = Find(Teach_Model);
            Get_Pos(Teach_Model, ref x, ref y, ref q, ref ccd);
            if (F_Result.Find_OK)
            {
                E_Q1_Col.Text = F_Result.Col.ToString("0.00");
                E_Q1_Row.Text = F_Result.Row.ToString("0.00");
                E_Q1_Pos.Text = q.ToString("0.000");

                E_Q_TX.Text = x.ToString("0.00");
                E_Q_TY.Text = y.ToString("0.00");
                E_Q_CCD.Text = ccd.ToString("0.00");
            }
        }
        private void B_Q2_Click(object sender, EventArgs e)
        {
            double x = 0, y = 0, q = 0, ccd = 0;

            F_Result = Find(Teach_Model);
            Get_Pos(Teach_Model, ref x, ref y, ref q, ref ccd);
            if (F_Result.Find_OK)
            {
                E_Q2_Col.Text = F_Result.Col.ToString("0.00");
                E_Q2_Row.Text = F_Result.Row.ToString("0.00");
                E_Q2_Pos.Text = q.ToString("0.000");

                E_Q_TX.Text = x.ToString("0.00");
                E_Q_TY.Text = y.ToString("0.00");
                E_Q_CCD.Text = ccd.ToString("0.00");
            }
        }
        private void TForm_Teaching_Load(object sender, EventArgs e)
        {

        }

        public TFind_Mothed_1_Param Get_Model_Param()
        {
            TFind_Mothed_1_Param result = null;
            switch (Teach_Model)
            {
                case emTeach_Model.Panel_Big:
                    result = Param.Teach_Data.Panel_Big.Model;
                    break;

                case emTeach_Model.Panel_Small:
                    result = Param.Teach_Data.Panel_Small.Model;
                    break;
            }
            return result;
        }
        public emCCD_Name Get_emCCD_Name()
        {
            emCCD_Name result = emCCD_Name.None;

            switch (Teach_Model)
            {
                case emTeach_Model.Panel_Big: result = emCCD_Name.Big_L; break;
                case emTeach_Model.Panel_Small: result = emCCD_Name.Small_L; break;
            }
            return result;
        }
        public TCamera_Base Get_Camera()
        {
            TCamera_Base result = null;

            result = TPub.Get_Camera(Get_emCCD_Name()); 
            return result;
        }
        public emModel Get_Model()
        {
            emModel result = emModel.None;

            switch (Teach_Model)
            {
                case emTeach_Model.Panel_Big: result = emModel.Big_L; break;
                case emTeach_Model.Panel_Small: result = emModel.Small_L; break;
            }
            return result;
        }
        public TFind_Mothed_1_Result Find(emTeach_Model tm_model)
        {
            TFind_Mothed_1_Result result = new TFind_Mothed_1_Result();
            TCamera_Base camera = null;
            HImage tmp_Image = new HImage();
            TFind_Mothed_1_Param param = null;

            camera = Get_Camera();
            camera.Get_HImage(ref tmp_Image);
            param = Get_Model_Param();
            param.Find_Base(tmp_Image, ref result);
            if (!result.Find_OK)
            {
                MessageBox.Show("自動搜索標把失敗", "警告", MessageBoxButtons.OK);
            }
            return result;
        }
        public void Get_Pos(emTeach_Model th_mode, ref double x, ref double y, ref double q, ref double ccd)
        {
            TJJS_Value_List pos = new TJJS_Value_List();

            TPub.Get_PLC_Pos(Get_Model(), ref pos);
            x = pos.Get_Value_Double("X");
            y = pos.Get_Value_Double("Y");
            q = pos.Get_Value_Double("Q");
            ccd = pos.Get_Value_Double("CCD");
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TTeach
    //-----------------------------------------------------------------------------------------------------
    public class TTeach : TBase_Class
    {
        private string In_Default_Path;
        public string Default_FileName;
        public string Teach_Name;
        public string FileName;
        public string Info;

        public TTeach_Data Teach_Data = new TTeach_Data();
        public TTeach_Cal_Data Cal_Data = new TTeach_Cal_Data();

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
        public TTeach()
        {
        }
        override public TBase_Class New_Class()
        {
            return new TTeach();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach && dis_base is TTeach)
            {
                TTeach sor = (TTeach)sor_base;
                TTeach dis = (TTeach)dis_base;

                dis.Default_Path = sor.Default_Path;
                dis.Default_FileName = sor.Default_FileName;
                dis.FileName = sor.FileName;
                dis.Info = sor.Info;

                dis.Teach_Data.Set(sor.Teach_Data);
                dis.Cal_Data.Set(sor.Cal_Data);
            }
        }

        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Teach_Data.Default_Path = path;
        }
        public void Set_Default()
        {
            In_Default_Path = "";
            Default_FileName = "Teach.xml";
            FileName = "";
            Info = "";
            Teach_Data.Set_Default();
            Cal_Data.Set_Default();
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            result = Read(ini, section);
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();

            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Teach_Data.Read(ini, section + "/Teach_Data");
                Read_Other_File();
            }
            Cal();
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Teach_Data.Write(ini, section + "/Teach_Data");
                Write_Other_File();
            }
            Cal();
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
        public void Cal()
        {
            Cal_Center_Panel_Big(Teach_Data.Panel_Big, ref Cal_Data.Panel_Big);
            Cal_Center_Panel_Small(Teach_Data.Panel_Small, ref Cal_Data.Panel_Small);
        }


        private void Cal_Center_Panel_Big(TTeach_Data_One_CCD teach_data, ref TTeach_Cal_Data_One_CCD cal_data)
        {
            TJJS_Line l1 = new TJJS_Line();
            TJJS_Line l2 = new TJJS_Line();
            TJJS_Line l3 = new TJJS_Line();
            double dq = 0;
            TJJS_Point movedist = new TJJS_Point();
            int ccd_no = 0;
            TJJS_Value_List pos = new TJJS_Value_List();

            try
            {
                if (teach_data.Q1.Col != 0 && teach_data.Q1.Row != 0 && teach_data.Q1.Pos != 0 &&
                    teach_data.Q2.Col != 0 && teach_data.Q2.Row != 0 && teach_data.Q2.Pos != 0)
                {
                    pos.Add("X", teach_data.Q_TX);
                    pos.Add("Y", teach_data.Q_TY);
                    pos.Add("CCD", teach_data.Q_CCD);
                    l1.Start = TPub.Get_Abs_Pos_Panel_Big_L(teach_data.Q1.Col, teach_data.Q1.Row, pos);
                    l1.End = TPub.Get_Abs_Pos_Panel_Big_L(teach_data.Q2.Col, teach_data.Q2.Row, pos);
                    dq = -(teach_data.Q2.Pos - teach_data.Q1.Pos) / 2;
                    l2 = l1.Rotate(l1.Start, 90 - dq);
                    l3 = l1.Rotate(l1.End, 90 + dq);
                    cal_data.Center = l2.Intersect(l3);
                    cal_data.Data_OK = true;
                }
                else
                    cal_data.Data_OK = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Cal_Center_Panel_Small(TTeach_Data_One_CCD teach_data, ref TTeach_Cal_Data_One_CCD cal_data)
        {
            TJJS_Line l1 = new TJJS_Line();
            TJJS_Line l2 = new TJJS_Line();
            TJJS_Line l3 = new TJJS_Line();
            double dq = 0;
            TJJS_Point movedist = new TJJS_Point();
            int ccd_no = 0;
            TJJS_Value_List pos = new TJJS_Value_List();

            try
            {
                if (teach_data.Q1.Col != 0 && teach_data.Q1.Row != 0 && teach_data.Q1.Pos != 0 &&
                    teach_data.Q2.Col != 0 && teach_data.Q2.Row != 0 && teach_data.Q2.Pos != 0)
                {
                    pos.Add("X", teach_data.Q_TX);
                    pos.Add("Y", teach_data.Q_TY);
                    pos.Add("CCD", teach_data.Q_CCD);
                    l1.Start = TPub.Get_Abs_Pos_Panel_Small_L(teach_data.Q1.Col, teach_data.Q1.Row, pos);
                    l1.End = TPub.Get_Abs_Pos_Panel_Small_L(teach_data.Q2.Col, teach_data.Q2.Row, pos);
                    dq = -(teach_data.Q2.Pos - teach_data.Q1.Pos) / 2;
                    l2 = l1.Rotate(l1.Start, 90 - dq);
                    l3 = l1.Rotate(l1.End, 90 + dq);
                    cal_data.Center = l2.Intersect(l3);
                    cal_data.Data_OK = true;
                }
                else
                    cal_data.Data_OK = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TTeach_Data
    //-----------------------------------------------------------------------------------------------------
    public class TTeach_Data : TBase_Class
    {
        private string In_Default_Path;
        public TTeach_Data_One_CCD Panel_Big = new TTeach_Data_One_CCD();
        public TTeach_Data_One_CCD Panel_Small = new TTeach_Data_One_CCD();

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
        public TTeach_Data()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Data();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Data && dis_base is TTeach_Data)
            {
                TTeach_Data sor = (TTeach_Data)sor_base;
                TTeach_Data dis = (TTeach_Data)dis_base;

                dis.Panel_Big.Set(sor.Panel_Big);
                dis.Panel_Small.Set(sor.Panel_Small);
            }
        }

        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Panel_Big.Default_Path = In_Default_Path + "Panel_Big\\";
            Panel_Small.Default_Path = In_Default_Path + "Panel_Small\\";
        }
        public void Set_Default()
        {
            Panel_Big.Set_Default();
            Panel_Small.Set_Default();
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Panel_Big.Read(ini, section + "/Panel_Big");
                Panel_Small.Read(ini, section + "/Panel_Small");
                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Panel_Big.Write(ini, section + "/Panel_Big");
                Panel_Small.Write(ini, section + "/Panel_Small");
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


    public class TTeach_Data_One_CCD : TBase_Class
    {
        public TTeach_Point Q1 = new TTeach_Point();
        public TTeach_Point Q2 = new TTeach_Point();
        public double Q_TX;
        public double Q_TY;
        public double Q_CCD;

        public double CCD_Ofs_X;
        public double CCD_Ofs_Y;

        public TFind_Mothed_1_Param Model = new TFind_Mothed_1_Param();

        public string Default_Path
        {
            get
            {
                return Model.Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TTeach_Data_One_CCD()
        {
            Set_Default();
            Model.JJS_Model.Default_FileName = "Model1.mod";
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Data_One_CCD();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Data_One_CCD && dis_base is TTeach_Data_One_CCD)
            {
                TTeach_Data_One_CCD sor = (TTeach_Data_One_CCD)sor_base;
                TTeach_Data_One_CCD dis = (TTeach_Data_One_CCD)dis_base;

                dis.Q1.Set(sor.Q1);
                dis.Q2.Set(sor.Q2);
                dis.Q_TX = sor.Q_TX;
                dis.Q_TY = sor.Q_TY;
                dis.Q_CCD = sor.Q_CCD;

                dis.CCD_Ofs_X = sor.CCD_Ofs_X;
                dis.CCD_Ofs_Y = sor.CCD_Ofs_Y;

                dis.Model.Set(sor.Model);
            }
        }

        public void Set_Default_Path(string path)
        {
            Model.Default_Path = path + "Model_L\\";
            Model.JJS_Model.Default_Path = Model.Default_Path;
            Model.JJS_Model.Default_FileName = "Model.mod";
        }
        public void Set_Default()
        {
            Q1.Set_Default();
            Q2.Set_Default();
            Q_TX = 0;
            Q_TY = 0;
            Q_CCD = 0;

            CCD_Ofs_X = 0.0;
            CCD_Ofs_Y = 0.0;

            Model.Set_Default();
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Q1.Read(ini, section + "/Q1");
                Q2.Read(ini, section + "/Q2");
                Q_TX = ini.ReadFloat(section, "Q_TX", Q_TX);
                Q_TY = ini.ReadFloat(section, "Q_TY", Q_TY);
                Q_CCD = ini.ReadFloat(section, "Q_CCD", Q_CCD);

                CCD_Ofs_X = ini.ReadFloat(section, "CCD_Ofs_X", CCD_Ofs_X);
                CCD_Ofs_Y = ini.ReadFloat(section, "CCD_Ofs_Y", CCD_Ofs_Y);

                Model.Read(ini, section + "/Model");

                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Q1.Write(ini, section + "/Q1");
                Q2.Write(ini, section + "/Q2");
                ini.WriteFloat(section, "Q_TX", Q_TX);
                ini.WriteFloat(section, "Q_TY", Q_TY);
                ini.WriteFloat(section, "Q_CCD", Q_CCD);

                ini.WriteFloat(section, "CCD_Ofs_X", CCD_Ofs_X);
                ini.WriteFloat(section, "CCD_Ofs_Y", CCD_Ofs_Y);

                Model.Write(ini, section + "/Model");

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

    public class TTeach_Point : TBase_Class
    {
        public double Col, Row, Pos;

        public TTeach_Point()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Point();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Point && dis_base is TTeach_Point)
            {
                TTeach_Point sor = (TTeach_Point)sor_base;
                TTeach_Point dis = (TTeach_Point)dis_base;

                dis.Col = sor.Col;
                dis.Row = sor.Row;
                dis.Pos = sor.Pos;
            }
        }

        public void Set_Default()
        {
            Col = 0;
            Row = 0;
            Pos = 0;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Col = ini.ReadFloat(section, "Col", 0.0);
                Row = ini.ReadFloat(section, "Row", 0.0);
                Pos = ini.ReadFloat(section, "Pos", 0.0);

                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "Col", Col);
                ini.WriteFloat(section, "Row", Row);
                ini.WriteFloat(section, "Pos", Pos);

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

    //-----------------------------------------------------------------------------------------------------
    // TTeach_Cal_Data
    //-----------------------------------------------------------------------------------------------------
    public class TTeach_Cal_Data : TBase_Class
    {
        public TTeach_Cal_Data_One_CCD Panel_Big = new TTeach_Cal_Data_One_CCD();
        public TTeach_Cal_Data_One_CCD Panel_Small = new TTeach_Cal_Data_One_CCD();

        public TTeach_Cal_Data()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Cal_Data();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Cal_Data_One_CCD && dis_base is TTeach_Cal_Data_One_CCD)
            {
                TTeach_Cal_Data sor = (TTeach_Cal_Data)sor_base;
                TTeach_Cal_Data dis = (TTeach_Cal_Data)dis_base;

                dis.Panel_Big.Set(sor.Panel_Big);
                dis.Panel_Small.Set(sor.Panel_Small);
            }
        }

        public void Set_Default()
        {
            Panel_Big.Set_Default();
            Panel_Small.Set_Default();
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Panel_Big.Read(ini, section + "/Panel_Big");
                Panel_Small.Read(ini, section + "/Panel_Small");
                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Panel_Big.Write(ini, section + "/Panel_Big");
                Panel_Small.Write(ini, section + "/Panel_Small");
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
    public class TTeach_Cal_Data_One_CCD : TBase_Class
    {
        public bool Data_OK = false;
        public TJJS_Point Center = new TJJS_Point();

        public TTeach_Cal_Data_One_CCD()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Cal_Data_One_CCD();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Cal_Data_One_CCD && dis_base is TTeach_Cal_Data_One_CCD)
            {
                TTeach_Cal_Data_One_CCD sor = (TTeach_Cal_Data_One_CCD)sor_base;
                TTeach_Cal_Data_One_CCD dis = (TTeach_Cal_Data_One_CCD)dis_base;

                dis.Data_OK = sor.Data_OK;
                dis.Center.Set(sor.Center);
            }
        }

        public void Set_Default()
        {
            Data_OK = false;
            Center.Set(0, 0);
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
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
