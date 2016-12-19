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
        private int team = 0;
        private int[] sharedCount = new int[15]; //Shared count for each team
        private int[] homeCount = new int[15];
        private int[] noPlayCount = new int[15];
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
                int teamCount = 0;
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
                    name[division, teamCount] = txtName.Text;
                    //Check if already exists
                    for (int i = 0; i < sharedCount[teamCount]; i++)
                    {
                        if (txtShared.Text == shared[division, teamCount, i])
                        {
                            invalid = true;
                        }
                    }
                    input = txtShared.Text;
                    input = input.Trim();
                    if (input != "" && txtShared.Text != "Enter a team" && invalid == false)
                    {
                        //Save shared
                        shared[division, teamCount, sharedCount[teamCount]] = txtShared.Text;
                    }
                    //Check if date already exists
                    invalid = false;
                    for (int i = 0; i < homeCount[teamCount]; i++)
                    {
                        if (cmbBoxHome.Text == datesHome[division, teamCount, i])
                        {
                            invalid = true;
                        }
                    }
                    if (cmbBoxHome.Text != "" && invalid == false)
                    {
                        //Save home date
                        datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome.Text;
                    }
                    //Check if date already exists
                    invalid = false;
                    for (int i = 0; i < noPlayCount[teamCount]; i++)
                    {
                        if (cmbBoxNoPlay.Text == datesNoPlay[division, teamCount, i])
                        {
                            invalid = true;
                        }
                    }
                    if (cmbBoxNoPlay.Text != "" && invalid == false)
                    {
                        //Save no play date
                        datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay.Text;
                    }
                    invalid = false;
                    #endregion
                    teamCount++;
                    input = txtName1.Text;
                    input = input.Trim();
                    if (txtName1.Text != "Enter a team" && input != "")
                    {
                        #region Save team 2
                        //Save name
                        name[division, teamCount] = txtName1.Text;
                        //Check if date already exists
                        for (int i = 0; i < sharedCount[teamCount]; i++)
                        {
                            if (txtShared1.Text == shared[division, teamCount, i])
                            {
                                invalid = true;
                            }
                        }
                        input = txtShared1.Text;
                        input = input.Trim();
                        if (input != "" && txtShared1.Text != "Enter a team" && invalid == false)
                        {
                            //Save shared
                            shared[division, teamCount, sharedCount[teamCount]] = txtShared1.Text;
                        }
                        //Check if date already exists
                        invalid = false;
                        for (int i = 0; i < homeCount[teamCount]; i++)
                        {
                            if (cmbBoxHome1.Text == datesHome[division, teamCount, i])
                            {
                                invalid = true;
                            }
                        }
                        if (cmbBoxHome1.Text != "" && invalid == false)
                        {
                            //Save home date
                            datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome1.Text;
                        }
                        //Check if date already exists
                        invalid = false;
                        for (int i = 0; i < noPlayCount[teamCount]; i++)
                        {
                            if (cmbBoxNoPlay1.Text == datesNoPlay[division, teamCount, i])
                            {
                                invalid = true;
                            }
                        }
                        if (cmbBoxNoPlay1.Text != "" && invalid == false)
                        {
                            //Save no play date
                            datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay1.Text;
                        }
                        invalid = false;
                        #endregion
                        teamCount++;
                        input = txtName2.Text;
                        input = input.Trim();
                        if (txtName2.Text != "Enter a team" && input != "")
                        {
                            #region Save team 3
                            //Save name
                            name[division, teamCount] = txtName2.Text;
                            //Check if date already exists
                            for (int i = 0; i < sharedCount[teamCount]; i++)
                            {
                                if (txtShared2.Text == shared[division, teamCount, i])
                                {
                                    invalid = true;
                                }
                            }
                            input = txtShared2.Text;
                            input = input.Trim();
                            if (input != "" && txtShared2.Text != "Enter a team" && invalid == false)
                            {
                                //Save shared
                                shared[division, teamCount, sharedCount[teamCount]] = txtShared2.Text;
                            }
                            //Check if date already exists
                            invalid = false;
                            for (int i = 0; i < homeCount[teamCount]; i++)
                            {
                                if (cmbBoxHome2.Text == datesHome[division, teamCount, i])
                                {
                                    invalid = true;
                                }
                            }
                            if (cmbBoxHome2.Text != "" && invalid == false)
                            {
                                //Save home date
                                datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome2.Text;
                            }
                            //Check if date already exists
                            invalid = false;
                            for (int i = 0; i < noPlayCount[teamCount]; i++)
                            {
                                if (cmbBoxNoPlay2.Text == datesNoPlay[division, teamCount, i])
                                {
                                    invalid = true;
                                }
                            }
                            if (cmbBoxNoPlay2.Text != "" && invalid == false)
                            {
                                //Save no play date
                                datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay2.Text;
                            }
                            invalid = false;
                            #endregion
                            teamCount++;
                            input = txtName3.Text;
                            input = input.Trim();
                            if (txtName3.Text != "Enter a team" && input != "")
                            {
                                #region Save team 4
                                //Save name
                                name[division, teamCount] = txtName3.Text;
                                //Check if date already exists
                                for (int i = 0; i < sharedCount[teamCount]; i++)
                                {
                                    if (txtShared3.Text == shared[division, teamCount, i])
                                    {
                                        invalid = true;
                                    }
                                }
                                input = txtShared3.Text;
                                input = input.Trim();
                                if (input != "" && txtShared3.Text != "Enter a team" && invalid == false)
                                {
                                    //Save shared
                                    shared[division, teamCount, sharedCount[teamCount]] = txtShared3.Text;
                                }
                                //Check if date already exists
                                invalid = false;
                                for (int i = 0; i < homeCount[teamCount]; i++)
                                {
                                    if (cmbBoxHome3.Text == datesHome[division, teamCount, i])
                                    {
                                        invalid = true;
                                    }
                                }
                                if (cmbBoxHome3.Text != "" && invalid == false)
                                {
                                    //Save home date
                                    datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome3.Text;
                                }
                                //Check if date already exists
                                invalid = false;
                                for (int i = 0; i < noPlayCount[teamCount]; i++)
                                {
                                    if (cmbBoxNoPlay3.Text == datesNoPlay[division, teamCount, i])
                                    {
                                        invalid = true;
                                    }
                                }
                                if (cmbBoxNoPlay3.Text != "" && invalid == false)
                                {
                                    //Save no play date
                                    datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay3.Text;
                                }
                                invalid = false;
                                #endregion
                                teamCount++;
                                input = txtName4.Text;
                                input = input.Trim();
                                if (txtName4.Text != "Enter a team" && input != "")
                                {
                                    #region Save team 5
                                    //Save name
                                    name[division, teamCount] = txtName4.Text;
                                    //Check if date already exists
                                    for (int i = 0; i < sharedCount[teamCount]; i++)
                                    {
                                        if (txtShared4.Text == shared[division, teamCount, i])
                                        {
                                            invalid = true;
                                        }
                                    }
                                    input = txtShared4.Text;
                                    input = input.Trim();
                                    if (input != "" && txtShared4.Text != "Enter a team" && invalid == false)
                                    {
                                        //Save shared
                                        shared[division, teamCount, sharedCount[teamCount]] = txtShared4.Text;
                                    }
                                    //Check if date already exists
                                    invalid = false;
                                    for (int i = 0; i < homeCount[teamCount]; i++)
                                    {
                                        if (cmbBoxHome4.Text == datesHome[division, teamCount, i])
                                        {
                                            invalid = true;
                                        }
                                    }
                                    if (cmbBoxHome4.Text != "" && invalid == false)
                                    {
                                        //Save home date
                                        datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome4.Text;
                                    }
                                    //Check if date already exists
                                    invalid = false;
                                    for (int i = 0; i < noPlayCount[teamCount]; i++)
                                    {
                                        if (cmbBoxNoPlay4.Text == datesNoPlay[division, teamCount, i])
                                        {
                                            invalid = true;
                                        }
                                    }
                                    if (cmbBoxNoPlay4.Text != "" && invalid == false)
                                    {
                                        //Save no play date
                                        datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay4.Text;
                                    }
                                    invalid = false;
                                    #endregion
                                    teamCount++;
                                    input = txtName5.Text;
                                    input = input.Trim();
                                    if (txtName5.Text != "Enter a team" && input != "")
                                    {
                                        #region Save team 6
                                        //Save name
                                        name[division, teamCount] = txtName5.Text;
                                        //Check if date already exists
                                        for (int i = 0; i < sharedCount[teamCount]; i++)
                                        {
                                            if (txtShared5.Text == shared[division, teamCount, i])
                                            {
                                                invalid = true;
                                            }
                                        }
                                        input = txtShared5.Text;
                                        input = input.Trim();
                                        if (input != "" && txtShared5.Text != "Enter a team" && invalid == false)
                                        {
                                            //Save shared
                                            shared[division, teamCount, sharedCount[teamCount]] = txtShared5.Text;
                                        }
                                        //Check if date already exists
                                        invalid = false;
                                        for (int i = 0; i < homeCount[teamCount]; i++)
                                        {
                                            if (cmbBoxHome5.Text == datesHome[division, teamCount, i])
                                            {
                                                invalid = true;
                                            }
                                        }
                                        if (cmbBoxHome5.Text != "" && invalid == false)
                                        {
                                            //Save home date
                                            datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome5.Text;
                                        }
                                        //Check if date already exists
                                        invalid = false;
                                        for (int i = 0; i < noPlayCount[teamCount]; i++)
                                        {
                                            if (cmbBoxNoPlay5.Text == datesNoPlay[division, teamCount, i])
                                            {
                                                invalid = true;
                                            }
                                        }
                                        if (cmbBoxNoPlay5.Text != "" && invalid == false)
                                        {
                                            //Save no play date
                                            datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay5.Text;
                                        }
                                        invalid = false;
                                        #endregion
                                        teamCount++;
                                        input = txtName6.Text;
                                        input = input.Trim();
                                        if (txtName6.Text != "Enter a team" && input != "")
                                        {
                                            #region Save team 7
                                            //Save name
                                            name[division, teamCount] = txtName6.Text;
                                            //Check if date already exists
                                            for (int i = 0; i < sharedCount[teamCount]; i++)
                                            {
                                                if (txtShared6.Text == shared[division, teamCount, i])
                                                {
                                                    invalid = true;
                                                }
                                            }
                                            input = txtShared6.Text;
                                            input = input.Trim();
                                            if (input != "" && txtShared6.Text != "Enter a team" && invalid == false)
                                            {
                                                //Save shared
                                                shared[division, teamCount, sharedCount[teamCount]] = txtShared6.Text;
                                            }
                                            //Check if date already exists
                                            invalid = false;
                                            for (int i = 0; i < homeCount[teamCount]; i++)
                                            {
                                                if (cmbBoxHome6.Text == datesHome[division, teamCount, i])
                                                {
                                                    invalid = true;
                                                }
                                            }
                                            if (cmbBoxHome6.Text != "" && invalid == false)
                                            {
                                                //Save home date
                                                datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome6.Text;
                                            }
                                            //Check if date already exists
                                            invalid = false;
                                            for (int i = 0; i < noPlayCount[teamCount]; i++)
                                            {
                                                if (cmbBoxNoPlay6.Text == datesNoPlay[division, teamCount, i])
                                                {
                                                    invalid = true;
                                                }
                                            }
                                            if (cmbBoxNoPlay6.Text != "" && invalid == false)
                                            {
                                                //Save no play date
                                                datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay6.Text;
                                            }
                                            invalid = false;
                                            #endregion
                                            teamCount++;
                                            input = txtName7.Text;
                                            input = input.Trim();
                                            if (txtName7.Text != "Enter a team" && input != "")
                                            {
                                                #region Save team 8
                                                //Save name
                                                name[division, teamCount] = txtName7.Text;
                                                //Check if date already exists
                                                for (int i = 0; i < sharedCount[teamCount]; i++)
                                                {
                                                    if (txtShared7.Text == shared[division, teamCount, i])
                                                    {
                                                        invalid = true;
                                                    }
                                                }
                                                input = txtShared7.Text;
                                                input = input.Trim();
                                                if (input != "" && txtShared7.Text != "Enter a team" && invalid == false)
                                                {
                                                    //Save shared
                                                    shared[division, teamCount, sharedCount[teamCount]] = txtShared7.Text;
                                                }
                                                //Check if date already exists
                                                invalid = false;
                                                for (int i = 0; i < homeCount[teamCount]; i++)
                                                {
                                                    if (cmbBoxHome7.Text == datesHome[division, teamCount, i])
                                                    {
                                                        invalid = true;
                                                    }
                                                }
                                                if (cmbBoxHome7.Text != "" && invalid == false)
                                                {
                                                    //Save home date
                                                    datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome7.Text;
                                                }
                                                //Check if date already exists
                                                invalid = false;
                                                for (int i = 0; i < noPlayCount[teamCount]; i++)
                                                {
                                                    if (cmbBoxNoPlay7.Text == datesNoPlay[division, teamCount, i])
                                                    {
                                                        invalid = true;
                                                    }
                                                }
                                                if (cmbBoxNoPlay7.Text != "" && invalid == false)
                                                {
                                                    //Save no play date
                                                    datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay7.Text;
                                                }
                                                invalid = false;
                                                #endregion
                                                teamCount++;
                                                input = txtName8.Text;
                                                input = input.Trim();
                                                if (txtName8.Text == "Enter a team" && input != "")
                                                {
                                                    #region Save team 9
                                                    //Save name
                                                    name[division, teamCount] = txtName8.Text;
                                                    //Check if date already exists
                                                    for (int i = 0; i < sharedCount[teamCount]; i++)
                                                    {
                                                        if (txtShared8.Text == shared[division, teamCount, i])
                                                        {
                                                            invalid = true;
                                                        }
                                                    }
                                                    input = txtShared8.Text;
                                                    input = input.Trim();
                                                    if (input != "" && txtShared8.Text != "Enter a team" && invalid == false)
                                                    {
                                                        //Save shared
                                                        shared[division, teamCount, sharedCount[teamCount]] = txtShared8.Text;
                                                    }
                                                    //Check if date already exists
                                                    invalid = false;
                                                    for (int i = 0; i < homeCount[teamCount]; i++)
                                                    {
                                                        if (cmbBoxHome8.Text == datesHome[division, teamCount, i])
                                                        {
                                                            invalid = true;
                                                        }
                                                    }
                                                    if (cmbBoxHome8.Text != "" && invalid == false)
                                                    {
                                                        //Save home date
                                                        datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome8.Text;
                                                    }
                                                    //Check if date already exists
                                                    invalid = false;
                                                    for (int i = 0; i < noPlayCount[teamCount]; i++)
                                                    {
                                                        if (cmbBoxNoPlay8.Text == datesNoPlay[division, teamCount, i])
                                                        {
                                                            invalid = true;
                                                        }
                                                    }
                                                    if (cmbBoxNoPlay8.Text != "" && invalid == false)
                                                    {
                                                        //Save no play date
                                                        datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay8.Text;
                                                    }
                                                    invalid = false;
                                                    #endregion
                                                    teamCount++;
                                                    input = txtName9.Text;
                                                    input = input.Trim();
                                                    if (txtName9.Text != "Enter a team" && input != "")
                                                    {
                                                        #region Save team 10
                                                        //Save name
                                                        name[division, teamCount] = txtName9.Text;
                                                        //Check if date already exists
                                                        for (int i = 0; i < sharedCount[teamCount]; i++)
                                                        {
                                                            if (txtShared9.Text == shared[division, teamCount, i])
                                                            {
                                                                invalid = true;
                                                            }
                                                        }
                                                        input = txtShared9.Text;
                                                        input = input.Trim();
                                                        if (input != "" && txtShared9.Text != "Enter a team" && invalid == false)
                                                        {
                                                            //Save shared
                                                            shared[division, teamCount, sharedCount[teamCount]] = txtShared9.Text;
                                                        }
                                                        //Check if date already exists
                                                        invalid = false;
                                                        for (int i = 0; i < homeCount[teamCount]; i++)
                                                        {
                                                            if (cmbBoxHome9.Text == datesHome[division, teamCount, i])
                                                            {
                                                                invalid = true;
                                                            }
                                                        }
                                                        if (cmbBoxHome9.Text != "" && invalid == false)
                                                        {
                                                            //Save home date
                                                            datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome9.Text;
                                                        }
                                                        //Check if date already exists
                                                        invalid = false;
                                                        for (int i = 0; i < noPlayCount[teamCount]; i++)
                                                        {
                                                            if (cmbBoxNoPlay9.Text == datesNoPlay[division, teamCount, i])
                                                            {
                                                                invalid = true;
                                                            }
                                                        }
                                                        if (cmbBoxNoPlay9.Text != "" && invalid == false)
                                                        {
                                                            //Save no play date
                                                            datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay9.Text;
                                                        }
                                                        invalid = false;
                                                        #endregion
                                                        teamCount++;
                                                        input = txtName10.Text;
                                                        input = input.Trim();
                                                        if (txtName10.Text != "Enter a team" && input != "")
                                                        {
                                                            #region Save team 11
                                                            //Save name
                                                            name[division, teamCount] = txtName10.Text;
                                                            //Check if date already exists
                                                            for (int i = 0; i < sharedCount[teamCount]; i++)
                                                            {
                                                                if (txtShared10.Text == shared[division, teamCount, i])
                                                                {
                                                                    invalid = true;
                                                                }
                                                            }
                                                            input = txtShared10.Text;
                                                            input = input.Trim();
                                                            if (input != "" && txtShared10.Text != "Enter a team" && invalid == false)
                                                            {
                                                                //Save shared
                                                                shared[division, teamCount, sharedCount[teamCount]] = txtShared10.Text;
                                                            }
                                                            //Check if date already exists
                                                            invalid = false;
                                                            for (int i = 0; i < homeCount[teamCount]; i++)
                                                            {
                                                                if (cmbBoxHome10.Text == datesHome[division, teamCount, i])
                                                                {
                                                                    invalid = true;
                                                                }
                                                            }
                                                            if (cmbBoxHome10.Text != "" && invalid == false)
                                                            {
                                                                //Save home date
                                                                datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome10.Text;
                                                            }
                                                            //Check if date already exists
                                                            invalid = false;
                                                            for (int i = 0; i < noPlayCount[teamCount]; i++)
                                                            {
                                                                if (cmbBoxNoPlay10.Text == datesNoPlay[division, teamCount, i])
                                                                {
                                                                    invalid = true;
                                                                }
                                                            }
                                                            if (cmbBoxNoPlay10.Text != "" && invalid == false)
                                                            {
                                                                //Save no play date
                                                                datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay10.Text;
                                                            }
                                                            invalid = false;
                                                            #endregion
                                                            teamCount++;
                                                            input = txtName11.Text;
                                                            input = input.Trim();
                                                            if (txtName11.Text != "Enter a team" && input != "")
                                                            {
                                                                #region Save team 12
                                                                //Save name
                                                                name[division, teamCount] = txtName11.Text;
                                                                //Check if date already exists
                                                                for (int i = 0; i < sharedCount[teamCount]; i++)
                                                                {
                                                                    if (txtShared11.Text == shared[division, teamCount, i])
                                                                    {
                                                                        invalid = true;
                                                                    }
                                                                }
                                                                input = txtShared11.Text;
                                                                input = input.Trim();
                                                                if (input != "" && txtShared11.Text != "Enter a team" && invalid == false)
                                                                {
                                                                    //Save shared
                                                                    shared[division, teamCount, sharedCount[teamCount]] = txtShared11.Text;
                                                                }
                                                                //Check if date already exists
                                                                invalid = false;
                                                                for (int i = 0; i < homeCount[teamCount]; i++)
                                                                {
                                                                    if (cmbBoxHome11.Text == datesHome[division, teamCount, i])
                                                                    {
                                                                        invalid = true;
                                                                    }
                                                                }
                                                                if (cmbBoxHome11.Text != "" && invalid == false)
                                                                {
                                                                    //Save home date
                                                                    datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome11.Text;
                                                                }
                                                                //Check if date already exists
                                                                invalid = false;
                                                                for (int i = 0; i < noPlayCount[teamCount]; i++)
                                                                {
                                                                    if (cmbBoxNoPlay11.Text == datesNoPlay[division, teamCount, i])
                                                                    {
                                                                        invalid = true;
                                                                    }
                                                                }
                                                                if (cmbBoxNoPlay11.Text != "" && invalid == false)
                                                                {
                                                                    //Save no play date
                                                                    datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay11.Text;
                                                                }
                                                                invalid = false;
                                                                #endregion
                                                                teamCount++;
                                                                input = txtName12.Text;
                                                                input = input.Trim();
                                                                if (txtName12.Text != "Enter a team" && input != "")
                                                                {
                                                                    #region Save team 13
                                                                    //Save name
                                                                    name[division, teamCount] = txtName12.Text;
                                                                    //Check if date already exists
                                                                    for (int i = 0; i < sharedCount[teamCount]; i++)
                                                                    {
                                                                        if (txtShared12.Text == shared[division, teamCount, i])
                                                                        {
                                                                            invalid = true;
                                                                        }
                                                                    }
                                                                    input = txtShared12.Text;
                                                                    input = input.Trim();
                                                                    if (input != "" && txtShared12.Text != "Enter a team" && invalid == false)
                                                                    {
                                                                        //Save shared
                                                                        shared[division, teamCount, sharedCount[teamCount]] = txtShared12.Text;
                                                                    }
                                                                    //Check if date already exists
                                                                    invalid = false;
                                                                    for (int i = 0; i < homeCount[teamCount]; i++)
                                                                    {
                                                                        if (cmbBoxHome12.Text == datesHome[division, teamCount, i])
                                                                        {
                                                                            invalid = true;
                                                                        }
                                                                    }
                                                                    if (cmbBoxHome12.Text != "" && invalid == false)
                                                                    {
                                                                        //Save home date
                                                                        datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome12.Text;
                                                                    }
                                                                    //Check if date already exists
                                                                    invalid = false;
                                                                    for (int i = 0; i < noPlayCount[teamCount]; i++)
                                                                    {
                                                                        if (cmbBoxNoPlay12.Text == datesNoPlay[division, teamCount, i])
                                                                        {
                                                                            invalid = true;
                                                                        }
                                                                    }
                                                                    if (cmbBoxNoPlay12.Text != "" && invalid == false)
                                                                    {
                                                                        //Save no play date
                                                                        datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay12.Text;
                                                                    }
                                                                    invalid = false;
                                                                    #endregion
                                                                    teamCount++;
                                                                    input = txtName13.Text;
                                                                    input = input.Trim();
                                                                    if (txtName13.Text != "Enter a team" && input != "")
                                                                    {
                                                                        #region Save team 14
                                                                        //Save name
                                                                        name[division, teamCount] = txtName13.Text;
                                                                        //Check if date already exists
                                                                        for (int i = 0; i < sharedCount[teamCount]; i++)
                                                                        {
                                                                            if (txtShared13.Text == shared[division, teamCount, i])
                                                                            {
                                                                                invalid = true;
                                                                            }
                                                                        }
                                                                        input = txtShared13.Text;
                                                                        input = input.Trim();
                                                                        if (input != "" && txtShared13.Text != "Enter a team" && invalid == false)
                                                                        {
                                                                            //Save shared
                                                                            shared[division, teamCount, sharedCount[teamCount]] = txtShared13.Text;
                                                                        }
                                                                        //Check if date already exists
                                                                        invalid = false;
                                                                        for (int i = 0; i < homeCount[teamCount]; i++)
                                                                        {
                                                                            if (cmbBoxHome13.Text == datesHome[division, teamCount, i])
                                                                            {
                                                                                invalid = true;
                                                                            }
                                                                        }
                                                                        if (cmbBoxHome13.Text != "" && invalid == false)
                                                                        {
                                                                            //Save home date
                                                                            datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome13.Text;
                                                                        }
                                                                        //Check if date already exists
                                                                        invalid = false;
                                                                        for (int i = 0; i < noPlayCount[teamCount]; i++)
                                                                        {
                                                                            if (cmbBoxNoPlay13.Text == datesNoPlay[division, teamCount, i])
                                                                            {
                                                                                invalid = true;
                                                                            }
                                                                        }
                                                                        if (cmbBoxNoPlay13.Text != "" && invalid == false)
                                                                        {
                                                                            //Save no play date
                                                                            datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay13.Text;
                                                                        }
                                                                        invalid = false;
                                                                        #endregion
                                                                        teamCount++;
                                                                        input = txtName14.Text;
                                                                        input = input.Trim();
                                                                        if (txtName14.Text != "Enter a team" && input != "")
                                                                        {
                                                                            #region Save team 15
                                                                            //Save name
                                                                            name[division, teamCount] = txtName14.Text;
                                                                            //Check if date already exists
                                                                            for (int i = 0; i < sharedCount[teamCount]; i++)
                                                                            {
                                                                                if (txtShared14.Text == shared[division, teamCount, i])
                                                                                {
                                                                                    invalid = true;
                                                                                }
                                                                            }
                                                                            input = txtShared14.Text;
                                                                            input = input.Trim();
                                                                            if (input != "" && txtShared14.Text != "Enter a team" && invalid == false)
                                                                            {
                                                                                //Save shared
                                                                                shared[division, teamCount, sharedCount[teamCount]] = txtShared14.Text;
                                                                            }
                                                                            //Check if date already exists
                                                                            invalid = false;
                                                                            for (int i = 0; i < homeCount[teamCount]; i++)
                                                                            {
                                                                                if (cmbBoxHome14.Text == datesHome[division, teamCount, i])
                                                                                {
                                                                                    invalid = true;
                                                                                }
                                                                            }
                                                                            if (cmbBoxHome14.Text != "" && invalid == false)
                                                                            {
                                                                                //Save home date
                                                                                datesHome[division, teamCount, homeCount[teamCount]] = cmbBoxHome14.Text;
                                                                            }
                                                                            //Check if date already exists
                                                                            invalid = false;
                                                                            for (int i = 0; i < noPlayCount[teamCount]; i++)
                                                                            {
                                                                                if (cmbBoxNoPlay14.Text == datesNoPlay[division, teamCount, i])
                                                                                {
                                                                                    invalid = true;
                                                                                }
                                                                            }
                                                                            if (cmbBoxNoPlay14.Text != "" && invalid == false)
                                                                            {
                                                                                //Save no play date
                                                                                datesNoPlay[division, teamCount, noPlayCount[teamCount]] = cmbBoxNoPlay14.Text;
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
                #region Populate objects

                #endregion
                //Store value for current division
                division = metTabControl.SelectedIndex;
            }
        }                

        private void lblSharedDisp_MouseEnter(object sender, EventArgs e)
        {
           // lblSharedAll.BringToFront();
           // lblSharedAll.Show();
        }

        private void lblSharedDisp_MouseLeave(object sender, EventArgs e)
        {
            //lblSharedAll.Hide();
        }

        private void lblDatesHome_MouseEnter(object sender, EventArgs e)
        {
            //lblDatesHomeAll.BringToFront();
           // lblDatesHomeAll.Show();
        }

        private void lblDatesHome_MouseLeave(object sender, EventArgs e)
        {
            //lblDatesHomeAll.Hide();
        }

        private void lblDatesNoPlay_MouseEnter(object sender, EventArgs e)
        {
           // lblDatesNoPlayAll.BringToFront();
            //lblDatesNoPlayAll.Show();
        }

        private void lblDatesNoPlay_MouseLeave(object sender, EventArgs e)
        {
            //lblDatesNoPlayAll.Hide();
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
            //Increment
            team++;
            //sharedCount = 0;
            //homeCount = 0;
            //noPlayCount = 0;
            teamCount[division]++;
        }

        private void btnShared_Click(object sender, EventArgs e)
        {
            string input = txtShared.Text;
            input = input.Trim();
            bool check = false;

            if (sharedCount[0] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[0]; i++)
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
                    shared[division, 0, sharedCount[0]] = txtShared.Text;
                    sharedCount[0]++;
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

            if (sharedCount[1] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared1.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[1]; i++)
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
                    shared[division, 1, sharedCount[1]] = txtShared1.Text;
                    sharedCount[1]++;
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

            if (sharedCount[2] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared2.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[2]; i++)
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
                    shared[division, 2, sharedCount[2]] = txtShared2.Text;
                    sharedCount[2]++;
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

            if (sharedCount[3] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared3.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[3]; i++)
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
                    shared[division, 3, sharedCount[3]] = txtShared3.Text;
                    sharedCount[3]++;
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

            if (sharedCount[4] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared4.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[4]; i++)
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
                    shared[division, 4, sharedCount[4]] = txtShared4.Text;
                    sharedCount[4]++;
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

            if (sharedCount[5] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared5.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[5]; i++)
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
                    shared[division, 5, sharedCount[5]] = txtShared5.Text;
                    sharedCount[2]++;
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

            if (sharedCount[6] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared6.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[6]; i++)
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
                    shared[division, 6, sharedCount[6]] = txtShared6.Text;
                    sharedCount[6]++;
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

            if (sharedCount[7] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared7.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[7]; i++)
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
                    shared[division, 7, sharedCount[7]] = txtShared7.Text;
                    sharedCount[7]++;
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

            if (sharedCount[8] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared8.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[8]; i++)
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
                    shared[division, 8, sharedCount[8]] = txtShared8.Text;
                    sharedCount[8]++;
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

            if (sharedCount[9] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared9.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[9]; i++)
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
                    shared[division, 9, sharedCount[9]] = txtShared9.Text;
                    sharedCount[9]++;
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

            if (sharedCount[10] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared10.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[10]; i++)
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
                    shared[division, 10, sharedCount[10]] = txtShared10.Text;
                    sharedCount[10]++;
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

            if (sharedCount[11] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared11.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[11]; i++)
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
                    shared[division, 11, sharedCount[11]] = txtShared11.Text;
                    sharedCount[11]++;
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

            if (sharedCount[12] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared12.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[12]; i++)
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
                    shared[division, 12, sharedCount[12]] = txtShared12.Text;
                    sharedCount[12]++;
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

            if (sharedCount[13] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared13.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[13]; i++)
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
                    shared[division, 13, sharedCount[13]] = txtShared13.Text;
                    sharedCount[13]++;
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

            if (sharedCount[14] == 3)
            {
                MessageBox.Show("Cannot add another team.", "Max teams added", MessageBoxButtons.OK);
            }
            else if (txtShared14.Text != "Enter a team" && input != "")
            {
                for (int i = 0; i < sharedCount[14]; i++)
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
                    shared[division, 14, sharedCount[14]] = txtShared14.Text;
                    sharedCount[14]++;
                }
                //Reset text to type new team name
                txtShared14.Text = "";
                txtShared14.Focus();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[0] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome.Text != "")
            {
                for (int i = 0; i < homeCount[0]; i++)
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
                    datesHome[division, 0, homeCount[0]] = cmbBoxHome.Text;
                    homeCount[0]++;
                }
                //Reset text to type new team name
                cmbBoxHome.SelectedIndex = -1;
            }
        }

        private void btnHome1_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[1] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome1.Text != "")
            {
                for (int i = 0; i < homeCount[1]; i++)
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
                    datesHome[division, 1, homeCount[1]] = cmbBoxHome1.Text;
                    homeCount[1]++;
                }
                //Reset text to type new team name
                cmbBoxHome1.SelectedIndex = -1;
            }
        }

        private void btnHome2_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[2] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome2.Text != "")
            {
                for (int i = 0; i < homeCount[2]; i++)
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
                    datesHome[division, 2, homeCount[2]] = cmbBoxHome2.Text;
                    homeCount[2]++;
                }
                //Reset text to type new team name
                cmbBoxHome2.SelectedIndex = -1;
            }
        }

        private void btnHome3_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[3] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome3.Text != "")
            {
                for (int i = 0; i < homeCount[3]; i++)
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
                    datesHome[division, 3, homeCount[3]] = cmbBoxHome3.Text;
                    homeCount[3]++;
                }
                //Reset text to type new team name
                cmbBoxHome3.SelectedIndex = -1;
            }
        }

        private void btnHome4_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[4] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome4.Text != "")
            {
                for (int i = 0; i < homeCount[4]; i++)
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
                    datesHome[division, 4, homeCount[4]] = cmbBoxHome4.Text;
                    homeCount[4]++;
                }
                //Reset text to type new team name
                cmbBoxHome4.SelectedIndex = -1;
            }
        }

        private void btnHome5_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[5] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome5.Text != "")
            {
                for (int i = 0; i < homeCount[5]; i++)
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
                    datesHome[division, 5, homeCount[5]] = cmbBoxHome5.Text;
                    homeCount[5]++;
                }
                //Reset text to type new team name
                cmbBoxHome5.SelectedIndex = -1;
            }
        }

        private void btnHome6_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[6] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome6.Text != "")
            {
                for (int i = 0; i < homeCount[6]; i++)
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
                    datesHome[division, 6, homeCount[6]] = cmbBoxHome6.Text;
                    homeCount[6]++;
                }
                //Reset text to type new team name
                cmbBoxHome6.SelectedIndex = -1;
            }
        }

        private void btnHome7_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[7] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome7.Text != "")
            {
                for (int i = 0; i < homeCount[7]; i++)
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
                    datesHome[division, 7, homeCount[7]] = cmbBoxHome.Text;
                    homeCount[7]++;
                }
                //Reset text to type new team name
                cmbBoxHome7.SelectedIndex = -1;
            }
        }

        private void btnHome8_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[8] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome8.Text != "")
            {
                for (int i = 0; i < homeCount[8]; i++)
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
                    datesHome[division, 8, homeCount[8]] = cmbBoxHome8.Text;
                    homeCount[8]++;
                }
                //Reset text to type new team name
                cmbBoxHome8.SelectedIndex = -1;
            }
        }

        private void btnHome9_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[9] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome9.Text != "")
            {
                for (int i = 0; i < homeCount[9]; i++)
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
                    datesHome[division, 9, homeCount[9]] = cmbBoxHome9.Text;
                    homeCount[9]++;
                }
                //Reset text to type new team name
                cmbBoxHome9.SelectedIndex = -1;
            }
        }

        private void btnHome10_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[10] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome10.Text != "")
            {
                for (int i = 0; i < homeCount[10]; i++)
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
                    datesHome[division, 10, homeCount[10]] = cmbBoxHome10.Text;
                    homeCount[10]++;
                }
                //Reset text to type new team name
                cmbBoxHome10.SelectedIndex = -1;
            }
        }

        private void btnHome11_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[11] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome11.Text != "")
            {
                for (int i = 0; i < homeCount[11]; i++)
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
                    datesHome[division, 11, homeCount[11]] = cmbBoxHome11.Text;
                    homeCount[11]++;
                }
                //Reset text to type new team name
                cmbBoxHome11.SelectedIndex = -1;
            }
        }

        private void btnHome12_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[12] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome12.Text != "")
            {
                for (int i = 0; i < homeCount[12]; i++)
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
                    datesHome[division, 12, homeCount[12]] = cmbBoxHome12.Text;
                    homeCount[12]++;
                }
                //Reset text to type new team name
                cmbBoxHome12.SelectedIndex = -1;
            }
        }

        private void btnHome13_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[13] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome13.Text != "")
            {
                for (int i = 0; i < homeCount[13]; i++)
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
                    datesHome[division, 13, homeCount[13]] = cmbBoxHome13.Text;
                    homeCount[13]++;
                }
                //Reset text to type new team name
                cmbBoxHome13.SelectedIndex = -1;
            }
        }

        private void btnHome14_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (homeCount[14] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max home games added", MessageBoxButtons.OK);
            }
            else if (cmbBoxHome14.Text != "")
            {
                for (int i = 0; i < homeCount[14]; i++)
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
                    datesHome[division, 14, homeCount[14]] = cmbBoxHome14.Text;
                    homeCount[14]++;
                }
                //Reset text to type new team name
                cmbBoxHome14.SelectedIndex = -1;
            }
        }

        private void btnNoPlay_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[0] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay.Text != "")
            {
                for (int i = 0; i < noPlayCount[0]; i++)
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
                    datesNoPlay[division, 0, noPlayCount[0]] = cmbBoxNoPlay.Text;
                    noPlayCount[0]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay.SelectedIndex = -1;
            }
        }

        private void btnNoPlay1_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[1] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay1.Text != "")
            {
                for (int i = 0; i < noPlayCount[1]; i++)
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
                    datesNoPlay[division, 1, noPlayCount[1]] = cmbBoxNoPlay1.Text;
                    noPlayCount[1]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay1.SelectedIndex = -1;
            }
        }

        private void btnNoPlay2_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[2] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay2.Text != "")
            {
                for (int i = 0; i < noPlayCount[2]; i++)
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
                    datesNoPlay[division, 2, noPlayCount[2]] = cmbBoxNoPlay2.Text;
                    noPlayCount[2]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay2.SelectedIndex = -1;
            }
        }

        private void btnNoPlay3_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[3] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay3.Text != "")
            {
                for (int i = 0; i < noPlayCount[3]; i++)
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
                    datesNoPlay[division, 3, noPlayCount[3]] = cmbBoxNoPlay3.Text;
                    noPlayCount[3]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay3.SelectedIndex = -1;
            }
        }

        private void btnNoPlay4_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[4] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay4.Text != "")
            {
                for (int i = 0; i < noPlayCount[4]; i++)
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
                    datesNoPlay[division, 4, noPlayCount[4]] = cmbBoxNoPlay4.Text;
                    noPlayCount[4]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay4.SelectedIndex = -1;
            }
        }

        private void btnNoPlay5_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[5] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay5.Text != "")
            {
                for (int i = 0; i < noPlayCount[5]; i++)
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
                    datesNoPlay[division, 5, noPlayCount[5]] = cmbBoxNoPlay5.Text;
                    noPlayCount[5]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay5.SelectedIndex = -1;
            }
        }

        private void btnNoPlay6_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[6] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay6.Text != "")
            {
                for (int i = 0; i < noPlayCount[6]; i++)
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
                    datesNoPlay[division, 6, noPlayCount[6]] = cmbBoxNoPlay6.Text;
                    noPlayCount[6]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay6.SelectedIndex = -1;
            }
        }

        private void btnNoPlay7_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[7] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay7.Text != "")
            {
                for (int i = 0; i < noPlayCount[7]; i++)
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
                    datesNoPlay[division, 7, noPlayCount[7]] = cmbBoxNoPlay7.Text;
                    noPlayCount[7]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay7.SelectedIndex = -1;
            }
        }

        private void btnNoPlay8_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[8] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay8.Text != "")
            {
                for (int i = 0; i < noPlayCount[8]; i++)
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
                    datesNoPlay[division, 8, noPlayCount[8]] = cmbBoxNoPlay8.Text;
                    noPlayCount[8]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay8.SelectedIndex = -1;
            }
        }

        private void btnNoPlay9_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[9] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay9.Text != "")
            {
                for (int i = 0; i < noPlayCount[9]; i++)
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
                    datesNoPlay[division, 9, noPlayCount[9]] = cmbBoxNoPlay9.Text;
                    noPlayCount[9]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay9.SelectedIndex = -1;
            }
        }

        private void btnNoPlay10_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[10] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay10.Text != "")
            {
                for (int i = 0; i < noPlayCount[10]; i++)
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
                    datesNoPlay[division, 10, noPlayCount[10]] = cmbBoxNoPlay10.Text;
                    noPlayCount[10]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay10.SelectedIndex = -1;
            }
        }

        private void btnNoPlay11_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[11] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay11.Text != "")
            {
                for (int i = 0; i < noPlayCount[11]; i++)
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
                    datesNoPlay[division, 11, noPlayCount[11]] = cmbBoxNoPlay11.Text;
                    noPlayCount[11]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay11.SelectedIndex = -1;
            }
        }

        private void btnNoPlay12_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[12] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay12.Text != "")
            {
                for (int i = 0; i < noPlayCount[12]; i++)
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
                    datesNoPlay[division, 12, noPlayCount[12]] = cmbBoxNoPlay12.Text;
                    noPlayCount[12]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay12.SelectedIndex = -1;
            }
        }

        private void btnNoPlay13_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[13] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay13.Text != "")
            {
                for (int i = 0; i < noPlayCount[13]; i++)
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
                    datesNoPlay[division, 13, noPlayCount[13]] = cmbBoxNoPlay13.Text;
                    noPlayCount[13]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay13.SelectedIndex = -1;
            }
        }

        private void btnNoPlay14_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (noPlayCount[14] == 12)
            {
                MessageBox.Show("Cannot add another date.", "Max no play dates added", MessageBoxButtons.OK);
            }
            else if (cmbBoxNoPlay14.Text != "")
            {
                for (int i = 0; i < noPlayCount[14]; i++)
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
                    datesNoPlay[division, 14, noPlayCount[14]] = cmbBoxNoPlay14.Text;
                    noPlayCount[14]++;
                }
                //Reset text to type new team name
                cmbBoxNoPlay14.SelectedIndex = -1;
            }
        }
    }
}