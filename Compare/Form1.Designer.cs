namespace Compare
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_input1 = new System.Windows.Forms.TextBox();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_compare = new System.Windows.Forms.Button();
            this.tb_input2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // tb_input1
            // 
            this.tb_input1.AllowDrop = true;
            this.tb_input1.Location = new System.Drawing.Point(102, 40);
            this.tb_input1.Name = "tb_input1";
            this.tb_input1.Size = new System.Drawing.Size(223, 20);
            this.tb_input1.TabIndex = 1;
            this.tb_input1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.tb_input1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // tb_output
            // 
            this.tb_output.AllowDrop = true;
            this.tb_output.Location = new System.Drawing.Point(102, 117);
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(223, 20);
            this.tb_output.TabIndex = 3;
            this.tb_output.Text = "D:\\1.txt";
            this.tb_output.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.tb_output.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // btn_compare
            // 
            this.btn_compare.Location = new System.Drawing.Point(157, 168);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(75, 23);
            this.btn_compare.TabIndex = 4;
            this.btn_compare.Text = "比较";
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_input2
            // 
            this.tb_input2.AllowDrop = true;
            this.tb_input2.Location = new System.Drawing.Point(102, 79);
            this.tb_input2.Name = "tb_input2";
            this.tb_input2.Size = new System.Drawing.Size(223, 20);
            this.tb_input2.TabIndex = 6;
            this.tb_input2.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.tb_input2.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 202);
            this.Controls.Add(this.tb_input2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_compare);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_input1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_input1;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.TextBox tb_input2;
        private System.Windows.Forms.Label label3;
    }
}

