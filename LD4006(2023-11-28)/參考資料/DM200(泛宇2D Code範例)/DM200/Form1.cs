using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.DataMan.SDK;
using Cognex.DataMan.SDK.Discovery;
using Cognex.DataMan.SDK.Utils;
using System.Threading;
using System.Xml;

using System.Net;

namespace DM200
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _syncContext = WindowsFormsSynchronizationContext.Current;
        }

        private EthSystemDiscoverer _ethSystemDiscoverer = null;
        private EthSystemDiscoverer.SystemInfo eth_system_info;
        private SynchronizationContext _syncContext = null;
        private ISystemConnector _connector = null;
        private DataManSystem _system = null;
        private ResultCollector _results;
        private object _currentResultInfoSyncLock = new object();
        Image fitted_image;

        //********************Live*****************************
        private void cbLiveDisplay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbLiveDisplay.Checked)
                {
                    BtnTrigger.Enabled = false;


                    _system.SendCommand("SET LIVEIMG.MODE 2");
                    _system.BeginGetLiveImage(
                        Cognex.DataMan.SDK.ImageFormat.jpeg,
                        ImageSize.Full,
                        ImageQuality.High,
                        OnLiveImageArrived,
                        null);
                }
                else
                {
                    BtnTrigger.Enabled = true;

                    _system.SendCommand("SET LIVEIMG.MODE 0");
                }
            }
            catch
            {
            }
        }

        private void OnLiveImageArrived(IAsyncResult result)
        {
            try
            {
                Image image = _system.EndGetLiveImage(result);
                Size image_size = Gui.FitImageInControl(image.Size, picResultImage.Size);
                Image fitted_image = Gui.ResizeImageToBitmap(image, image_size);

                _syncContext.Post(
                    delegate
                    {
                        picResultImage.Image = fitted_image;
                        picResultImage.Invalidate();
                    },
                null);
            }
            catch
            {
            }
            finally
            {
                if (cbLiveDisplay.Checked)
                {
                    _system.BeginGetLiveImage(
                        Cognex.DataMan.SDK.ImageFormat.jpeg,
                        ImageSize.Full,
                        ImageQuality.High,
                        OnLiveImageArrived,
                        null);
                }
            }
        }
        //*******************************************************************************

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create discoverers to discover ethernet and serial port systems.
            _ethSystemDiscoverer = new EthSystemDiscoverer();

            // Subscribe to the system discoved event.
            _ethSystemDiscoverer.SystemDiscovered += new EthSystemDiscoverer.SystemDiscoveredHandler(OnEthSystemDiscovered);

            // Ask the discoverers to start discovering systems.
            _ethSystemDiscoverer.Discover();

            System.Threading.Thread.Sleep(5000);

           
        }
      
        //**********************列出所連線到的DM************************************
        private void OnEthSystemDiscovered(EthSystemDiscoverer.SystemInfo systemInfo)
        {
           
            eth_system_info = systemInfo;
            //lbCameraName.Text = systemInfo.Name;
            //lbIP.Text = Convert.ToString(systemInfo.IPAddress);
            _syncContext.Post(
               new SendOrPostCallback(
                   delegate
                   {
                       listBoxDetectedSystems.Items.Add(systemInfo);
                       eth_system_info = systemInfo;
                   }),
                   null);
        }

        //**********************選取Listbox後DM的資料************************************
        private void listBoxDetectedSystems_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBoxDetectedSystems.SelectedIndex != -1 && listBoxDetectedSystems.Items.Count > listBoxDetectedSystems.SelectedIndex)
            {
                var system_info = listBoxDetectedSystems.Items[listBoxDetectedSystems.SelectedIndex];

                if (system_info is EthSystemDiscoverer.SystemInfo)
                {
                    EthSystemDiscoverer.SystemInfo eth_system_info = system_info as EthSystemDiscoverer.SystemInfo;
                    
                    lbIP.Text = eth_system_info.IPAddress.ToString();
                    lbCameraName.Text = eth_system_info.Name.ToString();
                }
            }
            else
                btnConnect.Enabled = false;
        }

        //***********************連線************************
        private void btnConnect_Click(object sender, EventArgs e)
        {
           
                if (btnConnect.Text == "Connected")
                {
                    try
                    {
                        // Create discoverers to discover ethernet and serial port systems.
                        _ethSystemDiscoverer = new EthSystemDiscoverer();

                        // Subscribe to the system discoved event.
                        _ethSystemDiscoverer.SystemDiscovered += new EthSystemDiscoverer.SystemDiscoveredHandler(OnEthSystemDiscovered);

                        // Ask the discoverers to start discovering systems.
                        _ethSystemDiscoverer.Discover();


                        IPAddress ipa = IPAddress.Parse(lbIP.Text);
                        EthSystemConnector conn = new EthSystemConnector(ipa, 4001);

                        //EthSystemConnector conn = new EthSystemConnector(eth_system_info.IPAddress, eth_system_info.Port);
                        conn.UserName = "admin";
                        conn.Password = "";
                        _connector = conn;

                        _system = new DataManSystem(_connector);
                        _system.DefaultTimeout = 5000;

                        BtnTrigger.MouseDown += new MouseEventHandler(BtnTrigger_MouseDown);
                        BtnTrigger.MouseUp += new MouseEventHandler(BtnTrigger_MouseUp);

                        ResultTypes requested_result_types = ResultTypes.ReadXml | ResultTypes.Image | ResultTypes.ImageGraphics;

                        _results = new ResultCollector(_system, requested_result_types);
                        _results.ComplexResultArrived += Results_ComplexResultArrived;

                        _system.Connect();
                        _system.SetResultTypes(requested_result_types);


                        if (_system.State == Cognex.DataMan.SDK.ConnectionState.Connected)
                        {
                            BtnTrigger.Enabled = true;
                            cbLiveDisplay.Enabled = true;
                         
                            btnConnect.BackColor = Color.Red;
                            btnConnect.Text = "Disconnection";
                          
                            //取得DM值
                            //DM_data_get();
                        }
                        else
                        {
                           
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                   
                    cbLiveDisplay.Checked = false;
                    btnConnect.BackColor = Color.Lime;
                    btnConnect.Text = "Connected";
                    lbIP.Visible = true;
                    BtnTrigger.Enabled = false;
                    cbLiveDisplay.Enabled = false;
                    _connector = null;
                    _system = null;
                }
            }

        // //**********************************Trigger**************************************
        private void BtnTrigger_MouseDown(object sender, MouseEventArgs e)
        {
          TxtResult.Text = "";
                try
                {
                    _system.SendCommand("TRIGGER ON");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to send TRIGGER ON command: " + ex.ToString());
                }
        }

        private void BtnTrigger_MouseUp(object sender, MouseEventArgs e)
        {
              try
                {
                    _system.SendCommand("TRIGGER OFF");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to send TRIGGER OFF command: " + ex.ToString());
                }
           
        }


        void Results_ComplexResultArrived(object sender, ResultInfo e)
        {
            _syncContext.Post(
                delegate
                {
                    ShowResult(e);
                },
                null);
        }


        //*********************結果*********************************************
        private void ShowResult(ResultInfo e)
        {
            List<Image> images = new List<Image>();
            List<string> image_graphics = new List<string>();
            string read_result = null;

            // Take a reference or copy values from the locked result info object. This is done
            // so that the lock is used only for a short period of time.
            lock (_currentResultInfoSyncLock)
            {
                read_result = !String.IsNullOrEmpty(e.ReadString) ? e.ReadString : GetReadStringFromResultXml(e.XmlResult);

                if (e.Image != null)
                    images.Add(e.Image);

                if (e.ImageGraphics != null)
                    image_graphics.Add(e.ImageGraphics);

                if (e.SubResults != null)
                {
                    foreach (var item in e.SubResults)
                    {
                        if (item.Image != null)
                            images.Add(item.Image);

                        if (item.ImageGraphics != null)
                            image_graphics.Add(item.ImageGraphics);
                    }
                }
            }

            TxtResult.Text = read_result;

            //if (images.Count > 0)
            //{
            //    Image first_image = images[0];

            //    Size image_size = Gui.FitImageInControl(first_image.Size, picResultImage.Size);
            //    fitted_image = Gui.ResizeImageToBitmap(first_image, image_size);

            //    if (image_graphics.Count > 0)
            //    {
            //        using (Graphics g = Graphics.FromImage(fitted_image))
            //        {
            //            foreach (var graphics in image_graphics)
            //            {
            //                ResultGraphics rg = GraphicsResultParser.Parse(graphics, new Rectangle(0, 0, image_size.Width, image_size.Height));
            //                ResultGraphicsRenderer.PaintResults(g, rg);
            //            }
            //        }
            //    }

            //    if (picResultImage.Image != null)
            //        picResultImage.Image.Dispose();

            //    picResultImage.Image = fitted_image;
            //    picResultImage.Invalidate();
            //}

           }


        private string GetReadStringFromResultXml(string resultXml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                doc.LoadXml(resultXml);

                XmlNode full_string_node = doc.SelectSingleNode("result/general/full_string");

                if (full_string_node != null)
                {
                    XmlAttribute encoding = full_string_node.Attributes["encoding"];
                    if (encoding != null && encoding.InnerText == "base64")
                    {
                        byte[] code = Convert.FromBase64String(full_string_node.InnerText);
                        return _system.Encoding.GetString(code, 0, code.Length);
                    }

                    return full_string_node.InnerText;
                }
            }
            catch
            {
            }

            return "";
        }

        //**********************************取得DM曝光值**************************************

        private void DM_data_get()
        {

            //取得no_Read string 資訊
            // DmccResponse aa = _system.SendCommand("GET RESULT.NO-READ-STRING");


            DmccResponse response = _system.SendCommand("GET CAMERA.EXPOSURE");
            DmccResponse response1 = _system.SendCommand("GET CAMERA.MAX-EXPOSURE");
            string[] data = response.PayLoad.ToString().Split(' ');
            if (data[0] == "ON")
            {
                //radioButton1.Checked = true;
                //numericUpDown1.Value = Convert.ToInt16(data[1].ToString());
                //comboBox2.SelectedIndex = Convert.ToInt16(data[2].ToString()) - 9;
                //numericUpDown3.Value = Convert.ToInt16(data[3].ToString());
                //comboBox1.SelectedIndex = Convert.ToInt16(response1.PayLoad.ToString()) - 9;

                //groupBox7.Enabled = true;
                //groupBox8.Enabled = false;

            }
            else
            {
                //radioButton2.Checked = true;
                //numericUpDown1.Value = Convert.ToInt16(data[1].ToString());
                //comboBox2.SelectedIndex = Convert.ToInt16(data[2].ToString()) - 9;
                //numericUpDown3.Value = Convert.ToInt16(data[3].ToString());
                //comboBox1.SelectedIndex = Convert.ToInt16(response1.PayLoad.ToString()) - 9;

                //groupBox7.Enabled = false;
                //groupBox8.Enabled = true;
            }
        }

        private void BtnTrigger_Click(object sender, EventArgs e)
        {

        }


       }
        
     
    
}
