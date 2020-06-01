namespace RMU30
{
    partial class Form
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.buttonStop = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelUsb = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCom = new System.Windows.Forms.ComboBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControl4 = new RMU30.UserControl1();
            this.userControl3 = new RMU30.UserControl1();
            this.userControl2 = new RMU30.UserControl1();
            this.userControl1 = new RMU30.UserControl1();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStop.Location = new System.Drawing.Point(676, 18);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(67, 32);
            this.buttonStop.TabIndex = 41;
            this.buttonStop.Text = "切断";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Location = new System.Drawing.Point(0, 501);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(888, 43);
            this.panel4.TabIndex = 75;
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richTextBoxStatus.Location = new System.Drawing.Point(633, 84);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(239, 351);
            this.richTextBoxStatus.TabIndex = 82;
            this.richTextBoxStatus.Text = "";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(634, 441);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(238, 36);
            this.buttonClear.TabIndex = 83;
            this.buttonClear.Text = "ログ消去";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BackgroundImage = global::RMU30.Resource.Header2;
            this.panel3.Controls.Add(this.panelUsb);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.comboCom);
            this.panel3.Controls.Add(this.buttonRun);
            this.panel3.Location = new System.Drawing.Point(320, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(568, 59);
            this.panel3.TabIndex = 73;
            // 
            // panelUsb
            // 
            this.panelUsb.BackgroundImage = global::RMU30.Resource.menu_usb_off;
            this.panelUsb.Location = new System.Drawing.Point(12, 17);
            this.panelUsb.Name = "panelUsb";
            this.panelUsb.Size = new System.Drawing.Size(32, 32);
            this.panelUsb.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(47, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 73;
            this.label1.Text = "COMポート";
            // 
            // comboCom
            // 
            this.comboCom.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboCom.FormattingEnabled = true;
            this.comboCom.Location = new System.Drawing.Point(125, 19);
            this.comboCom.Name = "comboCom";
            this.comboCom.Size = new System.Drawing.Size(111, 28);
            this.comboCom.TabIndex = 72;
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRun.Location = new System.Drawing.Point(259, 17);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(91, 33);
            this.buttonRun.TabIndex = 28;
            this.buttonRun.Text = "接続";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BackgroundImage = global::RMU30.Resource.Header1;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 59);
            this.panel1.TabIndex = 72;
            // 
            // userControl4
            // 
            this.userControl4.Location = new System.Drawing.Point(0, 379);
            this.userControl4.Margin = new System.Windows.Forms.Padding(4);
            this.userControl4.Name = "userControl4";
            this.userControl4.Size = new System.Drawing.Size(627, 103);
            this.userControl4.TabIndex = 79;
            // 
            // userControl3
            // 
            this.userControl3.Location = new System.Drawing.Point(0, 276);
            this.userControl3.Margin = new System.Windows.Forms.Padding(4);
            this.userControl3.Name = "userControl3";
            this.userControl3.Size = new System.Drawing.Size(627, 103);
            this.userControl3.TabIndex = 78;
            // 
            // userControl2
            // 
            this.userControl2.Location = new System.Drawing.Point(0, 173);
            this.userControl2.Margin = new System.Windows.Forms.Padding(4);
            this.userControl2.Name = "userControl2";
            this.userControl2.Size = new System.Drawing.Size(626, 103);
            this.userControl2.TabIndex = 77;
            // 
            // userControl1
            // 
            this.userControl1.Location = new System.Drawing.Point(0, 69);
            this.userControl1.Margin = new System.Windows.Forms.Padding(4);
            this.userControl1.Name = "userControl1";
            this.userControl1.Size = new System.Drawing.Size(626, 103);
            this.userControl1.TabIndex = 76;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.userControl4);
            this.Controls.Add(this.userControl3);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.userControl2);
            this.Controls.Add(this.userControl1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(900, 580);
            this.MinimumSize = new System.Drawing.Size(900, 580);
            this.Name = "Form";
            this.Text = "RMU30";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelUsb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboCom;
        private System.Windows.Forms.Panel panel4;
        public UserControl1 userControl1;
        public UserControl1 userControl2;
        public UserControl1 userControl3;
        public UserControl1 userControl4;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Button buttonClear;
    }
}

