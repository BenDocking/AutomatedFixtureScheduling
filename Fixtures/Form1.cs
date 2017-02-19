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
        private string[,] name = new string[15, 15]; //Division, Team
        private string[, ,] shared = new string[15,15,4]; //Max 15 divisions, 15 teams, 4 teams for single grounds
        private string[, ,] datesHome = new string[15, 15, 13]; //Division, Team, Dates
        private string[, ,] datesNoPlay = new string[15, 15, 13]; //Division, Team, Dates

        private int division = 0;
        private int divCount = 0;
        private int[,] sharedCount = new int[15, 15]; //Shared count Division, Team
        private int[,] homeCount = new int[15, 15]; //homeCount Division, Team
        private int[,] noPlayCount = new int[15, 15]; //noPlayCount Division, Team
        private int[,] homeIndex = new int[15, 15];
        private int[,] noPlayIndex = new int[15, 15];
        private int newTabIndex = 1;
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
            #region Initialize
            txtName.Text = "Enter a team";
            txtName1.Text = "Enter a team";
            txtName2.Text = "Enter a team";
            txtName3.Text = "Enter a team";
            txtName4.Text = "Enter a team";
            txtName5.Text = "Enter a team";
            txtName6.Text = "Enter a team";
            txtName7.Text = "Enter a team";
            txtName8.Text = "Enter a team";
            txtName9.Text = "Enter a team";
            txtName10.Text = "Enter a team";
            txtName11.Text = "Enter a team";
            txtName12.Text = "Enter a team";
            txtName13.Text = "Enter a team";
            txtName14.Text = "Enter a team";
            txtShared.Text = "Enter a team";
            txtShared1.Text = "Enter a team";
            txtShared2.Text = "Enter a team";
            txtShared3.Text = "Enter a team";
            txtShared4.Text = "Enter a team";
            txtShared5.Text = "Enter a team";
            txtShared6.Text = "Enter a team";
            txtShared7.Text = "Enter a team";
            txtShared8.Text = "Enter a team";
            txtShared9.Text = "Enter a team";
            txtShared10.Text = "Enter a team";
            txtShared11.Text = "Enter a team";
            txtShared12.Text = "Enter a team";
            txtShared13.Text = "Enter a team";
            txtShared14.Text = "Enter a team";
            metTabControl.SelectedIndex = 0;
            cmbBoxHome.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome5.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome6.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome7.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome8.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome9.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome10.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome11.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome12.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome13.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxHome14.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay5.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay6.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay7.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay8.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay9.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay10.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay11.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay12.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay13.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNoPlay14.DropDownStyle = ComboBoxStyle.DropDownList;
            txtName.ForeColor = Color.Gray;
            txtName1.ForeColor = Color.Gray;
            txtName2.ForeColor = Color.Gray;
            txtName3.ForeColor = Color.Gray;
            txtName4.ForeColor = Color.Gray;
            txtName5.ForeColor = Color.Gray;
            txtName6.ForeColor = Color.Gray;
            txtName7.ForeColor = Color.Gray;
            txtName8.ForeColor = Color.Gray;
            txtName9.ForeColor = Color.Gray;
            txtName10.ForeColor = Color.Gray;
            txtName11.ForeColor = Color.Gray;
            txtName12.ForeColor = Color.Gray;
            txtName13.ForeColor = Color.Gray;
            txtName14.ForeColor = Color.Gray;
            txtShared.ForeColor = Color.Gray;
            txtShared1.ForeColor = Color.Gray;
            txtShared2.ForeColor = Color.Gray;
            txtShared3.ForeColor = Color.Gray;
            txtShared4.ForeColor = Color.Gray;
            txtShared5.ForeColor = Color.Gray;
            txtShared6.ForeColor = Color.Gray;
            txtShared7.ForeColor = Color.Gray;
            txtShared8.ForeColor = Color.Gray;
            txtShared9.ForeColor = Color.Gray;
            txtShared10.ForeColor = Color.Gray;
            txtShared11.ForeColor = Color.Gray;
            txtShared12.ForeColor = Color.Gray;
            txtShared13.ForeColor = Color.Gray;
            txtShared14.ForeColor = Color.Gray;
            #endregion

            //CODE

            
            
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

            //PlEngine.PlCleanup();
        }

        private void metTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = this.metTabControl.TabCount;
            //If new tab clicked, create new division
            if (metTabControl.SelectedIndex == newTabIndex)
            {
                if (newTabIndex < 15)
                {
                    //Create new tab
                    metTabControl.SelectedTab.Text = "Division " + (newTabIndex + 1);
                    this.metTabControl.TabPages.Insert(index, "Add Division +");
                    this.metTabControl.SelectedIndex = index - 1;
                    this.metTabControl.SelectedTab.BackColor = Color.White;
                    newTabIndex++;
                    divCount++;
                }
                else
                {
                    //Max divisions added
                    this.metTabControl.SelectedIndex = 14;
                    MessageBox.Show("Cannot add another division.", "Max divisions added", MessageBoxButtons.OK);
                }
            }

            if (newTabIndex < 16)
            {
                saveChanges();
                #region Move objects between tabs
                metTabControl.SelectedTab.Controls.Add(metroLabel2);
                metTabControl.SelectedTab.Controls.Add(metroLabel3);
                metTabControl.SelectedTab.Controls.Add(metroLabel4);
                metTabControl.SelectedTab.Controls.Add(metroLabel5);
                metTabControl.SelectedTab.Controls.Add(txtName);
                metTabControl.SelectedTab.Controls.Add(txtName1);
                metTabControl.SelectedTab.Controls.Add(txtName2);
                metTabControl.SelectedTab.Controls.Add(txtName3);
                metTabControl.SelectedTab.Controls.Add(txtName4);
                metTabControl.SelectedTab.Controls.Add(txtName5);
                metTabControl.SelectedTab.Controls.Add(txtName6);
                metTabControl.SelectedTab.Controls.Add(txtName7);
                metTabControl.SelectedTab.Controls.Add(txtName8);
                metTabControl.SelectedTab.Controls.Add(txtName9);
                metTabControl.SelectedTab.Controls.Add(txtName10);
                metTabControl.SelectedTab.Controls.Add(txtName11);
                metTabControl.SelectedTab.Controls.Add(txtName12);
                metTabControl.SelectedTab.Controls.Add(txtName13);
                metTabControl.SelectedTab.Controls.Add(txtName14);
                metTabControl.SelectedTab.Controls.Add(txtShared);
                metTabControl.SelectedTab.Controls.Add(txtShared1);
                metTabControl.SelectedTab.Controls.Add(txtShared2);
                metTabControl.SelectedTab.Controls.Add(txtShared3);
                metTabControl.SelectedTab.Controls.Add(txtShared4);
                metTabControl.SelectedTab.Controls.Add(txtShared5);
                metTabControl.SelectedTab.Controls.Add(txtShared6);
                metTabControl.SelectedTab.Controls.Add(txtShared7);
                metTabControl.SelectedTab.Controls.Add(txtShared8);
                metTabControl.SelectedTab.Controls.Add(txtShared9);
                metTabControl.SelectedTab.Controls.Add(txtShared10);
                metTabControl.SelectedTab.Controls.Add(txtShared11);
                metTabControl.SelectedTab.Controls.Add(txtShared12);
                metTabControl.SelectedTab.Controls.Add(txtShared13);
                metTabControl.SelectedTab.Controls.Add(txtShared14);
                metTabControl.SelectedTab.Controls.Add(btnShared);
                metTabControl.SelectedTab.Controls.Add(btnShared1);
                metTabControl.SelectedTab.Controls.Add(btnShared2);
                metTabControl.SelectedTab.Controls.Add(btnShared3);
                metTabControl.SelectedTab.Controls.Add(btnShared4);
                metTabControl.SelectedTab.Controls.Add(btnShared5);
                metTabControl.SelectedTab.Controls.Add(btnShared6);
                metTabControl.SelectedTab.Controls.Add(btnShared7);
                metTabControl.SelectedTab.Controls.Add(btnShared8);
                metTabControl.SelectedTab.Controls.Add(btnShared9);
                metTabControl.SelectedTab.Controls.Add(btnShared10);
                metTabControl.SelectedTab.Controls.Add(btnShared11);
                metTabControl.SelectedTab.Controls.Add(btnShared12);
                metTabControl.SelectedTab.Controls.Add(btnShared13);
                metTabControl.SelectedTab.Controls.Add(btnShared14);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome1);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome2);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome3);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome4);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome5);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome6);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome7);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome8);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome9);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome10);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome11);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome12);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome13);
                metTabControl.SelectedTab.Controls.Add(cmbBoxHome14);
                metTabControl.SelectedTab.Controls.Add(btnHome);
                metTabControl.SelectedTab.Controls.Add(btnHome1);
                metTabControl.SelectedTab.Controls.Add(btnHome2);
                metTabControl.SelectedTab.Controls.Add(btnHome3);
                metTabControl.SelectedTab.Controls.Add(btnHome4);
                metTabControl.SelectedTab.Controls.Add(btnHome5);
                metTabControl.SelectedTab.Controls.Add(btnHome6);
                metTabControl.SelectedTab.Controls.Add(btnHome7);
                metTabControl.SelectedTab.Controls.Add(btnHome8);
                metTabControl.SelectedTab.Controls.Add(btnHome9);
                metTabControl.SelectedTab.Controls.Add(btnHome10);
                metTabControl.SelectedTab.Controls.Add(btnHome11);
                metTabControl.SelectedTab.Controls.Add(btnHome12);
                metTabControl.SelectedTab.Controls.Add(btnHome13);
                metTabControl.SelectedTab.Controls.Add(btnHome14);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay1);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay2);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay3);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay4);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay5);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay6);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay7);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay8);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay9);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay10);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay11);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay12);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay13);
                metTabControl.SelectedTab.Controls.Add(cmbBoxNoPlay14);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay1);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay2);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay3);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay4);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay5);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay6);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay7);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay8);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay9);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay10);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay11);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay12);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay13);
                metTabControl.SelectedTab.Controls.Add(btnNoPlay14);
                metTabControl.SelectedTab.Controls.Add(btnRemove);
                metTabControl.SelectedTab.Controls.Add(btnRemove1);
                metTabControl.SelectedTab.Controls.Add(btnRemove2);
                metTabControl.SelectedTab.Controls.Add(btnRemove3);
                metTabControl.SelectedTab.Controls.Add(btnRemove4);
                metTabControl.SelectedTab.Controls.Add(btnRemove5);
                metTabControl.SelectedTab.Controls.Add(btnRemove6);
                metTabControl.SelectedTab.Controls.Add(btnRemove7);
                metTabControl.SelectedTab.Controls.Add(btnRemove8);
                metTabControl.SelectedTab.Controls.Add(btnRemove9);
                metTabControl.SelectedTab.Controls.Add(btnRemove10);
                metTabControl.SelectedTab.Controls.Add(btnRemove11);
                metTabControl.SelectedTab.Controls.Add(btnRemove12);
                metTabControl.SelectedTab.Controls.Add(btnRemove13);
                metTabControl.SelectedTab.Controls.Add(btnRemove14);
                metTabControl.SelectedTab.Controls.Add(lblBack);
                metTabControl.SelectedTab.Controls.Add(lblBack1);
                metTabControl.SelectedTab.Controls.Add(lblBack2);
                metTabControl.SelectedTab.Controls.Add(lblBack3);
                metTabControl.SelectedTab.Controls.Add(lblBack4);
                metTabControl.SelectedTab.Controls.Add(lblBack5);
                metTabControl.SelectedTab.Controls.Add(lblBack6);
                metTabControl.SelectedTab.Controls.Add(lblBack7);
                metTabControl.SelectedTab.Controls.Add(lblBack8);
                metTabControl.SelectedTab.Controls.Add(lblBack9);
                metTabControl.SelectedTab.Controls.Add(lblBack10);
                metTabControl.SelectedTab.Controls.Add(lblBack11);
                metTabControl.SelectedTab.Controls.Add(lblBack12);
                metTabControl.SelectedTab.Controls.Add(lblBack13);
                metTabControl.SelectedTab.Controls.Add(lblBack14);
                metTabControl.SelectedTab.Controls.Add(txtTeam);
                metTabControl.SelectedTab.Controls.Add(txtTeam1);
                metTabControl.SelectedTab.Controls.Add(txtTeam2);
                metTabControl.SelectedTab.Controls.Add(txtTeam3);
                metTabControl.SelectedTab.Controls.Add(txtTeam4);
                metTabControl.SelectedTab.Controls.Add(txtTeam5);
                metTabControl.SelectedTab.Controls.Add(txtTeam6);
                metTabControl.SelectedTab.Controls.Add(txtTeam7);
                metTabControl.SelectedTab.Controls.Add(txtTeam8);
                metTabControl.SelectedTab.Controls.Add(txtTeam9);
                metTabControl.SelectedTab.Controls.Add(txtTeam10);
                metTabControl.SelectedTab.Controls.Add(txtTeam11);
                metTabControl.SelectedTab.Controls.Add(txtTeam12);
                metTabControl.SelectedTab.Controls.Add(txtTeam13);
                metTabControl.SelectedTab.Controls.Add(txtTeam14);
                lblBack14.SendToBack();
                lblBack13.SendToBack();
                lblBack12.SendToBack();
                lblBack11.SendToBack();
                lblBack10.SendToBack();
                lblBack9.SendToBack();
                lblBack8.SendToBack();
                lblBack7.SendToBack();
                lblBack6.SendToBack();
                lblBack5.SendToBack();
                lblBack4.SendToBack();
                lblBack3.SendToBack();
                lblBack2.SendToBack();
                lblBack1.SendToBack();
                lblBack.SendToBack();
                txtName7.BringToFront();
                txtName8.BringToFront();
                txtShared7.BringToFront();
                txtShared8.BringToFront();
                btnShared7.BringToFront();
                btnShared8.BringToFront();
                cmbBoxHome7.BringToFront();
                cmbBoxHome8.BringToFront();
                btnHome7.BringToFront();
                btnHome8.BringToFront();
                cmbBoxNoPlay7.BringToFront();
                cmbBoxNoPlay8.BringToFront();
                btnNoPlay7.BringToFront();
                btnNoPlay8.BringToFront();
                btnRemove7.BringToFront();
                btnRemove8.BringToFront();
                txtTeam7.BringToFront();
                txtTeam8.BringToFront();
                #endregion
                #region Initialize tab
                txtName.Text = "Enter a team";
                txtName1.Text = "Enter a team";
                txtName2.Text = "Enter a team";
                txtName3.Text = "Enter a team";
                txtName4.Text = "Enter a team";
                txtName5.Text = "Enter a team";
                txtName6.Text = "Enter a team";
                txtName7.Text = "Enter a team";
                txtName8.Text = "Enter a team";
                txtName9.Text = "Enter a team";
                txtName10.Text = "Enter a team";
                txtName11.Text = "Enter a team";
                txtName12.Text = "Enter a team";
                txtName13.Text = "Enter a team";
                txtName14.Text = "Enter a team";
                txtShared.Text = "Enter a team";
                txtShared1.Text = "Enter a team";
                txtShared2.Text = "Enter a team";
                txtShared3.Text = "Enter a team";
                txtShared4.Text = "Enter a team";
                txtShared5.Text = "Enter a team";
                txtShared6.Text = "Enter a team";
                txtShared7.Text = "Enter a team";
                txtShared8.Text = "Enter a team";
                txtShared9.Text = "Enter a team";
                txtShared10.Text = "Enter a team";
                txtShared11.Text = "Enter a team";
                txtShared12.Text = "Enter a team";
                txtShared13.Text = "Enter a team";
                txtShared14.Text = "Enter a team";
                txtName.ForeColor = Color.Gray;
                txtName1.ForeColor = Color.Gray;
                txtName2.ForeColor = Color.Gray;
                txtName3.ForeColor = Color.Gray;
                txtName4.ForeColor = Color.Gray;
                txtName5.ForeColor = Color.Gray;
                txtName6.ForeColor = Color.Gray;
                txtName7.ForeColor = Color.Gray;
                txtName8.ForeColor = Color.Gray;
                txtName9.ForeColor = Color.Gray;
                txtName10.ForeColor = Color.Gray;
                txtName11.ForeColor = Color.Gray;
                txtName12.ForeColor = Color.Gray;
                txtName13.ForeColor = Color.Gray;
                txtName14.ForeColor = Color.Gray;
                txtShared.ForeColor = Color.Gray;
                txtShared1.ForeColor = Color.Gray;
                txtShared2.ForeColor = Color.Gray;
                txtShared3.ForeColor = Color.Gray;
                txtShared4.ForeColor = Color.Gray;
                txtShared5.ForeColor = Color.Gray;
                txtShared6.ForeColor = Color.Gray;
                txtShared7.ForeColor = Color.Gray;
                txtShared8.ForeColor = Color.Gray;
                txtShared9.ForeColor = Color.Gray;
                txtShared10.ForeColor = Color.Gray;
                txtShared11.ForeColor = Color.Gray;
                txtShared12.ForeColor = Color.Gray;
                txtShared13.ForeColor = Color.Gray;
                txtShared14.ForeColor = Color.Gray;
                cmbBoxHome.SelectedIndex = -1;
                cmbBoxHome1.SelectedIndex = -1;
                cmbBoxHome2.SelectedIndex = -1;
                cmbBoxHome3.SelectedIndex = -1;
                cmbBoxHome4.SelectedIndex = -1;
                cmbBoxHome5.SelectedIndex = -1;
                cmbBoxHome6.SelectedIndex = -1;
                cmbBoxHome7.SelectedIndex = -1;
                cmbBoxHome8.SelectedIndex = -1;
                cmbBoxHome9.SelectedIndex = -1;
                cmbBoxHome10.SelectedIndex = -1;
                cmbBoxHome11.SelectedIndex = -1;
                cmbBoxHome12.SelectedIndex = -1;
                cmbBoxHome13.SelectedIndex = -1;
                cmbBoxHome14.SelectedIndex = -1;
                cmbBoxNoPlay.SelectedIndex = -1;
                cmbBoxNoPlay1.SelectedIndex = -1;
                cmbBoxNoPlay2.SelectedIndex = -1;
                cmbBoxNoPlay3.SelectedIndex = -1;
                cmbBoxNoPlay4.SelectedIndex = -1;
                cmbBoxNoPlay5.SelectedIndex = -1;
                cmbBoxNoPlay6.SelectedIndex = -1;
                cmbBoxNoPlay7.SelectedIndex = -1;
                cmbBoxNoPlay8.SelectedIndex = -1;
                cmbBoxNoPlay9.SelectedIndex = -1;
                cmbBoxNoPlay10.SelectedIndex = -1;
                cmbBoxNoPlay11.SelectedIndex = -1;
                cmbBoxNoPlay12.SelectedIndex = -1;
                cmbBoxNoPlay13.SelectedIndex = -1;
                cmbBoxNoPlay14.SelectedIndex = -1;
                #endregion
                //Store value for current division
                division = metTabControl.SelectedIndex;
                #region Populate objects
                //Populate names
                //Loop through each team in selected division
                for (int i = 0; i < teamCount[division]+1; i++)
                {
                    switch(i)
                    {
                        case 0:
                            //Populate team 1
                            txtName.Text = name[division, 0];
                            if (sharedCount[division, 0] == 0)
                            {
                                txtShared.Text = "Enter a team";
                                txtShared.ForeColor = Color.Gray;
                            }
                            else 
                            {
                                txtShared.Text = shared[division, 0, sharedCount[division, 0]-1];
                                if (txtShared.Text == "")
                                {
                                    txtShared.Text = shared[division, 0, sharedCount[division, 0]-1];
                                }
                            }
                            if (homeCount[division, 0] == 0)
                            {
                                cmbBoxHome.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome.SelectedIndex = homeIndex[division, 0];
                            }
                            if (noPlayCount[division, 0] == 0)
                            {
                                cmbBoxNoPlay.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay.SelectedIndex = noPlayIndex[division, 0];
                            }
                            break;
                        case 1:
                            //Populate team 2
                            txtName1.Text = name[division, 1];
                            if (sharedCount[division, 1] == 0)
                            {
                                txtShared1.Text = "Enter a team";
                                txtShared1.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared1.Text = shared[division, 1, sharedCount[division, 1]];
                                if (txtShared1.Text == "")
                                {
                                    txtShared1.Text = shared[division, 1, sharedCount[division, 1] - 1];
                                }
                            }
                            if (homeCount[division, 1] == 0)
                            {
                                cmbBoxHome1.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome1.SelectedIndex = homeIndex[division, 1];
                            }
                            if (noPlayCount[division, 1] == 0)
                            {
                                cmbBoxNoPlay1.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay1.SelectedIndex = noPlayIndex[division, 1];
                            }
                            break;
                        case 2:
                            //Populate team 3
                            txtName2.Text = name[division, 2];
                            if (sharedCount[division, 2] == 0)
                            {
                                txtShared2.Text = "Enter a team";
                                txtShared2.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared2.Text = shared[division, 2, sharedCount[division, 2]];
                                if (txtShared2.Text == "")
                                {
                                    txtShared2.Text = shared[division, 2, sharedCount[division, 2] - 1];
                                }
                            }
                            if (homeCount[division, 2] == 0)
                            {
                                cmbBoxHome2.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome2.SelectedIndex = homeIndex[division, 2];
                            }
                            if (noPlayCount[division, 2] == 0)
                            {
                                cmbBoxNoPlay2.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay2.SelectedIndex = noPlayIndex[division, 2];
                            }
                            break;
                        case 3:
                            //Populate team 4
                            txtName3.Text = name[division, 3];
                            if (sharedCount[division, 3] == 0)
                            {
                                txtShared3.Text = "Enter a team";
                                txtShared3.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared3.Text = shared[division, 3, sharedCount[division, 3]];
                                if (txtShared3.Text == "")
                                {
                                    txtShared3.Text = shared[division, 3, sharedCount[division, 3] - 1];
                                }
                            }
                            if (homeCount[division, 3] == 0)
                            {
                                cmbBoxHome3.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome3.SelectedIndex = homeIndex[division, 3];
                            }
                            if (noPlayCount[division, 3] == 0)
                            {
                                cmbBoxNoPlay3.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay3.SelectedIndex = noPlayIndex[division, 3];
                            }
                            break;
                        case 4:
                            //Populate team 5
                            txtName4.Text = name[division, 4];
                            if (sharedCount[division, 4] == 0)
                            {
                                txtShared4.Text = "Enter a team";
                                txtShared4.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared4.Text = shared[division, 4, sharedCount[division, 4]];
                                if (txtShared4.Text == "")
                                {
                                    txtShared4.Text = shared[division, 4, sharedCount[division, 4] - 1];
                                }
                            }
                            if (homeCount[division, 4] == 0)
                            {
                                cmbBoxHome4.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome4.SelectedIndex = homeIndex[division, 4];
                            }
                            if (noPlayCount[division, 4] == 0)
                            {
                                cmbBoxNoPlay4.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay4.SelectedIndex = noPlayIndex[division, 4];
                            }
                            break;
                        case 5:
                            //Populate team 6
                            txtName5.Text = name[division, 5];
                            if (sharedCount[division, 5] == 0)
                            {
                                txtShared5.Text = "Enter a team";
                                txtShared5.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared5.Text = shared[division, 5, sharedCount[division, 5]];
                                if (txtShared5.Text == "")
                                {
                                    txtShared5.Text = shared[division, 5, sharedCount[division, 5] - 1];
                                }
                            }
                            if (homeCount[division, 5] == 0)
                            {
                                cmbBoxHome5.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome5.SelectedIndex = homeIndex[division, 5];
                            }
                            if (noPlayCount[division, 5] == 0)
                            {
                                cmbBoxNoPlay5.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay5.SelectedIndex = noPlayIndex[division, 5];
                            }
                            break;
                        case 6:
                            //Populate team 7
                            txtName6.Text = name[division, 6];
                            if (sharedCount[division, 6] == 0)
                            {
                                txtShared6.Text = "Enter a team";
                                txtShared6.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared6.Text = shared[division, 6, sharedCount[division, 6]];
                                if (txtShared6.Text == "")
                                {
                                    txtShared6.Text = shared[division, 6, sharedCount[division, 6] - 1];
                                }
                            }
                            if (homeCount[division, 6] == 0)
                            {
                                cmbBoxHome6.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome6.SelectedIndex = homeIndex[division, 6];
                            }
                            if (noPlayCount[division, 6] == 0)
                            {
                                cmbBoxNoPlay6.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay6.SelectedIndex = noPlayIndex[division, 6];
                            }
                            break;
                        case 7:
                            //Populate team 8
                            txtName7.Text = name[division, 7];
                            if (sharedCount[division, 7] == 0)
                            {
                                txtShared7.Text = "Enter a team";
                                txtShared7.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared7.Text = shared[division, 7, sharedCount[division, 7]];
                                if (txtShared7.Text == "")
                                {
                                    txtShared7.Text = shared[division, 7, sharedCount[division, 7] - 1];
                                }
                            }
                            if (homeCount[division, 7] == 0)
                            {
                                cmbBoxHome7.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome7.SelectedIndex = homeIndex[division, 7];
                            }
                            if (noPlayCount[division, 7] == 0)
                            {
                                cmbBoxNoPlay7.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay7.SelectedIndex = noPlayIndex[division, 7];
                            }
                            break;
                        case 8:
                            //Populate team 9
                            txtName8.Text = name[division, 8];
                            if (sharedCount[division, 8] == 8)
                            {
                                txtShared8.Text = "Enter a team";
                                txtShared8.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared8.Text = shared[division, 8, sharedCount[division, 8]];
                                if (txtShared8.Text == "")
                                {
                                    txtShared8.Text = shared[division, 8, sharedCount[division, 8] - 1];
                                }
                            }
                            if (homeCount[division, 8] == 0)
                            {
                                cmbBoxHome8.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome8.SelectedIndex = homeIndex[division, 8];
                            }
                            if (noPlayCount[division, 8] == 0)
                            {
                                cmbBoxNoPlay8.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay8.SelectedIndex = noPlayIndex[division, 8];
                            }
                            break;
                        case 9:
                            //Populate team 10
                            txtName9.Text = name[division, 9];
                            if (sharedCount[division, 9] == 0)
                            {
                                txtShared9.Text = "Enter a team";
                                txtShared9.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared9.Text = shared[division, 9, sharedCount[division, 9]];
                                if (txtShared9.Text == "")
                                {
                                    txtShared9.Text = shared[division, 9, sharedCount[division, 9] - 1];
                                }
                            }
                            if (homeCount[division, 9] == 0)
                            {
                                cmbBoxHome9.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome9.SelectedIndex = homeIndex[division, 9];
                            }
                            if (noPlayCount[division, 9] == 0)
                            {
                                cmbBoxNoPlay9.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay9.SelectedIndex = noPlayIndex[division, 9];
                            }
                            break;
                        case 10:
                            //Populate team 11
                            txtName10.Text = name[division, 10];
                            if (sharedCount[division, 10] == 0)
                            {
                                txtShared10.Text = "Enter a team";
                                txtShared10.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared10.Text = shared[division, 10, sharedCount[division, 10]];
                                if (txtShared10.Text == "")
                                {
                                    txtShared10.Text = shared[division, 10, sharedCount[division, 10] - 1];
                                }
                            }
                            if (homeCount[division, 10] == 0)
                            {
                                cmbBoxHome10.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome10.SelectedIndex = homeIndex[division, 10];
                            }
                            if (noPlayCount[division, 10] == 0)
                            {
                                cmbBoxNoPlay10.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay10.SelectedIndex = noPlayIndex[division, 10];
                            }
                            break;
                        case 11:
                            //Populate team 12
                            txtName11.Text = name[division, 11];
                            if (sharedCount[division, 11] == 0)
                            {
                                txtShared11.Text = "Enter a team";
                                txtShared11.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared11.Text = shared[division, 11, sharedCount[division, 11]];
                                if (txtShared11.Text == "")
                                {
                                    txtShared11.Text = shared[division, 11, sharedCount[division, 11] - 1];
                                }
                            }
                            if (homeCount[division, 11] == 0)
                            {
                                cmbBoxHome11.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome11.SelectedIndex = homeIndex[division, 11];
                            }
                            if (noPlayCount[division, 11] == 0)
                            {
                                cmbBoxNoPlay11.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay11.SelectedIndex = noPlayIndex[division, 11];
                            }
                            break;
                        case 12:
                            //Populate team 13
                            txtName12.Text = name[division, 12];
                            if (sharedCount[division, 12] == 0)
                            {
                                txtShared12.Text = "Enter a team";
                                txtShared12.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared12.Text = shared[division, 12, sharedCount[division, 12]];
                                if (txtShared12.Text == "")
                                {
                                    txtShared12.Text = shared[division, 12, sharedCount[division, 12] - 1];
                                }
                            }
                            if (homeCount[division, 12] == 0)
                            {
                                cmbBoxHome12.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome12.SelectedIndex = homeIndex[division, 12];
                            }
                            if (noPlayCount[division, 12] == 0)
                            {
                                cmbBoxNoPlay12.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay12.SelectedIndex = noPlayIndex[division, 12];
                            }
                            break;
                        case 13:
                            //Populate team 14
                            txtName13.Text = name[division, 13];
                            if (sharedCount[division, 13] == 0)
                            {
                                txtShared13.Text = "Enter a team";
                                txtShared13.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared13.Text = shared[division, 13, sharedCount[division, 13]];
                                if (txtShared13.Text == "")
                                {
                                    txtShared13.Text = shared[division, 13, sharedCount[division, 13] - 1];
                                }
                            }
                            if (homeCount[division, 13] == 0)
                            {
                                cmbBoxHome13.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome13.SelectedIndex = homeIndex[division, 13];
                            }
                            if (noPlayCount[division, 13] == 0)
                            {
                                cmbBoxNoPlay13.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay13.SelectedIndex = noPlayIndex[division, 13];
                            }
                            break;
                        case 14:
                            //Populate team 15
                            txtName14.Text = name[division, 14];
                            if (sharedCount[division, 14] == 0)
                            {
                                txtShared14.Text = "Enter a team";
                                txtShared14.ForeColor = Color.Gray;
                            }
                            else
                            {
                                txtShared14.Text = shared[division, 14, sharedCount[division, 14]];
                                if (txtShared14.Text == "")
                                {
                                    txtShared14.Text = shared[division, 14, sharedCount[division, 14] - 1];
                                }
                            }
                            if (homeCount[division, 14] == 0)
                            {
                                cmbBoxHome14.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxHome14.SelectedIndex = homeIndex[division, 14];
                            }
                            if (noPlayCount[division, 14] == 0)
                            {
                                cmbBoxNoPlay14.SelectedIndex = -1;
                            }
                            else
                            {
                                cmbBoxNoPlay14.SelectedIndex = noPlayIndex[division, 14];
                            }
                            break;
                    }
                }
                #endregion
            }
        }                

        private void txt_TextChanged(object sender, EventArgs e)
        {
            //Set colour to black
            TextBox txtBox = (TextBox)sender;
            txtBox.ForeColor = Color.Black;
        }

        private void txt_Click(object sender, EventArgs e)
        {
            //Remove text so user can type
            TextBox txtBox = (TextBox)sender;
            if (txtBox.Text == "Enter a team")
            {
                txtBox.Text = "";
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            DialogResult calc = MessageBox.Show("Are you sure you are ready to calculate?", "Calculate", MessageBoxButtons.YesNo);
            if (calc == DialogResult.Yes)
            {
                //Save changes made to current division
                saveChanges();
                //Begin calculating! (Prolog)
                //Assert teams + params
                divCount++;
                for (int d = 0; d < divCount; d++)
                {
                    for (int t = 0; t < teamCount[d]; t++)
                    {
                        PlQuery.PlCall("assert(team(" + name[d, t] + "))");

                        for (int i = 0; i < sharedCount[d, t]; i++)
                        {
                            PlQuery.PlCall("assert(sharedGrounds(" + name[d, t] + ", " + shared[d, t, i] + "))");
                        }
                        for (int i = 0; i < homeCount[d, t]; i++)
                        {
                            PlQuery.PlCall("assert(home(" + name[d, t] + ", " + datesHome[d, t, i] + "))");
                        }
                        for (int i = 0; i < noPlayCount[d, t]; i++)
                        {
                            PlQuery.PlCall("assert(noPlay(" + name[d, t] + ", " + datesNoPlay[d, t, i] + "))");
                        }
                    }
                }
            }
        }

        private void btnShared_Click(object sender, EventArgs e)
        {
            string input = txtShared.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 0] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 0]; i++)
                {
                    if (txtShared.Text == shared[division, 0, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 0, sharedCount[division, 0]] = txtShared.Text;
                    sharedCount[division, 0]++;
                }
                //Reset text to type new team name
                txtShared.Text = "";
                txtShared.Focus();
            }
        }

        private void btnShared1_Click(object sender, EventArgs e)
        {
            string input = txtShared1.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 1] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared1.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 1]; i++)
                {
                    if (txtShared1.Text == shared[division, 1, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 1, sharedCount[division, 1]] = txtShared1.Text;
                    sharedCount[division, 1]++;
                }
                //Reset text to type new team name
                txtShared1.Text = "";
                txtShared1.Focus();
            }
        }

        private void btnShared2_Click(object sender, EventArgs e)
        {
            string input = txtShared2.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 2] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared2.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 2]; i++)
                {
                    if (txtShared2.Text == shared[division, 2, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 2, sharedCount[division, 2]] = txtShared2.Text;
                    sharedCount[division, 2]++;
                }
                //Reset text to type new team name
                txtShared2.Text = "";
                txtShared2.Focus();
            }
        }

        private void btnShared3_Click(object sender, EventArgs e)
        {
            string input = txtShared3.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 3] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared3.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 3]; i++)
                {
                    if (txtShared3.Text == shared[division, 3, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 3, sharedCount[division, 3]] = txtShared3.Text;
                    sharedCount[division, 3]++;
                }
                //Reset text to type new team name
                txtShared3.Text = "";
                txtShared3.Focus();
            }
        }

        private void btnShared4_Click(object sender, EventArgs e)
        {
            string input = txtShared4.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 4] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared4.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 4]; i++)
                {
                    if (txtShared4.Text == shared[division, 4, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 4, sharedCount[division, 4]] = txtShared4.Text;
                    sharedCount[division, 4]++;
                }
                //Reset text to type new team name
                txtShared4.Text = "";
                txtShared4.Focus();
            }
        }

        private void btnShared5_Click(object sender, EventArgs e)
        {
            string input = txtShared5.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 5] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared5.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 5]; i++)
                {
                    if (txtShared5.Text == shared[division, 5, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 5, sharedCount[division, 5]] = txtShared5.Text;
                    sharedCount[division, 2]++;
                }
                //Reset text to type new team name
                txtShared5.Text = "";
                txtShared5.Focus();
            }
        }

        private void btnShared6_Click(object sender, EventArgs e)
        {
            string input = txtShared6.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 6] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared6.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 6]; i++)
                {
                    if (txtShared6.Text == shared[division, 6, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 6, sharedCount[division, 6]] = txtShared6.Text;
                    sharedCount[division, 6]++;
                }
                //Reset text to type new team name
                txtShared6.Text = "";
                txtShared6.Focus();
            }
        }

        private void btnShared7_Click(object sender, EventArgs e)
        {
            string input = txtShared7.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 7] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared7.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 7]; i++)
                {
                    if (txtShared7.Text == shared[division, 7, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 7, sharedCount[division, 7]] = txtShared7.Text;
                    sharedCount[division, 7]++;
                }
                //Reset text to type new team name
                txtShared7.Text = "";
                txtShared7.Focus();
            }
        }

        private void btnShared8_Click(object sender, EventArgs e)
        {
            string input = txtShared8.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 8] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared8.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 8]; i++)
                {
                    if (txtShared8.Text == shared[division, 8, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 8, sharedCount[division, 8]] = txtShared8.Text;
                    sharedCount[division, 8]++;
                }
                //Reset text to type new team name
                txtShared8.Text = "";
                txtShared8.Focus();
            }
        }

        private void btnShared9_Click(object sender, EventArgs e)
        {
            string input = txtShared9.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 9] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared9.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 9]; i++)
                {
                    if (txtShared9.Text == shared[division, 9, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 9, sharedCount[division, 9]] = txtShared9.Text;
                    sharedCount[division, 9]++;
                }
                //Reset text to type new team name
                txtShared9.Text = "";
                txtShared9.Focus();
            }
        }

        private void btnShared10_Click(object sender, EventArgs e)
        {
            string input = txtShared10.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 10] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared10.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 10]; i++)
                {
                    if (txtShared10.Text == shared[division, 10, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 10, sharedCount[division, 10]] = txtShared10.Text;
                    sharedCount[division, 10]++;
                }
                //Reset text to type new team name
                txtShared10.Text = "";
                txtShared10.Focus();
            }
        }

        private void btnShared11_Click(object sender, EventArgs e)
        {
            string input = txtShared11.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 11] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared11.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 11]; i++)
                {
                    if (txtShared11.Text == shared[division, 11, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 11, sharedCount[division, 11]] = txtShared11.Text;
                    sharedCount[division, 11]++;
                }
                //Reset text to type new team name
                txtShared11.Text = "";
                txtShared11.Focus();
            }
        }

        private void btnShared12_Click(object sender, EventArgs e)
        {
            string input = txtShared12.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 12] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared12.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 12]; i++)
                {
                    if (txtShared12.Text == shared[division, 12, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 12, sharedCount[division, 12]] = txtShared12.Text;
                    sharedCount[division, 12]++;
                }
                //Reset text to type new team name
                txtShared12.Text = "";
                txtShared12.Focus();
            }
        }

        private void btnShared13_Click(object sender, EventArgs e)
        {
            string input = txtShared13.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 13] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared13.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 13]; i++)
                {
                    if (txtShared13.Text == shared[division, 13, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 13, sharedCount[division, 13]] = txtShared13.Text;
                    sharedCount[division, 13]++;
                }
                //Reset text to type new team name
                txtShared13.Text = "";
                txtShared13.Focus();
            }
        }

        private void btnShared14_Click(object sender, EventArgs e)
        {
            string input = txtShared14.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[division, 14] > 2)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared14.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[division, 14]; i++)
                {
                    if (txtShared14.Text == shared[division, 14, i])
                    {
                        MessageBox.Show("The team has already been added.", "Team already added to shared", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    shared[division, 14, sharedCount[division, 14]] = txtShared14.Text;
                    sharedCount[division, 14]++;
                }
                //Reset text to type new team name
                txtShared14.Text = "";
                txtShared14.Focus();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 0] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome.Text != "")
            {
                for (int i = 0; i < homeCount[division, 0]; i++)
                {
                    if (cmbBoxHome.Text == datesHome[division, 0, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 0, homeCount[division, 0]] = cmbBoxHome.Text;
                    homeCount[division, 0]++;
                    homeIndex[division, 0] = cmbBoxHome.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome.SelectedIndex = -1;
            }
        }

        private void btnHome1_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 1] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome1.Text != "")
            {
                for (int i = 0; i < homeCount[division, 1]; i++)
                {
                    if (cmbBoxHome1.Text == datesHome[division, 1, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 1, homeCount[division, 1]] = cmbBoxHome1.Text;
                    homeCount[division, 1]++;
                    homeIndex[division, 1] = cmbBoxHome1.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome1.SelectedIndex = -1;
            }
        }

        private void btnHome2_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 2] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome2.Text != "")
            {
                for (int i = 0; i < homeCount[division, 2]; i++)
                {
                    if (cmbBoxHome2.Text == datesHome[division, 2, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 2, homeCount[division, 2]] = cmbBoxHome2.Text;
                    homeCount[division, 2]++;
                    homeIndex[division, 2] = cmbBoxHome2.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome2.SelectedIndex = -1;
            }
        }

        private void btnHome3_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 3] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome3.Text != "")
            {
                for (int i = 0; i < homeCount[division, 3]; i++)
                {
                    if (cmbBoxHome3.Text == datesHome[division, 3, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 3, homeCount[division, 3]] = cmbBoxHome3.Text;
                    homeCount[division, 3]++;
                    homeIndex[division, 3] = cmbBoxHome3.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome3.SelectedIndex = -1;
            }
        }

        private void btnHome4_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 4] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome4.Text != "")
            {
                for (int i = 0; i < homeCount[division, 4]; i++)
                {
                    if (cmbBoxHome4.Text == datesHome[division, 4, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 4, homeCount[division, 4]] = cmbBoxHome4.Text;
                    homeCount[division, 4]++;
                    homeIndex[division, 4] = cmbBoxHome4.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome4.SelectedIndex = -1;
            }
        }

        private void btnHome5_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 5] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome5.Text != "")
            {
                for (int i = 0; i < homeCount[division, 5]; i++)
                {
                    if (cmbBoxHome5.Text == datesHome[division, 5, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 5, homeCount[division, 5]] = cmbBoxHome5.Text;
                    homeCount[division, 5]++;
                    homeIndex[division, 5] = cmbBoxHome5.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome5.SelectedIndex = -1;
            }
        }

        private void btnHome6_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 6] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome6.Text != "")
            {
                for (int i = 0; i < homeCount[division, 6]; i++)
                {
                    if (cmbBoxHome6.Text == datesHome[division, 6, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 6, homeCount[division, 6]] = cmbBoxHome6.Text;
                    homeCount[division, 6]++;
                    homeIndex[division, 6] = cmbBoxHome6.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome6.SelectedIndex = -1;
            }
        }

        private void btnHome7_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 7] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome7.Text != "")
            {
                for (int i = 0; i < homeCount[division, 7]; i++)
                {
                    if (cmbBoxHome7.Text == datesHome[division, 7, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 7, homeCount[division, 7]] = cmbBoxHome.Text;
                    homeCount[division, 7]++;
                    homeIndex[division, 7] = cmbBoxHome7.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome7.SelectedIndex = -1;
            }
        }

        private void btnHome8_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 8] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome8.Text != "")
            {
                for (int i = 0; i < homeCount[division, 8]; i++)
                {
                    if (cmbBoxHome8.Text == datesHome[division, 8, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 8, homeCount[division, 8]] = cmbBoxHome8.Text;
                    homeCount[division, 8]++;
                    homeIndex[division, 8] = cmbBoxHome8.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome8.SelectedIndex = -1;
            }
        }

        private void btnHome9_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 9] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome9.Text != "")
            {
                for (int i = 0; i < homeCount[division, 9]; i++)
                {
                    if (cmbBoxHome9.Text == datesHome[division, 9, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 9, homeCount[division, 9]] = cmbBoxHome9.Text;
                    homeCount[division, 9]++;
                    homeIndex[division, 9] = cmbBoxHome9.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome9.SelectedIndex = -1;
            }
        }

        private void btnHome10_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 10] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome10.Text != "")
            {
                for (int i = 0; i < homeCount[division, 10]; i++)
                {
                    if (cmbBoxHome10.Text == datesHome[division, 10, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 10, homeCount[division, 10]] = cmbBoxHome10.Text;
                    homeCount[division, 10]++;
                    homeIndex[division, 10] = cmbBoxHome10.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome10.SelectedIndex = -1;
            }
        }

        private void btnHome11_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 11] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome11.Text != "")
            {
                for (int i = 0; i < homeCount[division, 11]; i++)
                {
                    if (cmbBoxHome11.Text == datesHome[division, 11, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 11, homeCount[division, 11]] = cmbBoxHome11.Text;
                    homeCount[division, 11]++;
                    homeIndex[division, 11] = cmbBoxHome11.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome11.SelectedIndex = -1;
            }
        }

        private void btnHome12_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 12] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome12.Text != "")
            {
                for (int i = 0; i < homeCount[division, 12]; i++)
                {
                    if (cmbBoxHome12.Text == datesHome[division, 12, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 12, homeCount[division, 12]] = cmbBoxHome12.Text;
                    homeCount[division, 12]++;
                    homeIndex[division, 12] = cmbBoxHome12.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome12.SelectedIndex = -1;
            }
        }

        private void btnHome13_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 13] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome13.Text != "")
            {
                for (int i = 0; i < homeCount[division, 13]; i++)
                {
                    if (cmbBoxHome13.Text == datesHome[division, 13, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 13, homeCount[division, 13]] = cmbBoxHome13.Text;
                    homeCount[division, 13]++;
                    homeIndex[division, 13] = cmbBoxHome13.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome13.SelectedIndex = -1;
            }
        }

        private void btnHome14_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[division, 14] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome14.Text != "")
            {
                for (int i = 0; i < homeCount[division, 14]; i++)
                {
                    if (cmbBoxHome14.Text == datesHome[division, 14, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates home", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesHome[division, 14, homeCount[division, 14]] = cmbBoxHome14.Text;
                    homeCount[division, 14]++;
                    homeIndex[division, 14] = cmbBoxHome14.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxHome14.SelectedIndex = -1;
            }
        }

        private void btnNoPlay_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 0] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 0]; i++)
                {
                    if (cmbBoxNoPlay.Text == datesNoPlay[division, 0, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 0, noPlayCount[division, 0]] = cmbBoxNoPlay.Text;
                    noPlayCount[division, 0]++;
                    noPlayIndex[division, 0] = cmbBoxNoPlay.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay.SelectedIndex = -1;
            }
        }

        private void btnNoPlay1_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 1] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay1.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 1]; i++)
                {
                    if (cmbBoxNoPlay1.Text == datesNoPlay[division, 1, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 1, noPlayCount[division, 1]] = cmbBoxNoPlay1.Text;
                    noPlayCount[division, 1]++;
                    noPlayIndex[division, 1] = cmbBoxNoPlay1.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay1.SelectedIndex = -1;
            }
        }

        private void btnNoPlay2_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 2] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay2.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 2]; i++)
                {
                    if (cmbBoxNoPlay2.Text == datesNoPlay[division, 2, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 2, noPlayCount[division, 2]] = cmbBoxNoPlay2.Text;
                    noPlayCount[division, 2]++;
                    noPlayIndex[division, 2] = cmbBoxNoPlay2.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay2.SelectedIndex = -1;
            }
        }

        private void btnNoPlay3_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 3] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay3.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 3]; i++)
                {
                    if (cmbBoxNoPlay3.Text == datesNoPlay[division, 3, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 3, noPlayCount[division, 3]] = cmbBoxNoPlay3.Text;
                    noPlayCount[division, 3]++;
                    noPlayIndex[division, 3] = cmbBoxNoPlay3.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay3.SelectedIndex = -1;
            }
        }

        private void btnNoPlay4_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 4] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay4.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 4]; i++)
                {
                    if (cmbBoxNoPlay4.Text == datesNoPlay[division, 4, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 4, noPlayCount[division, 4]] = cmbBoxNoPlay4.Text;
                    noPlayCount[division, 4]++;
                    noPlayIndex[division, 4] = cmbBoxNoPlay4.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay4.SelectedIndex = -1;
            }
        }

        private void btnNoPlay5_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 5] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay5.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 5]; i++)
                {
                    if (cmbBoxNoPlay5.Text == datesNoPlay[division, 5, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 5, noPlayCount[division, 5]] = cmbBoxNoPlay5.Text;
                    noPlayCount[division, 5]++;
                    noPlayIndex[division, 5] = cmbBoxNoPlay5.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay5.SelectedIndex = -1;
            }
        }

        private void btnNoPlay6_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 6] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay6.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 6]; i++)
                {
                    if (cmbBoxNoPlay6.Text == datesNoPlay[division, 6, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 6, noPlayCount[division, 6]] = cmbBoxNoPlay6.Text;
                    noPlayCount[division, 6]++;
                    noPlayIndex[division, 6] = cmbBoxNoPlay6.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay6.SelectedIndex = -1;
            }
        }

        private void btnNoPlay7_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 7] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay7.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 7]; i++)
                {
                    if (cmbBoxNoPlay7.Text == datesNoPlay[division, 7, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 7, noPlayCount[division, 7]] = cmbBoxNoPlay7.Text;
                    noPlayCount[division, 7]++;
                    noPlayIndex[division, 7] = cmbBoxNoPlay7.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay7.SelectedIndex = -1;
            }
        }

        private void btnNoPlay8_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 8] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay8.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 8]; i++)
                {
                    if (cmbBoxNoPlay8.Text == datesNoPlay[division, 8, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 8, noPlayCount[division, 8]] = cmbBoxNoPlay8.Text;
                    noPlayCount[division, 8]++;
                    noPlayIndex[division, 8] = cmbBoxNoPlay8.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay8.SelectedIndex = -1;
            }
        }

        private void btnNoPlay9_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 9] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay9.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 9]; i++)
                {
                    if (cmbBoxNoPlay9.Text == datesNoPlay[division, 9, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 9, noPlayCount[division, 9]] = cmbBoxNoPlay9.Text;
                    noPlayCount[division, 9]++;
                    noPlayIndex[division, 9] = cmbBoxNoPlay9.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay9.SelectedIndex = -1;
            }
        }

        private void btnNoPlay10_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 10] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay10.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 10]; i++)
                {
                    if (cmbBoxNoPlay10.Text == datesNoPlay[division, 10, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 10, noPlayCount[division, 10]] = cmbBoxNoPlay10.Text;
                    noPlayCount[division, 10]++;
                    noPlayIndex[division, 10] = cmbBoxNoPlay10.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay10.SelectedIndex = -1;
            }
        }

        private void btnNoPlay11_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 11] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay11.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 11]; i++)
                {
                    if (cmbBoxNoPlay11.Text == datesNoPlay[division, 11, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 11, noPlayCount[division, 11]] = cmbBoxNoPlay11.Text;
                    noPlayCount[division, 11]++;
                    noPlayIndex[division, 11] = cmbBoxNoPlay11.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay11.SelectedIndex = -1;
            }
        }

        private void btnNoPlay12_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 12] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay12.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 12]; i++)
                {
                    if (cmbBoxNoPlay12.Text == datesNoPlay[division, 12, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 12, noPlayCount[division, 12]] = cmbBoxNoPlay12.Text;
                    noPlayCount[division, 12]++;
                    noPlayIndex[division, 12] = cmbBoxNoPlay12.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay12.SelectedIndex = -1;
            }
        }

        private void btnNoPlay13_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 13] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay13.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 13]; i++)
                {
                    if (cmbBoxNoPlay13.Text == datesNoPlay[division, 13, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 13, noPlayCount[division, 13]] = cmbBoxNoPlay13.Text;
                    noPlayCount[division, 13]++;
                    noPlayIndex[division, 13] = cmbBoxNoPlay13.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay13.SelectedIndex = -1;
            }
        }

        private void btnNoPlay14_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[division, 14] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay14.Text != "")
            {
                for (int i = 0; i < noPlayCount[division, 14]; i++)
                {
                    if (cmbBoxNoPlay14.Text == datesNoPlay[division, 14, i])
                    {
                        MessageBox.Show("The date has already been added.", "Date already added to dates not playing", MessageBoxButtons.OK);
                        check = true;
                    }
                }
                if (check == false)
                {
                    //Save current
                    datesNoPlay[division, 14, noPlayCount[division, 14]] = cmbBoxNoPlay14.Text;
                    noPlayCount[division, 14]++;
                    noPlayIndex[division, 14] = cmbBoxNoPlay14.SelectedIndex;
                }
                //Reset text to type new team name
                cmbBoxNoPlay14.SelectedIndex = -1;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(0);

                txtName.Text = "Enter a team";
                txtName.ForeColor = Color.Gray;
                txtShared.Text = "Enter a team";
                txtShared.ForeColor = Color.Gray;
                cmbBoxHome.SelectedIndex = -1;
                cmbBoxNoPlay.SelectedIndex = -1;
            }
        }

        private void btnRemove1_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(1);

                txtName1.Text = "Enter a team";
                txtName1.ForeColor = Color.Gray;
                txtShared1.Text = "Enter a team";
                txtShared1.ForeColor = Color.Gray;
                cmbBoxHome1.SelectedIndex = -1;
                cmbBoxNoPlay1.SelectedIndex = -1;
            }
        }

        private void btnRemove2_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(2);

                txtName2.Text = "Enter a team";
                txtName2.ForeColor = Color.Gray;
                txtShared2.Text = "Enter a team";
                txtShared2.ForeColor = Color.Gray;
                cmbBoxHome2.SelectedIndex = -1;
                cmbBoxNoPlay2.SelectedIndex = -1;
            }
        }

        private void btnRemove3_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(3);

                txtName3.Text = "Enter a team";
                txtName3.ForeColor = Color.Gray;
                txtShared3.Text = "Enter a team";
                txtShared3.ForeColor = Color.Gray;
                cmbBoxHome3.SelectedIndex = -1;
                cmbBoxNoPlay3.SelectedIndex = -1;
            }
        }

        private void btnRemove4_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(4);

                txtName4.Text = "Enter a team";
                txtName4.ForeColor = Color.Gray;
                txtShared4.Text = "Enter a team";
                txtShared4.ForeColor = Color.Gray;
                cmbBoxHome4.SelectedIndex = -1;
                cmbBoxNoPlay4.SelectedIndex = -1;
            }
        }

        private void btnRemove5_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(5);

                txtName5.Text = "Enter a team";
                txtName5.ForeColor = Color.Gray;
                txtShared5.Text = "Enter a team";
                txtShared5.ForeColor = Color.Gray;
                cmbBoxHome5.SelectedIndex = -1;
                cmbBoxNoPlay5.SelectedIndex = -1;
            }
        }

        private void btnRemove6_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(6);

                txtName6.Text = "Enter a team";
                txtName6.ForeColor = Color.Gray;
                txtShared6.Text = "Enter a team";
                txtShared6.ForeColor = Color.Gray;
                cmbBoxHome6.SelectedIndex = -1;
                cmbBoxNoPlay6.SelectedIndex = -1;
            }
        }

        private void btnRemove7_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(7);

                txtName7.Text = "Enter a team";
                txtName7.ForeColor = Color.Gray;
                txtShared7.Text = "Enter a team";
                txtShared7.ForeColor = Color.Gray;
                cmbBoxHome7.SelectedIndex = -1;
                cmbBoxNoPlay7.SelectedIndex = -1;
            }
        }

        private void btnRemove8_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(8);

                txtName8.Text = "Enter a team";
                txtName8.ForeColor = Color.Gray;
                txtShared8.Text = "Enter a team";
                txtShared8.ForeColor = Color.Gray;
                cmbBoxHome8.SelectedIndex = -1;
                cmbBoxNoPlay8.SelectedIndex = -1;
            }
        }

        private void btnRemove9_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(9);

                txtName9.Text = "Enter a team";
                txtName9.ForeColor = Color.Gray;
                txtShared9.Text = "Enter a team";
                txtShared9.ForeColor = Color.Gray;
                cmbBoxHome9.SelectedIndex = -1;
                cmbBoxNoPlay9.SelectedIndex = -1;
            }
        }

        private void btnRemove10_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(10);

                txtName10.Text = "Enter a team";
                txtName10.ForeColor = Color.Gray;
                txtShared10.Text = "Enter a team";
                txtShared10.ForeColor = Color.Gray;
                cmbBoxHome10.SelectedIndex = -1;
                cmbBoxNoPlay10.SelectedIndex = -1;
            }
        }

        private void btnRemove11_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(11);

                txtName11.Text = "Enter a team";
                txtName11.ForeColor = Color.Gray;
                txtShared11.Text = "Enter a team";
                txtShared11.ForeColor = Color.Gray;
                cmbBoxHome11.SelectedIndex = -1;
                cmbBoxNoPlay11.SelectedIndex = -1;
            }
        }

        private void btnRemove12_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(12);

                txtName12.Text = "Enter a team";
                txtName12.ForeColor = Color.Gray;
                txtShared12.Text = "Enter a team";
                txtShared12.ForeColor = Color.Gray;
                cmbBoxHome12.SelectedIndex = -1;
                cmbBoxNoPlay12.SelectedIndex = -1;
            }
        }

        private void btnRemove13_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(13);

                txtName13.Text = "Enter a team";
                txtName13.ForeColor = Color.Gray;
                txtShared13.Text = "Enter a team";
                txtShared13.ForeColor = Color.Gray;
                cmbBoxHome13.SelectedIndex = -1;
                cmbBoxNoPlay13.SelectedIndex = -1;
            }
        }

        private void btnRemove14_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Are you sure you want to remove this team?", "Remove team", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                remove(14);

                txtName14.Text = "Enter a team";
                txtName14.ForeColor = Color.Gray;
                txtShared14.Text = "Enter a team";
                txtShared14.ForeColor = Color.Gray;
                cmbBoxHome14.SelectedIndex = -1;
                cmbBoxNoPlay14.SelectedIndex = -1;
            }
        }

        private void metBtnQuit_Click(object sender, EventArgs e)
        {
             DialogResult del = MessageBox.Show("Are you sure you want to quit? All progress will be lost.", "Quit", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void saveChanges()
        {
            teamCount[division] = 0;
            bool invalid = false;
            string input = txtName.Text;
            input = input.Trim();
            #region Save changes
            //If name = "Enter team name" or "", it must be ignored
            //If a team name is blank, the following teams can be ignored
            if (txtName.Text != "Enter a team" && input != "")
            {
                #region Save team 1
                //Save name
                name[division, teamCount[division]] = txtName.Text;
                //Check if already exists
                for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                {
                    if (txtShared.Text == shared[division, teamCount[division], i])
                    {
                        invalid = true;
                    }
                }
                input = txtShared.Text;
                input = input.Trim();
                if (input != "" && txtShared.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                {
                    //Save shared
                    shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared.Text;
                    sharedCount[division, teamCount[division]]++;
                }
                //Check if date already exists
                invalid = false;
                for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                {
                    if (cmbBoxHome.Text == datesHome[division, teamCount[division], i])
                    {
                        invalid = true;
                    }
                }
                if (cmbBoxHome.Text != "" && invalid == false)
                {
                    //Save home date
                    datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome.Text;
                    homeCount[division, teamCount[division]]++;
                    homeIndex[division, teamCount[division]] = cmbBoxHome.SelectedIndex;
                }
                //Check if date already exists
                invalid = false;
                for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                {
                    if (cmbBoxNoPlay.Text == datesNoPlay[division, teamCount[division], i])
                    {
                        invalid = true;
                    }
                }
                if (cmbBoxNoPlay.Text != "" && invalid == false)
                {
                    //Save no play date
                    datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay.Text;
                    noPlayCount[division, teamCount[division]]++;
                    noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay.SelectedIndex;
                }
                invalid = false;
                #endregion
                teamCount[division]++;
                input = txtName1.Text;
                input = input.Trim();
                if (txtName1.Text != "Enter a team" && input != "")
                {
                    #region Save team 2
                    //Save name
                    name[division, teamCount[division]] = txtName1.Text;
                    //Check if date already exists
                    for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                    {
                        if (txtShared1.Text == shared[division, teamCount[division], i])
                        {
                            invalid = true;
                        }
                    }
                    input = txtShared1.Text;
                    input = input.Trim();
                    if (input != "" && txtShared1.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                    {
                        //Save shared
                        shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared1.Text;
                        sharedCount[division, teamCount[division]]++;
                    }
                    //Check if date already exists
                    invalid = false;
                    for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                    {
                        if (cmbBoxHome1.Text == datesHome[division, teamCount[division], i])
                        {
                            invalid = true;
                        }
                    }
                    if (cmbBoxHome1.Text != "" && invalid == false)
                    {
                        //Save home date
                        datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome1.Text;
                        homeCount[division, teamCount[division]]++;
                        homeIndex[division, teamCount[division]] = cmbBoxHome1.SelectedIndex;
                    }
                    //Check if date already exists
                    invalid = false;
                    for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                    {
                        if (cmbBoxNoPlay1.Text == datesNoPlay[division, teamCount[division], i])
                        {
                            invalid = true;
                        }
                    }
                    if (cmbBoxNoPlay1.Text != "" && invalid == false)
                    {
                        //Save no play date
                        datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay1.Text;
                        noPlayCount[division, teamCount[division]]++;
                        noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay1.SelectedIndex;
                    }
                    invalid = false;
                    #endregion
                    teamCount[division]++;
                    input = txtName2.Text;
                    input = input.Trim();
                    if (txtName2.Text != "Enter a team" && input != "")
                    {
                        #region Save team 3
                        //Save name
                        name[division, teamCount[division]] = txtName2.Text;
                        //Check if date already exists
                        for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                        {
                            if (txtShared2.Text == shared[division, teamCount[division], i])
                            {
                                invalid = true;
                            }
                        }
                        input = txtShared2.Text;
                        input = input.Trim();
                        if (input != "" && txtShared2.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                        {
                            //Save shared
                            shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared2.Text;
                            sharedCount[division, teamCount[division]]++;
                        }
                        //Check if date already exists
                        invalid = false;
                        for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                        {
                            if (cmbBoxHome2.Text == datesHome[division, teamCount[division], i])
                            {
                                invalid = true;
                            }
                        }
                        if (cmbBoxHome2.Text != "" && invalid == false)
                        {
                            //Save home date
                            datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome2.Text;
                            homeCount[division, teamCount[division]]++;
                            homeIndex[division, teamCount[division]] = cmbBoxHome2.SelectedIndex;
                        }
                        //Check if date already exists
                        invalid = false;
                        for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                        {
                            if (cmbBoxNoPlay2.Text == datesNoPlay[division, teamCount[division], i])
                            {
                                invalid = true;
                            }
                        }
                        if (cmbBoxNoPlay2.Text != "" && invalid == false)
                        {
                            //Save no play date
                            datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay2.Text;
                            noPlayCount[division, teamCount[division]]++;
                            noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay2.SelectedIndex;
                        }
                        invalid = false;
                        #endregion
                        teamCount[division]++;
                        input = txtName3.Text;
                        input = input.Trim();
                        if (txtName3.Text != "Enter a team" && input != "")
                        {
                            #region Save team 4
                            //Save name
                            name[division, teamCount[division]] = txtName3.Text;
                            //Check if date already exists
                            for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                            {
                                if (txtShared3.Text == shared[division, teamCount[division], i])
                                {
                                    invalid = true;
                                }
                            }
                            input = txtShared3.Text;
                            input = input.Trim();
                            if (input != "" && txtShared3.Text != "Enter a team" && invalid == false)
                            {
                                //Save shared
                                shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared3.Text;
                                sharedCount[division, teamCount[division]]++;
                            }
                            //Check if date already exists
                            invalid = false;
                            for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                            {
                                if (cmbBoxHome3.Text == datesHome[division, teamCount[division], i])
                                {
                                    invalid = true;
                                }
                            }
                            if (cmbBoxHome3.Text != "" && invalid == false)
                            {
                                //Save home date
                                datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome3.Text;
                                homeCount[division, teamCount[division]]++;
                                homeIndex[division, teamCount[division]] = cmbBoxHome3.SelectedIndex;
                            }
                            //Check if date already exists
                            invalid = false;
                            for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                            {
                                if (cmbBoxNoPlay3.Text == datesNoPlay[division, teamCount[division], i])
                                {
                                    invalid = true;
                                }
                            }
                            if (cmbBoxNoPlay3.Text != "" && invalid == false)
                            {
                                //Save no play date
                                datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay3.Text;
                                noPlayCount[division, teamCount[division]]++;
                                noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay3.SelectedIndex;
                            }
                            invalid = false;
                            #endregion
                            teamCount[division]++;
                            input = txtName4.Text;
                            input = input.Trim();
                            if (txtName4.Text != "Enter a team" && input != "")
                            {
                                #region Save team 5
                                //Save name
                                name[division, teamCount[division]] = txtName4.Text;
                                //Check if date already exists
                                for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                {
                                    if (txtShared4.Text == shared[division, teamCount[division], i])
                                    {
                                        invalid = true;
                                    }
                                }
                                input = txtShared4.Text;
                                input = input.Trim();
                                if (input != "" && txtShared4.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                {
                                    //Save shared
                                    shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared4.Text;
                                    sharedCount[division, teamCount[division]]++;
                                }
                                //Check if date already exists
                                invalid = false;
                                for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                {
                                    if (cmbBoxHome4.Text == datesHome[division, teamCount[division], i])
                                    {
                                        invalid = true;
                                    }
                                }
                                if (cmbBoxHome4.Text != "" && invalid == false)
                                {
                                    //Save home date
                                    datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome4.Text;
                                    homeCount[division, teamCount[division]]++;
                                    homeIndex[division, teamCount[division]] = cmbBoxHome4.SelectedIndex;
                                }
                                //Check if date already exists
                                invalid = false;
                                for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                {
                                    if (cmbBoxNoPlay4.Text == datesNoPlay[division, teamCount[division], i])
                                    {
                                        invalid = true;
                                    }
                                }
                                if (cmbBoxNoPlay4.Text != "" && invalid == false)
                                {
                                    //Save no play date
                                    datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay4.Text;
                                    noPlayCount[division, teamCount[division]]++;
                                    noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay4.SelectedIndex;
                                }
                                invalid = false;
                                #endregion
                                teamCount[division]++;
                                input = txtName5.Text;
                                input = input.Trim();
                                if (txtName5.Text != "Enter a team" && input != "")
                                {
                                    #region Save team 6
                                    //Save name
                                    name[division, teamCount[division]] = txtName5.Text;
                                    //Check if date already exists
                                    for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                    {
                                        if (txtShared5.Text == shared[division, teamCount[division], i])
                                        {
                                            invalid = true;
                                        }
                                    }
                                    input = txtShared5.Text;
                                    input = input.Trim();
                                    if (input != "" && txtShared5.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                    {
                                        //Save shared
                                        shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared5.Text;
                                        sharedCount[division, teamCount[division]]++;
                                    }
                                    //Check if date already exists
                                    invalid = false;
                                    for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                    {
                                        if (cmbBoxHome5.Text == datesHome[division, teamCount[division], i])
                                        {
                                            invalid = true;
                                        }
                                    }
                                    if (cmbBoxHome5.Text != "" && invalid == false)
                                    {
                                        //Save home date
                                        datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome5.Text;
                                        homeCount[division, teamCount[division]]++;
                                        homeIndex[division, teamCount[division]] = cmbBoxHome5.SelectedIndex;
                                    }
                                    //Check if date already exists
                                    invalid = false;
                                    for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                    {
                                        if (cmbBoxNoPlay5.Text == datesNoPlay[division, teamCount[division], i])
                                        {
                                            invalid = true;
                                        }
                                    }
                                    if (cmbBoxNoPlay5.Text != "" && invalid == false)
                                    {
                                        //Save no play date
                                        datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay5.Text;
                                        noPlayCount[division, teamCount[division]]++;
                                        noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay5.SelectedIndex;
                                    }
                                    invalid = false;
                                    #endregion
                                    teamCount[division]++;
                                    input = txtName6.Text;
                                    input = input.Trim();
                                    if (txtName6.Text != "Enter a team" && input != "")
                                    {
                                        #region Save team 7
                                        //Save name
                                        name[division, teamCount[division]] = txtName6.Text;
                                        //Check if date already exists
                                        for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                        {
                                            if (txtShared6.Text == shared[division, teamCount[division], i])
                                            {
                                                invalid = true;
                                            }
                                        }
                                        input = txtShared6.Text;
                                        input = input.Trim();
                                        if (input != "" && txtShared6.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                        {
                                            //Save shared
                                            shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared6.Text;
                                            sharedCount[division, teamCount[division]]++;
                                        }
                                        //Check if date already exists
                                        invalid = false;
                                        for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                        {
                                            if (cmbBoxHome6.Text == datesHome[division, teamCount[division], i])
                                            {
                                                invalid = true;
                                            }
                                        }
                                        if (cmbBoxHome6.Text != "" && invalid == false)
                                        {
                                            //Save home date
                                            datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome6.Text;
                                            homeCount[division, teamCount[division]]++;
                                            homeIndex[division, teamCount[division]] = cmbBoxHome6.SelectedIndex;
                                        }
                                        //Check if date already exists
                                        invalid = false;
                                        for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                        {
                                            if (cmbBoxNoPlay6.Text == datesNoPlay[division, teamCount[division], i])
                                            {
                                                invalid = true;
                                            }
                                        }
                                        if (cmbBoxNoPlay6.Text != "" && invalid == false)
                                        {
                                            //Save no play date
                                            datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay6.Text;
                                            noPlayCount[division, teamCount[division]]++;
                                            noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay6.SelectedIndex;
                                        }
                                        invalid = false;
                                        #endregion
                                        teamCount[division]++;
                                        input = txtName7.Text;
                                        input = input.Trim();
                                        if (txtName7.Text != "Enter a team" && input != "")
                                        {
                                            #region Save team 8
                                            //Save name
                                            name[division, teamCount[division]] = txtName7.Text;
                                            //Check if date already exists
                                            for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                            {
                                                if (txtShared7.Text == shared[division, teamCount[division], i])
                                                {
                                                    invalid = true;
                                                }
                                            }
                                            input = txtShared7.Text;
                                            input = input.Trim();
                                            if (input != "" && txtShared7.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                            {
                                                //Save shared
                                                shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared7.Text;
                                                sharedCount[division, teamCount[division]]++;
                                            }
                                            //Check if date already exists
                                            invalid = false;
                                            for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                            {
                                                if (cmbBoxHome7.Text == datesHome[division, teamCount[division], i])
                                                {
                                                    invalid = true;
                                                }
                                            }
                                            if (cmbBoxHome7.Text != "" && invalid == false)
                                            {
                                                //Save home date
                                                datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome7.Text;
                                                homeCount[division, teamCount[division]]++;
                                                homeIndex[division, teamCount[division]] = cmbBoxHome7.SelectedIndex;
                                            }
                                            //Check if date already exists
                                            invalid = false;
                                            for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                            {
                                                if (cmbBoxNoPlay7.Text == datesNoPlay[division, teamCount[division], i])
                                                {
                                                    invalid = true;
                                                }
                                            }
                                            if (cmbBoxNoPlay7.Text != "" && invalid == false)
                                            {
                                                //Save no play date
                                                datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay7.Text;
                                                noPlayCount[division, teamCount[division]]++;
                                                noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay7.SelectedIndex;
                                            }
                                            invalid = false;
                                            #endregion
                                            teamCount[division]++;
                                            input = txtName8.Text;
                                            input = input.Trim();
                                            if (txtName8.Text != "Enter a team" && input != "")
                                            {
                                                #region Save team 9
                                                //Save name
                                                name[division, teamCount[division]] = txtName8.Text;
                                                //Check if date already exists
                                                for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                                {
                                                    if (txtShared8.Text == shared[division, teamCount[division], i])
                                                    {
                                                        invalid = true;
                                                    }
                                                }
                                                input = txtShared8.Text;
                                                input = input.Trim();
                                                if (input != "" && txtShared8.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                                {
                                                    //Save shared
                                                    shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared8.Text;
                                                    sharedCount[division, teamCount[division]]++;
                                                }
                                                //Check if date already exists
                                                invalid = false;
                                                for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                                {
                                                    if (cmbBoxHome8.Text == datesHome[division, teamCount[division], i])
                                                    {
                                                        invalid = true;
                                                    }
                                                }
                                                if (cmbBoxHome8.Text != "" && invalid == false)
                                                {
                                                    //Save home date
                                                    datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome8.Text;
                                                    homeCount[division, teamCount[division]]++;
                                                    homeIndex[division, teamCount[division]] = cmbBoxHome8.SelectedIndex;
                                                }
                                                //Check if date already exists
                                                invalid = false;
                                                for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                                {
                                                    if (cmbBoxNoPlay8.Text == datesNoPlay[division, teamCount[division], i])
                                                    {
                                                        invalid = true;
                                                    }
                                                }
                                                if (cmbBoxNoPlay8.Text != "" && invalid == false)
                                                {
                                                    //Save no play date
                                                    datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay8.Text;
                                                    noPlayCount[division, teamCount[division]]++;
                                                    noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay8.SelectedIndex;
                                                }
                                                invalid = false;
                                                #endregion
                                                teamCount[division]++;
                                                input = txtName9.Text;
                                                input = input.Trim();
                                                if (txtName9.Text != "Enter a team" && input != "")
                                                {
                                                    #region Save team 10
                                                    //Save name
                                                    name[division, teamCount[division]] = txtName9.Text;
                                                    //Check if date already exists
                                                    for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                                    {
                                                        if (txtShared9.Text == shared[division, teamCount[division], i])
                                                        {
                                                            invalid = true;
                                                        }
                                                    }
                                                    input = txtShared9.Text;
                                                    input = input.Trim();
                                                    if (input != "" && txtShared9.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                                    {
                                                        //Save shared
                                                        shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared9.Text;
                                                        sharedCount[division, teamCount[division]]++;
                                                    }
                                                    //Check if date already exists
                                                    invalid = false;
                                                    for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                                    {
                                                        if (cmbBoxHome9.Text == datesHome[division, teamCount[division], i])
                                                        {
                                                            invalid = true;
                                                        }
                                                    }
                                                    if (cmbBoxHome9.Text != "" && invalid == false)
                                                    {
                                                        //Save home date
                                                        datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome9.Text;
                                                        homeCount[division, teamCount[division]]++;
                                                        homeIndex[division, teamCount[division]] = cmbBoxHome9.SelectedIndex;
                                                    }
                                                    //Check if date already exists
                                                    invalid = false;
                                                    for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                                    {
                                                        if (cmbBoxNoPlay9.Text == datesNoPlay[division, teamCount[division], i])
                                                        {
                                                            invalid = true;
                                                        }
                                                    }
                                                    if (cmbBoxNoPlay9.Text != "" && invalid == false)
                                                    {
                                                        //Save no play date
                                                        datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay9.Text;
                                                        noPlayCount[division, teamCount[division]]++;
                                                        noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay9.SelectedIndex;
                                                    }
                                                    invalid = false;
                                                    #endregion
                                                    teamCount[division]++;
                                                    input = txtName10.Text;
                                                    input = input.Trim();
                                                    if (txtName10.Text != "Enter a team" && input != "")
                                                    {
                                                        #region Save team 11
                                                        //Save name
                                                        name[division, teamCount[division]] = txtName10.Text;
                                                        //Check if date already exists
                                                        for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                                        {
                                                            if (txtShared10.Text == shared[division, teamCount[division], i])
                                                            {
                                                                invalid = true;
                                                            }
                                                        }
                                                        input = txtShared10.Text;
                                                        input = input.Trim();
                                                        if (input != "" && txtShared10.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                                        {
                                                            //Save shared
                                                            shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared10.Text;
                                                            sharedCount[division, teamCount[division]]++;
                                                        }
                                                        //Check if date already exists
                                                        invalid = false;
                                                        for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                                        {
                                                            if (cmbBoxHome10.Text == datesHome[division, teamCount[division], i])
                                                            {
                                                                invalid = true;
                                                            }
                                                        }
                                                        if (cmbBoxHome10.Text != "" && invalid == false)
                                                        {
                                                            //Save home date
                                                            datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome10.Text;
                                                            homeCount[division, teamCount[division]]++;
                                                            homeIndex[division, teamCount[division]] = cmbBoxHome10.SelectedIndex;
                                                        }
                                                        //Check if date already exists
                                                        invalid = false;
                                                        for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                                        {
                                                            if (cmbBoxNoPlay10.Text == datesNoPlay[division, teamCount[division], i])
                                                            {
                                                                invalid = true;
                                                            }
                                                        }
                                                        if (cmbBoxNoPlay10.Text != "" && invalid == false)
                                                        {
                                                            //Save no play date
                                                            datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay10.Text;
                                                            noPlayCount[division, teamCount[division]]++;
                                                            noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay10.SelectedIndex;
                                                        }
                                                        invalid = false;
                                                        #endregion
                                                        teamCount[division]++;
                                                        input = txtName11.Text;
                                                        input = input.Trim();
                                                        if (txtName11.Text != "Enter a team" && input != "")
                                                        {
                                                            #region Save team 12
                                                            //Save name
                                                            name[division, teamCount[division]] = txtName11.Text;
                                                            //Check if date already exists
                                                            for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                                            {
                                                                if (txtShared11.Text == shared[division, teamCount[division], i])
                                                                {
                                                                    invalid = true;
                                                                }
                                                            }
                                                            input = txtShared11.Text;
                                                            input = input.Trim();
                                                            if (input != "" && txtShared11.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                                            {
                                                                //Save shared
                                                                shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared11.Text;
                                                                sharedCount[division, teamCount[division]]++;
                                                            }
                                                            //Check if date already exists
                                                            invalid = false;
                                                            for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                                            {
                                                                if (cmbBoxHome11.Text == datesHome[division, teamCount[division], i])
                                                                {
                                                                    invalid = true;
                                                                }
                                                            }
                                                            if (cmbBoxHome11.Text != "" && invalid == false)
                                                            {
                                                                //Save home date
                                                                datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome11.Text;
                                                                homeCount[division, teamCount[division]]++;
                                                                homeIndex[division, teamCount[division]] = cmbBoxHome11.SelectedIndex;
                                                            }
                                                            //Check if date already exists
                                                            invalid = false;
                                                            for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                                            {
                                                                if (cmbBoxNoPlay11.Text == datesNoPlay[division, teamCount[division], i])
                                                                {
                                                                    invalid = true;
                                                                }
                                                            }
                                                            if (cmbBoxNoPlay11.Text != "" && invalid == false)
                                                            {
                                                                //Save no play date
                                                                datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay11.Text;
                                                                noPlayCount[division, teamCount[division]]++;
                                                                noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay11.SelectedIndex;
                                                            }
                                                            invalid = false;
                                                            #endregion
                                                            teamCount[division]++;
                                                            input = txtName12.Text;
                                                            input = input.Trim();
                                                            if (txtName12.Text != "Enter a team" && input != "")
                                                            {
                                                                #region Save team 13
                                                                //Save name
                                                                name[division, teamCount[division]] = txtName12.Text;
                                                                //Check if date already exists
                                                                for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                                                {
                                                                    if (txtShared12.Text == shared[division, teamCount[division], i])
                                                                    {
                                                                        invalid = true;
                                                                    }
                                                                }
                                                                input = txtShared12.Text;
                                                                input = input.Trim();
                                                                if (input != "" && txtShared12.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                                                {
                                                                    //Save shared
                                                                    shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared12.Text;
                                                                    sharedCount[division, teamCount[division]]++;
                                                                }
                                                                //Check if date already exists
                                                                invalid = false;
                                                                for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                                                {
                                                                    if (cmbBoxHome12.Text == datesHome[division, teamCount[division], i])
                                                                    {
                                                                        invalid = true;
                                                                    }
                                                                }
                                                                if (cmbBoxHome12.Text != "" && invalid == false)
                                                                {
                                                                    //Save home date
                                                                    datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome12.Text;
                                                                    homeCount[division, teamCount[division]]++;
                                                                    homeIndex[division, teamCount[division]] = cmbBoxHome12.SelectedIndex;
                                                                }
                                                                //Check if date already exists
                                                                invalid = false;
                                                                for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                                                {
                                                                    if (cmbBoxNoPlay12.Text == datesNoPlay[division, teamCount[division], i])
                                                                    {
                                                                        invalid = true;
                                                                    }
                                                                }
                                                                if (cmbBoxNoPlay12.Text != "" && invalid == false)
                                                                {
                                                                    //Save no play date
                                                                    datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay12.Text;
                                                                    noPlayCount[division, teamCount[division]]++;
                                                                    noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay12.SelectedIndex;
                                                                }
                                                                invalid = false;
                                                                #endregion
                                                                teamCount[division]++;
                                                                input = txtName13.Text;
                                                                input = input.Trim();
                                                                if (txtName13.Text != "Enter a team" && input != "")
                                                                {
                                                                    #region Save team 14
                                                                    //Save name
                                                                    name[division, teamCount[division]] = txtName13.Text;
                                                                    //Check if date already exists
                                                                    for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                                                    {
                                                                        if (txtShared13.Text == shared[division, teamCount[division], i])
                                                                        {
                                                                            invalid = true;
                                                                        }
                                                                    }
                                                                    input = txtShared13.Text;
                                                                    input = input.Trim();
                                                                    if (input != "" && txtShared13.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                                                    {
                                                                        //Save shared
                                                                        shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared13.Text;
                                                                        sharedCount[division, teamCount[division]]++;
                                                                    }
                                                                    //Check if date already exists
                                                                    invalid = false;
                                                                    for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                                                    {
                                                                        if (cmbBoxHome13.Text == datesHome[division, teamCount[division], i])
                                                                        {
                                                                            invalid = true;
                                                                        }
                                                                    }
                                                                    if (cmbBoxHome13.Text != "" && invalid == false)
                                                                    {
                                                                        //Save home date
                                                                        datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome13.Text;
                                                                        homeCount[division, teamCount[division]]++;
                                                                        homeIndex[division, teamCount[division]] = cmbBoxHome13.SelectedIndex;
                                                                    }
                                                                    //Check if date already exists
                                                                    invalid = false;
                                                                    for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                                                    {
                                                                        if (cmbBoxNoPlay13.Text == datesNoPlay[division, teamCount[division], i])
                                                                        {
                                                                            invalid = true;
                                                                        }
                                                                    }
                                                                    if (cmbBoxNoPlay13.Text != "" && invalid == false)
                                                                    {
                                                                        //Save no play date
                                                                        datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay13.Text;
                                                                        noPlayCount[division, teamCount[division]]++;
                                                                        noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay13.SelectedIndex;
                                                                    }
                                                                    invalid = false;
                                                                    #endregion
                                                                    teamCount[division]++;
                                                                    input = txtName14.Text;
                                                                    input = input.Trim();
                                                                    if (txtName14.Text != "Enter a team" && input != "")
                                                                    {
                                                                        #region Save team 15
                                                                        //Save name
                                                                        name[division, teamCount[division]] = txtName14.Text;
                                                                        //Check if date already exists
                                                                        for (int i = 0; i < sharedCount[division, teamCount[division]]; i++)
                                                                        {
                                                                            if (txtShared14.Text == shared[division, teamCount[division], i])
                                                                            {
                                                                                invalid = true;
                                                                            }
                                                                        }
                                                                        input = txtShared14.Text;
                                                                        input = input.Trim();
                                                                        if (input != "" && txtShared14.Text != "Enter a team" && invalid == false && sharedCount[division, teamCount[division]] < 4)
                                                                        {
                                                                            //Save shared
                                                                            shared[division, teamCount[division], sharedCount[division, teamCount[division]]] = txtShared14.Text;
                                                                            sharedCount[division, teamCount[division]]++;
                                                                        }
                                                                        //Check if date already exists
                                                                        invalid = false;
                                                                        for (int i = 0; i < homeCount[division, teamCount[division]]; i++)
                                                                        {
                                                                            if (cmbBoxHome14.Text == datesHome[division, teamCount[division], i])
                                                                            {
                                                                                invalid = true;
                                                                            }
                                                                        }
                                                                        if (cmbBoxHome14.Text != "" && invalid == false)
                                                                        {
                                                                            //Save home date
                                                                            datesHome[division, teamCount[division], homeCount[division, teamCount[division]]] = cmbBoxHome14.Text;
                                                                            homeCount[division, teamCount[division]]++;
                                                                            homeIndex[division, teamCount[division]] = cmbBoxHome14.SelectedIndex;
                                                                        }
                                                                        //Check if date already exists
                                                                        invalid = false;
                                                                        for (int i = 0; i < noPlayCount[division, teamCount[division]]; i++)
                                                                        {
                                                                            if (cmbBoxNoPlay14.Text == datesNoPlay[division, teamCount[division], i])
                                                                            {
                                                                                invalid = true;
                                                                            }
                                                                        }
                                                                        if (cmbBoxNoPlay14.Text != "" && invalid == false)
                                                                        {
                                                                            //Save no play date
                                                                            datesNoPlay[division, teamCount[division], noPlayCount[division, teamCount[division]]] = cmbBoxNoPlay14.Text;
                                                                            noPlayCount[division, teamCount[division]]++;
                                                                            noPlayIndex[division, teamCount[division]] = cmbBoxNoPlay14.SelectedIndex;
                                                                        }
                                                                        invalid = false;
                                                                        #endregion
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        private void remove(int x)
        {
            name[division, x] = null;
            for (int i = 0; i < sharedCount[division, x]; i++)
            {
                shared[division, x, i] = null;
            }
            for (int i = 0; i < homeCount[division, x]; i++)
            {
                datesHome[division, x, i] = null;
            }
            for (int i = 0; i < noPlayCount[division, x]; i++)
            {
                datesNoPlay[division, x, i] = null;
            }
            sharedCount[division, x] = 0;
            homeCount[division, x] = 0;
            noPlayCount[division, x] = 0;
        }
    }
}