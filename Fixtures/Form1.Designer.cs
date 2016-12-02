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
            this.lblTeam = new System.Windows.Forms.Label();
            this.txtShared = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnNoPlay = new MetroFramework.Controls.MetroButton();
            this.btnHome = new MetroFramework.Controls.MetroButton();
            this.lblNoPlay = new MetroFramework.Controls.MetroLabel();
            this.lblHome = new MetroFramework.Controls.MetroLabel();
            this.btnShared = new MetroFramework.Controls.MetroButton();
            this.lblShared = new MetroFramework.Controls.MetroLabel();
            this.lblName = new MetroFramework.Controls.MetroLabel();
            this.metBtnAddTeam = new MetroFramework.Controls.MetroButton();
            this.metroAddTab = new MetroFramework.Controls.MetroTabPage();
            this.btnCalc = new MetroFramework.Controls.MetroButton();
            this.metBtnQuit = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.cmbBoxHome = new System.Windows.Forms.ComboBox();
            this.cmbBoxNoPlay = new System.Windows.Forms.ComboBox();
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
            this.metTabControl.Size = new System.Drawing.Size(1189, 521);
            this.metTabControl.TabIndex = 1;
            this.metTabControl.SelectedIndexChanged += new System.EventHandler(this.metTabControl_SelectedIndexChanged);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.AutoScroll = true;
            this.metroTabPage1.Controls.Add(this.cmbBoxNoPlay);
            this.metroTabPage1.Controls.Add(this.cmbBoxHome);
            this.metroTabPage1.Controls.Add(this.lblTeam);
            this.metroTabPage1.Controls.Add(this.txtShared);
            this.metroTabPage1.Controls.Add(this.txtName);
            this.metroTabPage1.Controls.Add(this.btnNoPlay);
            this.metroTabPage1.Controls.Add(this.btnHome);
            this.metroTabPage1.Controls.Add(this.lblNoPlay);
            this.metroTabPage1.Controls.Add(this.lblHome);
            this.metroTabPage1.Controls.Add(this.btnShared);
            this.metroTabPage1.Controls.Add(this.lblShared);
            this.metroTabPage1.Controls.Add(this.lblName);
            this.metroTabPage1.Controls.Add(this.metBtnAddTeam);
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1181, 482);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Division 1";
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.BackColor = System.Drawing.SystemColors.Window;
            this.lblTeam.Font = new System.Drawing.Font("Nirmala UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.Location = new System.Drawing.Point(12, 3);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(68, 25);
            this.lblTeam.TabIndex = 20;
            this.lblTeam.Text = "Team 1";
            // 
            // txtShared
            // 
            this.txtShared.BackColor = System.Drawing.SystemColors.Window;
            this.txtShared.Location = new System.Drawing.Point(332, 32);
            this.txtShared.Name = "txtShared";
            this.txtShared.Size = new System.Drawing.Size(134, 20);
            this.txtShared.TabIndex = 17;
            this.txtShared.Click += new System.EventHandler(this.txtShared_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Location = new System.Drawing.Point(71, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(144, 20);
            this.txtName.TabIndex = 16;
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            // 
            // btnNoPlay
            // 
            this.btnNoPlay.Location = new System.Drawing.Point(870, 58);
            this.btnNoPlay.Name = "btnNoPlay";
            this.btnNoPlay.Size = new System.Drawing.Size(75, 23);
            this.btnNoPlay.TabIndex = 15;
            this.btnNoPlay.Text = "Add another";
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(621, 58);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 14;
            this.btnHome.Text = "Add another";
            // 
            // lblNoPlay
            // 
            this.lblNoPlay.AutoSize = true;
            this.lblNoPlay.Location = new System.Drawing.Point(702, 32);
            this.lblNoPlay.Name = "lblNoPlay";
            this.lblNoPlay.Size = new System.Drawing.Size(97, 19);
            this.lblNoPlay.TabIndex = 12;
            this.lblNoPlay.Text = "Date can\'t play:";
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Location = new System.Drawing.Point(472, 32);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(78, 19);
            this.lblHome.TabIndex = 10;
            this.lblHome.Text = "Home date:";
            // 
            // btnShared
            // 
            this.btnShared.Location = new System.Drawing.Point(391, 58);
            this.btnShared.Name = "btnShared";
            this.btnShared.Size = new System.Drawing.Size(75, 23);
            this.btnShared.TabIndex = 9;
            this.btnShared.Text = "Add another";
            this.btnShared.Click += new System.EventHandler(this.btnShared_Click);
            // 
            // lblShared
            // 
            this.lblShared.AutoSize = true;
            this.lblShared.Location = new System.Drawing.Point(221, 32);
            this.lblShared.Name = "lblShared";
            this.lblShared.Size = new System.Drawing.Size(105, 19);
            this.lblShared.TabIndex = 7;
            this.lblShared.Text = "Shared grounds:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 19);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // metBtnAddTeam
            // 
            this.metBtnAddTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metBtnAddTeam.Location = new System.Drawing.Point(3, 3);
            this.metBtnAddTeam.Name = "metBtnAddTeam";
            this.metBtnAddTeam.Size = new System.Drawing.Size(1175, 43);
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
            this.metroAddTab.Size = new System.Drawing.Size(1181, 482);
            this.metroAddTab.TabIndex = 1;
            this.metroAddTab.Text = "Add Division +";
            this.metroAddTab.VerticalScrollbarBarColor = true;
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Location = new System.Drawing.Point(1121, 591);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(85, 33);
            this.btnCalc.TabIndex = 2;
            this.btnCalc.Text = "Calculate";
            // 
            // metBtnQuit
            // 
            this.metBtnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metBtnQuit.Location = new System.Drawing.Point(1030, 591);
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
            // cmbBoxHome
            // 
            this.cmbBoxHome.FormattingEnabled = true;
            this.cmbBoxHome.Items.AddRange(new object[] {
            "17th April",
            "24th April",
            "1st May",
            "8th May",
            "15th May",
            "22nd May",
            "29th May",
            "5th June",
            "12th June",
            "19th June",
            "26th June",
            "3rd July",
            "10th July",
            "17th July",
            "24th July",
            "31st July",
            "7th August",
            "14th August",
            "21st August",
            "28th August",
            "4th September",
            "11th September",
            "18th September",
            "2nd May (Holiday)",
            "30th May (Holiday)",
            "29th August (Holiday)"});
            this.cmbBoxHome.Location = new System.Drawing.Point(556, 32);
            this.cmbBoxHome.Name = "cmbBoxHome";
            this.cmbBoxHome.Size = new System.Drawing.Size(140, 21);
            this.cmbBoxHome.TabIndex = 21;
            // 
            // cmbBoxNoPlay
            // 
            this.cmbBoxNoPlay.FormattingEnabled = true;
            this.cmbBoxNoPlay.Items.AddRange(new object[] {
            "17th April",
            "24th April",
            "1st May",
            "8th May",
            "15th May",
            "22nd May",
            "29th May",
            "5th June",
            "12th June",
            "19th June",
            "26th June",
            "3rd July",
            "10th July",
            "17th July",
            "24th July",
            "31st July",
            "7th August",
            "14th August",
            "21st August",
            "28th August",
            "4th September",
            "11th September",
            "18th September",
            "2nd May (Holiday)",
            "30th May (Holiday)",
            "29th August (Holiday)"});
            this.cmbBoxNoPlay.Location = new System.Drawing.Point(805, 32);
            this.cmbBoxNoPlay.Name = "cmbBoxNoPlay";
            this.cmbBoxNoPlay.Size = new System.Drawing.Size(140, 21);
            this.cmbBoxNoPlay.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 635);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metBtnQuit);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.metTabControl);
            this.Name = "Form1";
            this.Text = "League Fixtures";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metTabControl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metTabControl;
        private MetroFramework.Controls.MetroTabPage metroAddTab;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroButton metBtnAddTeam;
        private MetroFramework.Controls.MetroButton btnCalc;
        private MetroFramework.Controls.MetroButton metBtnQuit;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroLabel lblName;
        private MetroFramework.Controls.MetroLabel lblShared;
        private MetroFramework.Controls.MetroButton btnShared;
        private MetroFramework.Controls.MetroButton btnNoPlay;
        private MetroFramework.Controls.MetroButton btnHome;
        private MetroFramework.Controls.MetroLabel lblNoPlay;
        private MetroFramework.Controls.MetroLabel lblHome;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtShared;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.ComboBox cmbBoxNoPlay;
        private System.Windows.Forms.ComboBox cmbBoxHome;


    }
}

