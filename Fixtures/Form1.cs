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
            datePickerHome.Hide();
            btnHome.Hide();
            lblNoPlay.Hide();
            datePickerNoPlay.Hide();
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
                List<MetroButton> buttons = new List<MetroButton>();
                MetroButton btnAddTeam1 = new MetroButton();
                buttons.Add(btnAddTeam1);
                metTabControl.SelectedTab.Controls.Add(btnAddTeam1);
                btnAddTeam1.Location = new Point(5, 5);
                btnAddTeam1.Size = new Size(1175, 43);
                btnAddTeam1.Text = "Add team +";
                btnAddTeam1.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
            }
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
                datePickerHome.Show();
                btnHome.Show();
                lblNoPlay.Show();
                datePickerNoPlay.Show();
                btnNoPlay.Show();
                metBtnAddTeam.Text = "Submit";
                metBtnAddTeam.Location = new Point(5, addTeamBtnY);
                addTeamBtnY += 90;
            }
            else if (addTeamBtnY != 902 && metBtnAddTeam.Text == "Submit")
            {
                //Add team
                name[0, team] = txtName.Text;
                //Display team
                List<MetroLabel> labels = new List<MetroLabel>();
                MetroLabel lblTeamName = new MetroLabel();
                labels.Add(lblTeamName);
                metTabControl.SelectedTab.Controls.Add(lblTeamName);
                lblTeamName.Location = new Point(5, 5);
                //Increment
                team++;
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
                datePickerHome.Hide();
                btnHome.Hide();
                lblNoPlay.Hide();
                datePickerNoPlay.Hide();
                btnNoPlay.Hide();
                lblName.Location = new Point(17, addTeamBtnY-40);
                lblTeam.Location = new Point(5, addTeamBtnY-70);
                txtName.Location = new Point(71, addTeamBtnY);
                lblShared.Location = new Point(221, addTeamBtnY);
                btnShared.Location = new Point(391, addTeamBtnY);
                txtShared.Location = new Point(332, addTeamBtnY);
                lblHome.Location = new Point(472, addTeamBtnY);
                datePickerHome.Location = new Point(556, addTeamBtnY);
                btnHome.Location = new Point(681, addTeamBtnY);
                lblNoPlay.Location = new Point(762, addTeamBtnY);
                datePickerNoPlay.Location = new Point(865, addTeamBtnY);
                btnNoPlay.Location = new Point(990, addTeamBtnY);
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
    }
}
