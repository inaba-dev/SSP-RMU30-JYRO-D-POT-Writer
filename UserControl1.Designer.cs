namespace RMU30
{
    partial class UserControl1
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonWrite = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.GroupBox();
            this.labelR = new System.Windows.Forms.Label();
            this.labelW = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRead = new System.Windows.Forms.TextBox();
            this.numericWrite = new System.Windows.Forms.NumericUpDown();
            this.buttonProgram = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.labelOTP = new System.Windows.Forms.Label();
            this.checkOWBit = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userControlBit = new RMU30.UserControl2();
            this.title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWrite)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWrite
            // 
            this.buttonWrite.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonWrite.Location = new System.Drawing.Point(386, 33);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(58, 35);
            this.buttonWrite.TabIndex = 0;
            this.buttonWrite.Text = "WRITE";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // title
            // 
            this.title.Controls.Add(this.label4);
            this.title.Controls.Add(this.label3);
            this.title.Controls.Add(this.checkOWBit);
            this.title.Controls.Add(this.userControlBit);
            this.title.Controls.Add(this.labelR);
            this.title.Controls.Add(this.labelW);
            this.title.Controls.Add(this.label2);
            this.title.Controls.Add(this.label1);
            this.title.Controls.Add(this.textBoxRead);
            this.title.Controls.Add(this.numericWrite);
            this.title.Controls.Add(this.buttonProgram);
            this.title.Controls.Add(this.buttonRead);
            this.title.Controls.Add(this.buttonWrite);
            this.title.Controls.Add(this.labelOTP);
            this.title.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.title.Location = new System.Drawing.Point(10, 7);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(603, 92);
            this.title.TabIndex = 1;
            this.title.TabStop = false;
            this.title.Text = "XXXXXX";
            // 
            // labelR
            // 
            this.labelR.Location = new System.Drawing.Point(93, 71);
            this.labelR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(80, 16);
            this.labelR.TabIndex = 8;
            this.labelR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelW
            // 
            this.labelW.Location = new System.Drawing.Point(14, 72);
            this.labelW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(75, 16);
            this.labelW.TabIndex = 7;
            this.labelW.Text = "XXXX";
            this.labelW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "READ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "WRITE";
            // 
            // textBoxRead
            // 
            this.textBoxRead.Enabled = false;
            this.textBoxRead.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxRead.Location = new System.Drawing.Point(102, 39);
            this.textBoxRead.Name = "textBoxRead";
            this.textBoxRead.Size = new System.Drawing.Size(70, 30);
            this.textBoxRead.TabIndex = 4;
            this.textBoxRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRead.TextChanged += new System.EventHandler(this.textBoxRead_TextChanged);
            // 
            // numericWrite
            // 
            this.numericWrite.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericWrite.Location = new System.Drawing.Point(17, 39);
            this.numericWrite.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericWrite.Name = "numericWrite";
            this.numericWrite.Size = new System.Drawing.Size(70, 30);
            this.numericWrite.TabIndex = 3;
            this.numericWrite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericWrite.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericWrite.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonProgram
            // 
            this.buttonProgram.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonProgram.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonProgram.Location = new System.Drawing.Point(513, 33);
            this.buttonProgram.Name = "buttonProgram";
            this.buttonProgram.Size = new System.Drawing.Size(76, 35);
            this.buttonProgram.TabIndex = 2;
            this.buttonProgram.Text = "ZAPPING";
            this.buttonProgram.UseVisualStyleBackColor = false;
            this.buttonProgram.Click += new System.EventHandler(this.buttonProgram_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRead.Location = new System.Drawing.Point(451, 33);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(58, 35);
            this.buttonRead.TabIndex = 1;
            this.buttonRead.Text = "READ";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // labelOTP
            // 
            this.labelOTP.Location = new System.Drawing.Point(382, 69);
            this.labelOTP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOTP.Name = "labelOTP";
            this.labelOTP.Size = new System.Drawing.Size(206, 19);
            this.labelOTP.TabIndex = 9;
            this.labelOTP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkOWBit
            // 
            this.checkOWBit.AutoSize = true;
            this.checkOWBit.Location = new System.Drawing.Point(354, 37);
            this.checkOWBit.Name = "checkOWBit";
            this.checkOWBit.Size = new System.Drawing.Size(15, 14);
            this.checkOWBit.TabIndex = 11;
            this.checkOWBit.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(182, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "7   6   5   4   3   2   1   0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(345, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "OW";
            // 
            // userControlBit
            // 
            this.userControlBit.Location = new System.Drawing.Point(173, 18);
            this.userControlBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlBit.Name = "userControlBit";
            this.userControlBit.Size = new System.Drawing.Size(168, 62);
            this.userControlBit.TabIndex = 10;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.title);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(627, 99);
            this.title.ResumeLayout(false);
            this.title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWrite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonProgram;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelW;
        public System.Windows.Forms.TextBox textBoxRead;
        public System.Windows.Forms.GroupBox title;
        public System.Windows.Forms.NumericUpDown numericWrite;
        public System.Windows.Forms.Label labelOTP;
        private UserControl2 userControlBit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox checkOWBit;
    }
}
