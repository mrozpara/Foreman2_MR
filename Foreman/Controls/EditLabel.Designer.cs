namespace Foreman
{
    partial class EditLabel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FontSize = new System.Windows.Forms.NumericUpDown();
            this.txtLabelText = new System.Windows.Forms.TextBox();
            this.cbIsAutoSize = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontSize)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.tableLayoutPanel1.Controls.Add(this.FontSize, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLabelText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbIsAutoSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FontSize
            // 
            this.FontSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.FontSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontSize.Location = new System.Drawing.Point(333, 3);
            this.FontSize.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.FontSize.Name = "FontSize";
            this.FontSize.Size = new System.Drawing.Size(114, 20);
            this.FontSize.TabIndex = 5;
            this.FontSize.ThousandsSeparator = true;
            this.FontSize.ValueChanged += new System.EventHandler(this.FontSize_ValueChanged);
            // 
            // txtLabelText
            // 
            this.txtLabelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLabelText.Location = new System.Drawing.Point(3, 3);
            this.txtLabelText.Name = "txtLabelText";
            this.txtLabelText.Size = new System.Drawing.Size(324, 20);
            this.txtLabelText.TabIndex = 0;
            this.txtLabelText.TextChanged += new System.EventHandler(this.txtLabelText_TextChanged);
            // 
            // cbIsAutoSize
            // 
            this.cbIsAutoSize.AutoSize = true;
            this.cbIsAutoSize.Location = new System.Drawing.Point(333, 29);
            this.cbIsAutoSize.Name = "cbIsAutoSize";
            this.cbIsAutoSize.Size = new System.Drawing.Size(68, 17);
            this.cbIsAutoSize.TabIndex = 6;
            this.cbIsAutoSize.Text = "AutoSize";
            this.cbIsAutoSize.UseVisualStyleBackColor = true;
            this.cbIsAutoSize.CheckedChanged += new System.EventHandler(this.cbIsAutoSize_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.txtWidth, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtHeight, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(324, 26);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(3, 3);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(109, 3);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 1;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // EditLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditLabel";
            this.Size = new System.Drawing.Size(450, 58);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontSize)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtLabelText;
        private System.Windows.Forms.NumericUpDown FontSize;
        private System.Windows.Forms.CheckBox cbIsAutoSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
    }
}
