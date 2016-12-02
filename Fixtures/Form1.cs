using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SbsSW.SwiPlCs;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Animation;
using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Fonts;
using MetroFramework.Interfaces;
using MetroFramework.Localization;
using MetroFramework.Native;
using MetroFramework.Properties;

namespace Fixtures
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        //Global input variables
        private string[,] name = new string[20, 20]; //Division, Team
        private string[, ,] shared = new string[20,20,4]; //Max 20 divisions, 20 teams, 5 teams for single grounds
        //Create objects
        List<Label> labels = new List<Label>();
        List<MetroComboBox> comboBoxes = new List<MetroComboBox>();
        List<MetroButton> buttons = new List<MetroButton>();
        Label lblLine = new Label();
        Label lblTeamName = new Label();
        Label lblNameDisp = new Label();
        Label lblSharedDisp = new Label();
        Label lblSharedAll = new Label();
        //
        private int division = 0;
        private int team = 0;
        private int sharedCount = 0;
        private int newTabIndex = 1;
        private int addTeamBtnY = 90;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize Prolog
            Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"C:\\Program Files (x86)\\swipl");
            Environment.SetEnvironmentVariable("Path", @"C:\\PROGRAM FILES (x86)\\swipl");
            Environment.SetEnvironmentVariable("Path", @"C:\\PROGRAM FILES (x86)\\swipl\bin");

            String[] param = { "-q", "-f", @"calculate.pl" };
            PlEngine.Initialize(param);
            //Initialize
            metTabControl.SelectedIndex = 0;
            metBtnAddTeam.Location = new Point(5, 5);
            txtName.Text = "Enter team name";
            txtShared.Text = "Enter team name";
            txtName.ForeColor = Color.Gray;
            txtShared.ForeColor = Color.Gray;
            lblName.Hide();
            lblTeam.Hide();
            txtName.Hide();
            lblShared.Hide();
            btnShared.Hide();
            txtShared.Hide();
            lblHome.Hide();
            cmbBoxHome.Hide();
            btnHome.Hide();
            lblNoPlay.Hide();
            cmbBoxNoPlay.Hide();
            btnNoPlay.Hide();


            //CODE

            //PlQuery.PlCall("assert(team(brz))");
            
            //DONE

            //using (var q = new PlQuery("playing(fra,R,G), atomic_list_concat(['France plays in round ', R, ' game ', G], L)"))
            //{
                //foreach (PlQueryVariables v in q.SolutionVariables)
                //{
                    //richTextBox1.AppendText(v["L"].ToString());
                   // richTextBox1.AppendText("\n");
                //}

                /*richTextBox1.AppendText("\n\nall children from uwe:");
                q.Variables["P"].Unify("uwe");
                foreach (PlQueryVariables v in q.SolutionVariables)
                {
                    richTextBox1.AppendText("\n");
                    richTextBox1.AppendText(v["C"].ToString());
                }*/
            //}

            //using (var q = new PlQuery("plays(ger,fra,R,G), atomic_list_concat(['Germany could play France in round ', R, ' game ', G], L)"))
            //{
                //foreach (PlQueryVariables v in q.SolutionVariables)
                //{
                    //richTextBox1.AppendText(v["L"].ToString());
                    //richTextBox1.AppendText("\n");
                //}
            //}

            PlEngine.PlCleanup();
        }

        private void metTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = this.metTabControl.TabCount;
            //New tab clicked, create new division
            if (metTabControl.SelectedIndex == newTabIndex)
            {
                //Create new tab
                metTabControl.SelectedTab.Text = "Division " + (newTabIndex + 1) ;
                this.metTabControl.TabPages.Insert(index, "Add Division +");
                this.metTabControl.SelectedIndex = index - 1;
                this.metTabControl.SelectedTab.BackColor = Color.White;
                newTabIndex++;
                //Populate new tab with objects
                //buttons.Add(btnAddTeam);
                //metTabControl.SelectedTab.Controls.Add(btnAddTeam);
                //btnAddTeam.Location = new Point(5, 5);
                //btnAddTeam.Size = new Size(1175, 43);
                //btnAddTeam.Text = "Add team +";
                //btnAddTeam.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
            }
            //Move objects between tabs
            metTabControl.SelectedTab.Controls.Add(metBtnAddTeam);
        }

        private void metBtnAddTeam_Click(object sender, EventArgs e)
        {
            if (addTeamBtnY != 902 && metBtnAddTeam.Text == "Add team +") //20 teams max
            {
                //Add a team
                lblName.Show();
                lblTeam.Show();
                txtName.Show();
                lblShared.Show();
                btnShared.Show();
                txtShared.Show();
                lblHome.Show();
                cmbBoxHome.Show();
                btnHome.Show();
                lblNoPlay.Show();
                cmbBoxNoPlay.Show();
                btnNoPlay.Show();
                metBtnAddTeam.Text = "Submit";
                metBtnAddTeam.Location = new Point(5, addTeamBtnY);
                addTeamBtnY += 90;
            }
            else if (addTeamBtnY != 902 && metBtnAddTeam.Text == "Submit")
            {
                string input = txtShared.Text;
                input = input.Trim();
                //Add team
                name[0, team] = txtName.Text;

                if (txtShared.Text != "Enter team name" && input != "")
                {
                    shared[division, team, sharedCount] = txtShared.Text;
                }

                //Display team
                labels.Add(lblLine);
                labels.Add(lblTeamName);
                labels.Add(lblNameDisp);
                labels.Add(lblSharedDisp);
                lblSharedDisp.MouseEnter += new EventHandler(lblSharedDisp_MouseEnter);
                lblSharedDisp.MouseLeave += new EventHandler(lblSharedDisp_MouseLeave);
                metTabControl.SelectedTab.Controls.Add(lblTeamName);
                metTabControl.SelectedTab.Controls.Add(lblNameDisp);
                metTabControl.SelectedTab.Controls.Add(lblLine);
                metTabControl.SelectedTab.Controls.Add(lblSharedDisp);
                lblLine.Location = new Point(5, 85);
                lblTeamName.Location = new Point(12, 3);
                lblNameDisp.Location = new Point(65, 32);
                lblSharedDisp.Location = new Point(365, 32);
                lblLine.Text = "";
                lblLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lblNameDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lblSharedDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lblLine.AutoSize = false;
                lblLine.Height = 2;
                lblLine.Width = 1175;
                lblTeamName.Text = "Team 1";

                if (shared[division, team, 1] == null)
                {
                    lblSharedDisp.Text = shared[0, 0, 0];
                }
                else
                {
                    //More than one shared teams
                    labels.Add(lblSharedAll);
                    metTabControl.SelectedTab.Controls.Add(lblSharedAll);
                    lblSharedAll.Location = new Point(500, 50);
                    lblSharedAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    lblSharedAll.Hide();
                    lblSharedAll.Font = new Font("Nirmala UI Semilight", 12);
                    lblSharedDisp.Text = shared[division, team, 0] + "...";                   

                    if (shared[division, team, 2] == null)
                    {
                        lblSharedAll.Text = "..." + shared[division, team, 1];
                        lblSharedAll.Size = new Size(100, 25);
                    }
                    else if (shared[division, team, 3] == null)
                    {
                        lblSharedAll.Text = "..." + shared[division, team, 1] + "\n" + shared[division, team, 2];
                        lblSharedAll.Size = new Size(100, 50);
                    }
                    else
                    {
                        lblSharedAll.Text = "..." + shared[division, team, 1] + "\n" + shared[division, team, 2] + "\n" + shared[division, team, 3];
                        lblSharedAll.Size = new Size(100, 75);
                    }
                }
                lblNameDisp.Text = name[0, 0];
                lblTeamName.Font = new Font("Nirmala UI Semilight", 14);
                lblNameDisp.Font = new Font("Nirmala UI Semilight", 18);
                lblSharedDisp.Font = new Font("Nirmala UI Semilight", 18);
                lblTeamName.BackColor = Color.White;
                lblNameDisp.BackColor = Color.White;
                lblSharedDisp.BackColor = Color.White;
                lblNameDisp.Size = new Size(300, 40);
                lblSharedDisp.Size = new Size(300, 40);
                //Increment
                team++;
                sharedCount = 0;
                //Reset
                txtName.Text = "Enter team name";
                txtShared.Text = "Enter team name";
                txtName.ForeColor = Color.Gray;
                txtShared.ForeColor = Color.Gray;
                lblName.Hide();
                lblTeam.Hide();
                txtName.Hide();
                lblShared.Hide();
                btnShared.Hide();
                txtShared.Hide();
                lblHome.Hide();
                cmbBoxHome.Hide();
                btnHome.Hide();
                lblNoPlay.Hide();
                cmbBoxNoPlay.Hide();
                btnNoPlay.Hide();
                //Move down
                lblName.Location = new Point(17, addTeamBtnY-90 + 32);
                lblTeam.Location = new Point(12, addTeamBtnY-90);
                txtName.Location = new Point(71, addTeamBtnY-90 + 32);
                lblShared.Location = new Point(221, addTeamBtnY-90 + 32);
                btnShared.Location = new Point(391, addTeamBtnY-90 + 58);
                txtShared.Location = new Point(332, addTeamBtnY-90 + 32);
                lblHome.Location = new Point(472, addTeamBtnY-90 + 32);
                cmbBoxHome.Location = new Point(556, addTeamBtnY-90 + 32);
                btnHome.Location = new Point(681, addTeamBtnY-90 + 58);
                lblNoPlay.Location = new Point(762, addTeamBtnY-90 + 32);
                cmbBoxNoPlay.Location = new Point(865, addTeamBtnY-90 + 32);
                btnNoPlay.Location = new Point(990, addTeamBtnY-90 + 58);
                metBtnAddTeam.Text = "Add team +";
                sharedCount = 0;
            }
            else
            {
                //Max teams added
            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            //Remove text so user can type and set colour to black
            if (txtName.Text == "Enter team name")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtShared_Click(object sender, EventArgs e)
        {
            //Remove text so user can type and set colour to black
            if (txtShared.Text == "Enter team name")
            {
                txtShared.Text = "";
                txtShared.ForeColor = Color.Black;
            }
        }

        private void btnShared_Click(object sender, EventArgs e)
        {
            string input = txtShared.Text;
            input = input.Trim();

            if (sharedCount == 3)
            {
                //Max shared teams added
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared.Text != "Enter team name" && input != "")
            {
                //User wants to add another team to be sharing grounds with
                //Save current text
                shared[division, team, sharedCount] = txtShared.Text;
                sharedCount++;
                //Reset text to type new team name
                txtShared.Text = "";
                txtShared.Focus();
            }
        }

        private void lblSharedDisp_MouseEnter(object sender, EventArgs e)
        {
            lblSharedAll.BringToFront();
            lblSharedAll.Show();
        }

        private void lblSharedDisp_MouseLeave(object sender, EventArgs e)
        {
            lblSharedAll.Hide();
        }
    }
}
