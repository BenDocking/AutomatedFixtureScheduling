namespace Fixtures
{
    partial class Form2
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
            this.metTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // metTabControl
            // 
            this.metTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metTabControl.Controls.Add(this.metroTabPage1);
            this.metTabControl.Location = new System.Drawing.Point(23, 63);
            this.metTabControl.Name = "metTabControl";
            this.metTabControl.SelectedIndex = 0;
            this.metTabControl.Size = new System.Drawing.Size(999, 475);
            this.metTabControl.TabIndex = 2;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(991, 436);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Division 1";
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 569);
            this.Controls.Add(this.metTabControl);
            this.MinimumSize = new System.Drawing.Size(1045, 569);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Cricket League Fixtures Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metTabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
    }
}

