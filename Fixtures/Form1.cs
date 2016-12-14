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