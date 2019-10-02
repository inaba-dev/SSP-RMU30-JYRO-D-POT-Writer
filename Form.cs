using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMU30
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            execFormInitialize();

            ////
            userControl1.title.Text = "AGC Trim";
            userControl2.title.Text = "REAL Trim";
            userControl3.title.Text = "VCO Trim";
            userControl4.title.Text = "PHASE Trim";

            ////
            userControl1.ProgressEvent += new UserControl1.EventHandler(comFunction1);
            userControl2.ProgressEvent += new UserControl1.EventHandler(comFunction2);
            userControl3.ProgressEvent += new UserControl1.EventHandler(comFunction3);
            userControl4.ProgressEvent += new UserControl1.EventHandler(comFunction4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Reload(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>

        public class RecvData
        {
            public int data { get; set; }
            public int status { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>

        public void comFunction1(int func)
        {
            int addr = 0;

            //// COMポートの接続確認
            if (!bComOpen) return;

            //// Zappingの場合の実行確認            
            if (!msgZapping(func)) return;

            //// ログ表示
            msgFunction(func, addr);

            //// シリアル通信
            RecvData recvdata = execSerial(func, addr, (int)userControl1.numericWrite.Value);

            ////
            if (recvdata.data < 0)
            {
                StatusWriteLine("通信エラー");
                return;
            }

            //// ステータス表示
            userControl1.labelOTP.Text = msgStatus(recvdata.status);

            //// 画面表示
            userControl1.textBoxRead.Text = recvdata.data.ToString();
        }

        public void comFunction2(int func)
        {
            int addr = 1;

            //// COMポートの接続確認
            if (!bComOpen) return;

            //// Zappingの場合の実行確認            
            if (!msgZapping(func)) return;

            //// ログ表示
            msgFunction(func, addr);

            //// シリアル通信
            RecvData recvdata = execSerial(func, addr, (int)userControl2.numericWrite.Value);

            ////
            if (recvdata.data < 0)
            {
                StatusWriteLine("通信エラー");
                return;
            }

            //// ステータス表示
            userControl2.labelOTP.Text = msgStatus(recvdata.status);

            //// 画面表示
            userControl2.textBoxRead.Text = recvdata.data.ToString();
        }

        public void comFunction3(int func)
        {
            int addr = 2;

            //// COMポートの接続確認
            if (!bComOpen) return;

            //// Zappingの場合の実行確認            
            if (!msgZapping(func)) return;

            //// ログ表示
            msgFunction(func, addr);

            //// シリアル通信
            RecvData recvdata = execSerial(func, addr, (int)userControl3.numericWrite.Value);

            ////
            if (recvdata.data < 0)
            {
                StatusWriteLine("通信エラー");
                return;
            }

            //// ステータス表示
            userControl3.labelOTP.Text = msgStatus(recvdata.status);

            //// 画面表示
            userControl3.textBoxRead.Text = recvdata.data.ToString();
        }

        public void comFunction4(int func)
        {
            int addr = 3;

            //// COMポートの接続確認
            if (!bComOpen) return;

            //// Zappingの場合の実行確認            
            if (!msgZapping(func)) return;

            //// ログ表示
            msgFunction(func, addr);

            //// シリアル通信
            RecvData recvdata = execSerial(func, addr, (int)userControl4.numericWrite.Value);

            ////
            if (recvdata.data < 0)
            {
                StatusWriteLine("通信エラー");
                return;
            }

            //// ステータス表示
            userControl4.labelOTP.Text = msgStatus(recvdata.status);

            //// 画面表示
            userControl4.textBoxRead.Text = recvdata.data.ToString();
        }

        /// <summary>
        /// 
        /// </summary>

        public RecvData execSerial(int func, int addr, int value)
        {
            int data = 0;
            RecvData recvData = new RecvData();

            byte[] srcBuff = createPacket(func, addr, value).ToArray();
            byte[] dstBuff = new byte[defComMaxDataSize];

            ////
            comSerial.Send(srcBuff);
            Thread.Sleep(2000);
            int len = comSerial.Read(dstBuff);

            ////
            msgRecvData(dstBuff, len);

            ////
            if (!parsePacket(dstBuff, len))
            {
                recvData.data = -1;
                return recvData;
            }

            ////

            recvData.data = (Func.asc2int((int)dstBuff[3]) << 4) + Func.asc2int((int)dstBuff[4]);
            recvData.status = (Func.asc2int((int)dstBuff[5]) << 4) + Func.asc2int((int)dstBuff[6]);

            return recvData;
        }

        /// <summary>
        /// 
        /// </summary>

        public List<byte> createPacket(int func, int addr, int data)
        {
            List<byte> packet = new List<byte>();

            if(func != (int)UserControl1.FuncCode.None)
            {
                //// Header
                packet.Add((byte)ComSerial.AsciiCode.SOH);

                //// ファンクションコード
                packet.Add((byte)func);

                //// アドレス
                packet.Add((byte)Func.int2asc(addr));

                //// データ
                packet.Add((byte)Func.int2asc(data >> 4));
                packet.Add((byte)Func.int2asc(data % 16));

                ////// Checksum
                int sum = 0;
                for (int i = 0; i < packet.Count; i++) sum += (int)packet[i];
                int chksum = 256 - (sum % 256);

                packet.Add((byte)Func.int2asc(chksum >> 4));
                packet.Add((byte)Func.int2asc(chksum % 16));

                //// Footer
                packet.Add((byte)ComSerial.AsciiCode.EOT);
            }

            //// Debug
            msgSendData(packet);

            return packet;
        }

        /// <summary>
        /// 
        /// </summary>

        public bool parsePacket(byte[] dstBuff, int recvLen)
        {
            if (recvLen < 8) return false;

            if (dstBuff[0] != 0x01) return false;
            if (dstBuff[9] != 0x04) return false;

            //// Checksum
            int sum = 0;
            for (int i = 0; i <= 6; i++) sum += (int)dstBuff[i];
            int chksum = 256 - (sum % 256);
            int chksum_ref = (Func.asc2int(dstBuff[7]) << 4) | Func.asc2int(dstBuff[8]);

            if (chksum != chksum_ref) return false;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>

        public void msgFunction(int func, int type)
        {
            string msg = "[Function] ";

            if (type == 0) msg += userControl1.title.Text;
            else if (type == 1) msg += userControl2.title.Text;
            else if (type == 2) msg += userControl3.title.Text;
            else if (type == 3) msg += userControl4.title.Text;

            if (func == 0x12) msg += " 書き込み";
            else if (func == 0x13) msg += " 読み出し";
            else if (func == 0x14) msg += " プログラム";

            StatusWriteLine(msg);
        }

        public void msgSendData(List<byte> dstBuff)
        {
            string msg = "";

            StatusWriteLine("---- [Send]");
            for (int i = 0; i < dstBuff.Count; i++)
            {
                msg = "[send] (" + i + ")" + dstBuff[i].ToString("X2");
                StatusWriteLine(msg);
            }
        }

        public void msgRecvData(byte[] dstBuff, int len)
        {
            string msg = "";

            StatusWriteLine("---- [Recv]");
            for (int i = 0; i < len; i++)
            {
                msg = "[recv] (" + i + ")" + dstBuff[i].ToString("X2");
                StatusWriteLine(msg);
            }
        }

        public string msgStatus(int status)
        {
            string msg = "[OPT] ";

            int _status = (status & 0xC0);

            if (_status == 0x00) msg += "ready to program.";
            else if (_status == 0x80) msg += "fatal error.";
            else if (_status == 0xC0) msg += "programmed successfully.";
            else msg += "status error.";

            StatusWriteLine(msg);

            return msg;
        }

        public bool msgZapping(int func)
        {
            if (func == 0x14)
            {
                //メッセージボックスを表示する
                DialogResult result = MessageBox.Show("Zappingを実行しますか？", "実行の確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    //「はい」が選択された時
                    Console.WriteLine("「はい」が選択されました");
                    return true;
                }
                else if (result == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

         /// <summary>
        /// 実行/停止
        /// </summary>

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (!bComOpen)
            {
                execConnectCom();
            }

            //// 現在の時刻を取得
            timeStamp = DateTime.Now;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (bComOpen)
            {
                execConnectCom();
            }
        }

        /// <summary>
        /// 状態表示クリア
        /// </summary>
        public void StatusClear()
        {
            richTextBoxStatus.Text = "";
        }

        /// <summary>
        /// 状態表示（改行なし）
        /// </summary>
        /// <param name="data">表示データ</param>
        public void StatusWrite(string data)
        {
            richTextBoxStatus.Text += data;

            richTextBoxStatus.SelectionStart = richTextBoxStatus.TextLength;
            richTextBoxStatus.SelectionLength = 0;
            richTextBoxStatus.ScrollToCaret();
        }

        /// <summary>
        /// 状態表示（改行あり）
        /// </summary>
        /// <param name="line">表示データ</param>
        public void StatusWriteLine(string line)
        {
            richTextBoxStatus.Text += line + "\r\n";

            richTextBoxStatus.SelectionStart = richTextBoxStatus.TextLength;
            richTextBoxStatus.SelectionLength = 0;
            richTextBoxStatus.ScrollToCaret();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            StatusClear();
        }
    }
}
