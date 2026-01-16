namespace srv
{
    partial class Form1
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
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnCloseConn = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBlenderpath = new System.Windows.Forms.TextBox();
            this.checkHeadless = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(312, 393);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(238, 45);
            this.btnEnable.TabIndex = 0;
            this.btnEnable.Text = "Start Listener";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnCloseConn
            // 
            this.btnCloseConn.Location = new System.Drawing.Point(556, 393);
            this.btnCloseConn.Name = "btnCloseConn";
            this.btnCloseConn.Size = new System.Drawing.Size(232, 45);
            this.btnCloseConn.TabIndex = 1;
            this.btnCloseConn.Text = "Close Listener";
            this.btnCloseConn.UseVisualStyleBackColor = true;
            this.btnCloseConn.Click += new System.EventHandler(this.btnCloseConn_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(447, 99);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(323, 20);
            this.txtPort.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(443, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hosting Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(443, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Blender Executable Path";
            // 
            // txtBlenderpath
            // 
            this.txtBlenderpath.Location = new System.Drawing.Point(447, 145);
            this.txtBlenderpath.Name = "txtBlenderpath";
            this.txtBlenderpath.Size = new System.Drawing.Size(323, 20);
            this.txtBlenderpath.TabIndex = 4;
            // 
            // checkHeadless
            // 
            this.checkHeadless.AutoSize = true;
            this.checkHeadless.Checked = true;
            this.checkHeadless.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkHeadless.Location = new System.Drawing.Point(447, 171);
            this.checkHeadless.Name = "checkHeadless";
            this.checkHeadless.Size = new System.Drawing.Size(173, 17);
            this.checkHeadless.TabIndex = 6;
            this.checkHeadless.Text = "Run Blender in Headless Mode";
            this.checkHeadless.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkHeadless);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBlenderpath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnCloseConn);
            this.Controls.Add(this.btnEnable);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnCloseConn;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBlenderpath;
        private System.Windows.Forms.CheckBox checkHeadless;
    }
}

