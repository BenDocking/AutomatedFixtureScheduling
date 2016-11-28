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
            this.metBtnAddTeam = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metBtnAddTeam
            // 
            this.metBtnAddTeam.Location = new System.Drawing.Point(23, 63);
            this.metBtnAddTeam.Name = "metBtnAddTeam";
            this.metBtnAddTeam.Size = new System.Drawing.Size(75, 23);
            this.metBtnAddTeam.TabIndex = 0;
            this.metBtnAddTeam.Text = "Add team +";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 635);
            this.Controls.Add(this.metBtnAddTeam);
            this.Name = "Form1";
            this.Text = "Fixtures";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metBtnAddTeam;


    }
}

