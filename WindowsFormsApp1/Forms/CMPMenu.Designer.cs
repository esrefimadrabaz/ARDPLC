namespace WindowsFormsApp1
{
    partial class CMPMenu
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TypeDef = new System.Windows.Forms.ComboBox();
            this.FirstDef = new System.Windows.Forms.ComboBox();
            this.FirstVal = new System.Windows.Forms.NumericUpDown();
            this.MiddleVal = new System.Windows.Forms.NumericUpDown();
            this.ResultVal = new System.Windows.Forms.NumericUpDown();
            this.LastVal = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.MiddleDef = new System.Windows.Forms.ComboBox();
            this.LastDef = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FirstVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiddleVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastVal)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.Font = new System.Drawing.Font("Noto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(106, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(62, 23);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "Type";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TypeDef
            // 
            this.TypeDef.DisplayMember = "string";
            this.TypeDef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeDef.FormattingEnabled = true;
            this.TypeDef.Items.AddRange(new object[] {
            "CMP",
            "ZONECMP"});
            this.TypeDef.Location = new System.Drawing.Point(174, 8);
            this.TypeDef.Name = "TypeDef";
            this.TypeDef.Size = new System.Drawing.Size(93, 21);
            this.TypeDef.TabIndex = 22;
            this.TypeDef.SelectedIndexChanged += new System.EventHandler(this.TypeDef_SelectedIndexChanged);
            // 
            // FirstDef
            // 
            this.FirstDef.DisplayMember = "string";
            this.FirstDef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirstDef.FormattingEnabled = true;
            this.FirstDef.Items.AddRange(new object[] {
            "K",
            "F",
            "L",
            "CNTR",
            "D"});
            this.FirstDef.Location = new System.Drawing.Point(9, 34);
            this.FirstDef.Name = "FirstDef";
            this.FirstDef.Size = new System.Drawing.Size(135, 21);
            this.FirstDef.TabIndex = 23;
            this.FirstDef.SelectedIndexChanged += new System.EventHandler(this.FirstDef_SelectedIndexChanged);
            // 
            // FirstVal
            // 
            this.FirstVal.Location = new System.Drawing.Point(203, 35);
            this.FirstVal.Name = "FirstVal";
            this.FirstVal.Size = new System.Drawing.Size(122, 20);
            this.FirstVal.TabIndex = 24;
            this.FirstVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstVal.ThousandsSeparator = true;
            this.FirstVal.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.FirstVal.ValueChanged += new System.EventHandler(this.FirstVal_ValueChanged);
            // 
            // MiddleVal
            // 
            this.MiddleVal.Location = new System.Drawing.Point(203, 62);
            this.MiddleVal.Name = "MiddleVal";
            this.MiddleVal.Size = new System.Drawing.Size(122, 20);
            this.MiddleVal.TabIndex = 26;
            this.MiddleVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiddleVal.ThousandsSeparator = true;
            this.MiddleVal.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MiddleVal.ValueChanged += new System.EventHandler(this.MiddleVal_ValueChanged);
            // 
            // ResultVal
            // 
            this.ResultVal.Font = new System.Drawing.Font("Noto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ResultVal.Location = new System.Drawing.Point(174, 139);
            this.ResultVal.Name = "ResultVal";
            this.ResultVal.Size = new System.Drawing.Size(93, 23);
            this.ResultVal.TabIndex = 28;
            this.ResultVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ResultVal.ThousandsSeparator = true;
            this.ResultVal.ValueChanged += new System.EventHandler(this.ResultVal_ValueChanged);
            // 
            // LastVal
            // 
            this.LastVal.Location = new System.Drawing.Point(203, 89);
            this.LastVal.Name = "LastVal";
            this.LastVal.Size = new System.Drawing.Size(122, 20);
            this.LastVal.TabIndex = 30;
            this.LastVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LastVal.ThousandsSeparator = true;
            this.LastVal.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LastVal.ValueChanged += new System.EventHandler(this.LastVal_ValueChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox2.Location = new System.Drawing.Point(144, 115);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(62, 20);
            this.textBox2.TabIndex = 31;
            this.textBox2.Text = "TO";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MiddleDef
            // 
            this.MiddleDef.DisplayMember = "string";
            this.MiddleDef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MiddleDef.FormattingEnabled = true;
            this.MiddleDef.Items.AddRange(new object[] {
            "K",
            "F",
            "L",
            "CNTR",
            "D"});
            this.MiddleDef.Location = new System.Drawing.Point(9, 62);
            this.MiddleDef.Name = "MiddleDef";
            this.MiddleDef.Size = new System.Drawing.Size(135, 21);
            this.MiddleDef.TabIndex = 32;
            this.MiddleDef.SelectedIndexChanged += new System.EventHandler(this.MiddleDef_SelectedIndexChanged);
            // 
            // LastDef
            // 
            this.LastDef.DisplayMember = "string";
            this.LastDef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LastDef.FormattingEnabled = true;
            this.LastDef.Items.AddRange(new object[] {
            "K",
            "F",
            "L",
            "CNTR",
            "D"});
            this.LastDef.Location = new System.Drawing.Point(9, 89);
            this.LastDef.Name = "LastDef";
            this.LastDef.Size = new System.Drawing.Size(135, 21);
            this.LastDef.TabIndex = 33;
            this.LastDef.SelectedIndexChanged += new System.EventHandler(this.LastDef_SelectedIndexChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox3.Font = new System.Drawing.Font("Noto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox3.Location = new System.Drawing.Point(106, 139);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(62, 23);
            this.textBox3.TabIndex = 34;
            this.textBox3.Text = "M";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(124, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 38);
            this.button1.TabIndex = 35;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // CMPMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 228);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.LastDef);
            this.Controls.Add(this.MiddleDef);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.LastVal);
            this.Controls.Add(this.ResultVal);
            this.Controls.Add(this.MiddleVal);
            this.Controls.Add(this.FirstVal);
            this.Controls.Add(this.FirstDef);
            this.Controls.Add(this.TypeDef);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CMPMenu";
            this.Text = "CMPMenu";
            ((System.ComponentModel.ISupportInitialize)(this.FirstVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiddleVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox TypeDef;
        private System.Windows.Forms.ComboBox FirstDef;
        private System.Windows.Forms.NumericUpDown FirstVal;
        private System.Windows.Forms.NumericUpDown MiddleVal;
        private System.Windows.Forms.NumericUpDown ResultVal;
        private System.Windows.Forms.NumericUpDown LastVal;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox MiddleDef;
        private System.Windows.Forms.ComboBox LastDef;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
    }
}