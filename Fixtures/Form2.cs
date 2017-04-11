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

namespace Fixtures
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        //global output variables
        private int divCount = 0;
        private int division = 0;
        private int[] matchCount = new int[15];
        private int[] teamCount = new int[15];
        private int[,] sharedCount = new int[15, 15];
        private string[,] game = new string[15, 210]; //Division, Matches ... The list of all matches which must take place

        private string[,] name = new string[15, 15]; //Division, Team
        private string[,,] shared = new string[15, 15, 2]; //Max 15 divisions, 15 teams, 4 teams for single grounds
        private string[,,] datesHome = new string[15, 15, 13]; //Division, Team, Dates
        private string[,,] datesNoPlay = new string[15, 15, 13]; //Division, Team, Dates

        public Form2(int d, int[] m, string[,] g, string[,] n, string[, ,] s, string[, ,] dh, string[, ,] dnp, int[] tc, int[,] sc)
        {
            InitializeComponent();
            divCount = d;
            matchCount = m;
            game = g;
            name = n;
            shared = s;
            datesHome = dh;
            datesNoPlay = dnp;
            teamCount = tc;
            sharedCount = sc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int teamHome = 0;
            int teamAway = 0;
            string previous = "start";
            string temp = "";
            bool home = true;
            //int count = 0;

            #region Initialize
            matchA1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchA23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchB23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchC23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchD23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchE23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchF23.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG1.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG2.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG3.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG4.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG5.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG6.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG7.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG8.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG9.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG10.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG11.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG12.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG13.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG14.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG15.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG16.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG17.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG18.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG19.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG20.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG21.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG22.DropDownStyle = ComboBoxStyle.DropDownList;
            matchG23.DropDownStyle = ComboBoxStyle.DropDownList;
            team1.Hide();
            team1.CustomBackground = true;
            team1.BackColor = Color.White;
            team2.Hide();
            team2.CustomBackground = true;
            team2.BackColor = Color.White;
            team3.Hide();
            team3.CustomBackground = true;
            team3.BackColor = Color.White;
            team4.Hide();
            team4.CustomBackground = true;
            team4.BackColor = Color.White;
            team5.Hide();
            team5.CustomBackground = true;
            team5.BackColor = Color.White;
            team6.Hide();
            team6.CustomBackground = true;
            team6.BackColor = Color.White;
            team7.Hide();
            team7.CustomBackground = true;
            team7.BackColor = Color.White;
            team8.Hide();
            team8.CustomBackground = true;
            team8.BackColor = Color.White;
            team9.Hide();
            team9.CustomBackground = true;
            team9.BackColor = Color.White;
            team10.Hide();
            team10.CustomBackground = true;
            team10.BackColor = Color.White;
            team11.Hide();
            team11.CustomBackground = true;
            team11.BackColor = Color.White;
            team12.Hide();
            team12.CustomBackground = true;
            team12.BackColor = Color.White;
            team13.Hide();
            team13.CustomBackground = true;
            team13.BackColor = Color.White;
            team14.Hide();
            team14.CustomBackground = true;
            team14.BackColor = Color.White;
            team15.Hide();
            team15.CustomBackground = true;
            team15.BackColor = Color.White;
            #endregion

            for (int i = 15; i > divCount; i--)
            {
                //remove non-used divisions
                metTabControl.SelectedIndex = divCount;
                metTabControl.TabPages.Remove(metTabControl.SelectedTab);
            }

            //Calculate match availablity

            for (int div = 0; div < divCount; div++) //for each division
            {
                for (int date = 0; date < 26; date++) //for each date
                {
                    for (int m = 0; m < matchCount[div]; m++) //for each match in division
                    {
                        //store teams at integers for home and away
                        foreach (char c in game[div, m])
                        {
                            if (c != 'v' && c != 's') //if c is a team number
                            {
                                if (previous == "start")
                                {
                                    home = true;
                                    teamHome = (int)Char.GetNumericValue(c);
                                }
                                else if (previous == "s")
                                {
                                    home = false;
                                    teamAway = (int)Char.GetNumericValue(c);
                                }
                                else
                                {
                                    temp = previous + Convert.ToString(c);

                                    if (home == true)
                                    {
                                        teamHome = Convert.ToInt32(temp);
                                    }
                                    else
                                    {
                                        teamAway = Convert.ToInt32(temp);
                                    }
                                }
                            }

                            previous = Convert.ToString(c);
                        }

                        previous = "start";
                        //bool valid = true;

                        //for (int i = 0; i < 13; i++) //for each possible dates home
                        //{
                        //    if (convertDate(datesHome[div, teamAway, i]) == date ||     //team playing away must play home ... invalid match date
                        //        convertDate(datesNoPlay[div, teamHome, i]) == date ||   //team in match cannot play on date ... invalid match date
                        //        convertDate(datesNoPlay[div, teamAway, i]) == date)  
                        //    {
                        //        valid = false;
                        //        count++;
                        //    }
                        //}
                        
                        //if away team not play home and not noPlay for any of the teams in match 
                        //then add match as available for that date

                        //Add another variable to teams called assigned... if not assigned for any of the teams...
                    }
                }
            }

            this.metTabControl.SelectedIndex = 0;
        }

        private int convertDate(string x)
        {
            int res = 1;

            switch (x)
            {
                case "Week 1":
                    res = 1;
                    break;
                case "Week 2":
                    res = 2;
                    break;
                case "Week 3":
                    res = 3;
                    break;
                case "Week 4":
                    res = 4;
                    break;
                case "Week 5":
                    res = 5;
                    break;
                case "Week 6":
                    res = 6;
                    break;
                case "Week 7":
                    res = 7;
                    break;
                case "Week 8":
                    res = 8;
                    break;
                case "Week 9":
                    res = 9;
                    break;
                case "Week 10":
                    res = 10;
                    break;
                case "Week 11":
                    res = 11;
                    break;
                case "Week 12":
                    res = 12;
                    break;
                case "Week 13":
                    res = 13;
                    break;
                case "Week 14":
                    res = 14;
                    break;
                case "Week 15":
                    res = 15;
                    break;
                case "Week 16":
                    res = 16;
                    break;
                case "Week 17":
                    res = 17;
                    break;
                case "Week 18":
                    res = 18;
                    break;
                case "Week 19":
                    res = 19;
                    break;
                case "Week 20":
                    res = 20;
                    break;
                case "Week 21":
                    res = 21;
                    break;
                case "Week 22":
                    res = 22;
                    break;
                case "Week 23":
                    res = 23;
                    break;
                default:
                    res = 100;
                    break;
            }
            return res;
        }

        private void metTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sharedGroundsInfo = "";

            richTextBox1.Hide();
            richTextBox2.Hide();
            richTextBox3.Hide();
            richTextBox4.Hide();
            richTextBox5.Hide();
            richTextBox6.Hide();
            richTextBox7.Hide();
            richTextBox8.Hide();
            richTextBox9.Hide();
            richTextBox10.Hide();
            richTextBox11.Hide();
            richTextBox12.Hide();
            richTextBox13.Hide();
            richTextBox14.Hide();
            richTextBox15.Hide();
            metroLabel24.Hide();
            metroLabel25.Hide();
            line2.Hide();
            line3.Hide();
            line4.Hide();
            line5.Hide();
            line6.Hide();
            line7.Hide();
            line8.Hide();
            line9.Hide();
            line10.Hide();
            line11.Hide();
            line12.Hide();
            line13.Hide();
            line14.Hide();
            sharedLine.Hide();

            //save changes before moving tabs

            //

            division = metTabControl.SelectedIndex; //division = 0 .. 14

            #region Move objects between tabs
            metTabControl.SelectedTab.Controls.Add(team1);
            metTabControl.SelectedTab.Controls.Add(team2);
            metTabControl.SelectedTab.Controls.Add(team3);
            metTabControl.SelectedTab.Controls.Add(team4);
            metTabControl.SelectedTab.Controls.Add(team5);
            metTabControl.SelectedTab.Controls.Add(team6);
            metTabControl.SelectedTab.Controls.Add(team7);
            metTabControl.SelectedTab.Controls.Add(team8);
            metTabControl.SelectedTab.Controls.Add(team9);
            metTabControl.SelectedTab.Controls.Add(team10);
            metTabControl.SelectedTab.Controls.Add(team11);
            metTabControl.SelectedTab.Controls.Add(team12);
            metTabControl.SelectedTab.Controls.Add(team13);
            metTabControl.SelectedTab.Controls.Add(team14);
            metTabControl.SelectedTab.Controls.Add(team15);
            metTabControl.SelectedTab.Controls.Add(metroLabel15);
            metTabControl.SelectedTab.Controls.Add(metroLabel2);
            metTabControl.SelectedTab.Controls.Add(metroLabel13);
            metTabControl.SelectedTab.Controls.Add(metroLabel14);
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
            metTabControl.SelectedTab.Controls.Add(metroLabel11);
            metTabControl.SelectedTab.Controls.Add(metroLabel9);
            metTabControl.SelectedTab.Controls.Add(metroLabel7);
            metTabControl.SelectedTab.Controls.Add(metroLabel5);
            metTabControl.SelectedTab.Controls.Add(metroLabel3);
            metTabControl.SelectedTab.Controls.Add(metroLabel23);
            metTabControl.SelectedTab.Controls.Add(metroLabel21);
            metTabControl.SelectedTab.Controls.Add(metroLabel18);
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
            metTabControl.SelectedTab.Controls.Add(metroLabel10);
            metTabControl.SelectedTab.Controls.Add(metroLabel8);
            metTabControl.SelectedTab.Controls.Add(metroLabel6);
            metTabControl.SelectedTab.Controls.Add(metroLabel4);
            metTabControl.SelectedTab.Controls.Add(metroLabel1);
            metTabControl.SelectedTab.Controls.Add(metroLabel22);
            metTabControl.SelectedTab.Controls.Add(metroLabel20);
            metTabControl.SelectedTab.Controls.Add(metroLabel16);
            metTabControl.SelectedTab.Controls.Add(metroLabel12);
            metTabControl.SelectedTab.Controls.Add(matchA1);
            metTabControl.SelectedTab.Controls.Add(matchA2);
            metTabControl.SelectedTab.Controls.Add(matchA3);
            metTabControl.SelectedTab.Controls.Add(matchA4);
            metTabControl.SelectedTab.Controls.Add(matchA5);
            metTabControl.SelectedTab.Controls.Add(matchA6);
            metTabControl.SelectedTab.Controls.Add(matchA7);
            metTabControl.SelectedTab.Controls.Add(matchA8);
            metTabControl.SelectedTab.Controls.Add(matchA9);
            metTabControl.SelectedTab.Controls.Add(matchA10);
            metTabControl.SelectedTab.Controls.Add(matchA11);
            metTabControl.SelectedTab.Controls.Add(matchA12);
            metTabControl.SelectedTab.Controls.Add(matchA13);
            metTabControl.SelectedTab.Controls.Add(matchA14);
            metTabControl.SelectedTab.Controls.Add(matchA15);
            metTabControl.SelectedTab.Controls.Add(matchA16);
            metTabControl.SelectedTab.Controls.Add(matchA17);
            metTabControl.SelectedTab.Controls.Add(matchA18);
            metTabControl.SelectedTab.Controls.Add(matchA19);
            metTabControl.SelectedTab.Controls.Add(matchA20);
            metTabControl.SelectedTab.Controls.Add(matchA21);
            metTabControl.SelectedTab.Controls.Add(matchA22);
            metTabControl.SelectedTab.Controls.Add(matchA23);
            metTabControl.SelectedTab.Controls.Add(matchB1);
            metTabControl.SelectedTab.Controls.Add(matchB2);
            metTabControl.SelectedTab.Controls.Add(matchB3);
            metTabControl.SelectedTab.Controls.Add(matchB4);
            metTabControl.SelectedTab.Controls.Add(matchB5);
            metTabControl.SelectedTab.Controls.Add(matchB6);
            metTabControl.SelectedTab.Controls.Add(matchB7);
            metTabControl.SelectedTab.Controls.Add(matchB8);
            metTabControl.SelectedTab.Controls.Add(matchB9);
            metTabControl.SelectedTab.Controls.Add(matchB10);
            metTabControl.SelectedTab.Controls.Add(matchB11);
            metTabControl.SelectedTab.Controls.Add(matchB12);
            metTabControl.SelectedTab.Controls.Add(matchB13);
            metTabControl.SelectedTab.Controls.Add(matchB14);
            metTabControl.SelectedTab.Controls.Add(matchB15);
            metTabControl.SelectedTab.Controls.Add(matchB16);
            metTabControl.SelectedTab.Controls.Add(matchB17);
            metTabControl.SelectedTab.Controls.Add(matchB18);
            metTabControl.SelectedTab.Controls.Add(matchB19);
            metTabControl.SelectedTab.Controls.Add(matchB20);
            metTabControl.SelectedTab.Controls.Add(matchB21);
            metTabControl.SelectedTab.Controls.Add(matchB22);
            metTabControl.SelectedTab.Controls.Add(matchB23);
            metTabControl.SelectedTab.Controls.Add(matchC1);
            metTabControl.SelectedTab.Controls.Add(matchC2);
            metTabControl.SelectedTab.Controls.Add(matchC3);
            metTabControl.SelectedTab.Controls.Add(matchC4);
            metTabControl.SelectedTab.Controls.Add(matchC5);
            metTabControl.SelectedTab.Controls.Add(matchC6);
            metTabControl.SelectedTab.Controls.Add(matchC7);
            metTabControl.SelectedTab.Controls.Add(matchC8);
            metTabControl.SelectedTab.Controls.Add(matchC9);
            metTabControl.SelectedTab.Controls.Add(matchC10);
            metTabControl.SelectedTab.Controls.Add(matchC11);
            metTabControl.SelectedTab.Controls.Add(matchC12);
            metTabControl.SelectedTab.Controls.Add(matchC13);
            metTabControl.SelectedTab.Controls.Add(matchC14);
            metTabControl.SelectedTab.Controls.Add(matchC15);
            metTabControl.SelectedTab.Controls.Add(matchC16);
            metTabControl.SelectedTab.Controls.Add(matchC17);
            metTabControl.SelectedTab.Controls.Add(matchC18);
            metTabControl.SelectedTab.Controls.Add(matchC19);
            metTabControl.SelectedTab.Controls.Add(matchC20);
            metTabControl.SelectedTab.Controls.Add(matchC21);
            metTabControl.SelectedTab.Controls.Add(matchC22);
            metTabControl.SelectedTab.Controls.Add(matchC23);
            metTabControl.SelectedTab.Controls.Add(matchD1);
            metTabControl.SelectedTab.Controls.Add(matchD2);
            metTabControl.SelectedTab.Controls.Add(matchD3);
            metTabControl.SelectedTab.Controls.Add(matchD4);
            metTabControl.SelectedTab.Controls.Add(matchD5);
            metTabControl.SelectedTab.Controls.Add(matchD6);
            metTabControl.SelectedTab.Controls.Add(matchD7);
            metTabControl.SelectedTab.Controls.Add(matchD8);
            metTabControl.SelectedTab.Controls.Add(matchD9);
            metTabControl.SelectedTab.Controls.Add(matchD10);
            metTabControl.SelectedTab.Controls.Add(matchD11);
            metTabControl.SelectedTab.Controls.Add(matchD12);
            metTabControl.SelectedTab.Controls.Add(matchD13);
            metTabControl.SelectedTab.Controls.Add(matchD14);
            metTabControl.SelectedTab.Controls.Add(matchD15);
            metTabControl.SelectedTab.Controls.Add(matchD16);
            metTabControl.SelectedTab.Controls.Add(matchD17);
            metTabControl.SelectedTab.Controls.Add(matchD18);
            metTabControl.SelectedTab.Controls.Add(matchD19);
            metTabControl.SelectedTab.Controls.Add(matchD20);
            metTabControl.SelectedTab.Controls.Add(matchD21);
            metTabControl.SelectedTab.Controls.Add(matchD22);
            metTabControl.SelectedTab.Controls.Add(matchD23);
            metTabControl.SelectedTab.Controls.Add(matchE1);
            metTabControl.SelectedTab.Controls.Add(matchE2);
            metTabControl.SelectedTab.Controls.Add(matchE3);
            metTabControl.SelectedTab.Controls.Add(matchE4);
            metTabControl.SelectedTab.Controls.Add(matchE5);
            metTabControl.SelectedTab.Controls.Add(matchE6);
            metTabControl.SelectedTab.Controls.Add(matchE7);
            metTabControl.SelectedTab.Controls.Add(matchE8);
            metTabControl.SelectedTab.Controls.Add(matchE9);
            metTabControl.SelectedTab.Controls.Add(matchE10);
            metTabControl.SelectedTab.Controls.Add(matchE11);
            metTabControl.SelectedTab.Controls.Add(matchE12);
            metTabControl.SelectedTab.Controls.Add(matchE13);
            metTabControl.SelectedTab.Controls.Add(matchE14);
            metTabControl.SelectedTab.Controls.Add(matchE15);
            metTabControl.SelectedTab.Controls.Add(matchE16);
            metTabControl.SelectedTab.Controls.Add(matchE17);
            metTabControl.SelectedTab.Controls.Add(matchE18);
            metTabControl.SelectedTab.Controls.Add(matchE19);
            metTabControl.SelectedTab.Controls.Add(matchE20);
            metTabControl.SelectedTab.Controls.Add(matchE21);
            metTabControl.SelectedTab.Controls.Add(matchE22);
            metTabControl.SelectedTab.Controls.Add(matchE23);
            metTabControl.SelectedTab.Controls.Add(matchF1);
            metTabControl.SelectedTab.Controls.Add(matchF2);
            metTabControl.SelectedTab.Controls.Add(matchF3);
            metTabControl.SelectedTab.Controls.Add(matchF4);
            metTabControl.SelectedTab.Controls.Add(matchF5);
            metTabControl.SelectedTab.Controls.Add(matchF6);
            metTabControl.SelectedTab.Controls.Add(matchF7);
            metTabControl.SelectedTab.Controls.Add(matchF8);
            metTabControl.SelectedTab.Controls.Add(matchF9);
            metTabControl.SelectedTab.Controls.Add(matchF10);
            metTabControl.SelectedTab.Controls.Add(matchF11);
            metTabControl.SelectedTab.Controls.Add(matchF12);
            metTabControl.SelectedTab.Controls.Add(matchF13);
            metTabControl.SelectedTab.Controls.Add(matchF14);
            metTabControl.SelectedTab.Controls.Add(matchF15);
            metTabControl.SelectedTab.Controls.Add(matchF16);
            metTabControl.SelectedTab.Controls.Add(matchF17);
            metTabControl.SelectedTab.Controls.Add(matchF18);
            metTabControl.SelectedTab.Controls.Add(matchF19);
            metTabControl.SelectedTab.Controls.Add(matchF20);
            metTabControl.SelectedTab.Controls.Add(matchF21);
            metTabControl.SelectedTab.Controls.Add(matchF22);
            metTabControl.SelectedTab.Controls.Add(matchF23);
            metTabControl.SelectedTab.Controls.Add(matchG1);
            metTabControl.SelectedTab.Controls.Add(matchG2);
            metTabControl.SelectedTab.Controls.Add(matchG3);
            metTabControl.SelectedTab.Controls.Add(matchG4);
            metTabControl.SelectedTab.Controls.Add(matchG5);
            metTabControl.SelectedTab.Controls.Add(matchG6);
            metTabControl.SelectedTab.Controls.Add(matchG7);
            metTabControl.SelectedTab.Controls.Add(matchG8);
            metTabControl.SelectedTab.Controls.Add(matchG9);
            metTabControl.SelectedTab.Controls.Add(matchG10);
            metTabControl.SelectedTab.Controls.Add(matchG11);
            metTabControl.SelectedTab.Controls.Add(matchG12);
            metTabControl.SelectedTab.Controls.Add(matchG13);
            metTabControl.SelectedTab.Controls.Add(matchG14);
            metTabControl.SelectedTab.Controls.Add(matchG15);
            metTabControl.SelectedTab.Controls.Add(matchG16);
            metTabControl.SelectedTab.Controls.Add(matchG17);
            metTabControl.SelectedTab.Controls.Add(matchG18);
            metTabControl.SelectedTab.Controls.Add(matchG19);
            metTabControl.SelectedTab.Controls.Add(matchG20);
            metTabControl.SelectedTab.Controls.Add(matchG21);
            metTabControl.SelectedTab.Controls.Add(matchG22);
            metTabControl.SelectedTab.Controls.Add(matchG23);
            metTabControl.SelectedTab.Controls.Add(assignA1);
            metTabControl.SelectedTab.Controls.Add(assignA2);
            metTabControl.SelectedTab.Controls.Add(assignA3);
            metTabControl.SelectedTab.Controls.Add(assignA4);
            metTabControl.SelectedTab.Controls.Add(assignA5);
            metTabControl.SelectedTab.Controls.Add(assignA6);
            metTabControl.SelectedTab.Controls.Add(assignA7);
            metTabControl.SelectedTab.Controls.Add(assignA8);
            metTabControl.SelectedTab.Controls.Add(assignA9);
            metTabControl.SelectedTab.Controls.Add(assignA10);
            metTabControl.SelectedTab.Controls.Add(assignA11);
            metTabControl.SelectedTab.Controls.Add(assignA12);
            metTabControl.SelectedTab.Controls.Add(assignA13);
            metTabControl.SelectedTab.Controls.Add(assignA14);
            metTabControl.SelectedTab.Controls.Add(assignA15);
            metTabControl.SelectedTab.Controls.Add(assignA16);
            metTabControl.SelectedTab.Controls.Add(assignA17);
            metTabControl.SelectedTab.Controls.Add(assignA18);
            metTabControl.SelectedTab.Controls.Add(assignA19);
            metTabControl.SelectedTab.Controls.Add(assignA20);
            metTabControl.SelectedTab.Controls.Add(assignA21);
            metTabControl.SelectedTab.Controls.Add(assignA22);
            metTabControl.SelectedTab.Controls.Add(assignA23);
            metTabControl.SelectedTab.Controls.Add(assignB1);
            metTabControl.SelectedTab.Controls.Add(assignB2);
            metTabControl.SelectedTab.Controls.Add(assignB3);
            metTabControl.SelectedTab.Controls.Add(assignB4);
            metTabControl.SelectedTab.Controls.Add(assignB5);
            metTabControl.SelectedTab.Controls.Add(assignB6);
            metTabControl.SelectedTab.Controls.Add(assignB7);
            metTabControl.SelectedTab.Controls.Add(assignB8);
            metTabControl.SelectedTab.Controls.Add(assignB9);
            metTabControl.SelectedTab.Controls.Add(assignB10);
            metTabControl.SelectedTab.Controls.Add(assignB11);
            metTabControl.SelectedTab.Controls.Add(assignB12);
            metTabControl.SelectedTab.Controls.Add(assignB13);
            metTabControl.SelectedTab.Controls.Add(assignB14);
            metTabControl.SelectedTab.Controls.Add(assignB15);
            metTabControl.SelectedTab.Controls.Add(assignB16);
            metTabControl.SelectedTab.Controls.Add(assignB17);
            metTabControl.SelectedTab.Controls.Add(assignB18);
            metTabControl.SelectedTab.Controls.Add(assignB19);
            metTabControl.SelectedTab.Controls.Add(assignB20);
            metTabControl.SelectedTab.Controls.Add(assignB21);
            metTabControl.SelectedTab.Controls.Add(assignB22);
            metTabControl.SelectedTab.Controls.Add(assignB23);
            metTabControl.SelectedTab.Controls.Add(assignC1);
            metTabControl.SelectedTab.Controls.Add(assignC2);
            metTabControl.SelectedTab.Controls.Add(assignC3);
            metTabControl.SelectedTab.Controls.Add(assignC4);
            metTabControl.SelectedTab.Controls.Add(assignC5);
            metTabControl.SelectedTab.Controls.Add(assignC6);
            metTabControl.SelectedTab.Controls.Add(assignC7);
            metTabControl.SelectedTab.Controls.Add(assignC8);
            metTabControl.SelectedTab.Controls.Add(assignC9);
            metTabControl.SelectedTab.Controls.Add(assignC10);
            metTabControl.SelectedTab.Controls.Add(assignC11);
            metTabControl.SelectedTab.Controls.Add(assignC12);
            metTabControl.SelectedTab.Controls.Add(assignC13);
            metTabControl.SelectedTab.Controls.Add(assignC14);
            metTabControl.SelectedTab.Controls.Add(assignC15);
            metTabControl.SelectedTab.Controls.Add(assignC16);
            metTabControl.SelectedTab.Controls.Add(assignC17);
            metTabControl.SelectedTab.Controls.Add(assignC18);
            metTabControl.SelectedTab.Controls.Add(assignC19);
            metTabControl.SelectedTab.Controls.Add(assignC20);
            metTabControl.SelectedTab.Controls.Add(assignC21);
            metTabControl.SelectedTab.Controls.Add(assignC22);
            metTabControl.SelectedTab.Controls.Add(assignC23);
            metTabControl.SelectedTab.Controls.Add(assignD1);
            metTabControl.SelectedTab.Controls.Add(assignD2);
            metTabControl.SelectedTab.Controls.Add(assignD3);
            metTabControl.SelectedTab.Controls.Add(assignD4);
            metTabControl.SelectedTab.Controls.Add(assignD5);
            metTabControl.SelectedTab.Controls.Add(assignD6);
            metTabControl.SelectedTab.Controls.Add(assignD7);
            metTabControl.SelectedTab.Controls.Add(assignD8);
            metTabControl.SelectedTab.Controls.Add(assignD9);
            metTabControl.SelectedTab.Controls.Add(assignD10);
            metTabControl.SelectedTab.Controls.Add(assignD11);
            metTabControl.SelectedTab.Controls.Add(assignD12);
            metTabControl.SelectedTab.Controls.Add(assignD13);
            metTabControl.SelectedTab.Controls.Add(assignD14);
            metTabControl.SelectedTab.Controls.Add(assignD15);
            metTabControl.SelectedTab.Controls.Add(assignD16);
            metTabControl.SelectedTab.Controls.Add(assignD17);
            metTabControl.SelectedTab.Controls.Add(assignD18);
            metTabControl.SelectedTab.Controls.Add(assignD19);
            metTabControl.SelectedTab.Controls.Add(assignD20);
            metTabControl.SelectedTab.Controls.Add(assignD21);
            metTabControl.SelectedTab.Controls.Add(assignD22);
            metTabControl.SelectedTab.Controls.Add(assignD23);
            metTabControl.SelectedTab.Controls.Add(assignE1);
            metTabControl.SelectedTab.Controls.Add(assignE2);
            metTabControl.SelectedTab.Controls.Add(assignE3);
            metTabControl.SelectedTab.Controls.Add(assignE4);
            metTabControl.SelectedTab.Controls.Add(assignE5);
            metTabControl.SelectedTab.Controls.Add(assignE6);
            metTabControl.SelectedTab.Controls.Add(assignE7);
            metTabControl.SelectedTab.Controls.Add(assignE8);
            metTabControl.SelectedTab.Controls.Add(assignE9);
            metTabControl.SelectedTab.Controls.Add(assignE10);
            metTabControl.SelectedTab.Controls.Add(assignE11);
            metTabControl.SelectedTab.Controls.Add(assignE12);
            metTabControl.SelectedTab.Controls.Add(assignE13);
            metTabControl.SelectedTab.Controls.Add(assignE14);
            metTabControl.SelectedTab.Controls.Add(assignE15);
            metTabControl.SelectedTab.Controls.Add(assignE16);
            metTabControl.SelectedTab.Controls.Add(assignE17);
            metTabControl.SelectedTab.Controls.Add(assignE18);
            metTabControl.SelectedTab.Controls.Add(assignE19);
            metTabControl.SelectedTab.Controls.Add(assignE20);
            metTabControl.SelectedTab.Controls.Add(assignE21);
            metTabControl.SelectedTab.Controls.Add(assignE22);
            metTabControl.SelectedTab.Controls.Add(assignE23);
            metTabControl.SelectedTab.Controls.Add(assignF1);
            metTabControl.SelectedTab.Controls.Add(assignF2);
            metTabControl.SelectedTab.Controls.Add(assignF3);
            metTabControl.SelectedTab.Controls.Add(assignF4);
            metTabControl.SelectedTab.Controls.Add(assignF5);
            metTabControl.SelectedTab.Controls.Add(assignF6);
            metTabControl.SelectedTab.Controls.Add(assignF7);
            metTabControl.SelectedTab.Controls.Add(assignF8);
            metTabControl.SelectedTab.Controls.Add(assignF9);
            metTabControl.SelectedTab.Controls.Add(assignF10);
            metTabControl.SelectedTab.Controls.Add(assignF11);
            metTabControl.SelectedTab.Controls.Add(assignF12);
            metTabControl.SelectedTab.Controls.Add(assignF13);
            metTabControl.SelectedTab.Controls.Add(assignF14);
            metTabControl.SelectedTab.Controls.Add(assignF15);
            metTabControl.SelectedTab.Controls.Add(assignF16);
            metTabControl.SelectedTab.Controls.Add(assignF17);
            metTabControl.SelectedTab.Controls.Add(assignF18);
            metTabControl.SelectedTab.Controls.Add(assignF19);
            metTabControl.SelectedTab.Controls.Add(assignF20);
            metTabControl.SelectedTab.Controls.Add(assignF21);
            metTabControl.SelectedTab.Controls.Add(assignF22);
            metTabControl.SelectedTab.Controls.Add(assignF23);
            metTabControl.SelectedTab.Controls.Add(assignG1);
            metTabControl.SelectedTab.Controls.Add(assignG2);
            metTabControl.SelectedTab.Controls.Add(assignG3);
            metTabControl.SelectedTab.Controls.Add(assignG4);
            metTabControl.SelectedTab.Controls.Add(assignG5);
            metTabControl.SelectedTab.Controls.Add(assignG6);
            metTabControl.SelectedTab.Controls.Add(assignG7);
            metTabControl.SelectedTab.Controls.Add(assignG8);
            metTabControl.SelectedTab.Controls.Add(assignG9);
            metTabControl.SelectedTab.Controls.Add(assignG10);
            metTabControl.SelectedTab.Controls.Add(assignG11);
            metTabControl.SelectedTab.Controls.Add(assignG12);
            metTabControl.SelectedTab.Controls.Add(assignG13);
            metTabControl.SelectedTab.Controls.Add(assignG14);
            metTabControl.SelectedTab.Controls.Add(assignG15);
            metTabControl.SelectedTab.Controls.Add(assignG16);
            metTabControl.SelectedTab.Controls.Add(assignG17);
            metTabControl.SelectedTab.Controls.Add(assignG18);
            metTabControl.SelectedTab.Controls.Add(assignG19);
            metTabControl.SelectedTab.Controls.Add(assignG20);
            metTabControl.SelectedTab.Controls.Add(assignG21);
            metTabControl.SelectedTab.Controls.Add(assignG22);
            metTabControl.SelectedTab.Controls.Add(assignG23);
            metTabControl.SelectedTab.Controls.Add(richTextBox1);
            metTabControl.SelectedTab.Controls.Add(richTextBox2);
            metTabControl.SelectedTab.Controls.Add(richTextBox3);
            metTabControl.SelectedTab.Controls.Add(richTextBox4);
            metTabControl.SelectedTab.Controls.Add(richTextBox5);
            metTabControl.SelectedTab.Controls.Add(richTextBox6);
            metTabControl.SelectedTab.Controls.Add(richTextBox7);
            metTabControl.SelectedTab.Controls.Add(richTextBox8);
            metTabControl.SelectedTab.Controls.Add(richTextBox9);
            metTabControl.SelectedTab.Controls.Add(richTextBox10);
            metTabControl.SelectedTab.Controls.Add(richTextBox11);
            metTabControl.SelectedTab.Controls.Add(richTextBox12);
            metTabControl.SelectedTab.Controls.Add(richTextBox13);
            metTabControl.SelectedTab.Controls.Add(richTextBox14);
            metTabControl.SelectedTab.Controls.Add(richTextBox15);
            metTabControl.SelectedTab.Controls.Add(metroLabel24);
            metTabControl.SelectedTab.Controls.Add(metroLabel25);
            metTabControl.SelectedTab.Controls.Add(line2);
            metTabControl.SelectedTab.Controls.Add(line3);
            metTabControl.SelectedTab.Controls.Add(line4);
            metTabControl.SelectedTab.Controls.Add(line5);
            metTabControl.SelectedTab.Controls.Add(line6);
            metTabControl.SelectedTab.Controls.Add(line7);
            metTabControl.SelectedTab.Controls.Add(line8);
            metTabControl.SelectedTab.Controls.Add(line9);
            metTabControl.SelectedTab.Controls.Add(line10);
            metTabControl.SelectedTab.Controls.Add(line11);
            metTabControl.SelectedTab.Controls.Add(line12);
            metTabControl.SelectedTab.Controls.Add(line13);
            metTabControl.SelectedTab.Controls.Add(line14);
            metTabControl.SelectedTab.Controls.Add(sharedLine);
            metroLabel15.BringToFront();
            lblBack.BringToFront();
            lblBack1.BringToFront();
            lblBack2.BringToFront();
            lblBack3.BringToFront();
            lblBack4.BringToFront();
            lblBack5.BringToFront();
            lblBack6.BringToFront();
            lblBack7.BringToFront();
            lblBack8.BringToFront();
            lblBack9.BringToFront();
            lblBack10.BringToFront();
            lblBack11.BringToFront();
            lblBack12.BringToFront();
            lblBack13.BringToFront();
            lblBack14.BringToFront();
            metroLabel11.BringToFront();
            metroLabel9.BringToFront();
            metroLabel7.BringToFront();
            metroLabel5.BringToFront();
            metroLabel3.BringToFront();
            metroLabel23.BringToFront();
            metroLabel21.BringToFront();
            metroLabel18.BringToFront();
            txtTeam.BringToFront();
            txtTeam1.BringToFront();
            txtTeam2.BringToFront();
            txtTeam3.BringToFront();
            txtTeam4.BringToFront();
            txtTeam5.BringToFront();
            txtTeam6.BringToFront();
            txtTeam7.BringToFront();
            txtTeam8.BringToFront();
            txtTeam9.BringToFront();
            txtTeam10.BringToFront();
            txtTeam11.BringToFront();
            txtTeam12.BringToFront();
            txtTeam13.BringToFront();
            txtTeam14.BringToFront();
            metroLabel10.BringToFront();
            metroLabel8.BringToFront();
            metroLabel6.BringToFront();
            metroLabel4.BringToFront();
            metroLabel1.BringToFront();
            metroLabel22.BringToFront();
            metroLabel20.BringToFront();
            metroLabel16.BringToFront();
            metroLabel12.BringToFront();
            metroLabel15.BringToFront();
            richTextBox1.BringToFront();
            richTextBox2.BringToFront();
            richTextBox3.BringToFront();
            richTextBox4.BringToFront();
            richTextBox5.BringToFront();
            richTextBox6.BringToFront();
            richTextBox7.BringToFront();
            richTextBox8.BringToFront();
            richTextBox9.BringToFront();
            richTextBox10.BringToFront();
            richTextBox11.BringToFront();
            richTextBox12.BringToFront();
            richTextBox13.BringToFront();
            richTextBox14.BringToFront();
            richTextBox15.BringToFront();
            metroLabel24.BringToFront();
            metroLabel25.BringToFront();
            line2.BringToFront();
            line3.BringToFront();
            line4.BringToFront();
            line5.BringToFront();
            line6.BringToFront();
            line7.BringToFront();
            line8.BringToFront();
            line9.BringToFront();
            line10.BringToFront();
            line11.BringToFront();
            line12.BringToFront();
            line13.BringToFront();
            line14.BringToFront();
            sharedLine.BringToFront();
            team1.BringToFront();
            team2.BringToFront();
            team3.BringToFront();
            team4.BringToFront();
            team5.BringToFront();
            team6.BringToFront();
            team7.BringToFront();
            team8.BringToFront();
            team9.BringToFront();
            team10.BringToFront();
            team11.BringToFront();
            team12.BringToFront();
            team13.BringToFront();
            team14.BringToFront();
            team15.BringToFront();
            metroLabel2.BringToFront();
            metroLabel13.BringToFront();
            metroLabel14.BringToFront();
            assignA1.BringToFront();
            assignA2.BringToFront();
            assignA3.BringToFront();
            assignA4.BringToFront();
            assignA5.BringToFront();
            assignA6.BringToFront();
            assignA7.BringToFront();
            assignA8.BringToFront();
            assignA9.BringToFront();
            assignA10.BringToFront();
            assignA11.BringToFront();
            assignA12.BringToFront();
            assignA13.BringToFront();
            assignA14.BringToFront();
            assignA15.BringToFront();
            assignA16.BringToFront();
            assignA17.BringToFront();
            assignA18.BringToFront();
            assignA19.BringToFront();
            assignA20.BringToFront();
            assignA21.BringToFront();
            assignA22.BringToFront();
            assignA23.BringToFront();
            assignB1.BringToFront();
            assignB2.BringToFront();
            assignB3.BringToFront();
            assignB4.BringToFront();
            assignB5.BringToFront();
            assignB6.BringToFront();
            assignB7.BringToFront();
            assignB8.BringToFront();
            assignB9.BringToFront();
            assignB10.BringToFront();
            assignB11.BringToFront();
            assignB12.BringToFront();
            assignB13.BringToFront();
            assignB14.BringToFront();
            assignB15.BringToFront();
            assignB16.BringToFront();
            assignB17.BringToFront();
            assignB18.BringToFront();
            assignB19.BringToFront();
            assignB20.BringToFront();
            assignB21.BringToFront();
            assignB22.BringToFront();
            assignB23.BringToFront();
            assignC1.BringToFront();
            assignC2.BringToFront();
            assignC3.BringToFront();
            assignC4.BringToFront();
            assignC5.BringToFront();
            assignC6.BringToFront();
            assignC7.BringToFront();
            assignC8.BringToFront();
            assignC9.BringToFront();
            assignC10.BringToFront();
            assignC11.BringToFront();
            assignC12.BringToFront();
            assignC13.BringToFront();
            assignC14.BringToFront();
            assignC15.BringToFront();
            assignC16.BringToFront();
            assignC17.BringToFront();
            assignC18.BringToFront();
            assignC19.BringToFront();
            assignC20.BringToFront();
            assignC21.BringToFront();
            assignC22.BringToFront();
            assignC23.BringToFront();
            assignD1.BringToFront();
            assignD2.BringToFront();
            assignD3.BringToFront();
            assignD4.BringToFront();
            assignD5.BringToFront();
            assignD6.BringToFront();
            assignD7.BringToFront();
            assignD8.BringToFront();
            assignD9.BringToFront();
            assignD10.BringToFront();
            assignD11.BringToFront();
            assignD12.BringToFront();
            assignD13.BringToFront();
            assignD14.BringToFront();
            assignD15.BringToFront();
            assignD16.BringToFront();
            assignD17.BringToFront();
            assignD18.BringToFront();
            assignD19.BringToFront();
            assignD20.BringToFront();
            assignD21.BringToFront();
            assignD22.BringToFront();
            assignD23.BringToFront();
            assignE1.BringToFront();
            assignE2.BringToFront();
            assignE3.BringToFront();
            assignE4.BringToFront();
            assignE5.BringToFront();
            assignE6.BringToFront();
            assignE7.BringToFront();
            assignE8.BringToFront();
            assignE9.BringToFront();
            assignE10.BringToFront();
            assignE11.BringToFront();
            assignE12.BringToFront();
            assignE13.BringToFront();
            assignE14.BringToFront();
            assignE15.BringToFront();
            assignE16.BringToFront();
            assignE17.BringToFront();
            assignE18.BringToFront();
            assignE19.BringToFront();
            assignE20.BringToFront();
            assignE21.BringToFront();
            assignE22.BringToFront();
            assignE23.BringToFront();
            assignF1.BringToFront();
            assignF2.BringToFront();
            assignF3.BringToFront();
            assignF4.BringToFront();
            assignF5.BringToFront();
            assignF6.BringToFront();
            assignF7.BringToFront();
            assignF8.BringToFront();
            assignF9.BringToFront();
            assignF10.BringToFront();
            assignF11.BringToFront();
            assignF12.BringToFront();
            assignF13.BringToFront();
            assignF14.BringToFront();
            assignF15.BringToFront();
            assignF16.BringToFront();
            assignF17.BringToFront();
            assignF18.BringToFront();
            assignF19.BringToFront();
            assignF20.BringToFront();
            assignF21.BringToFront();
            assignF22.BringToFront();
            assignF23.BringToFront();
            assignG1.BringToFront();
            assignG2.BringToFront();
            assignG3.BringToFront();
            assignG4.BringToFront();
            assignG5.BringToFront();
            assignG6.BringToFront();
            assignG7.BringToFront();
            assignG8.BringToFront();
            assignG9.BringToFront();
            assignG10.BringToFront();
            assignG11.BringToFront();
            assignG12.BringToFront();
            assignG13.BringToFront();
            assignG14.BringToFront();
            assignG15.BringToFront();
            assignG16.BringToFront();
            assignG17.BringToFront();
            assignG18.BringToFront();
            assignG19.BringToFront();
            assignG20.BringToFront();
            assignG21.BringToFront();
            assignG22.BringToFront();
            assignG23.BringToFront();
            matchA1.BringToFront();
            matchA2.BringToFront();
            matchA3.BringToFront();
            matchA4.BringToFront();
            matchA5.BringToFront();
            matchA6.BringToFront();
            matchA7.BringToFront();
            matchA8.BringToFront();
            matchA9.BringToFront();
            matchA10.BringToFront();
            matchA11.BringToFront();
            matchA12.BringToFront();
            matchA13.BringToFront();
            matchA14.BringToFront();
            matchA15.BringToFront();
            matchA16.BringToFront();
            matchA17.BringToFront();
            matchA18.BringToFront();
            matchA19.BringToFront();
            matchA20.BringToFront();
            matchA21.BringToFront();
            matchA22.BringToFront();
            matchA23.BringToFront();
            matchB1.BringToFront();
            matchB2.BringToFront();
            matchB3.BringToFront();
            matchB4.BringToFront();
            matchB5.BringToFront();
            matchB6.BringToFront();
            matchB7.BringToFront();
            matchB8.BringToFront();
            matchB9.BringToFront();
            matchB10.BringToFront();
            matchB11.BringToFront();
            matchB12.BringToFront();
            matchB13.BringToFront();
            matchB14.BringToFront();
            matchB15.BringToFront();
            matchB16.BringToFront();
            matchB17.BringToFront();
            matchB18.BringToFront();
            matchB19.BringToFront();
            matchB20.BringToFront();
            matchB21.BringToFront();
            matchB22.BringToFront();
            matchB23.BringToFront();
            matchC1.BringToFront();
            matchC2.BringToFront();
            matchC3.BringToFront();
            matchC4.BringToFront();
            matchC5.BringToFront();
            matchC6.BringToFront();
            matchC7.BringToFront();
            matchC8.BringToFront();
            matchC9.BringToFront();
            matchC10.BringToFront();
            matchC11.BringToFront();
            matchC12.BringToFront();
            matchC13.BringToFront();
            matchC14.BringToFront();
            matchC15.BringToFront();
            matchC16.BringToFront();
            matchC17.BringToFront();
            matchC18.BringToFront();
            matchC19.BringToFront();
            matchC20.BringToFront();
            matchC21.BringToFront();
            matchC22.BringToFront();
            matchC23.BringToFront();
            matchD1.BringToFront();
            matchD2.BringToFront();
            matchD3.BringToFront();
            matchD4.BringToFront();
            matchD5.BringToFront();
            matchD6.BringToFront();
            matchD7.BringToFront();
            matchD8.BringToFront();
            matchD9.BringToFront();
            matchD10.BringToFront();
            matchD11.BringToFront();
            matchD12.BringToFront();
            matchD13.BringToFront();
            matchD14.BringToFront();
            matchD15.BringToFront();
            matchD16.BringToFront();
            matchD17.BringToFront();
            matchD18.BringToFront();
            matchD19.BringToFront();
            matchD20.BringToFront();
            matchD21.BringToFront();
            matchD22.BringToFront();
            matchD23.BringToFront();
            matchE1.BringToFront();
            matchE2.BringToFront();
            matchE3.BringToFront();
            matchE4.BringToFront();
            matchE5.BringToFront();
            matchE6.BringToFront();
            matchE7.BringToFront();
            matchE8.BringToFront();
            matchE9.BringToFront();
            matchE10.BringToFront();
            matchE11.BringToFront();
            matchE12.BringToFront();
            matchE13.BringToFront();
            matchE14.BringToFront();
            matchE15.BringToFront();
            matchE16.BringToFront();
            matchE17.BringToFront();
            matchE18.BringToFront();
            matchE19.BringToFront();
            matchE20.BringToFront();
            matchE21.BringToFront();
            matchE22.BringToFront();
            matchE23.BringToFront();
            matchF1.BringToFront();
            matchF2.BringToFront();
            matchF3.BringToFront();
            matchF4.BringToFront();
            matchF5.BringToFront();
            matchF6.BringToFront();
            matchF7.BringToFront();
            matchF8.BringToFront();
            matchF9.BringToFront();
            matchF10.BringToFront();
            matchF11.BringToFront();
            matchF12.BringToFront();
            matchF13.BringToFront();
            matchF14.BringToFront();
            matchF15.BringToFront();
            matchF16.BringToFront();
            matchF17.BringToFront();
            matchF18.BringToFront();
            matchF19.BringToFront();
            matchF20.BringToFront();
            matchF21.BringToFront();
            matchF22.BringToFront();
            matchF23.BringToFront();
            matchG1.BringToFront();
            matchG2.BringToFront();
            matchG3.BringToFront();
            matchG4.BringToFront();
            matchG5.BringToFront();
            matchG6.BringToFront();
            matchG7.BringToFront();
            matchG8.BringToFront();
            matchG9.BringToFront();
            matchG10.BringToFront();
            matchG11.BringToFront();
            matchG12.BringToFront();
            matchG13.BringToFront();
            matchG14.BringToFront();
            matchG15.BringToFront();
            matchG16.BringToFront();
            matchG17.BringToFront();
            matchG18.BringToFront();
            matchG19.BringToFront();
            matchG20.BringToFront();
            matchG21.BringToFront();
            matchG22.BringToFront();
            matchG23.BringToFront();
            #endregion

            #region Display correct number of possible possible matches per date
            assignA1.Show();
            assignA2.Show();
            assignA3.Show();
            assignA4.Show();
            assignA5.Show();
            assignA6.Show();
            assignA7.Show();
            assignA8.Show();
            assignA9.Show();
            assignA10.Show();
            assignA11.Show();
            assignA12.Show();
            assignA13.Show();
            assignA14.Show();
            assignA15.Show();
            assignA16.Show();
            assignA17.Show();
            assignA18.Show();
            assignA19.Show();
            assignA20.Show();
            assignA21.Show();
            assignA22.Show();
            assignA23.Show();
            assignB1.Show();
            assignB2.Show();
            assignB3.Show();
            assignB4.Show();
            assignB5.Show();
            assignB6.Show();
            assignB7.Show();
            assignB8.Show();
            assignB9.Show();
            assignB10.Show();
            assignB11.Show();
            assignB12.Show();
            assignB13.Show();
            assignB14.Show();
            assignB15.Show();
            assignB16.Show();
            assignB17.Show();
            assignB18.Show();
            assignB19.Show();
            assignB20.Show();
            assignB21.Show();
            assignB22.Show();
            assignB23.Show();
            assignC1.Show();
            assignC2.Show();
            assignC3.Show();
            assignC4.Show();
            assignC5.Show();
            assignC6.Show();
            assignC7.Show();
            assignC8.Show();
            assignC9.Show();
            assignC10.Show();
            assignC11.Show();
            assignC12.Show();
            assignC13.Show();
            assignC14.Show();
            assignC15.Show();
            assignC16.Show();
            assignC17.Show();
            assignC18.Show();
            assignC19.Show();
            assignC20.Show();
            assignC21.Show();
            assignC22.Show();
            assignC23.Show();
            assignD1.Show();
            assignD2.Show();
            assignD3.Show();
            assignD4.Show();
            assignD5.Show();
            assignD6.Show();
            assignD7.Show();
            assignD8.Show();
            assignD9.Show();
            assignD10.Show();
            assignD11.Show();
            assignD12.Show();
            assignD13.Show();
            assignD14.Show();
            assignD15.Show();
            assignD16.Show();
            assignD17.Show();
            assignD18.Show();
            assignD19.Show();
            assignD20.Show();
            assignD21.Show();
            assignD22.Show();
            assignD23.Show();
            assignE1.Show();
            assignE2.Show();
            assignE3.Show();
            assignE4.Show();
            assignE5.Show();
            assignE6.Show();
            assignE7.Show();
            assignE8.Show();
            assignE9.Show();
            assignE10.Show();
            assignE11.Show();
            assignE12.Show();
            assignE13.Show();
            assignE14.Show();
            assignE15.Show();
            assignE16.Show();
            assignE17.Show();
            assignE18.Show();
            assignE19.Show();
            assignE20.Show();
            assignE21.Show();
            assignE22.Show();
            assignE23.Show();
            assignF1.Show();
            assignF2.Show();
            assignF3.Show();
            assignF4.Show();
            assignF5.Show();
            assignF6.Show();
            assignF7.Show();
            assignF8.Show();
            assignF9.Show();
            assignF10.Show();
            assignF11.Show();
            assignF12.Show();
            assignF13.Show();
            assignF14.Show();
            assignF15.Show();
            assignF16.Show();
            assignF17.Show();
            assignF18.Show();
            assignF19.Show();
            assignF20.Show();
            assignF21.Show();
            assignF22.Show();
            assignF23.Show();
            assignG1.Show();
            assignG2.Show();
            assignG3.Show();
            assignG4.Show();
            assignG5.Show();
            assignG6.Show();
            assignG7.Show();
            assignG8.Show();
            assignG9.Show();
            assignG10.Show();
            assignG11.Show();
            assignG12.Show();
            assignG13.Show();
            assignG14.Show();
            assignG15.Show();
            assignG16.Show();
            assignG17.Show();
            assignG18.Show();
            assignG19.Show();
            assignG20.Show();
            assignG21.Show();
            assignG22.Show();
            assignG23.Show();
            matchA1.Show();
            matchA2.Show();
            matchA3.Show();
            matchA4.Show();
            matchA5.Show();
            matchA6.Show();
            matchA7.Show();
            matchA8.Show();
            matchA9.Show();
            matchA10.Show();
            matchA11.Show();
            matchA12.Show();
            matchA13.Show();
            matchA14.Show();
            matchA15.Show();
            matchA16.Show();
            matchA17.Show();
            matchA18.Show();
            matchA19.Show();
            matchA20.Show();
            matchA21.Show();
            matchA22.Show();
            matchA23.Show();
            matchB1.Show();
            matchB2.Show();
            matchB3.Show();
            matchB4.Show();
            matchB5.Show();
            matchB6.Show();
            matchB7.Show();
            matchB8.Show();
            matchB9.Show();
            matchB10.Show();
            matchB11.Show();
            matchB12.Show();
            matchB13.Show();
            matchB14.Show();
            matchB15.Show();
            matchB16.Show();
            matchB17.Show();
            matchB18.Show();
            matchB19.Show();
            matchB20.Show();
            matchB21.Show();
            matchB22.Show();
            matchB23.Show();
            matchC1.Show();
            matchC2.Show();
            matchC3.Show();
            matchC4.Show();
            matchC5.Show();
            matchC6.Show();
            matchC7.Show();
            matchC8.Show();
            matchC9.Show();
            matchC10.Show();
            matchC11.Show();
            matchC12.Show();
            matchC13.Show();
            matchC14.Show();
            matchC15.Show();
            matchC16.Show();
            matchC17.Show();
            matchC18.Show();
            matchC19.Show();
            matchC20.Show();
            matchC21.Show();
            matchC22.Show();
            matchC23.Show();
            matchD1.Show();
            matchD2.Show();
            matchD3.Show();
            matchD4.Show();
            matchD5.Show();
            matchD6.Show();
            matchD7.Show();
            matchD8.Show();
            matchD9.Show();
            matchD10.Show();
            matchD11.Show();
            matchD12.Show();
            matchD13.Show();
            matchD14.Show();
            matchD15.Show();
            matchD16.Show();
            matchD17.Show();
            matchD18.Show();
            matchD19.Show();
            matchD20.Show();
            matchD21.Show();
            matchD22.Show();
            matchD23.Show();
            matchE1.Show();
            matchE2.Show();
            matchE3.Show();
            matchE4.Show();
            matchE5.Show();
            matchE6.Show();
            matchE7.Show();
            matchE8.Show();
            matchE9.Show();
            matchE10.Show();
            matchE11.Show();
            matchE12.Show();
            matchE13.Show();
            matchE14.Show();
            matchE15.Show();
            matchE16.Show();
            matchE17.Show();
            matchE18.Show();
            matchE19.Show();
            matchE20.Show();
            matchE21.Show();
            matchE22.Show();
            matchE23.Show();
            matchF1.Show();
            matchF2.Show();
            matchF3.Show();
            matchF4.Show();
            matchF5.Show();
            matchF6.Show();
            matchF7.Show();
            matchF8.Show();
            matchF9.Show();
            matchF10.Show();
            matchF11.Show();
            matchF12.Show();
            matchF13.Show();
            matchF14.Show();
            matchF15.Show();
            matchF16.Show();
            matchF17.Show();
            matchF18.Show();
            matchF19.Show();
            matchF20.Show();
            matchF21.Show();
            matchF22.Show();
            matchF23.Show();
            matchG1.Show();
            matchG2.Show();
            matchG3.Show();
            matchG4.Show();
            matchG5.Show();
            matchG6.Show();
            matchG7.Show();
            matchG8.Show();
            matchG9.Show();
            matchG10.Show();
            matchG11.Show();
            matchG12.Show();
            matchG13.Show();
            matchG14.Show();
            matchG15.Show();
            matchG16.Show();
            matchG17.Show();
            matchG18.Show();
            matchG19.Show();
            matchG20.Show();
            matchG21.Show();
            matchG22.Show();
            matchG23.Show();

            if (teamCount[division] == 0 || teamCount[division] /2 == 6 || teamCount[division] / 2 == 5 || teamCount[division] / 2 == 4 || teamCount[division] / 2 == 3 || teamCount[division] / 2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide G
                assignG1.Hide();
                assignG2.Hide();
                assignG3.Hide();
                assignG4.Hide();
                assignG5.Hide();
                assignG6.Hide();
                assignG7.Hide();
                assignG8.Hide();
                assignG9.Hide();
                assignG10.Hide();
                assignG11.Hide();
                assignG12.Hide();
                assignG13.Hide();
                assignG14.Hide();
                assignG15.Hide();
                assignG16.Hide();
                assignG17.Hide();
                assignG18.Hide();
                assignG19.Hide();
                assignG20.Hide();
                assignG21.Hide();
                assignG22.Hide();
                assignG23.Hide();
                matchG1.Hide();
                matchG2.Hide();
                matchG3.Hide();
                matchG4.Hide();
                matchG5.Hide();
                matchG6.Hide();
                matchG7.Hide();
                matchG8.Hide();
                matchG9.Hide();
                matchG10.Hide();
                matchG11.Hide();
                matchG12.Hide();
                matchG13.Hide();
                matchG14.Hide();
                matchG15.Hide();
                matchG16.Hide();
                matchG17.Hide();
                matchG18.Hide();
                matchG19.Hide();
                matchG20.Hide();
                matchG21.Hide();
                matchG22.Hide();
                matchG23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 5 || teamCount[division] / 2 == 4 || teamCount[division] / 2 == 3 || teamCount[division] / 2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide F
                assignF1.Hide();
                assignF2.Hide();
                assignF3.Hide();
                assignF4.Hide();
                assignF5.Hide();
                assignF6.Hide();
                assignF7.Hide();
                assignF8.Hide();
                assignF9.Hide();
                assignF10.Hide();
                assignF11.Hide();
                assignF12.Hide();
                assignF13.Hide();
                assignF14.Hide();
                assignF15.Hide();
                assignF16.Hide();
                assignF17.Hide();
                assignF18.Hide();
                assignF19.Hide();
                assignF20.Hide();
                assignF21.Hide();
                assignF22.Hide();
                assignF23.Hide();
                matchF1.Hide();
                matchF2.Hide();
                matchF3.Hide();
                matchF4.Hide();
                matchF5.Hide();
                matchF6.Hide();
                matchF7.Hide();
                matchF8.Hide();
                matchF9.Hide();
                matchF10.Hide();
                matchF11.Hide();
                matchF12.Hide();
                matchF13.Hide();
                matchF14.Hide();
                matchF15.Hide();
                matchF16.Hide();
                matchF17.Hide();
                matchF18.Hide();
                matchF19.Hide();
                matchF20.Hide();
                matchF21.Hide();
                matchF22.Hide();
                matchF23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 4 || teamCount[division] / 2 == 3 || teamCount[division] / 2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide E
                assignE1.Hide();
                assignE2.Hide();
                assignE3.Hide();
                assignE4.Hide();
                assignE5.Hide();
                assignE6.Hide();
                assignE7.Hide();
                assignE8.Hide();
                assignE9.Hide();
                assignE10.Hide();
                assignE11.Hide();
                assignE12.Hide();
                assignE13.Hide();
                assignE14.Hide();
                assignE15.Hide();
                assignE16.Hide();
                assignE17.Hide();
                assignE18.Hide();
                assignE19.Hide();
                assignE20.Hide();
                assignE21.Hide();
                assignE22.Hide();
                assignE23.Hide();
                matchE1.Hide();
                matchE2.Hide();
                matchE3.Hide();
                matchE4.Hide();
                matchE5.Hide();
                matchE6.Hide();
                matchE7.Hide();
                matchE8.Hide();
                matchE9.Hide();
                matchE10.Hide();
                matchE11.Hide();
                matchE12.Hide();
                matchE13.Hide();
                matchE14.Hide();
                matchE15.Hide();
                matchE16.Hide();
                matchE17.Hide();
                matchE18.Hide();
                matchE19.Hide();
                matchE20.Hide();
                matchE21.Hide();
                matchE22.Hide();
                matchE23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 3 || teamCount[division] / 2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide D
                assignD1.Hide();
                assignD2.Hide();
                assignD3.Hide();
                assignD4.Hide();
                assignD5.Hide();
                assignD6.Hide();
                assignD7.Hide();
                assignD8.Hide();
                assignD9.Hide();
                assignD10.Hide();
                assignD11.Hide();
                assignD12.Hide();
                assignD13.Hide();
                assignD14.Hide();
                assignD15.Hide();
                assignD16.Hide();
                assignD17.Hide();
                assignD18.Hide();
                assignD19.Hide();
                assignD20.Hide();
                assignD21.Hide();
                assignD22.Hide();
                assignD23.Hide();
                matchD1.Hide();
                matchD2.Hide();
                matchD3.Hide();
                matchD4.Hide();
                matchD5.Hide();
                matchD6.Hide();
                matchD7.Hide();
                matchD8.Hide();
                matchD9.Hide();
                matchD10.Hide();
                matchD11.Hide();
                matchD12.Hide();
                matchD13.Hide();
                matchD14.Hide();
                matchD15.Hide();
                matchD16.Hide();
                matchD17.Hide();
                matchD18.Hide();
                matchD19.Hide();
                matchD20.Hide();
                matchD21.Hide();
                matchD22.Hide();
                matchD23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 2 || teamCount[division] / 2 == 1)
            {
                //Hide C
                assignC1.Hide();
                assignC2.Hide();
                assignC3.Hide();
                assignC4.Hide();
                assignC5.Hide();
                assignC6.Hide();
                assignC7.Hide();
                assignC8.Hide();
                assignC9.Hide();
                assignC10.Hide();
                assignC11.Hide();
                assignC12.Hide();
                assignC13.Hide();
                assignC14.Hide();
                assignC15.Hide();
                assignC16.Hide();
                assignC17.Hide();
                assignC18.Hide();
                assignC19.Hide();
                assignC20.Hide();
                assignC21.Hide();
                assignC22.Hide();
                assignC23.Hide();
                matchC1.Hide();
                matchC2.Hide();
                matchC3.Hide();
                matchC4.Hide();
                matchC5.Hide();
                matchC6.Hide();
                matchC7.Hide();
                matchC8.Hide();
                matchC9.Hide();
                matchC10.Hide();
                matchC11.Hide();
                matchC12.Hide();
                matchC13.Hide();
                matchC14.Hide();
                matchC15.Hide();
                matchC16.Hide();
                matchC17.Hide();
                matchC18.Hide();
                matchC19.Hide();
                matchC20.Hide();
                matchC21.Hide();
                matchC22.Hide();
                matchC23.Hide();
            }

            if (teamCount[division] == 0 || teamCount[division] /2 == 1)
            {
                //Hide B
                assignB1.Hide();
                assignB2.Hide();
                assignB3.Hide();
                assignB4.Hide();
                assignB5.Hide();
                assignB6.Hide();
                assignB7.Hide();
                assignB8.Hide();
                assignB9.Hide();
                assignB10.Hide();
                assignB11.Hide();
                assignB12.Hide();
                assignB13.Hide();
                assignB14.Hide();
                assignB15.Hide();
                assignB16.Hide();
                assignB17.Hide();
                assignB18.Hide();
                assignB19.Hide();
                assignB20.Hide();
                assignB21.Hide();
                assignB22.Hide();
                assignB23.Hide();
                matchB1.Hide();
                matchB2.Hide();
                matchB3.Hide();
                matchB4.Hide();
                matchB5.Hide();
                matchB6.Hide();
                matchB7.Hide();
                matchB8.Hide();
                matchB9.Hide();
                matchB10.Hide();
                matchB11.Hide();
                matchB12.Hide();
                matchB13.Hide();
                matchB14.Hide();
                matchB15.Hide();
                matchB16.Hide();
                matchB17.Hide();
                matchB18.Hide();
                matchB19.Hide();
                matchB20.Hide();
                matchB21.Hide();
                matchB22.Hide();
                matchB23.Hide();
            }

            if (teamCount[division] == 0)
            {
                //Hide A
                assignA1.Hide();
                assignA2.Hide();
                assignA3.Hide();
                assignA4.Hide();
                assignA5.Hide();
                assignA6.Hide();
                assignA7.Hide();
                assignA8.Hide();
                assignA9.Hide();
                assignA10.Hide();
                assignA11.Hide();
                assignA12.Hide();
                assignA13.Hide();
                assignA14.Hide();
                assignA15.Hide();
                assignA16.Hide();
                assignA17.Hide();
                assignA18.Hide();
                assignA19.Hide();
                assignA20.Hide();
                assignA21.Hide();
                assignA22.Hide();
                assignA23.Hide();
                matchA1.Hide();
                matchA2.Hide();
                matchA3.Hide();
                matchA4.Hide();
                matchA5.Hide();
                matchA6.Hide();
                matchA7.Hide();
                matchA8.Hide();
                matchA9.Hide();
                matchA10.Hide();
                matchA11.Hide();
                matchA12.Hide();
                matchA13.Hide();
                matchA14.Hide();
                matchA15.Hide();
                matchA16.Hide();
                matchA17.Hide();
                matchA18.Hide();
                matchA19.Hide();
                matchA20.Hide();
                matchA21.Hide();
                matchA22.Hide();
                matchA23.Hide();
            }
            #endregion

            #region Display teams key + Shared grounds indicator
            switch (teamCount[division])
            {
                case 0:
                    team1.Hide();
                    team2.Hide();
                    team3.Hide();
                    team4.Hide();
                    team5.Hide();
                    team6.Hide();
                    team7.Hide();
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 1:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Hide();
                    team3.Hide();
                    team4.Hide();
                    team5.Hide();
                    team6.Hide();
                    team7.Hide();
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 2:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Hide();
                    team4.Hide();
                    team5.Hide();
                    team6.Hide();
                    team7.Hide();
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 3:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 1];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Hide();
                    team5.Hide();
                    team6.Hide();
                    team7.Hide();
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 4:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Hide();
                    team6.Hide();
                    team7.Hide();
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 5:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Hide();
                    team7.Hide();
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 6:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Hide();
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 7:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Hide();
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 8:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Hide();
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 9:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Hide();
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 10:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Hide();
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 11:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Hide();
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 12:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Show();
                    team12.Text = "12 - " + name[division, 11];
                    team13.Hide();
                    team14.Hide();
                    team15.Hide();
                    break;
                case 13:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Show();
                    team12.Text = "12 - " + name[division, 11];
                    team13.Show();
                    team13.Text = "13 - " + name[division, 12];
                    team14.Hide();
                    team15.Hide();
                    break;
                case 14:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Show();
                    team12.Text = "12 - " + name[division, 11];
                    team13.Show();
                    team13.Text = "13 - " + name[division, 12];
                    team14.Show();
                    team14.Text = "14 - " + name[division, 13];
                    team15.Hide();
                    break;
                case 15:
                    team1.Show();
                    team1.Text = "1 - " + name[division, 0];
                    team2.Show();
                    team2.Text = "2 - " + name[division, 1];
                    team3.Show();
                    team3.Text = "3 - " + name[division, 2];
                    team4.Show();
                    team4.Text = "4 - " + name[division, 3];
                    team5.Show();
                    team5.Text = "5 - " + name[division, 4];
                    team6.Show();
                    team6.Text = "6 - " + name[division, 5];
                    team7.Show();
                    team7.Text = "7 - " + name[division, 6];
                    team8.Show();
                    team8.Text = "8 - " + name[division, 7];
                    team9.Show();
                    team9.Text = "9 - " + name[division, 8];
                    team10.Show();
                    team10.Text = "10 - " + name[division, 9];
                    team11.Show();
                    team11.Text = "11 - " + name[division, 10];
                    team12.Show();
                    team12.Text = "12 - " + name[division, 11];
                    team13.Show();
                    team13.Text = "13 - " + name[division, 12];
                    team14.Show();
                    team14.Text = "14 - " + name[division, 13];
                    team15.Show();
                    team15.Text = "15 - " + name[division, 14];
                    break;
            }

            //Shared grounds indicator

            if (sharedCount[division, 0] != 0)
            {
                //team shares grounds
                richTextBox1.Show();
                team1.BringToFront();
                team1.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                metroLabel25.Show();
                metroLabel25.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team1.Text + " shares with:\n      " + shared[division, 0, 0];
                for (int j = 1; j < sharedCount[division, 0]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 0, j];
                }
            }
            else
            {
                team1.BackColor = Color.White;
            }
            if (sharedCount[division, 1] != 0)
            {
                //team shares grounds
                richTextBox2.Show();
                team2.BringToFront();
                team2.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                metroLabel25.Show();
                line2.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team2.Text + " shares with:\n      " + shared[division, 1, 0];
                for (int j = 1; j < sharedCount[division, 1]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 1, j];
                }
            }
            else
            {
                team2.BackColor = Color.White;
            }
            if (sharedCount[division, 2] != 0)
            {
                //team shares grounds
                richTextBox3.Show();
                team3.BringToFront();
                team3.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line2.Show();
                line3.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team3.Text + " shares with:\n      " + shared[division, 2, 0];
                for (int j = 1; j < sharedCount[division, 2]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 2, j];
                }
            }
            else
            {
                team3.BackColor = Color.White;
            }
            if (sharedCount[division, 3] != 0)
            {
                //team shares grounds
                richTextBox4.Show();
                team4.BringToFront();
                team4.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line3.Show();
                line4.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team4.Text + " shares with:\n      " + shared[division, 3, 0];
                for (int j = 1; j < sharedCount[division, 3]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 3, j];
                }
            }
            else
            {
                team4.BackColor = Color.White;
            }
            if (sharedCount[division, 4] != 0)
            {
                //team shares grounds
                richTextBox5.Show();
                team5.BringToFront();
                team5.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line4.Show();
                line5.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team5.Text + " shares with:\n      " + shared[division, 4, 0];
                for (int j = 1; j < sharedCount[division, 4]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 4, j];
                }
            }
            else
            {
                team5.BackColor = Color.White;
            }
            if (sharedCount[division, 5] != 0)
            {
                //team shares grounds
                richTextBox6.Show();
                team6.BringToFront();
                team6.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line5.Show();
                line6.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team6.Text + " shares with:\n      " + shared[division, 5, 0];
                for (int j = 1; j < sharedCount[division, 5]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 5, j];
                }
            }
            else
            {
                team6.BackColor = Color.White;
            }
            if (sharedCount[division, 6] != 0)
            {
                //team shares grounds
                richTextBox7.Show();
                team7.BringToFront();
                team7.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line6.Show();
                line7.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team7.Text + " shares with:\n      " + shared[division, 6, 0];
                for (int j = 1; j < sharedCount[division, 6]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 6, j];
                }
            }
            else
            {
                team7.BackColor = Color.White;
            }
            if (sharedCount[division, 7] != 0)
            {
                //team shares grounds
                richTextBox8.Show();
                team8.BringToFront();
                team8.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line7.Show();
                line8.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team8.Text + " shares with:\n      " + shared[division, 7, 0];
                for (int j = 1; j < sharedCount[division, 7]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 7, j];
                }
            }
            else
            {
                team8.BackColor = Color.White;
            }
            if (sharedCount[division, 8] != 0)
            {
                //team shares grounds
                richTextBox9.Show();
                team9.BringToFront();
                team9.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line8.Show();
                line9.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team9.Text + " shares with:\n      " + shared[division, 8, 0];
                for (int j = 1; j < sharedCount[division, 8]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 8, j];
                }
            }
            else
            {
                team9.BackColor = Color.White;
            }
            if (sharedCount[division, 9] != 0)
            {
                //team shares grounds
                richTextBox10.Show();
                team10.BringToFront();
                team10.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line9.Show();
                line10.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team10.Text + " shares with:\n      " + shared[division, 9, 0];
                for (int j = 1; j < sharedCount[division, 9]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 9, j];
                }
            }
            else
            {
                team10.BackColor = Color.White;
            }
            if (sharedCount[division, 10] != 0)
            {
                //team shares grounds
                richTextBox11.Show();
                team11.BringToFront();
                team11.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line10.Show();
                line11.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team11.Text + " shares with:\n      " + shared[division, 10, 0];
                for (int j = 1; j < sharedCount[division, 10]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 10, j];
                }
            }
            else
            {
                team11.BackColor = Color.White;
            }
            if (sharedCount[division, 11] != 0)
            {
                //team shares grounds
                richTextBox12.Show();
                team12.BringToFront();
                team12.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line11.Show();
                line12.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team12.Text + " shares with:\n      " + shared[division, 11, 0];
                for (int j = 1; j < sharedCount[division, 11]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 11, j];
                }
            }
            else
            {
                team12.BackColor = Color.White;
            }
            if (sharedCount[division, 12] != 0)
            {
                //team shares grounds
                richTextBox13.Show();
                team13.BringToFront();
                team13.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line12.Show();
                line13.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team13.Text + " shares with:\n      " + shared[division, 12, 0];
                for (int j = 1; j < sharedCount[division, 12]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 12, j];
                }
            }
            else
            {
                team13.BackColor = Color.White;
            }
            if (sharedCount[division, 13] != 0)
            {
                //team shares grounds
                richTextBox14.Show();
                team14.BringToFront();
                team14.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line13.Show();
                line14.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team14.Text + " shares with:\n      " + shared[division, 13, 0];
                for (int j = 1; j < sharedCount[division, 13]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 13, j];
                }
            }
            else
            {
                team14.BackColor = Color.White;
            }
            if (sharedCount[division, 14] != 0)
            {
                //team shares grounds
                richTextBox15.Show();
                team15.BringToFront();
                team15.BackColor = Color.DeepSkyBlue;
                metroLabel24.Show();
                line14.Show();
                sharedLine.Show();
                sharedGroundsInfo = sharedGroundsInfo + "\n" + team15.Text + " shares with:\n      " + shared[division, 14, 0];
                for (int j = 1; j < sharedCount[division, 14]; j++)
                {
                    sharedGroundsInfo = sharedGroundsInfo + ", " + shared[division, 14, j];
                }
            }
            else
            {
                team15.BackColor = Color.White;
            }

            metroLabel24.Text = sharedGroundsInfo;
            #endregion

        }
    }
}
