namespace Fixtures
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
            this.metTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metBtnAddTeam = new MetroFramework.Controls.MetroButton();
            this.metroAddTab = new MetroFramework.Controls.MetroTabPage();
            this.metBtnCalc = new MetroFramework.Controls.MetroButton();
            this.metBtnQuit = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metTabControl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metTabControl
            // 
            this.metTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metTabControl.Controls.Add(this.metroTabPage1);
            this.metTabControl.Controls.Add(this.metroAddTab);
            this.metTabControl.Location = new System.Drawing.Point(24, 64);
            this.metTabControl.Name = "metTabControl";
            this.metTabControl.SelectedIndex = 0;
            this.metTabControl.Size = new System.Drawing.Size(1138, 521);
            this.metTabControl.TabIndex = 1;
            this.metTabControl.SelectedIndexChanged += new System.EventHandler(this.metTabControl_SelectedIndexChanged);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.AutoScroll = true;
            this.metroTabPage1.Controls.Add(this.metBtnAddTeam);
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1130, 482);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Division 1";
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // metBtnAddTeam
            // 
            this.metBtnAddTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metBtnAddTeam.Location = new System.Drawing.Point(3, 3);
            this.metBtnAddTeam.Name = "metBtnAddTeam";
            this.metBtnAddTeam.Size = new System.Drawing.Size(1124, 43);
            this.metBtnAddTeam.TabIndex = 2;
            this.metBtnAddTeam.Text = "Add team +";
            this.metBtnAddTeam.Click += new System.EventHandler(this.metBtnAddTeam_Click);
            // 
            // metroAddTab
            // 
            this.metroAddTab.BackColor = System.Drawing.SystemColors.Control;
            this.metroAddTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroAddTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroAddTab.HorizontalScrollbarBarColor = true;
            this.metroAddTab.Location = new System.Drawing.Point(4, 35);
            this.metroAddTab.Name = "metroAddTab";
            this.metroAddTab.Size = new System.Drawing.Size(1130, 509);
            this.metroAddTab.TabIndex = 1;
            this.metroAddTab.Text = "Add Division +";
            this.metroAddTab.VerticalScrollbarBarColor = true;
            // 
            // metBtnCalc
            // 
            this.metBtnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metBtnCalc.Location = new System.Drawing.Point(1070, 591);
            this.metBtnCalc.Name = "metBtnCalc";
            this.metBtnCalc.Size = new System.Drawing.Size(85, 33);
            this.metBtnCalc.TabIndex = 2;
            this.metBtnCalc.Text = "Calculate";
            // 
            // metBtnQuit
            // 
            this.metBtnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metBtnQuit.Location = new System.Drawing.Point(979, 591);
            this.metBtnQuit.Name = "metBtnQuit";
            this.metBtnQuit.Size = new System.Drawing.Size(85, 33);
            this.metBtnQuit.TabIndex = 3;
            this.metBtnQuit.Text = "Quit";
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton1.Location = new System.Drawing.Point(273, 591);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(119, 33);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Remove Division";
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton2.Location = new System.Drawing.Point(148, 591);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(119, 33);
            this.metroButton2.TabIndex = 5;
            this.metroButton2.Text = "Remove Team";
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton3.Location = new System.Drawing.Point(23, 591);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(119, 33);
            this.metroButton3.TabIndex = 6;
            this.metroButton3.Text = "Edit Team";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 635);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metBtnQuit);
            this.Controls.Add(this.metBtnCalc);
            this.Controls.Add(this.metTabControl);
            this.Name = "Form1";
            this.Text = "League Fixtures";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metTabControl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metTabControl;
        private MetroFramework.Controls.MetroTabPage metroAddTab;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroButton metBtnAddTeam;
        private MetroFramework.Controls.MetroButton metBtnCalc;
        private MetroFramework.Controls.MetroButton metBtnQuit;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;


    }
}

