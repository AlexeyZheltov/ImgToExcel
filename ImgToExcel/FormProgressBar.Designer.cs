namespace ImgToExcel
{
    partial class FormProgressBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgressBar));
            this.LabelTimeLost = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelNameTask = new System.Windows.Forms.Label();
            this.LabelNameProcess = new System.Windows.Forms.Label();
            this.btnCancelBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIndicator = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelTimeLost
            // 
            this.LabelTimeLost.Location = new System.Drawing.Point(576, 33);
            this.LabelTimeLost.Margin = new System.Windows.Forms.Padding(0);
            this.LabelTimeLost.Name = "LabelTimeLost";
            this.LabelTimeLost.Size = new System.Drawing.Size(60, 18);
            this.LabelTimeLost.TabIndex = 12;
            this.LabelTimeLost.Text = "-";
            this.LabelTimeLost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(515, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Осталось:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelNameTask
            // 
            this.LabelNameTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNameTask.Location = new System.Drawing.Point(9, 32);
            this.LabelNameTask.Margin = new System.Windows.Forms.Padding(0);
            this.LabelNameTask.Name = "LabelNameTask";
            this.LabelNameTask.Size = new System.Drawing.Size(506, 18);
            this.LabelNameTask.TabIndex = 9;
            this.LabelNameTask.Text = "Выполняемая задача";
            // 
            // LabelNameProcess
            // 
            this.LabelNameProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNameProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelNameProcess.Location = new System.Drawing.Point(9, 9);
            this.LabelNameProcess.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LabelNameProcess.Name = "LabelNameProcess";
            this.LabelNameProcess.Size = new System.Drawing.Size(592, 23);
            this.LabelNameProcess.TabIndex = 8;
            this.LabelNameProcess.Text = "Описание процесса";
            // 
            // btnCancelBox
            // 
            this.btnCancelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelBox.ErrorImage = null;
            this.btnCancelBox.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelBox.Image")));
            this.btnCancelBox.Location = new System.Drawing.Point(613, 1);
            this.btnCancelBox.Name = "btnCancelBox";
            this.btnCancelBox.Size = new System.Drawing.Size(26, 25);
            this.btnCancelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancelBox.TabIndex = 14;
            this.btnCancelBox.TabStop = false;
            this.btnCancelBox.Click += new System.EventHandler(this.CancelBox_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 23);
            this.label1.TabIndex = 15;
            // 
            // lblIndicator
            // 
            this.lblIndicator.BackColor = System.Drawing.Color.LimeGreen;
            this.lblIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIndicator.ForeColor = System.Drawing.Color.White;
            this.lblIndicator.Location = new System.Drawing.Point(12, 51);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Padding = new System.Windows.Forms.Padding(4);
            this.lblIndicator.Size = new System.Drawing.Size(616, 23);
            this.lblIndicator.TabIndex = 16;
            this.lblIndicator.Text = "0%";
            this.lblIndicator.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 83);
            this.panel1.TabIndex = 17;
            // 
            // FormProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 83);
            this.Controls.Add(this.lblIndicator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelBox);
            this.Controls.Add(this.LabelTimeLost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LabelNameTask);
            this.Controls.Add(this.LabelNameProcess);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProgressBar";
            this.ShowIcon = false;
            this.Text = "FormProgressBar";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProgressBar_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelTimeLost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelNameTask;
        private System.Windows.Forms.Label LabelNameProcess;
        private System.Windows.Forms.PictureBox btnCancelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIndicator;
        private System.Windows.Forms.Panel panel1;
    }
}