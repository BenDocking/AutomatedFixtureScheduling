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
            this.metroAddTab = new MetroFramework.Controls.MetroTabPage();
            this.metBtnAddTeam = new MetroFramework.Controls.MetroButton();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
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
            this.metTabControl.Size = new System.Drawing.Size(1138, 548);
            this.metTabControl.TabIndex = 1;
            this.metTabControl.SelectedIndexChanged += new System.EventHandler(this.metTabControl_SelectedIndexChanged);
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
            // metroTabPage1
            // 
            this.metroTabPage1.AutoScroll = true;
            this.metroTabPage1.Controls.Add(this.metBtnAddTeam);
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1130, 509);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Division 1";
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 635);
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


    }
}

