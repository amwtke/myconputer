namespace Computer
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox_expression = new System.Windows.Forms.RichTextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_consumeTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Bt_AddConsts = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_constSave = new System.Windows.Forms.Button();
            this.tb_constValue = new System.Windows.Forms.TextBox();
            this.tx_constName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_const = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bt_saveUfunc = new System.Windows.Forms.Button();
            this.bt_AddUfunc = new System.Windows.Forms.Button();
            this.richTextBox_ufunc = new System.Windows.Forms.RichTextBox();
            this.listBox_ufuncs = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_expression
            // 
            this.richTextBox_expression.Location = new System.Drawing.Point(12, 12);
            this.richTextBox_expression.Name = "richTextBox_expression";
            this.richTextBox_expression.Size = new System.Drawing.Size(586, 210);
            this.richTextBox_expression.TabIndex = 0;
            this.richTextBox_expression.Text = "";
            this.richTextBox_expression.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyUp_RichTestBox);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 228);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(587, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK(F5)";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(95, 279);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(131, 21);
            this.textBox_result.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "=";
            // 
            // label_consumeTime
            // 
            this.label_consumeTime.AutoSize = true;
            this.label_consumeTime.Location = new System.Drawing.Point(29, 22);
            this.label_consumeTime.Name = "label_consumeTime";
            this.label_consumeTime.Size = new System.Drawing.Size(0, 12);
            this.label_consumeTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // Bt_AddConsts
            // 
            this.Bt_AddConsts.Location = new System.Drawing.Point(20, 67);
            this.Bt_AddConsts.Name = "Bt_AddConsts";
            this.Bt_AddConsts.Size = new System.Drawing.Size(75, 23);
            this.Bt_AddConsts.TabIndex = 6;
            this.Bt_AddConsts.Text = "添加";
            this.Bt_AddConsts.UseVisualStyleBackColor = true;
            this.Bt_AddConsts.Click += new System.EventHandler(this.Bt_AddConsts_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.bt_constSave);
            this.groupBox1.Controls.Add(this.tb_constValue);
            this.groupBox1.Controls.Add(this.tx_constName);
            this.groupBox1.Controls.Add(this.Bt_AddConsts);
            this.groupBox1.Location = new System.Drawing.Point(629, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 108);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加常数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "数值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "名称";
            // 
            // bt_constSave
            // 
            this.bt_constSave.Location = new System.Drawing.Point(140, 67);
            this.bt_constSave.Name = "bt_constSave";
            this.bt_constSave.Size = new System.Drawing.Size(75, 23);
            this.bt_constSave.TabIndex = 9;
            this.bt_constSave.Text = "存盘";
            this.bt_constSave.UseVisualStyleBackColor = true;
            this.bt_constSave.Click += new System.EventHandler(this.bt_constSave_Click);
            // 
            // tb_constValue
            // 
            this.tb_constValue.Location = new System.Drawing.Point(123, 27);
            this.tb_constValue.Name = "tb_constValue";
            this.tb_constValue.Size = new System.Drawing.Size(154, 21);
            this.tb_constValue.TabIndex = 8;
            // 
            // tx_constName
            // 
            this.tx_constName.Location = new System.Drawing.Point(8, 27);
            this.tx_constName.Name = "tx_constName";
            this.tx_constName.Size = new System.Drawing.Size(100, 21);
            this.tx_constName.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label_consumeTime);
            this.groupBox2.Location = new System.Drawing.Point(260, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计信息";
            // 
            // listBox_const
            // 
            this.listBox_const.FormattingEnabled = true;
            this.listBox_const.ItemHeight = 12;
            this.listBox_const.Location = new System.Drawing.Point(20, 20);
            this.listBox_const.Name = "listBox_const";
            this.listBox_const.Size = new System.Drawing.Size(257, 172);
            this.listBox_const.TabIndex = 9;
            this.listBox_const.DoubleClick += new System.EventHandler(this.listboxconst_doubleclick);
            this.listBox_const.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListBox_keyPress);
            this.listBox_const.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListBoxConst_keyup);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox_const);
            this.groupBox3.Location = new System.Drawing.Point(629, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 210);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "常量";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.listBox_ufuncs);
            this.groupBox4.Location = new System.Drawing.Point(12, 410);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(900, 201);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "自定义函数";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bt_saveUfunc);
            this.groupBox5.Controls.Add(this.bt_AddUfunc);
            this.groupBox5.Controls.Add(this.richTextBox_ufunc);
            this.groupBox5.Location = new System.Drawing.Point(480, 32);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(414, 163);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "添加自定义函数";
            // 
            // bt_saveUfunc
            // 
            this.bt_saveUfunc.Location = new System.Drawing.Point(120, 124);
            this.bt_saveUfunc.Name = "bt_saveUfunc";
            this.bt_saveUfunc.Size = new System.Drawing.Size(75, 23);
            this.bt_saveUfunc.TabIndex = 2;
            this.bt_saveUfunc.Text = "存盘";
            this.bt_saveUfunc.UseVisualStyleBackColor = true;
            this.bt_saveUfunc.Click += new System.EventHandler(this.bt_saveUfunc_Click);
            // 
            // bt_AddUfunc
            // 
            this.bt_AddUfunc.Location = new System.Drawing.Point(17, 124);
            this.bt_AddUfunc.Name = "bt_AddUfunc";
            this.bt_AddUfunc.Size = new System.Drawing.Size(75, 23);
            this.bt_AddUfunc.TabIndex = 1;
            this.bt_AddUfunc.Text = "添加";
            this.bt_AddUfunc.UseVisualStyleBackColor = true;
            this.bt_AddUfunc.Click += new System.EventHandler(this.bt_AddUfunc_Click);
            // 
            // richTextBox_ufunc
            // 
            this.richTextBox_ufunc.Location = new System.Drawing.Point(17, 21);
            this.richTextBox_ufunc.Name = "richTextBox_ufunc";
            this.richTextBox_ufunc.Size = new System.Drawing.Size(379, 96);
            this.richTextBox_ufunc.TabIndex = 0;
            this.richTextBox_ufunc.Text = "";
            // 
            // listBox_ufuncs
            // 
            this.listBox_ufuncs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_ufuncs.FormattingEnabled = true;
            this.listBox_ufuncs.ItemHeight = 12;
            this.listBox_ufuncs.Location = new System.Drawing.Point(16, 32);
            this.listBox_ufuncs.Name = "listBox_ufuncs";
            this.listBox_ufuncs.Size = new System.Drawing.Size(448, 148);
            this.listBox_ufuncs.Sorted = true;
            this.listBox_ufuncs.TabIndex = 0;
            this.listBox_ufuncs.DoubleClick += new System.EventHandler(this.listbox_ufuncDoubleClick);
            this.listBox_ufuncs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox_ufuncs_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 637);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.richTextBox_expression);
            this.Name = "Form1";
            this.Text = "Compute";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_expression;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_consumeTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Bt_AddConsts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_constValue;
        private System.Windows.Forms.TextBox tx_constName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_constSave;
        private System.Windows.Forms.ListBox listBox_const;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox_ufuncs;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox_ufunc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_AddUfunc;
        private System.Windows.Forms.Button bt_saveUfunc;
    }
}

