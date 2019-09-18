using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.IO.Ports;
using System.Net;

namespace RMU30
{
    /// <summary>
    /// 
    /// </summary>

    partial class Form
    {
        private ComSerial comSerial = new ComSerial();

        private List<byte> dataBufferCom = new List<byte>();

        private bool bComOpen = false;

        private DateTime timeStamp;

        public const int defComMaxDataSize = 64;
       
        // フォームの初期化
        private void execFormInitialize()
        {
            //// 
            InitializeComponent();

            //// COMポート取得            
            getSerialPort();
        }

        /// <summary>
        /// COMポート取得
        /// </summary>

        public void getSerialPort()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                this.comboCom.Items.Add(port);
                this.comboCom.SelectedItem = port;
            }
        }

        /// <summary>
        /// 接続・切断
        /// </summary>

        //private void execConnectTcp()
        //{
        //    try
        //    {
        //        int port = (int)numericTcp.Value;
        //        string ipaddr = textBoxIPAddress.Text;
        //        if (!connectTcp(port, ipaddr))
        //        {
        //            MessageBox.Show("TCPポートが接続できません。", "接続エラー");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("TCPポートが接続できません。", "接続エラー");
        //    }
        //}

        //private bool connectTcp(int port, string ipaddr)
        //{
        //    try
        //    {
        //        if (!bLanOpen)
        //        {
        //            //backgroundWorkerTcp.WorkerReportsProgress = true;
        //            //backgroundWorkerTcp.WorkerSupportsCancellation = true;
        //            //backgroundWorkerTcp.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerTcp_DoWork);

        //            var task = Task.Run(() => tcpListen(port, ipaddr));

        //            //if (!Define.defDebugMode)
        //            //{
        //            //    if (!comEthernet.Open(port, ipaddr))
        //            //    {
        //            //        return false;
        //            //    }
        //            //}

        //            bLanOpen = true;

        //            panelTcp.BackgroundImage = Resource1.menu_lan_on;

        //            //// スレッドの起動
        //            //backgroundWorkerTcp.RunWorkerAsync();

        //            return true;
        //        }
        //        else
        //        {
        //            //// スレッド終了
        //            //if (backgroundWorkerTcp.IsBusy)
        //            //{
        //            //    backgroundWorkerTcp.CancelAsync();
        //            //}

        //            tcpClose();
        //            bLanOpen = false;

        //            panelTcp.BackgroundImage = Resource1.menu_lan_off;

        //            return true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //backgroundWorkerTcp.CancelAsync();

        //        bLanOpen = false;
        //        panelTcp.BackgroundImage = Resource1.menu_lan_off;
        //        return false;
        //    }
        //}

        /// <summary>
        /// 接続・切断
        /// </summary>

        private void execConnectCom()
        {
            try
            {
                string port = (string)comboCom.Items[comboCom.SelectedIndex];
                if (!connectCom(port))
                {
                    MessageBox.Show("COMポートが接続できません。", "接続エラー");
                }

            }
            catch
            {
                MessageBox.Show("COMポートが接続できません。", "接続エラー");
            }
        }

        private bool connectCom(string port)
        {
            try
            {
                if (!bComOpen)
                {
                    if (!comSerial.Open(port, 9600, defComMaxDataSize))
                    {
                        return false;
                    }

                    bComOpen = true;
                    panelUsb.BackgroundImage = Resource.menu_usb_on;


                    return true;
                }
                else
                {
                    comSerial.Close();

                    bComOpen = false;
                    panelUsb.BackgroundImage = Resource.menu_usb_off;
                    return true;
                }
            }
            catch (Exception)
            {
                bComOpen = false;
                panelUsb.BackgroundImage = Resource.menu_usb_off;
                return false;
            }         
        }
    }
}
