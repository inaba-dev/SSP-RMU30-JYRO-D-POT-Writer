using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;     //IPEndPointクラス
using System.Net.Sockets; //TCPListener、TCPClientクラス
using System.IO;
using System.Threading;
using System.IO.Ports;

namespace RMU30
{
    class ComSerial
    {
        #region　インスタンス

        private SerialPort serial = new SerialPort();
        private bool bOpen = false;

        public enum AsciiCode : int
        {
            SOH = 0x01, // ヘッダ開始
            EOT = 0x04  // 転送終了
        };

        #endregion

        #region メソッド

        public bool Open(string portName, int baudRate, int readSize)
        {
            serial.PortName = portName;
            serial.BaudRate = baudRate;
            serial.Parity = Parity.None;
            serial.DataBits = 8;
            serial.StopBits = StopBits.One;
            serial.Handshake = Handshake.None;
            serial.ReadBufferSize = readSize;
            serial.ReadTimeout =2500;

            try
            {
                serial.Open();
                bOpen = true;
                return true;
            }
            catch (Exception)
            {
                bOpen = false;
                return false;
            }

        }

        public void Close()
        {
            if (bOpen)
            {
                serial.Close();
                bOpen = false;
                Console.WriteLine("comDevice.Close");
            }
        }

        public void Clear()
        {
            byte[] dummybuf = new byte[serial.ReadBufferSize];

            serial.DiscardInBuffer();

            //念のためDummyReadして受信を空にする
            for (int i = 0; i < 20; i++)
            {
                Read(dummybuf);
                Thread.Sleep(1);
            }
        }

        public void Send(byte[] srcBuff)
        {
            if (!bOpen) return;

            serial.Write(srcBuff, 0, srcBuff.Length);

            //// for Debug
            Console.WriteLine("[send] {0}byte -----------------", srcBuff.Length);
            for (int i = 0; i < srcBuff.Length; i++) Console.WriteLine("send[{0}] : {1:X2}", i, srcBuff[i]);
        }

        public int Read(byte[] dstBuff)
        {
            if (!bOpen) return 0;

            try
            {
                int resLen;

                resLen = serial.Read(dstBuff, 0, dstBuff.Length);

                //// for Debug
                Console.WriteLine("[recv] {0}byte -----------------", resLen);
                for (int i = 0; i < resLen; i++) Console.WriteLine("recv[{0}] : {1:X2}", i, dstBuff[i]);

                return resLen;
            }
            catch (Exception)
            {
                return 0;
            }
        }

#endregion
    }
}
