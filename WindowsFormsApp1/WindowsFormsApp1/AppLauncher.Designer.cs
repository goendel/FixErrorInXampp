namespace WindowsFormsApp1
{
    partial class AppLauncher
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
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnQuickFix = new System.Windows.Forms.Button();
            this.btnRepair = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.txtLabelNotif = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOFFLINE = new System.Windows.Forms.Label();
            this.txtIONLINE = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStartServer.Font = new System.Drawing.Font("Montserrat Alternates", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartServer.Location = new System.Drawing.Point(52, 151);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(246, 66);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnQuickFix
            // 
            this.btnQuickFix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnQuickFix.Font = new System.Drawing.Font("Montserrat Alternates", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickFix.ForeColor = System.Drawing.Color.White;
            this.btnQuickFix.Location = new System.Drawing.Point(52, 243);
            this.btnQuickFix.Name = "btnQuickFix";
            this.btnQuickFix.Size = new System.Drawing.Size(246, 68);
            this.btnQuickFix.TabIndex = 1;
            this.btnQuickFix.Text = "Quick Repair Server";
            this.btnQuickFix.UseVisualStyleBackColor = false;
            this.btnQuickFix.Click += new System.EventHandler(this.btnQuickFix_Click);
            // 
            // btnRepair
            // 
            this.btnRepair.BackColor = System.Drawing.Color.Red;
            this.btnRepair.Font = new System.Drawing.Font("Montserrat Alternates", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepair.ForeColor = System.Drawing.Color.White;
            this.btnRepair.Location = new System.Drawing.Point(315, 243);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(234, 66);
            this.btnRepair.TabIndex = 2;
            this.btnRepair.Text = "Deep Fix Server";
            this.btnRepair.UseVisualStyleBackColor = false;
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnStopServer.Font = new System.Drawing.Font("Montserrat Alternates", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopServer.Location = new System.Drawing.Point(315, 151);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(234, 68);
            this.btnStopServer.TabIndex = 3;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = false;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // txtLabelNotif
            // 
            this.txtLabelNotif.AutoSize = true;
            this.txtLabelNotif.Location = new System.Drawing.Point(170, 329);
            this.txtLabelNotif.MaximumSize = new System.Drawing.Size(600, 500);
            this.txtLabelNotif.Name = "txtLabelNotif";
            this.txtLabelNotif.Size = new System.Drawing.Size(0, 16);
            this.txtLabelNotif.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 14F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(235, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Status Server";
            // 
            // txtOFFLINE
            // 
            this.txtOFFLINE.AutoSize = true;
            this.txtOFFLINE.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOFFLINE.ForeColor = System.Drawing.Color.Red;
            this.txtOFFLINE.Location = new System.Drawing.Point(236, 70);
            this.txtOFFLINE.Name = "txtOFFLINE";
            this.txtOFFLINE.Size = new System.Drawing.Size(147, 48);
            this.txtOFFLINE.TabIndex = 6;
            this.txtOFFLINE.Text = "OFFLINE";
            // 
            // txtIONLINE
            // 
            this.txtIONLINE.AutoSize = true;
            this.txtIONLINE.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIONLINE.ForeColor = System.Drawing.Color.Green;
            this.txtIONLINE.Location = new System.Drawing.Point(239, 71);
            this.txtIONLINE.Name = "txtIONLINE";
            this.txtIONLINE.Size = new System.Drawing.Size(136, 48);
            this.txtIONLINE.TabIndex = 7;
            this.txtIONLINE.Text = "ONLINE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(267, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "v 1.0";
            // 
            // AppLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(602, 453);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIONLINE);
            this.Controls.Add(this.txtOFFLINE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLabelNotif);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnRepair);
            this.Controls.Add(this.btnQuickFix);
            this.Controls.Add(this.btnStartServer);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(620, 500);
            this.MinimumSize = new System.Drawing.Size(620, 500);
            this.Name = "AppLauncher";
            this.Text = "AppLauncher";
            this.Load += new System.EventHandler(this.AppLauncher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnQuickFix;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Label txtLabelNotif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtOFFLINE;
        private System.Windows.Forms.Label txtIONLINE;
        private System.Windows.Forms.Label label2;
    }
}