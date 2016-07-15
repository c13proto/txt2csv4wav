namespace txt2csv4wav
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.button保存 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton16bit = new System.Windows.Forms.RadioButton();
            this.radioButton8bit = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxloop = new System.Windows.Forms.TextBox();
            this.textbox = new System.Windows.Forms.Label();
            this.labeldebug = new System.Windows.Forms.Label();
            this.button変換開始 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button保存
            // 
            this.button保存.Location = new System.Drawing.Point(13, 13);
            this.button保存.Name = "button保存";
            this.button保存.Size = new System.Drawing.Size(75, 23);
            this.button保存.TabIndex = 0;
            this.button保存.Text = "開く";
            this.button保存.UseVisualStyleBackColor = true;
            this.button保存.Click += new System.EventHandler(this.Click開く);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton16bit);
            this.panel1.Controls.Add(this.radioButton8bit);
            this.panel1.Location = new System.Drawing.Point(13, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 49);
            this.panel1.TabIndex = 1;
            // 
            // radioButton16bit
            // 
            this.radioButton16bit.AutoSize = true;
            this.radioButton16bit.Checked = true;
            this.radioButton16bit.Location = new System.Drawing.Point(4, 27);
            this.radioButton16bit.Name = "radioButton16bit";
            this.radioButton16bit.Size = new System.Drawing.Size(48, 16);
            this.radioButton16bit.TabIndex = 1;
            this.radioButton16bit.TabStop = true;
            this.radioButton16bit.Text = "16bit";
            this.radioButton16bit.UseVisualStyleBackColor = true;
            // 
            // radioButton8bit
            // 
            this.radioButton8bit.AutoSize = true;
            this.radioButton8bit.Location = new System.Drawing.Point(4, 4);
            this.radioButton8bit.Name = "radioButton8bit";
            this.radioButton8bit.Size = new System.Drawing.Size(42, 16);
            this.radioButton8bit.TabIndex = 0;
            this.radioButton8bit.Text = "8bit";
            this.radioButton8bit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Click保存);
            // 
            // textBoxloop
            // 
            this.textBoxloop.Location = new System.Drawing.Point(52, 97);
            this.textBoxloop.Name = "textBoxloop";
            this.textBoxloop.Size = new System.Drawing.Size(35, 19);
            this.textBoxloop.TabIndex = 3;
            this.textBoxloop.Text = "100";
            // 
            // textbox
            // 
            this.textbox.AutoSize = true;
            this.textbox.Location = new System.Drawing.Point(15, 100);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(26, 12);
            this.textbox.TabIndex = 4;
            this.textbox.Text = "loop";
            // 
            // labeldebug
            // 
            this.labeldebug.AutoSize = true;
            this.labeldebug.Location = new System.Drawing.Point(94, 13);
            this.labeldebug.Name = "labeldebug";
            this.labeldebug.Size = new System.Drawing.Size(35, 12);
            this.labeldebug.TabIndex = 5;
            this.labeldebug.Text = "debug";
            // 
            // button変換開始
            // 
            this.button変換開始.Location = new System.Drawing.Point(13, 122);
            this.button変換開始.Name = "button変換開始";
            this.button変換開始.Size = new System.Drawing.Size(75, 23);
            this.button変換開始.TabIndex = 6;
            this.button変換開始.Text = "変換開始";
            this.button変換開始.UseVisualStyleBackColor = true;
            this.button変換開始.Click += new System.EventHandler(this.Click変換開始);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 181);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(75, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 237);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button変換開始);
            this.Controls.Add(this.labeldebug);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.textBoxloop);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button保存);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button保存;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton16bit;
        private System.Windows.Forms.RadioButton radioButton8bit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxloop;
        private System.Windows.Forms.Label textbox;
        private System.Windows.Forms.Label labeldebug;
        private System.Windows.Forms.Button button変換開始;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

