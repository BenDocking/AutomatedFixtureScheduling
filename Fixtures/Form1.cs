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
        #region Team1
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
        #endregion
        #region Team2
        Label lblLine1 = new Label();
        Label lblTeamName1 = new Label();
        Label lblNameDisp1 = new Label();
        Label lblSharedDisp1 = new Label();
        Label lblSharedAll1 = new Label();
        Label lblDatesHome1 = new Label();
        Label lblDatesNoPlay1 = new Label();
        Label lblDatesHomeAll1 = new Label();
        Label lblDatesNoPlayAll1 = new Label();
        Label lblSharedLabelDisp1 = new Label();
        Label lblPlayHomeDisp1 = new Label();
        Label lblNoPlayDisp1 = new Label();
        MetroButton del1 = new MetroButton();
        #endregion
        #region Team3
        Label lblLine2 = new Label();
        Label lblTeamName2 = new Label();
        Label lblNameDisp2 = new Label();
        Label lblSharedDisp2 = new Label();
        Label lblSharedAll2 = new Label();
        Label lblDatesHome2 = new Label();
        Label lblDatesNoPlay2 = new Label();
        Label lblDatesHomeAll2 = new Label();
        Label lblDatesNoPlayAll2 = new Label();
        Label lblSharedLabelDisp2 = new Label();
        Label lblPlayHomeDisp2 = new Label();
        Label lblNoPlayDisp2 = new Label();
        MetroButton del2 = new MetroButton();
        #endregion
        #region Team4
        Label lblLine3 = new Label();
        Label lblTeamName3 = new Label();
        Label lblNameDisp3 = new Label();
        Label lblSharedDisp3 = new Label();
        Label lblSharedAll3 = new Label();
        Label lblDatesHome3 = new Label();
        Label lblDatesNoPlay3 = new Label();
        Label lblDatesHomeAll3 = new Label();
        Label lblDatesNoPlayAll3 = new Label();
        Label lblSharedLabelDisp3 = new Label();
        Label lblPlayHomeDisp3 = new Label();
        Label lblNoPlayDisp3 = new Label();
        MetroButton del3 = new MetroButton();
        #endregion
        #region Team5
        Label lblLine4 = new Label();
        Label lblTeamName4 = new Label();
        Label lblNameDisp4 = new Label();
        Label lblSharedDisp4 = new Label();
        Label lblSharedAll4 = new Label();
        Label lblDatesHome4 = new Label();
        Label lblDatesNoPlay4 = new Label();
        Label lblDatesHomeAll4 = new Label();
        Label lblDatesNoPlayAll4 = new Label();
        Label lblSharedLabelDisp4 = new Label();
        Label lblPlayHomeDisp4 = new Label();
        Label lblNoPlayDisp4 = new Label();
        MetroButton del4 = new MetroButton();
        #endregion
        #region Team6
        Label lblLine5 = new Label();
        Label lblTeamName5 = new Label();
        Label lblNameDisp5 = new Label();
        Label lblSharedDisp5 = new Label();
        Label lblSharedAll5 = new Label();
        Label lblDatesHome5 = new Label();
        Label lblDatesNoPlay5 = new Label();
        Label lblDatesHomeAll5 = new Label();
        Label lblDatesNoPlayAll5 = new Label();
        Label lblSharedLabelDisp5 = new Label();
        Label lblPlayHomeDisp5 = new Label();
        Label lblNoPlayDisp5 = new Label();
        MetroButton del5 = new MetroButton();
        #endregion
        #region Team7
        Label lblLine6 = new Label();
        Label lblTeamName6 = new Label();
        Label lblNameDisp6 = new Label();
        Label lblSharedDisp6 = new Label();
        Label lblSharedAll6 = new Label();
        Label lblDatesHome6 = new Label();
        Label lblDatesNoPlay6 = new Label();
        Label lblDatesHomeAll6 = new Label();
        Label lblDatesNoPlayAll6 = new Label();
        Label lblSharedLabelDisp6 = new Label();
        Label lblPlayHomeDisp6 = new Label();
        Label lblNoPlayDisp6 = new Label();
        MetroButton del6 = new MetroButton();
        #endregion
        #region Team8
        Label lblLine7 = new Label();
        Label lblTeamName7 = new Label();
        Label lblNameDisp7 = new Label();
        Label lblSharedDisp7 = new Label();
        Label lblSharedAll7 = new Label();
        Label lblDatesHome7 = new Label();
        Label lblDatesNoPlay7 = new Label();
        Label lblDatesHomeAll7 = new Label();
        Label lblDatesNoPlayAll7 = new Label();
        Label lblSharedLabelDisp7 = new Label();
        Label lblPlayHomeDisp7 = new Label();
        Label lblNoPlayDisp7 = new Label();
        MetroButton del7 = new MetroButton();
        #endregion
        #region Team9
        Label lblLine8 = new Label();
        Label lblTeamName8 = new Label();
        Label lblNameDisp8 = new Label();
        Label lblSharedDisp8 = new Label();
        Label lblSharedAll8 = new Label();
        Label lblDatesHome8 = new Label();
        Label lblDatesNoPlay8 = new Label();
        Label lblDatesHomeAll8 = new Label();
        Label lblDatesNoPlayAll8 = new Label();
        Label lblSharedLabelDisp8 = new Label();
        Label lblPlayHomeDisp8 = new Label();
        Label lblNoPlayDisp8 = new Label();
        MetroButton del8 = new MetroButton();
        #endregion
        #region Team10
        Label lblLine9 = new Label();
        Label lblTeamName9 = new Label();
        Label lblNameDisp9 = new Label();
        Label lblSharedDisp9 = new Label();
        Label lblSharedAll9 = new Label();
        Label lblDatesHome9 = new Label();
        Label lblDatesNoPlay9 = new Label();
        Label lblDatesHomeAll9 = new Label();
        Label lblDatesNoPlayAll9 = new Label();
        Label lblSharedLabelDisp9 = new Label();
        Label lblPlayHomeDisp9 = new Label();
        Label lblNoPlayDisp9 = new Label();
        MetroButton del9 = new MetroButton();
        #endregion
        #region Team11
        Label lblLine10 = new Label();
        Label lblTeamName10 = new Label();
        Label lblNameDisp10 = new Label();
        Label lblSharedDisp10 = new Label();
        Label lblSharedAll10 = new Label();
        Label lblDatesHome10 = new Label();
        Label lblDatesNoPlay10 = new Label();
        Label lblDatesHomeAll10 = new Label();
        Label lblDatesNoPlayAll10 = new Label();
        Label lblSharedLabelDisp10 = new Label();
        Label lblPlayHomeDisp10 = new Label();
        Label lblNoPlayDisp10 = new Label();
        MetroButton del10 = new MetroButton();
        #endregion
        #region Team12
        Label lblLine11 = new Label();
        Label lblTeamName11 = new Label();
        Label lblNameDisp11 = new Label();
        Label lblSharedDisp11 = new Label();
        Label lblSharedAll11 = new Label();
        Label lblDatesHome11 = new Label();
        Label lblDatesNoPlay11 = new Label();
        Label lblDatesHomeAll11 = new Label();
        Label lblDatesNoPlayAll11 = new Label();
        Label lblSharedLabelDisp11 = new Label();
        Label lblPlayHomeDisp11 = new Label();
        Label lblNoPlayDisp11 = new Label();
        MetroButton del11 = new MetroButton();
        #endregion
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
                    #region Display Team
                    switch (teamCount[division])
                    {
                        case 0:
                            #region Display Team 1
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

                                lblDatesHomeAll.Size = new Size(200, 25 * homeCount - 25);
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

                                lblDatesNoPlayAll.Size = new Size(200, 25 * noPlayCount - 25);
                            }

                            lblNameDisp.Text = name[division, team];
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
                            #endregion
                            break;
                        case 1:
                            #region Display Team 2
                            labels.Add(lblLine1);
                            labels.Add(lblTeamName1);
                            labels.Add(lblNameDisp1);
                            labels.Add(lblSharedDisp1);
                            labels.Add(lblDatesHome1);
                            labels.Add(lblDatesNoPlay1);
                            labels.Add(lblSharedLabelDisp1);
                            labels.Add(lblPlayHomeDisp1);
                            labels.Add(lblNoPlayDisp1);
                            buttons.Add(del1);
                            lblSharedDisp1.MouseEnter += new EventHandler(lblSharedDisp_MouseEnter);
                            lblSharedDisp1.MouseLeave += new EventHandler(lblSharedDisp_MouseLeave);
                            lblDatesHome1.MouseEnter += new EventHandler(lblDatesHome_MouseEnter);
                            lblDatesHome1.MouseLeave += new EventHandler(lblDatesHome_MouseLeave);
                            lblDatesNoPlay1.MouseEnter += new EventHandler(lblDatesNoPlay_MouseEnter);
                            lblDatesNoPlay1.MouseLeave += new EventHandler(lblDatesNoPlay_MouseLeave);
                            del1.Click += new EventHandler(del_Click);
                            metTabControl.SelectedTab.Controls.Add(lblTeamName1);
                            metTabControl.SelectedTab.Controls.Add(lblNameDisp1);
                            metTabControl.SelectedTab.Controls.Add(lblLine1);
                            metTabControl.SelectedTab.Controls.Add(lblSharedDisp1);
                            metTabControl.SelectedTab.Controls.Add(lblDatesHome1);
                            metTabControl.SelectedTab.Controls.Add(lblDatesNoPlay1);
                            metTabControl.SelectedTab.Controls.Add(lblSharedLabelDisp1);
                            metTabControl.SelectedTab.Controls.Add(lblPlayHomeDisp1);
                            metTabControl.SelectedTab.Controls.Add(lblNoPlayDisp1);
                            metTabControl.SelectedTab.Controls.Add(del1);
                            //+35 in Y
                            lblLine1.Location = new Point(5, 67);
                            lblTeamName1.Location = new Point(8, 38);
                            lblNameDisp1.Location = new Point(65, 38);
                            lblSharedDisp1.Location = new Point(340, 38);
                            lblDatesHome1.Location = new Point(610, 38);
                            lblDatesNoPlay1.Location = new Point(900, 38);
                            lblSharedLabelDisp1.Location = new Point(280, 38);
                            lblPlayHomeDisp1.Location = new Point(555, 38);
                            lblNoPlayDisp1.Location = new Point(830, 38);
                            del1.Location = new Point(1110, 38);
                            lblLine1.Text = "";
                            del1.Text = "Remove";
                            lblLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            lblNameDisp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            lblSharedDisp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            lblDatesHome1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            lblDatesNoPlay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            lblLine1.AutoSize = false;
                            lblLine1.Height = 2;
                            lblLine1.Width = 1175;
                            lblTeamName1.Text = "Team 1";
                            lblSharedLabelDisp1.Text = "Shared:";
                            lblPlayHomeDisp1.Text = "Home:";
                            lblNoPlayDisp1.Text = "No Play:";

                            //Label to display all shared grounds teams
                            if (shared[division, team, 1] == null)
                            {
                                lblSharedDisp1.Text = shared[division, team, 0];
                            }
                            else
                            {
                                //More than one shared teams
                                labels.Add(lblSharedAll1);
                                metTabControl.SelectedTab.Controls.Add(lblSharedAll1);
                                lblSharedAll1.Location = new Point(500, 29);
                                lblSharedAll1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                lblSharedAll1.Hide();
                                lblSharedAll1.Font = new Font("Nirmala UI Semilight", 12);
                                lblSharedDisp1.Text = shared[division, team, 0] + "...";

                                if (shared[division, team, 2] == null)
                                {
                                    lblSharedAll1.Text = "..." + shared[division, team, 1];
                                    lblSharedAll1.Size = new Size(200, 25);
                                }
                                else if (shared[division, team, 3] == null)
                                {
                                    lblSharedAll1.Text = "..." + shared[division, team, 1] + "\n" + shared[division, team, 2];
                                    lblSharedAll1.Size = new Size(200, 50);
                                }
                                else
                                {
                                    lblSharedAll1.Text = "..." + shared[division, team, 1] + "\n" + shared[division, team, 2] + "\n" + shared[division, team, 3];
                                    lblSharedAll1.Size = new Size(200, 75);
                                }
                            }
                            //Label to display all home dates
                            if (datesHome[division, team, 1] == null)
                            {
                                lblDatesHome1.Text = datesHome[division, team, 0];
                            }
                            else
                            {
                                //More than one home dates
                                labels.Add(lblDatesHomeAll1);
                                metTabControl.SelectedTab.Controls.Add(lblDatesHomeAll1);
                                lblDatesHomeAll1.Location = new Point(800, 29);
                                lblDatesHomeAll1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                lblDatesHomeAll1.Hide();
                                lblDatesHomeAll1.Font = new Font("Nirmala UI Semilight", 12);
                                lblDatesHome1.Text = datesHome[division, team, 0] + "...";
                                lblDatesHomeAll1.Text = "...";

                                for (int i = 1; i < homeCount; i++)
                                {
                                    lblDatesHomeAll1.Text += datesHome[division, team, i] + "\n";
                                }

                                lblDatesHomeAll1.Size = new Size(200, 25 * homeCount - 25);
                            }
                            //Label to display all dates not playing
                            if (datesNoPlay[division, team, 1] == null)
                            {
                                lblDatesNoPlay1.Text = datesNoPlay[division, team, 0];
                            }
                            else
                            {
                                //More than one no play dates
                                labels.Add(lblDatesNoPlayAll1);
                                metTabControl.SelectedTab.Controls.Add(lblDatesNoPlayAll1);
                                lblDatesNoPlayAll1.Location = new Point(800, 29);
                                lblDatesNoPlayAll1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                lblDatesNoPlayAll1.Hide();
                                lblDatesNoPlayAll1.Font = new Font("Nirmala UI Semilight", 12);
                                lblDatesNoPlay1.Text = datesNoPlay[division, team, 0] + "...";
                                lblDatesNoPlayAll1.Text = "...";

                                for (int i = 1; i < noPlayCount; i++)
                                {
                                    lblDatesNoPlayAll1.Text += datesNoPlay[division, team, i] + "\n";
                                }

                                lblDatesNoPlayAll1.Size = new Size(200, 25 * noPlayCount - 25);
                            }

                            lblNameDisp1.Text = name[division, team];
                            lblTeamName1.Font = new Font("Nirmala UI Semilight", 12);
                            lblNameDisp1.Font = new Font("Nirmala UI Semilight", 12);
                            lblSharedDisp1.Font = new Font("Nirmala UI Semilight", 12);
                            lblDatesHome1.Font = new Font("Nirmala UI Semilight", 12);
                            lblDatesNoPlay1.Font = new Font("Nirmala UI Semilight", 12);
                            lblSharedLabelDisp1.Font = new Font("Nirmala UI Semilight", 12);
                            lblPlayHomeDisp1.Font = new Font("Nirmala UI Semilight", 12);
                            lblNoPlayDisp1.Font = new Font("Nirmala UI Semilight", 12);
                            lblTeamName1.BackColor = Color.White;
                            lblNameDisp1.BackColor = Color.White;
                            lblSharedDisp1.BackColor = Color.White;
                            lblDatesHome1.BackColor = Color.White;
                            lblDatesNoPlay1.BackColor = Color.White;
                            lblSharedLabelDisp1.BackColor = Color.White;
                            lblPlayHomeDisp1.BackColor = Color.White;
                            lblNoPlayDisp1.BackColor = Color.White;
                            lblTeamName1.Size = new Size(55, 25);
                            lblNameDisp1.Size = new Size(200, 25);
                            lblSharedDisp1.Size = new Size(200, 25);
                            lblDatesHome1.Size = new Size(200, 25);
                            lblDatesNoPlay1.Size = new Size(200, 25);
                            del1.Size = new Size(60, 25);
                            #endregion
                            break;
                        case 2:
                            #region Display Team 3

                            #endregion
                            break;
                        case 3:
                            #region Display Team 4

                            #endregion
                            break;
                        case 4:
                            #region Display Team 4

                            #endregion
                            break;
                        case 5:
                            #region Display Team 5

                            #endregion
                            break;
                        case 6:
                            #region Display Team 6

                            #endregion
                            break;
                        case 7:
                            #region Display Team 7

                            #endregion
                            break;
                        case 8:
                            #region Display Team 8

                            #endregion
                            break;
                        case 9:
                            #region Display Team 9

                            #endregion
                            break;
                        case 10:
                            #region Display Team 10

                            #endregion
                            break;
                        case 11:
                            #region Display Team 11

                            #endregion
                            break;
                        case 12:
                            #region Display Team 12

                            #endregion
                            break;
                        default:

                            break;
                    }
                    #endregion
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