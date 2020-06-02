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
    public partial class UserControl2 : UserControl
    {
        private CheckBox checkBoxW0 = new CheckBox();
        private CheckBox checkBoxW1 = new CheckBox();
        private CheckBox checkBoxW2 = new CheckBox();
        private CheckBox checkBoxW3 = new CheckBox();
        private CheckBox checkBoxW4 = new CheckBox();
        private CheckBox checkBoxW5 = new CheckBox();
        private CheckBox checkBoxW6 = new CheckBox();
        private CheckBox checkBoxW7 = new CheckBox();

        private CheckBox checkBoxR0 = new CheckBox();
        private CheckBox checkBoxR1 = new CheckBox();
        private CheckBox checkBoxR2 = new CheckBox();
        private CheckBox checkBoxR3 = new CheckBox();
        private CheckBox checkBoxR4 = new CheckBox();
        private CheckBox checkBoxR5 = new CheckBox();
        private CheckBox checkBoxR6 = new CheckBox();
        private CheckBox checkBoxR7 = new CheckBox();

        public UserControl2()
        {
            InitializeComponent();

            setupCheckBoxW(checkBoxW7, 0, 0);
            setupCheckBoxW(checkBoxW6, 1, 0);
            setupCheckBoxW(checkBoxW5, 2, 0);
            setupCheckBoxW(checkBoxW4, 3, 0);
            setupCheckBoxW(checkBoxW3, 4, 0);
            setupCheckBoxW(checkBoxW2, 5, 0);
            setupCheckBoxW(checkBoxW1, 6, 0);
            setupCheckBoxW(checkBoxW0, 7, 0);

            setupCheckBoxR(checkBoxR7, 0, 1);
            setupCheckBoxR(checkBoxR6, 1, 1);
            setupCheckBoxR(checkBoxR5, 2, 1);
            setupCheckBoxR(checkBoxR4, 3, 1);
            setupCheckBoxR(checkBoxR3, 4, 1);
            setupCheckBoxR(checkBoxR2, 5, 1);
            setupCheckBoxR(checkBoxR1, 6, 1);
            setupCheckBoxR(checkBoxR0, 7, 1);
        }

        private const int baseX = 10;
        private const int baseY = 10;

        private void setupCheckBoxW(CheckBox chk, int x, int y)
        {
            chk.Location = new System.Drawing.Point(baseX + 17 * x, baseY + 15 * y);
            chk.Size = new System.Drawing.Size(16, 15);
            chk.TabIndex = 0;
            chk.CheckedChanged += new System.EventHandler(valueChange);
            this.Controls.Add(chk);
        }

        private void setupCheckBoxR(CheckBox chk, int x, int y)
        {
            chk.Location = new System.Drawing.Point(baseX + 17 * x, baseY + 15 * y);
            chk.Size = new System.Drawing.Size(16, 15);
            chk.Enabled = false;
            chk.TabIndex = 0;
            this.Controls.Add(chk);
        }

        private void valueChange(object sender, EventArgs e)
        {
            try
            {
                ChangeEvent();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>

        public int getWdata()
        {
            int data = 0;
            data |= (checkBoxW0.Checked) ? 0x01 : 0x00;
            data |= (checkBoxW1.Checked) ? 0x02 : 0x00;
            data |= (checkBoxW2.Checked) ? 0x04 : 0x00;
            data |= (checkBoxW3.Checked) ? 0x08 : 0x00;
            data |= (checkBoxW4.Checked) ? 0x10 : 0x00;
            data |= (checkBoxW5.Checked) ? 0x20 : 0x00;
            data |= (checkBoxW6.Checked) ? 0x40 : 0x00;
            data |= (checkBoxW7.Checked) ? 0x80 : 0x00;
            return data;
        }

        public void setWdata(int data)
        {
            checkBoxW0.Checked = (((data >> 0) & 0x01) == 0x01) ? true : false;
            checkBoxW1.Checked = (((data >> 1) & 0x01) == 0x01) ? true : false;
            checkBoxW2.Checked = (((data >> 2) & 0x01) == 0x01) ? true : false;
            checkBoxW3.Checked = (((data >> 3) & 0x01) == 0x01) ? true : false;
            checkBoxW4.Checked = (((data >> 4) & 0x01) == 0x01) ? true : false;
            checkBoxW5.Checked = (((data >> 5) & 0x01) == 0x01) ? true : false;
            checkBoxW6.Checked = (((data >> 6) & 0x01) == 0x01) ? true : false;
            checkBoxW7.Checked = (((data >> 7) & 0x01) == 0x01) ? true : false;
        }

        public void setRdata(int data)
        {
            checkBoxR0.Checked = (((data >> 0) & 0x01) == 0x01) ? true : false;
            checkBoxR1.Checked = (((data >> 1) & 0x01) == 0x01) ? true : false;
            checkBoxR2.Checked = (((data >> 2) & 0x01) == 0x01) ? true : false;
            checkBoxR3.Checked = (((data >> 3) & 0x01) == 0x01) ? true : false;
            checkBoxR4.Checked = (((data >> 4) & 0x01) == 0x01) ? true : false;
            checkBoxR5.Checked = (((data >> 5) & 0x01) == 0x01) ? true : false;
            checkBoxR6.Checked = (((data >> 6) & 0x01) == 0x01) ? true : false;
            checkBoxR7.Checked = (((data >> 7) & 0x01) == 0x01) ? true : false;
        }

        /// <summary>
        /// イベントハンドラ
        /// </summary>

        ////イベントハンドラのデリゲートを定義
        public delegate void EventHandler();

        //// イベントハンドラを定義
        public event EventHandler ChangeEvent;

        //// イベントを伝える関数を定義
        private void ChangeProgress(object sender, EventArgs e) { ChangeEvent(); }
    }
}
