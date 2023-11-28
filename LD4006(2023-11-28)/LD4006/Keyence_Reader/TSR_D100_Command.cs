using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace TEFC_Communication
{
    public class TSR_D100_Command
    {
        //工用變數
        public bool Reading = false;
        public bool Read_Finish = false;
        public bool Read_Ok = false;
        public string Read_Data = "";
        public bool Wait_OK_LON = false;
        //變數
        bool FBusy;
        bool FOn_TimeOut;
        bool Read_Result = false;
        bool IsconnectOK = false;
        System.Windows.Forms.Timer Timer1 = new System.Windows.Forms.Timer();
        private System.Timers.Timer Connect_Timer = new System.Timers.Timer(1000);
        private System.Timers.Timer Receive_Timer = new System.Timers.Timer(100);
        private Socket clientSocket;
        byte[] Write_Buffer = new byte[1024];
        private static byte[] Read_Buffer = new byte[1024];
        int Write_Count = 0;
        int Read_Count = 0;
        string Host_Ip = "192.168.0.101";
        int Host_Port = 5000;
        public bool Connecting { get { return IsconnectOK; } }
        public bool Add_Log = false;
        public string Log_Data = "";
        //靜態變數
        public static Boolean IsconnectSuccess = false; //异步连接情况，由异步连接回调函数置位
        private static object lockObj_IsConnectSuccess = new object();
        private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        private static String SockErrorStr = null;
        //建構式
        public TSR_D100_Command()
        {
            //Timer1
            Timer1.Enabled = false;
            Timer1.Interval = 2000;
            Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            //Connect_Timer
            Connect_Timer.Elapsed += new System.Timers.ElapsedEventHandler(ConnectTimer_Tick);
            Connect_Timer.AutoReset = false;
            //Receive_Timer
            Receive_Timer.Elapsed += new System.Timers.ElapsedEventHandler(ReceiveTimer_Tick);
            Receive_Timer.AutoReset = false;
            Receive_Timer.Enabled = true;
            //plc state
            FBusy = false;
        }
        //Timer1
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            FOn_TimeOut = true;
            //輸出讀取完成但讀取失敗
            Read_Finish = true;
            Read_Ok = false;
            Reading = false;
            Send_Command(1);
        }
        //ConnectTimer
        private void ConnectTimer_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            checkSocketState();
            if (IsconnectOK == false)
                Connect_Timer.Enabled = true;
        }
        //連線
        public bool Connect(string address, int port)
        {
            Host_Ip = address;
            Host_Port = port;
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.SendTimeout = 500;
            clientSocket.ReceiveTimeout = 500;
            IPAddress ip = IPAddress.Parse(address);
            IPEndPoint remoteEP = new IPEndPoint(ip, port);
            TimeoutObject.Reset(); //复位timeout事件
            try
            {
                clientSocket.BeginConnect(remoteEP, connectedCallback, clientSocket);
            }
            catch (Exception err)
            {
                SockErrorStr = err.ToString();
                return false;
            }
            if (TimeoutObject.WaitOne(1000, false))//直到timeout，或者TimeoutObject.set()
            {
                if (IsconnectSuccess)
                {
                    IsconnectOK = true;
                    return true;
                }
                else
                {
                    IsconnectOK = false;
                    Connect_Timer.Enabled = true;
                    return false;
                }
            }
            else
            {
                SockErrorStr = "Time Out";
                IsconnectOK = false;
                Connect_Timer.Enabled = true;
                return false;
            }
        }
        //連線狀態Callback
        static void connectedCallback(IAsyncResult iar)
        {
            #region <remarks>
            /// 1、置位IsconnectSuccess
            #endregion </remarks>

            lock (lockObj_IsConnectSuccess)
            {
                Socket client = (Socket)iar.AsyncState;
                try
                {
                    client.EndConnect(iar);
                    IsconnectSuccess = true;
                    //StartKeepAlive(); //开始KeppAlive检测
                }
                catch (Exception e)
                {
                    SockErrorStr = e.ToString();
                    IsconnectSuccess = false;
                }
                finally
                {
                    TimeoutObject.Set();
                }
            }
        }
        //確認連接狀況
        public bool checkSocketState()
        {
            try
            {
                if (clientSocket == null)
                {
                    return Connect(Host_Ip, Host_Port);
                }
                else if (IsconnectOK)
                {
                    return true;
                }
                else//已创建套接字，但未connected
                {
                    IPAddress ipAddress = IPAddress.Parse(Host_Ip);
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, Host_Port);
                    clientSocket.SendTimeout = 500;
                    clientSocket.ReceiveTimeout = 500;
                    #region 异步连接代码
                    TimeoutObject.Reset(); //复位timeout事件
                    try
                    {
                        clientSocket.BeginConnect(remoteEP, connectedCallback, clientSocket);
                    }
                    catch (Exception err)
                    {
                        SockErrorStr = err.ToString();
                        ReConnect();
                        return false;
                    }
                    if (TimeoutObject.WaitOne(1000, false))//直到timeout，或者TimeoutObject.set()
                    {
                        if (IsconnectSuccess)
                        {
                            IsconnectOK = true;
                            return true;
                        }
                        else
                        {
                            IsconnectOK = false;
                            return false;
                        }
                    }
                    else
                    {
                        SockErrorStr = "Time Out";
                        IsconnectOK = false;
                        return false;
                    }

                    #endregion
                }
            }
            catch (SocketException se)
            {
                SockErrorStr = se.ToString();
                IsconnectOK = false;
                return false;
            }
        }
        //重新連線
        private void ReConnect()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Disconnect(false);
            IsconnectSuccess = false;
            IsconnectOK = false;
            clientSocket.Close();
            clientSocket = null;
            Connect_Timer.Enabled = true;
        }
        //關閉socket
        public void CloseConnect()
        {
            clientSocket.Disconnect(true);
            clientSocket.Close();
        }

        //Receive Timer
        private void ReceiveTimer_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            int receiveNumber = 0;
            Receive_Timer.Enabled = false;
            if (clientSocket != null && IsconnectOK == true)
            {
                //接收資料
                try
                {
                    receiveNumber = clientSocket.Receive(Read_Buffer);
                }
                catch (Exception err)
                {
                    ReConnect();
                    SockErrorStr = err.ToString();
                }
                //取得字串
                string receive_str = Encoding.ASCII.GetString(Read_Buffer, 0, receiveNumber);
                //判斷命令
                if (receive_str != "" && ((!receive_str.Contains("ERROR")) && (!receive_str.Contains("ER"))) && receive_str.Length > 10)
                {
                    string tmpstr = "";
                    int pos = 0;
                    pos = receive_str.IndexOf("\r");
                    tmpstr = receive_str.Substring(0, pos);
                    Write_Log("[Socket READ]" + tmpstr);
                    //輸出讀取資料
                    Read_Data = tmpstr;
                    //輸出讀取完成
                    Read_Finish = true;
                    //輸出讀取OK
                    Read_Ok = true;
                    ////關閉計時器
                    //Timer1.Enabled = false;
                    Reading = false;
                    //if (Wait_OK_LON == true && (receive_str == "OK,LON\r" || receive_str == "OK,LOFF\r" || receive_str.Substring(0, 7) == "OK,LOFF" || receive_str.Substring(0, 7) == "ER,LOFF") && Read_Result == false)
                    //{
                    //    Read_Result = true;
                    //    receive_str = "";
                    //}
                    //else if(Wait_OK_LON == false || Read_Result == true)
                    //{
                    //    string tmpstr = "";
                    //    int pos = 0;
                    //    pos = receive_str.IndexOf("\r");
                    //    tmpstr = receive_str.Substring(0, pos);
                    //    Write_Log("[Socket READ]" + tmpstr);
                    //    //輸出讀取資料
                    //    Read_Data = tmpstr;
                    //    //輸出讀取完成
                    //    Read_Finish = true;
                    //    //輸出讀取OK
                    //    Read_Ok = true;
                    //    ////關閉計時器
                    //    //Timer1.Enabled = false;
                    //    Reading = false; 
                    //}
                }
                else if (receive_str.Contains("ERROR") || receive_str.Contains("ER"))// == "ERROR\r")
                {
                    string tmpstr = "ERROR";
                    Write_Log("[Socket READ]" + tmpstr);
                    //輸出讀取資料
                    Read_Data = tmpstr;
                    //輸出讀取完成
                    Read_Finish = true;
                    //輸出讀取OK
                    Read_Ok = false;
                    ////關閉計時器
                    //Timer1.Enabled = false;
                    Reading = false;
                }
            }
            Receive_Timer.Enabled = true;
        }
        //Send Command
        public void Send_Command(int code)
        {
            if (clientSocket != null && IsconnectOK == true)
            {
                try
                {
                    switch (code)
                    {
                        case 0:
                            Read_Result = false;
                            Read_Finish = false;
                            Read_Ok = false;
                            Reading = true;
                            Write_Log("[Socket Send]LON");
                            //開啟timeout計時器
                            //Timer1.Enabled = true;
                            clientSocket.Send(Encoding.ASCII.GetBytes("LON\r"));
                        break;
                        case 1:
                            //Timer1.Enabled = false;
                            Reading = false;
                            Write_Log("[Socket Send]LOFF");
                            clientSocket.Send(Encoding.ASCII.GetBytes("LOFF\r"));
                        break;
                    }
                }
                catch (Exception err)
                {
                    SockErrorStr = err.ToString();
                }
            }
        }
        //Log寫入
        public void Write_Log(string addstr)
        {
            Add_Log = true;
            Log_Data = addstr;
        }
        //end
    }
}
