using System;
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
using EFC.CAD;
using EFC.INI;


namespace EFC.Vision.Halcon
{
    //-----------------------------------------------------------------------------------------------------
    //Align_Mode = 0, 無
    //
    //Align_Mode = 1, 使用1點定位 X,Y,
    //
    //Align_Mode = 2, 使用2點定位 X,Y,Q
    //Align_Angle = false, 角度不修正, Align_Angle = true,角度修正
    //
    //Base_Image = 參考的基準影像
    //
    //Find_Result[0] = 第1點資訊
    //Find_Result[1] = 第2點資訊
    //Find_Result[2] = 對位基準點資訊,2點模式，目前基準為第1點
    //-----------------------------------------------------------------------------------------------------
    public partial class TForm_Image_Pre_Process : Form
    {
        public string Default_Path;
        public HImage Sample_Image = new HImage();
        public TImage_Pre_Process_Param Param = new TImage_Pre_Process_Param();
        public TImage_Pre_Process_Result Result = new TImage_Pre_Process_Result();
        public TFrame_JJS_HW JJS_HW = null;
        public int Step = 0;

        
        public TForm_Image_Pre_Process()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        public int Image_Width
        {
            get
            {
                int w, h;
                Sample_Image.GetImageSize(out w, out h);
                return w;
            }
        }
        public int Image_Height
        {
            get
            {
                int w, h;
                Sample_Image.GetImageSize(out w, out h);
                return h;
            }
        }
        private void TForm_Align_Mothed2_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            JJS_HW.SetPart(Sample_Image);
            Disp_Image(JJS_HW.HW_Buf, Sample_Image);
            JJS_HW.Copy_HW();
        }
        public void Set_Param(TImage_Pre_Process_Param param)
        {
            Param.Set(param);

            E_Threhold_Min.Text = Param.Threshold_Min.ToString();
            E_Threhold_Max.Text = Param.Threshold_Max.ToString();
            E_Circle_Size.Text = Param.Circle_Size.ToString("0.0");
        }
        public void Update_Param()
        {
            try
            {
                Param.Threshold_Min = Convert.ToDouble(E_Threhold_Min.Text);
                Param.Threshold_Max = Convert.ToDouble(E_Threhold_Max.Text);
                Param.Circle_Size = Convert.ToDouble(E_Circle_Size.Text);
            }
            catch { };
        }
        private void B_Set_Default_Click(object sender, EventArgs e)
        {
            Param.Set_Default();
            Set_Param(Param);
        }
        public void Disp_Image(HWindowControl hw, HImage image, bool clear_flag = true)
        {
            if (clear_flag) hw.HalconWindow.ClearWindow();
            if (JJS_Vision.Is_Not_Empty(image))
                hw.HalconWindow.DispObj(image);
        }
        public void Update_View()
        {
            bool flag = true;
            HRegion region = new HRegion();

            Update_Param();
            if (true)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                Disp_Image(JJS_HW.HW_Buf, Sample_Image);

                #region Step1 display image
                if (Step >= 1 && flag)
                {
                    Param.Run_Process(Sample_Image, ref Result);
                    if (Step == 1)
                    {
                        Disp_Image(JJS_HW.HW_Buf, Result.Image);
                    }
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    Disp_Image(JJS_HW.HW_Buf, Result.Image);
                }
                #endregion

                JJS_HW.Copy_HW();
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
        private void TP_Step0_Enter(object sender, EventArgs e)
        {
            Step = 0;
            Update_View();
        }
        private void TP_Step1_Enter(object sender, EventArgs e)
        {
            Step = 1;
            Update_View();
        }
        private void TP_Step2_Enter(object sender, EventArgs e)
        {
            Step = 2;
            Update_View();
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
            Update_View();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void B_Update_Click(object sender, EventArgs e)
        {
            Update_View();
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
    public class TImage_Pre_Process_Param : TBase_Param
    {
        public string                   Class_Name; 
        public double                   Threshold_Min = 0;
        public double                   Threshold_Max = 0;
        public double                   Circle_Size = 0;


        public TImage_Pre_Process_Param()
        {
            Class_Name = "TImage_Pre_Process_Param";
            Set_Default();
        }
        public override TBase_Class New_Class()
        {
            TBase_Class result = new TImage_Pre_Process_Param();
            return result;
        }
        public override TBase_Result New_Base_Result()
        {
            TBase_Result result = new TImage_Pre_Process_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TImage_Pre_Process_Param && dis_base is TImage_Pre_Process_Param)
            {

                TImage_Pre_Process_Param sor = (TImage_Pre_Process_Param)sor_base;
                TImage_Pre_Process_Param dis = (TImage_Pre_Process_Param)dis_base;
                base.Copy(sor, dis);
                dis.Threshold_Min = sor.Threshold_Min;
                dis.Threshold_Max = sor.Threshold_Max;
                dis.Circle_Size = sor.Circle_Size;
                dis.Update();
            }
        }
        public override void Set_Default()
        {
            base.Set_Default();
            Threshold_Min = 0;
            Threshold_Max = 255;
            Circle_Size = 3.5;
        }
        override public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
        public override void Read(TJJS_XML_File ini, string section)
        {
            string path = Default_Path;
            if (ini != null)
            {
                base.Read(ini, section);
                path = Default_Path;
                Threshold_Min = ini.ReadFloat(section, "Threshold_Min", Threshold_Min);
                Threshold_Max = ini.ReadFloat(section, "Threshold_Max", Threshold_Max);
                Circle_Size = ini.ReadFloat(section, "Circle_Size", Circle_Size);
                Read_Other_File();
                Update();
            }
        }
        public override void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null)
            {
                base.Write(ini, section);
                ini.WriteFloat(section, "Threshold_Min", Threshold_Min);
                ini.WriteFloat(section, "Threshold_Max", Threshold_Max);
                ini.WriteFloat(section, "Circle_Size", Circle_Size);

                Write_Other_File();
                Update();
            }
        }
        public override void Read_Other_File()
        {
        }
        public override void Write_Other_File()
        {
        }
        public void Log_Diff(TLog log, string section, TImage_Pre_Process_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Threshold_Min", Threshold_Min, new_value.Threshold_Min, ref flag);
            log.Log_Diff(section + "/Threshold_Max", Threshold_Max, new_value.Threshold_Max, ref flag);
            log.Log_Diff(section + "/Circle_Size", Circle_Size, new_value.Circle_Size, ref flag);
        }

        public override bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Image_Pre_Process form = new TForm_Image_Pre_Process();
            JJS_Vision.Copy_Obj(image, ref form.Sample_Image);
            form.Default_Path = Default_Path;
            form.Set_Param(this);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set(form.Param);
                result = true;
            }
            return result;
        }
        public override bool Find_Base(HImage image, ref TBase_Result f_result)
        {
            return false;
        }
        public bool Run_Process(HImage image, ref TImage_Pre_Process_Result f_result)
        {
            f_result.Image = Run_Process(image);
            f_result.Find_OK = true;
            return f_result.Find_OK;
        }
        public HImage Run_Process(HImage image)
        {
            HImage result = new HImage();
            HRegion region = new HRegion();
            int w, h;

            image.GetImageSize(out w, out h);
            region = image.Threshold(Threshold_Min, Threshold_Max);
            region = region.DilationCircle(Circle_Size);
            region = region.ErosionCircle(Circle_Size);
            result = region.RegionToBin(128, 0, w, h);
            return result;
        }

        public void Update()
        {
        }
    }
    public class TImage_Pre_Process_Result : TBase_Result
    {
        public HImage                Image = new HImage();
        public TBase_Disp_Param      Disp_Param = new TBase_Disp_Param();

        public TImage_Pre_Process_Result()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TImage_Pre_Process_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TImage_Pre_Process_Result && dis_base is TImage_Pre_Process_Result)
            {
                base.Copy(sor_base, dis_base);
                TImage_Pre_Process_Result sor = (TImage_Pre_Process_Result)sor_base;
                TImage_Pre_Process_Result dis = (TImage_Pre_Process_Result)dis_base;

                if (JJS_Vision.Is_Not_Empty(sor.Image)) dis.Image = sor.Image.Clone();
                dis.Disp_Param.Set(sor.Disp_Param);
            }
        }


        override public void Set_Default()
        {
            base.Set_Default();
            Disp_Param.Set_Default();
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Disp_Param.Read(ini, "/Disp_Param");
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Disp_Param.Write(ini, "/Disp_Param");
            }
        }
        override public void Read_Other_File()
        {
        }
        override public void Write_Other_File()
        {

        }

        override public void Reset()
        {
            Find_OK = false;
            Image = new HImage();
        }
        override public void Display_Message(HWindowControl hw)
        {

        }
        override public void Display_Model(HWindowControl hw)
        {

        }
        override public string Get_Message()
        {
            string result = "";
            return result;
        }
    }
}
