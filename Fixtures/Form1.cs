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
            sharedCount = 0;
            homeCount = 0;
            noPlayCount = 0;
            teamCount[division]++;
        }
    }
}