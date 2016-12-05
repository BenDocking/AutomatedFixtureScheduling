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
        private string[,] name = new string[15, 12]; //Division, Team
        private string[, ,] shared = new string[15,12,4]; //Max 15 divisions, 12 teams, 4 teams for single grounds
        private string[, ,] datesHome = new string[15, 12, 26]; //Division, Team, Dates
        private string[, ,] datesNoPlay = new string[15, 12, 26]; //Division, Team, Dates
        //Create objects
        List<Label> labels = new List<Label>();
        List<MetroComboBox> comboBoxes = new List<MetroComboBox>();
        List<MetroButton> buttons = new List<MetroButton>();
        Label lblLine = new Label();
        Label lblTeamName = new Label();
        Label lblNameDisp = new Label();
        Label lblSharedDisp = new Label();
        Label lblSharedAll = new Label();
        Label lblDatesHome = new Label();
        Label lblDatesNoPlay = new Label();
        Label lblDatesHomeAll = new Label();
        Label lblDatesNoPlayAll = new Label();
        Label lblSharedLabelDisp = new Label();
        Label lblPlayHomeDisp = new Label();
        Label lblNoPlayDisp = new Label();
        MetroButton del = new MetroButton();
        //
        private int division = 0;
        private int team = 0;
        private int sharedCount = 0;
        private int homeCount = 0;
        private int noPlayCount = 0;
        private int newTabIndex = 1;
        private int addTeamBtnY = 90;
        private int[] teamCount = new int[15];

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
            cmbBoxHome.Text = "Select a date";
            cmbBoxNoPlay.Text = "Select a date";
            cmbBoxHome.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay.DropDownStyle = ComboBoxStyle.DropDownList;
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
            if (teamCount[division] != 12 && metBtnAddTeam.Text == "Add team +") //15 teams max
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
                addTeamBtnY += 35;
            }
            else if (teamCount[division] != 12 && metBtnAddTeam.Text == "Submit")
            {
                string input = txtName.Text;
                input.Trim();

                if (input != "" && txtName.Text != "Enter team name")
                {
                    input = txtShared.Text;
                    input = input.Trim();
                    //Add team
                    name[0, team] = txtName.Text;

                    if (txtShared.Text != "Enter team name" && input != "")
                    {
                        shared[division, team, sharedCount] = txtShared.Text;
                        sharedCount++;
                    }

                    bool invalid = false;
                    //Check if date already exists
                    for (int i = 0; i < homeCount; i++)
                    {
                        if (cmbBoxHome.Text == datesHome[division, team, i])
                        {
                            invalid = true;
                        }
                    }

                    if (invalid == false && cmbBoxHome.Text != "")
                    {
                        //Add date to array
                        datesHome[division, team, homeCount] = cmbBoxHome.Text;
                        homeCount++;
                    }

                    invalid = false;

                    for (int i = 0; i < noPlayCount; i++)
                    {
                        if (cmbBoxNoPlay.Text == datesNoPlay[division, team, i])
                        {
                            invalid = true;
                        }
                    }

                    if (invalid == false && cmbBoxNoPlay.Text != "")
                    {
                        //Add date to array
                        datesNoPlay[division, team, noPlayCount] = cmbBoxNoPlay.Text;
                        noPlayCount++;
                    }

                    //Display team
                    labels.Add(lblLine);
                    labels.Add(lblTeamName);
                    labels.Add(lblNameDisp);
                    labels.Add(lblSharedDisp);
                    labels.Add(lblDatesHome);
                    labels.Add(lblDatesNoPlay);
                    labels.Add(lblSharedLabelDisp);
                    labels.Add(lblPlayHomeDisp);
                    labels.Add(lblNoPlayDisp);
                    buttons.Add(del);
                    lblSharedDisp.MouseEnter += new EventHandler(lblSharedDisp_MouseEnter);
                    lblSharedDisp.MouseLeave += new EventHandler(lblSharedDisp_MouseLeave);
                    lblDatesHome.MouseEnter += new EventHandler(lblDatesHome_MouseEnter);
                    lblDatesHome.MouseLeave += new EventHandler(lblDatesHome_MouseLeave);
                    lblDatesNoPlay.MouseEnter += new EventHandler(lblDatesNoPlay_MouseEnter);
                    lblDatesNoPlay.MouseLeave += new EventHandler(lblDatesNoPlay_MouseLeave);
                    del.Click += new EventHandler(del_Click);
                    metTabControl.SelectedTab.Controls.Add(lblTeamName);
                    metTabControl.SelectedTab.Controls.Add(lblNameDisp);
                    metTabControl.SelectedTab.Controls.Add(lblLine);
                    metTabControl.SelectedTab.Controls.Add(lblSharedDisp);
                    metTabControl.SelectedTab.Controls.Add(lblDatesHome);
                    metTabControl.SelectedTab.Controls.Add(lblDatesNoPlay);
                    metTabControl.SelectedTab.Controls.Add(lblSharedLabelDisp);
                    metTabControl.SelectedTab.Controls.Add(lblPlayHomeDisp);
                    metTabControl.SelectedTab.Controls.Add(lblNoPlayDisp);
                    metTabControl.SelectedTab.Controls.Add(del);
                    lblLine.Location = new Point(5, 32);
                    lblTeamName.Location = new Point(8, 3);
                    lblNameDisp.Location = new Point(65, 3);
                    lblSharedDisp.Location = new Point(340, 3);
                    lblDatesHome.Location = new Point(610, 3);
                    lblDatesNoPlay.Location = new Point(900, 3);
                    lblSharedLabelDisp.Location = new Point(280, 3);
                    lblPlayHomeDisp.Location = new Point(555, 3);
                    lblNoPlayDisp.Location = new Point(830, 3);
                    del.Location = new Point(1110, 3);
                    lblLine.Text = "";
                    del.Text = "Remove";
                    lblLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    lblNameDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    lblSharedDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    lblDatesHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    lblDatesNoPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    lblLine.AutoSize = false;
                    lblLine.Height = 2;
                    lblLine.Width = 1175;
                    lblTeamName.Text = "Team 1";
                    lblSharedLabelDisp.Text = "Shared:";
                    lblPlayHomeDisp.Text = "Home:";
                    lblNoPlayDisp.Text = "No Play:";

                    //Label to display all shared grounds teams
                    if (shared[division, team, 1] == null)
                    {
                        lblSharedDisp.Text = shared[division, team, 0];
                    }
                    else
                    {
                        //More than one shared teams
                        labels.Add(lblSharedAll);
                        metTabControl.SelectedTab.Controls.Add(lblSharedAll);
                        lblSharedAll.Location = new Point(500, 29);
                        lblSharedAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        lblSharedAll.Hide();
                        lblSharedAll.Font = new Font("Nirmala UI Semilight", 12);
                        lblSharedDisp.Text = shared[division, team, 0] + "...";

                        if (shared[division, team, 2] == null)
                        {
                            lblSharedAll.Text = "..." + shared[division, team, 1];
                            lblSharedAll.Size = new Size(200, 25);
                        }
                        else if (shared[division, team, 3] == null)
                        {
                            lblSharedAll.Text = "..." + shared[division, team, 1] + "\n" + shared[division, team, 2];
                            lblSharedAll.Size = new Size(200, 50);
                        }
                        else
                        {
                            lblSharedAll.Text = "..." + shared[division, team, 1] + "\n" + shared[division, team, 2] + "\n" + shared[division, team, 3];
                            lblSharedAll.Size = new Size(200, 75);
                        }
                    }
                    //Label to display all home dates
                    if (datesHome[division, team, 1] == null)
                    {
                        lblDatesHome.Text = datesHome[division, team, 0];
                    }
                    else
                    {
                        //More than one home dates
                        labels.Add(lblDatesHomeAll);
                        metTabControl.SelectedTab.Controls.Add(lblDatesHomeAll);
                        lblDatesHomeAll.Location = new Point(800, 29);
                        lblDatesHomeAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        lblDatesHomeAll.Hide();
                        lblDatesHomeAll.Font = new Font("Nirmala UI Semilight", 12);
                        lblDatesHome.Text = datesHome[division, team, 0] + "...";
                        lblDatesHomeAll.Text = "...";

                        for (int i = 1; i < homeCount; i++)
                        {
                            lblDatesHomeAll.Text += datesHome[division, team, i] + "\n";
                        }

                        lblDatesHomeAll.Size = new Size(200, 25 * homeCount);
                    }
                    //Label to display all dates not playing
                    if (datesNoPlay[division, team, 1] == null)
                    {
                        lblDatesNoPlay.Text = datesNoPlay[division, team, 0];
                    }
                    else
                    {
                        //More than one no play dates
                        labels.Add(lblDatesNoPlayAll);
                        metTabControl.SelectedTab.Controls.Add(lblDatesNoPlayAll);
                        lblDatesNoPlayAll.Location = new Point(800, 29);
                        lblDatesNoPlayAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        lblDatesNoPlayAll.Hide();
                        lblDatesNoPlayAll.Font = new Font("Nirmala UI Semilight", 12);
                        lblDatesNoPlay.Text = datesNoPlay[division, team, 0] + "...";
                        lblDatesNoPlayAll.Text = "...";

                        for (int i = 1; i < noPlayCount; i++)
                        {
                            lblDatesNoPlayAll.Text += datesNoPlay[division, team, i] + "\n";
                        }

                        lblDatesNoPlayAll.Size = new Size(200, 25 * homeCount);
                    }

                    lblNameDisp.Text = name[0, 0];
                    lblTeamName.Font = new Font("Nirmala UI Semilight", 12);
                    lblNameDisp.Font = new Font("Nirmala UI Semilight", 12);
                    lblSharedDisp.Font = new Font("Nirmala UI Semilight", 12);
                    lblDatesHome.Font = new Font("Nirmala UI Semilight", 12);
                    lblDatesNoPlay.Font = new Font("Nirmala UI Semilight", 12);
                    lblSharedLabelDisp.Font = new Font("Nirmala UI Semilight", 12);
                    lblPlayHomeDisp.Font = new Font("Nirmala UI Semilight", 12);
                    lblNoPlayDisp.Font = new Font("Nirmala UI Semilight", 12);
                    lblTeamName.BackColor = Color.White;
                    lblNameDisp.BackColor = Color.White;
                    lblSharedDisp.BackColor = Color.White;
                    lblDatesHome.BackColor = Color.White;
                    lblDatesNoPlay.BackColor = Color.White;
                    lblSharedLabelDisp.BackColor = Color.White;
                    lblPlayHomeDisp.BackColor = Color.White;
                    lblNoPlayDisp.BackColor = Color.White;
                    lblTeamName.Size = new Size(55, 25);
                    lblNameDisp.Size = new Size(200, 25);
                    lblSharedDisp.Size = new Size(200, 25);
                    lblDatesHome.Size = new Size(200, 25);
                    lblDatesNoPlay.Size = new Size(200, 25);
                    del.Size = new Size(60, 25);
                    //Increment
                    team++;
                    sharedCount = 0;
                    homeCount = 0;
                    noPlayCount = 0;
                    teamCount[division]++;
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
                    if (teamCount[division] == 12)
                    {
                        metBtnAddTeam.Hide();
                    }
                    else
                    {
                        lblName.Location = new Point(17, addTeamBtnY - 90 + 32);
                        lblTeam.Location = new Point(12, addTeamBtnY - 90);
                        txtName.Location = new Point(71, addTeamBtnY - 90 + 32);
                        lblShared.Location = new Point(221, addTeamBtnY - 90 + 32);
                        btnShared.Location = new Point(391, addTeamBtnY - 90 + 58);
                        txtShared.Location = new Point(332, addTeamBtnY - 90 + 32);
                        lblHome.Location = new Point(472, addTeamBtnY - 90 + 32);
                        cmbBoxHome.Location = new Point(556, addTeamBtnY - 90 + 32);
                        btnHome.Location = new Point(681, addTeamBtnY - 90 + 58);
                        lblNoPlay.Location = new Point(762, addTeamBtnY - 90 + 32);
                        cmbBoxNoPlay.Location = new Point(865, addTeamBtnY - 90 + 32);
                        btnNoPlay.Location = new Point(990, addTeamBtnY - 90 + 58);
                        metBtnAddTeam.Text = "Add team +";
                        metBtnAddTeam.Location = new Point(5, addTeamBtnY - 88);
                        sharedCount = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a team name", "No name entered", MessageBoxButtons.OK);
                }
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
            }
        }

        private void txtShared_Click(object sender, EventArgs e)
        {
            //Remove text so user can type and set colour to black
            if (txtShared.Text == "Enter team name")
            {
                txtShared.Text = "";
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            bool invalid = false;
            //Check if date already exists
            for (int i = 0; i < homeCount; i++)
            {
                if (cmbBoxHome.Text == datesHome[division, team, i])
                {
                    invalid = true;
                }
            }

            if (invalid == false && cmbBoxHome.Text != "")
            {
                //Add date to array
                datesHome[division, team, homeCount] = cmbBoxHome.Text;
                cmbBoxHome.SelectedIndex = -1;
                homeCount++;
            }
        }

        private void btnNoPlay_Click(object sender, EventArgs e)
        {
            bool invalid = false;

            for (int i = 0; i < noPlayCount; i++)
            {
                if (cmbBoxNoPlay.Text == datesNoPlay[division, team, i])
                {
                    invalid = true;
                }
            }

            if (invalid == false && cmbBoxNoPlay.Text != "")
            {
                //Add date to array
                datesNoPlay[division, team, noPlayCount] = cmbBoxNoPlay.Text;
                cmbBoxNoPlay.SelectedIndex = -1;
                noPlayCount++;
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

        private void lblDatesHome_MouseEnter(object sender, EventArgs e)
        {
            lblDatesHomeAll.BringToFront();
            lblDatesHomeAll.Show();
        }

        private void lblDatesHome_MouseLeave(object sender, EventArgs e)
        {
            lblDatesHomeAll.Hide();
        }

        private void lblDatesNoPlay_MouseEnter(object sender, EventArgs e)
        {
            lblDatesNoPlayAll.BringToFront();
            lblDatesNoPlayAll.Show();
        }

        private void lblDatesNoPlay_MouseLeave(object sender, EventArgs e)
        {
            lblDatesNoPlayAll.Hide();
        }

        private void txtShared_TextChanged(object sender, EventArgs e)
        {
            txtShared.ForeColor = Color.Black;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.ForeColor = Color.Black;
        }

        private void del_Click(object sender, EventArgs e)
        {
            //Remove team
        }
    }
}