using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using Cognex.DataMan.SDK;
using Cognex.DataMan.SDK.Discovery;
using Cognex.DataMan.SDK.Utils;
using EFC.Tool;


namespace Cognex.DataMan
{
    public class TReader_Cognex_DataMan
    {
        public TLog      Log = null;
        public Image     Read_Image = null;
        public bool      Reflash = false;
        public ArrayList Device_List = new ArrayList();

        private DataManSystem System = null;
        private EthSystemDiscoverer System_Discoverer = null;
        private EthSystemDiscoverer.SystemInfo System_Info;
        private EthSystemConnector Connector = null;
        private ResultCollector Result_Collector = null;

        private bool InConnect = false;
        private bool in_On_Life = false;
        private string Read_String = "";
        private bool Read_Finish = false;


        public bool Connect
        {
            get
            {
                return InConnect;
            }
            set
            {
                Set_Connect(value);
            }
        }
        public bool On_Life
        {
            get
            {
                return in_On_Life;
            }
            set
            {
                Set_Life(value);
            }
        }
        public TReader_Cognex_DataMan()
        {
            try
            {
                // Create discoverers to discover ethernet and serial port systems.
                System_Discoverer = new EthSystemDiscoverer();

                // Subscribe to the system discoved event.
                System_Discoverer.SystemDiscovered += new EthSystemDiscoverer.SystemDiscoveredHandler(OnEthSystemDiscovered);

                // Ask the discoverers to start discovering systems.
                System_Discoverer.Discover();
                //System.Threading.Thread.Sleep(5000);
            }
            catch (Exception e)
            {

            }
        }

        //**********************列出所連線到的DM************************************
        private void OnEthSystemDiscovered(EthSystemDiscoverer.SystemInfo systemInfo)
        {

            System_Info = systemInfo;
            Device_List.Add(systemInfo);
            //lbCameraName.Text = systemInfo.Name;
            //lbIP.Text = Convert.ToString(systemInfo.IPAddress);
            //_syncContext.Post(
            //   new SendOrPostCallback(
            //       delegate
            //       {
            //           Device_List.Add(systemInfo.ToString());
            //           eth_system_info = systemInfo;
            //       }),
            //       null);
        }
        public void Set_Connect(bool state)
        {
            if (Device_List.Count > 0)
            {
                try
                {
                    EthSystemDiscoverer.SystemInfo systemInfo = (EthSystemDiscoverer.SystemInfo)Device_List[0];
                    IPAddress ipa = systemInfo.IPAddress;

                    Connector = new EthSystemConnector(ipa, 4001);
                    Connector.UserName = "admin";
                    Connector.Password = "";

                    System = new DataManSystem(Connector);
                    System.DefaultTimeout = 5000;

                    ResultTypes requested_result_types = ResultTypes.ReadXml | ResultTypes.Image | ResultTypes.ImageGraphics;

                    Result_Collector = new ResultCollector(System, requested_result_types);
                    Result_Collector.ComplexResultArrived += Results_ComplexResultArrived;

                    System.Connect();
                    System.SetResultTypes(requested_result_types);


                    if (System.State == Cognex.DataMan.SDK.ConnectionState.Connected)
                    {
                        InConnect = true;
                        //BtnTrigger.Enabled = true;
                        //cbLiveDisplay.Enabled = true;

                        //btnConnect.BackColor = Color.Red;
                        //btnConnect.Text = "Disconnection";

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
        }
        public void Set_Life(bool state)
        {
            try
            {
                in_On_Life = state;
                if (in_On_Life)
                {
                    System.SendCommand("SET LIVEIMG.MODE 2");
                    BeginGetLiveImage();
                }
                else
                {
                    System.SendCommand("SET LIVEIMG.MODE 0");
                }
            }
            catch
            {
            }
        }
        public bool Get_Code(ref string read_code)
        {
            bool result = false;

            if (Connect && !On_Life)
            {
                Read_Finish = false;
                Read_String = "";
                Trigger_ON();
                //Trigger_OFF();
                while (!Read_Finish) { };
                read_code = Read_String;
                Log_Add(string.Format("Get_Code = {0:s}", Read_String));
                result = true;
            }
            else
            {
                Log_Add(string.Format("Get_Code Error."));
            }
            return result;
        }


        public void Log_Add(string msg)
        {
            if (Log != null && Log.Enabled) Log.Add(msg);
        }

        private void Trigger_ON()
        {
            try
            {
                System.SendCommand("TRIGGER ON");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send TRIGGER ON command: " + ex.ToString());
            }
        }
        private void Trigger_OFF()
        {
            try
            {
                System.SendCommand("TRIGGER OFF");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send TRIGGER OFF command: " + ex.ToString());
            }
        }
        void Results_ComplexResultArrived(object sender, ResultInfo e)
        {
            if (e.Image != null)
            {
                Read_Image = (Image)e.Image.Clone();
                Reflash = true;
            }
            if (e.ReadString != null)
            {
                Read_String = e.ReadString;
            }
            else
            {
                Read_String = Get_String_Xml(e.XmlResult);
            }
            Read_Finish = true;
        }
        private string Get_String_Xml(string resultXml)
        {
            string result = "";
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
                        result = System.Encoding.GetString(code, 0, code.Length);
                    }
                    else
                    {
                        result = full_string_node.InnerText;
                    }
                }
            }
            catch
            {
            }

            return result;
        }
        private void BeginGetLiveImage()
        {
            System.BeginGetLiveImage(
                Cognex.DataMan.SDK.ImageFormat.jpeg,
                ImageSize.Full,
                ImageQuality.High,
                OnLiveImageArrived,
                null);
        }
        private void OnLiveImageArrived(IAsyncResult result)
        {
            try
            {
                Read_Image = System.EndGetLiveImage(result);
                Reflash = true;
            }
            catch
            {
            }
            finally
            {
                if (in_On_Life) BeginGetLiveImage();
            }
        }

    }
}
