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
            this.title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWrite)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWrite
            // 
            this.buttonWrite.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonWrite.Location = new System.Drawing.Point(367, 32);
            this.buttonWrite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(77, 44);
            this.buttonWrite.TabIndex = 0;
            this.buttonWrite.Text = "WRITE";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // title
            // 
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
            this.title.Location = new System.Drawing.Point(13, 9);
            this.title.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.title.Size = new System.Drawing.Size(665, 102);
            this.title.TabIndex = 1;
            this.title.TabStop = false;
            this.title.Text = "XXXXXX";
            // 
            // labelR
            // 
            this.labelR.Location = new System.Drawing.Point(235, 75);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(107, 20);
            this.labelR.TabIndex = 8;
            this.labelR.Text = "(データなし)";
            this.labelR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelW
            // 
            this.labelW.Location = new System.Drawing.Point(73, 75);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(100, 20);
            this.labelW.TabIndex = 7;
            this.labelW.Text = "XXXX";
            this.labelW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "READ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "WRITE";
            // 
            // textBoxRead
            // 
            this.textBoxRead.Enabled = false;
            this.textBoxRead.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxRead.Location = new System.Drawing.Point(244, 35);
            this.textBoxRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRead.Name = "textBoxRead";
            this.textBoxRead.Size = new System.Drawing.Size(92, 36);
            this.textBoxRead.TabIndex = 4;
            this.textBoxRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRead.TextChanged += new System.EventHandler(this.textBoxRead_TextChanged);
            // 
            // numericWrite
            // 
            this.numericWrite.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericWrite.Location = new System.Drawing.Point(79, 36);
            this.numericWrite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericWrite.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericWrite.Name = "numericWrite";
            this.numericWrite.Size = new System.Drawing.Size(93, 36);
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
            this.buttonProgram.Location = new System.Drawing.Point(541, 32);
            this.buttonProgram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonProgram.Name = "buttonProgram";
            this.buttonProgram.Size = new System.Drawing.Size(101, 44);
            this.buttonProgram.TabIndex = 2;
            this.buttonProgram.Text = "ZAPPING";
            this.buttonProgram.UseVisualStyleBackColor = false;
            this.buttonProgram.Click += new System.EventHandler(this.buttonProgram_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRead.Location = new System.Drawing.Point(456, 32);
            this.buttonRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(77, 44);
            this.buttonRead.TabIndex = 1;
            this.buttonRead.Text = "READ";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // labelOTP
            // 
            this.labelOTP.Location = new System.Drawing.Point(367, 76);
            this.labelOTP.Name = "labelOTP";
            this.labelOTP.Size = new System.Drawing.Size(275, 24);
            this.labelOTP.TabIndex = 9;
            this.labelOTP.Text = "(データなし)";
            this.labelOTP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.title);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(697, 124);
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
    }
}
