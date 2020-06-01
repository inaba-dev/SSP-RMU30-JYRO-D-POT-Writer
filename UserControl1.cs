using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMU30
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            numericUpDown_dec2hex();
            userControlBit.setWdata((int)numericWrite.Value);

            userControlBit.ChangeEvent += new UserControl2.EventHandler(chngeWdata);
        }

        public enum FuncCode : int
        {
            None = 0x11,
            Write = 0x12,  // 書き込み
            Read = 0x13,   // 読み出し
            Program = 0x14 // プログラム
        };

        /// <summary>
        /// イベントハンドラ
        /// </summary>
        
        private int _func = (int)FuncCode.None;

        ////イベントハンドラのデリゲートを定義
        public delegate void EventHandler(int func);

        //// イベントハンドラを定義
        public event EventHandler ProgressEvent;

        //// イベントを伝える関数を定義
        private void EventProgress(object sender, EventArgs e) { ProgressEvent(_func); }

        /// <summary>
        /// 
        /// </summary>

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            ProgressEvent((int)FuncCode.Write);
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            ProgressEvent((int)FuncCode.Read);
        }

        private void buttonProgram_Click(object sender, EventArgs e)
        {
            ProgressEvent((int)FuncCode.Program);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_dec2hex();
            userControlBit.setWdata((int)numericWrite.Value);
        }

        private void chngeWdata()
        {
            int val = userControlBit.getWdata();
            numericWrite.Value = val;
            this.labelW.Text = "(Hex : " + val.ToString("X2") + ")";
        }

        private void numericUpDown_dec2hex()
        {
            int val = (int)numericWrite.Value;
            this.labelW.Text = "(Hex : " + val.ToString("X2") + ")";
        }

        private void textBoxRead_TextChanged(object sender, EventArgs e)
        {
            int val = Int32.Parse(textBoxRead.Text);
            this.labelR.Text = "(Hex : " + val.ToString("X2") + ")";
            userControlBit.setRdata(val);
        }
    }
}
