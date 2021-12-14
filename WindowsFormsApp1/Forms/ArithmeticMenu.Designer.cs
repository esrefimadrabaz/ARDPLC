namespace WindowsFormsApp1
{
    partial class ArithmeticMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ops = new System.Windows.Forms.ComboBox();
            this.PreVal = new System.Windows.Forms.NumericUpDown();
            this.Pre = new System.Windows.Forms.ComboBox();
            this.PostVal = new System.Windows.Forms.NumericUpDown();
            this.Post = new System.Windows.Forms.ComboBox();
            this.ResultVal = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PreVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultVal)).BeginInit();
            this.SuspendLayout();
            // 
            // Ops
            // 
            this.Ops.DisplayMember = "string";
            this.Ops.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ops.FormattingEnabled = true;
            this.Ops.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.Ops.Location = new System.Drawing.Point(146, 40);
            this.Ops.Name = "Ops";
            this.Ops.Size = new System.Drawing.Size(51, 21);
            this.Ops.TabIndex = 10;
            this.Ops.SelectedIndexChanged += new System.EventHandler(this.Ops_SelectedIndexChanged);
            // 
            // PreVal
            // 
            this.PreVal.Location = new System.Drawing.Point(189, 13);
            this.PreVal.Name = "PreVal";
            this.PreVal.Size = new System.Drawing.Size(122, 20);
            this.PreVal.TabIndex = 13;
            this.PreVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PreVal.ThousandsSeparator = true;
            this.PreVal.ValueChanged += new System.EventHandler(this.PreVal_ValueChanged);
            // 
            // Pre
            // 
            this.Pre.DisplayMember = "string";
            this.Pre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Pre.FormattingEnabled = true;
            this.Pre.Items.AddRange(new object[] {
            "K",
            "F",
            "L",
            "D"});
            this.Pre.Location = new System.Drawing.Point(12, 12);
            this.Pre.Name = "Pre";
            this.Pre.Size = new System.Drawing.Size(135, 21);
            this.Pre.TabIndex = 14;
            this.Pre.SelectedIndexChanged += new System.EventHandler(this.Pre_SelectedIndexChanged);
            // 
            // PostVal
            // 
            this.PostVal.Location = new System.Drawing.Point(189, 66);
            this.PostVal.Name = "PostVal";
            this.PostVal.Size = new System.Drawing.Size(122, 20);
            this.PostVal.TabIndex = 15;
            this.PostVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PostVal.ThousandsSeparator = true;
            this.PostVal.ValueChanged += new System.EventHandler(this.PostVal_ValueChanged);
            // 
            // Post
            // 
            this.Post.DisplayMember = "string";
            this.Post.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Post.FormattingEnabled = true;
            this.Post.Items.AddRange(new object[] {
            "K",
            "F",
            "L",
            "D"});
            this.Post.Location = new System.Drawing.Point(12, 66);
            this.Post.Name = "Post";
            this.Post.Size = new System.Drawing.Size(135, 21);
            this.Post.TabIndex = 16;
            this.Post.SelectedIndexChanged += new System.EventHandler(this.Post_SelectedIndexChanged);
            // 
            // ResultVal
            // 
            this.ResultVal.Location = new System.Drawing.Point(178, 100);
            this.ResultVal.Name = "ResultVal";
            this.ResultVal.Size = new System.Drawing.Size(63, 20);
            this.ResultVal.TabIndex = 18;
            this.ResultVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ResultVal.ThousandsSeparator = true;
            this.ResultVal.ValueChanged += new System.EventHandler(this.ResultVal_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(130, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 38);
            this.button1.TabIndex = 19;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.Location = new System.Drawing.Point(98, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "D";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ArithmeticMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 170);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResultVal);
            this.Controls.Add(this.Post);
            this.Controls.Add(this.PostVal);
            this.Controls.Add(this.Pre);
            this.Controls.Add(this.PreVal);
            this.Controls.Add(this.Ops);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ArithmeticMenu";
            this.Text = "ArithmeticMenu";
            ((System.ComponentModel.ISupportInitialize)(this.PreVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Ops;
        private System.Windows.Forms.NumericUpDown PreVal;
        private System.Windows.Forms.ComboBox Pre;
        private System.Windows.Forms.NumericUpDown PostVal;
        private System.Windows.Forms.ComboBox Post;
        private System.Windows.Forms.NumericUpDown ResultVal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}