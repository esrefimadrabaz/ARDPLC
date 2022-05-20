
namespace WindowsFormsApp1
{
    partial class SerialMenu
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
            this.label2 = new System.Windows.Forms.Label();
            this.FunctionBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.FormatLabel = new System.Windows.Forms.Label();
            this.FormatBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dLabel = new System.Windows.Forms.Label();
            this.dIndex = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Function";
            // 
            // FunctionBox
            // 
            this.FunctionBox.DisplayMember = "string";
            this.FunctionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FunctionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FunctionBox.FormattingEnabled = true;
            this.FunctionBox.Items.AddRange(new object[] {
            "begin",
            "end",
            "print",
            "read"});
            this.FunctionBox.Location = new System.Drawing.Point(193, 49);
            this.FunctionBox.Name = "FunctionBox";
            this.FunctionBox.Size = new System.Drawing.Size(121, 28);
            this.FunctionBox.TabIndex = 3;
            this.FunctionBox.SelectedIndexChanged += new System.EventHandler(this.FunctionBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(97, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Serial Menu";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Font = new System.Drawing.Font("Noto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ValueLabel.Location = new System.Drawing.Point(12, 90);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(59, 19);
            this.ValueLabel.TabIndex = 5;
            this.ValueLabel.Text = "Value";
            // 
            // FormatLabel
            // 
            this.FormatLabel.AutoSize = true;
            this.FormatLabel.Font = new System.Drawing.Font("Noto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormatLabel.Location = new System.Drawing.Point(12, 124);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(69, 19);
            this.FormatLabel.TabIndex = 7;
            this.FormatLabel.Text = "Format";
            // 
            // FormatBox
            // 
            this.FormatBox.DisplayMember = "string";
            this.FormatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormatBox.FormattingEnabled = true;
            this.FormatBox.Items.AddRange(new object[] {
            "DEC",
            "HEX",
            "OCT",
            "BIN"});
            this.FormatBox.Location = new System.Drawing.Point(193, 120);
            this.FormatBox.Name = "FormatBox";
            this.FormatBox.Size = new System.Drawing.Size(121, 28);
            this.FormatBox.TabIndex = 8;
            this.FormatBox.SelectedIndexChanged += new System.EventHandler(this.FormatBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(115, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 27);
            this.button1.TabIndex = 22;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dLabel
            // 
            this.dLabel.AutoSize = true;
            this.dLabel.Font = new System.Drawing.Font("Noto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dLabel.Location = new System.Drawing.Point(214, 90);
            this.dLabel.Name = "dLabel";
            this.dLabel.Size = new System.Drawing.Size(19, 19);
            this.dLabel.TabIndex = 23;
            this.dLabel.Text = "D";
            // 
            // dIndex
            // 
            this.dIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dIndex.Location = new System.Drawing.Point(239, 87);
            this.dIndex.Name = "dIndex";
            this.dIndex.Size = new System.Drawing.Size(75, 26);
            this.dIndex.TabIndex = 24;
            this.dIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dIndex.ValueChanged += new System.EventHandler(this.dIndex_ValueChanged);
            // 
            // SerialMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 195);
            this.Controls.Add(this.dIndex);
            this.Controls.Add(this.dLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FormatBox);
            this.Controls.Add(this.FormatLabel);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FunctionBox);
            this.Controls.Add(this.label2);
            this.Name = "SerialMenu";
            this.Text = "SerialMenu";
            ((System.ComponentModel.ISupportInitialize)(this.dIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FunctionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label FormatLabel;
        private System.Windows.Forms.ComboBox FormatBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label dLabel;
        private System.Windows.Forms.NumericUpDown dIndex;
    }
}